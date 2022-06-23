using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class Analytics : System.Web.UI.Page
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

            ///Display all analytical info

            string Display = "";
           
            //Session["uid"].ToString();     //logged in user id ||user type already set prior don't accomodate for user type

            //Display on analytical item eg. number of users 


            Display = "<a class='cardf' id='numUsers' href='Product-Catalog.aspx'>" +          //remove href - no need here 
                "<div class='cardf__background' style='background-image: url(resources/Users.jpg)'></div>" +        //dont worry about pictures now i'll sort out
                "<div class='cardf__content'>" +       // all textual elements go after this 
                "<h2 class='cardf__category'>Total Number Of Users:</h2>" +            // small top heading 
               "<h3 class='cardf__heading'>" + client.TtlNumUser() + "</h3>" +                    // large text in centre     add more of these two if more info is required per card
                "</div>" +
               "</a>";
             dynamicContent.InnerHtml += Display;

            //end of one item 

            //registered users per day
            Display = "<a class='cardf' id='RegUsers' href='Product-Catalog.aspx'>" +          //remove href - no need here 
               "<div class='cardf__background' style='background-image: url(resources/Users.jpg)'></div>" +        //dont worry about pictures now i'll sort out
               "<div class='cardf__content'>" +       // all textual elements go after this 
               "<h2 class='cardf__category'>Registered Users Per day:</h2>" +
              // small top heading 
              ///add like a calender thing to choose which day
              "<h3 class='cardf__heading'>" + client.RegUsersPerDay(DateTime.Today.Date.ToString()) + "</h3>" +                    // large text in centre     add more of these two if more info is required per card
              // small top heading 

              "</div>" +
              "</a>";
            dynamicContent.InnerHtml += Display;


            //Number of products we sell

            Display = "<a class='cardf' href='ProductListDash.aspx' >" +          //remove href - no need here 
                "<div class='cardf__background' style='background-image: url(resources/Products.jpg)'></div>" +        //dont worry about pictures now i'll sort out
                "<div class='cardf__content'>" +
                "<h2 class='cardf__category'>Number Of Products We Sell:</h2>" +// all textual elements go after this 
                "<h3 class='cardf__heading'>" + client.TotalProducts() + "</h3>" +            // small top heading 
                     "</div>" +
               "</a>";                                                                         // large text in centre     add more of these two if more info is required per card

            dynamicContent.InnerHtml += Display;

            //end of one item 


            //Display x analytical item - eg whatever - just copy paste for however many analytical things you want to display
            //sales for the day so far

            Display = "<a class='cardf' id='salesForDay' href='InvoiceList.aspx'>" +          //remove href - no need here 
                "<div class='cardf__background' style='background-image: url(resources/SalesPerDay.jpg)'></div>" +        //dont worry about pictures now i'll sort out
                "<div class='cardf__content'>" +       // all textual elements go after this 
                "<h2 class='cardf__category'>Sales Made For The Day So Far:</h2>" +            // small top heading 
               "<h3 class='cardf__heading'>" + client.TotalSalesCertainDate(DateTime.Today.Date.ToString()) + "</h3>" +                    // large text in centre     add more of these two if more info is required per card
                "</div>" +
               "</a>";
            dynamicContent.InnerHtml += Display;

            //end of one item 

            //tax payable
            Display = "<a class='cardf' id='tax' href='#'>" +          //remove href - no need here 
                           "<div class='cardf__background' style='background-image: url(resources/Tax.jpg)'></div>" +        //dont worry about pictures now i'll sort out
                           "<div class='cardf__content'>" +       // all textual elements go after this 
                           "<h2 class='cardf__category'>Total Tax Paid:</h2>" +            // small top heading 
                          "<h3 class='cardf__heading'>" + client.ToatalTax() + "</h3>" +                    // large text in centre     add more of these two if more info is required per card
                           "</div>" +
                          "</a>";
            dynamicContent.InnerHtml += Display;

            //Total items on hand

            Display = "<a class='cardf' id='productsOnHand' href='Product-Catalog.aspx'>" +          //remove href - no need here 
                "<div class='cardf__background' style='background-image: url(resources/TotStock.jpg)'></div>" +        //dont worry about pictures now i'll sort out
                "<div class='cardf__content'>" +       // all textual elements go after this 
                "<h2 class='cardf__category'>Total Stock on Hand:</h2>" +
               // small top heading 
               "<h3 class='cardf__heading'>" + client.TotalItemsOnHand() + "</h3>" +                    // large text in centre     add more of these two if more info is required per card
                                                                                                        // small top heading 

               "</div>" +
               "</a>";
            dynamicContent.InnerHtml += Display;

            

            //MOST SOLD STOCK
            Display = "<a class='cardf' id='RegUsers' href='ProductView.aspx?pID="+ client.getProduct(client.maxProductSold()).PId+"'>" +          //remove href - no need here 
              "<div class='cardf__background' style='background-image: url(resources/Users.jpg)'></div>" +        //dont worry about pictures now i'll sort out
              "<div class='cardf__content'>" +       // all textual elements go after this 
              "<h2 class='cardf__category'>Most sold stock:</h2>" +
              // small top heading 
              ///add like a calender thing to choose which day
            "<h3 class='cardf__heading'>" + client.getProduct(client.maxProductSold()).P_NAME + "</h3>" +                    // large text in centre     add more of these two if more info is required per card
                                                                                                                                   // small top heading
             "</div>" +
             "</a>";
            dynamicContent.InnerHtml += Display;



                 var li = client.getProducts();
            int count = 0;
            foreach (Product p in li)
            {
                count++;
                Display = "<a class='cardf' href='Product-Catalog.aspx'>" +          //remove href - no need here 
                "<div class='cardf__background' style='background-image: url(resources/"  +  p.P_IMAGE_url  +  "'></div>" +        //dont worry about pictures now i'll sort out
                "<div class='cardf__content'>" +       // all textual elements go after this 
                "<h2 class='cardf__category' style='color:#1cefff;'>Item no:" + count + "</h2>" +
              "<h3 class='cardf__category'>" + p.P_NAME + "</h3>" +
                "<h4 class='cardf__category'>Stock on Hand:</h4>";
                if  (client.getInventory(p.PId).Quantity  <  5)
                {
                    Display += "<h5 class='cardf__heading' style='color:#1cefff;'>" + client.getInventory(p.PId).Quantity + "(needs restock)</h5>"; // small top heading 
                 }    
                else
                {
                    Display += "<h5 class='cardf__heading' style='color:#1cefff;'>" + client.getInventory(p.PId).Quantity + "</h5>";  // small top heading 


                }
                // large text in centre     add more of these two if more info is required per card
               Display+= "</div>" +
               "</a>";                                                                                                         // small top heading 
                stockContent.InnerHtml += Display;
            }

        }
    }
}
