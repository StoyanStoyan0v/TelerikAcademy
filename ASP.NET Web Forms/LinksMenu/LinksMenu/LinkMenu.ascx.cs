using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinksMenu
{
    public partial class LinkMenu : System.Web.UI.UserControl
    {
        public object DataSource
        {
            get
            {
                return this.ListMenuDataList.DataSource;
            }
            set
            {
                this.ListMenuDataList.DataSource = value;
            }
        }

        public string FontName { get; set; }

        public Color FontColour { get; set; }

        protected void Page_Load(object sender,
            EventArgs e)
        {
        }

        protected void DataBind()
        {
            base.DataBind();
        }
    }
}