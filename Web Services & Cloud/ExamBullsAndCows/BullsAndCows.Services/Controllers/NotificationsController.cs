using BullsAndCows.Data;
using BullsAndCows.Models;
using BullsAndCows.Services.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BullsAndCows.Services.Controllers
{
    [Authorize]
    public class NotificationsController : BaseApiController
    {
        public NotificationsController(IBullsAndCowsData data) : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.All(0);
        }

        [HttpGet]
        public IHttpActionResult All(int page)
        {
            var notifications = this.Data.Notifications.All()
                                    .OrderBy(n => n.DateCreated)
                                    .Skip(10 * page)
                                    .Take(10);
            foreach (var notification in notifications)
            {
                notification.State = NotificationState.Read;
            }

            var listedNotifications = notifications.Select(NotificationDataModel.FromNotification)
                                                   .ToList();

            return Ok(listedNotifications);
        }

        [HttpGet]
        public IHttpActionResult Next()
        {
            var oldestUnread = this.Data.Notifications
                                   .All()
                                   .Where(n => n.State == NotificationState.Unread)
                                   .OrderByDescending(n => n.DateCreated)
                                   .Select(NotificationDataModel.FromNotification)
                                   .FirstOrDefault();
            
            var id = oldestUnread.Id;
            this.Data.Notifications.Find(id).State = NotificationState.Read;
            this.Data.SaveChanges();
            if (oldestUnread == null)
            {
                return NotFound();
            }

            return Ok(oldestUnread);
        }
    }
}