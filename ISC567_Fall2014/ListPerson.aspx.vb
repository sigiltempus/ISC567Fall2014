Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class ListPerson
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

#Region "Local Methods   "
    Private Sub SetForm()
        PopulateGVPersons()
    End Sub

    ' populates our gridview
    Private Sub PopulateGVPersons()
        Dim dtPersonList As DataTable = GetPersonList()
        Dim dvPersonList As DataView

        Try
            If Not IsNothing(dtPersonList) AndAlso dtPersonList.Rows.Count > 0 Then
                dvPersonList = dtPersonList.DefaultView
                dvPersonList.Sort = String.Format("{0} {1}", gvPersonList.GridSortColumn, gvPersonList.GridSortDirection.ToString())
                gvPersonList.DataSource = dvPersonList
                gvPersonList.DataBind()
            Else
                gvPersonList.DataSource = Nothing
                gvPersonList.DataBind()
            End If
        Catch ex As Exception
            lblErrorMessage.Text = ex.Message
            lblErrorMessage.Visible = True
        End Try
    End Sub
#End Region

#Region "Local Functions "
    ' Function that returns a list of Persons
    Private Function GetPersonList() As DataTable
        Dim dtPersonList As DataTable
        Dim oPerson As New DataAccessTier.daUser
        Dim cn As String = GetConnectionString("connectionString")
        dtPersonList = oPerson.GetPersonList(cn)
        If Not oPerson.TransactionSuccessful Then
            dtPersonList = Nothing
        End If
        Return dtPersonList
    End Function

    ' Deletes a Person given a Personid
    Private Function DeleteSelectedPerson(ByVal PersonID As Integer) As String
        Dim strStatus As String = "Error"
        Dim oPerson As New DataAccessTier.daUser
        Dim cn As String = GetConnectionString("connectionString")
        oPerson.DeletePersonById(PersonID, cn)
        If oPerson.TransactionSuccessful Then
            strStatus = "Success"
        Else
            strStatus = " An error occured while trying to delete user: " & AppUser.ErrorMessage
        End If
        Return strStatus
    End Function

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

#Region " Event "

    Private Sub gvPersonList_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvPersonList.Sorting
        PopulateGVPersons()
    End Sub

    Protected Sub gvPersonList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvPersonList.SelectedIndexChanged
        'Place selected data from Grid into the session variable
        Dim selectedPersonId As String = gvPersonList.SelectedValue.ToString()
        Session.Add("selectedPersonId", selectedPersonId)
    End Sub

    Protected Sub btnDeletePerson_Click(sender As Object, e As EventArgs) Handles btnDeletePerson.Click
        Dim strMsg As String = ""

        Dim personId As Integer = CInt(Session("selectedPersonId"))

        Try
            'Try to delete the person
            strMsg = DeleteSelectedPerson(personId)

            If strMsg = "Success" Then
                'if the delete was successful
                'if the Add/Edit was successful
                lblErrorMessage.ForeColor = Drawing.Color.Green
                lblErrorMessage.Text = "User was successfully deleted"
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

#End Region

End Class