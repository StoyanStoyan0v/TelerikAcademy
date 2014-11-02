using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Countries.Data.Models
{
    public class Town
    {
        public int TownId { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}