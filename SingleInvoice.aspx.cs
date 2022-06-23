using MR_CLEAN_FINAL.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MR_CLEAN_FINAL
{
    public partial class SingleInvoice : System.Web.UI.Page
    {
        CleanServiceClient client = new CleanServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)//not logged in no acces
            {
                Response.Redirect("Home.aspx");//end goal redirect home

            }
            



            if (Session["uid"] != null && !IsPostBack)//if someone is looged in
            {
                int invoiceNum = int.Parse(Request.QueryString["InvID"]);
                var fullInv = client.getInvoice(invoiceNum);// retrieve with user id products they added to cart
                var lineInv = client.getInvoiceLines(fullInv.I_ID);
                var userF = client.GetUser(fullInv.User_ID);
                string prev = Session["prev"].ToString();


                UserInfo.InnerHtml = "<a class ='btn' href='"+prev+"'>Go To Dashboard</a>" +
                  "<h1 style='font-size:28px; margin:0;'>Invoice Number:<span>[</span> <em><a href = '#' target = '_blank'> " + fullInv.I_ID + " </a ></em> <span class='last-span is-open'>]</span></h1>"+
                  "<h1 style='font-size:28px;margin:0;'>Customer Name:<span>[</span> <em><a href = '#' target = '_blank'> " + userF.User_Name + " </a></em> <span class='last-span is-open'>]</span></h1>";


                string dis = "";

                if (lineInv == null)
                {

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
                    foreach (InvoiceLine l in lineInv)
                    {
                        count++;

                        var p = client.getProduct(l.PId);
                        //var prod=client.
                        double totalperitem = (double)(l.P_PRICE * l.P_Quantity);
                        totalnotax += totalperitem;



                        dis = "<article class='product' id='artprod'>" +
                          "<header>" +
                            "<a>" +
                              "<img src ='resources/" + p.P_IMAGE_url + "'alt=''>" +
                              "</a>" +
                         " </header>" +
                          "<div class='content'>" +
                            "<h1>" + p.P_NAME + "</h1>" +
                          "</div>" +
                          "<footer class='content'>" +
                           "<span class ='qt'>Quantity:" + l.P_Quantity + "</span>" +
                           "<input class='qtinput' value='" + l.P_Quantity + "'name='qty" + p.PId + "' runat='server' type='hidden'/> " +
                            "<h2 class='full-price'>" +
                             totalperitem + " ZAR" +
                            "</h2>" +
                            "<h2 class='price'>" +
                               l.P_PRICE +
                            "</h2>" +
                          "</footer>" +
                        "</article>";

                        cart.InnerHtml += dis;

                    }

                    if (totalnotax != 0)
                    {
                        deliveryfee = 100;
                        promodiscount = 100;//to decide still
                    }

                    total += totalnotax + deliveryfee;

                    tax += (0.15 * total);

                    subtot.InnerText = Convert.ToString(totalnotax);
                    vat.InnerText = Convert.ToString(tax);
                    finalTotal.InnerText = Convert.ToString(total);
                    shipping.InnerText = Convert.ToString(deliveryfee);

                    




                    //calculate vat
                    /*
                    sc.InnerHtml = dis;//shopping cart info
                    notax.InnerText = (totalnotax).ToString();//ttl with no tax
                    dfee.InnerText = deliveryfee.ToString();//delivery fee
                    taxTtl.InnerText = (tax).ToString();
                    totalwithTax.InnerText = (total + tax).ToString();
                    */

                }
            }
        }
    }
}
