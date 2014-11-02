using ArticlesSystem.Data;
using ArticlesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticlesSystem
{
    public partial class Categories : System.Web.UI.Page
    {
        private IArticlesData data;

        public Categories()
        {
            this.data = new ArticlesData();
        }

        public void Sort(object sender, GridViewSortEventArgs e)
        {
            if ("ASC" == this.ViewState["sortDirection"].ToString())
            {
                this.ViewState["sortDirection"] = "DESC";
            }
            else
            {
                this.ViewState["sortDirection"] = "ASC";
            }

            var categories = this.data.Categories.All();

            if (ViewState["sortDirection"] == "ASC")
            {
                categories = categories.OrderBy(c => c.Name);
            }
            else
            {
                categories = categories.OrderByDescending(c => c.Name);
            }

            this.CategoriesGridView.DataSource = categories.ToList();
            this.CategoriesGridView.DataBind();
        }

        public void AddCatBtn_Click(object sender, EventArgs e)
        {
            var category = new Category()
            {
                Name = HttpUtility.HtmlEncode(this.CatName.Text)
            };

            this.data.Categories.Add(category);
            this.data.SaveChanges();
            this.CatName.Text = "";
            Bind();
        }

        public void Delete(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);  
            GridViewRow selectedRow = this.CategoriesGridView.Rows[index];
            var a = selectedRow.Cells[0].Text;
            var category = this.data.Categories.All().FirstOrDefault(c => c.Name == a);
            this.data.Categories.Delete(category);
            this.data.SaveChanges();
            Bind();
        }

        public void Edit(object sender, GridViewEditEventArgs e)
        {
            int index = Convert.ToInt32(e.NewEditIndex);  
            GridViewRow selectedRow = this.CategoriesGridView.Rows[index];
            var a = selectedRow.Cells[0].Text;
            var category = this.data.Categories.All().FirstOrDefault(c => c.Name == a);
            category.Name = HttpUtility.HtmlEncode(this.EditName.Text);
            this.data.SaveChanges();
            Bind();
        }
        
        public void PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            this.CategoriesGridView.PageIndex = e.NewPageIndex;
            Bind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ViewState["sortDirection"] = " ";
            }
            Bind();
        }

        private void Bind()
        {
            this.CategoriesGridView.DataSource = this.data.Categories.All().ToList();
            this.CategoriesGridView.DataBind();
        }
    }
}