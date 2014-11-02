using ArticlesSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using ArticlesSystem.Models;

namespace ArticlesSystem.Authorized
{
    public partial class Articles : System.Web.UI.Page
    {
        private IArticlesData data;

        public Articles()
        {
            this.data = new ArticlesData();
        }

        public void Delete(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);  
            GridViewRow selectedRow = this.CategoriesGridView.Rows[index];
            var a = ((Label)selectedRow.FindControl("Title")).Text;
            var article = this.data.Articles.All().FirstOrDefault(c => c.Title == a);
            this.data.Articles.Delete(article);
            this.data.SaveChanges();
            Bind();
        }

        public void Edit(object sender, GridViewEditEventArgs e)
        {
           
        }

        public void Sort(object sender, GridViewSortEventArgs e)
        {
        }
        
        public void PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            this.CategoriesGridView.PageIndex = e.NewPageIndex;
            Bind();
        }

        public void CreateArticleClick(object sender, EventArgs e)
        {
            var currentUserId = Thread.CurrentPrincipal.Identity.GetUserId();
            if (currentUserId == null)
            {
                Response.Redirect("~/");
            }

            var like = new Like()
            {
                Value = 0
            };
            this.data.Likes.Add(like);
            this.data.SaveChanges();
            
            var article = new Article()
            {
                AuthorId = currentUserId,
                CategoryId = int.Parse(this.DropDownListxCategories.SelectedValue),
                DateCreated = DateTime.Now,
                Title = HttpUtility.HtmlEncode(this.ArticleTitle.Text),
                Content = HttpUtility.HtmlEncode(this.Content.Text),
                LikeId = this.data.Likes.All().First(x => x.Id == 2).Id
            };
            this.data.Articles.Add(article);
            this.data.SaveChanges();
            Bind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ViewState["sort"] = " ";
                this.DropDownListxCategories.DataSource = this.data.Categories.All().ToList();
                this.DropDownListxCategories.DataBind();
            }

            Bind();
        }

        private void Bind()
        {
            this.CategoriesGridView.DataSource = this.data.Articles.All().ToList();
            this.CategoriesGridView.DataBind();
        }

        private void ChangeDirection()
        {
            if ("ASC" == this.ViewState["sortDirection"].ToString())
            {
                this.ViewState["sortDirection"] = "DESC";
            }
            else
            {
                this.ViewState["sortDirection"] = "ASC";
            }
        }
        
        public void SortByLikes(object sender, EventArgs e)
        {
            this.CategoriesGridView.DataSource = this.data.Articles.All().OrderBy(x => x.Like.Value).ToList();
            this.CategoriesGridView.DataBind();
        }

        public void SortByCategory(object sender, EventArgs e)
        {
            this.CategoriesGridView.DataSource = this.data.Articles.All().OrderBy(x => x.Category.Name).ToList();
            this.CategoriesGridView.DataBind();
        }

        public void SortByDate(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CategoriesGridView.DataSource = this.data.Articles.All().OrderBy(x => x.DateCreated).ToList();
                this.CategoriesGridView.DataBind();
            }
        }

        public void SortByTitle(object sender, EventArgs e)
        {
            this.CategoriesGridView.DataSource = this.data.Articles.All().OrderBy(x => x.DateCreated).ToList();
            this.CategoriesGridView.DataBind();
        }
    }
}