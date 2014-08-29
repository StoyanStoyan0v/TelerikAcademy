using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseHandlers
{
    public abstract class DBHandler
    {
        protected IDbConnection Connecton { get; set; }
        
        protected IDbCommand Command { get; set; }

        protected IDataReader Reader { get; set; }

        public virtual object AggregateTable(string operation)
        {
            this.Connecton.Open();

            object categoriesCount = this.Command.ExecuteScalar();

            this.Connecton.Close();
            
            return categoriesCount;
        }

        public virtual IDictionary<object, object> SelectFromTable(string[] keys, string databaseName)
        {
            this.Connecton.Open();

            var result = new Dictionary<object, object>();
            this.Reader = this.Command.ExecuteReader();
           
            using (this.Reader)
            {
                while (this.Reader.Read())
                {
                    if (result.ContainsKey((dynamic)this.Reader[keys[0]]))
                    {
                         int index = keys.Length - 1;
                        result[(dynamic)this.Reader[keys[0]]] += ", " + this.Reader[keys[index]];
                    }
                    else
                    {
                        int index = keys.Length - 1;
                        result.Add((dynamic)this.Reader[keys[0]], this.Reader[keys[index]]);
                    }
                }
            }

            this.Connecton.Close();

            return result;
        }

        public virtual void InsertIntoDatabase(KeyValuePair<string, object>[] keys, string table)
        {
            this.Connecton.Open();
           
            foreach (var key in keys)
            {                
                var parameter = this.Command.CreateParameter();
                parameter.ParameterName = ("@" + key.Key);
                parameter.Value = key.Value;
                this.Command.Parameters.Add(parameter);
            }
            this.Command.Connection = this.Connecton;
            this.Command.ExecuteNonQuery();

            this.Connecton.Close();
        }
    }
}