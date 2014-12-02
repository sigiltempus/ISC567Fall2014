Imports JSIM.Bases.SVTable
Public Class ProgramOutcomeSubSkill
    Inherits JSIM.Bases.BaseClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim prgoutcomesid As Integer
            prgoutcomesid = CInt(Session("crsoutcomesid"))
            SetForm()
        End If

    End Sub

#Region "Local Methods  "
    ''Intial Loading Operations
    Private Sub SetForm()
        'Displaying Error Message
        lblStatus.Text = ""
        'Setting Color to label
        lblStatus.ForeColor = Drawing.Color.Blue
        'Populating dropDownList
        PopulateProgramOutCome()
        'Populating Gridview
        PopulateAssignedSubskills()
    End Sub

    ''Populates ProgramOutcome to label
    Private Sub PopulateProgramOutCome()
        Dim dtProgram As DataTable = GetCourseOutcomeShortlist()
        If Not IsNothing(dtProgram) AndAlso dtProgram.Rows.Count > 0 Then
            With dtProgram
                lblProgOutcome.Text = lblProgOutcome.Text + " " + .Rows(0)("crsshortoutcome").ToString() + "  Choose SubSkill"
            End With
        Else
            lblStatus.Text = " "
            lblStatus.ForeColor = Drawing.Color.Red
        End If
    End Sub

    ''Get ProgramOutcome from Database
    Private Function GetCourseOutcomeShortlist() As DataTable
        Dim dtProgram As DataTable
        Dim cn As String = GetConnectionString("ConnectionString")
        Dim oRole As New DataAccessTier.daCourse
        dtProgram = oRole.GetCourseOutcomeShortlist(cn)
        If Not oRole.TransactionSuccessful Then
            dtProgram = Nothing
        End If
        Return dtProgram
    End Function

    ''Populates Gridview
    Private Sub PopulateAssignedSubskills()
        'creating the parameters
        gvSubSkill.Parameters = CreateParameters()
        Dim prgoutcomesid As Integer = CInt(Session("crsoutcomesid"))
        If Not IsNothing(Session("crsoutcomesid")) AndAlso CInt(Session("crsoutcomesid")) > 0 Then
            Dim dtUserAssignedRoles As DataTable = GetAssignedSubskill(CInt(Session("crsoutcomesid")))
            Dim dv As DataView = dtUserAssignedRoles.DefaultView
            Try
                gvSubSkill.DataSource = dv
                gvSubSkill.DataBind()
            Catch ex As Exception
                lblStatus.Text = "DataBindingError" & ex.Message
                lblStatus.ForeColor = Drawing.Color.Red
            End Try

        Else
            gvSubSkill.DataSource = Nothing
            gvSubSkill.DataBind()
        End If

    End Sub

    ''Creates Parameters
    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        'Gets prgoutcomesid from dropDownlist
        Dim prgoutcomesid As Integer = CInt(Session("crsoutcomesid"))
        paramContainer.AddParameter("crsoutcomesid", CStr(prgoutcomesid), False)
        Return MyBase.CreateParameters()
    End Function
#End Region

#Region "Local Functions  "
    'Get a list of Subskills with assigned and unassigned ProgramOutcomes
    Private Function GetAssignedSubskill(ByVal prgoutcomesid As Integer) As DataTable
        Dim dtUsers As DataTable
        Dim cn As String = GetConnectionString("ConnectionString")
        Dim oRole As New DataAccessTier.daProgram
        dtUsers = oRole.GetProgramoutcomesforsubskill(prgoutcomesid, cn)
        If Not oRole.TransactionSuccessful Then
            dtUsers = Nothing
        End If
        Return dtUsers
    End Function

    ' Toggles a specified subskill to ProgramOutcome
    Private Shared Function ToggleSubskill(ByVal ProgramOutomeID As Integer, ByVal subSkillId As Integer) As String
        Dim strMssg As String = ""
        Dim cn As String = GetConnectionString("ConnectionString")
        Dim oRole As New DataAccessTier.daProgram
        oRole.ToggleSubskillInCourseOutcome(ProgramOutomeID, subSkillId, cn)
        If oRole.TransactionSuccessful Then
            strMssg = "Subskill Toggled"
        Else
            strMssg = "Error: " & oRole.ErrorMessage
        End If
        Return strMssg
    End Function
#End Region

#Region "Click Event handlers For Page Controls  "

#End Region

#Region "Click Event Handlers For GridView Controls  "
    Protected Sub gvSubSkill_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvSubSkill.SelectedIndexChanged
        PopulateAssignedSubskills()
    End Sub

    Protected Sub gvSubSkill_CheckBoxClick(sender As Object, e As EventArgs) Handles gvSubSkill.CheckBoxClick
        PopulateAssignedSubskills()
    End Sub

    Protected Sub gvSubSkill_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvSubSkill.RowCommand
        PopulateAssignedSubskills()
    End Sub
#End Region

#Region "Local Webservice Methods  "
    <Services.WebMethod()> _
    Public Shared Function wsToggleSubskill(ByVal checked As Boolean, ByVal subSkillId As Integer, ByVal programOutomeID As Integer) As String
        Dim strMssg As String = ""
        Dim progOutcomeId As Integer = CInt(programOutomeID)
        strMssg = ToggleSubskill(progOutcomeId, subSkillId)
        Return strMssg
    End Function
#End Region

End Class