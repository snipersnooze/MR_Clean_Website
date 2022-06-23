<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingleInvoice.aspx.cs" Inherits="MR_CLEAN_FINAL.SingleInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>MR CLEAN</title>
           <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"> </script>

       <script src="js/Cart.js"> </script>
      <link href="css/Cart.css" rel="Stylesheet" />

</head>
<body>

    <form id="form1" runat="server" method="post">

       <header id="site-header">
    <div class="container" id="UserInfo" runat="server">
     
    </div>
  </header>

  <div class="container" >
      
    <section id="cart" runat="server"> 

    </section>

  </div>




  <footer id="site-footer">
    <div class="container clearfix">

      <div class="left">
        <h2 class="subtotal">Subtotal: <span id="subtot" runat="server">0.00</span> ZAR</h2>
          <h3 class="tax">Taxes (15%): <span id="vat" runat="server">0</span> ZAR</h3>
        <h3 class="shipping">Shipping: <span id="shipping" runat ="server">0.00</span> ZAR</h3>
      </div>

      <div class="right">
        <h1 class="total">Total: <span id="finalTotal" runat="server">0.00</span> ZAR</h1>
      </div>
    </div>
  </footer>




    </form>
</body>
</html>
