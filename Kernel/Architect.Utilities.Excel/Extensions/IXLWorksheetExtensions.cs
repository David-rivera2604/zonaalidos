using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Architect.Utilities.Excel.Exceptions;
using ClosedXML.Excel;
using System.Data;

namespace Architect.Utilities.Excel.Extensions
{
    public static class IXLWorksheetExtensions
    {
        public static string StringValue(this IXLWorksheet sheet, int rowNumber, string column)
        {
            string result = string.Empty;
            if (sheet.Cell(rowNumber, column).Value != null)
            {
                result = sheet.Cell(rowNumber, column).Value.ToString();
                result = result.Trim();
            }
            return result;
        }

        public static string StringValue(this IXLWorksheet sheet, int rowNumber, int columnNumber)
        {
            string result = string.Empty;
            if (sheet.Cell(rowNumber, columnNumber).Value != null)
            {
                result = sheet.Cell(rowNumber, columnNumber).Value.ToString();
                result = result.Trim();
            }
            return result;
        }

        public static string StringValue(this IXLWorksheet sheet, int rowNumber, int columnNumber, ref bool specified)
        {
            string result = sheet.Cell(rowNumber, columnNumber).Value.ToString();
            specified = false;
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Trim();
                specified = true;
            }
            return result;
        }


        public static int IntegerValue(this IXLWorksheet sheet, int rowNumber, string column)
        {
            try
            {
                string result = sheet.Cell(rowNumber, column).Value.ToString();
                if (!string.IsNullOrEmpty(result))
                    result = result.Trim();
                else
                    result = "0";
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new WorksheetCellException(rowNumber, column, ex);
            }
        }

        public static int IntegerValue(this IXLWorksheet sheet, int rowNumber, int columnNumber)
        {
            try
            {
                string result = sheet.Cell(rowNumber, columnNumber).Value.ToString();
                if (!string.IsNullOrEmpty(result))
                    result = result.Trim();
                else
                    result = "0";
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new WorksheetCellException(rowNumber, columnNumber.ToString(), ex);
            }
        }

        public static int IntegerValue(this IXLWorksheet sheet, int rowNumber, int columnNumber, ref bool specified)
        {
            try
            {
                string result = sheet.Cell(rowNumber, columnNumber).Value.ToString();
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
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw new WorksheetCellException(rowNumber, columnNumber.ToString(), ex);
            }
        }

        public static decimal DecimalValue(this IXLWorksheet sheet, int rowNumber, string column)
        {
            try
            {
                if (sheet.Cell(rowNumber, column).Value == null)
                    return 0;
                else
                {
                    decimal value = Convert.ToDecimal(sheet.Cell(rowNumber, column).Value);
                    return value;
                }
            }
            catch (Exception ex)
            {
                throw new WorksheetCellException(rowNumber, column, ex);
            }
        }

        public static decimal DecimalValue(this IXLWorksheet sheet, int rowNumber, string column, string format)
        {
            try
            {
                if (sheet.Cell(rowNumber, column).Value == null)
                    return 0;
                else
                {
                    decimal value = Convert.ToDecimal(sheet.Cell(rowNumber, column).Value);
                    return value;
                }
            }
            catch (Exception ex)
            {
                throw new WorksheetCellException(rowNumber, column, ex);
            }
        }

        public static decimal DecimalValue(this IXLWorksheet sheet, int rowNumber, int columnNumber, string format)
        {
            if (sheet.Cell(rowNumber, columnNumber).Value == null)
                return 0;
            else
            {
                decimal value = Convert.ToDecimal(sheet.Cell(rowNumber, columnNumber).Value);
                return value;
            }
        }

