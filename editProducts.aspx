<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="editProducts.aspx.cs" Inherits="MR_CLEAN_FINAL.editProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <link href="css/login.css" rel="Stylesheet" />
    <script src="js/login.js"></script>
    <script src="js/login.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="login-wrap" runat="server">
	<div class="login-html">
		<input id="tab-1" type="text" name="tab" class="sign-up"><label for="tab-1" class="tab">Edit a Product</label>
		
		<div class="login-form" runat ="server">
			<div>
				<div class="group">
					<label for="pname" class="label">Product Name</label>
					<input id="pname" type="text" class="input" runat="server">
				</div>

				<div class="group">
					<label for="pprice" class="label">Product Price</label>
					<input id="pprice" type="text" class="input" runat="server">
				</div>

				<div class="group">
					<label for="pdescr" class="label">Product Description</label>
					<input id="pdescr" type="text" class="input" runat="server">
				</div>

				<div class="group" >
					<label for="ppic" class="label">Product Image URL</label>
					<input id="ppic"  type="text" class="input" runat="server">
				</div>

				  <div class="group">
                      
             <label for="PPROMO">Is The Product On Promotion:</label>
                <select name="PPROMO" id="ppromo" runat="server">
                 <option value="Y">Yes</option>
                <option value="N">No</option>

                 </select>
                   </div>

				<div class="group">
                      
                <label for="PACTIVE">Product Active Status:</label>
                <select name="PACTIVE" id="pactive" runat="server">
                 <option value="A">Active</option>
                <option value="I">Inactive</option>

                 </select>
                   </div>

				<div class="group">
                      
             <label for="PCAT">Product Category:</label>
                <select name="PCAT" id="pcat" runat="server">
                 <option value="Household">Household</option>
                <option value="Clothing">Clothing</option>
				<option value="Pool">Pool</option>
                <option value="Car">Car</option>
				<option value="Covid">Covid</option>

                 </select>
                   </div>

				<div class="group" >
					<label for="pqty" class="label">Quantity</label>
					<input id="pqty" type="text" class="input" runat="server">
				</div>

				<div class="group">
				<asp:Button type="submit" class="button" ID="btnAddProduct" runat="server" Text="Save Changes" OnClick="btnSignUp_Click" />
				</div>

				<div class="hr"></div>
			<label id="AddStatus" runat="server"  style="color:black; font-size:22px;" hidden>Product Updated</label>


			</div>
		</div>
	</div>
</div>






</asp:Content>
