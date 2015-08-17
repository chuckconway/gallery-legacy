<%@ Control Language="vb" AutoEventWireup="false" Codebehind="GalleryAdmin.ascx.vb" Inherits="Gallery.GalleryAdmin" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<h1>Gallery Management</h1>
<div class="outline">
	<h2>New Gallery Name</h2>
	<asp:textbox id="txtGalleryName" Text="" runat="server"></asp:textbox><br>
	<asp:label id="lblResults" runat="server"></asp:label><br>
	<asp:button id="btnSubmit" onclick="Submit_Click" Text="Submit" runat="server"></asp:button></div>
<br>
<h2>Current Galleries</h2>
<span style="FONT-SIZE: x-small; COLOR: red">*Do NOT delete default gallery named 
	'General'<br>
	*Photos left in deleted Galleries will be set to the default gallery </span>
<asp:datagrid id="drgGalleryInsert" Runat="server" Width="450px" AutoGenerateColumns="False" DataKeyField="GALLERY_ID"
	OnCancelCommand="drgGalleryInsert_CancelCommand" OnUpdateCommand="drgGalleryInsert_UpdateCommand"
	OnEditCommand="drgGalleryInsert_EditCommand" OnDeleteCommand="drgGalleryInsert_DeleteCommand">
	<Columns>
		<asp:BoundColumn DataField="NAME" HeaderText="Gallery Name"></asp:BoundColumn>
		<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
		<asp:TemplateColumn>
			<ItemTemplate>
				<asp:linkbutton id="cmdDelete" CommandName="Delete" runat="Server" Text="Delete" />
			</ItemTemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:datagrid>
