Imports JSIM.Bases.SVTable


Public Class AddProvider
    Inherits JSIM.Bases.BaseClass
    Dim cn As String = GetConnectionString("connectionString")
    Dim mode As String
    Public Shared prvdrid As Integer = GetSVTableValue(Of Integer)("providerid")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If

    End Sub

    Protected Sub SetForm()
        mode = Request.QueryString("mode")
        If mode = "add" Then
            AddProviderMethod()
        ElseIf mode = "edit" Then
            EditProviderMethod()
        End If
    End Sub
    Private Sub AddProviderMethod()

    End Sub
    Private Sub EditProviderMethod()
        Dim AppUser As New DataAccessTier.daUser

        Dim dtUserInfo As DataTable

        dtUserInfo = AppUser.GetProviderListforEdit(CInt(Session("providerid")), cn)

        If Not IsNothing(dtUserInfo) AndAlso dtUserInfo.Rows.Count > 0 Then
            With dtUserInfo

                txtName.Text = .Rows(0)("name").ToString()
                txtAddress1.Text = .Rows(0)("address1").ToString()
                txtAddress2.Text = .Rows(0)("address2").ToString()
                txtCity.Text = .Rows(0)("City").ToString()
                txtState.Text = .Rows(0)("st").ToString()
                txtZip.Text = .Rows(0)("zip").ToString()
                txtCountry.Text = .Rows(0)("country").ToString()
                txtWeburl.Text = .Rows(0)("weburl").ToString()
                chkBxIsEPSA.Checked = False
                'CBool(.Rows(0)("isdeleted"))
                chkBxIsDeveloper.Checked = False
                'CBool(.Rows(0)("isaccredited"))
            End With
        End If

    End Sub


    Protected Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click

        Dim ouser As New DataAccessTier.daUser


        Dim format As String = "MM/dd/yyyy hh:mm:ss.fff"
        Dim dt As DateTime = DateAndTime.Now
        'DateTime.ParseExact("05/15/2012 10:09:28.650",
        '                                format,
        '                                System.Globalization.CultureInfo.InvariantCulture)
        Dim dtnew As DateTime = DateAndTime.Now
        ' DateTime.ParseExact("05/15/2012 10:09:28.650",
        '                          format,
        '                         System.Globalization.CultureInfo.InvariantCulture)


        Dim isd As Boolean
        
        Dim isa As Boolean
        mode = Request.QueryString("mode")
        If Not chkBxIsDeveloper.Checked Then
            isd = False
        Else
            isd = True

        End If
        If Not chkBxIsEPSA.Checked Then
            isa = False
        Else
            isa = True

        End If

        If mode = "add" Then
            Dim id As Integer = Convert.ToInt32(Session("personid"))

            Dim idnew As Integer = Convert.ToInt32(Session("personid"))

            ouser.AddorUpdateProvider(-1, txtName.Text, txtAddress1.Text, txtAddress2.Text, txtCity.Text,
                                  txtState.Text, Convert.ToInt32(txtZip.Text), txtCountry.Text,
                                  txtWeburl.Text, isd, isa, dt, id, dtnew, idnew, cn)
        ElseIf mode = "edit" Then
            Dim id As Integer = Convert.ToInt32(Session("personid"))

            Dim idnew As Integer = Convert.ToInt32(Session("personid"))

            Dim pid = Session("providerid")


            '<<<<<<<<<--------------- 9 is hardcoded instead of providerID'-------------->>>>>>>>>>>>
            ouser.AddorUpdateProvider(CInt(pid), txtName.Text, txtAddress1.Text, txtAddress2.Text, txtCity.Text,
                                 txtState.Text, Convert.ToInt32(txtZip.Text), txtCountry.Text,
                                 txtWeburl.Text, isd, isa, dt, id, dtnew, idnew, cn)
        End If






        ' We are inserting provider so we give provide providerID as -1

    End Sub
End Class