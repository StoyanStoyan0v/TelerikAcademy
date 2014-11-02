﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Countries.Data.Models
{
    public class Continent
    {
        private ICollection<Country> countries;

        public Continent()
        {
            this.countries = new HashSet<Country>();
        }

        public int ContinentId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Country> Countries
        {
            get
            {
                return this.countries;
            }
            set
            {
                this.countries = value;
            }
        }
    }
}