Imports JSIM.Bases.SVTable
Public Class Skills
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
        Dim skillclassid As Integer
        skillclassid = GetSVTableValue(Of Integer)("skillsclassnum")
        'skillclassid = 1
        If IsNothing(skillclassid) Then
            Response.Redirect("Login.aspx")
        End If

        If Not IsPostBack Then
            setform()
        End If

        ' End If
    End Sub

    Private Sub setform()

        Dim skillsclassnum As Integer
        Dim con As String = GetConnectionString("ConnectionString")
        'New Instance for creating an object
        Dim oProgram As New DataAccessTier.daProgram
        skillsclassnum = GetSVTableValue(Of Integer)("skillclassid")
        'CInt(Session("skillsclassnum"))
        'accessing Validateuser 
        'Checking if user exists in database
        Dim dtUserSkillset As DataTable = oProgram.getskillsbyskillclassnum(skillsclassnum, con) 'need to pass a parameter of ProgramID, to call
        If Not IsNothing(dtUserSkillset) AndAlso dtUserSkillset.Rows.Count > 0 Then
            UserProfile = dtUserSkillset
            'Creating SVtable
            'Dim success As Boolean = CreateSVTable(con)
            'Debug.Print(CStr(success))
            CreateSVTable(con)
            ProjectsGridView.DataSource = dtUserSkillset
            ProjectsGridView.DataBind()
        Else
            ProjectsGridView.DataSource = Nothing
            ProjectsGridView.DataBind()
        End If
    End Sub


    Protected Sub ProjectsGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ProjectsGridView.SelectedIndexChanged
        'Dim row As Integer = ProjectsGridView.SelectedIndex
        'Dim skillsid As Integer = Convert.ToInt32(ProjectsGridView.DataKeys(row).Value.ToString())
        'Dim ls As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblskillsclassnum"), Label)
        'Dim skillsclassnum As Integer = Convert.ToInt32(ls.Text)
        'Dim ls1 As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblskillsnum"), Label)
        'Dim skillsnum As Integer = Convert.ToInt32(ls1.Text)
        'InsertSVTableValue(Of Integer)("skillsclassnum", skillsclassnum)
        'InsertSVTableValue(Of Integer)("skillsnum", skillsnum)
        'InsertSVTableValue(Of Integer)("skillsid", skillsid)
        'Dim skillsid As Integer = CInt(ProjectsGridView.SelectedValue)

        Dim skillsId As String = ProjectsGridView.SelectedValue.ToString()
        'InsertSVTableValue(Of Integer)("skillsid", skillsId)

        Session.Add("skillsid", skillsId)
        'Dim selectedSubSkillId As String = ProjectsGridView.SelectedValue.ToString()
        'Session.Add("selectedSubSkillId", selectedSubSkillId)
        'Dim skillclassid As String = ProjectsGridView.SelectedValue.ToString()
        'Session.Add("skillclassid", skillclassid)
        'Dim skillsclassnum As String = ProjectsGridView.SelectedValue.ToString()
        'Session.Add("skillsclassnum", skillsclassnum)
        'Dim skillsname As String = ProjectsGridView.SelectedValue.ToString()
        'Session.Add("skillsname", skillsname)
        'Dim skillsnum As String = ProjectsGridView.SelectedValue.ToString()
        'Session.Add("skillsnum", skillsnum)


    End Sub
End Class