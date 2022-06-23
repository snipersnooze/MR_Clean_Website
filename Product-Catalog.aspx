<%@ Page Title="" Language="C#" MasterPageFile="~/MrClean.Master" AutoEventWireup="true" CodeBehind="Product-Catalog.aspx.cs" Inherits="MR_CLEAN_FINAL.Product_Catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet">

    <div>
          <h3 style="text-align:center; font-size:4rem;">Product Categories</h3>
    </div>
      

<section class="hero-section">





    <div class="cardf-grid">

        
         <a class="cardf" href="Product-Catalog.aspx">
            <div class="cardf__background" style="background-image: url(resources/All.jpg)"></div>
            <div class="cardf__content">
                <p class="cardf__category">Filter By category:</p>
                <h3 class="cardf__heading">All</h3>
            </div>
        </a>

      

        
        <a class="cardf" href="Product-Catalog.aspx?Filter=Household">
            <div class="cardf__background" style="background-image: url(resources/house.jpg)"></div>
            <div class="cardf__content">
                <p class="cardf__category">Filter By category:</p>
                <h3 class="cardf__heading">Household</h3>
            </div>
        </a>
           

        <a class="cardf" href="Product-Catalog.aspx?Filter=Pool">
             <div class="cardf__background" style="background-image: url(resources/pool.jpg)"></div>
            <div class="cardf__content">
                <p class="cardf__category">Filter By category:</p>
                <h3 class="cardf__heading">Pool</h3>
            </div>
        </a>

        <a class="cardf" href="Product-Catalog.aspx?Filter=Car">
              <div class="cardf__background" style="background-image: url(resources/car.jpg)"></div>
            <div class="cardf__content">
                <p class="cardf__category">Filter By category:</p>
                <h3 class="cardf__heading">Car</h3>
            </div>
        </a>


        <a class="cardf" href="Product-Catalog.aspx?Filter=Clothing">
              <div class="cardf__background" style="background-image: url(resources/clothing.jpg)"></div>
            <div class="cardf__content">
                <p class="cardf__category">Filter By category:</p>
                <h3 class="cardf__heading">Clothing</h3>
            </div>
        </a>

        <a class="cardf" href="Product-Catalog.aspx?Filter=Covid">
            <div class="cardf__background" style="background-image: url(resources/covid.jpg)"></div>
            <div class="cardf__content">
                <p class="cardf__category">Filter By category:</p>
                <h3 class="cardf__heading">Covid</h3>
            </div>
        </a>

        
        <a class="cardf" href="Product-Catalog.aspx?FilterP=R200">
            <div class="cardf__background" style="background-image: url(resources/Price.jpg)"></div>
            <div class="cardf__content">
                <p class="cardf__category">Filter By Price:</p>
                <h3 class="cardf__heading">R1 - R200</h3>
            </div>
        </a>

        <a class="cardf" href="Product-Catalog.aspx?FilterP=R500">
            <div class="cardf__background" style="background-image: url(resources/Price.jpg)"></div>
            <div class="cardf__content">
                <p class="cardf__category">Filter By Price:</p>
                <h3 class="cardf__heading">R201 - R500</h3>
            </div>
        </a>

        <a class="cardf" href="Product-Catalog.aspx?FilterP=RMAX">
            <div class="cardf__background" style="background-image: url(resources/Price.jpg)"></div>
            <div class="cardf__content">
                <p class="cardf__category">Filter By Price:</p>
                <h3 class="cardf__heading">R501 - MAX</h3>
            </div>
        </a>

    </div>

    </section>
    <section class="cardwrapper" id="ProdDisp" runat="server">
    </section>
    <div id="productbtn"></div>

</asp:Content>
