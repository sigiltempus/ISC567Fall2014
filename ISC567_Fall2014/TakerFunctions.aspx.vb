Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class TakerFunctions
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
        
    End Sub
#Region "Local Methods"
    Private Sub SetForm()
        If (UpdateSVT = True) Then
            UpdateSVTable()
        End If
    End Sub
     
    Private Sub UpdateSVTable()

        Dim dtUserInfo As DataTable = AppUser.GetUserProfileByID(personid, con)
        SVtable(dtUserInfo)
        'UpdateVariables()
        UpdateSVT = False
    End Sub
#End Region


End Class