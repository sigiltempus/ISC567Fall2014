Imports JSIM.Bases.SVTable
Public Class AddEditBKLevel2
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

#Region "Local Methods"
    Private Sub SetForm()
        Dim mode As String = Request.QueryString("mode")
        If mode = "add" Then
            AddNewBKLevel2()
        Else
            EditBKLevel2()
        End If
        btnSave.Parameters = CreateParameters()
    End Sub

    Private Sub AddNewBKLevel2()
        dgFrame.Text = "Add BKLevel2"
        txtISModelID.Text = ""
        txtBKLevel1ID.Text = ""
        txtNumberL1.Text = ""
        txtNumberL2.Text = ""
        txtTitle.Text = ""
    End Sub


    Private Sub EditBKLevel2()
        dgFrame.Text = "Edit BK Level2"
        Dim BKLevel1ID As Integer = CInt(Session("BKLevel1ID"))
        Dim BKLevel2ID As Integer = CInt(Session("BKLevel2ID"))
        'Dim subskillid As Integer = 1
        Dim oBKLevel2 As New DataAccessTier.daBodyOfKnowledge
        Dim con As String = GetConnectionString("connectionString")
        Dim dtBKLevel2 As DataTable = GetBKLevel2Info(BKLevel2ID)
        If Not IsNothing(dtBKLevel2) AndAlso dtBKLevel2.Rows.Count > 0 Then
            With dtBKLevel2
                txtISModelID.Text = .Rows(0)("ISModelID").ToString()
                txtBKLevel1ID.Text = .Rows(0)("BKLevel1ID").ToString()
                txtNumberL1.Text = .Rows(0)("NumberL1").ToString()
                txtNumberL2.Text = .Rows(0)("NumberL2").ToString()
                txtTitle.Text = .Rows(0)("title").ToString()
            End With

        End If

    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        Dim mode As String = Request.QueryString("mode")
        paramContainer.AddParameter("mode", mode, False)
        paramContainer.AddParameter("selectedProgramId", txtISModelID)
        paramContainer.AddParameter("BKLevel1ID", txtBKLevel1ID)
        paramContainer.AddParameter("NumberL1", txtNumberL1)
        paramContainer.AddParameter("NumberL2", txtNumberL2)
        paramContainer.AddParameter("title", txtTitle)


        Dim BKLevel2ID As Integer = CInt(Session("BKLevel2ID"))
        'Dim subskillid As Integer = 1
        paramContainer.AddParameter("BKLevel2ID", CStr(BKLevel2ID), False)
        Return MyBase.CreateParameters()
    End Function

#End Region


#Region "Local Functions"
    Private Function GetBKLevel2Info(ByVal BKLevel2ID As Integer) As DataTable
        Dim dtBKLevel2Info As DataTable
        Dim oBKLevel2 As New DataAccessTier.daBodyOfKnowledge
        Dim con As String = GetConnectionString("connectionString")
        dtBKLevel2Info = oBKLevel2.GetBKLevel2Info(BKLevel2ID, con)
        If Not oBKLevel2.TransactionSuccessful Then
            dtBKLevel2Info = Nothing
        End If
        Return dtBKLevel2Info
    End Function


    Private Shared Function insertBKLevel2Info(ByVal selectedprogramid As Integer, ByVal BKLevel1ID As Integer,
                                               ByVal NumberL1 As Integer, ByVal NumberL2 As Integer, ByVal title As String) As String
        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("connectionString")
        Dim oBKLevel2 As New DataAccessTier.daBodyOfKnowledge
        oBKLevel2.insertBKLevel2(selectedprogramid, BKLevel1ID, NumberL1, NumberL2, title, con)
        If oBKLevel2.TransactionSuccessful Then
            strStatus = "BKLevel2 added Successfull"
        Else
            strStatus = "Error occured"
        End If

        Return strStatus
    End Function

    Private Shared Function editBKLevel2Info(ByVal BKLevel2ID As Integer, ByVal selectedprogramid As Integer, ByVal BKLevel1ID As Integer, ByVal NumberL1 As Integer, ByVal NumberL2 As Integer, ByVal title As String) As String

        Dim strStatus As String = ""
        Dim con As String = GetConnectionString("connectionString")
        Dim oBKLevel2 As New DataAccessTier.daBodyOfKnowledge
        oBKLevel2.editBKLevel2Info(BKLevel2ID, selectedprogramid, BKLevel1ID, NumberL1, NumberL2, title, con)
        If oBKLevel2.TransactionSuccessful Then
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
    Public Shared Function wsAddEditBKLevel2(ByVal mode As String, ByVal selectedprogramid As Integer, ByVal BKLevel1ID As Integer, ByVal NumberL1 As Integer,
                                             ByVal NumberL2 As Integer, ByVal title As String, ByVal BKLevel2ID As Integer) As String
        Dim strmsg As String = ""
        If mode = "add" Then
            strmsg = insertBKLevel2Info(selectedprogramid, BKLevel1ID, NumberL1, NumberL2, title)
        ElseIf mode = "edit" Then
            strmsg = editBKLevel2Info(BKLevel2ID, selectedprogramid, BKLevel1ID, NumberL1, NumberL2, title)
        Else
            strmsg = "No Mode was Selected"
        End If
        Return strmsg
    #End Function
#End Region

End Class