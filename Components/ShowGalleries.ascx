<%@ Control Language="vb" autoeventwireup="false" codebehind="ShowGalleries.ascx.vb" Inherits="Gallery.ShowGalleries" targetschema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ import Namespace="System.Data" %>
<asp:Repeater id="parentRepeater" runat="server">
    <itemtemplate>
        <div><strong> <%# DataBinder.Eval(Container.DataItem, "NAME") %> </strong> 
        <br />
        <asp:repeater id="childRepeater" runat="server" datasource='<%# Container.DataItem.Row.GetChildRows("myrelation") %>'>
            <itemtemplate>
                <a href="Photos.aspx?gal=<%# Container.DataItem("GALLERY_ID") %>"><img style='border:1px solid #000;margin-bottom:4px' src='LargeImage.aspx?img=<%# Container.dataitem( "FILENAME")%>' alt="cconway - photography" /></a>
                </div>
            </itemtemplate>
        </asp:Repeater>
    </itemtemplate>
</asp:Repeater>
