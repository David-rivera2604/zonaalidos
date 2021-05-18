#Region "using"

Imports ClosedXML.Excel
Imports System.Globalization

#End Region

Namespace Integration.Import

    Public NotInheritable Class Excel

#Region "Main Methods"

        Public Shared Sub DoWorkWithDataManager(specification As Contracts.Model, excelFilename As String)
            Dim workbook As New XLWorkbook(excelFilename, XLEventTracking.Disabled)
            Dim workSheet As IXLWorksheet = workbook.Worksheet(specification.Worksheet)
            Dim ColCount As Integer = specification.RealDataColumnCount
            Dim value As String = String.Empty
            Dim RowEmpty As Boolean = False
            Dim realvalue As Object = Nothing
            Dim isNull As Boolean
            Dim columnNameList As String = String.Empty
            Dim columnParamList As String = String.Empty

            If specification.Sequence.TableName.IsNotEmpty AndAlso specification.Sequence.ColumnName.IsNotEmpty Then

                With New DataManagerFactory(String.Format(CultureInfo.InvariantCulture, "SELECT NVL(MAX({1}),0) FROM {0}",
                                                          specification.Sequence.TableName, specification.Sequence.ColumnName),
                                                      specification.Sequence.TableName, specification.ConnectionStringName)

                    specification.LastSequenceNumber = .QueryExecuteScalarToInteger
                End With
            End If

            For RowNumber As Integer = specification.FirstDataRow To 10000
                RowEmpty = True

                For Each columnSpec As Contracts.Model.Column In specification.Columns
                    If columnSpec.Visible Then
                        value = workSheet.Cell(RowNumber, columnSpec.ExcelColumnNumber).Value

                        If value.IsNotEmpty Then
                            RowEmpty = False
                            Exit For
                        End If
                    End If
                Next

                If RowEmpty Then
                    Exit For
                Else
                    columnNameList = String.Empty
                    columnParamList = String.Empty

                    With New DataManagerFactory("...", specification.TableName, specification.ConnectionStringName)
                        '.ForceLocalMode = True

                        For Each columnSpec As Contracts.Model.Column In specification.Columns

                            If columnSpec.Sequence Then
                                specification.LastSequenceNumber += 1
                                realvalue = Convert.ToInt32(specification.LastSequenceNumber)

                                columnNameList += String.Format("{0},", columnSpec.Name)
                                columnParamList += String.Format("@:{0},", columnSpec.Name)
                                .AddParameter(columnSpec.Name, columnSpec.Type, columnSpec.Size, False, realvalue)

                            ElseIf columnSpec.Visible Then
                                value = workSheet.Cell(RowNumber, columnSpec.ExcelColumnNumber).Value

                                If value.IsEmpty Then
                                    isNull = True
                                    realvalue = Nothing

                                Else
                                    isNull = False
                                    Select Case columnSpec.Type
                                        Case DbType.Decimal
                                            'realvalue = 0D
                                            'realvalue = Convert.ToDecimal(value, New System.Globalization.CultureInfo("en-US", False))
                                            'realvalue = Convert.ToDecimal(value)
                                            realvalue = workSheet.Cell(RowNumber, columnSpec.ExcelColumnNumber).GetDouble

                                            If IsNothing(realvalue) Then
                                                isNull = True
                                                realvalue = Nothing
                                            End If

                                        Case DbType.DateTime
                                            'realvalue = Convert.ToDateTime(value, New System.Globalization.CultureInfo("es-CR", False))
                                            'realvalue = Convert.ToDateTime(value)
                                            realvalue = workSheet.Cell(RowNumber, columnSpec.ExcelColumnNumber).GetDateTime

                                            If IsNothing(realvalue) OrElse realvalue = Date.MinValue Then
                                                isNull = True
                                                realvalue = Nothing
                                            End If

                                        Case Else
                                            realvalue = value
                                    End Select
                                End If

                                columnNameList += String.Format("{0},", columnSpec.Name)
                                columnParamList += String.Format("@:{0},", columnSpec.Name)
                                .AddParameter(columnSpec.Name, columnSpec.Type, columnSpec.Size, isNull, realvalue)

                            ElseIf columnSpec.Constant.IsNotEmpty Then
                                columnNameList += String.Format("{0},", columnSpec.Name)
                                columnParamList += String.Format("{0},", columnSpec.Constant)

                            ElseIf Not IsNothing(columnSpec.Value) Then
                                columnNameList += String.Format("{0},", columnSpec.Name)
                                columnParamList += String.Format("@:{0},", columnSpec.Name)
                                .AddParameter(columnSpec.Name, columnSpec.Type, columnSpec.Size, False, columnSpec.Value)

                            End If
                        Next

                        columnNameList = columnNameList.Substring(0, columnNameList.Length - 1)
                        columnParamList = columnParamList.Substring(0, columnParamList.Length - 1)

                        .Statement = String.Format(CultureInfo.InvariantCulture,
                                                   "INSERT INTO {0} ({1}) VALUES ({2})", specification.TableName, columnNameList, columnParamList)
                        .CommandExecute()
                    End With
                End If
            Next

            workSheet = Nothing
            workbook = Nothing
        End Sub

#End Region

    End Class

End Namespace