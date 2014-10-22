Imports JSIM.Bases.SVTable
Public Class AddEditSkills
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim skillsidSv As Integer
        skillsidSv = GetSVTableValue(Of Integer)("skillsid")
        'skillsidSv = 1
        If IsNothing(skillsidSv) Then
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
            EditSkills()
        End If
        btnSave.Parameters = CreateParameters()
    End Sub

    Private Sub AddNew()
        dgFrame.Text = "Add Skills"
        'txtskillsclassnum.Text = ""
        'txtskillsnum.Text = ""
        'txtskillsname.Text = ""
    End Sub


    Private Sub EditSkills()
        dgFrame.Text = "Edit Skills"
        Dim skillsId = CInt(Session("skillsid"))
        'Dim skillsnum = CInt(Session("skillsnum"))
        'Dim skillsclassnum = CInt(Session("skillsclassnum"))
        Dim oUser As New DataAccessTier.daProgram
        Dim dtUserlInfo As DataTable = GetSkillsInfo(skillsId)

        If Not IsNothing(dtUserlInfo) AndAlso dtUserlInfo.Rows.Count > 0 Then
            With dtUserlInfo
                txtskillsclassnum.Text = .Rows(0)("skillsclassnum").ToString()
                txtskillsnum.Text = .Rows(0)("skillsnum").ToString()
                txtskillsname.Text = .Rows(0)("skillsname").ToString()
            End With

        End If

    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        Dim mode As String = Request.QueryString("mode")
        paramContainer.AddParameter("mode", mode, False)
        paramContainer.AddParameter("skillsclassnum", txtskillsclassnum)
        paramContainer.AddParameter("skillsnum", txtskillsnum)
        paramContainer.AddParameter("skillsname", txtskillsname)
        Dim skillsid As Integer = Convert.ToInt16(GetSVTableValue(Of Integer)("skillsid"))
        'Dim skillsid As Integer = 1
        'paramContainer.AddParameter("skillsid", skillsid, False)
        Return MyBase.CreateParameters()
    End Function

#End Region

#Region "Local Functions"
    Private Function GetSkillsInfo(ByVal skillsId As Integer) As DataTable
        Dim dtUserlInfo As DataTable
        Dim oUser As New DataAccessTier.daProgram
        Dim con As String = GetConnectionString("ConnectionString")
        dtUserlInfo = oUser.GetSkillsInfo(skillsId, con)
        If Not oUser.TransactionSuccessful Then
            dtUserlInfo = Nothing
        End If
        Return dtUserlInfo
    End Function


    Private Shared Function insertskills(ByVal skillsclassnum As Integer, ByVal skillsnum As Integer, ByVal skillsname As String) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.insertskills(skillsclassnum, skillsnum, skillsname, con)
        If oUser.TransactionSuccessful Then
            strStatus = "Skills added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Shared Function editskills(ByVal skillsid As Integer, ByVal skillsclassnum As Integer, ByVal skillsnum As Integer, ByVal skillsname As String) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.editskills(skillsid, skillsclassnum, skillsnum, skillsname, con)
        If oUser.TransactionSuccessful Then
            strStatus = "Skills added Successfull"
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
    Public Shared Function wsAddEditSkills(ByVal mode As String, ByVal skillsclassnum As Integer, ByVal skillsnum As Integer, ByVal skillsname As String,
                                            ByVal skillsid As Integer) As String
        Dim strmsg As String = ""
        If mode = "add" Then
            strmsg = insertskills(skillsclassnum, skillsnum, skillsname)
        ElseIf mode = "edit" Then
            strmsg = EditSkills(skillsid, skillsclassnum, skillsnum, skillsname)
        Else
            strmsg = "No Mode was Selected"
        End If
        Return strmsg
    #End Function
#End Region

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'mode = Request.QueryString("mode")


        Dim skillsclassnum = txtskillsclassnum.Text
        Dim skillsnum = txtskillsnum.Text
        Dim skillsname = txtskillsname.Text

        Dim ConnectionString As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.insertskills(CInt(skillsclassnum), CInt(skillsnum), skillsname, ConnectionString)


        'Dim skillsclassnum As String = ProjectsGridView.SelectedValue.ToString()
        'Session.Add("skillsclassnum", skillsclassnum)
        'Dim skillsname As String = ProjectsGridView.SelectedValue.ToString()
        'Session.Add("skillsname", skillsname)
        'programid As String = ProjectsGridView.SelectedValue.ToString()
        'Session.Add("programid", programid)



    End Sub
End Class