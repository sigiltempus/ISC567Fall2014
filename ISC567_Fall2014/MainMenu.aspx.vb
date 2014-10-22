Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Imports System.Web

Public Class MainMenu
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

    Protected Sub SetForm()
        '
        'This block of code will retrieve the user's ID, call the method to retrieve the user's profile,
        '     and display the user's name in the menu
        '
        'Retrieves the users's ID from the SvTable
        Dim personid As Integer = GetSVTableValue(Of Integer)("personid")
        isSA = GetSVTableValue(Of Boolean)("isSA")
        isInstitution = GetSVTableValue(Of Boolean)("isInstitution")
        isProvider = GetSVTableValue(Of Boolean)("isProvider")
        isTaker = GetSVTableValue(Of Boolean)("isTaker")
        isDeveloper = GetSVTableValue(Of Boolean)("isDeveloper")
        isRoster = GetSVTableValue(Of Boolean)("isRoster")

        isInstStaff = GetSVTableValue(Of Boolean)("isInstStaff")
        isExProvStaff = GetSVTableValue(Of Boolean)("isExProvStaff")

        ' Instance of Data Access Tier
        Dim oUser As New DataAccessTier.daUser
        'Retrieves the user's Profile
        Dim dtUserProfile As DataTable = oUser.GetUserProfileByID(personid, con)
        'Retrieves user's first and last names from the data table
        Dim firstname As String = dtUserProfile.Rows(0)("firstname").ToString()
        Dim lastname As String = dtUserProfile.Rows(0)("lastname").ToString()
        'Inserts first and last names into label on Menu
        lblSVLineName.Text = firstname + " " + lastname
        
        'Enables all functionality for the System Administrator
        If isSA = True Then
            lbtnListPersons.Visible = True ' List Person
            lbtnInstitutionFunctions.Visible = True ' Institution Function
            lbtnExamProviderFunctions.Visible = True ' Exam Provider Function
            lbtnTakerFunctions.Visible = True ' Exam Taker Function
            lbtnProgramFunctions.Visible = True ' List Program
        End If
        'Enables Institution functionality
        If isInstitution = True Then
            lbtnInstitutionFunctions.Visible = True ' Institution Function
            lbtnProgramFunctions.Visible = True ' List Program
        End If
        'Enables Exam Provider functionality
        If isProvider = True Then
            lbtnExamProviderFunctions.Visible = True ' Exam Provider Function
        End If
        'Enables Taker functionality
        If isTaker = True Then
            lbtnTakerFunctions.Visible = True ' Exam Taker Function
        End If
    End Sub

End Class

