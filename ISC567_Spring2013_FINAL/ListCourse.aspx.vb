Imports JSIM.Bases.SVTable
Public Class ListCourse
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim PeopleIDsv As Integer
        PeopleIDsv = GetSVTableValue(Of Integer)("Peopleid")

        If IsNothing(PeopleIDsv) Then
            Response.Redirect("Loginpage.aspx")
        End If

        If Not IsPostBack Then
            setform()
        End If

    End Sub

    Private Sub setform()
        Dim ProgramId As Integer
        ProgramId = GetSVTableValue(Of Integer)("programId")
        PopulateProgram()
        'If peopleid > 0 Then
        Dim cn As String = GetConnectionString("connectionString")
        'New Instance for creating an object
        Dim oUser As New DataAccess.daCourse
        'accessing Validateuser 
        'Checking if user exists in database
        Dim dtCourse As DataTable = oUser.GetCourseList(ProgramId, cn)
        If Not IsNothing(dtCourse) AndAlso dtCourse.Rows.Count > 0 Then
            gvCourse.DataSource = dtCourse
            gvCourse.DataBind()
        Else
            gvCourse.DataSource = Nothing
            gvCourse.DataBind()
        End If
    End Sub


    Private Sub PopulateProgram()
        Dim dtProgram As DataTable = GetParticipatingSociety()
        If Not IsNothing(dtProgram) AndAlso dtProgram.Rows.Count > 0 Then
            With dtProgram
                lblMesage.Text = lblMesage.Text + " " + .Rows(0)("longtitle").ToString()
            End With
        Else

        End If
    End Sub

    Private Function GetParticipatingSociety() As DataTable
        Dim dtRoleList As DataTable
        Dim ProgramId As Integer = GetSVTableValue(Of Integer)("programId")
        Dim cn As String = GetConnectionString("connectionString")
        Dim oRole As New DataAccess.daCourse
        dtRoleList = oRole.GetCourseProgram(ProgramId, cn)
        If Not oRole.TransactionSuccessful Then
            dtRoleList = Nothing
        End If
        Return dtRoleList
    End Function

    Protected Sub gvCourse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvCourse.SelectedIndexChanged
        Dim index As Integer = gvCourse.SelectedIndex
        Dim CourseId As Integer = CInt(gvCourse.DataKeys(index).Value.ToString())
        Dim s As Boolean = InsertSVTableValue(Of Integer)("courseid", CourseId)
        Dim lbl As Label = DirectCast(gvCourse.Rows(index).FindControl("lblPrgsequence"), Label)
        Session("CrsShorttitle") = lbl.Text
        Session("courseid") = CourseId




    End Sub
End Class