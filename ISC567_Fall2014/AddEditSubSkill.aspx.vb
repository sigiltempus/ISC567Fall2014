Imports JSIM.Bases.SVTable
Public Class AddEditSubSkill
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim subskillidSv As Integer
        subskillidSv = GetSVTableValue(Of Integer)("subskillid")
        'subskillidSv = 1
        If IsNothing(subskillidSv) Then
            Response.Redirect("Login.aspx")
        End If
        SetFrom()
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
        'Dim subskillid As Integer = 1
        Dim oUser As New DataAccessTier.daProgram
        Dim con As String = GetConnectionString("ConnectionString")
        Dim dtUserlInfo As DataTable = GetSubSkillInfo(subskillid)
        If Not IsNothing(dtUserlInfo) AndAlso dtUserlInfo.Rows.Count > 0 Then
            With dtUserlInfo
                txtskillsclassnum.Text = .Rows(0)("skillsclassnum").ToString()
                txtskillsnum.Text = .Rows(0)("skillsnum").ToString()
                txtsubskillnum.Text = .Rows(0)("subskillnum").ToString()
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
        paramContainer.AddParameter("skillsclassnum", txtskillsclassnum)
        paramContainer.AddParameter("skillsnum", txtskillsnum)
        paramContainer.AddParameter("subskillnum", txtsubskillnum)
        paramContainer.AddParameter("subskilltitle", txtsubskilltitle)
        paramContainer.AddParameter("subskillcombo", txtsubskillcombo)
        paramContainer.AddParameter("jobadwords", txtjobadwords)
        Dim subskillid As Integer = Convert.ToInt16(GetSVTableValue(Of Integer)("subskillid"))
        'Dim subskillid As Integer = 1
        'paramContainer.AddParameter("subskillid", subskillid, False)
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


    Private Shared Function insertsubskill(ByVal skillsclassnum As Integer, ByVal skillsnum As Integer, ByVal subskillnum As Integer, ByVal subskilltitle As String, ByVal subskillcomb As String, ByVal jobadwords As String) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.insertsubskill(skillsclassnum, skillsnum, subskillnum, subskilltitle, subskillcomb, jobadwords, con)
        If oUser.TransactionSuccessful Then
            strStatus = "SubSkill added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Shared Function editsubskill(ByVal subskillid As Integer, ByVal skillsclassnum As Integer, ByVal skillsnum As Integer, ByVal subskillnum As Integer, ByVal subskilltitle As String, ByVal subskillcomb As String, ByVal jobadwords As String) As String

        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.editsubskill(subskillid, skillsclassnum, skillsnum, subskillnum, subskilltitle, subskillcomb, jobadwords, con)
        If oUser.TransactionSuccessful Then
            strStatus = "SubSkill added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function
#End Region

#Region "Click Event Handlers for Page Controls"
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim skillsclassnum = txtskillsclassnum.Text
        Dim skillsnum = txtskillsnum.Text
        Dim subskillnum = txtsubskillnum.Text
        Dim subskillcombo = txtsubskillcombo.Text
        Dim subskilltitle = txtsubskilltitle.Text
        Dim jobadwords = txtjobadwords.Text


        Dim ConnectionString As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.insertsubskill(CInt(skillsclassnum), CInt(skillsnum), CInt(subskillnum), subskilltitle, subskillcombo, jobadwords, ConnectionString)
    End Sub

#End Region

    '#Region "Local WebService Methods"
    '    <Services.WebMethod()> _
    '    Public Shared Function wsAddEditSubSkill(ByVal mode As String, ByVal skillsclassnum As Integer, ByVal skillsnum As Integer, ByVal subskillnum As Integer, ByVal subskilltitle As String, ByVal subskillcomb As String, ByVal jobadwords As String,
    '                                            ByVal subskillid As Integer) As String
    '        Dim strmsg As String = ""
    '        If mode = "add" Then
    '            strmsg = insertsubskill(skillsclassnum, skillsnum, subskillnum, subskilltitle, subskillcomb, jobadwords)
    '        ElseIf mode = "edit" Then
    '            strmsg = EditSubSkill(subskillid, skillsclassnum, skillsnum, subskillnum, subskilltitle, subskillcomb, jobadwords)
    '        Else
    '            strmsg = "No Mode was Selected"
    '        End If
    '        Return strmsg
    '    #End Function
    '#End Region


End Class