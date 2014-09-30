Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class AddEditExam
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

    Private Sub SetForm()
        Dim mode As String = Request.QueryString("mode")

        populateExamToSchedule()

        If mode = "add" Then
            AddNew()
        ElseIf mode = "edit" Then
            EditSchedule()
        Else
            'TODO
        End If
        'btnSave.Parameters = CreateParameters()
    End Sub
    'Populates Drop Down List for Scheduling Exam
    Private Sub populateExamToSchedule()
        Dim dtExamList As DataTable = GetNonScheduledExamList()

        If Not IsNothing(dtExamList) AndAlso dtExamList.Rows.Count > 0 Then
            With ddlExam
                .DataSource = dtExamList
                .DataValueField = "examid"
                .DataTextField = "examname"
                .DataBind()
                .Items.Insert(0, New ListItem("- Select Exam To Schedule -", "-1"))
                .SelectedItem.Value = "-1"
            End With
        Else
            lblMessage.Text = "No Exams to be scheduled. Please add new exam before scheduling."
            lblMessage.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Private Sub AddNew()
        ddlExam.SelectedItem.Value = "-1"
        txtDate.Value = ""
        txtStartTime.Text = ""
        txtEndTime.Text = ""
        txtLocation.Text = ""
    End Sub

    Private Sub EditSchedule()
        lblTitle.Text = "Edit Schedule"

        'Disable Exam dropdown list box
        ddlExam.Enabled = False

        Dim dtExamInfo As DataTable
        Dim cn As String = GetConnectionString("connectionString")
        Dim institutionid As Integer = CInt(Session("institutionIdInContext"))
        Dim scheduledexamid As Integer = CInt(Session("selectedExamId"))

        Dim oExam As New DataAccessTier.daInstitution
        dtExamInfo = oExam.GetScheduledExamInfoById(institutionid, scheduledexamid, cn)

        If Not oExam.TransactionSuccessful Then
            dtExamInfo = Nothing
        End If
        'Format(CDate(TextBox1.Text), "MM/dd/yyyy").
        If Not IsNothing(dtExamInfo) AndAlso dtExamInfo.Rows.Count > 0 Then
            With dtExamInfo
                ddlExam.SelectedItem.Text = .Rows(0)("examname").ToString()
                ddlExam.SelectedItem.Value = .Rows(0)("scheduledexamid").ToString()
                txtDate.Value = Format((CDate(.Rows(0)("examdate"))), "yyyy-MM-dd")
                txtStartTime.Text = .Rows(0)("examStartTime").ToString()
                txtEndTime.Text = .Rows(0)("examEndTime").ToString()
                txtLocation.Text = .Rows(0)("examlocation").ToString()
            End With
        Else
            'TODO
        End If
    End Sub

#Region "Local Functions"
    ' Returns a list of Exams 
    Private Function GetNonScheduledExamList() As DataTable
        Dim dtNonScheduledExamList As DataTable
        Dim oExam As New DataAccessTier.daInstitution

        Dim institutionid As Integer = CInt(Session("institutionIdInContext"))
        Dim cn As String = GetConnectionString("connectionString")

        dtNonScheduledExamList = oExam.GetNonScheduledExamList(institutionid, cn)

        If Not oExam.TransactionSuccessful Then
            dtNonScheduledExamList = Nothing
        End If

        Return dtNonScheduledExamList
    End Function

    Private Shared Function InsertScheduleExam(ByVal examid As Integer, ByVal examname As String, ByVal examDate As DateTime, ByVal examStartTime As DateTime, ByVal examEndTime As DateTime, ByVal examlocation As String, ByVal institutionpeopleid As Integer) As String
        Dim strStatus As String = ""
        Dim cn As String = GetConnectionString("connectionString")

        Dim oExam As New DataAccessTier.daUser
        oExam.InsertScheduleExamDetails(examid, examname, examDate, examStartTime, examEndTime, examlocation, institutionpeopleid, cn)
        If oExam.TransactionSuccessful Then
            strStatus = "Schedule was successfully inserted"
        Else
            strStatus = "An error occured while trying to insert schedule: " & oExam.ErrorMessage
        End If
        Return strStatus
    End Function

    Private Shared Function AddEditScheduledExam(ByVal scheduledExamId As Integer, ByVal examid As Integer, ByVal examname As String,
                                                 ByVal examDate As DateTime, ByVal examStartTime As DateTime, ByVal examEndTime As DateTime,
                                                 ByVal examlocation As String, ByVal institutionpeopleid As Integer, ByVal mode As String) As String
        Dim strStatus As String = ""
        Dim cn As String = GetConnectionString("connectionString")

        Dim oExam As New DataAccessTier.daInstitution

        oExam.AddEditScheduledExam(scheduledExamId, examid, examname, examDate, examStartTime, examEndTime, examlocation, institutionpeopleid, cn)

        If oExam.TransactionSuccessful Then
            If mode = "edit" Then
                strStatus = "Exam Schedule was successfully Updated"
            Else
                strStatus = "Exam Schedule was successfully Added"
            End If

        Else
            strStatus = "An error occured while trying to update the schedule: " & oExam.ErrorMessage
        End If
        Return strStatus
    End Function

#End Region

#Region "Click Event Handlers for Page Controls"
    
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim mode As String = Request.QueryString("mode")

        Dim examDate As DateTime
        Dim examStartTime As DateTime
        Dim examEndTime As DateTime
        Dim scheduledExamId = -1 ' Default for Upsert

        If mode = "edit" Then
            scheduledExamId = CInt(Session("selectedExamId"))
        Else
            scheduledExamId = -1
        End If

        Dim institutionid As Integer = CInt(Session("institutionIdInContext"))
        Dim examid As Integer = CInt(ddlExam.SelectedItem.Value)
        Dim examName As String = ddlExam.SelectedItem.Text
        Dim personid As Integer = GetSVTableValue(Of Integer)("personid")
        Dim examlocation As String = txtLocation.Text

        Dim strMssg As String = ""

        Try
            examDate = CDate(txtDate.Value + " 00:00:00.000")
            examStartTime = CDate("1900-01-01 " + txtStartTime.Text)
            examEndTime = CDate("1900-01-01 " + txtEndTime.Text)
        Catch ex As Exception
            ' if an exception occur trying to convert the user entered value to appropriate data type
            lblMessage.ForeColor = Drawing.Color.Red
            lblMessage.Text = ex.Message
            lblMessage.Visible = True
        Finally
            strMssg = AddEditScheduledExam(scheduledExamId, examid, examName, examDate, examStartTime, examEndTime, examlocation, personid, mode)
        End Try

        lblMessage.Text = strMssg
        lblMessage.Visible = True
    End Sub

#End Region

    Protected Sub txtStartTime_TextChanged(sender As Object, e As EventArgs) Handles txtStartTime.TextChanged
        'txtEndTime.Text = 
    End Sub
End Class