using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class login : System.Web.UI.Page
    {
        CleanServiceClient client = new CleanServiceClient();


        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                int loginId = client.Login(email.Value, pass.Value);
                if (loginId != 0)
                {

                    User u = client.GetUser(loginId);
                    Session["uid"] = u.User_ID;
                    Session["utype"] = u.User_Type;
                    Response.Redirect("Home.aspx");

                }
                else
                {
                    /*
                    loginLbl.Visible = true;
                    loginLbl.Text = "Incorrect username or password"; */

                    logstatus.Attributes.Remove("hidden");


                }
            }
            else
            {
                Response.Redirect("Home.aspx");
            }




        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {

            bool dontexist = client.checkUserExist("9999999", emailreg.Value);
            if (dontexist)
            {
                bool added = client.AddUser(fnamereg.Value, lnamereg.Value, cellreg.Value, emailreg.Value, passreg.Value, "CUS", 0, 'Y');
             
            }
            else
            {
                regstatus.Attributes.Remove("hidden");
                regstatus.InnerText = "User already exists Please Sign in";

            }






        }
    }
}