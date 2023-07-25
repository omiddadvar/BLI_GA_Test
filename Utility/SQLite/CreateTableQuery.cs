using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.SQLite
{
    public class CreateTableQuery
    {
        private DataTable _DT;
        public CreateTableQuery SetDataTable(ref DataTable dataTable)
        {
            this._DT = dataTable;
            return this;
        }
        public string GetQuery()
        {
            string query = string.Format("CREATE TABLE {0} ({1});",
                _DT.TableName, _createTableStructureQuery());

            return query;
        }
        private string _createTableStructureQuery()
        {
            string result = "RunQueryAreaId INTEGER,";
            foreach (DataColumn column in _DT.Columns)
            {
                result += string.Format("{0} {1},", column.ColumnName, _getDataType(column.DataType));
            }
            return result.Substring(0, result.Length - 1);
        }
        private string _getDataType(Type type)
        {
            switch (type.Name)
            {
                case "Boolean":
                case "String":
                case "DateTime":
                    return "TEXT";
                case "Int32":
                case "Int64":
                    return "INTEGER";
                case "Double":
                case "Single":
                    return "REAL";
                default:
                    return null;
            }
        }
    }
}
