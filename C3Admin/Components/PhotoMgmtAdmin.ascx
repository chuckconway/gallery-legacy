<%@ Control Language="vb" autoeventwireup="false" codebehind="PhotoMgmtAdmin.ascx.vb" Inherits="Gallery.PhotoMgmtAdmin" targetschema="http://schemas.microsoft.com/intellisense/ie5" %>
<div class="outline">
	<h2>Select Gallery
	</h2>
	<asp:dropdownlist id="dropGalleryList" runat="server" onSelectedIndexChanged="dropGalleryList_Select"
		autopostback="true"></asp:dropdownlist>
	<br>
	<asp:datagrid id="dgrdPhotoGallery" OnItemCreated="DeteleItem_OnItemBound"
OnDeleteCommand="dgrdPhotoGallery_DeleteCommand" OnEditCommand="dgrdPhotoGallery_EditCommand"
		OnUpdateCommand="dgrdPhotoGallery_UpdateCommand" OnItemDataBound="ItemDataBound"
 OnCancelCommand="dgrdPhotoGallery_CancelCommand"
		DataKeyField="GALLERY_PHOTOS_ID" AutoGenerateColumns="False"
		Width="450px" Runat="server">
		<Columns>
			<asp:TemplateColumn>
				<ItemTemplate>
					<img style='border:1px solid #000;' src='../showimage.aspx?img=<%# Container.dataitem( "FILENAME")%>' alt="cconway - photography" />
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn Visible="False" DataField="PHOTOS_ID" HeaderText="Title"></asp:BoundColumn>
			<asp:BoundColumn DataField="TITLE" HeaderText="Title"></asp:BoundColumn>
			<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Description"></asp:BoundColumn>
			<asp:BoundColumn DataField="DATETAKEN" HeaderText="Date Taken"></asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="GALLERY_ID" HeaderText="Title"></asp:BoundColumn>
			<asp:TemplateColumn>
				<EditItemTemplate>
					<asp:DropDownList ID="dropEditGalleryList" DataSource="<%# BindState() %>" DataValueField="GALLERY_ID" DataTextField="NAME" Runat="server" />
				</EditItemTemplate>
			</asp:TemplateColumn>
			<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
			<asp:TemplateColumn>
				<ItemTemplate>
					<asp:linkbutton id="btnDelete" CommandName="Delete" runat="Server" Text="Delete" />
				</ItemTemplate>
			</asp:TemplateColumn>
			
			
		</Columns>
	</asp:datagrid>
	<asp:Label id="lblTest" runat="server" visible="False"></asp:Label>
</div>
<div class="outline">
</div>
