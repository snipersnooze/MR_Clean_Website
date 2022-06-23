<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Analytics.aspx.cs" Inherits="MR_CLEAN_FINAL.Analytics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    

     <section class="hero-section">
    <div class="cardf-grid" id ="dynamicContent" runat ="server">


        </div>
        </section>

    <br/>
    <h1 id="stock" style ="font-size:50px; text-align:center;" >Product Analysis</ h1>
    <br/>



         <section class="hero-section">

    <div class="cardf-grid" id ="stockContent" runat ="server">


        </div>
        </section>



</asp:Content>
