using ArticlesSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticlesSystem
{
    public partial class _Default  : Page
    {
        private IArticlesData data;

        public _Default ()
        {
            this.data = new ArticlesData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {       
        }

        public ICollection<ArticlesSystem.Models.Article> ListViewArticles_GetData()
        {
            return this.data.Articles.All().OrderByDescending(a => a.Like.Value).Take(3).ToList();
        }
        public ICollection<ArticlesSystem.Models.Category> ListViewCategories_GetData()
        {
            return this.data.Categories.All().ToList();
        }

    }
}