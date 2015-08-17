Public Class GalleryPage
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents plhAdmin As System.Web.UI.WebControls.PlaceHolder

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

        Dim strControl As String
        Dim ctlAdminControl As Control

        Select Case Request.QueryString("admin")
            
            Case "Gal"
                strControl = "Components/GalleryAdmin.ascx"
            Case "New"
                strControl = "Components/NewPhotoAdmin.ascx"
            Case "Mgmt"
                strControl = "Components/PhotoMgmtAdmin.ascx"
            Case ""
                strControl = "Components/blank.ascx"
        End Select

        ctlAdminControl = LoadControl(strControl)
        plhAdmin.Controls.Add(ctlAdminControl)

    End Sub

End Class
