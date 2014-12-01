Imports JSIM.Bases.SVTable
Public Class AddEditCourseOutcome
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ProgramidSv As Integer
        'ProgramidSv = GetSVTableValue(Of Integer)("Programid")
        ProgramidSv = CInt(Session("programid"))
        'Dim CourseId As Integer
        'CourseId = CInt(Session("courseid"))
        'ProgramidSv = 1s
        If IsNothing(ProgramidSv) Then
            Response.Redirect("Loginpage.aspx")
        End If
        If Not IsPostBack Then
            SetFrom()
        End If
    End Sub

#Region "Local Methods"
    Private Sub SetFrom()
        Dim mode As String = Request.QueryString("mode")
        'PopulatePrograms()

        If mode = "add" Then
            AddNew()
        Else
            EditUSer()
        End If
        btnSave.Parameters = CreateParameters()
    End Sub

    Private Sub AddNew()
        dgFrame.Text = "Add Course OutCome"
        'ddlProgram.SelectedIndex = -1
        'ddlCourse.SelectedIndex = -1
        txtPrgoutcom.Text = ""
        txtShortoutcome.Text = ""
        txtCrsOutcomeNumber.Text = ""
    End Sub

   
    Private Sub EditUSer()
        dgFrame.Text = "Edit Course OutCome"
        GetSVTable()
        Dim crsoutcomesid As Integer = GetSVTableValue(Of Integer)("crsoutcomesid")
        'Dim programid As Integer = 1
        'Dim programid As Integer = GetSVTableValue(Of Integer)("programid")
        Dim CourseId As Integer = GetSVTableValue(Of Integer)("courseid")

        Dim dtUserlInfo As DataTable = GetCourseOutcome(crsoutcomesid)

        If Not IsNothing(dtUserlInfo) AndAlso dtUserlInfo.Rows.Count > 0 Then
            With dtUserlInfo
                txtShortoutcome.Text = .Rows(0)("crsshortoutcome").ToString()
                txtPrgoutcom.Text = .Rows(0)("crsoutcometext").ToString()
                txtProgramseq.Text = .Rows(0)("crsoutcomesid").ToString()
                'ddlProgram.SelectedValue = .Rows(0)("programid").ToString()
                txtCrsOutcomeNumber.Text = .Rows(0)("crsoutcomenum").ToString()
            End With
        End If
    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        GetSVTable()
        Dim mode As String = Request.QueryString("mode")
        paramContainer.AddParameter("mode", mode, False)
        'Dim programid As Integer = Convert.ToInt16(GetSVTableValue(Of Integer)("programid"))
        'paramContainer.AddParameter("programid", CStr(programid), False)
        Dim programid As Integer = CInt(Session("programid"))
        paramContainer.AddParameter("programid", CStr(programid), False)
        Dim CourseId As Integer = CInt(Session("courseid"))
        
        paramContainer.AddParameter("courseid", CStr(CourseId), False)
        paramContainer.AddParameter("crsoutcometext", txtPrgoutcom)
        paramContainer.AddParameter("crsshortoutcome", txtShortoutcome)
        paramContainer.AddParameter("crssequencenum", txtProgramseq)
        paramContainer.AddParameter("crsoutcomenum", txtCrsOutcomeNumber)
        'Dim crsoutcomesid As Integer = Convert.ToInt16(GetSVTableValue(Of Integer)("crsoutcomesid"))
        paramContainer.AddParameter("crsoutcomesid", txtProgramseq)
        Return MyBase.CreateParameters()
    End Function

#End Region

#Region "Local Functions"
    Private Function GetCourseOutcome(ByVal crsoutcomesid As Integer) As DataTable
        Dim dtUserlInfo As DataTable
        Dim oUser As New DataAccessTier.daCourse
        Dim con As String = GetConnectionString("connectionString")
        dtUserlInfo = oUser.GetCourseOutcome(crsoutcomesid, con)
        If Not oUser.TransactionSuccessful Then
            dtUserlInfo = Nothing
        End If
        Return dtUserlInfo
    End Function


    Private Shared Function InsertCourseOutcomes(ByVal programid As Integer, ByVal CourseId As Integer, ByVal crsoutcometext As String, ByVal crsshortoutcome As String, ByVal crssequencenum As Integer, ByVal crsoutcomenum As String, ByVal crsoutcomesid As Integer) As String

        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("connectionString")
        Dim oUser As New DataAccessTier.daCourse
        oUser.InsertCourseOutcomes(programid, CourseId, crsoutcometext, crsshortoutcome, crssequencenum, crsoutcomenum, crsoutcomesid, con)
        If oUser.TransactionSuccessful Then
            strStatus = "Course Outcome added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Shared Function UpdateCourseOutcome(ByVal programid As Integer, ByVal CourseId As Integer, ByVal crsoutcometext As String, ByVal crsshortoutcome As String, ByVal crssequencenum As Integer, ByVal crsoutcomenum As String, ByVal crsoutcomesid As Integer) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("connectionString")
        Dim oUser As New DataAccessTier.daCourse
        oUser.UpdateCourseOutcome(crsoutcomesid, programid, CourseId, crsoutcometext, crsshortoutcome, crssequencenum, crsoutcomenum, con)
        If oUser.TransactionSuccessful Then
            strStatus = "Course Outcome added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function
#End Region

#Region "Click Event Handlers for Page Controls"

    'Protected Sub ddlProgram_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProgram.SelectedIndexChanged
    '    Dim index As Integer = ddlProgram.SelectedIndex
    '    PopulateCourses()
    'End Sub

    'Protected Sub ddlCourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCourse.SelectedIndexChanged
    '    Dim index As Integer = ddlCourse.SelectedIndex
    '    Dim CourseId As Integer = CInt(ddlCourse.SelectedIndex.ToString())
    '    Dim s As Boolean = InsertSVTableValue(Of Integer)("courseid", CourseId)
    '    btnSave.Parameters = CreateParameters()

    'End Sub

#End Region

#Region "Local WebService Methods"
    <Services.WebMethod()> _
    Public Shared Function wsAddEditCourseOutcome(ByVal mode As String, ByVal programid As Integer, ByVal CourseId As Integer, ByVal crsoutcometext As String, ByVal crsshortoutcome As String, ByVal crssequencenum As Integer, ByVal crsoutcomenum As String, ByVal crsoutcomesid As Integer) As String
        Dim strmsg As String = ""
        If mode = "add" Then
            strmsg = InsertCourseOutcomes(programid, CourseId, crsoutcometext, crsshortoutcome, crssequencenum, crsoutcomenum, crsoutcomesid)
        ElseIf mode = "edit" Then
            strmsg = UpdateCourseOutcome(programid, CourseId, crsoutcometext, crsshortoutcome, crssequencenum, crsoutcomenum, crsoutcomesid)
        Else
            strmsg = "No Mode was Selected"
        End If
        Return strmsg
    #End Function
#End Region






End Class