Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Imports DataAccessTier.daUser

Public Class ExamProvider_12
    Inherits System.Web.UI.Page
    Dim mode As String
    Dim cn As String = GetConnectionString("connectionString")
    Dim oUser As New DataAccessTier.daUser


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            populateKey1()
            SetForm()
            PopulateTextBox()
        End If
    End Sub
    Private Sub PopulateTextBox()
        Dim eid As Integer = CInt(Session("examid"))
        Dim dtExamInfo As DataTable = oUser.getExamNamesForEditScreen(eid, cn)
        txtExam.Text = dtExamInfo.Rows(0).Item("examname").ToString()
        txtType.Text = dtExamInfo.Rows(0).Item("description").ToString()
    End Sub

    Protected Sub populateKey1()
        Dim dtProviderInfo As DataTable = oUser.GetList1(cn)
        Session("Key1") = dtProviderInfo
        ddlKey1.Items.Insert(0, "Select a Course")

        Dim newListItem As ListItem
        For Each row As DataRow In dtProviderInfo.Rows

            newListItem = New ListItem(row("crsoutcometext").ToString().Trim(), row("key1id").ToString().Trim())
            ddlKey1.Items.Add(newListItem)
        Next
        ddlKey1.DataBind()
    End Sub

    Protected Sub ddlKey1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlKey1.SelectedIndexChanged
        Dim dtKey1 As DataTable = CType(Session("Key1"), DataTable)
        Dim newListItem As ListItem
        Dim resultsKey1 = (From myRow In dtKey1
                       Where myRow.Field(Of Int32)("key1id") = CInt(ddlKey1.SelectedValue.ToString().Trim()) Select myRow).First()
        TextBox3.Text = resultsKey1("courseid").ToString().Trim()

        ddlKey2.Items.Clear()
        ddlKey3.Items.Clear()

        Dim dtKey2 As DataTable = oUser.GetList2(CInt(ddlKey1.SelectedValue.ToString().Trim()), cn)

        If dtKey2.Rows.Count > 1 Then
            ddlKey2.Items.Insert(0, "Select a Objective")
        End If


        For Each row As DataRow In dtKey2.Rows
            newListItem = New ListItem(row("dodobjectivenumvalue").ToString().Trim(), row("key2id").ToString().Trim())
            ddlKey2.Items.Add(newListItem)
        Next
        ddlKey2.DataBind()

        Session("Key2") = dtKey2

        Dim dtKey3 As DataTable = oUser.GetList3(CInt(ddlKey1.SelectedValue.ToString().Trim()), cn)

        If dtKey3.Rows.Count > 1 Then
            ddlKey3.Items.Insert(0, "Select a Skill")
        End If

        For Each row As DataRow In dtKey3.Rows
            newListItem = New ListItem(row("SubskillTitle").ToString().Trim(), row("key3id").ToString().Trim())
            ddlKey3.Items.Add(newListItem)
        Next
        ddlKey3.DataBind()

        Session("Key3") = dtKey3

        TextBox2.Text = ""
        TextBox1.Text = ""

        If dtKey2.Rows.Count = 1 Then
            TextBox2.Text = dtKey2.Rows(0)("dodobjectivenum").ToString().Trim()
        End If

        If dtKey3.Rows.Count = 1 Then
            TextBox1.Text = dtKey3.Rows(0)("SkillsID").ToString().Trim()
        End If
    End Sub

    Protected Sub ddlKey2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlKey2.SelectedIndexChanged
        Dim dtKey2 As DataTable = CType(Session("Key2"), DataTable)
        Dim resultsKey2 = (From myRow In dtKey2
                                Where myRow.Field(Of Int32)("key2id") = CInt(ddlKey2.SelectedValue.ToString().Trim()) Select myRow).First()
        TextBox2.Text = resultsKey2("dodobjectivenum").ToString().Trim()
    End Sub

    Protected Sub ddlKey3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlKey3.SelectedIndexChanged
        Dim dtKey3 As DataTable = CType(Session("Key3"), DataTable)
        Dim resultsKey3 = (From myRow In dtKey3
                               Where myRow.Field(Of Int32)("key3id") = CInt(ddlKey3.SelectedValue.ToString().Trim()) Select myRow).First()
        TextBox1.Text = resultsKey3("SkillsID").ToString().Trim()
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

    End Sub

    Private Sub EditItemMethod()
        Dim AppUser As New DataAccessTier.daUser

        Dim dtItemInfo As DataTable
        dtItemInfo = AppUser.GetExamItemForEdit(CInt(Session("examItemId")), cn)

        If Not IsNothing(dtItemInfo) AndAlso dtItemInfo.Rows.Count > 0 Then
            With dtItemInfo
                ddlKey1.Items.Clear()
                ddlKey2.Items.Clear()
                ddlKey3.Items.Clear()

                Dim key1 As Integer = CInt(.Rows(0)("key1id").ToString())
                Dim key2 As Integer = CInt(.Rows(0)("key2id").ToString())
                Dim key3 As Integer = CInt(.Rows(0)("key3id").ToString())

                populateKey1ForEdit(key1)
                populateKey2ForEdit(key1, key2)
                populateKey3ForEdit(key1, key3)

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


    Protected Sub populateKey1ForEdit(ByVal key1id As Integer)
        Dim dtKey1 As DataTable = CType(Session("Key1"), DataTable)
        ddlKey1.Items.Insert(0, "Select a Course")

        Dim newListItem As ListItem
        For Each row As DataRow In dtKey1.Rows

            newListItem = New ListItem(row("crsoutcometext").ToString().Trim(), row("key1id").ToString().Trim())
            ddlKey1.Items.Add(newListItem)
        Next
        ddlKey1.SelectedValue = key1id.ToString()

        Dim resultsKey1 = (From myRow In dtKey1
                       Where myRow.Field(Of Int32)("key1id") = CInt(ddlKey1.SelectedValue.ToString().Trim()) Select myRow).First()
        TextBox3.Text = resultsKey1("courseid").ToString().Trim()

        ddlKey1.DataBind()
    End Sub

    Protected Sub populateKey2ForEdit(ByVal key1id As Integer, ByVal key2id As Integer)
        Dim dtKey2 As DataTable = oUser.GetList2(key1id, cn)

        If dtKey2.Rows.Count > 1 Then
            ddlKey2.Items.Insert(0, "Select a Objective")
        End If

        Dim newListItem As ListItem
        For Each row As DataRow In dtKey2.Rows
            newListItem = New ListItem(row("dodobjectivenumvalue").ToString().Trim(), row("key2id").ToString().Trim())
            ddlKey2.Items.Add(newListItem)
        Next
        ddlKey2.SelectedValue = key2id.ToString()

        Dim resultsKey2 = (From myRow In dtKey2
                                Where myRow.Field(Of Int32)("key2id") = CInt(ddlKey2.SelectedValue.ToString().Trim()) Select myRow).First()
        TextBox2.Text = resultsKey2("dodobjectivenum").ToString().Trim()

        ddlKey2.DataBind()
    End Sub


    Protected Sub populateKey3ForEdit(ByVal key1id As Integer, ByVal key3id As Integer)
        Dim dtKey3 As DataTable = oUser.GetList3(key1id, cn)

        If dtKey3.Rows.Count > 1 Then
            ddlKey3.Items.Insert(0, "Select a Skill")
        End If

        Dim newListItem As ListItem
        For Each row As DataRow In dtKey3.Rows
            newListItem = New ListItem(row("SubskillTitle").ToString().Trim(), row("key3id").ToString().Trim())
            ddlKey3.Items.Add(newListItem)
        Next
        ddlKey3.SelectedValue = key3id.ToString()

        Dim resultsKey3 = (From myRow In dtKey3
                               Where myRow.Field(Of Int32)("key3id") = CInt(ddlKey3.SelectedValue.ToString().Trim()) Select myRow).First()
        TextBox1.Text = resultsKey3("SkillsID").ToString().Trim()

        ddlKey3.DataBind()
    End Sub

    Protected Sub btnSaveChanges_Click(sender As Object, e As EventArgs) Handles btnSaveChanges.Click
        Dim ouser As New DataAccessTier.daUser

        mode = Request.QueryString("mode")

        If mode = "add" Then
            ouser.AddorUpdateExamItem(-1, CInt(Session("examid").ToString()), CInt(ddlKey1.SelectedValue.ToString()), CInt(ddlKey2.SelectedValue.ToString()), CInt(ddlKey3.SelectedValue.ToString()), txtObjective.Text, txtItem.Text, txtA.Text, txtB.Text, txtC.Text, txtD.Text, txtCorrect.Text, cn)
        ElseIf mode = "edit" Then
            Dim eid = Session("examitemid").ToString()
            ouser.AddorUpdateExamItem(CInt(eid), CInt(Session("examid").ToString()), CInt(ddlKey1.SelectedValue.ToString()), CInt(ddlKey2.SelectedValue.ToString()), CInt(ddlKey3.SelectedValue.ToString()), txtObjective.Text, txtItem.Text, txtA.Text, txtB.Text, txtC.Text, txtD.Text, txtCorrect.Text, cn)

        End If

    End Sub
End Class