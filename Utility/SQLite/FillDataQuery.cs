using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.SQLite
{
    public class FillDataQuery
    {
        private DataTable _DT;
        public FillDataQuery SetDataTable(ref DataTable dataTable)
        {
            this._DT = dataTable;
            return this;
        }
        public string GetQuery()
        {
            string query = string.Format("INSERT INTO {0} {1} VALUES {2}",
                _DT.TableName,
                _GetDataColumnQuery(),
                _GetDataRowsQuery()
                );

            return query;
        }
        private string _GetDataColumnQuery()
        {
            string result = "(";
            for (int i = 0; i < _DT.Columns.Count; i++)
            {
                result += _DT.Columns[i].ColumnName + " ,";
            }
            result = result.Substring(0, result.Length - 1); // remove extra ","
            result += ")";
            return result;
        }
        private string _GetDataRowsQuery()
        {
            string result = "";
            string tempRowSQL = "";

                foreach (DataRow row in _DT.Rows)
                {
                    tempRowSQL = "(";
                    for (int i = 0; i < _DT.Columns.Count; i++)
                    {
                        tempRowSQL += _GetCellData(row, _DT.Columns[i], i) + " ,";
                    }
                    tempRowSQL = tempRowSQL.Substring(0, tempRowSQL.Length - 1); // remove extra ","
                    tempRowSQL += ")";
                    result += tempRowSQL + ",";
                }
            return result.Substring(0, result.Length - 1);
        }
        private string _GetCellData(DataRow row, DataColumn column, int index)
        {
            Type cellType = column.DataType;
            if (row[index].Equals(DBNull.Value) || row[index] == null)
                return "NULL";
            switch (cellType.Name)
            {
                case "Boolean":
                case "String":
                case "DateTime":
                    return string.Format("'{0}'", row[index].ToString());
                default:
                    return row[index].ToString();
            }
        }
    }
}
