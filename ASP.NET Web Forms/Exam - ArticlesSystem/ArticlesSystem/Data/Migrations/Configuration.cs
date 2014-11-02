using ArticlesSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ArticlesSystem.Data.Migrations
{
    public class Configuration : DbMigrationsConfiguration<ArticlesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ArticlesContext context)
        {
            var seeder = new SeedData();
            if (!context.Categories.Any())
            {
                foreach (var item in seeder.Categories)
                {
                    context.Categories.Add(item);
                }
                context.SaveChanges();
            }

            if (!context.Articles.Any())
            {
                foreach (var item in seeder.Articles)
                {
                    context.Articles.Add(item);
                }
                context.SaveChanges();
            }
        }
    }
}