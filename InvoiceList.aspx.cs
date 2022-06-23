using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class InvoiceList : System.Web.UI.Page
    {
        CleanServiceClient client = new CleanServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["uid"] == null)//not logged in no acces
            {
                Response.Redirect("Home.aspx");//end goal redirect home

            } else if (Session["utype"].Equals("CUS"))
            {
                Response.Redirect("Home.aspx");//end goal redirect home

            }
            //pages where only admins allowed add this and inside put line 18
            ///Display customer invoices on the admin side // idk how yall want to display this ? all invoices ? 
            ///filtered using a customer ID ? just add logic for it i'll add additional ui elements
            /// Use a normal int or string and just add a comment that it needs to get input from ui next to where variable was created

            Session["prev"] = Request.RawUrl;

            string Display = "";


            foreach (Invoice invoice in client.getInvoices())
            {

                DateTime date = invoice.I_Time.Date;
                string formatted = date.ToString("dd/M/yyyy");

                Display += "<a class='cardf' href='SingleInvoice.aspx?InvID=" + invoice.I_ID + "'>" +
                        "<div class='cardf__background' style='background-image: url(resources/mackenzie-marco-XG88BYDSDZA-unsplash.jpg)'></div>" +        //dont worry about pictures now i'll sort out
                       "<div class='cardf__content'>" +
                     "<h3 class='cardf__heading'>Name:" + client.GetUser(invoice.User_ID).User_Name+ "</p>"+// all textual elements go after this 
                    "<h3 class='cardf__heading'>Invoice:" + invoice.I_ID + "</p>" +
                      "<h3 class='cardf__heading'>Date:" + formatted +"</p>" +  // small top heading 
                      "<h3 class='cardf__heading'>R " + invoice.I_Total + "</h3>" +                    // large text in centre     add more of these two if more info is required per card
                       "</div>" +
                      "</a>";
            }
                dynamicContent.InnerHtml += Display;

    
        }
    }
}