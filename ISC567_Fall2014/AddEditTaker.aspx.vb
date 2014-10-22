Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class AddEditTaker
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
            ' AddNew()
        ElseIf mode = "edit" Then
            EditUser()
        Else
            'TO DO: Display Error message no mode was given
        End If

        btnSave.Parameters = CreateParameters()
    End Sub
    Private Sub EditUser()
        lblHeader.Text = "Edit User"
        Dim dtUserInfo As DataTable

        dtUserInfo = AppUser.GetUserProfileByID(personid, con)

        If Not IsNothing(dtUserInfo) AndAlso dtUserInfo.Rows.Count > 0 Then
            With dtUserInfo
                txtFirstName.Text = .Rows(0)("FirstName").ToString()
                txtLastName.Text = .Rows(0)("LastName").ToString()
                txtAddress1.Text = .Rows(0)("address1").ToString()
                txtAddress2.Text = .Rows(0)("address2").ToString()
                txtCity.Text = .Rows(0)("City").ToString()
                txtState.Text() = .Rows(0)("st").ToString()
                txtzip.Text() = .Rows(0)("zip").ToString()
                txtPhoneNum.Text() = .Rows(0)("phonenumber1").ToString()
                txtUserName.Text() = .Rows(0)("username").ToString()
                txtPassword.Text() = .Rows(0)("password").ToString()
                txtEmail.Text() = .Rows(0)("email").ToString()
            End With
        Else
            ' Todo: Display Error Message
        End If
    End Sub

    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        'Creates a new parameter container
        MyBase.paramContainer = New JSIM.ParameterContainer()

        Dim mode As String = Request.QueryString("mode")
        paramContainer.AddParameter("mode", mode, False)
        paramContainer.AddParameter("FirstName", txtFirstName)
        paramContainer.AddParameter("LastName", txtLastName)
        paramContainer.AddParameter("address1", txtAddress1)
        paramContainer.AddParameter("address2", txtAddress2)
        paramContainer.AddParameter("city", txtCity)
        paramContainer.AddParameter("st", txtState)
        paramContainer.AddParameter("zip", txtzip)
        paramContainer.AddParameter("phonenumber1", txtPhoneNum)
        paramContainer.AddParameter("username", txtUserName)
        paramContainer.AddParameter("password", txtPassword)
        paramContainer.AddParameter("email", txtEmail)


        Dim PersonID As Integer = (GetSVTableValue(Of Integer)("personid"))
        paramContainer.AddParameter("Personid", CStr(PersonID), False)

        Return MyBase.CreateParameters()

    End Function
#End Region
#Region "Local Functions"
    Private Shared Function UpdateUser(ByVal PersonID As Integer, ByVal FirstName As String, ByVal LastName As String,
                               ByVal address1 As String, ByVal address2 As String, ByVal city As String,
                               ByVal st As String, ByVal zip As String,
                               ByVal phonenumber1 As String, ByVal username As String,
                               ByVal password As String, ByVal email As String) As String
        Dim StrStatus As String = ""
        Dim cn As String = GetConnectionString("connectionString")
        Dim oUser As New DataAccessTier.daUser
        AppUser.UpdateUser(PersonID, FirstName, LastName, address1, address2, city, st, zip, phonenumber1, username, password, email, cn)

        If oUser.TransactionSuccessful Then
            StrStatus = "User was successfully updated"

        Else
            StrStatus = " An error occured while trying to update user: " & oUser.ErrorMessage
        End If
        UpdateSVT = True
        Return StrStatus
    End Function
#End Region

#Region "Local WEbservice Methods"
    <Services.WebMethod()> _
    Public Shared Function wsAddEditUser(ByVal mode As String, ByVal FirstName As String, ByVal LastName As String,
                                         ByVal address1 As String, ByVal address2 As String, ByVal city As String, ByVal st As String,
                                         ByVal zip As String, ByVal phonenumber1 As String, ByVal username As String,
                                         ByVal password As String, ByVal email As String,
                                         ByVal PersonID As Integer) As String
        Dim strMsg As String = ""
        If mode = "add" Then
            'Add Record
            'TODO Add a user in this if statement call insertuser method in DA tier
            'and proceed accordingly. Also authorize the person before allowing them 
            'to add a user - Ali 4/2/2012
            strMsg = ""
        ElseIf mode = "edit" Then
            'Edit Record
            strMsg = UpdateUser(PersonID, FirstName, LastName, address1, address2, city, st, zip, phonenumber1, username, password, email)

        Else
            strMsg = "No mode were specified no operation could be formed"
        End If

        Return strMsg
    End Function
#End Region

End Class
