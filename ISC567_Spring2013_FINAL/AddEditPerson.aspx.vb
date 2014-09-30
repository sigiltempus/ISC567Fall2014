Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class AddEditPerson
    Inherits JSIM.Bases.BaseClass

    Dim mode As String = "add" ' Assume add by default
    Dim parentScreen As String = "lstPerson" ' Assume lstPerson is calling it in default case

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

#Region "Local Methods"
    Private Sub SetForm()
        mode = Request.QueryString("mode") ' Get the actual mode from the Query string
        parentScreen = Request.QueryString("caller") ' Get the actual caller/parent from the Query string

        LoadInstitution()
        LoadProvider()
        LoadUserRoleChkBox()

        If mode = "add" Then
            AddNew()
        ElseIf mode = "edit" Then
            EditUser()
        End If
    End Sub

    Private Sub AddNew()
        lblTitle.Text = "Add New Person"
    End Sub

    Private Sub EditUser()
        lblTitle.Text = "Edit User"
        Dim dtUserInfo As DataTable

        dtUserInfo = AppUser.GetUserProfileByID(CInt(Session("selectedPersonId")), con)

        If Not IsNothing(dtUserInfo) AndAlso dtUserInfo.Rows.Count > 0 Then
            With dtUserInfo
                ddlInstitution.SelectedValue = .Rows(0)("institutionid").ToString()
                ddlProvider.SelectedValue = .Rows(0)("providerId").ToString()
                txtFirstName.Text = .Rows(0)("firstname").ToString()
                txtLastName.Text = .Rows(0)("lastname").ToString()
                txtEmail.Text = .Rows(0)("email").ToString()
                txtDateOfBirth.Value = .Rows(0)("dob").ToString()
                txtAddress1.Text = .Rows(0)("address1").ToString()
                txtAddress2.Text = .Rows(0)("address2").ToString()
                txtCity.Text = .Rows(0)("City").ToString()
                txtState.Text = .Rows(0)("st").ToString()
                txtZip.Text = .Rows(0)("zip").ToString()
                txtPrimaryPhone.Text = .Rows(0)("phonenumber1").ToString()
                ddlPhoneType1.SelectedValue = .Rows(0)("phonenumber1type").ToString()
                txtAlternatePhone.Text = .Rows(0)("phonenumber2").ToString()
                ddlPhoneType2.SelectedValue = .Rows(0)("phonenumber2type").ToString()
                txtUserName.Text = .Rows(0)("username").ToString()
                ' Set the text as value attributes for password fields
                txtPassword.Attributes.Add("value", .Rows(0)("password").ToString())
                txtPasswordConfirm.Attributes.Add("value", .Rows(0)("password").ToString())

                ' Loop throgh each checkbox in the checkbox list to set its checked status
                For Each chkBx As ListItem In chkBxRoleLists.Items
                    If chkBx.ToString() = "Is SA" Then
                        chkBx.Selected = CBool(.Rows(0)("isSA"))
                    End If
                    If chkBx.ToString() = "Is Reports" Then
                        chkBx.Selected = CBool(.Rows(0)("isReports"))
                    End If
                    If chkBx.ToString() = "Is Taker" Then
                        chkBx.Selected = CBool(.Rows(0)("isTaker"))
                    End If
                    If chkBx.ToString() = "Is Provider" Then
                        chkBx.Selected = CBool(.Rows(0)("isProvider"))
                    End If
                    If chkBx.ToString() = "Is EPSA" Then
                        chkBx.Selected = CBool(.Rows(0)("isEPSA"))
                    End If
                    If chkBx.ToString() = "Is Developer" Then
                        chkBx.Selected = CBool(.Rows(0)("isDeveloper"))
                    End If
                    If chkBx.ToString() = "Is Institution" Then
                        chkBx.Selected = CBool(.Rows(0)("isInstitution"))
                    End If
                    If chkBx.ToString() = "Is ISA" Then
                        chkBx.Selected = CBool(.Rows(0)("isISA"))
                    End If
                    If chkBx.ToString() = "Is Proctor" Then
                        chkBx.Selected = CBool(.Rows(0)("isProctor"))
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub LoadInstitution()
        Dim dtInstitutionNames As DataTable
        Dim oInstitution As New DataAccessTier.daInstitution

        dtInstitutionNames = oInstitution.GetInstitutionList(con)

        ddlInstitution.DataTextField = "name"
        ddlInstitution.DataValueField = "institutionid"
        ddlInstitution.DataSource = dtInstitutionNames
        ddlInstitution.DataBind()

        ddlInstitution.Items.Insert(0, New ListItem("-- Select Institution --", "-1"))

    End Sub

    Private Sub LoadProvider()
        Dim dtProviderNames As DataTable
        Dim oProvider As New DataAccessTier.daProvider

        dtProviderNames = oProvider.GetProvidersList(con)

        ddlProvider.DataTextField = "name"
        ddlProvider.DataValueField = "providerid"
        ddlProvider.DataSource = dtProviderNames
        ddlProvider.DataBind()

        ddlProvider.Items.Insert(0, New ListItem("-- Select Provider --", "-1"))

    End Sub

    Private Sub LoadUserRoleChkBox()
        chkBxRoleLists.Items.Clear() ' Remove all the items if exists

        ' If a person is trying to register, allow them to be a taker
        If parentScreen = "register" Then
            chkBxRoleLists.Items.Insert(0, "Is Taker")
            ' If the person isSA or the screen is launched from List Person then allow all Roles
        ElseIf isSA Or parentScreen = "lstPerson" Then
            chkBxRoleLists.Items.Insert(0, "Is SA")
            chkBxRoleLists.Items.Insert(1, "Is Provider")
            chkBxRoleLists.Items.Insert(2, "Is Institution")
            chkBxRoleLists.Items.Insert(3, "Is Reports")
            chkBxRoleLists.Items.Insert(4, "Is EPSA")
            chkBxRoleLists.Items.Insert(5, "Is ISA")
            chkBxRoleLists.Items.Insert(6, "Is Taker")
            chkBxRoleLists.Items.Insert(7, "Is Developer")
            chkBxRoleLists.Items.Insert(8, "Is Proctor")
        ElseIf isProvider Or parentScreen = "lstExamProvider" Then
            If isInstitution Then
                chkBxRoleLists.Items.Insert(0, "Is Provider")
                chkBxRoleLists.Items.Insert(1, "Is Institution")
                chkBxRoleLists.Items.Insert(2, "Is Taker")
                chkBxRoleLists.Items.Insert(3, "Is EPSA")
                chkBxRoleLists.Items.Insert(4, "Is ISA")
                chkBxRoleLists.Items.Insert(5, "Is Developer")
                chkBxRoleLists.Items.Insert(6, "Is Proctor")
            Else
                chkBxRoleLists.Items.Insert(0, "Is Provider")
                chkBxRoleLists.Items.Insert(1, "Is Taker")
                chkBxRoleLists.Items.Insert(2, "Is EPSA")
                chkBxRoleLists.Items.Insert(3, "Is Developer")
            End If
        ElseIf isInstitution Or parentScreen = "lstInstPeople" Then
            If isProvider Then
                chkBxRoleLists.Items.Insert(0, "Is Provider")
                chkBxRoleLists.Items.Insert(1, "Is Institution")
                chkBxRoleLists.Items.Insert(2, "Is Taker")
                chkBxRoleLists.Items.Insert(3, "Is EPSA")
                chkBxRoleLists.Items.Insert(4, "Is ISA")
                chkBxRoleLists.Items.Insert(5, "Is Developer")
                chkBxRoleLists.Items.Insert(6, "Is Proctor")
            Else
                chkBxRoleLists.Items.Insert(0, "Is Institution")
                chkBxRoleLists.Items.Insert(1, "Is Taker")
                chkBxRoleLists.Items.Insert(2, "Is ISA")
                chkBxRoleLists.Items.Insert(3, "Is Proctor")
            End If
        End If
    End Sub

