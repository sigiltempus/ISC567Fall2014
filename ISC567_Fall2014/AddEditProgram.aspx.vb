Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class AddEditProgram
    Inherits JSIM.Bases.BaseClass

    Dim mode As String = "add" ' Assume add by default

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

#Region "Local Methods"
    Private Sub SetForm()
        mode = Request.QueryString("mode") ' Get the actual mode from the Query string

        LoadProgramStatus()
        Txtcurriculumname.Text = CStr(Session("selectedCurriculumName"))
        If mode = "add" Then
            AddNew()
        ElseIf mode = "edit" Then
            EditUser()
        End If
    End Sub

    Private Sub AddNew()
        lblTitle.Text = "Add New Model"

    End Sub
    Private Sub EditUser()
        lblTitle.Text = "Edit Model"

        Dim oProgram As New DataAccessTier.daProgram
        Dim dtProgramInfo As DataTable

        dtProgramInfo = oProgram.GetProgramInfoById(CInt(Session("selectedProgramId")), con)

        If Not IsNothing(dtProgramInfo) AndAlso dtProgramInfo.Rows.Count > 0 Then
            With dtProgramInfo
                txtShortName.Text = .Rows(0)("ProgramShortName").ToString()
                txtLongName.Text = .Rows(0)("ProgramName").ToString()
                txtDescription.Text = .Rows(0)("ProgramDescription").ToString()
                ddlProgramStatus.SelectedValue = .Rows(0)("ProgramStatusId").ToString()
            End With
        End If
    End Sub

    Private Sub LoadProgramStatus()
        Dim dtProgramStatus As DataTable
        Dim oProgram As New DataAccessTier.daProgram

        dtProgramStatus = oProgram.GetProgramStatusList(con)

        ddlProgramStatus.DataTextField = "ProgramStatus"
        ddlProgramStatus.DataValueField = "ProgramStatusId"
        ddlProgramStatus.DataSource = dtProgramStatus
        ddlProgramStatus.DataBind()

    End Sub

#End Region

#Region "Local Functions"
    Private Function AddEditUser(ByVal curriculumid As Integer, ByVal programId As Integer, ByVal shortName As String, ByVal longName As String,
                                 ByVal description As String, ByVal statusId As Integer) As String
        Dim strStatus As String = "Error"
        Dim cn As String = GetConnectionString("connectionString")
        Dim oProgram As New DataAccessTier.daProgram

        oProgram.AddEditProgramInformation(curriculumid, programId, shortName, longName, description, statusId, cn)

        If oProgram.TransactionSuccessful Then
            strStatus = "Success"
        Else
            strStatus = " An error occured while trying to update user: " & oProgram.ErrorMessage
        End If

        Return strStatus
    End Function
#End Region

#Region "Events"

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        mode = Request.QueryString("mode") ' Get the actual mode from the Query string

        Dim strMsg As String = ""
        Dim programId As Integer = -1 ' Default value
        Dim curriculumid As Integer

        curriculumid = CInt(Session("selectedcurriculumId"))

        If mode = "edit" Then
            programId = CInt(Session("selectedProgramId"))
        End If

        Try
            'Try to convert the value from the screen to appropriate data type and pass to add edit function
            strMsg = AddEditUser(curriculumid, programId, txtShortName.Text, txtLongName.Text, txtDescription.Text, CInt(ddlProgramStatus.SelectedValue))

            If strMsg = "Success" Then
                'if the Add/Edit was successful
                lblMessage.ForeColor = Drawing.Color.Green
                lblMessage.Text = "Program was successfully " + mode + "ed"
                'Response.Write("<script>parent.window.location.reload();</script>")
                'Response.End()


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
    End Sub

#End Region
    '#Region "Local WebService Methods"
    '    <Services.WebMethod()> _
    '    Public Shared Function wsAddEditBKLevel1(ByVal programId As Integer, ByVal shortName As String, ByVal longName As String,
    '                                 ByVal description As String, ByVal statusId As Integer) As String


    '    #End Function

    '#End Region
End Class