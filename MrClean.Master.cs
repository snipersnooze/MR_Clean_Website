using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{

    public partial class MrClean : System.Web.UI.MasterPage
    {
        CleanServiceClient client = new CleanServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            DisablePageCaching();

            string Display = "";




     if (Session["utype"] == null)
     {

                Display = "<a href='login.aspx'>LOG IN</a>";

     }else if (Session["utype"].Equals("MAN"))
     {

                Display = "<a href='EditProfile.aspx'>VIEW DASHBOARD</a>" +
                           "<a href='Logout.aspx'>LOG OUT</a>";

     }
      else
     {
                int uid = int.Parse(Session["uid"].ToString());
                int cartNum = client.getCartNumbers(uid);
                Display = "<a href='Trolley.aspx'>CART <p class='cartqty'>"+cartNum+"</p></a>" +
                 "<a href='EditProfile.aspx'>VIEW PROFILE</a>"+
                   "<a href='Logout.aspx'>LOG OUT</a>";

            }

            checkLogged.InnerHtml = Display;
           

 


            




        }

        public static void DisablePageCaching()
        {

            //Used for disabling page caching

            HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            HttpContext.Current.Response.Cache.SetValidUntilExpires(false);

            HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
        }
    }
}