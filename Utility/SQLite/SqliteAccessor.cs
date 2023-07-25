using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;
using Utility.SQLite;

namespace Utility.Sqlite
{
    public class SqliteAccessor: IDisposable
    {
        private const string _DBName = "MyDatabase.db";
        private DataTable _DataModels;
        private SQLiteConnection _dbConnection;
        public SqliteAccessor()
        {
            _CreateDatabase();
        }
        public void InsertData(DataTable dataModels , bool dropTable = false)
        {
            _DataModels = dataModels;

            if (dropTable)
            {
                _DropTable(dataModels.TableName);
                _CreateTable();
            }
            _FillData();
        }
        public void CreateTable(DataTable dataModels)
        {
            _DataModels = dataModels;
            _DropTable(dataModels.TableName);
            _CreateTable();
        }
        public static void DropSQLiteDB()
        {
            if (File.Exists(_DBName))
                File.Delete(_DBName);
        }
        private void _CreateDatabase()
        {
            if (!File.Exists(_DBName))
            {
                SQLiteConnection.CreateFile(_DBName);
            }
            string connectionString = string.Format("Data Source={0};Version=3;", _DBName);
            _dbConnection = new SQLiteConnection(connectionString);
            _dbConnection.Open();
        }
        private void _CreateTable()
        {
            string createTableSQL = new CreateTableQuery()
                        .SetDataTable(ref _DataModels)
                        .GetQuery();

            var cmd = new SQLiteCommand(_dbConnection);
            cmd.CommandText = createTableSQL;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        private void _FillData()
        {
            string fillDataSQL = new FillDataQuery()
                        .SetDataTable(ref _DataModels)
                        .GetQuery();

            var cmd = new SQLiteCommand(_dbConnection);
            cmd.CommandText = fillDataSQL;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        private void _DropTable(string tableName)
        {
            try
            {
                string lSQL = string.Format("DROP TABLE {0}", tableName);
                var cmd = new SQLiteCommand(_dbConnection);
                cmd.CommandText = lSQL;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch { }
        }
        public void Dispose()
        {
           _DataModels = null;
            if (_dbConnection != null)
                _dbConnection.Dispose();
            if(_dbConnection != null)
            {
                _dbConnection.Close();
                _dbConnection.Dispose();
            }
        }
    }
}
