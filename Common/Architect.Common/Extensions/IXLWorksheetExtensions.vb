Imports System.Runtime.CompilerServices
Imports Architect.Common.Exceptions
Imports ClosedXML.Excel

Namespace Extensions

    Public Module IXLWorksheetExtensions

        <Extension()>
        Public Function StringValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, column As String) As String
            Dim result As String = String.Empty
            If Not IsNothing(sheet.Cell(rowNumber, column).Value) Then
                result = sheet.Cell(rowNumber, column).Value
                result = result.Trim
            End If
            Return result
        End Function

        <Extension()>
        Public Function StringValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, columnNumber As Integer) As String
            Dim result As String = String.Empty
            If Not IsNothing(sheet.Cell(rowNumber, columnNumber).Value) Then
                result = sheet.Cell(rowNumber, columnNumber).Value
                result = result.Trim
            End If
            Return result
        End Function

        <Extension()>
        Public Function StringValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, columnNumber As Integer, ByRef specified As Boolean) As String
            Dim result As String = sheet.Cell(rowNumber, columnNumber).Value
            specified = False
            If Not String.IsNullOrEmpty(result) Then
                result = result.Trim
                specified = True
            End If
            Return result
        End Function


        <Extension()>
        Public Function IntegerValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, column As String) As Integer
            Dim result As String = sheet.Cell(rowNumber, column).Value
            If Not String.IsNullOrEmpty(result) Then
                result = result.Trim
            Else
                result = "0"
            End If
            Return result
        End Function

        <Extension()>
        Public Function IntegerValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, columnNumber As Integer) As Integer
            Dim result As String = sheet.Cell(rowNumber, columnNumber).Value
            If Not String.IsNullOrEmpty(result) Then
                result = result.Trim
            Else
                result = "0"
            End If
            Return result
        End Function

        <Extension()>
        Public Function IntegerValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, columnNumber As Integer, ByRef specified As Boolean) As Integer
            Dim result As String = sheet.Cell(rowNumber, columnNumber).Value
            specified = False
            If Not String.IsNullOrEmpty(result) Then
                result = result.Trim
                specified = True
            Else
                result = "0"
                specified = False
            End If
            Return result
        End Function

        <Extension()>
        Public Function DecimalValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, column As String) As Decimal
            Try
                If String.IsNullOrEmpty(sheet.Cell(rowNumber, column).Value) Then
                    Return 0
                Else
                    Dim value As Decimal = sheet.Cell(rowNumber, column).Value
                    Return value
                End If
            Catch ex As Exception
                Throw New WorksheetCellException(rowNumber, column, ex)
            End Try
        End Function

        <Extension()>
        Public Function DecimalValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, column As String, format As String) As Decimal
            Try
                If String.IsNullOrEmpty(sheet.Cell(rowNumber, column).Value) Then
                    Return 0.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                Else
                    Dim value As Decimal = sheet.Cell(rowNumber, column).Value
                    Return value.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                End If
            Catch ex As Exception
                Throw New WorksheetCellException(rowNumber, column, ex)
            End Try
        End Function

        <Extension()>
        Public Function DecimalValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, columnNumber As Integer, format As String) As Decimal

            If String.IsNullOrEmpty(sheet.Cell(rowNumber, columnNumber).Value) Then
                Return 0.ToString(format, New System.Globalization.CultureInfo("en-US", False))
            Else
                Dim value As Decimal = sheet.Cell(rowNumber, columnNumber).Value
                Return value.ToString(format, New System.Globalization.CultureInfo("en-US", False))
            End If
        End Function

        <Extension()>
        Public Function DateTimeValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, column As String) As Date
            Dim result As Date = DateTime.MinValue
            Dim internal As Date

            If Not String.IsNullOrEmpty(sheet.Cell(rowNumber, column).Value) Then
                Try
                    If TypeName(sheet.Cell(rowNumber, column).Value) <> "Date" Then
                        'DEBERIA: La cultura por default deberia de ser un settings.
                        If Not DateTime.TryParse(sheet.Cell(rowNumber, column).Value,
                                             New System.Globalization.CultureInfo("es-CR", False),
                                             Globalization.DateTimeStyles.None,
                                             internal) Then
                            internal = sheet.Cell(rowNumber, column).Value
                        End If
                    Else
                        internal = sheet.Cell(rowNumber, column).Value
                    End If

                    result = internal
                Catch ex As Exception
                    Throw New WorksheetCellException(rowNumber, column, ex)
                End Try

            End If

            Return result
        End Function
        <Extension()>
        Public Function DateTimeValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, columnNumber As Integer) As Date
            Dim result As Date = DateTime.MinValue
            Dim internal As Date

            If Not String.IsNullOrEmpty(sheet.Cell(rowNumber, columnNumber).Value) Then
                Try
                    If TypeName(sheet.Cell(rowNumber, columnNumber).Value) <> "Date" Then
                        'DEBERIA: La cultura por default deberia de ser un settings.
                        If Not DateTime.TryParse(sheet.Cell(rowNumber, columnNumber).Value,
                                             New System.Globalization.CultureInfo("es-CR", False),
                                             Globalization.DateTimeStyles.None,
                                             internal) Then
                            internal = sheet.Cell(rowNumber, columnNumber).Value
                        End If
                    Else
                        internal = sheet.Cell(rowNumber, columnNumber).Value
                    End If

                    result = internal
                Catch ex As Exception
                    Throw New WorksheetCellException(rowNumber, columnNumber.ToString(), ex)
                End Try

            End If

            Return result
        End Function

        <Extension()>
        Public Function FormatDecimalValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, column As String, format As String) As String
            Try
                Dim result As String = String.Empty

                If String.IsNullOrEmpty(sheet.Cell(rowNumber, column).Value) Then
                    Return 0.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                Else
                    Dim value As Decimal = sheet.Cell(rowNumber, column).Value
                    Return value.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                End If
            Catch ex As Exception
                Throw New WorksheetCellException(rowNumber, column, ex)
            End Try
        End Function

        <Extension()>
        Public Function FormatDecimalValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, column As String, format As String, message As DataTable, sheetName As String) As String
            Try
                Dim result As String = String.Empty

                If String.IsNullOrEmpty(sheet.Cell(rowNumber, column).Value) Then
                    Return 0.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                Else
                    Dim value As Decimal = sheet.Cell(rowNumber, column).Value
                    Return value.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                End If
            Catch ex As Exception
                Throw New WorksheetCellException(rowNumber, column, ex)
            End Try
        End Function

        <Extension()>
        Public Function FormatDecimalValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, columnNumber As Integer, format As String) As String
            Dim result As String = String.Empty

            Try


                If String.IsNullOrEmpty(sheet.Cell(rowNumber, columnNumber).Value) Then
                    Return 0.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                Else
                    Dim value As Decimal = sheet.Cell(rowNumber, columnNumber).Value
                    Return value.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                End If
            Catch ex As Exception
                Throw New WorksheetCellException(rowNumber, columnNumber.ToString(), ex)
            End Try
        End Function

        <Extension()>
        Public Function FormatDecimalValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, columnNumber As Integer, format As String, ByRef specified As Boolean) As String
            Dim result As String = String.Empty

            If String.IsNullOrEmpty(sheet.Cell(rowNumber, columnNumber).Value) Then
                specified = False
                Return 0.ToString(format, New System.Globalization.CultureInfo("en-US", False))
            Else
                Dim value As Decimal = sheet.Cell(rowNumber, columnNumber).Value
                specified = True
                Return value.ToString(format, New System.Globalization.CultureInfo("en-US", False))
            End If
        End Function

        <Extension()>
        Public Function FormatDateTimeValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, columnNumber As Integer, format As String) As String
            Dim result As String = String.Empty
            Dim internal As Date

            If Not String.IsNullOrEmpty(sheet.Cell(rowNumber, columnNumber).Value) Then
                Try
                    If TypeName(sheet.Cell(rowNumber, columnNumber).Value) <> "Date" Then
                        'DEBERIA: La cultura por default deberia de ser un settings.
                        If Not DateTime.TryParse(sheet.Cell(rowNumber, columnNumber).Value,
                                             New System.Globalization.CultureInfo("es-CR", False),
                                             Globalization.DateTimeStyles.None,
                                             internal) Then
                            internal = sheet.Cell(rowNumber, columnNumber).Value
                        End If
                    Else
                        internal = sheet.Cell(rowNumber, columnNumber).Value
                    End If

                    result = internal.ToString(format)
                Catch ex As Exception
                    Throw New WorksheetCellException(rowNumber, columnNumber.ToString(), ex)
                End Try

            End If

            Return result
        End Function

        <Extension()>
        Public Function EnumValue(Of T)(ByVal sheet As IXLWorksheet, rowNumber As Integer, columnNumber As Integer) As T
            Try
                Dim valueType As Type = GetType(T)
                Return CType([Enum].Parse(valueType, sheet.Cell(rowNumber, columnNumber).Value), T)
            Catch ex As ArgumentException
                Return Nothing
            End Try
        End Function

        <Extension()>
        Public Function EnumValue(Of T)(ByVal sheet As IXLWorksheet, rowNumber As Integer, column As String, ByRef withError As Boolean) As T
            Try
                Dim valueType As Type = GetType(T)
                Dim value As T = [Enum].Parse(valueType, sheet.Cell(rowNumber, column).Value)

                withError = False
                Return value
            Catch ex As ArgumentException
                withError = True
                Return Nothing
            End Try
        End Function

        <Extension()>
        Public Function EnumValue(Of T)(ByVal sheet As IXLWorksheet, rowNumber As Integer, columnNumber As Integer, ByRef withError As Boolean) As T
            Try
                Dim valueType As Type = GetType(T)
                Dim value As T = [Enum].Parse(valueType, sheet.Cell(rowNumber, columnNumber).Value)

                withError = False
                Return value
            Catch ex As ArgumentException
                withError = True
                Return Nothing
            End Try
        End Function

        <Extension()>
        Public Function EnumValue(Of T)(ByVal sheet As IXLWorksheet, rowNumber As Integer, columnNumber As Integer, ByRef specified As Boolean, ByRef withError As Boolean) As T

            Try
                Dim valueType As Type = GetType(T)
                Dim value As T = Nothing
                If Not String.IsNullOrEmpty(sheet.Cell(rowNumber, columnNumber).Value) Then
                    Dim x As String = sheet.Cell(rowNumber, columnNumber).Value
                    value = [Enum].Parse(valueType, x)
                    specified = True
                    withError = False
                Else
                    specified = False
                    withError = False
                End If
                Return value
            Catch ex As ArgumentException
                specified = False
                withError = True
                Return Nothing
            End Try
        End Function

        <Extension()>
        Public Function FormatDecimalValue(ByVal sheet As IXLWorksheet, rowNumber As Integer, column As String, format As String, message As DataTable, sheetName As String, ByRef specified As Boolean) As String
            Try
                Dim result As String = String.Empty

                If String.IsNullOrEmpty(sheet.Cell(rowNumber, column).Value) Then
                    specified = True
                    Return 0.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                Else
                    Dim value As Decimal = sheet.Cell(rowNumber, column).Value
                    specified = True
                    Return value.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                End If
            Catch ex As Exception
                Throw New WorksheetCellException(rowNumber, column, ex)
            End Try
        End Function

        <Extension()>
        Public Function FormatDecimalValueOnlyPositive(ByVal sheet As IXLWorksheet, rowNumber As Integer, column As String, format As String, message As DataTable, sheetName As String) As String
            Dim specified As Boolean
            Return FormatDecimalValueOnlyPositive(sheet, rowNumber, column, format, message, sheetName, specified)
        End Function

        <Extension()>
        Public Function FormatDecimalValueOnlyPositive(ByVal sheet As IXLWorksheet, rowNumber As Integer, column As String, format As String, message As DataTable, sheetName As String, ByRef specified As Boolean) As String
            Try
                Dim result As String = String.Empty

                If String.IsNullOrEmpty(sheet.Cell(rowNumber, column).Value) Then
                    specified = True
                    Return 0.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                Else
                    Dim value As Decimal = sheet.Cell(rowNumber, column).Value

                    If value < 0 Then
                        Dim currentRow As DataRow = message.NewRow()
                        currentRow("tipo") = "error"
                        currentRow("message") = String.Format("En la hoja '{3}' la celda '{0}:{1}' el valor '{2}' debe ser positivo", rowNumber, column, value, sheetName)
                        message.Rows.Add(currentRow)
                    Else
                        specified = True
                    End If
                    Return value.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                End If
            Catch ex As Exception
                Throw New WorksheetCellException(rowNumber, column, ex)
            End Try
        End Function

        <Extension()>
        Public Function FormatDecimalValueOnlyNegative(ByVal sheet As IXLWorksheet, rowNumber As Integer, column As String, format As String, message As DataTable, sheetName As String, ByRef specified As Boolean) As String
            Try
                Dim result As String = String.Empty

                If String.IsNullOrEmpty(sheet.Cell(rowNumber, column).Value) Then
                    specified = True
                    Return 0.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                Else
                    Dim value As Decimal = sheet.Cell(rowNumber, column).Value

                    If value > 0 Then
                        Dim currentRow As DataRow = message.NewRow()
                        currentRow("tipo") = "error"
                        currentRow("message") = String.Format("En la hoja '{3}' la celda '{0}:{1}' el valor '{2}' debe ser negativo", rowNumber, column, value, sheetName)
                        message.Rows.Add(currentRow)
                    Else
                        specified = True
                    End If
                    Return value.ToString(format, New System.Globalization.CultureInfo("en-US", False))
                End If
            Catch ex As Exception
                Throw New WorksheetCellException(rowNumber, column, ex)
            End Try
        End Function

    End Module

End Namespace