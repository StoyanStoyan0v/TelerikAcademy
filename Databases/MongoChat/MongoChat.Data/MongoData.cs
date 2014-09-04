namespace MongoChat.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public class MongoData
    {
        private readonly MongoDatabase database;

        private readonly MongoCollection<Message> messages;

        public MongoData()
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            this.database = server.GetDatabase("ChatDb");
            this.messages = this.database.GetCollection<Message>("messages");
        }

        public void InsertMessage(string message, string username)
        {
            var msg = new Message()
            {
                MessageText = message,
                Date = DateTime.Now,
                User = new User()
                {
                    Name = username
                }
            };

            this.messages.Insert(msg);
        }

        public List<string> GetMessages()
        {
            var list = new List<string>();

            foreach (var msg in this.messages.AsQueryable<Message>().ToList())
            {
                var output = new StringBuilder();
                output.AppendLine(string.Format("[{0}] {1}: {2}", msg.Date.ToLocalTime(), msg.User.Name, msg.MessageText));
                list.Add(output.ToString());
            }
            return list;
        }
    }
}