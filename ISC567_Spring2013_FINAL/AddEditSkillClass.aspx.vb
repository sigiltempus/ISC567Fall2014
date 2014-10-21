Imports JSIM.Bases.SVTable
Public Class AddEditSkillClass
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetSVTable()
        Dim skillclassid As Integer = GetSVTableValue(Of Integer)("skillclassid")
        If IsNothing(skillclassid) Then
            Response.Redirect("Login.aspx")
        End If
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

#Region "Local Methods"
    Private Sub SetForm()
        Dim mode As String = Request.QueryString("mode")
        If mode = "add" Then
            AddNew()
        Else
            EditSkillClass()
        End If
        btnSave.Parameters = CreateParameters()
    End Sub

    Private Sub AddNew()
        dgFrame.Text = "Add Skill Class"
        txtscname.Text = ""
        txtskillsclassnum.Text = ""
        'Dim ProgramId As Integer = CInt(Session("selectedProgramId"))
        ddlProgram.SelectedValue = Session("selectedProgramId").ToString()
    End Sub


    Private Sub EditSkillClass()
        dgFrame.Text = "Edit Skill Class"
        GetSVTable()
        ' Dim skillclassid As Integer
        Dim skillclassid As Integer = GetSVTableValue(Of Integer)("skillclassid")
        Dim oUser As New DataAccessTier.daProgram
        Dim con As String = GetConnectionString("ConnectionString")
        Dim dtUserlInfo As DataTable = oUser.GetSkillClassInfo(skillclassid, con)

        If Not IsNothing(dtUserlInfo) AndAlso dtUserlInfo.Rows.Count > 0 Then
            With dtUserlInfo
                txtscname.Text = .Rows(0)("scname").ToString()
                txtskillsclassnum.Text = .Rows(0)("skillsclassnum").ToString()
                ddlProgram.SelectedValue = .Rows(0)("programid").ToString()
            End With

        End If

    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        Dim mode As String = Request.QueryString("mode")
        paramContainer.AddParameter("mode", mode, False)
        paramContainer.AddParameter("skillsclassnum", txtskillsclassnum) ' txtscname)
        paramContainer.AddParameter("scname", txtscname)
        paramContainer.AddParameter("programid", ddlProgram)
        Dim foo As Integer = GetSVTableValue(Of Integer)("skillclassid")
        Dim skillclassid As String = CStr(foo)
        paramContainer.AddParameter("skillclassid", skillclassid, False)
        Return MyBase.CreateParameters()
    End Function

#End Region

#Region "Local Functions"
    Private Function GetSkillClassInfo(ByVal skillclassid As Integer) As DataTable
        Dim dtUserlInfo As DataTable
        Dim oUser As New DataAccessTier.daProgram
        Dim con As String = GetConnectionString("ConnectionString")
        dtUserlInfo = oUser.GetSkillClassInfo(skillclassid, con)
        If Not oUser.TransactionSuccessful Then
            dtUserlInfo = Nothing
        End If
        Return dtUserlInfo
    End Function


    Private Shared Function insertskillclass(ByVal scname As String, ByVal skillsclassnum As Integer, ByVal programid As Integer) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.insertskillclass(scname, skillsclassnum, programid, con)
        If oUser.TransactionSuccessful Then
            strStatus = "SkillClass added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Shared Function editskillclass(ByVal skillclassid As Integer, ByVal skillsclassnum As Integer, ByVal skillsname As String, ByVal programid As Integer) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.editskillclass(skillclassid, skillsclassnum, skillsname, programid, con)
        If oUser.TransactionSuccessful Then
            strStatus = "SkillClass added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function
    ' Private Function deleteskillclass(ByVal skillclassid As Integer) As String
    ' Dim strStatus As String = ""
    'Dim con As String = GetConnectionString("ConnectionString")
    'Dim oUser As New DataAccessTier.daProgram
    '    oUser.deleteskillclass(skillclassid, con)
    '    If oUser.TransactionSuccessful Then
    '        strStatus = "SkillClass deleted Successfull"
    '    Else
    '        strStatus = "Error occured"
    '    End If

    '    Return strStatus
    'End Function
#End Region

#Region "Click Event Handlers for Page Controls"

#End Region

#Region "Local WebService Methods"
    <Services.WebMethod()> _
    Public Shared Function wsAddEditSkillClass(ByVal mode As String, ByVal skillsclassnum As Integer, ByVal skillsname As String, ByVal programid As Integer,
                                            ByVal skillclassid As Integer) As String
        Dim strmsg As String = ""
        If mode = "add" Then
            strmsg = insertskillclass(skillsname, skillsclassnum, programid)
        ElseIf mode = "edit" Then
            strmsg = EditSkillClass(skillclassid, skillsclassnum, skillsname, programid)
        Else
            strmsg = "No Mode was Selected"
        End If
        Return strmsg
    End Function

#End Region

End Class