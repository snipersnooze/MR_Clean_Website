<%@ Page Title="" Language="C#" MasterPageFile="~/MrClean.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="MR_CLEAN_FINAL.ProductView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section class="hero-sectionS" id="SingleView" runat="server">
 
</section>


            <div class="vertical-center">
           <div class="quantity buttons_added" >
	              <input type="button" value="-" class="minus"><input type="number" runat="server" id="prodQty" step="1" min="1" max="10" name="quantity" value="1" title="Qty" class="input-text qty" size="1" pattern="" inputmode="" style=" color:white;background-color:transparent;width: 41px;height: 41px;text-align:center;"><input type="button" value="+" class="plus">              
              </div>  
           </div>

         <div class="vertical-center" runat ="server">
           
                  <asp:Button ID="addToCart" runat="server" Text="Add To Cart" class="button-54" OnClick="addToCart_Click"/>
                  <asp:Button ID="EditItem" runat="server" Text="Edit Item" class="button-54" OnClick="EditItem_Click"/>

         </div>

  
      <div class="vertical-center" id="isLogged" runat ="server">

   </div>


    <div class="vertical-center" id="descriptionProd" runat ="server">

   </div>


</asp:Content>
