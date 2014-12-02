Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Imports DataAccessTier.daUser
Public Class WorkonExam
    Inherits JSIM.Bases.BaseClass
    Dim cn As String = GetConnectionString("connectionString")
    Dim InstitutionID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            setForm()
        End If

    End Sub
#Region "Local Methods"

    Public Sub setForm()
        PopulateRadioList()
        populategv(InstitutionID)

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

    Public Sub populategv(InstitutionID As Integer)
        Dim dtInstitutuionExams As DataTable = GetExams(CInt(rblSelect.SelectedValue))
        RadioButtonGridView2.DataSource = dtInstitutuionExams
        RadioButtonGridView2.DataBind()
    End Sub

#End Region

    Private Function GetExams(examStatus As Integer) As DataTable
        Dim dtInstitutionExams As DataTable
        Dim cn As String = GetConnectionString("connectionString")
        Dim oExam As New DataAccessTier.daUser



        dtInstitutionExams = oExam.GetExamList(CInt(Session("institutionid").ToString), CInt(Session("selectedProgramId").ToString), examStatus, cn)

        If Not oExam.TransactionSuccessful Then
            dtInstitutionExams = Nothing
        End If

        Return dtInstitutionExams
    End Function

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
        Session("examstatusid") = rblSelect.SelectedValue
        populategv(InstitutionID)


    End Sub

End Class