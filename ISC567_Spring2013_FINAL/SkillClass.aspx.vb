Imports JSIM.Bases.SVTable
Public Class SkillClass
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim userIDsv As Integer
        userIDsv = GetSVTableValue(Of Integer)("userID")

        If IsNothing(userIDsv) Then
            Response.Redirect("Login.aspx")
        End If
        setform()

        ' End If
    End Sub

    Private Sub setform()

        Dim ProgramId As Integer
        Dim con As String = GetConnectionString("ConnectionString")
        'New Instance for creating an object
        Dim oProgram As New DataAccessTier.daProgram
        ProgramId = CInt(Session("selectedProgramId"))
        'accessing Validateuser 
        'Checking if user exists in database
        Dim dtUserSkillset As DataTable = oProgram.ListSkillClass(ProgramId, con) 'need to pass a parameter of ProgramID, to call
        If Not IsNothing(dtUserSkillset) AndAlso dtUserSkillset.Rows.Count > 0 Then
            UserProfile = dtUserSkillset
            'Creating SVtable
            CreateSVTable(con)
            ProjectsGridView.DataSource = dtUserSkillset
            ProjectsGridView.DataBind()
        Else
            ProjectsGridView.DataSource = Nothing
            ProjectsGridView.DataBind()
        End If
    End Sub

    Protected Sub ProjectsGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ProjectsGridView.SelectedIndexChanged
        Dim con As String = GetConnectionString("ConnectionString")
        'CreateSVTable(con)
        'Dim row As Integer = ProjectsGridView.SelectedIndex
        'Dim skillclassid As Integer = Convert.ToInt32(ProjectsGridView.DataKeys(row).Value.ToString())
        'Dim ls As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblSkillsclassnum"), Label)
        'Dim skillsclassnum As Integer = Convert.ToInt32(ls.Text)
        'InsertSVTableValue(Of Integer)("skillsclassnum", skillsclassnum)
        'InsertSVTableValue(Of Integer)("skillclassid", skillclassid)
        Dim skillclassid As String = ProjectsGridView.SelectedValue.ToString()
        Session.Add("skillclassid", skillclassid)
        Dim skillsnum As String = ProjectsGridView.SelectedValue.ToString()
        Session.Add("skillsnum", skillsnum)
        Dim skillsclassnum As String = ProjectsGridView.SelectedValue.ToString()
        Session.Add("skillsclassnum", skillsclassnum)
        Dim skillsname As String = ProjectsGridView.SelectedValue.ToString()
        Session.Add("skillsname", skillsname)
    End Sub


End Class