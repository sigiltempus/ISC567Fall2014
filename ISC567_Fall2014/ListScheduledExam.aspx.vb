Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class ListScheduledExam
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

#Region "Local Methods"

    Protected Sub SetForm()
        PopulateRadioList()
        PopulateGV_ExamList()
    End Sub

    Private Sub PopulateRadioList()
        Dim dtStatus As DataTable = GetExamStatus()
        rblSelect.DataSource = dtStatus
        rblSelect.DataTextField = dtStatus.Columns("statusName").ToString()
        rblSelect.DataValueField = dtStatus.Columns("statusId").ToString()
        rblSelect.SelectedValue = "2" ' Scheduled Exam by default
        rblSelect.DataBind()

        rblSelect.Items.Insert(0, New ListItem("All Exams", "-1"))
    End Sub

    Private Sub PopulateGV_ExamList()
        Dim dtExams As DataTable = GetExams(CInt(rblSelect.SelectedValue))

        gvExamList.DataSource = dtExams
        gvExamList.DataBind()
    End Sub

#End Region

#Region "Local Functions Calling Data Access Tier"

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

    Private Function GetExams(examStatus As Integer) As DataTable
        Dim dtExams As DataTable
        Dim cn As String = GetConnectionString("connectionString")
        Dim oExam As New DataAccessTier.daInstitution

        dtExams = oExam.GetInstitutionExamByStatus(CInt(Session("institutionIdInContext")), examStatus, cn)

        If Not oExam.TransactionSuccessful Then
            dtExams = Nothing
        End If

        Return dtExams
    End Function

#End Region

#Region "Click Event Handlers for Page Controls"

    Protected Sub gvExamList_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvExamList.Sorting
        PopulateGV_ExamList()
    End Sub

    Protected Sub gvExamList_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Add the selected exam's examScheduleId in the grid to the session variable
        Dim selectedExamId As String = gvExamList.SelectedValue.ToString

        If (CInt(selectedExamId) = -1) Then
            btnEditSchedule.Visible = False
        Else
            btnEditSchedule.Visible = True
            Session.Add("selectedExamId", selectedExamId.ToString())
        End If
    End Sub

    Protected Sub rblSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblSelect.SelectedIndexChanged
        ' Update the Grid on radio selection change
        PopulateGV_ExamList()

        If (CInt(rblSelect.SelectedValue) = 1) Then ' Created option selected
            'We don't want to edit exams in created status as it has not been scheduled yet
            btnEditSchedule.Visible = False
        Else
            btnEditSchedule.Visible = True
        End If
    End Sub

#End Region

End Class