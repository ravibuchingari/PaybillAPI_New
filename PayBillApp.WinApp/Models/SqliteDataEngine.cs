using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace PayBillApp.WinApp.Models
{
    public class SqliteDataEngine
    {
        public SqliteDataEngine()
        {
            string dbPath = Path.Combine(Application.StartupPath, ConstantVariables.SQLITE_DATABASE);
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                ConstantVariables.SQLITE_CONNECTION_STRING = $"Data Source={ConstantVariables.SQLITE_DATABASE};";
                CreateTables();
            }
            else
            {
                ConstantVariables.SQLITE_CONNECTION_STRING = $"Data Source={ConstantVariables.SQLITE_DATABASE};";
                TruncateItems();
            }
        }

        private static void CreateTables()
        {
            string sqlQuery = $@"create table {ConstantVariables.SQLITE_ITEMS_TABLE}(
                                ItemId integer primary key,
                                ItemCode text not null,
                                ItemName text not null,
                                ItemAaliasNname text null,
                                ItemMRP double,
                                ItemPrice double,
                                ItemDiscountPer float,
                                ItemGSTPer float,
                                LocalLanguage text
                            );";

            using SQLiteConnection connection = new(ConstantVariables.SQLITE_CONNECTION_STRING);
            using SQLiteCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sqlQuery;
            command.ExecuteNonQuery();
        }

        private static void TruncateItems()
        {
            using SQLiteConnection connection = new(ConstantVariables.SQLITE_CONNECTION_STRING);
            using SQLiteCommand command = connection.CreateCommand();
            command.Connection.Open();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = $"delete from {ConstantVariables.SQLITE_ITEMS_TABLE}";
            command.ExecuteNonQuery();
        }
    }
}
