﻿Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Imports DataAccessTier.daUser
Public Class ExamProvider_7
    Inherits JSIM.Bases.BaseClass
    Dim cn As String = GetConnectionString("connectionString")
    Dim InstitutionID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            setForm()
        End If
    End Sub
    Public Sub setForm()


        populategv(InstitutionID)
        PopulateRadioList()
    End Sub

    'Public Sub populateddl()

    '    Dim cn As String = GetConnectionString("connectionString")

    '    Dim oUser As New DataAccessTier.daUser
    '    Dim dtInstitutionNames As DataTable
    '    dtInstitutionNames = oUser.GetInstitutionNames(cn)
    '    Dim dtInstitutionNamesView As DataView
    '    dtInstitutionNamesView = dtInstitutionNames.DefaultView
    '    'DropDownList1.DataTextField = "name"
    '    'DropDownList1.DataValueField = "institutionid"
    '    'DropDownList1.DataSource = dtInstitutionNamesView
    '    'DropDownList1.DataBind()
    '    'DropDownList1.Items.Insert(0, New ListItem("Name of Universities", "0"))

    'End Sub

    Private Sub PopulateRadioList()
        Dim dtStatus As DataTable = GetExamStatus()
        rblSelect.DataSource = dtStatus
        rblSelect.DataTextField = dtStatus.Columns("statusName").ToString()
        rblSelect.DataValueField = dtStatus.Columns("statusId").ToString()
        rblSelect.SelectedValue = "2" ' Scheduled Exam by default
        rblSelect.DataBind()

        rblSelect.Items.Insert(0, New ListItem("All Exams", "-1"))
    End Sub
    Public Sub populategv(InstitutionID As Integer)

        Dim oUser As New DataAccessTier.daUser
        Dim dtInstitutionExams As DataTable
        InstitutionID = CInt(Session("institutionid").ToString)
        dtInstitutionExams = oUser.GetExamList(InstitutionID, cn)
        'Dim dtInstitutionExamsView As DataView
        'dtInstitutionExamsView = dtInstitutionExams.DefaultView

        RadioButtonGridView2.DataSource = dtInstitutionExams
        RadioButtonGridView2.DataBind()

    End Sub

    Private Function GetExamStatus() As DataTable
        Dim dtStatus As DataTable
        Dim cn As String = GetConnectionString("connectionString")
        Dim oExam As New DataAccessTier.daInstitution
        'Exam status from Status table for filtering
        dtStatus = oExam.GetExamStatus(cn)

        If Not oExam.TransactionSuccessful Then
            dtStatus = Nothing
        End If

        Return dtStatus
    End Function

    'Public Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
    '    RadioButtonGridView2.Visible = True
    '    InstitutionID = CInt(DropDownList1.SelectedValue)

    '    populategv(InstitutionID)

    'End Sub




    Protected Sub RadioButtonGridView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonGridView2.SelectedIndexChanged
        Session("examid") = RadioButtonGridView2.SelectedDataKey.Value
    End Sub


    Protected Sub OpenIFrameButton4_Click(sender As Object, e As EventArgs) Handles OpenIFrameButton4.Click
        If RadioButtonGridView2.SelectedDataKey.Value Is Nothing Then
            lblErrorMessage.Text = "Please select an Exam."
            setForm()
        End If
    End Sub

    Protected Sub rblSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblSelect.SelectedIndexChanged
        ' Update the Grid on radio selection change
        populategv(InstitutionID)


    End Sub

End Class