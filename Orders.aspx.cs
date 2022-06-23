using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class Orders : System.Web.UI.Page
    {
        CleanServiceClient client = new CleanServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)//not logged in no acces
            {
                Response.Redirect("Home.aspx");//end goal redirect home

            }
            else if (Session["utype"].Equals("MAN"))
            {
                Response.Redirect("Home.aspx");//end goal redirect home

            }
            ///Display all customer invoices using their id
            Session["prev"] = Request.RawUrl;

            string Display = "";
            int uid=int.Parse(Session["uid"].ToString());
      
            foreach (Invoice invoice in client.getUserInvoices(Convert.ToInt32(uid)))
            {
                DateTime date = invoice.I_Time.Date;
                string formatted = date.ToString("dd/M/yyyy");


                Display = "<a class='cardf' href='SingleInvoice.aspx?InvID="+invoice.I_ID+"'>" +          //remove href if element doesn't need to take you anywhere
                    "<div class='cardf__background' style='background-image: url(resources/Orders.jpg)'></div>" +        //dont worry about pictures now i'll sort out 
                    "<div class='cardf__content'>" +       // all textual elements go after this 
                    "<h3 class='cardf__heading'>Invoice:"+invoice.I_ID+"</p>" +
                    "<h3 class='cardf__heading'>Date:" + formatted + "</p>"+  // small top heading 
                   "<h3 class='cardf__heading'>R"+invoice.I_Total+"</h3>" +                    // large text in centre     add more of these two if more info is required per card
                    "</div>" +
                   "</a>";
                    dynamicContent.InnerHtml += Display;

            }

            //end for each



        }
    }
}