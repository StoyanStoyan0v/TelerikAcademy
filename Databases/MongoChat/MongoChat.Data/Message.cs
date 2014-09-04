namespace MongoChat.Data
{
    using MongoDB.Bson;
    using System;
    
    public class Message : IEquatable<Message>
    {
        public ObjectId Id { get; set; }

        public string MessageText { get; set; }

        public DateTime Date { get; set; }

        public User User { get; set; }

        public bool Equals(Message other)
        {
            return this.MessageText == other.MessageText &&
                   this.Date == other.Date &&
                   this.User.Name == other.User.Name;
        }
    }
}