#End Region

#Region "Local Functions"
    Private Function AddEditUser(ByVal personId As Integer, ByVal institutionId As Integer, ByVal providerId As Integer, ByVal firstName As String, ByVal lastName As String,
                                 ByVal dob As Date, ByVal email As String, ByVal address1 As String, ByVal address2 As String,
                                 ByVal city As String, ByVal state As String, ByVal zip As String, ByVal phoneNumber1 As String, ByVal phoneNumber1Type As String,
                                 ByVal phoneNumber2 As String, ByVal phoneNumber2Type As String, ByVal username As String, ByVal password As String,
                                 ByVal isSA As Boolean, ByVal isReports As Boolean, ByVal isTaker As Boolean, ByVal isProvider As Boolean, ByVal isEPSA As Boolean,
                                 ByVal isDeveloper As Boolean, ByVal isInstitution As Boolean, ByVal isISA As Boolean, ByVal isProctor As Boolean) As String
        Dim strStatus As String = "Error"
        Dim cn As String = GetConnectionString("connectionString")

        AppUser.AddEditPersonInformation(personId, institutionId, providerId, firstName, lastName, dob, email, address1, address2, city, state, zip,
                                         phoneNumber1, phoneNumber1Type, phoneNumber2, phoneNumber2Type, username, password, isTaker,
                                         isProvider, isInstitution, isSA, isISA, isProctor, isReports, isEPSA, isDeveloper, cn)

        If AppUser.TransactionSuccessful Then
            strStatus = "Success"

            UpdateSVT = True
        Else
            strStatus = " An error occured while trying to update user: " & AppUser.ErrorMessage
        End If

        Return strStatus
    End Function
