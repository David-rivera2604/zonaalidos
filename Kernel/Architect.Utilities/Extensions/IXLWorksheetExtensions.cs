using System;
using System.Data;
using ClosedXML.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Architect.Utilities.Extensions
{
    public static class IXLWorksheetExtensions
    {
        public static string StringValue(this IXLWorksheet sheet, int rowNumber, int columnNumber)
        {
            string result = string.Empty;
            if (!(sheet.Cell(rowNumber, columnNumber).Value.IsNotEmpty()))
            {
                result = Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value);
                result = result.Trim();
            }
            return result;
        }

        public static string StringValue(this IXLWorksheet sheet, int rowNumber, string column)
        {
            string result = string.Empty;
            if (!(sheet.Cell(rowNumber, column).Value.IsNotEmpty()))
            {
                result = Conversions.ToString(sheet.Cell(rowNumber, column).Value);
                result = result.Trim();
            }
            return result;
        }

        public static string StringValue(this IXLWorksheet sheet, int rowNumber, int columnNumber, ref bool specified)
        {
            string result = Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value);
            specified = false;
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Trim();
                specified = true;
            }
            return result;
        }

        public static string StringValue(this IXLWorksheet sheet, int rowNumber, string column, ref bool specified)
        {
            string result = Conversions.ToString(sheet.Cell(rowNumber, column).Value);
            specified = false;
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Trim();
                specified = true;
            }
            return result;
        }

        public static int IntegerValue(this IXLWorksheet sheet, int rowNumber, int columnNumber, ref bool specified)
        {
            string result = Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value);
            specified = false;
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Trim();
                specified = true;
            }
            else
            {
                result = "0";
                specified = false;
            }
            return Conversions.ToInteger(result);
        }

        public static int IntegerValue(this IXLWorksheet sheet, int rowNumber, string column)
        {
            string result = Conversions.ToString(sheet.Cell(rowNumber, column).Value);
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Trim();
            }
            else
            {
                result = "0";
            }
            return Conversions.ToInteger(result);
        }

        public static decimal DecimalValue(this IXLWorksheet sheet, int rowNumber, string column, string format)
        {
            try
            {
                if (string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, column).Value)))
                {
                    return Conversions.ToDecimal(0.ToString(format, new System.Globalization.CultureInfo("en-US", false)));
                }
                else
                {
                    decimal value = Conversions.ToDecimal(sheet.Cell(rowNumber, column).Value);
                    return Conversions.ToDecimal(value.ToString(format, new System.Globalization.CultureInfo("en-US", false)));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1} {2}", rowNumber, column, ex.Message), ex);
            }
        }

        public static decimal DecimalValue(this IXLWorksheet sheet, int rowNumber, int columnNumber, string format)
        {
            try
            {
                if (string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value)))
                {
                    return Conversions.ToDecimal(0.ToString(format, new System.Globalization.CultureInfo("en-US", false)));
                }
                else
                {
                    decimal value = Conversions.ToDecimal(sheet.Cell(rowNumber, columnNumber).Value);
                    return Conversions.ToDecimal(value.ToString(format, new System.Globalization.CultureInfo("en-US", false)));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1} {2}", rowNumber, columnNumber, ex.Message), ex);
            }
        }

        public static string FormatDecimalValue(this IXLWorksheet sheet, int rowNumber, string column, string format)
        {
            try
            {
                if (string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, column).Value)))                
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));                
                else
                {
                    decimal value = Conversions.ToDecimal(sheet.Cell(rowNumber, column).Value);
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1} {2}", rowNumber, column, ex.Message), ex);
            }
        }

        public static string FormatDecimalValue(this IXLWorksheet sheet, int rowNumber, string column, string format, DataTable message, string sheetName)
        {
            try
            {
                string result = string.Empty;

                if (string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, column).Value))) 
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false)); 
                else
                {
                    decimal value = Conversions.ToDecimal(sheet.Cell(rowNumber, column).Value);
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1} {2}", rowNumber, column, ex.Message), ex);
            }
        }

        public static string FormatDecimalValue(this IXLWorksheet sheet, int rowNumber, int columnNumber, string format)
        {
            string result = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value))) 
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false)); 
                else
                {
                    decimal value = Conversions.ToDecimal(sheet.Cell(rowNumber, columnNumber).Value);
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1} {2}", rowNumber, columnNumber, ex.Message), ex);
            }
        }

        public static string FormatDecimalValue(this IXLWorksheet sheet, int rowNumber, string columnNumber, string format, ref bool specified)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value)))
            {
                specified = false;
                return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
            }
            else
            {
                decimal value = Conversions.ToDecimal(sheet.Cell(rowNumber, columnNumber).Value);
                specified = true;
                return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
            }
        }

        public static string FormatDecimalValue(this IXLWorksheet sheet, int rowNumber, int columnNumber, string format, ref bool specified)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value)))
            {
                specified = false;
                return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
            }
            else
            {
                decimal value = Conversions.ToDecimal(sheet.Cell(rowNumber, columnNumber).Value);
                specified = true;
                return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
            }
        }

        public static string FormatDateTimeValue(this IXLWorksheet sheet, int rowNumber, int columnNumber, string format)
        {
            string result = string.Empty;
            DateTime @internal;

            if (!string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value)))
            {
                try
                {
                    if (Information.TypeName(sheet.Cell(rowNumber, columnNumber).Value) != "Date")
                    {
                        // TODO: La cultura por default deberia de ser un settings.
                        if (!DateTime.TryParse(Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value), new System.Globalization.CultureInfo("es-CR", false), System.Globalization.DateTimeStyles.None, out @internal))
                        {
                            @internal = Conversions.ToDate(sheet.Cell(rowNumber, columnNumber).Value);
                        }
                    }
                    else  
                        @internal = Conversions.ToDate(sheet.Cell(rowNumber, columnNumber).Value); 

                    result = @internal.ToString(format);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("{0}:{1} {2}", rowNumber, columnNumber, ex.Message), ex);
                }
            }

            return result;
        }

        public static string FormatDateTimeValue(this IXLWorksheet sheet, int rowNumber, string column, string format)
        {
            string result = string.Empty;
            DateTime @internal;

            if (!string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, column).Value)))
            {
                try
                {
                    if (Information.TypeName(sheet.Cell(rowNumber, column).Value) != "Date")
                    {
                        // TODO: La cultura por default deberia de ser un settings.
                        if (!DateTime.TryParse(Conversions.ToString(sheet.Cell(rowNumber, column).Value), new System.Globalization.CultureInfo("es-CR", false), System.Globalization.DateTimeStyles.None, out @internal))
                        {
                            @internal = Conversions.ToDate(sheet.Cell(rowNumber, column).Value);
                        }
                    }
                    else 
                        @internal = Conversions.ToDate(sheet.Cell(rowNumber, column).Value); 
                    result = @internal.ToString(format);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("{0}:{1} {2}", rowNumber, column, ex.Message), ex);
                }
            }

            return result;
        }

        public static T EnumValue<T>(this IXLWorksheet sheet, int rowNumber, int columnNumber)
        {
            try
            {
                var valueType = typeof(T);
                return Conversions.ToGenericParameter<T>(Enum.Parse(valueType, Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value)));
            }
            catch (ArgumentException ex)
            {
                return default;
            }
        }

        public static T EnumValue<T>(this IXLWorksheet sheet, int rowNumber, string column, ref bool withError)
        {
            try
            {
                var valueType = typeof(T);
                T value = Conversions.ToGenericParameter<T>(Enum.Parse(valueType, Conversions.ToString(sheet.Cell(rowNumber, column).Value)));

                withError = false;
                return value;
            }
            catch (ArgumentException ex)
            {
                withError = true;
                return default;
            }
        }

        public static T EnumValue<T>(this IXLWorksheet sheet, int rowNumber, int columnNumber, ref bool withError)
        {
            try
            {
                var valueType = typeof(T);
                T value = Conversions.ToGenericParameter<T>(Enum.Parse(valueType, Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value)));

                withError = false;
                return value;
            }
            catch (ArgumentException ex)
            {
                withError = true;
                return default;
            }
        }

        public static T EnumValue<T>(this IXLWorksheet sheet, int rowNumber, int columnNumber, ref bool specified, ref bool withError)
        {
            try
            {
                var valueType = typeof(T);
                T value = default;
                if (!string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value)))
                {
                    string x = Conversions.ToString(sheet.Cell(rowNumber, columnNumber).Value);
                    value = Conversions.ToGenericParameter<T>(Enum.Parse(valueType, x));
                    specified = true;
                    withError = false;
                }
                else
                {
                    specified = false;
                    withError = false;
                }
                return value;
            }
            catch (ArgumentException ex)
            {
                specified = false;
                withError = true;
                return default;
            }
        }

        public static T EnumValue<T>(this IXLWorksheet sheet, int rowNumber, string column, ref bool specified, ref bool withError)
        {
            try
            {
                var valueType = typeof(T);
                T value = default;
                if (!string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, column).Value)))
                {
                    string x = Conversions.ToString(sheet.Cell(rowNumber, column).Value);
                    value = Conversions.ToGenericParameter<T>(Enum.Parse(valueType, x));
                    specified = true;
                    withError = false;
                }
                else
                {
                    specified = false;
                    withError = false;
                }
                return value;
            }
            catch (ArgumentException ex)
            {
                specified = false;
                withError = true;
                return default;
            }
        }

        public static string FormatDecimalValue(this IXLWorksheet sheet, int rowNumber, string column, string format, DataTable message, string sheetName, ref bool specified)
        {
            try
            {
                string result = string.Empty;

                if (string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, column).Value)))
                {
                    specified = true;
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
                else
                {
                    decimal value = Conversions.ToDecimal(sheet.Cell(rowNumber, column).Value);
                    specified = true;
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1} {2}", rowNumber, column, ex.Message), ex);
            }
        }

        public static string FormatDecimalValueOnlyPositive(this IXLWorksheet sheet, int rowNumber, string column, string format, DataTable message, string sheetName)
        {
            var specified = default(bool);
            return sheet.FormatDecimalValueOnlyPositive(rowNumber, column, format, message, sheetName, ref specified);
        }

        public static string FormatDecimalValueOnlyPositive(this IXLWorksheet sheet, int rowNumber, string column, string format, DataTable message, string sheetName, ref bool specified)
        {
            try
            {
                string result = string.Empty;

                if (string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, column).Value)))
                {
                    specified = true;
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
                else
                {
                    decimal value = Conversions.ToDecimal(sheet.Cell(rowNumber, column).Value);

                    if (value < 0m)
                    {
                        var currentRow = message.NewRow();
                        currentRow["tipo"] = "error";
                        currentRow["message"] = string.Format("En la hoja '{3}' la celda '{0}:{1}' el valor '{2}' debe ser positivo", rowNumber, column, value, sheetName);
                        message.Rows.Add(currentRow);
                    }
                    else
                    {
                        specified = true;
                    }
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1} {2}", rowNumber, column, ex.Message), ex);
            }
        }

        public static string FormatDecimalValueOnlyNegative(this IXLWorksheet sheet, int rowNumber, string column, string format, DataTable message, string sheetName, ref bool specified)
        {
            try
            {
                string result = string.Empty;

                if (string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, column).Value)))
                {
                    specified = true;
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
                else
                {
                    decimal value = Conversions.ToDecimal(sheet.Cell(rowNumber, column).Value);

                    if (value > 0m)
                    {
                        var currentRow = message.NewRow();
                        currentRow["tipo"] = "error";
                        currentRow["message"] = string.Format("En la hoja '{3}' la celda '{0}:{1}' el valor '{2}' debe ser negativo", rowNumber, column, value, sheetName);
                        message.Rows.Add(currentRow);
                    }
                    else
                    {
                        specified = true;
                    }
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1} {2}", rowNumber, column, ex.Message), ex);
            }
        }

        public static string FormatDecimalValueOnlyNegative(this IXLWorksheet sheet, int rowNumber, string column, string format, DataTable message, string sheetName)
        {
            try
            {
                string result = string.Empty;

                if (string.IsNullOrEmpty(Conversions.ToString(sheet.Cell(rowNumber, column).Value)))
                {
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
                else
                {
                    decimal value = Conversions.ToDecimal(sheet.Cell(rowNumber, column).Value);

                    if (value > 0m)
                    {
                        var currentRow = message.NewRow();
                        currentRow["tipo"] = "error";
                        currentRow["message"] = string.Format("En la hoja '{3}' la celda '{0}:{1}' el valor '{2}' debe ser negativo", rowNumber, column, value, sheetName);
                        message.Rows.Add(currentRow);
                    }
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:{1} {2}", rowNumber, column, ex.Message), ex);
            }
        }
    }
}