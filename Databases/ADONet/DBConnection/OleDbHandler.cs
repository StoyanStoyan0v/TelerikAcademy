using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;

namespace DatabaseHandlers
{
    public class OleDbHandler : DBHandler
    {
        public OleDbHandler(string filePath)
        {
            string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 XML;HDR=Yes;\"", filePath);
            this.Connecton = new OleDbConnection(connectionString);
        }

        public override object AggregateTable(string operation)
        {
            this.Command = new OleDbCommand(operation, this.Connecton as OleDbConnection);
            return base.AggregateTable(operation);
        }

        public override IDictionary<object, object> SelectFromTable(string[] keys, string tableName)
        {
            this.Command = new OleDbCommand(string.Format("SELECT {0} FROM [{1}]",
                string.Join(", ", keys), tableName), this.Connecton as OleDbConnection);

            return base.SelectFromTable(keys, tableName);
        }

        public override void InsertIntoDatabase(KeyValuePair<string, object>[]keys, string table)
        {
            var values = keys.Select(key => "@" + key.Key);
            this.Command = new OleDbCommand(string.Format("INSERT INTO [{0}]({1}) VALUES ({2})",
                table, string.Join(", ", keys.Select(x => x.Key)), string.Join(", ", values)),
                this.Connecton as OleDbConnection);
            base.InsertIntoDatabase(keys, table);
        }
    }
}