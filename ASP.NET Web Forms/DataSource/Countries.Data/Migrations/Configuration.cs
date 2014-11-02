using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Countries.Migrations
{
    using Countries.Data;
    using Countries.Data.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CountriesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CountriesContext context)
        {
            if (!context.Continets.Any())
            {
                context.Continets.Add(new Continent
                {
                    Name = "Asia"
                });
                context.Continets.Add(new Continent
                {
                    Name = "Europe"
                });
                context.Continets.Add(new Continent
                {
                    Name = "North America"
                });
                context.SaveChanges();
            }
            if (!context.Countries.Any())
            {
                context.Countries.Add(new Country
                {
                    Name = "China",
                    Population = 1500000000,
                    ContinentId = context.Continets.FirstOrDefault(c => c.Name == "Asia").ContinentId
                });
                context.Countries.Add(new Country
                {
                    Name = "Russia",
                    Population = 600000000,
                    ContinentId = context.Continets.FirstOrDefault(c => c.Name == "Asia").ContinentId
                });
                context.Countries.Add(new Country
                {
                    Name = "Germany",
                    Population = 20000000,
                    ContinentId = context.Continets.FirstOrDefault(c => c.Name == "Europe").ContinentId
                });
                context.Countries.Add(new Country
                {
                    Name = "Bulgaria",
                    Population = 7500000,
                    ContinentId = context.Continets.FirstOrDefault(c => c.Name == "Europe").ContinentId
                });
                context.Countries.Add(new Country
                {
                    Name = "Mexico",
                    Population = 20000000,
                    ContinentId = context.Continets.FirstOrDefault(c => c.Name == "North America").ContinentId
                });
                context.Countries.Add(new Country
                {
                    Name = "Canada",
                    Population = 7500000,
                    ContinentId = context.Continets.FirstOrDefault(c => c.Name == "North America").ContinentId
                });
            }

            if (!context.Towns.Any())
            {
                context.Towns.Add(new Town
                {
                    Name = "Beijing",
                    Population = 750000,
                    CountryId = context.Countries.FirstOrDefault(c => c.Name == "China").CountryId
                });

                context.Towns.Add(new Town
                {
                    Name = "Moscow",
                    Population = 750000,
                    CountryId = context.Countries.FirstOrDefault(c => c.Name == "Russia").CountryId
                });
                context.Towns.Add(new Town
                {
                    Name = "Berlin",
                    Population = 75000,
                    CountryId = context.Countries.FirstOrDefault(c => c.Name == "Germany").CountryId
                });
                context.Towns.Add(new Town
                {
                    Name = "Sofia",
                    Population = 75000,
                    CountryId = context.Countries.FirstOrDefault(c => c.Name == "Bulgaria").CountryId
                });
                context.Towns.Add(new Town
                {
                    Name = "Mexico",
                    Population = 75000,
                    CountryId = context.Countries.FirstOrDefault(c => c.Name == "Mexico").CountryId
                });
                context.Towns.Add(new Town
                {
                    Name = "Otawa",
                    Population = 75000,
                    CountryId = context.Countries.FirstOrDefault(c => c.Name == "Canada").CountryId
                });
            }
            context.SaveChanges();
        }
    }
}