using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class EditProfile : System.Web.UI.Page
    {
        CleanServiceClient client = new CleanServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)//not logged in no acces
            {
                Response.Redirect("Home.aspx");//end goal redirect home

            }
            

            if (!IsPostBack)
            {
                if (Session["uid"] != null)
                {
                    User u = client.GetUser((int)Session["uid"]);
                    if(u!=null)
                    {

                        fnamereg.Value = u.User_Name;
                        lnamereg.Value = u.User_Surname;
                        emailreg.Value = u.User_Email;
                        cellreg.Value = u.User_CellNum;
                        passreg.Value = u.User_Password;
                    }
                   

                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            User u = client.GetUser((int)Session["uid"]);
            client.EditUser(u.User_ID, emailreg.Value, fnamereg.Value, lnamereg.Value, cellreg.Value);
            Response.Redirect("EditProfile.aspx");

        }
    }
}