Imports ByteFX.Data.MySQLClient

Public Class Photo
    Inherits System.Web.UI.Page
    Protected WithEvents plhPhotos As System.Web.UI.WebControls.PlaceHolder
    


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strGalleryID As String = Request.QueryString("gal")
        Dim ctlPhotoControl As Control

        If (strGalleryID = "") Then

            ctlPhotoControl = LoadControl("Components/ShowGalleries.ascx")
            plhPhotos.Controls.Add(ctlPhotoControl)

        Else

            ctlPhotoControl = LoadControl("Components/GalleryPhotos.ascx")
            plhPhotos.Controls.Add(ctlPhotoControl)

        End If

    End Sub

End Class
