namespace DAOAndTest
{
    using System;
    using System.Data.Linq;
    
    public partial class Employee
    {
        public EntitySet<Territory> TeritoryEntries
        {
            get
            {
                var teritories = new EntitySet<Territory>();
                teritories.AddRange(this.Territories);
                return teritories;
            }
        }
    }
}