using System.Data;
using System.Text;

namespace Architect.Utilities.Extensions
{
    /// <summary>
    /// Extesión para tipos 'DataTable'.
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// Convierte el contenido de un 'datatable' en un table de HTML.
        /// </summary>
        /// <param name="data">'datatable' con información.</param>
        /// <returns>Tabla HTML.</returns>
        public static string HtmlTable(this DataTable data)
        {
            StringBuilder mHtml = new StringBuilder();
            int columnCount = data.Columns.Count;
            mHtml.Append("<div class='table-responsive'>");
            mHtml.Append("<table class='table table-hover'>");
            mHtml.Append("<thead>").
                  Append("<tr>");
            int index;
            for (index = 0; index < columnCount; index++)
            {
                mHtml.Append("<th scope='col'>").
                      Append(data.Columns[index].ColumnName).
                      Append("</th>");
            }
            mHtml.Append("</tr>").
                  Append("</thead>");

            mHtml.Append("<tbody>");
            foreach (DataRow row in data.Rows)
            {
                mHtml.Append("<tr>");
                for (index = 0; index < columnCount; index++)
                {
                    mHtml.Append("<td scope='col'>").
                          Append(row[index]).
                          Append("</td>");
                }
                mHtml.Append("</tr>");
            }
            mHtml.Append("</tbody>");
            mHtml.Append("</table>");
            mHtml.Append("</div>");

            return mHtml.ToString();
        }
    }
}
