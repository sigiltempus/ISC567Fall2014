Imports JSIM.Bases.SVTable
Public Class AddEditBKLevel3
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
            AddNewBKLevel3()
        Else
            EditBKLevel3()
        End If
    End Sub

    Private Sub AddNewBKLevel3()
        dgFrame.Text = "Add BKLevel3"
        txtISModelID.Text = ""
        txtNumberL1.Text = ""
        txtNumberL2.Text = ""
        txtNumberL3.Text = ""
        txtTitle.Text = ""
    End Sub

    Private Sub EditBKLevel3()
        dgFrame.Text = "Edit BK Level3"
        Dim BKLevel1ID As Integer = CInt(Session("BKLevel1ID"))
        Dim BKLevel3ID As Integer = CInt(Session("BKLevel3ID"))
        'Dim subskillid As Integer = 1
        Dim oBKLevel3 As New DataAccessTier.daBodyOfKnowledge
        Dim con As String = GetConnectionString("connectionString")
        Dim dtBKLevel3 As DataTable = oBKLevel3.GetBKLevel3Info(BKLevel3ID, con)
        If Not IsNothing(dtBKLevel3) AndAlso dtBKLevel3.Rows.Count > 0 Then
            With dtBKLevel3
                txtISModelID.Text = .Rows(0)("ISModelID").ToString()
                'txtBKLevel1ID.Text = .Rows(0)("BKLevel1ID").ToString()
                txtNumberL1.Text = .Rows(0)("NumberL1").ToString()
                txtNumberL2.Text = .Rows(0)("NumberL2").ToString()
                txtNumberL3.Text = .Rows(0)("NubmerL3").ToString()
                txtTitle.Text = .Rows(0)("title").ToString()
            End With

        End If

    End Sub
#End Region

#Region "Local Functions"
    Private Function AddEditBKLevel3(ByVal BKLevel3ID As Integer, ByVal programid As Integer, ByVal NumberL1 As Integer,
                                     ByVal NumberL2 As Integer, ByVal NumberL3 As Integer, ByVal Title As String) As String
        Dim strStatus As String = "Error"
        Dim cn As String = GetConnectionString("connectionString")

        Dim BKLevel1ID As Integer = CInt(Session("BKLevel1ID"))
        'paramContainer.AddParameter("BKLevel1ID", CStr(BKLevel1ID), False)

        Dim BKLevel2ID As Integer = CInt(Session("BKLevel2ID"))
        'paramContainer.AddParameter("BKLevel2ID", CStr(BKLevel2ID), False)

        Dim oBKLevel3 As New DataAccessTier.daBodyOfKnowledge
        oBKLevel3.AddEditBKLevel3Info(BKLevel3ID, programid, BKLevel1ID, BKLevel2ID, NumberL1, NumberL2, NumberL3, Title, cn)

        If oBKLevel3.TransactionSuccessful Then
            strStatus = "Success"
        Else
            strStatus = " An error occured while trying to update BKLevel3: " & oBKLevel3.ErrorMessage
        End If

        Return strStatus
    End Function

    
#End Region

#Region "Events"
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim mode As String = Request.QueryString("mode") ' Get the actual mode from the Query string

        Dim strMsg As String = ""

        Dim BKLevel3ID As Integer = -1 ' Default value
        If mode = "edit" Then
            BKLevel3ID = CInt(Session("BKLevel3ID"))
        End If

        Try
            'Try to convert the value from the screen to appropriate data type and pass to add edit function
            strMsg = AddEditBKLevel3(BKLevel3ID, CInt(txtISModelID.Text), CInt(txtNumberL1.Text), CInt(txtNumberL2.Text), CInt(txtNumberL3.Text), txtTitle.Text)

            If strMsg = "Success" Then
                '            if the Add/Edit was successful

                lblMessage.Text = "BKLevel3 was successfully " + mode + "ed"
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