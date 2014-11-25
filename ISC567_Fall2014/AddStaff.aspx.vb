Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class WorkOnStaff
    Inherits JSIM.Bases.BaseClass

    Dim cn As String = GetConnectionString("connectionString")
    Dim mode As String
    Dim oUser As New DataAccessTier.daUser
    Dim providerid As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

    Protected Sub SetForm()

        providerid = CInt(Session("providerid"))
        mode = Request.QueryString("mode")

        Dim dtProviderInfo As DataTable = oUser.getPersonsNotAsProviderStaff(providerid, cn)

        CGVRosterNotProvider.DataSource = dtProviderInfo
        CGVRosterNotProvider.DataBind()

        If mode = "add" Then
            AddProviderMethod()
        ElseIf mode = "edit" Then
            EditProviderMethod()
        End If
    End Sub


    Private Sub AddProviderMethod()
        Dim dtProviderInfo As DataTable = oUser.getPersonsNotAsProviderStaff(providerid, cn)
        ddlName.Visible = True
        nameValue.Visible = False

        ddlName.DataSource = dtProviderInfo
        ddlName.DataTextField = "personName"
        ddlName.DataValueField = "personid"
        ddlName.DataBind()
    End Sub


    Private Sub EditProviderMethod()
        Dim pid As Integer = CInt(Session("examProviderStaffId"))
        Dim dtProviderInfo As DataTable = oUser.getExamProviderStaffName(pid, cn)
        ddlName.Visible = False
        nameValue.Visible = True

        nameValue.Text = dtProviderInfo.Rows(0).Item("personName").ToString()
        isEPSA.Checked = CBool(dtProviderInfo.Rows(0).Item("isEPSA").ToString())
        isDeveloper.Checked = CBool(dtProviderInfo.Rows(0).Item("isdeveloper").ToString())
    End Sub

    Protected Sub saveProvider_Click(sender As Object, e As EventArgs) Handles saveProvider.Click
        Dim isd As Boolean
        Dim isa As Boolean

        mode = Request.QueryString("mode")

        If Not isEPSA.Checked Then
            isa = False
        Else
            isa = True
        End If

        If Not isDeveloper.Checked Then
            isd = False
        Else
            isd = True
        End If

        Dim providerid As Integer = Convert.ToInt32(Session("providerid"))

        If mode = "add" Then
            oUser.addOrUpdateProviderStaff(-1, providerid, CInt(ddlName.SelectedValue),isa, isd, cn)
        ElseIf mode = "edit" Then
            Dim pid As Integer = CInt(Session("examProviderStaffId"))
            ' we do not need person id, so value is hard coded and never used in the update
            oUser.addOrUpdateProviderStaff(pid, providerid, 0, isa, isd, cn)
        End If
    End Sub
End Class