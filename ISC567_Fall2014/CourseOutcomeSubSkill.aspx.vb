Imports JSIM.Bases.SVTable
Public Class ProgramOutcomeSubSkill
    Inherits JSIM.Bases.BaseClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNothing(Session("crsoutcomesid")) AndAlso IsNothing(Session("skillsnum")) Then
            Response.Redirect("Login.aspx")
        End If

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

    Private Function GetCOID() As Integer
        ' The hackiest of hacks, the kludgiest of kludges to get the page working from subskill before the demo.        
        Dim COID As Integer = -1
        If Not IsNothing(Session("crsoutcomesid")) Then COID = Convert.ToInt32(Session("crsoutcomesid").ToString())
        Return COID
    End Function

    ''Populates ProgramOutcome to label
    Private Sub PopulateProgramOutCome()
        Dim dt As DataTable = GetCourseOutcomeShortlist()

        ' Bail out if we didn't receive any records
        If IsNothing(dt) Or dt.Rows.Count <= 0 Then
            ddlOutcome.DataSource = Nothing
            ddlOutcome.DataBind()
            Exit Sub
        End If

        ' Display our dataset and select the value provided in the session
        Dim dv As DataView = dt.DefaultView
        ddlOutcome.DataSource = dv
        ddlOutcome.DataBind()

        Dim SelectedID As String = GetCOID().ToString()
        If SelectedID <> "-1" Then
            ddlOutcome.SelectedValue = SelectedID
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
        Dim prgoutcomesid As Integer = GetCOID()
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
            strMssg = String.Format("Program {0} Subskill {1} Toggled", ProgramOutomeID, subSkillId)
        Else
            strMssg = "Error: " & oRole.ErrorMessage
        End If
        Return strMssg
    End Function
#End Region

#Region "Local Webservice Methods  "
    <Services.WebMethod()> _
    Public Shared Function wsToggleSubskill(ByVal checked As Boolean, ByVal subSkillId As Integer, ByVal programOutomeID As Integer) As String
        Return ToggleSubskill(programOutomeID, subSkillId)
    End Function
#End Region

    Private Sub ddlOutcome_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOutcome.SelectedIndexChanged
        Dim SelectedID As String = ddlOutcome.SelectedValue.ToString()
        Session("crsoutcomesid") = SelectedID
        PopulateAssignedSubskills()
    End Sub
End Class