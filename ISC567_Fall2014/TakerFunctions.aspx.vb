Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Imports System.Web
Public Class TakerFunctions
    Inherits JSIM.Bases.BaseClass


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()


        End If
        
    End Sub




#Region "Local Methods"
    Private Sub SetForm()
        personid = GetSVTableValue(Of Integer)("personid")
        Dim oUser As New DataAccessTier.daUser
        'Retrieves the user's Profile
        Dim dtUserProfile As DataTable = oUser.GetUserProfileByID(personid, con)
        'Retrieves user's first and last names from the data table
        Dim firstname As String = dtUserProfile.Rows(0)("firstname").ToString()
        Dim lastname As String = dtUserProfile.Rows(0)("lastname").ToString()
        'Inserts first and last names into label on Menu
        lblSVLineName2.Text = "Welcome " + firstname + " " + lastname + "!"

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


    Protected Sub btnRoster_Click(sender As Object, e As EventArgs) Handles btnRoster.Click

    End Sub
End Class