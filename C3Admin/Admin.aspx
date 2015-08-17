<%@ Register TagPrefix="uc1" TagName="PhotoMgmtAdmin" Src="Components/PhotoMgmtAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NewPhotoAdmin" Src="Components/NewPhotoAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="GalleryAdmin" Src="Components/GalleryAdmin.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Blank" Src="Components/Blank.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Admin.aspx.vb" Inherits="Gallery.GalleryPage"%>
<%@ Register TagPrefix="uc1" TagName="nav" Src="Components/nav.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="Components/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:nav id="Nav1" runat="server"></uc1:nav><br />
			<asp:PlaceHolder ID="plhAdmin" Runat="server" /><br />
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
		</form>
	</body>
</HTML>
