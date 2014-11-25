Imports JSIM.Bases.SVTable
Public Class AddEditCourse
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ProgramidSv As Integer
        ProgramidSv = GetSVTableValue(Of Integer)("Programid")
        'ProgramidSv = 1
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
        If mode = "add" Then
            AddNew()
        Else
            EditUSer()
        End If
        btnSave.Parameters = CreateParameters()
    End Sub

    Private Sub AddNew()
        txtShortName.Text = ""
        txtFullName.Text = ""
        txtDescription.Text = ""
    End Sub

    Private Sub EditUSer()
        lblHeader.Text = "Edit Course"
        GetSVTable()
        Dim Programid As Integer
        Programid = GetSVTableValue(Of Integer)("programid")
        Dim CourseId As Integer
        CourseId = GetSVTableValue(Of Integer)("CourseId")

        'Dim ProjectID As Integer = Convert.ToInt32(Request.QueryString("ProjectID"))
        Dim dtUserlInfo As DataTable = GetCourseInfo(CourseId)

        If Not IsNothing(dtUserlInfo) AndAlso dtUserlInfo.Rows.Count > 0 Then
            With dtUserlInfo
                txtShortName.Text = .Rows(0)("shorttitle").ToString()
                txtFullName.Text = .Rows(0)("longtitle").ToString()
                txtDescription.Text = .Rows(0)("catdesc").ToString()
                txttopics.Text = .Rows(0)("topics").ToString()
                txtDiscussion.Text = .Rows(0)("discussion").ToString()
                txtYear.Text = .Rows(0)("yearinprog").ToString()
                txtSeq.Text = .Rows(0)("sequencenum").ToString()
            End With
        End If

    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        GetSVTable()
        Dim mode As String = Request.QueryString("mode")
        paramContainer.AddParameter("mode", mode, False)
        paramContainer.AddParameter("shorttitle", txtShortName)
        Dim programid As Integer = Convert.ToInt16(GetSVTableValue(Of Integer)("programid"))
        paramContainer.AddParameter("progid", CStr(programid), False)
        paramContainer.AddParameter("longtitle", txtFullName)
        paramContainer.AddParameter("catdesc", txtDescription)
        paramContainer.AddParameter("topics", txttopics)
        paramContainer.AddParameter("discussion", txtDescription)
        paramContainer.AddParameter("yearinprog", txtYear)
        paramContainer.AddParameter("sequencenum", txtSeq)
        Dim CourseId As Integer = Convert.ToInt16(GetSVTableValue(Of Integer)("courseid"))
        paramContainer.AddParameter("courseid", CStr(CourseId), False)
        Return MyBase.CreateParameters()
    End Function

#End Region

#Region "Local Functions"
    Private Function GetCourseInfo(ByVal CourseId As Integer) As DataTable
        Dim dtUserlInfo As DataTable
        Dim oUser As New DataAccess.daCourse
        Dim con As String = GetConnectionString("connectionString")
        dtUserlInfo = oUser.GetCourse(CourseId, con)
        If Not oUser.TransactionSuccessful Then
            dtUserlInfo = Nothing
        End If
        Return dtUserlInfo
    End Function


    Private Shared Function InsertCourse(ByVal shorttitle As String, ByVal progid As Integer, ByVal longtitle As String, ByVal catdesc As String, ByVal topics As String, ByVal discussion As String, ByVal yearinprog As String, ByVal sequencenum As Integer) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("connectionString")
        Dim oUser As New DataAccess.daCourse
        oUser.InsertCourse(shorttitle, progid, longtitle, catdesc, topics, discussion, yearinprog, sequencenum, con)
        If oUser.TransactionSuccessful Then
            strStatus = "Course added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Shared Function UpdateCourse(ByVal CourseId As Integer, ByVal shorttitle As String, ByVal progid As Integer, ByVal longtitle As String, ByVal catdesc As String, ByVal topics As String, ByVal discussion As String, ByVal yearinprog As String, ByVal sequencenum As Integer) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("connectionString")
        Dim oUser As New DataAccess.daCourse
        oUser.UpdateCourse(CourseId, shorttitle, progid, longtitle, catdesc, topics, discussion, yearinprog, sequencenum, con)
        If oUser.TransactionSuccessful Then
            strStatus = "Course added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function
#End Region

#Region "Click Event Handlers for Page Controls"

#End Region

#Region "Local WebService Methods"
    <Services.WebMethod()> _
    Public Shared Function wsAddEditCourse(ByVal mode As String, ByVal shorttitle As String, ByVal progid As Integer, ByVal longtitle As String, ByVal catdesc As String, ByVal topics As String, ByVal discussion As String, ByVal yearinprog As String, ByVal sequencenum As Integer, ByVal CourseId As Integer) As String
        Dim strmsg As String = ""

        If mode = "add" Then
            strmsg = InsertCourse(shorttitle, progid, longtitle, catdesc, topics, discussion, yearinprog, sequencenum)

        ElseIf mode = "edit" Then
            strmsg = UpdateCourse(CourseId, shorttitle, progid, longtitle, catdesc, topics, discussion, yearinprog, sequencenum)
        Else
            strmsg = "No Mode was Selected"
        End If
        Return strmsg
    #End Function
#End Region
End Class
