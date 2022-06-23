using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class Product_Catalog : System.Web.UI.Page
    {
        CleanServiceClient client = new CleanServiceClient();


        protected void Page_Load(object sender, EventArgs e)
        {
            
            


            string cat = Request.QueryString["Filter"];
            string fPrice = Request.QueryString["FilterP"];

            var listOfProducts = client.getProducts();

            if (cat == null && fPrice ==null)
            {
                listOfProducts = client.getProducts();

            }
            else if(fPrice == null)
            {
                listOfProducts = client.getFilteredCategory(cat);

            }else if(cat ==null)
            {
                int min = -1;
                int max = -1;

                if(fPrice.Equals("R200"))
                {
                    min = 1;
                    max = 200;
                }else if(fPrice.Equals("R500"))
                {
                    min = 201;
                    max = 500;
                }else if(fPrice.Equals("RMAX"))
                {
                    min = 501;
                    max = 999999;
                }
                listOfProducts = client.getItemsUnder(min, max);
            }

            string Display = "";

            foreach(Product p in listOfProducts)
                {
                 
                Display = "<div class='card' >" +
                 "<div class='image' style='background-image: url(resources/"+p.P_IMAGE_url+")'></div>" +
                 "<div class='content'>" +
                 "<h1>"+p.P_NAME+"</h1>" +
                 "<p>-------</p>" +
                 "<h1>R "+p.P_PRICE+"</h1>" +
                 "<a href=ProductView.aspx?pID="+p.PId+" class='a-button'>View Item</a>" +
                "</div>" +
                "</div>";
               
                ProdDisp.InnerHtml += Display;

            }

        }

        protected void addItemToCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}