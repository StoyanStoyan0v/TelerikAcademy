using System.Web.ModelBinding;
using Countries.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Countries.Data.Models;

namespace Countries
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private ICountriesData data;

        public WebForm1()
        {
            data = new CountriesData();
        }

        public void Command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int index = Convert.ToInt32(e.CommandArgument);  
                GridViewRow selectedRow = this.GridViewCountries.Rows[index];
                var a = selectedRow.Cells[1].Text;
                var towns = data.Towns.All().Where(c => c.Country.Name == a).ToList();
                this.TownsView.DataSource = towns;
                this.TownsView.DataBind();
            }
        }

        public void GridViewCountries_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewCountries.PageIndex = e.NewPageIndex;

            this.GridViewCountries.DataSource = data.Countries.All().Where(c => c.Continent.Name == ListBoxContinents.SelectedItem.Value.ToString()).ToList();
            this.DataBind();
        }
        
        public void ListBoxContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GridViewCountries.DataSource = data.Countries.All().Where(c => c.Continent.Name == ListBoxContinents.SelectedItem.Value.ToString()).ToList();
            this.GridViewCountries.DataBind();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListBoxContinents.DataSource = data.Continents.All().ToList();
                this.DataBind();
            }
        }
    }
}