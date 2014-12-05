Imports JSIM.Bases.SVTable
Public Class AddEditSkills
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetSVTable()
        Dim skillsidSv As Integer
        skillsidSv = GetSVTableValue(Of Integer)("skillsid")


        If IsNothing(skillsidSv) Then
            Response.Redirect("Login.aspx")
        End If
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
            EditSkills()
        End If
        btnSave.Parameters = CreateParameters()
    End Sub

    Private Sub AddNew()
        dgFrame.Text = "Add Skills"
    End Sub


    Private Sub EditSkills()
        dgFrame.Text = "Edit Skills"
        Dim skillid As Integer = Convert.ToInt32(Session("skillsnum"))
        Dim oUser As New DataAccessTier.daProgram
        Dim dtUserlInfo As DataTable = GetSkillsInfo(skillid)

        If Not IsNothing(dtUserlInfo) AndAlso dtUserlInfo.Rows.Count > 0 Then
            With dtUserlInfo
                txtskillsname.Text = .Rows(0)("skillsname").ToString()
            End With

        End If

    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        Dim mode As String = Request.QueryString("mode")
        Dim skillclass As String = Session("skillclassid").ToString()
        paramContainer.AddParameter("mode", mode, False)
        paramContainer.AddParameter("skillsclassnum", skillclass, False)
        paramContainer.AddParameter("skillsname", txtskillsname)
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


    Private Shared Function insertskills(ByVal skillsclassnum As Integer, ByVal skillsname As String) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.insertskills(skillsclassnum, skillsname, con)
        If oUser.TransactionSuccessful Then
            strStatus = "Skills added Successfully"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Shared Function editskill(ByVal skillsclassnum As Integer, ByVal skillsname As String) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        Dim skillsid As Integer = GetSVTableValue(Of Integer)("skillsnum")
        oUser.editskills(skillsid, skillsclassnum, skillsname, con)
        If oUser.TransactionSuccessful Then
            strStatus = "Skills edited Successfully"
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
    Public Shared Function wsAddEditSkills(ByVal mode As String, ByVal skillsclassnum As Integer, ByVal skillsname As String) As String
        Dim strmsg As String = ""
        If mode = "add" Then
            strmsg = insertskills(skillsclassnum, skillsname)
        ElseIf mode = "edit" Then
            strmsg = editskill(skillsclassnum, skillsname)
        Else
            strmsg = "No Mode was Selected"
        End If
        Return strmsg
    #End Function
#End Region
End Class