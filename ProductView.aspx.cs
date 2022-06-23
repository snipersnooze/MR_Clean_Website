using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class ProductView : System.Web.UI.Page
    {
        CleanServiceClient client = new CleanServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {




            string Display = "";


            int prodID = int.Parse(Request.QueryString["pID"]);
            string added = Request.QueryString["Added"];
            
            if(added!=null)
            {
                isLogged.InnerHtml = "<h1 style = 'color:green; text-align:center; word-wrap:break-word;max - width:500px;'>Item Successfully Added to your cart</h1>";

            }

            var p = client.getProduct(prodID);



           Display= "<div class='cardS-grid'>"+
           "<div class='cardS'>"+
           "<div class='cardS__background' style='background-image: url(resources/"+p.P_IMAGE_url+")'></div>"+
           "<div class='cardS__content'>"+
           "<p class='cardS__category'>"+p.P_Category+"</p>" +
           "<h3 class='cardS__heading'>"+p.P_NAME+"</h3>" +
           "<h3 class='cardS__heading'style='margin-top:-20px;margin-bottom:10px;'>R" + p.P_PRICE + "</h3>" +
           "</div>" +
           "</div>" +
          "</div>";

            SingleView.InnerHtml = Display;

           descriptionProd.InnerHtml= "<p style = 'color:white; text-align:center; word-wrap:break-word;max - width:500px;'>" + p.P_DESCRIPTION + "</p>";

            if (Session["utype"] == null)
            {
                EditItem.Visible = false;


            }
            else if (Session["utype"].Equals("MAN"))
            {
                addToCart.Visible = false;
            }
            else if (Session["utype"].Equals("CUS"))
            {
                EditItem.Visible = false;
            }

            


        }

        protected void addToCart_Click(object sender, EventArgs e)
        {


            if(Session["utype"] != null)
              {

                int uid = int.Parse(Session["uid"].ToString());
                int prodID = int.Parse(Request.QueryString["pID"]);

                int qty = int.Parse(prodQty.Value);

                client.AddtoCart(prodID, uid, qty);

                isLogged.InnerHtml = "<h1 style = 'color:green; text-align:center; word-wrap:break-word;max - width:500px;'>Item Successfully Added to your cart</h1>";
                Response.Redirect(Request.RawUrl+"&Added=1");

            }
            else
            {
                isLogged.InnerHtml = "<h1 style = 'color:red; text-align:center; word-wrap:break-word;max - width:500px;'>Please log in to add items to your cart</h1>";

            }
           



        }

        protected void EditItem_Click(object sender, EventArgs e)
        {
            int prodID = int.Parse(Request.QueryString["pID"]);
            Response.Redirect("editProducts.aspx?pid="+prodID);

        }
    }
}