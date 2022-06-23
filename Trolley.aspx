<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trolley.aspx.cs" Inherits="MR_CLEAN_FINAL.Trolley" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
           <script src="js/jquery.js"> </script>
           <script src="js/Cart.js"></script>  
           <link href="css/Cart.css" rel="Stylesheet" />
           <title>MR CLEAN</title>
</head>
<body>
    <form id="form1" runat="server" method="post">

       <header id="site-header">
    <div class="container">
        <a class ="btn" href="Home.aspx">Go Home</a>
      <h1>Shopping cart <span>[</span> <em><a href="Home.aspx" target="_blank">Mr Clean</a></em> <span class="last-span is-open">]</span></h1>
    </div>
  </header>

  <div class="container">
      
    <section id="cart" runat="server">    
      </section>

  </div>




  <footer id="site-footer">
    <div class="container clearfix">

      <div class="left">
        <h2 class="subtotal">Subtotal: <span id="subtot" runat="server">0.00</span> ZAR</h2>
          <h3 class="tax">Taxes (15%): <span id="vat" runat="server">0</span> ZAR</h3>
        <h3 class="shipping">Shipping: <span id="shipping" runat ="server">0.00</span> ZAR</h3>
      <asp:Button ID="btnUpdate" class="btn" runat="server" Text="Update Cart" OnClick="btnUpdate_Click"/>
      </div>

      <div class="right">
        <h1 class="total">Total: <span id="finalTotal" runat="server">0.00</span> ZAR</h1>
          <asp:Button ID="btnCheckOut" class="btn" runat="server" Text="Checkout" OnClick="btnCheckOut_Click" href="#popup1"/>
      </div>
    </div>
  </footer>
    </form>
</body>

   
</html>
