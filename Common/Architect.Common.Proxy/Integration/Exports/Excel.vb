#Region "using"

Imports ClosedXML.Excel
Imports System.Globalization

#End Region

Namespace Integration.Exports

    Public NotInheritable Class Excel

#Region "Main Methods"

        Public Shared Sub DoWork(specification As Contracts.Model, excelFilename As String, lookUpValues As Boolean, withData As Boolean)
            Dim workbook As XLWorkbook = Generate(specification, lookUpValues)
            Dim worksheet As IXLWorksheet = workbook.Worksheets.First
            Dim selectStatement As String = "SELECT "
            Dim orderby As String = String.Empty
            Dim sentenceOrder As String = String.Empty
            Dim records As DataTable
            Dim line As Integer

            If withData Then
                For Each columnItem As Contracts.Model.Column In specification.Columns
                    If Not columnItem.Audit Then
                        selectStatement += String.Format(CultureInfo.InvariantCulture, "{0},", columnItem.Name)

                        If columnItem.Sequence Then
                            orderby += String.Format(CultureInfo.InvariantCulture, "{0},", columnItem.Name)
                        End If
                    End If
                Next

                selectStatement = selectStatement.Substring(0, selectStatement.Length - 1)

                If orderby.Length > 0 Then
                    orderby = orderby.Substring(0, orderby.Length - 1)
                    sentenceOrder = String.Format(CultureInfo.InvariantCulture, " ORDER BY {0}", orderby)
                End If

                selectStatement += String.Format(CultureInfo.InvariantCulture, " FROM {0}{1}", specification.TableName, sentenceOrder)

                With New DataManagerFactory(selectStatement, specification.TableName, specification.ConnectionStringName)
                    records = .QueryExecuteToTable(True)
                End With

                If records.Rows.Count > 0 Then
                    'Genera las filas
                    line = 2

                    For Each row As DataRow In records.Rows
                        For Each columnItem As Contracts.Model.Column In specification.Columns

                            If Not columnItem.Audit Then
                                worksheet.Cell(line, columnItem.ExcelColumnNumber).Value = row.Item(columnItem.Name)

                                With columnItem
                                    worksheet.Cell(line, columnItem.ExcelColumnNumber).Value = row.Item(.Name)

                                    If Not String.IsNullOrEmpty(.LookUpStatement) AndAlso
                                        Not IsNothing(.LookUpData) AndAlso .LookUpData.Rows.Count > 0 Then

                                        For Each itemData As DataRow In .LookUpData.Rows
                                            If String.Equals(row.Item(.Name), itemData(0), StringComparison.CurrentCultureIgnoreCase) Then
                                                worksheet.Cell(line, columnItem.ExcelColumnNumber).Value = itemData(1)

                                                Exit For
                                            End If
                                        Next
                                    End If
                                End With

                                If columnItem.Sequence Then
                                    With worksheet.Cell(line, columnItem.ExcelColumnNumber).SetDataValidation
                                        .AllowedValues = XLAllowedValues.Custom
                                        .Custom(String.Format("""{0}""", row.Item(columnItem.Name)))
                                        .Operator = XLOperator.Between
                                        .IgnoreBlanks = False
                                        .ErrorStyle = XLErrorStyle.Stop
                                        .ErrorMessage = "No se puede modificar el valor de esta celda"
                                        .ShowErrorMessage = True
                                    End With
                                End If
                            End If
                        Next

                        line += 1
                    Next

                    worksheet.RangeUsed().SetAutoFilter()
                    worksheet.Columns(1, specification.Columns.Count).AdjustToContents(1, line)
                End If
            End If

            workbook.SaveAs(excelFilename)
        End Sub

        Public Shared Function Generate(specification As Contracts.Model, lookUpValues As Boolean) As XLWorkbook
            Dim workbook As New XLWorkbook(XLEventTracking.Disabled)
            Dim sheetTemplate As IXLWorksheet = workbook.Worksheets.Add(specification.RealTitle).SetTabColor(XLColor.Green)
            Dim sheetLookup As IXLWorksheet = sheetTemplate 'workbook.Worksheets.Add("Listas")

            With workbook.Properties
                .Author = "Generador de plantillas"
                .Title = specification.Title
                .Company = "MAPFRE Costa Rica"
                .Keywords = ":" & specification.TableName
            End With

            With sheetTemplate
                '.Visibility = True
                .Style.Font.FontName = "Calibri"
                .Style.Font.FontSize = 11
            End With

            With sheetLookup
                '.Visibility = XLWorksheetVisibility.VeryHidden
            End With

            Dim line As Integer = 1
            Dim col As Integer = 1
            Dim lookupCol As Integer = 53
            Dim lookupRow As Integer = 1
            Dim lookupWidth As Boolean = False

            For Each columnSpec As Contracts.Model.Column In specification.Columns

                If Not columnSpec.Audit Then

                    Select Case columnSpec.Type
                        Case DbType.AnsiString, DbType.AnsiStringFixedLength
                            sheetTemplate.Column(col).Style.NumberFormat.NumberFormatId = 0
                            '    sheetTemplate.Column(col).DataType = XLCellValues.Text

                        Case DbType.Int32
                            sheetTemplate.Column(col).Style.NumberFormat.NumberFormatId = 1

                            With sheetTemplate.Column(col).SetDataValidation
                                .AllowedValues = XLAllowedValues.WholeNumber
                                .ErrorStyle = XLErrorStyle.Stop
                                .ErrorMessage = "Debe indicar un valor numerico"
                                .ShowErrorMessage = True
                                .ShowInputMessage = False
                            End With

                        Case DbType.Decimal
                            If columnSpec.Scale = 0 Then
                                sheetTemplate.Column(col).Style.NumberFormat.NumberFormatId = 1
                            Else
                                sheetTemplate.Column(col).Style.NumberFormat.NumberFormatId = 2
                            End If

                            With sheetTemplate.Column(col).SetDataValidation
                                If columnSpec.Scale = 0 Then
                                    .AllowedValues = XLAllowedValues.WholeNumber
                                Else
                                    .AllowedValues = XLAllowedValues.Decimal
                                End If

                                .ErrorStyle = XLErrorStyle.Stop
                                .ErrorMessage = "Debe indicar un valor numerico"
                                .ShowErrorMessage = True
                                .ShowInputMessage = False
                            End With

                        Case DbType.Boolean
                            '    sheetTemplate.Column(col).DataType = XLCellValues.Boolean

                        Case DbType.DateTime
                            '                    sheetTemplate.Column(col).DataType = XLCellValues.DateTime
                            sheetTemplate.Column(col).Style.NumberFormat.NumberFormatId = 14
                            'sheetTemplate.Column(col).Style.NumberFormat.Format = "yyyy/MM/dd"
                            With sheetTemplate.Column(col).SetDataValidation
                                .AllowedValues = XLAllowedValues.Date
                                '.Date.EqualOrGreaterThan( New DateTime(1900, 1, 1))
                                '                        .InputTitle ="Can't party like it's 1900."
                                '                       .InputMessage = "Please enter a date in this century."
                                .ErrorStyle = XLErrorStyle.Stop
                                .ErrorMessage = "Debe indicar una fecha valida"
                                .ShowErrorMessage = True
                                .ShowInputMessage = False
                            End With

                        Case Else
                    End Select

                    lookupWidth = False

                    If lookUpValues AndAlso columnSpec.LookUpStatement.IsNotEmpty Then
                        If columnSpec.LookUpData.IsEmpty Then
                            With New DataManagerFactory(columnSpec.LookUpStatement, String.Format("{0}.{1}", specification.TableName, columnSpec.Name), specification.ConnectionStringName)
                                columnSpec.LookUpData = .QueryExecuteToTable(True)
                            End With
                        End If

                        lookupRow = 0

                        For Each row As DataRow In columnSpec.LookUpData.Rows
                            lookupRow += 1
                            'sheetLookup.Cell(lookupRow, lookupCol).Value = String.Format("{0} - {1}", row(0).ToString.Trim, row(1).ToString.Trim)
                            sheetLookup.Cell(lookupRow, lookupCol).Value = String.Format(CultureInfo.InvariantCulture, "{0}", row(1).ToString.Trim)
                        Next

                        sheetLookup.Columns(lookupCol, lookupCol).AdjustToContents()
                        sheetLookup.Columns(lookupCol).Hide()

                        Dim rng As IXLRange = sheetLookup.Range(sheetLookup.Cell(1, lookupCol).Address, sheetLookup.Cell(lookupRow, lookupCol).Address)

                        rng.AddToNamed(String.Format("Lookup{0}", lookupCol))
                        sheetTemplate.Column(col).Width = sheetLookup.Column(lookupCol).Width
                        lookupWidth = True

                        With sheetTemplate.Column(col).SetDataValidation
                            .AllowedValues = XLAllowedValues.List
                            .List(rng)
                            .ErrorStyle = XLErrorStyle.Stop
                            .ErrorMessage = "Incluya los valores de la lista"
                            .ShowErrorMessage = True
                            .ShowInputMessage = False
                        End With

                        lookupCol += 1
                    End If

                    sheetTemplate.Cell(line, col).Style.Font.FontSize = 12
                    sheetTemplate.Cell(line, col).Style.Fill.BackgroundColor = XLColor.FromTheme(XLThemeColor.Accent3, 0.8)
                    sheetTemplate.Cell(line, col).Style.Font.Bold = True 'item.Required
                    sheetTemplate.Cell(line, col).Style.Protection.Locked = True
                    sheetTemplate.Cell(line, col).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    sheetTemplate.Cell(line, col).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center
                    sheetTemplate.Cell(line, col).SetValue(columnSpec.RealTitle)
                    sheetTemplate.Cell(line, col).Style.Alignment.WrapText = True

                    If Not String.IsNullOrEmpty(columnSpec.Comment) Then
                        sheetTemplate.Cell(line, col).Comment.AddText(columnSpec.Comment)
                    End If

                    If Not columnSpec.IsNullable Then
                        If Not String.IsNullOrEmpty(columnSpec.Comment) Then
                            If columnSpec.Comment.EndsWith(".") Then
                                sheetTemplate.Cell(line, col).Comment.AddText(" ")
                            Else
                                sheetTemplate.Cell(line, col).Comment.AddText(". ")
                            End If
                        End If

                        sheetTemplate.Cell(line, col).Comment.AddText("Esta columna es requerida.")
                    End If

                    With sheetTemplate.Cell(line, col).SetDataValidation
                        .AllowedValues = XLAllowedValues.Custom
                        .Custom(String.Format("""{0}""", columnSpec.RealTitle))
                        .Operator = XLOperator.Between
                        .IgnoreBlanks = False
                        .ErrorStyle = XLErrorStyle.Stop
                        .ErrorMessage = "No se puede modificar el nombre de la columna"
                        .ShowErrorMessage = True
                    End With

                    If IsNothing(columnSpec.LookUpData) Then
                        sheetTemplate.Columns(col, col).AdjustToContents()
                    End If

                    col += 1
                End If
            Next

            Return workbook
        End Function


#End Region

    End Class

End Namespace
