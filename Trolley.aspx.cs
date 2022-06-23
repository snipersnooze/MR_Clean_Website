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
    public partial class Trolley : System.Web.UI.Page
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





            if (Session["uid"] != null && !IsPostBack)//if someone is looged in
            {
                int uid = (int)Session["uid"];
                var items = client.getCarts(uid);// retrieve with user id products they added to cart
                string dis = "";

                if (items == null)
                {
                    btnCheckOut.Enabled = false;
                }
                else
                {
                    double total = 0;
                    double totalnotax = 0;
                    double tax = 0;
                    double promodiscount = 0;//from company as couertesy discounteg aniversary discount
                                             //user has option to add
                    double deliveryfee = 0;//standard fee anywhere around country
                    int count = 0;
                    foreach (Cart c in items)
                    {
                        count++;

                        var p = client.getProduct(c.PId);
                        //var prod=client.
                       
                        double totalperitem = (double)(p.P_PRICE * c.P_Quantity);
                        totalnotax += totalperitem;



                        dis = "<article class='product' id='artprod'>" +
                          "<header>" +
                            "<a class='remove'>" +
                              "<input class='qtremoved' value='0' id='removedProd" + p.PId + "' name='removedProd" + p.PId + "' runat='server' type='hidden'/> " +
                              "<img src ='resources/" + p.P_IMAGE_url + "'>" +
                              "<h3> Remove product</h3>" +
                              "</a>" +
                         " </header>" +
                          "<div class='content'>" +
                            "<h1>" + p.P_NAME + "</h1>" +
                          "</div>" +
                          "<footer class='content'>" +
                            "<span class='qt-minus'>-</span>" +
                           "<span class ='qt'>" + c.P_Quantity + "</span>" +
                           "<input class='qtinput' value='" + c.P_Quantity + "'name='qty" + p.PId + "' runat='server' type='hidden'/> " +
                           "<span class='qt-plus'>+</span>" +
                            "<h2 class='full-price'>" +
                             totalperitem + " ZAR" +
                            "</h2>" +
                            "<h2 class='price'>";
                        if (p.P_PROMO.Equals('Y'))
                        {
                            dis += p.P_PRICE+" (Promo Applied)";
                        }
                        else
                        {
                            dis += p.P_PRICE;
                        }
                        
                           dis+= "</h2>" +
                          "</footer>" +
                        "</article>";
                        cart.InnerHtml += dis;
                    }

                    if (totalnotax != 0)
                    {
                        deliveryfee = 100;
                     //   promodiscount = (0.10*totalnottax);//to decide still
                    }

                    total += totalnotax + deliveryfee;

                    tax += (0.15 * total);

                    subtot.InnerText = Convert.ToString(totalnotax);
                    vat.InnerText= Convert.ToString(tax);
                    finalTotal.InnerText= Convert.ToString(total);
                    shipping.InnerText= Convert.ToString(deliveryfee);
                }
            }
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            updateCart();
            int uid = int.Parse(Session["uid"].ToString());
            var cartCheck = client.getCarts(uid);
            if(cartCheck.Length>0)
            {
                int Invid = client.AddInvoice((int)Session["uid"], DateTime.Now);

                foreach (Cart c in cartCheck)
                {
                    var p = client.getProduct(c.PId);
                    client.AddInvLine(Invid, c.PId, decimal.ToInt32(p.P_PRICE), c.P_Quantity, decimal.ToInt32(p.P_PRICE * c.P_Quantity), p.P_NAME);
                    client.UpdateInventory(p.PId, c.P_Quantity);
                }
                client.RemoveWholeCart(uid);
                client.UpdateInvoice(Invid, int.Parse(finalTotal.InnerText));
                Session["prev"] = "Orders.aspx";
                Response.Redirect("SingleInvoice.aspx?InvID=" + Invid);
            }
            else
            {
                Response.Redirect("Trolley.aspx");
            }
        }
        protected void updateCart()
        {
            int uid = (int)Session["uid"];
            var items = client.getCarts(uid);// retrieve with user id products they added to cart
            int count = 0;

            if (items == null)
            {

            }
            else
            {
               foreach(Cart c in items)
                {
                    count++;
                    string prodIDToRemove = "removedProd" + c.PId;
                    var elementUpdate = Request.Form["qty"+c.PId];
                    int newAmount = int.Parse(elementUpdate);
                    var element = Request.Form[prodIDToRemove];

                    Cart newCart = c;
                   if(element.Equals("1"))
                    {
                        client.RemoveCart(uid, c.PId);
                        newCart = null;
                    }

                   if(newCart!=null)
                    {
                        client.updateCart(newCart.PId, uid, newAmount);

                    }

                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updateCart();
            Response.Redirect("Trolley.aspx");

        }
    }
}