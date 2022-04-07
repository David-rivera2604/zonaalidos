using System;
using System.Runtime.Serialization;

namespace Architect.Utilities.Excel.Exceptions
{
    [Serializable()]
    public class WorksheetCellException : Exception, ISerializable
    {
        private int _rowNumber;
        private string _column;
        private string _verbose;

        public WorksheetCellException() : base()
        {
        }

        public WorksheetCellException(int rowNumber, string column, Exception inner) : base(string.Format("Failed to process row {0} column {1}", rowNumber, column), inner)
        {
            _rowNumber = rowNumber;
            _column = column;
        }

        public WorksheetCellException(int rowNumber, string column, string verbose, Exception inner) : base(string.Format("Failed to process row {0} column '{2}' ({1})", rowNumber, column, verbose), inner)
        {
            _rowNumber = rowNumber;
            _column = column;
            _verbose = verbose;
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
        public string Verbose
        {
            get
            {
                return _verbose;
            }
        }
    }
}
