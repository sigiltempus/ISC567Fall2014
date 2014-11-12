Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class AddEditCurriculum
    Inherits System.Web.UI.Page

    Dim mode As String = "add" ' Assume add by default

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

#Region "Local Methods"
    Private Sub SetForm()
        mode = Request.QueryString("mode") ' Get the actual mode from the Query string

       If mode = "add" Then
            AddNew()
        ElseIf mode = "edit" Then
            EditUser()
        End If
    End Sub

    Private Sub AddNew()
        lblTitle.Text = "Add New Curriculum"
    End Sub

    Private Sub EditUser()
        lblTitle.Text = "Edit Curriculum"

        Dim oCurriculum As New DataAccessTier.daProgram
        Dim dtCurriculumInfo As DataTable

        dtCurriculumInfo = oCurriculum.GetCurriculumById(CInt(Session("selectedCurriculumId")), con)

        If Not IsNothing(dtCurriculumInfo) AndAlso dtCurriculumInfo.Rows.Count > 0 Then
            With dtCurriculumInfo
                txtShortName.Text = .Rows(0)("curriculum_shortname").ToString()
                txtLongName.Text = .Rows(0)("curriculum_longname").ToString()
            End With
        End If
    End Sub

#End Region

#Region "Local Functions"
    Private Function AddEditUser(ByVal CurriculumId As Integer, ByVal shortName As String, ByVal longName As String) As String
        Dim strStatus As String = "Error"
        Dim cn As String = GetConnectionString("connectionString")
        Dim oCurriculum As New DataAccessTier.daProgram
        If mode = "add" Then
            oCurriculum.InsertCurriculumInformation(shortName, longName, cn)
        ElseIf mode = "edit" Then
            oCurriculum.EditCurriculumInformation(CurriculumId, shortName, longName, cn)
        End If


        If oCurriculum.TransactionSuccessful Then
            strStatus = "Success"
        Else
            strStatus = " An error occured while trying to update user: " & oCurriculum.ErrorMessage
        End If

        Return strStatus
    End Function
#End Region

#Region "Events"

    Protected Sub btnCSave_Click(sender As Object, e As EventArgs) Handles btnCSave.Click
        mode = Request.QueryString("mode") ' Get the actual mode from the Query string

        Dim strMsg As String = ""

        Dim CurriculumId As Integer = -1 ' Default value
        If mode = "edit" Then
            CurriculumId = CInt(Session("selectedCurriculumId"))
        End If

        Try
            'Try to convert the value from the screen to appropriate data type and pass to add edit function
            strMsg = AddEditUser(CurriculumId, txtShortName.Text, txtLongName.Text)

            If strMsg = "Success" Then
                'if the Add/Edit was successful
                lblMessage.ForeColor = Drawing.Color.Green
                lblMessage.Text = "Curriculum was successfully " + mode + "ed"
                'Response.Write("<script>parent.window.location.reload();</script>")
                Response.End()

            Else
                'if there was an error trying to add/edit user
                lblMessage.ForeColor = Drawing.Color.Red
                lblMessage.Text = strMsg
            End If
        Catch ex As Exception
            ' if an exception occur trying to convert the user entered value to appropriate data type
            lblMessage.ForeColor = Drawing.Color.Red
            lblMessage.Text = ex.Message
            lblMessage.Visible = True
        End Try

        lblMessage.Visible = True
        Response.End()

    End Sub

#End Region

End Class