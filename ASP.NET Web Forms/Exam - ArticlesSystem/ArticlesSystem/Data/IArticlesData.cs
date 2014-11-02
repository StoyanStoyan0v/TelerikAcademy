using ArticlesSystem.Data.Repositories;
using ArticlesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesSystem.Data
{
    public interface IArticlesData
    {
        IRepository<Category> Categories { get; }
        
        IRepository<Article> Articles { get; }

        IRepository<Like> Likes { get; }

        void SaveChanges();
    }
}