Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Imports DataAccessTier.daUser


Public Class ExamProvider_11
    Inherits System.Web.UI.Page
    Dim oUser As New DataAccessTier.daUser
    Dim cn As String = GetConnectionString("connectionString")


    'Inherits JSIM.Bases.BaseClass
    'Dim cn As String = GetConnectionString("connectionString")
    'Dim id As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    setForm()
        'End If
        setForm()
        PopulateTextBox()
    End Sub

    'updated 11/30/2013
    Public Sub setForm()

        Dim oUser As New DataAccessTier.daUser
        Dim dtExamItem As DataTable
        Try
            Dim eid As Integer = CInt(Session("examid"))
            dtExamItem = oUser.GetExamItemByExam(eid, cn)
            Dim dtExamListView As DataView
            dtExamListView = dtExamItem.DefaultView()
            gvExamList.DataSource = dtExamListView
            gvExamList.DataBind()
        Catch ex As Exception
            lblErrorMessage.ForeColor = Drawing.Color.Red
            lblErrorMessage.Text = "No value selected for exam. Please close and try again."
        End Try

    End Sub

    'updated 11/30/2013
    Private Sub PopulateTextBox()
        Try
            Dim eid As Integer = CInt(Session("examid"))
            Dim dtExamInfo As DataTable = oUser.getExamNames(eid, cn)
            txtExam.Text = dtExamInfo.Rows(0).Item("examname").ToString()
            txtStatus.Text = dtExamInfo.Rows(0).Item("status").ToString()
            txtType.Text = dtExamInfo.Rows(0).Item("description").ToString()
        Catch ex As Exception

        End Try

    End Sub

    'Public Sub populategvExamItemList(cn)

    '    Dim oUser As New DataAccessTier.daUser
    '    Dim dtExamItem As DataTable
    '    dtExamItem() = oUser.GetExamItem(cn)
    '    Dim dtInstitutionExamsView As DataView
    '    dtExamItem() = dtExamItem.DefaultView()

    '    gvExamList.DataSource = dtInstitutionExamsView
    '    gvExamList.DataBind()

    'End Sub

    Protected Sub gvExamList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvExamList.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim rowView As DataRowView = CType(e.Row.DataItem, DataRowView)
            Dim questionType As String = rowView("QuestionType").ToString()
            Dim types As String() = questionType.Split(New Char() {"#"c})
            Dim count As Integer = 0
            Dim questions As String = ""
            Dim builder As New StringBuilder
            Dim questionCount As String = ""

            For Each question As String In types
                questionCount = CStr(count + 1)
                'questions = questions + "K" + questionCount + ":&nbsp;" + question + "\n"

                builder.Append("K" + questionCount + ":&nbsp;" + question + "<br/><br/>")

                count += 1
            Next

            e.Row.Cells(3).Text = builder.ToString

        End If
    End Sub
    Protected Sub gvExamList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvExamList.SelectedIndexChanged
        'Place selected data from Grid into the session variable
        Dim selectedItemId As String = gvExamList.SelectedValue.ToString()
        Session.Add("selectedItemId", selectedItemId)
        Session.Add("examItemId", selectedItemId)
    End Sub
    Private Function DeleteSelectedItem(ByVal examitemid As Integer) As String
        Dim strStatus As String = "Error"
        Dim oItem As New DataAccessTier.daUser
        Dim cn As String = GetConnectionString("connectionString")
        oItem.DeleteItemById(examitemid, cn)
        If oItem.TransactionSuccessful Then
            strStatus = "Success"
            setForm()
        Else
            strStatus = " An error occured while trying to delete user: " & AppUser.ErrorMessage
        End If
        Return strStatus
    End Function
    Protected Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        Dim strMsg As String = ""

        Dim examitemid As Integer = CInt(Session("selectedItemId"))

        Try
            'Try to delete the person
            strMsg = DeleteSelectedItem(examitemid)

            If strMsg = "Success" Then
                'if the delete was successful
                'if the Add/Edit was successful
                lblErrorMessage.ForeColor = Drawing.Color.Green
                lblErrorMessage.Text = "Item was successfully deleted"
                ' TODO: Refresh Screen/Person list
            Else
                'if there was an error trying to delete user
                lblErrorMessage.ForeColor = Drawing.Color.Red
                lblErrorMessage.Text = strMsg

            End If
        Catch ex As Exception
            ' if an exception occur
            lblErrorMessage.ForeColor = Drawing.Color.Red
            lblErrorMessage.Text = ex.Message
            lblErrorMessage.Visible = True
        End Try

        lblErrorMessage.Visible = True
    End Sub
End Class