Imports JSIM.Bases.SVTable
Public Class Skills
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
        Dim skillclassid As Integer
        skillclassid = GetSVTableValue(Of Integer)("skillclassid")
        If skillclassid = 0 Then
            skillclassid = Convert.ToInt32(Session("skillclassid"))
        End If

        If IsNothing(skillclassid) Then
            Response.Redirect("Login.aspx")
        End If

        If Not IsPostBack Then
            setform()
        End If
    End Sub

    Private Sub setform()

        Dim skillclassid As Integer
        Dim con As String = GetConnectionString("ConnectionString")
        Dim oProgram As New DataAccessTier.daProgram
        skillclassid = GetSVTableValue(Of Integer)("skillclassid")
        If skillclassid = 0 Then
            skillclassid = Convert.ToInt32(Session("skillclassid"))
        End If

        Dim dtUserSkillset As DataTable = oProgram.getskillsbyskillclassnum(skillclassid, con) 'need to pass a parameter of ProgramID, to call
        If Not IsNothing(dtUserSkillset) AndAlso dtUserSkillset.Rows.Count > 0 Then
            UserProfile = dtUserSkillset
            CreateSVTable(con)
            ProjectsGridView.DataSource = dtUserSkillset
            ProjectsGridView.DataBind()
        Else
            ProjectsGridView.DataSource = Nothing
            ProjectsGridView.DataBind()
        End If
    End Sub


    Protected Sub ProjectsGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ProjectsGridView.SelectedIndexChanged
        Dim skillsnum As Integer = CInt(ProjectsGridView.SelectedValue)
        InsertSVTableValue(Of Integer)("skillsnum", skillsnum)
        Session("skillsnum") = skillsnum.ToString()
    End Sub
End Class