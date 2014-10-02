using BullsAndCows.Data.Repositories;
using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Data
{
    public interface IBullsAndCowsData
    {
        IRepository<User> Users { get; }

        IRepository<Game> Games { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<Notification> Notifications { get; }
        
        int SaveChanges();
    }
}