        public static DateTime DateTimeValue(this IXLWorksheet sheet, int rowNumber, string column)
        {
            DateTime result = DateTime.MinValue;
            DateTime @internal;

            if (sheet.Cell(rowNumber, column).Value != null)
            {
                try
                {
                    if (sheet.Cell(rowNumber, column).Value.GetType().Name != "Date")
                    {
                        // DEBERÍA: La cultura por default debería de ser un settings.
                        if (!DateTime.TryParse(sheet.Cell(rowNumber, column).Value.ToString(), new System.Globalization.CultureInfo("es-CR", false), System.Globalization.DateTimeStyles.None, out @internal))
                            @internal = Convert.ToDateTime(sheet.Cell(rowNumber, column).Value);
                    }
                    else
                        @internal = Convert.ToDateTime(sheet.Cell(rowNumber, column).Value);

                    result = @internal;
                }
                catch (Exception ex)
                {
                    throw new WorksheetCellException(rowNumber, column, ex);
                }
            }

            return result;
        }
        public static DateTime DateTimeValue(this IXLWorksheet sheet, int rowNumber, int columnNumber)
        {
            DateTime result = DateTime.MinValue;
            DateTime @internal;

            if (sheet.Cell(rowNumber, columnNumber).Value != null)
            {
                try
                {
                    if (sheet.Cell(rowNumber, columnNumber).Value.GetType().Name != "Date")
                    {
                        // DEBERÍA: La cultura por default debería de ser un settings.
                        if (!DateTime.TryParse(sheet.Cell(rowNumber, columnNumber).Value.ToString(), new System.Globalization.CultureInfo("es-CR", false), System.Globalization.DateTimeStyles.None, out @internal))
                            @internal = Convert.ToDateTime(sheet.Cell(rowNumber, columnNumber).Value);
                    }
                    else
                        @internal = Convert.ToDateTime(sheet.Cell(rowNumber, columnNumber).Value);

                    result = @internal;
                }
                catch (Exception ex)
                {
                    throw new WorksheetCellException(rowNumber, columnNumber.ToString(), ex);
                }
            }

            return result;
        }

