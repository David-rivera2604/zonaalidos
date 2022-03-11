using System;
using System.Runtime.Serialization;

namespace Architect.Utilities.Excel.Exceptions
{
    [Serializable()]
    public class WorksheetCellException : Exception, ISerializable
    {
        private int _rowNumber;
        private string _column;

        public WorksheetCellException() : base()
        {
        }

        public WorksheetCellException(int rowNumber, string column, Exception inner) : base(string.Format("Failed to process row {0} column {1}", rowNumber, column), inner)
        {
            _rowNumber = rowNumber;
            _column = column;
        }

        public int RowNumber
        {
            get
            {
                return _rowNumber;
            }
        }

        public string Column
        {
            get
            {
                return _column;
            }
        }
    }
}
