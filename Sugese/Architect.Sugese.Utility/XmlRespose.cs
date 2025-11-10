using Architect.Utilities.Extensions;
using ClosedXML.Excel;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Architect.Sugese.Utility.Helpers
{
    public class XmlRespose
    {
        public static bool HasErrors(DataTable response)
        {
            bool result = false;

            if (response.IsNotEmpty())
            {
                if (response.Rows.Count == 1)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(response.Rows[0]["message"], "El archivo fue recibido exitosamente.", false)))
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        public static DataTable ConvertDataTable(string xmlString)
        {
            var @out = new DataTable();

            if (xmlString.IsNotEmpty())
            {
                @out = ToTable(xmlString);
            }
            return @out;
        }

        public static bool IsValid(string xmlString)
        {
            bool result = true;

            if (xmlString.IsNotEmpty())
            {
                var @out = ToTable(xmlString);
                if (@out.IsNotEmpty() & @out.Rows.IsNotEmpty() && @out.Rows.Count > 0)
                {
                    result = false;
                }
            }
            return result;
        }

        public static void AddError(DataTable result, string tipo, string message)
        {
            var currentRow = result.NewRow();
            currentRow["tipo"] = tipo;
            currentRow["message"] = message;
            result.Rows.Add(currentRow);
        }

        public static DataTable TableWithMessage(string tipo, string message)
        {
            var result = ReponseDataTable();
            AddError(result, tipo, message);
            return result;
        }

        public static DataTable ToTable(string xmlString)
        {
            var result = ReponseDataTable();

            if (xmlString.IsNotEmpty())
            {
                var doc = XDocument.Parse(xmlString);
                long rowNumber = 1L;
                DataRow currentRow;
                string lineContent;

                foreach (XElement mensajeItem in doc.Elements("CargarArchivo").Elements("ListaMensajes").Elements("Mensaje"))
                {
                    lineContent = mensajeItem.Value.Trim();
                    currentRow = result.NewRow();
                    currentRow["id"] = rowNumber;

                    // Línea:1, posición:58015, error:The 'CodISIN' element is invalid - The value 'SN-260' is invalid according to its datatype 'CodIsin' - The Pattern constraint failed.
                    if (lineContent.Split(',').Count() > 1 && lineContent.Split(',')[0].Contains("Línea:"))
                    {
                        currentRow["linea"] = lineContent.Split(',')[0].Replace("Línea:", string.Empty).Trim();
                        lineContent = lineContent.Replace(lineContent.Split(',')[0] + ",", string.Empty).Trim();
                    }
                    if (lineContent.Split(',').Count() > 1 && lineContent.Split(',')[0].Contains("posición:"))
                    {
                        currentRow["posicion"] = lineContent.Split(',')[0].Replace("posición:", string.Empty).Trim();
                        lineContent = lineContent.Replace(lineContent.Split(',')[0] + ",", string.Empty).Trim();
                    }
                    if (lineContent.StartsWith("error:"))
                    {
                        currentRow["tipo"] = "error";
                        lineContent = lineContent.Substring(6);
                    }

                    if (lineContent.StartsWith("En el detalle de inversión con CodISIN ["))
                    {
                        lineContent = lineContent.Replace("En el detalle de inversión con CodISIN ", string.Empty);
                        currentRow["CodISIN"] = lineContent.Substring(0, lineContent.IndexOf(" ")).Trim();
                        currentRow["CodISIN"] = currentRow["CodISIN"].ToString().Replace("[", string.Empty);
                        currentRow["CodISIN"] = currentRow["CodISIN"].ToString().Replace("]", string.Empty);
                        lineContent = lineContent.Substring(lineContent.IndexOf(" ")).Trim();
                    }

                    currentRow["message"] = lineContent.Substring(0, 1).ToUpper() + lineContent.Substring(1);
                    result.Rows.Add(currentRow);
                    rowNumber += 1L;
                }
                if (result.Rows.Count == 0)
                {
                    currentRow = result.NewRow();
                    currentRow["id"] = rowNumber;
                    currentRow["message"] = doc.Element("CargarArchivo")?.Element("Descripcion")?.Value;
                    result.Rows.Add(currentRow);
                }
            }
            return result;
        }

        public static DataTable ReponseDataTable()
        {
            var result = new DataTable("Resultado");
            result.Columns.Add(new DataColumn("id") { DataType = Type.GetType("System.Int32") });
            result.Columns.Add(new DataColumn("linea") { DataType = Type.GetType("System.String") });
            result.Columns.Add(new DataColumn("posicion") { DataType = Type.GetType("System.String") });
            result.Columns.Add(new DataColumn("tipo") { DataType = Type.GetType("System.String") });
            result.Columns.Add(new DataColumn("CodISIN") { DataType = Type.GetType("System.String") });
            result.Columns.Add(new DataColumn("message") { DataType = Type.GetType("System.String") });

            return result;
        }

        public static void ExcelUpdateResult(string excelFilename, DataTable data)
        {
            var workbook = new XLWorkbook(excelFilename);
            IXLWorksheet sheet = null;
            try
            {
                sheet = workbook.Worksheet("Resultado");
            }
            catch (Exception ex)
            {
                sheet = null;
            }

            if (sheet.IsNotEmpty())
            {
                workbook.Worksheet("Resultado").Delete();
            }
            if (data.Rows.Count > 0)
            {
                workbook.Worksheets.Add(data);
            }
            workbook.Save();
        }
    }
}