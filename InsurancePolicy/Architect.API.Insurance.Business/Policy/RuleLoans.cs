using Architect.Utilities.Extensions;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Business.Policy
{
    /// <summary>
    /// Opción para la carga de información de la tabla "RuleLoans".
    /// </summary>
    public static class RuleLoans
    {
        /// <summary>
        /// Define una DataTable compatible con la tabla "RuleLoans".
        /// </summary>
        /// <returns>DataTable compatible con la tabla "RuleLoans".</returns>
        private static System.Data.DataTable DataTableSpecification()
        {
            System.Data.DataTable result = new System.Data.DataTable("RuleLoans");

            result.Columns.Add(new System.Data.DataColumn("LoanNumber", typeof(Decimal)));
            result.Columns.Add(new System.Data.DataColumn("CompanyId", typeof(Decimal)));
            result.Columns.Add(new System.Data.DataColumn("DocumentNumber", typeof(string)));
            result.Columns.Add(new System.Data.DataColumn("FullName", typeof(string)));
            result.Columns.Add(new System.Data.DataColumn("BirthDate", typeof(DateTime)));
            result.Columns.Add(new System.Data.DataColumn("Gender", typeof(Decimal)));
            result.Columns.Add(new System.Data.DataColumn("StartTerm", typeof(DateTime)));
            result.Columns.Add(new System.Data.DataColumn("EndTerm", typeof(DateTime)));
            result.Columns.Add(new System.Data.DataColumn("Duration", typeof(Decimal)));
            result.Columns.Add(new System.Data.DataColumn("Amount", typeof(Decimal)));
            result.Columns.Add(new System.Data.DataColumn("Balance", typeof(Decimal)));
            return result;
        }

        /// <summary>
        /// Convierte un a fila de un archivo excel a un DataRow del DataTable "RuleLoans".
        /// </summary>
        /// <param name="dataRow">DataRow vacio del DataTable</param>
        /// <param name="sheet">Hola del archivo excel.</param>
        /// <param name="rowNumber">Número de fila a procesar.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <returns>DataRow del DataTable "RuleLoans"</returns>
        private static System.Data.DataRow SheetRow2DataTableRow(System.Data.DataRow dataRow,
                                                                 IXLWorksheet sheet,
                                                                 int rowNumber,
                                                                 int companyId)
        {
            dataRow["LoanNumber"] = Architect.Common.Extensions.IXLWorksheetExtensions.IntegerValue(sheet, rowNumber, "G");
            dataRow["CompanyId"] = companyId;
            dataRow["DocumentNumber"] = Architect.Common.Extensions.IXLWorksheetExtensions.StringValue(sheet, rowNumber, "C");
            dataRow["FullName"] = Architect.Common.Extensions.IXLWorksheetExtensions.StringValue(sheet,rowNumber, "B");
            dataRow["BirthDate"] = Architect.Common.Extensions.IXLWorksheetExtensions.DateTimeValue(sheet, rowNumber, "E");
            if (Architect.Common.Extensions.IXLWorksheetExtensions.StringValue(sheet, rowNumber, "K") == "M")
                dataRow["Gender"] = 1;
            else
                dataRow["Gender"] = 2;
            dataRow["StartTerm"] = Common.Extensions.IXLWorksheetExtensions.DateTimeValue(sheet, rowNumber, "H");
            dataRow["EndTerm"] = Common.Extensions.IXLWorksheetExtensions.DateTimeValue(sheet, rowNumber, "I");
            dataRow["Duration"] = Common.Extensions.IXLWorksheetExtensions.DecimalValue(sheet, rowNumber, "O");
            dataRow["Amount"] = Common.Extensions.IXLWorksheetExtensions.DecimalValue(sheet, rowNumber, "L");
            dataRow["Balance"] = Common.Extensions.IXLWorksheetExtensions.DecimalValue(sheet, rowNumber, "N");

            return dataRow;
        }

        /// <summary>
        /// Permite la carga de información de la tabla "RuleLoans" por medio de un archivo excel.
        /// </summary>
        /// <param name="localFileName">Nombre del archivo excel en el servidor.</param>
        /// <param name="originalFileName">nombre original del archivo excel.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <returns>Cantidad de registros procesador</returns>
        public static string Load(string localFileName, string originalFileName, int companyId, int userId)
        {
            string result = "";
            int rowNumber =0;
            try
            {
                XLWorkbook workbook = new XLWorkbook(localFileName, XLEventTracking.Disabled);
                IXLWorksheet sheet = workbook.Worksheet(2);
                System.Data.DataTable data = DataTableSpecification();

                for (rowNumber = 9; rowNumber < 100000; rowNumber++)
                {
                    if (!string.IsNullOrEmpty(Common.Extensions.IXLWorksheetExtensions.StringValue(sheet, rowNumber, "A")))
                    {
                        data.Rows.Add(SheetRow2DataTableRow(data.NewRow(), sheet, rowNumber, companyId));
                    }
                    else
                    {
                        break;
                    }
                }
                if (data.Rows.Count > 0)
                {
                    DataAccess.Policy.RuleLoans.Truncate();
                    Architect.Common.Helpers.Bulk.test(data, "RULELOANS", "Research");

                    result = string.Format("El archivo '{0}' fue procesado de forma exitosa, se cargaron {1} registros", originalFileName, data.Rows.Count);

                    Core.Business.General.ChangeSet.Create(2005, userId, companyId, "Procesado", result, userId, new { FileName = originalFileName, Rows = data.Rows.Count } );
                }
            }
            catch (Architect.Common.Exceptions.WorksheetCellException wex)
            {
                Utilities.Log.ErrorLog("Load", string.Format("fileName={0}, companyId={1}, row={2}, column={3}", localFileName, companyId, rowNumber, wex.Column), wex);
                result = string.Format("Ha ocurrido un error procesando la fila {0} columna {1}, por favor verifique e intente nuevamente.", wex.RowNumber, wex.Column);
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Load", string.Format("fileName={0}, companyId={1}, rownumber={2}", localFileName, companyId, rowNumber), ex);
                throw;
            }
            return result;
        }

        /// <summary>
        /// Devuelva la lista de prestamos de una persona por medio de su identificación.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="documentNumber">Documento o número de identificación.</param>
        /// <returns>lista de prestamos.</returns>
        public static List<Contracts.Policy.RuleLoans> RetrieveByDocumentNumber(int companyId, string documentNumber)
        {
            List<Architect.API.Insurance.Contracts.Policy.RuleLoans> result = Architect.API.Insurance.DataAccess.Policy.RuleLoans
                .RetrieveByDocumentNumber(companyId, documentNumber);

            foreach (Architect.API.Insurance.Contracts.Policy.RuleLoans item in result)
            {
                if (item.Gender.IsNotEmpty())
                {
                    item.GenderDesc = Core.Business.Common
                        .Lkp("Gender", companyId)
                        .Find(x => x.Code == item.Gender.ToString())
                        .Description;
                }
            }
            return result;
        }
    }
}