        public static string FormatDecimalValue(this IXLWorksheet sheet, int rowNumber, string column, string format)
        {
            try
            {
                string result = string.Empty;

                if (sheet.Cell(rowNumber, column).Value == null)
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                else
                {
                    decimal value = Convert.ToDecimal(sheet.Cell(rowNumber, column).Value);
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new WorksheetCellException(rowNumber, column, ex);
            }
        }

        public static string FormatDecimalValue(this IXLWorksheet sheet, int rowNumber, string column, string format, DataTable message, string sheetName)
        {
            try
            {
                string result = string.Empty;

                if (sheet.Cell(rowNumber, column).Value == null)
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                else
                {
                    decimal value = Convert.ToDecimal(sheet.Cell(rowNumber, column).Value);
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new WorksheetCellException(rowNumber, column, ex);
            }
        }

        public static string FormatDecimalValue(this IXLWorksheet sheet, int rowNumber, int columnNumber, string format)
        {
            string result = string.Empty;

            try
            {
                if (sheet.Cell(rowNumber, columnNumber).Value == null)
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                else
                {
                    decimal value = Convert.ToDecimal(sheet.Cell(rowNumber, columnNumber).Value);
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new WorksheetCellException(rowNumber, columnNumber.ToString(), ex);
            }
        }

        public static string FormatDecimalValue(this IXLWorksheet sheet, int rowNumber, int columnNumber, string format, ref bool specified)
        {
            string result = string.Empty;

            if (sheet.Cell(rowNumber, columnNumber).Value == null)
            {
                specified = false;
                return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
            }
            else
            {
                decimal value = Convert.ToDecimal(sheet.Cell(rowNumber, columnNumber).Value);
                specified = true;
                return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
            }
        }

        public static string FormatDateTimeValue(this IXLWorksheet sheet, int rowNumber, int columnNumber, string format)
        {
            string result = string.Empty;
            DateTime @internal;

            if (sheet.Cell(rowNumber, columnNumber).Value != null)
            {
                try
                {
                    if (sheet.Cell(rowNumber, columnNumber).Value.GetType().Name != "Date")
                    {
                        // DEBERIA: La cultura por default deberia de ser un settings.
                        if (!DateTime.TryParse(sheet.Cell(rowNumber, columnNumber).Value.ToString(), new System.Globalization.CultureInfo("es-CR", false), System.Globalization.DateTimeStyles.None, out @internal))
                            @internal = Convert.ToDateTime(sheet.Cell(rowNumber, columnNumber).Value);
                    }
                    else
                        @internal = Convert.ToDateTime(sheet.Cell(rowNumber, columnNumber).Value);

                    result = @internal.ToString(format);
                }
                catch (Exception ex)
                {
                    throw new WorksheetCellException(rowNumber, columnNumber.ToString(), ex);
                }
            }

            return result;
        }

        public static T EnumValue<T>(this IXLWorksheet sheet, int rowNumber, int columnNumber)
        {
            try
            {
                Type valueType = typeof(T);
                return (T)Enum.Parse(valueType, sheet.Cell(rowNumber, columnNumber).Value.ToString());
            }
            catch (ArgumentException ex)
            {
                return default(T);
            }
        }

        public static T EnumValue<T>(this IXLWorksheet sheet, int rowNumber, string column, ref bool withError)
        {
            try
            {
                Type valueType = typeof(T);
                withError = false;
                return (T)Enum.Parse(valueType, sheet.Cell(rowNumber, column).Value.ToString());
            }
            catch (ArgumentException ex)
            {
                withError = true;
                return default(T);
            }
        }

        public static T EnumValue<T>(this IXLWorksheet sheet, int rowNumber, int columnNumber, ref bool withError)
        {
            try
            {
                Type valueType = typeof(T);
                withError = false;
                return (T)Enum.Parse(valueType, sheet.Cell(rowNumber, columnNumber).Value.ToString());
            }
            catch (ArgumentException ex)
            {
                withError = true;
                return default(T);
            }
        }

        public static T EnumValue<T>(this IXLWorksheet sheet, int rowNumber, int columnNumber, ref bool specified, ref bool withError)
        {
            try
            {
                Type valueType = typeof(T);
                T value = default(T);
                if (sheet.Cell(rowNumber, columnNumber).Value != null)
                {
                    string x = sheet.Cell(rowNumber, columnNumber).Value.ToString();
                    value = (T)Enum.Parse(valueType, x);
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
                return default(T);
            }
        }

        public static string FormatDecimalValue(this IXLWorksheet sheet, int rowNumber, string column, string format, DataTable message, string sheetName, ref bool specified)
        {
            try
            {
                string result = string.Empty;

                if (sheet.Cell(rowNumber, column).Value == null)
                {
                    specified = true;
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
                else
                {
                    decimal value = Convert.ToDecimal(sheet.Cell(rowNumber, column).Value);
                    specified = true;
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new WorksheetCellException(rowNumber, column, ex);
            }
        }

        public static string FormatDecimalValueOnlyPositive(this IXLWorksheet sheet, int rowNumber, string column, string format, DataTable message, string sheetName)
        {
            bool specified = false;
            return FormatDecimalValueOnlyPositive(sheet, rowNumber, column, format, message, sheetName, ref specified);
        }

        public static string FormatDecimalValueOnlyPositive(this IXLWorksheet sheet, int rowNumber, string column, string format, DataTable message, string sheetName, ref bool specified)
        {
            try
            {
                string result = string.Empty;

                if (sheet.Cell(rowNumber, column).Value == null)
                {
                    specified = true;
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
                else
                {
                    decimal value = Convert.ToDecimal(sheet.Cell(rowNumber, column).Value);

                    if (value < 0)
                    {
                        DataRow currentRow = message.NewRow();
                        currentRow["tipo"] = "error";
                        currentRow["message"] = string.Format("En la hoja '{3}' la celda '{0}:{1}' el valor '{2}' debe ser positivo", rowNumber, column, value, sheetName);
                        message.Rows.Add(currentRow);
                    }
                    else
                        specified = true;
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new WorksheetCellException(rowNumber, column, ex);
            }
        }

        public static string FormatDecimalValueOnlyNegative(this IXLWorksheet sheet, int rowNumber, string column, string format, DataTable message, string sheetName, ref bool specified)
        {
            try
            {
                string result = string.Empty;

                if (sheet.Cell(rowNumber, column).Value == null)
                {
                    specified = true;
                    return 0.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
                else
                {
                    decimal value = Convert.ToDecimal(sheet.Cell(rowNumber, column).Value);

                    if (value > 0)
                    {
                        DataRow currentRow = message.NewRow();
                        currentRow["tipo"] = "error";
                        currentRow["message"] = string.Format("En la hoja '{3}' la celda '{0}:{1}' el valor '{2}' debe ser negativo", rowNumber, column, value, sheetName);
                        message.Rows.Add(currentRow);
                    }
                    else
                        specified = true;
                    return value.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
            }
            catch (Exception ex)
            {
                throw new WorksheetCellException(rowNumber, column, ex);
            }
        }
    }
}
