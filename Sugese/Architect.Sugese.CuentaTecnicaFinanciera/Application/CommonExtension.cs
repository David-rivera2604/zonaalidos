using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Sugese.CuentaTecnicaFinanciera.Application
{
    public static class CommonExtension
    {

        public static T EnumValue<T>(this IXLWorksheet sheet, int rowNumber, string column, DataTable response)
        {
            try
            {
                Type valueType = typeof(T);
                T value = (T)Enum.Parse(valueType, Convert.ToString(sheet.Cell(rowNumber, column).Value));

                return value;
            }
            catch (ArgumentException ex)
            {
                DataRow errorRow = response.NewRow();
                errorRow["tipo"] = "error";
                errorRow["message"] = String.Format("La celda '{0}:{1}' presenta un error '{2}'", rowNumber, column, ex.Message);
                response.Rows.Add(errorRow);
                return default(T);
            }
        }

        public static decimal DecimalValue(this IXLWorksheet sheet, int rowNumber, string column, DataTable response)
        {
            try
            {
                if (!string.IsNullOrEmpty(sheet.Cell(rowNumber, column).Value.ToString()))
                {
                    return (decimal)Math.Round(Convert.ToDecimal(sheet.Cell(rowNumber, column).Value), 2);
                }
            }
            catch (Exception ex)
            {
                DataRow errorRow = response.NewRow();

                errorRow["tipo"] = "error";
                errorRow["message"] = String.Format("La celda '{0}:{1}' presenta un error '{2}'", rowNumber, column, ex.Message);
                response.Rows.Add(errorRow);
            }
            return 0;
        }

    }
}