#End Region

#Region "Events"

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        mode = Request.QueryString("mode") ' Get the actual mode from the Query string

        Dim isSAChecked As Boolean = False
        Dim isReportsChecked As Boolean = False
        Dim isTakerChecked As Boolean = False
        Dim isProviderChecked As Boolean = False
        Dim isEPSAChecked As Boolean = False
        Dim isDeveloperChecked As Boolean = False
        Dim isInstitutionChecked As Boolean = False
        Dim isISAChecked As Boolean = False
        Dim isProctorChecked As Boolean = False

        Dim strMsg As String = ""

        Dim personId As Integer = -1 ' Default value
        If mode = "edit" Then
            personId = CInt(Session("selectedPersonId"))
        End If

        ' Loop throgh each checkbox in the checkbox list to set its checked status
        For Each chkBx As ListItem In chkBxRoleLists.Items
            If chkBx.ToString() = "Is SA" Then
                isSAChecked = chkBx.Selected
            End If
            If chkBx.ToString() = "Is Reports" Then
                isReportsChecked = chkBx.Selected
            End If
            If chkBx.ToString() = "Is Taker" Then
                isTakerChecked = chkBx.Selected
            End If
            If chkBx.ToString() = "Is Provider" Then
                isProviderChecked = chkBx.Selected
            End If
            If chkBx.ToString() = "Is EPSA" Then
                isEPSAChecked = chkBx.Selected
            End If
            If chkBx.ToString() = "Is Developer" Then
                isDeveloperChecked = chkBx.Selected
            End If
            If chkBx.ToString() = "Is Institution" Then
                isInstitutionChecked = chkBx.Selected
            End If
            If chkBx.ToString() = "Is ISA" Then
                isISAChecked = chkBx.Selected
            End If
            If chkBx.ToString() = "Is Proctor" Then
                isProctorChecked = chkBx.Selected
            End If
        Next

        Try
            'Try to convert the value from the screen to appropriate data type and pass to add edit function
            strMsg = AddEditUser(personId, CInt(ddlInstitution.SelectedValue), CInt(ddlProvider.SelectedValue), txtFirstName.Text, txtLastName.Text, CDate(txtDateOfBirth.Value), txtEmail.Text, txtAddress1.Text, txtAddress2.Text,
                                 txtCity.Text, txtState.Text, txtZip.Text, txtPrimaryPhone.Text, ddlPhoneType1.SelectedValue, txtAlternatePhone.Text, ddlPhoneType2.SelectedValue,
                                 txtUserName.Text, txtPassword.Text, isSAChecked, isReportsChecked, isTakerChecked, isProviderChecked, isEPSAChecked, isDeveloperChecked,
                                 isInstitutionChecked, isISAChecked, isProctorChecked)

            If strMsg = "Success" Then
                'if the Add/Edit was successful
                lblMessage.ForeColor = Drawing.Color.Green
                lblMessage.Text = "User was successfully " + mode + "ed"

                ' Since user is still in the same screen -- update the mode for further change to the same person
                ' TODO: mode = "edit" and retrieve the new PersonID as well
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

    'Protected Sub chkBxIsProvider_CheckedChanged(sender As Object, e As EventArgs) Handles chkBxIsProvider.CheckedChanged
    '    ' Enable the type of Provider roles if the isProvider is checked
    '    If chkBxIsProvider.Checked Then
    '        chkBxIsEPSA.Enabled = True
    '        chkBxIsDeveloper.Enabled = True
    '    Else
    '        ' When is provider is not checked, one cannot take the role of EPSA or Developer
    '        chkBxIsEPSA.Checked = False
    '        chkBxIsEPSA.Enabled = False
    '        'Developer
    '        chkBxIsDeveloper.Checked = False
    '        chkBxIsDeveloper.Enabled = False
    '    End If
    'End Sub

    'Protected Sub chkBxIsInstitution_CheckedChanged(sender As Object, e As EventArgs) Handles chkBxIsInstitution.CheckedChanged
    '    ' Enable the type of institution roles if the isInstitution is checked
    '    If chkBxIsInstitution.Checked Then
    '        chkBxIsISA.Enabled = True
    '        chkBxIsProctor.Enabled = True
    '    Else
    '        ' When is provider is not checked, one cannot take the role of ISA or Proctor
    '        chkBxIsISA.Checked = False
    '        chkBxIsISA.Enabled = False
    '        'Proctor
    '        chkBxIsProctor.Checked = False
    '        chkBxIsProctor.Enabled = False
    '    End If
    'End Sub

#End Region
End Class