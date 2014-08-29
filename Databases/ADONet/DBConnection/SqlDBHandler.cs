namespace DatabaseHandlers
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Collections.Generic;

    public class SqlDBHandler : DBHandler
    {
        public SqlDBHandler(string dataBase)
        {
            string connectionString = string.Format("Server=.\\SQLEXPRESS; Database={0}; Integrated Security=true", dataBase);
            this.Connecton = new SqlConnection(connectionString);
        }
        
        public override object AggregateTable(string operation)
        {
            this.Command = new SqlCommand(operation, this.Connecton as SqlConnection);
            return base.AggregateTable(operation);
        }

        public override IDictionary<object, object> SelectFromTable(string[] keys, string tableName)
        {
            this.Command = new SqlCommand(string.Format("SELECT {0} FROM {1}",
                string.Join(", ", keys), tableName), this.Connecton as SqlConnection);

            return base.SelectFromTable(keys, tableName);
        }

        public override void InsertIntoDatabase(KeyValuePair<string, object>[]keys, string table)
        {
            var values = keys.Select(key => "@" + key.Key);
            this.Command = new SqlCommand(string.Format("INSERT INTO {0}({1}) VALUES ({2})",
                table, string.Join(", ", keys.Select(x => x.Key)), string.Join(", ", values)), this.Connecton as SqlConnection);
            base.InsertIntoDatabase(keys, table);
        }
    }
}