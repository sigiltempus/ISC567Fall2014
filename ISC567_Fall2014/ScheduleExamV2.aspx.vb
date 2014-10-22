Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class ScheduleExamV2
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub
#Region "Local Methods"

    Private Sub SetForm()
        PopulateExamList()
    End Sub

    Private Sub PopulateExamList()
        Dim PersonID As Integer = GetSVTableValue(Of Integer)("PersonID")
        Dim dtExamList As DataTable = GetExam()

        If Not IsNothing(dtExamList) AndAlso dtExamList.Rows.Count > 0 Then
            With ddlExam
                .DataSource = dtExamList
                .DataTextField = "examname"
                .DataBind()
                .Items.Insert(0, New ListItem("-select a exam-", "-1"))
            End With

        Else

        End If

    End Sub
#End Region
#Region "local Functions"

    Private Function GetExam() As DataTable
        Dim dtExamList As DataTable
        Dim cn As String = GetConnectionString("connectionString")
        Dim oExam As New DataAccessTier.daUser
        dtExamList = oExam.GetExam(cn)
        If Not oExam.TransactionSuccessful Then
            oExam = Nothing

        End If
        Return dtExamList
    End Function
#End Region

    Protected Sub ddlExam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlExam.SelectedIndexChanged
        'PopulateExamList()
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim objScheduleExam As New DataAccessTier.daUser()
        Dim examname As String
        Dim cn As String = GetConnectionString("connectionString")
        Dim personid As Integer = GetSVTableValue(Of Integer)("PersonID")
        examname = ddlExam.SelectedValue
        Session("ExamName") = examname
        If ddlExam.SelectedValue = "-1" Then
            lblErr.Text = "Select Exam"

        Else
            Dim status As String = "Scheduled"
            'TEMP WORKAROUND FOR LOGIC - TEAM2 - J00087408
            personid = 6
            objScheduleExam.InsertScheduleExamForTaker(personid, examname, status, cn)
            Response.Redirect("Roster.aspx")
        End If
    End Sub
End Class
