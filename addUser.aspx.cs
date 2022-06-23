using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class addUser : System.Web.UI.Page
    {
        CleanServiceClient client = new CleanServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)//they logged in
            {
                if (Session["utype"].ToString() != "MAN") //they not a manager they cant use it
                {
                    Response.Redirect("Home.aspx");
                }

            }
            else//not logged in 
            {
              Response.Redirect("Home.aspx");
            }

        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            bool dontexist = client.checkUserExist(cellreg.Value, emailreg.Value);
            if (dontexist)
            {
                
                bool added = client.AddUser(fnamereg.Value, lnamereg.Value, cellreg.Value, emailreg.Value, passreg.Value, usertype.Value, 0, 'Y');
                if (added)
                {   //add purchases

                    regstatus.Attributes.Remove("hidden");
                }
                
            }
            else
            {
                regstatus.Attributes.Remove("hidden");
                regstatus.InnerText = "User already exists";

            }
        }



    }
}