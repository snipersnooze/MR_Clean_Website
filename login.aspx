<%@ Page Title="" Language="C#" MasterPageFile="~/MrClean.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MR_CLEAN_FINAL.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="css/login.css" rel="Stylesheet" />
    <script src="js/login.js"></script>
    <script src="js/login.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <div class="login-wrap">
	<div class="login-html">
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Sign In</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab">Sign Up</label>
		<div class="login-form">


			<div class="sign-in-htm">

				<div class="group">
					<label for="email" class="label">Email</label>
					<input id="email" type="text" class="input" runat="server">
				</div>
				<div class="group">
					<label for="pass" class="label">Password</label>
					<input id="pass" type="password" class="input" data-type="password" runat="server">
				</div>

				<div class="group">
			 <asp:Button  type="submit" class="button" ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" />
				</div>
				<div class="hr"></div>
	         <label id="logstatus" runat="server"  style="color:darkred; font-size:22px;" hidden>User Not Found</label>


			</div>




			<div class="sign-up-htm">

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
					<input id="cellreg" type="tel" class="input" runat="server">
				</div>

				<div class="group" >
					<label for="passreg" class="label">Password</label>
					<input id="passreg" type="password" class="input" data-type="password" runat="server">
				</div>


				<div class="group">
					<label for="emailreg" class="label">Email Address</label>
					<input id="emailreg" type="email" class="input" runat="server">
				</div>

				<div class="group">
				<asp:Button type="submit" class="button" ID="btnSignUp" runat="server" Text="Register" OnClick="btnSignUp_Click" />
				</div>

				<div class="hr"></div>
			<label id="regstatus" runat="server"  style="color:black; font-size:22px;" hidden>Succesfully Registered</label>


			</div>
		</div>
	</div>
</div>



</asp:Content>
