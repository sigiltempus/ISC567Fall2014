Imports JSIM.Bases.SVTable
Imports DataAccessTier.daProgram

Public Class ListProgramOutCome
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim PeopleIDsv As Integer
        'PeopleIDsv = GetSVTableValue(Of Integer)("PeopleID")
        PeopleIDsv = CInt(Session("selectedProgramId"))

        If IsNothing(PeopleIDsv) Then
            Response.Redirect("Loginpage.aspx")
        End If
        If Not IsPostBack Then
            setform()

        End If
    End Sub


    Private Sub setform()
        PopulateProgram()
        Dim con As String = GetConnectionString("ConnectionString")
        'New Instance for creating an object
        Dim oUser As New DataAccessTier.daProgram
        'accessing Validateuser 
        'Checking if user exists in database
        Dim ProgramId As Integer = CInt(Session("selectedProgramId"))
        Dim dtProgramOutcome As DataTable = oUser.GetProgramOutcomesList(ProgramId, con)
        If Not IsNothing(dtProgramOutcome) AndAlso dtProgramOutcome.Rows.Count > 0 Then
            UserProfile = dtProgramOutcome
            'Creating SVtable
            CreateSVTable(con)
            gvProgramOutcome.DataSource = dtProgramOutcome
            gvProgramOutcome.DataBind()
        Else
            gvProgramOutcome.DataSource = Nothing
            gvProgramOutcome.DataBind()
        End If
    End Sub


    Private Sub PopulateProgram()
        Dim dtProgram As DataTable = GetProgram()
        If Not IsNothing(dtProgram) AndAlso dtProgram.Rows.Count > 0 Then
            With dtProgram
                lblRole.Text = lblRole.Text + " " + .Rows(0)("longname").ToString()
            End With
        Else
            'lblStatus.Text = "No Programs were found,an Error Occured"
            'lblStatus.ForeColor = Drawing.Color.Red
        End If
    End Sub


    Private Function GetProgram() As DataTable
        Dim dtRoleList As DataTable

        'Dim ProgramId As Integer = GetSVTableValue(Of Integer)("ProgramId")
        Dim ProgramId As Integer = CInt(Session("selectedProgramId"))
        Dim cn As String = GetConnectionString("connectionString")
        Dim oRole As New DataAccessTier.daProgram
        dtRoleList = oRole.GetProgram(ProgramId, cn)
        If Not oRole.TransactionSuccessful Then
            dtRoleList = Nothing
        End If
        Return dtRoleList
    End Function

    Protected Sub gvProgramOutcome_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvProgramOutcome.SelectedIndexChanged
        Dim index As Integer = gvProgramOutcome.SelectedIndex
        Dim prgoutcomesid As Integer = CInt(gvProgramOutcome.DataKeys(index).Value)
        Dim s As Boolean = InsertSVTableValue(Of Integer)("prgoutcomesid", prgoutcomesid)
        Session.Add("prgoutcomesid ", prgoutcomesid)
        ' Dim lbl As Label '= DirectCast(gvProgramOutcome.Rows(index).FindControl("prgoutcomesid"), Label)
        Session("prgoutcomesid ") = prgoutcomesid
    End Sub


    Protected Sub btnProgramSubSkill_Click(sender As Object, e As EventArgs) Handles btnProgramSubSkill.Click
        Dim index As Integer = gvProgramOutcome.SelectedIndex
        Dim prgoutcomesid As Integer = CInt(gvProgramOutcome.DataKeys(index).Value)
        Dim s As Boolean = InsertSVTableValue(Of Integer)("prgoutcomesid ", prgoutcomesid)
        'Dim prgsequencenum = Session("prgsequencenum");
        Session.Add("prgoutcomesid", prgoutcomesid)
        ' Dim lbl As Label = DirectCast(gvProgramOutcome.Rows(index).FindControl("lblPrgsequence"), Label)
        Session("prgoutcomesid") = prgoutcomesid
    End Sub
End Class