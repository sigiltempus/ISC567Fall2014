Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class ExamProvider_2aspx
    Inherits JSIM.Bases.BaseClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetForm()
    End Sub

#Region "Local Methods"

    Protected Sub SetForm()
        'Retrieves the users's ID from the SvTable
        Dim personID As Integer = GetSVTableValue(Of Integer)("personID")
        Dim cn As String = GetConnectionString("connectionString")
        ' Instance of Data Access Tier
        Dim oUser As New DataAccessTier.daUser
        'Retrieves the user's Profile
        Dim dtUserInfo As DataTable = oUser.GetUserProfileByID(personID, cn)
        'Retrieves user's first and last names from the data table
        Dim firstname As String = dtUserInfo.Rows(0)("firstname").ToString()
        Dim lastname As String = dtUserInfo.Rows(0)("lastname").ToString()
        'Inserts first and last names into label on Menu
        'lblUser.Text = firstname + " " + lastname

        'For the Institution Name
        Dim providerid As Integer = GetSVTableValue(Of Integer)("providerid")

        'Retrieves the user's Profile
        Dim dtExamProviderInfo As DataTable = oUser.GetProviderId(providerid, cn)
        'Retrieves user's first and last names from the data table
        Dim ExamProviderName As String = dtExamProviderInfo.Rows(0)("name").ToString()

        'Inserts first and last names into label on Menu
        'lblUser.Text = ExamProviderName

    End Sub
#End Region





End Class

