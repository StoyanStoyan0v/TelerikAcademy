using ArticlesSystem.Data.Migrations;
using ArticlesSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArticlesSystem.Data
{
    public class ArticlesContext : IdentityDbContext<ApplicationUser>, IArticlesContext
    {
        public ArticlesContext() : base("ArticlesConnectionString", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArticlesContext, Configuration>());
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        public static ArticlesContext Create()
        {
            return new ArticlesContext();
        }
    }
}