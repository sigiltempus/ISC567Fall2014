Imports JSIM.Bases.SVTable
Imports DataAccessTier.daProgram

Public Class AddEditProgramOutcome
    Inherits JSIM.Bases.BaseClass
    Dim mode As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ProjectidSv As Integer
        ' ProjectidSv = GetSVTableValue(Of Integer)("Programid")
        ProjectidSv = 1
        If IsNothing(ProjectidSv) Then
            Response.Redirect("Loginpage.aspx")
        End If

        If Not IsPostBack Then
            SetFrom()
        End If
    End Sub

#Region "Local Methods"
    Private Sub SetFrom()
        Dim mode As String = Request.QueryString("mode")
        PopulatePrograms()
        If mode = "add" Then
            AddNew()
        Else
            EditUSer()
        End If
        btnSave.Parameters = CreateParameters()
    End Sub

    Private Sub AddNew()
        dgFrame.Text = "Add Program Outcome"
        ddlProgram.SelectedIndex = -1
        txtPrgoutcom.Text = ""
        txtShortoutcome.Text = ""
    End Sub

    Private Sub PopulatePrograms()
        Dim dtRoleList As DataTable = GetPrograms()
        If Not IsNothing(dtRoleList) AndAlso dtRoleList.Rows.Count > 0 Then
            With ddlProgram
                .DataSource = dtRoleList
                .DataValueField = "programid"
                .DataTextField = "Shortname"
                .DataBind()
                .Items.Insert(0, New ListItem("--Select a Program--", "-1"))
                .SelectedIndex = 0
            End With
        End If
    End Sub

    Private Function GetPrograms() As DataTable
        Dim dtRoleList As DataTable
        Dim cn As String = GetConnectionString("ConnectionString")
        Dim oRole As New DataAccessTier.daProgram
        dtRoleList = oRole.GetProgramddl(cn)
        If Not oRole.TransactionSuccessful Then
            dtRoleList = Nothing
        End If
        ' txtPrgoutcom.Text=dtRoleList.
        Return dtRoleList
    End Function

    Private Sub EditUSer()
        dgFrame.Text = "Edit Program OutCome"
        GetSVTable()
        Dim prgoutcomesid As Integer = GetSVTableValue(Of Integer)("prgoutcomesid")
        Dim dtUserlInfo As DataTable = GetProgramOutcome(prgoutcomesid)

        If Not IsNothing(dtUserlInfo) AndAlso dtUserlInfo.Rows.Count > 0 Then
            With dtUserlInfo
                txtShortoutcome.Text = .Rows(0)("prgshortoutcome").ToString()
                txtPrgoutcom.Text = .Rows(0)("prgoutcometext").ToString()
                txtProgramseq.Text = .Rows(0)("prgsequencenum").ToString()
                'ddlProgram.SelectedValue = .Rows(0)("programid").ToString()
            End With
        End If
    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        Dim mode As String = Request.QueryString("mode")
        paramContainer.AddParameter("mode", mode, False)
        paramContainer.AddParameter("programid", ddlProgram)
        paramContainer.AddParameter("prgoutcometext", txtPrgoutcom)
        paramContainer.AddParameter("prgshortoutcome", txtShortoutcome)
        paramContainer.AddParameter("prgsequencenum", txtProgramseq)
        Dim prgoutcomesid As Integer = Convert.ToInt16(GetSVTableValue(Of Integer)("prgoutcomesid"))
        paramContainer.AddParameter("ProgramOutcomeid", CStr(prgoutcomesid), False)
        Return MyBase.CreateParameters()
    End Function

#End Region

