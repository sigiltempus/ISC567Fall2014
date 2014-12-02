Imports JSIM.Bases.SVTable
Public Class AddEditSubSkill
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetFrom()
        End If
    End Sub

#Region "Local Methods"
    Private Sub SetFrom()
        Dim mode As String = Request.QueryString("mode")
        If mode = "add" Then
            AddNew()
        Else
            EditSubSkill()
        End If
        btnSave.Parameters = CreateParameters()
    End Sub

    Private Sub AddNew()
        dgFrame.Text = "Add Sub Skill"
        'txtskillsclassnum.Text = ""
        'txtskillsnum.Text = ""
        'txtsubskillnum.Text = ""
        'txtsubskilltitle.Text = ""
        'txtsubskillcombo.Text = ""
        'txtjobadwords.Text = ""
    End Sub


    Private Sub EditSubSkill()
        dgFrame.Text = "Edit Sub Skill"
        Dim Subskillid = CInt(Session("subskillid"))
        Dim oUser As New DataAccessTier.daProgram
        Dim con As String = GetConnectionString("ConnectionString")
        Dim dtUserlInfo As DataTable = GetSubSkillInfo(Subskillid)
        If Not IsNothing(dtUserlInfo) AndAlso dtUserlInfo.Rows.Count > 0 Then
            With dtUserlInfo

                txtskillsnum.Text = .Rows(0)("skillsid").ToString()
                'txtsubskillnum.Text = .Rows(0)("subskillnum").ToString()
                txtsubskilltitle.Text = .Rows(0)("subskilltitle").ToString()
                txtsubskillcombo.Text = .Rows(0)("subskillcomb").ToString()
                txtjobadwords.Text = .Rows(0)("jobadwords").ToString()

            End With

        End If

    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        Dim mode As String = Request.QueryString("mode")
        paramContainer.AddParameter("mode", mode, False)
        paramContainer.AddParameter("skillsnum", txtskillsnum)
        'paramContainer.AddParameter("subskillnum", txtsubskillnum)
        paramContainer.AddParameter("subskilltitle", txtsubskilltitle)
        paramContainer.AddParameter("jobadwords", txtjobadwords)
        paramContainer.AddParameter("subskillcombo", txtsubskillcombo)
        Dim subskillid As String = Session("subskillid").ToString()
        paramContainer.AddParameter("subskillid", subskillid, False)
        'paramContainer.AddParameter("subskillid", txtskillsnum)
        Return MyBase.CreateParameters()
    End Function

#End Region

#Region "Local Functions"
    Private Function GetSubSkillInfo(ByVal subskillid As Integer) As DataTable
        Dim dtUserlInfo As DataTable
        Dim oUser As New DataAccessTier.daProgram
        Dim con As String = GetConnectionString("ConnectionString")
        dtUserlInfo = oUser.GetSubSkillInfo(subskillid, con)
        If Not oUser.TransactionSuccessful Then
            dtUserlInfo = Nothing
        End If
        Return dtUserlInfo
    End Function


    Private Shared Function insertsubskill(ByVal skillsnum As Integer, ByVal subskilltitle As String, ByVal jobadwords As String, ByVal subskillcomb As String) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.insertsubskill(skillsnum, subskilltitle, subskillcomb, jobadwords, con)
        If oUser.TransactionSuccessful Then
            strStatus = "SubSkill added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Shared Function editsubskill(ByVal subskillid As Integer, ByVal skillsnum As Integer, ByVal subskilltitle As String, ByVal subskillcomb As String, ByVal jobadwords As String) As String

        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.editsubskill(subskillid, skillsnum, subskilltitle, subskillcomb, jobadwords, con)
        If oUser.TransactionSuccessful Then
            strStatus = "SubSkill added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function
#End Region

#Region "Click Event Handlers for Page Controls"

#End Region

#Region "Local WebService Methods"
    <Services.WebMethod()> _
    Public Shared Function wsAddEditSubSkill(ByVal mode As String, ByVal skillsnum As Integer, ByVal subskilltitle As String, ByVal jobadwords As String, ByVal subskillcomb As String,
                                                ByVal subskillid As Integer) As String
        Dim strmsg As String = ""
        If mode = "add" Then
            strmsg = insertsubskill(skillsnum, subskilltitle, subskillcomb, jobadwords)
        ElseIf mode = "edit" Then
            strmsg = EditSubSkill(subskillid, skillsnum, subskilltitle, subskillcomb, jobadwords)
        Else
            strmsg = "No Mode was Selected"
        End If
        Return strmsg
        #End Function
#End Region


End Class