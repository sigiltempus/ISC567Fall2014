Imports JSIM.Bases.SVTable
Public Class Login
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserLogin.Focus()
    End Sub

    Private Sub AuthenticateUser(ByVal username As String, password As String)
        ' Get Connection String
        Dim cn As String = GetConnectionString("connectionString")

        ' Instance of Data Access Tier
        Dim oUser As New DataAccessTier.daUser

        ' Validate User based upon the login/password entered
        oUser.ValidateUser(username, password, cn)

        ' If the User was found for given login/password
        If oUser.IsFound Then
            ' Confirm that User information exists for additional confirmation
            Dim dtUserProfile As DataTable = oUser.GetUserProfile(username, password, cn)
            If Not IsNothing(dtUserProfile) AndAlso dtUserProfile.Rows.Count > 0 Then
                ' Store the user profile in our base class 
                UserProfile = dtUserProfile

                'Create the SV Table
                CreateSVTable(cn)

                Dim foo As DataTable = GetSVTable()

                Session("Lastname") = dtUserProfile.Rows(0)("lastname").ToString()
                Session("institutionid") = dtUserProfile.Rows(0)("institutionid").ToString()

                'Place data from table into variables that will be passed to the SV table
                Dim personid As String = dtUserProfile.Rows(0)("personid").ToString()
                InsertSVTableValue(Of String)("personid", personid)               
                Dim institutionid As String = dtUserProfile.Rows(0)("institutionid").ToString()
                InsertSVTableValue(Of String)("institutionid", institutionid)
                Dim isTaker As String = dtUserProfile.Rows(0)("isTaker").ToString()
                InsertSVTableValue(Of String)("isTaker", isTaker)
                Dim isProvider As String = dtUserProfile.Rows(0)("isProvider").ToString()
                InsertSVTableValue(Of String)("isProvider", isProvider)
                Dim isInstitution As String = dtUserProfile.Rows(0)("isInstitution").ToString()
                InsertSVTableValue(Of String)("isInstitution", isInstitution)
                Dim isSA As String = dtUserProfile.Rows(0)("isSA").ToString()
                InsertSVTableValue(Of String)("isSA", isSA)

                ' Redirect to main menu
                Response.Redirect("MainMenu.aspx")

            Else
                ' Display error message
                lblError.Text = "Login failed for User: " & username
            End If
        End If

    End Sub

    Protected Sub UserLogin_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles UserLogin.Authenticate
        Dim username As String = UserLogin.UserName
        Dim password As String = UserLogin.Password
        AuthenticateUser(username, password)
    End Sub

End Class

