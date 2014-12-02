Imports JSIM.Bases.SVTable
Public Class ListCourseOutcome
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ProgramidSv As Integer
        'ProgramidSv = GetSVTableValue(Of Integer)("Programid")
        ProgramidSv = CInt(Session("courseid"))
        'ProgramidSv = 1
        If IsNothing(ProgramidSv) Or ProgramidSv = 0 Then
            Response.Redirect("Loginpage.aspx")
        End If
        If Not IsPostBack Then
            setform()
        End If
    End Sub

    Private Sub setform()

        Dim CourseId As Integer
        CourseId = CInt(Session("courseid"))
        'If peopleid > 0 Then
        Dim con As String = GetConnectionString("connectionString")
        'New Instance for creating an object
        Dim oUser As New DataAccessTier.daCourse
        'accessing Validateuser 
        'Checking if user exists in database

        Dim dtCourseOutcome As DataTable = oUser.GetCourseOutcomesList(CourseId, con)
        If Not IsNothing(dtCourseOutcome) AndAlso dtCourseOutcome.Rows.Count > 0 Then
            UserProfile = dtCourseOutcome
            'Creating SVtable
            CreateSVTable(con)
            gvCourseOutcome.DataSource = dtCourseOutcome
            gvCourseOutcome.DataBind()
        Else
            gvCourseOutcome.DataSource = Nothing
            gvCourseOutcome.DataBind()
        End If
    End Sub

    Protected Sub gvCourseOutcome_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvCourseOutcome.SelectedIndexChanged
        Dim index As Integer = gvCourseOutcome.SelectedIndex
        Dim crsoutcomesid As Integer = CInt(gvCourseOutcome.DataKeys(index).Value.ToString())
        Session("crsoutcomesid") = crsoutcomesid
    End Sub
End Class