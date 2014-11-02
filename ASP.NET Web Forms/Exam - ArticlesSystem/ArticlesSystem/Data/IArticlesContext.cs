using ArticlesSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesSystem.Data
{
    public interface IArticlesContext
    {
        IDbSet<Article> Articles { get; set; }

        IDbSet<Like> Likes { get; set; }

        IDbSet<Category> Categories { get; set; }
        
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}