Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class AddEditBKLevel1
    Inherits JSIM.Bases.BaseClass
    'Dim mode As String = "add" ' Assume add by default

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub
    Private Sub SetForm()
        Dim mode As String = Request.QueryString("mode") ' Get the actual mode from the Query string
        If mode = "add" Then
            AddNew()
        ElseIf mode = "edit" Then
            EditBKLevel1()
        End If
        btnSave.Parameters = CreateParameters()
    End Sub
    Private Sub AddNew()
        dgFrame.Text = "Add BKLevel1"
        txtNumberL1.Text = ""
        txtTitle.Text = ""
        ddlProgram.SelectedIndex = -1
    End Sub


    Private Sub EditBKLevel1()
        dgFrame.Text = "Edit BKLevel1 Info"
        Dim BKLevel1ID As Integer = CInt(Session("BKLevel1ID"))
        'Dim skillclassid As Integer = 1
        'Dim ProjectID As Integer = Convert.ToInt32(Request.QueryString("ProjectID"))
        Dim oBKLevel1 As New DataAccessTier.daBodyOfKnowledge
        Dim con As String = GetConnectionString("connectionString")
        Dim dtBKLevel1Info As DataTable = oBKLevel1.GetBKLevel1Info(BKLevel1ID, con)

        If Not IsNothing(dtBKLevel1Info) AndAlso dtBKLevel1Info.Rows.Count > 0 Then
            With dtBKLevel1Info
                txtTitle.Text = .Rows(0)("title").ToString()
                txtNumberL1.Text = .Rows(0)("NumberL1").ToString()
                ddlProgram.SelectedValue = .Rows(0)("ISModelID").ToString()
            End With

        End If
    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        Dim mode As String = Request.QueryString("mode")
        paramContainer.AddParameter("mode", mode, False)
        paramContainer.AddParameter("title", txtTitle)
        paramContainer.AddParameter("NumberL1", txtNumberL1)
        paramContainer.AddParameter("programid", ddlProgram)

        Dim BKLevel1ID As Integer
        'Dim BKLevel1ID As Integer = Convert.ToInt16(GetSVTableValue(Of Integer)("BKLevel1ID"))

        BKLevel1ID = CInt(Session("BKLevel1ID"))
        'Dim skillclassid As Integer = 1
        paramContainer.AddParameter("BKLevel1ID", CStr(BKLevel1ID), False)
        Return MyBase.CreateParameters()
    End Function

#Region "Local Functions"
    Private Shared Function insertBKLevel1Info(ByVal title As String, ByVal NumberL1 As Integer, ByVal programid As Integer) As String
        Dim strStatus As String = ""
        Dim cn As String = GetConnectionString("connectionString")
        Dim oBKLevel1 As New DataAccessTier.daBodyOfKnowledge
        oBKLevel1.insertBKLevel1(title, NumberL1, programid, cn)
        If oBKLevel1.TransactionSuccessful Then
            strStatus = "BKLevel1 added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Function GetBKLevel1Info(ByVal BKLevel1ID As Integer) As DataTable
        Dim dtBKLevel1Info As DataTable
        Dim oBKLevel1 As New DataAccessTier.daBodyOfKnowledge
        Dim con As String = GetConnectionString("connectionString")
        dtBKLevel1Info = oBKLevel1.GetBKLevel1Info(BKLevel1ID, con)
        If Not oBKLevel1.TransactionSuccessful Then
            dtBKLevel1Info = Nothing
        End If
        Return dtBKLevel1Info
    End Function

    Private Shared Function editBKLevel1Info(ByVal BKLevel1ID As Integer, ByVal title As String, ByVal NumberL1 As Integer, ByVal programid As Integer) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("connectionString")
        Dim oBKLevel1 As New DataAccessTier.daBodyOfKnowledge
        oBKLevel1.editBKLevel1Info(BKLevel1ID, title, NumberL1, programid, con)
        If oBKLevel1.TransactionSuccessful Then
            strStatus = "SkillClass added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function
#End Region

#Region "Local WebService Methods"
    <Services.WebMethod()> _
    Public Shared Function wsAddEditBKLevel1(ByVal mode As String, ByVal title As String, ByVal NumberL1 As Integer, ByVal programid As Integer,
                                            ByVal BKLevel1ID As Integer) As String
        Dim strmsg As String = ""
        If mode = "add" Then
            strmsg = insertBKLevel1Info(title, NumberL1, programid)
        ElseIf mode = "edit" Then
            strmsg = editBKLevel1Info(BKLevel1ID, title, NumberL1, programid)
        Else
            strmsg = "No Mode was Selected"
        End If
        Return strmsg
    #End Function

#End Region

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine & _
               "window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

End Class