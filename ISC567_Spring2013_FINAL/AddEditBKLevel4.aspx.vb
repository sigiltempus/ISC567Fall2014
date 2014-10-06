Imports JSIM.Bases.SVTable
Public Class AddEditBKLevel4
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
            AddNewBKLevel4()
        Else
            EditBKLevel4()
        End If
    End Sub

    Private Sub AddNewBKLevel4()
        dgFrame.Text = "Add BKLevel4"
        txtISModelID.Text = ""
        txtNumberL1.Text = ""
        txtNumberL2.Text = ""
        txtNumberL3.Text = ""
        txtNumberL4.Text = ""
        txtTitle.Text = ""
    End Sub

    Private Sub EditBKLevel4()
        dgFrame.Text = "Edit BK Level4"
        Dim BKLevel1ID As Integer = CInt(Session("BKLevel1ID"))
        Dim BKLevel4ID As Integer = CInt(Session("BKLevel4ID"))
        'Dim subskillid As Integer = 1
        Dim oBKLevel4 As New DataAccessTier.daBodyOfKnowledge
        Dim con As String = GetConnectionString("connectionString")
        Dim dtBKLevel4 As DataTable = oBKLevel4.GetBKLevel4Info(BKLevel4ID, con)
        If Not IsNothing(dtBKLevel4) AndAlso dtBKLevel4.Rows.Count > 0 Then
            With dtBKLevel4
                txtISModelID.Text = .Rows(0)("ISModelID").ToString()
                'txtBKLevel1ID.Text = .Rows(0)("BKLevel1ID").ToString()
                txtNumberL1.Text = .Rows(0)("NumberL1").ToString()
                txtNumberL2.Text = .Rows(0)("NumberL2").ToString()
                txtNumberL3.Text = .Rows(0)("NumberL3").ToString()
                txtNumberL4.Text = .Rows(0)("NumberL4").ToString()
                txtTitle.Text = .Rows(0)("title").ToString()
            End With

        End If

    End Sub
#End Region

#Region "Local Functions"
    Private Function AddEditBKLevel4(ByVal BKLevel4ID As Integer, ByVal programid As Integer,
                                     ByVal NumberL1 As Integer, ByVal NumberL2 As Integer, ByVal NumberL3 As Integer, ByVal NumberL4 As Integer,
                                     ByVal Title As String) As String
        Dim strStatus As String = "Error"
        Dim cn As String = GetConnectionString("connectionString")

        Dim BKLevel1ID As Integer = CInt(Session("BKLevel1ID"))
        'paramContainer.AddParameter("BKLevel1ID", CStr(BKLevel1ID), False)

        Dim BKLevel2ID As Integer = CInt(Session("BKLevel2ID"))
        'paramContainer.AddParameter("BKLevel2ID", CStr(BKLevel2ID), False)

        Dim BKLevel3ID As Integer = CInt(Session("BKLevel3ID"))

        Dim oBKLevel4 As New DataAccessTier.daBodyOfKnowledge
        oBKLevel4.AddEditBKLevel4Info(BKLevel4ID, programid, BKLevel1ID, BKLevel2ID, BKLevel3ID,
                                      NumberL1, NumberL2, NumberL3, NumberL4, Title, cn)

        If oBKLevel4.TransactionSuccessful Then
            strStatus = "Success"
        Else
            strStatus = " An error occured while trying to update BKLevel3: " & oBKLevel4.ErrorMessage
        End If

        Return strStatus
    End Function


#End Region

#Region "Events"
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim mode As String = Request.QueryString("mode") ' Get the actual mode from the Query string

        Dim strMsg As String = ""

        Dim BKLevel4ID As Integer = -1 ' Default value
        If mode = "edit" Then
            BKLevel4ID = CInt(Session("BKLevel4ID"))
        End If

        Try
            'Try to convert the value from the screen to appropriate data type and pass to add edit function
            strMsg = AddEditBKLevel4(BKLevel4ID, CInt(txtISModelID.Text), CInt(txtNumberL1.Text), CInt(txtNumberL2.Text), CInt(txtNumberL3.Text), CInt(txtNumberL4.Text), txtTitle.Text)

            If strMsg = "Success" Then
                '            if the Add/Edit was successful

                lblMessage.Text = "BKLevel4 was successfully " + mode + "ed"
            Else
                '            if there was an error trying to add/edit user
                lblMessage.ForeColor = Drawing.Color.Red
                lblMessage.Text = strMsg
            End If
        Catch ex As Exception
            '         if an exception occur trying to convert the user entered value to appropriate data type
            lblMessage.ForeColor = Drawing.Color.Red
            lblMessage.Text = ex.Message
            lblMessage.Visible = True
        End Try

        lblMessage.Visible = True
    End Sub

#End Region
End Class