<%@ Control Language="vb" AutoEventWireup="false" Codebehind="NewPhotoAdmin.ascx.vb" Inherits="Gallery.PhotoAdmin" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<h1>Photo Management</h1>
<div class="outline">
	<h2>Add New Photo</h2>
	<input id="inpfileup" type="file" name="inpfileup" runat="server"><br>
	<strong>gallery</strong><br>
	<asp:dropdownlist id="dropGallery" runat="server"></asp:dropdownlist><br>
	<strong>title</strong>
	<br>
	<asp:textbox id="txttitle" runat="server"></asp:textbox><br>
	<strong>description</strong>
	<br>
	<asp:textbox id="txtdescript" runat="server" height="70" width="240"></asp:textbox><br>
	<strong>date taken</strong>
	<br>
	<asp:textbox id="txtdate" runat="server"></asp:textbox><br>
	<br>
	<asp:button id="btnUpload" onclick="button_click" runat="server" text="upload file!"></asp:button><br>
	<b>
		<asp:label id="lblerror" runat="server"></asp:label></b><br>
</div>
<br>
<div class="outline">&nbsp;</div>
