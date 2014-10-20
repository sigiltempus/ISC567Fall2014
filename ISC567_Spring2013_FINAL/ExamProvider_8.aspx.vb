Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Imports System.Data.SqlClient
Imports DataAccessTier.daUser

Public Class ExamProvider_8
    Inherits JSIM.Bases.BaseClass
    Dim cn As String = GetConnectionString("connectionString")

    Dim mode As String
    Dim AppUser As New DataAccessTier.daUser
    Dim etypeid As Integer



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If

    End Sub
    Protected Sub SetForm()

        etypeid = CInt(Session("etypeid"))
        mode = Request.QueryString("mode")
        If mode = "add" Then
            AddExamMethod()
        ElseIf mode = "edit" Then
            EditExamMethod()
        End If
    End Sub
    Private Sub AddExamMethod()


        Dim dtExamInfo As DataTable = AppUser.GetETypeExamInfo(cn)
        ddlExamType.Visible = True
        ddlExamType.DataSource = dtExamInfo
        ddlExamType.DataTextField = "description"
        ddlExamType.DataValueField = "etypeid"
        ddlExamType.DataBind()



    End Sub
    Private Sub EditExamMethod()
        Dim dtUserInfo As DataTable

        dtUserInfo = AppUser.GetExamListforEdit(CInt(Session("examid")), cn)

        If Not IsNothing(dtUserInfo) AndAlso dtUserInfo.Rows.Count > 0 Then
            With dtUserInfo
                txtName.Text = .Rows(0)("examname").ToString()

                Dim dtExamInfo As DataTable = AppUser.GetETypeExamInfo(cn)
                ddlExamType.Visible = True
                ddlExamType.DataSource = dtExamInfo
                ddlExamType.DataTextField = "description"
                ddlExamType.DataValueField = "etypeid"
                ddlExamType.DataBind()

                txtPurpose.Text = .Rows(0)("exampurpose").ToString()
                txtDuration.Text = .Rows(0)("duration").ToString()
            End With
        End If
    End Sub

    'Protected Sub ddlExamType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlExamType.SelectedIndexChanged

    'End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Dim examname As String
        Dim Duration As String = "hh:mm:ss"

        mode = Request.QueryString("mode")
        Dim examid As Integer = Convert.ToInt32(Session("examid"))

        If mode = "add" Then
            AppUser.addOrUpdateExam(-1, txtName.Text, CDec(txtDuration.Text), CInt(Session("providerid")),
                                    CInt(ddlExamType.SelectedValue.ToString()), txtPurpose.Text, cn)
            'Edit 10/17/2014 - J00087408 
            'provide confirmation of success and clear screen to prevent duplicate data.
            If AppUser.TransactionSuccessful Then
                lblMessage.Visible = True
                lblMessage.Text = "Exam sucessfully added"
                txtName.Text = ""
                txtPurpose.Text = ""
                txtDuration.Text = ""

            End If
            'End edit
        ElseIf mode = "edit" Then
            Dim eid As Integer = CInt(Session("examid"))

            AppUser.addOrUpdateExam(eid, txtName.Text, CDec(txtDuration.Text), CInt(Session("providerid")),
                                    CInt(ddlExamType.SelectedValue.ToString()), txtPurpose.Text, cn)
            'Edit 10/17/2014 - J00087408 
            'provide confirmation of success and clear screen to prevent duplicate data.
            If AppUser.TransactionSuccessful Then
                lblMessage.Visible = True
                lblMessage.Text = "Exam sucessfully added"
                txtName.Text = ""
                txtPurpose.Text = ""
                txtDuration.Text = ""

            End If

            'End edit
        End If
    End Sub
End Class