#Region "Local Functions"
    Private Function GetProgramOutcome(ByVal prgoutcomesid As Integer) As DataTable
        Dim dtUserlInfo As DataTable
        Dim cn As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        'dtUserlInfo = oUser.Getproglist(CInt((Session("prgoutcomesid"))), cn)
        dtUserlInfo = oUser.Getproglist(CInt((Session("prgoutcomesid "))), cn)
        If Not oUser.TransactionSuccessful Then
            dtUserlInfo = Nothing
        End If
        Return dtUserlInfo
    End Function


    Private Shared Function InsertProgramoutcome(ByVal programid As Integer, ByVal prgoutcometext As String, ByVal prgshortoutcome As String, ByVal prgsequencenum As String, ByVal con As string ) As String
        Dim strStatus As String = ""
        'Dim con As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.InsertProgramOutcome(programid, prgoutcometext, prgshortoutcome, prgsequencenum, con)
        If oUser.TransactionSuccessful Then
            strStatus = "Program Outcome added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Shared Function UpdateProgramOutcome(ByVal prgoutcomesid As Integer, ByVal programid As Integer, ByVal prgoutcometext As String, ByVal prgshortoutcome As String, ByVal ProgramOutcomesq As String, ByVal con As String) As String
        Dim strStatus As String = ""
        ' Dim con As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.UpdateProgramOutcome(prgoutcomesid, programid, prgoutcometext, prgshortoutcome, ProgramOutcomesq, con)
        If oUser.TransactionSuccessful Then
            strStatus = "Program Outcome added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus


    End Function
#End Region

#Region "Click Event Handlers for Page Controls"

#End Region

    '#Region "Local WebService Methods"
    '    <Services.WebMethod()> _
    '    Public Shared Function wsAddEditProgramOutcome(ByVal mode As String, ByVal prgoutcomesid As Integer, ByVal programid As Integer, ByVal prgoutcometext As String, ByVal prgshortoutcome As String, ByVal ProgramOutcomesq As String, ByVal ProgramOutcomeid As Integer) As String
    '        Dim strmsg As String = ""
    '        If mode = "add" Then
    '            strmsg = InsertProgramoutcome(prgoutcomesid, programid, prgoutcometext, prgshortoutcome, ProgramOutcomesq)
    '        ElseIf mode = "edit" Then
    '            strmsg = UpdateProgramOutcome(prgoutcomesid, programid, prgoutcometext, prgshortoutcome, ProgramOutcomesq)
    '        Else
    '            strmsg = "No Mode was Selected"
    '        End If
    '        Return strmsg
    '    #End Function
    '#End Region

    
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim strStatus As String = ""
        mode = Request.QueryString("mode") ' Get the actual mode from the Query string
        Dim con As String = GetConnectionString("ConnectionString")
        If mode = "add" Then
            'Dim ob As New DataAccessTier.daProgram
            Dim status As String = ""
            status = InsertProgramoutcome(CInt(ddlProgram.SelectedIndex + 1), txtPrgoutcom.Text, txtShortoutcome.Text, txtProgramseq.Text, con)
            'UpdateProgramOutcome(CInt(Session("prgoutcomesid")), CInt(ddlProgram.DataValueField), txtPrgoutcom.Text, txtShortoutcome.Text, txtProgramseq.Text, con)

            Savemsg.Text = status
        End If

        If mode = "edit" Then

            ' Dim ob As New DataAccessTier.daProgram
            ' UpdateProgramOutcome(CInt(Session("prgoutcomesid ")), CInt(ddlProgram.SelectedIndex + 1), txtPrgoutcom.Text, txtShortoutcome.Text, txtProgramseq.Text, con)
            Dim status As String = ""
            status = UpdateProgramOutcome(CInt(Session("prgoutcomesid ")), CInt(ddlProgram.SelectedIndex + 1), txtPrgoutcom.Text, txtShortoutcome.Text, txtProgramseq.Text, con)
            Savemsg.Text = status

        End If

    End Sub




    Protected Sub ddlProgram_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProgram.SelectedIndexChanged
        Dim index As Integer = ddlProgram.SelectedIndex
        Dim programid As Integer = CInt(ddlProgram.DataValueField)
    End Sub
    
End Class