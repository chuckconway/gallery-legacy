<%@ Import Namespace="System.Data" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Photos.aspx.vb" Inherits="Gallery.Photo"%>
<%@ Register TagPrefix="uc1" TagName="ShowGalleries" Src="Components/ShowGalleries.ascx" %>
<HTML>
	<HEAD>
		<title>Cconway.com - Photo Galleries</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script src="gallerypics.js" type="text/javascript"></script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:PlaceHolder ID="plhPhotos" Runat="server" />
		</form>
	</body>
</HTML>
