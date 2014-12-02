Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Imports DataAccessTier.daUser

Public Class AddEditExamItem
    Inherits System.Web.UI.Page
    Dim mode As String
    Dim cn As String = GetConnectionString("connectionString")
    Dim oUser As New DataAccessTier.daUser


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            setForm()
            PopulateTextBox()
        End If
    End Sub
    Private Sub PopulateTextBox()
        Dim eid As Integer = CInt(Session("examid"))
        Dim dtExamInfo As DataTable = oUser.getExamNamesForEditScreen(eid, cn)
        txtExam.Text = dtExamInfo.Rows(0).Item("examname").ToString()
        txtType.Text = dtExamInfo.Rows(0).Item("description").ToString()
    End Sub




    Protected Sub SetForm()
        mode = Request.QueryString("mode")
        If mode = "add" Then
            AddItemMethod()
        ElseIf mode = "edit" Then
            EditItemMethod()
        End If
    End Sub

    Private Sub AddItemMethod()
        txtObjective.Text = "Enter Question Objective Here"
        txtItem.Text = "Write question stem here"
    End Sub

    Private Sub EditItemMethod()
        Dim AppUser As New DataAccessTier.daUser

        Dim dtItemInfo As DataTable
        dtItemInfo = AppUser.GetExamItemForEdit(CInt(Session("examItemId")), cn)

        If Not IsNothing(dtItemInfo) AndAlso dtItemInfo.Rows.Count > 0 Then
            With dtItemInfo

                txtObjective.Text = .Rows(0)("questionobjective").ToString()
                txtItem.Text = .Rows(0)("stem").ToString()
                txtA.Text = .Rows(0)("destractor1").ToString()
                txtB.Text = .Rows(0)("destractor2").ToString()
                txtC.Text = .Rows(0)("destractor3").ToString()
                txtD.Text = .Rows(0)("destractor4").ToString()
                txtCorrect.Text = .Rows(0)("correctanswer").ToString()
            End With
        End If

    End Sub






    Protected Sub btnSaveChanges_Click(sender As Object, e As EventArgs) Handles btnSaveChanges.Click
        Dim ouser As New DataAccessTier.daUser

        mode = Request.QueryString("mode")

        If mode = "add" Then
            ouser.AddorUpdateExamItem(-1, CInt(Session("examid").ToString()), txtObjective.Text, txtItem.Text, txtA.Text, txtB.Text, txtC.Text, txtD.Text, txtCorrect.Text, cn)
        ElseIf mode = "edit" Then
            Dim eid = Session("examitemid").ToString()
            ouser.AddorUpdateExamItem(CInt(eid), CInt(Session("examid").ToString()), txtObjective.Text, txtItem.Text, txtA.Text, txtB.Text, txtC.Text, txtD.Text, txtCorrect.Text, cn)

        End If

    End Sub
End Class