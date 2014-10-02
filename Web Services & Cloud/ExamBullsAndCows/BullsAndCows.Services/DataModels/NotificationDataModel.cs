using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.Services.DataModels
{
    public class NotificationDataModel
    {
        public static Expression<Func<Notification, NotificationDataModel>> FromNotification
        {
            get
            {
                return n => new NotificationDataModel()
                {
                    Id = n.Id,
                    Message = n.Message,
                    DateCreated = n.DateCreated,
                    Type = n.Type.ToString(),
                    State = n.State.ToString(),
                    GameId = n.GameId
                };
            }
        }
        
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public string Type { get; set; }

        public string State { get; set; }

        public int GameId { get; set; }
    }
}