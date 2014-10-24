Imports JSIM.Bases.SVTable
Public Class AddEditSkillClass
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim skillclassid As Integer
        skillclassid = GetSVTableValue(Of Integer)("skillclassid")
        'DODSkillClassSv = 1
        If IsNothing(skillclassid) Then
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
            EditSkillClass()
        End If
        btnSave.Parameters = CreateParameters()
    End Sub

    Private Sub AddNew()
        dgFrame.Text = "Add Skill Class"
        txtscname.Text = ""
        txtskillsclassnum.Text = ""
        ddlProgram.SelectedIndex = -1
    End Sub


    Private Sub EditSkillClass()
        dgFrame.Text = "Edit Skill Class"
        GetSVTable()
        ' Dim skillclassid As Integer
        Dim skillclassid = CInt(Session("skillclassid"))
        Dim skillsclassnum = CInt(Session("skillsclassnum"))
        Dim skillsnum = CInt(Session("skillsnum"))
        Dim skillsname = CStr(Session("skillsname"))
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
        paramContainer.AddParameter("scname", txtscname)
        paramContainer.AddParameter("skillsclassnum", txtskillsclassnum)
        paramContainer.AddParameter("programid", ddlProgram)
        Dim skillclassid As Integer = Convert.ToInt32(GetSVTableValue(Of Integer)("skillclassid"))
        'Dim skillclassid As Integer = 1
        'paramContainer.AddParameter("skillclassid", skillclassid, False)
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
    #End Function

#End Region

    'Protected Sub ddlProgram_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlProgram.SelectedIndexChanged
    '    MessageBox("Do you want to save these changes")
    'End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine & _
               "window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'mode = Request.QueryString("mode")


        Dim skillsclassnum = txtskillsclassnum.Text
        Dim scname = txtscname.Text
        Dim programid = ddlProgram.Text

        Dim ConnectionString As String = GetConnectionString("ConnectionString")
        Dim oUser As New DataAccessTier.daProgram
        oUser.insertskillclass(scname, CInt(skillsclassnum), CInt(programid), ConnectionString)


        'Dim skillsclassnum As String = ProjectsGridView.SelectedValue.ToString()
        'Session.Add("skillsclassnum", skillsclassnum)
        'Dim skillsname As String = ProjectsGridView.SelectedValue.ToString()
        'Session.Add("skillsname", skillsname)
        'programid As String = ProjectsGridView.SelectedValue.ToString()
        'Session.Add("programid", programid)



    End Sub
End Class