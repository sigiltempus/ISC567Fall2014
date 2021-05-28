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
        personid = GetSVTableValue(Of Integer)("personid")
        isSA = GetSVTableValue(Of Boolean)("isSA")
        isInstitution = GetSVTableValue(Of Boolean)("isInstitution")
        isProvider = GetSVTableValue(Of Boolean)("isProvider")
        isTaker = GetSVTableValue(Of Boolean)("isTaker")
        isEmployee = CType(Session("isEmployee"), Boolean)
        isCurriculum = CType(Session("isCurriculum"), Boolean)


        isInstStaff = GetSVTableValue(Of Boolean)("isInstStaff")
        isExProvStaff = GetSVTableValue(Of Boolean)("isExProvStaff")
        'Make sure after save -> rebuild -> set Login.aspx as start page
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
            'lbtnExamProviderFunctions.Visible = True ' Exam Provider Function
            lbtnTakerFunctions.Visible = True ' Exam Taker Function
            lbtnCurriculumFunctions.Visible = True ' List Program
            lbtnsociety.Visible = True ' List society
        End If
        'Enables Institution functionality
        If isInstitution = True Then
            lbtnInstitutionFunctions.Visible = True ' Institution Function
            lbtnCurriculumFunctions.Visible = True ' List Program

        End If
        'Enables Exam Provider functionality
        'If isProvider = True Then
        '    lbtnExamProviderFunctions.Visible = True ' Exam Provider Function
        'End If
        'Enables Taker functionality
        If isTaker = True Then
            lbtnTakerFunctions.Visible = True ' Exam Taker Function
        End If
        If isCurriculum = True Then
            lbtnCurriculumFunctions.Visible = True ' List Program
        End If
        If isEmployee = True Then
            lbtnInstitutionFunctions.Visible = True ' Institution Function
        End If


    End Sub

End Class

