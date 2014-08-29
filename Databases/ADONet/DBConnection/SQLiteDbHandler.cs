using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;

namespace DatabaseHandlers
{
    //Download the SQLLite (Nugget for example)... too big RAR file for uploading...
    public class SQLiteDbHandler : DBHandler
    {
        public SQLiteDbHandler(string databaseFile)
        {
            string connectionString =
                string.Format("Data Source={0};Version=3;New=True;Compress=True;", databaseFile);
            this.Connecton = new SQLiteConnection(connectionString);
        }
        
        public override object AggregateTable(string operation)
        {
            this.Command = new SQLiteCommand(operation, this.Connecton as SQLiteConnection);
            return base.AggregateTable(operation);
        }
        
        public override IDictionary<object, object> SelectFromTable(string[] keys, string tableName)
        {
            this.Command = new SQLiteCommand(string.Format("SELECT {0} FROM {1}",
                string.Join(", ", keys), tableName), this.Connecton as SQLiteConnection);

            return base.SelectFromTable(keys, tableName);
        }

        public override void InsertIntoDatabase(KeyValuePair<string, object>[]keys, string table)
        {
            var values = keys.Select(key => "@" + key.Key);
            this.Command = new SQLiteCommand(string.Format("INSERT INTO {0}({1}) VALUES ({2})",
                table, string.Join(", ", keys.Select(x => x.Key)), string.Join(", ", values)),
                this.Connecton as SQLiteConnection);
            base.InsertIntoDatabase(keys, table);
        }
    }
}