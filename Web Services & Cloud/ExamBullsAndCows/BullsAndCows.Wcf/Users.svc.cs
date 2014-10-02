using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using BullsAndCows.Data;
using BullsAndCows.Models;

namespace BullsAndCows.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Users" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Users.svc or Users.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]    
    public class Users : IUsers
    {
        private IBullsAndCowsData data;

        public Users()
        {
            this.data = new BullsAndCowsData();
        }

        public ICollection<User> All()
        {
            return this.AllPage(0);
        }

        public ICollection<User> AllPage(int page)
        {
            var games = this.data.Users.All()
                            .Skip(10 * page)
                            .Take(10)
                            .ToList();
            return games;
        }

        public User ById(string id)
        {
            throw new NotImplementedException();
        }
    }
}