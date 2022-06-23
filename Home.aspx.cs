using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CleanServiceClient client = new CleanServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            

            string Display = "";

            var listOfProducts = client.isOnPromo();


            foreach (Product p in listOfProducts)
            {
                if  (p.P_Active.Equals('A'))
                {
                    Display = "<div class='card'>" +
                     "<div class='image' style='background-image: url(resources/" + p.P_IMAGE_url + ")'></div>" +
                     "<div class='content'>" +
                     "<h1>" + p.P_NAME + "</h1>" +
                     "<p>-------</p>" +
                     "<h1>R " + p.P_PRICE + "</h1>" +
                     "<a href=ProductView.aspx?pID=" + p.PId + " class='a-button'>View Item</a>" +
                    "</div>" +
                    "</div>";
               
                PromoProds.InnerHtml += Display;
                 }
            }



        }
    }
}