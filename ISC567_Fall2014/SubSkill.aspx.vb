Imports JSIM.Bases.SVTable
Public Class SubSkill
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim skillclassid, skillsid As Integer
        skillclassid = GetSVTableValue(Of Integer)("skillclassid")
        skillsid = GetSVTableValue(Of Integer)("skillsid")
        'subskillid = 1
        If IsNothing(skillsid) Then
            Response.Redirect("Login.aspx")
        End If
        setform()

        ' End If
    End Sub

    Private Sub Setform()

        Dim skillsnum As Integer
        Dim con As String = GetConnectionString("ConnectionString")
        'New Instance for creating an object
        Dim oProgram As New DataAccessTier.daProgram
        skillsnum = CInt(Session("skillsnum"))
        'accessing Validateuser 
        'Checking if user exists in database
        Dim dtUserSkillset As DataTable = oProgram.GetSubSkillBySkillClassNum(skillsnum, con) 'need to pass a parameter of ProgramID, to call
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
        Dim row As Integer = ProjectsGridView.SelectedIndex
        Dim subskillid As Integer = Convert.ToInt32(ProjectsGridView.DataKeys(row).Value.ToString())
        'Dim ls As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblskillsclassnum"), Label)
        'Dim skillsclassnum As Integer = Convert.ToInt32(ls.Text)
        'Dim ls1 As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblskillsnum"), Label)
        'Dim skillsnum As Integer = Convert.ToInt32(ls1.Text)
        'Dim ls2 As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblsubskillnum"), Label)
        'Dim subskillnum As Integer = Convert.ToInt32(ls2.Text)
        ''InsertSVTableValue(Of Integer)("skillsclassnum", skillsclassnum)
        ''InsertSVTableValue(Of Integer)("skillsnum", skillsnum)
        ''InsertSVTableValue(Of Integer)("skillsclassnum", skillsclassnum)
        ''InsertSVTableValue(Of Integer)("subskillid", subskillid)

        'Dim subskillid As String = ProjectsGridView.SelectedValue.ToString()
        Session.Add("subskillid", subskillid)
    End Sub

End Class