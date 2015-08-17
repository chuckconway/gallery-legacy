<%@ Control Language="vb" AutoEventWireup="false" Codebehind="GalleryPhotos.ascx.vb" Inherits="Gallery.GalleryPhotos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:Repeater id="rptShowPhotos" runat="server">

	<ItemTemplate>
	
		<a href="javascript:showPic('photos/<%# Container.dataitem( "FILENAME")%>','photography','<%# Container.dataitem( "DESCRIPTION")%>','<%# Container.dataitem( "TITLE")%>','<%# Container.dataitem("DATETAKEN")%>');"><img style='border:1px solid #000;margin-bottom:4px'  src='showimage.aspx?img=<%# Container.dataitem( "FILENAME")%>' alt="cconway - photography"/></a>
		
	</ItemTemplate>

</asp:Repeater>
