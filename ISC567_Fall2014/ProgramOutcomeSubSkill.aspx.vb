Imports JSIM.Bases.SVTable
Public Class ProgramOutcomeSubSkill
    Inherits JSIM.Bases.BaseClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim prgoutcomesid As Integer
            prgoutcomesid = CInt(Session("prgoutcomesid "))
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
        Dim dtProgram As DataTable = GetProgramOutCome()
        If Not IsNothing(dtProgram) AndAlso dtProgram.Rows.Count > 0 Then
            With dtProgram
                lblProgOutcome.Text = lblProgOutcome.Text + " " + .Rows(0)("prgshortoutcome").ToString() + "  Choose SubSkill"
            End With
        Else
            lblStatus.Text = " "
            lblStatus.ForeColor = Drawing.Color.Red
        End If
    End Sub

    ''Get ProgramOutcome from Database
    Private Function GetProgramOutCome() As DataTable

       Dim dtProgram As DataTable
        ' Dim prgoutcomesid As Integer = GetSVTableValue(Of Integer)("prgoutcomesid")
        Dim prgoutcomesid As Integer = CInt(Session("prgoutcomesid "))
        'Dim index As Integer = gvProgramOutcome.SelectedIndex
        'Dim prgoutcomesid As Integer = CInt(gvProgramOutcome.DataKeys(index).Value)
        ' Dim prgoutcomesid As Integer = 1
        Dim cn As String = GetConnectionString("ConnectionString")
        Dim oRole As New DataAccessTier.daProgram
        dtProgram = oRole.GetProgramOutcome(CInt(prgoutcomesid), cn)
        If Not oRole.TransactionSuccessful Then
            dtProgram = Nothing
        End If
        Return dtProgram
    End Function

    ''Populates Gridview
    Private Sub PopulateAssignedSubskills()
        'creating the parameters
        gvSubSkill.Parameters = CreateParameters()
        Dim prgoutcomesid As Integer = CInt(Session("prgoutcomesid "))
        If Not IsNothing(Session("prgoutcomesid ")) AndAlso CInt(Session("prgoutcomesid ")) > 0 Then
            Dim dtUserAssignedRoles As DataTable = GetAssignedSubskill(CInt(Session("prgoutcomesid ")))
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
        Dim prgoutcomesid As Integer = CInt(Session("prgoutcomesid "))
        paramContainer.AddParameter("prgoutcomesid", CStr(prgoutcomesid), False)
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

    'Assigns a specified subskill to ProgramOutcome
    Private Shared Function AssignSubskill(ByVal ProgramOutomeID As Integer, ByVal subSkillId As Integer) As String
        Dim strMssg As String = ""
        Dim cn As String = GetConnectionString("ConnectionString")
        Dim oRole As New DataAccessTier.daProgram
        oRole.InsertProgrOuctomeSubskill(ProgramOutomeID, subSkillId, cn)
        If oRole.TransactionSuccessful Then
            strMssg = "Subskill was successfully assigned toto the Program OutCome "
        Else
            strMssg = "An error occured while trying to assign the role:" & oRole.ErrorMessage
        End If
        Return strMssg
    End Function
    'Unassigns a selected subskill to ProgramOutcome
    Private Shared Function UnAssignSubskill(ByVal ProgramOutcomeId As Integer, ByVal subSkillId As Integer) As String
        Dim strMssg As String = ""
        Dim cn As String = GetConnectionString("ConnectionString")
        Dim oRole As New DataAccessTier.daProgram
        oRole.DeleteProgrOuctomeSubskill(ProgramOutcomeId, subSkillId, cn)
        If oRole.TransactionSuccessful Then
            strMssg = "Subskill was successfully unassigned fromto the Program OutCome"
        Else
            strMssg = "An error occured while trying to unassign the role:" & oRole.ErrorMessage
        End If
        Return strMssg
    End Function
#End Region

#Region "Click Event handlers For Page Controls  "

#End Region

#Region "Click Event Handlers For GridView Controls  "

#End Region

#Region "Local Webservice Methods  "
    <Services.WebMethod()> _
    Public Shared Function wsAssignSubskill(ByVal checked As Boolean, ByVal subSkillId As Integer, ByVal programOutomeID As String) As String
        Dim strMssg As String = ""
        Dim progOutcomeId As Integer = CInt(programOutomeID)
        If checked Then
            strMssg = AssignSubskill(progOutcomeId, subSkillId) 'subskillcomb)
        Else
            strMssg = "Assign method was called but checked value was not set to true"
        End If
        Return strMssg
    End Function

    <Services.WebMethod()> _
    Public Shared Function wsUnAssignSubskill(ByVal checked As Boolean, ByVal programOutomeID As Integer, ByVal subskillcomb As Integer) As String
        Dim strMssg As String = ""
        Dim progOutcomeId As Integer = CInt(programOutomeID)
        If Not checked Then
            strMssg = UnAssignSubskill(progOutcomeId, subskillcomb)
        Else
            strMssg = "Unassign method was called but checked value was not set to false"
        End If
        Return strMssg
    End Function
#End Region






    'Protected Sub gvSubSkill_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    Dim s As Boolean
    '    Dim k As Integer = gvSubSkill.SelectedIndex
    '    s = True
    '    'Dim strng As String = "C"
    '    'Dim rng As String = "C"
    '    'wsAssignSubskill(s, rng, strng)

    '    '  s = CheckBox.Checked
    'End Sub

    'Protected Sub gvSubSkill_CheckBoxClick(sender As Object, e As EventArgs)
    '    'TODO
    '    Dim a As String = "I am here"
    'End Sub

    ''Protected Sub gvSubSkill_SelectedIndexChanged(sender As Object, e As GridViewSelectEventArgs)
    ''    Dim s As Boolean
    ''    Dim k As Integer = gvSubSkill.SelectedIndex
    ''    s = True
    ''    'Dim strng As String = "C"
    ''    'Dim rng As String = "C"
    ''    'wsAssignSubskill(s, rng, strng)

    ''End Sub

    'Protected Sub gvSubSkill_SelectedIndexChanged1(sender As Object, e As EventArgs)
    '    Dim s As Boolean
    '    '    Dim k As Integer = gvSubSkill.SelectedIndex
    '    '    s = True
    '    '    'Dim strng As String = "C"
    'End Sub
End Class