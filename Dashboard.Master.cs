using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string Display = "";
            if(Session["utype"]!=null && Session["utype"].Equals("CUS"))
                {

         Display= "<li><a href ='Home.aspx'><i class='fa'></i><span class='nav-text'>HOME</span></a></li>" +
         "<li><a href = 'EditProfile.aspx' ><i class='fa'></i><span class='nav-text'>EDIT PROFILE</span></a></li>" +
         "<li><a href = 'Orders.aspx' ><i class='fa'></i><span class='nav-text'>VIEW ORDERS</span></a></li>" +
         "<li class='darkerli'><a href = 'Product-Catalog.aspx' ><i class='fa'></i> <span class='nav-text'>SHOPPING</span></a></li>"+
         "<li class='darkerli'><a href = 'Logout.aspx' ><i class='fa'></i> <span class='nav-text'>LOGOUT</span></a></li>";


            }
            else
            {
                Display = "<li><a href = 'Home.aspx'><i class='fa'></i><span class='nav-text'>HOME</span></a></li>" +
                          "<li><a href = 'EditProfile.aspx' ><i class='fa'></i><span class='nav-text'>EDIT PROFILE</span></a></li>" +
                          "<li><a href = 'InvoiceList.aspx' ><i class='fa '></i><span class='nav-text'>VIEW INVOICES</span></a></li>" +
                          "<li class='darkerli'><a href = 'Analytics.aspx' ><i class='fa'></i> <span class='nav-text'>ANALYTICS</span></a></li>"+
                          "<li class='darkerli'><a href = 'ProductListDash.aspx' ><i class='fa '></i> <span class='nav-text'>VIEW PRODUCTS</span></a></li>"+
                          "<li class='darkerli'><a href = 'addProducts.aspx' ><i class='fa '></i> <span class='nav-text'>ADD NEW PRODUCTS</span></a></li>"+
                          "<li class='darkerli'><a href = 'addUser.aspx' ><i class='fa '></i> <span class='nav-text'>ADD NEW USER</span></a></li>"+
                          "<li class='darkerli'><a href = 'Logout.aspx' ><i class='fa'></i> <span class='nav-text'>LOGOUT</span></a></li>";
            }
            navList.InnerHtml = Display;
        }
    }
}