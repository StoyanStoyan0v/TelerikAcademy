using BugLogger.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BugLogger.RestApi.Models
{
    public class BugModel
    {
        public static Expression<Func<Bug, BugModel>> FromBug
        {
            get
            {
                return a => new BugModel
                {
                    Id = a.Id,
                    Status = a.Status,
                    Text = a.Text,
                    LogDate = a.LogDate
                };
            }
        }

        public int Id { get; set; }

        public Status Status { get; set; }

        public string Text { get; set; }

        public DateTime? LogDate { get; set; }
    }
}