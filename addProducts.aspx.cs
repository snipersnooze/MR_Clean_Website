using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class addProducts : System.Web.UI.Page
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

            int added = client.AddProduct(pname.Value, int.Parse(pprice.Value), pdescr.Value, ppic.Value, char.Parse(ppromo.Value),char.Parse(pactive.Value), pcat.Value);
            if (added > 1)
            {   //add purchases

                client.AddInventory(added, int.Parse(ProdQTY.Value));
                AddStatus.Attributes.Remove("hidden");

            }

            else
            {
                AddStatus.Attributes.Remove("hidden");
                AddStatus.InnerText = "Product could not be added";

            }
        }



    }
}