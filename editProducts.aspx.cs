using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class editProducts : System.Web.UI.Page
    {
        CleanServiceClient client = new CleanServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["uid"] == null)//not logged in no acces
            {
                Response.Redirect("Home.aspx");//end goal redirect home

            }
            else if (Session["utype"].Equals("CUS"))
            {
                Response.Redirect("Home.aspx");//end goal redirect home

            }

            if (!IsPostBack)
            {
                int prodId = int.Parse(Request.QueryString["pid"].ToString());

                var p = client.getProduct(prodId);
                string display = "";
                pname.Value = p.P_NAME;
                pprice.Value = Convert.ToString(p.P_PRICE);
                pdescr.Value = p.P_DESCRIPTION;
                ppic.Value = p.P_IMAGE_url;
                pqty.Value = Convert.ToString(client.getInventory(prodId).Quantity);
                pcat.Value  =  p.P_Category;
                ppromo.Value  = Convert.ToString(p.P_PROMO);
                pactive.Value = Convert.ToString(p.P_Active);
            }

        }


        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            int prodId = int.Parse(Request.QueryString["pid"].ToString());
            Product p = client.getProduct(prodId);
            client.EditProduct(p.PId, pname.Value, int.Parse(pprice.Value), pdescr.Value, ppic.Value, char.Parse(ppromo.Value), char.Parse(pactive.Value), pcat.Value);
            client.UpdatInventory(prodId, int.Parse(pqty.Value));
            Response.Redirect("ProductListDash.aspx");
            
        }
    }
}
