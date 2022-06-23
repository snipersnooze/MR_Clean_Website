<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="MR_CLEAN_FINAL.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="css/login.css" rel="Stylesheet" />
    <script src="js/login.js"></script>
    <script src="js/login.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-wrap">
	<div class="login-html">
		<input id="tab-1" type="text" name="tab" class="sign-up"><label for="tab-1" class="tab">Edit My Details</label>
		
		<div class="login-form">


			<div >

				<div class="group">
					<label for="fnamereg" class="label">First Name</label>
					<input id="fnamereg" type="text" class="input" runat="server">
				</div>

				<div class="group">
					<label for="lnamereg" class="label">Last Name</label>
					<input id="lnamereg" type="text" class="input" runat="server">
				</div>

				<div class="group">
					<label for="cellreg" class="label">Cell No.</label>
					<input id="cellreg" type="number" class="input" runat="server">
				</div>

				<div class="group" >
					<label for="passreg" class="label">Password</label>
					<input id="passreg"  type="password" class="input" data-type="password" runat="server">
				</div>


				<div class="group">
					<label for="emailreg" class="label">Email Address</label>
					<input id="emailreg" type="email" class="input" runat="server">
				</div>

				<div class="group">
				<asp:Button type="submit" class="button" ID="btnSignUp" runat="server" Text="Edit" OnClick="btnSignUp_Click" />
				</div>

				<div class="hr"></div>
			<label id="regstatus" runat="server"  style="color:black; font-size:22px;" hidden>Details editted</label>



</asp:Content>
