using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.Services.DataModels
{
    public class UserRankDataModel
    {
        public static Expression<Func<User, UserRankDataModel>> FromUser
        {
            get
            {
                return u => new UserRankDataModel()
                {
                    Username = u.UserName,
                    Rank = u.Rank
                };
            }
        }

        public string Username { get; set; }

        public int Rank { get; set; }
    }
}