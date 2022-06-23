using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {if (Session["uid"] != null)
            {
                Session["uid"] = null;
                Session["utype"] = null;
                Response.Redirect("Home.aspx");
            }
        }
    }
}