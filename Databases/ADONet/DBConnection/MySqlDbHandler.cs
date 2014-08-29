namespace DatabaseHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MySql.Data.MySqlClient;

    public class MySqlDbHandler : DBHandler
    {
        public MySqlDbHandler(string password, string dataBaseName)
        {
            
            string connectionString =
                string.Format("Server=localhost;Database={0};Uid=root;Pwd={1}", dataBaseName, password);
            this.Connecton = new MySqlConnection(connectionString);
        }

        public override IDictionary<object, object> SelectFromTable(string[] keys, string tableName)
        {
            this.Command = new MySqlCommand(string.Format("SELECT {0} FROM {1}",
                string.Join(", ", keys), tableName), this.Connecton as MySqlConnection);

            return base.SelectFromTable(keys, tableName);
        }

        public override void InsertIntoDatabase(KeyValuePair<string, object>[]keys, string table)
        {
            var values = keys.Select(key => "@" + key.Key);
            this.Command = new MySqlCommand(string.Format("INSERT INTO {0}({1}) VALUES ({2})",
                table, string.Join(", ", keys.Select(x => x.Key)), string.Join(", ", values)),
                this.Connecton as MySqlConnection);
            base.InsertIntoDatabase(keys, table);
        }
    }
}