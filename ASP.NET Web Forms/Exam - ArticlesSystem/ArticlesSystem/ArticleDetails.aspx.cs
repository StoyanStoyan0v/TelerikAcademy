using ArticlesSystem.Data;
using ArticlesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace ArticlesSystem
{
    public partial class ArticleDetails : System.Web.UI.Page
    {
        private IArticlesData data;

        public ArticleDetails()
        {
            this.data = new ArticlesData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Article FormViewArticleDetails_GetItem([QueryString("id")]
                                                      int? articleId)
        {
            if (articleId == null)
            {
                Response.Redirect("~/");
            }
            this.ViewState["id"] = articleId;
            var article = this.data.Articles.All().FirstOrDefault(b => b.Id == articleId);
            
            return article;
        }

        protected void Up_Click(object sender, EventArgs e)
        {
            var userId = Thread.CurrentPrincipal.Identity.GetUserId();
            if (userId == null)
            {
                Response.Redirect("~/Account/Login");
                return;
            }

            var id = int.Parse(this.ViewState["id"].ToString());
            var article = this.data.Articles.All().FirstOrDefault(b => b.Id == id);
            article.Like.Value++;
            this.data.SaveChanges();
            this.FormViewArticlekDetails.DataBind();
        }

        protected void Down_Click(object sender, EventArgs e)
        {
            var userId = Thread.CurrentPrincipal.Identity.GetUserId();
            if (userId == null)
            {
                Response.Redirect("~/Account/Login");
                return;
            }
            var id = int.Parse(this.ViewState["id"].ToString());
            var article = this.data.Articles.All().FirstOrDefault(b => b.Id == id);
            article.Like.Value--;
            this.data.SaveChanges();
            this.FormViewArticlekDetails.DataBind();
        }
    }
}