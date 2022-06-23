using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class ProductListDash : System.Web.UI.Page
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
            ///Display all products here 
            var c = client.getProducts();
            string Display = "";

            //string uid = Session["uid"].ToString();     //logged in user id ||user type already set prior don't accomodate for user type

            foreach(Product p in c)
            {
                Display = "<a class='cardf' href='editProducts.aspx?pid=" + p.PId + "'>" +
                "<div class='cardf__background' style='background-image: url(resources/" + p.P_IMAGE_url + ")'></div>" +        //use product image url here  
                "<div class='cardf__content'>" +       // all textual elements go after this 
                "<p class='cardf__category'>" + p.P_Category + "</p>" +            // product categoy here
               "<h3 class='cardf__heading'>" + p.P_NAME + "</h3>" +
               "<h3 class='cardf__heading'>" + p.P_PRICE + "</h3>" +// product name  // add h3 for price // dont add description 
                "</div>" +
               "</a>";
                dynamicContent.InnerHtml += Display;
            }

            

            //end for each

           



        }
    }
}