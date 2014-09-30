Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class ExamProvider_4
    Inherits JSIM.Bases.BaseClass

    Dim cn As String = GetConnectionString("connectionString")
    Dim oUser As New DataAccessTier.daUser

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetForm()
    End Sub

    Protected Sub SetForm()
        'Gotta get providerid in there somewhere...
        Dim providerid As Integer
        providerid = CInt(Session("providerid"))
        ' Establish Connection String

        ' Instance of Data Access Tier

        'Retrieves the Institution's Staff
        Dim dtProviderInfo As DataTable = oUser.getExamProviderStaff(providerid, cn)

        staffGridView.DataSource = dtProviderInfo
        staffGridView.DataBind()


    End Sub

    'Private Sub gvExamProviderStaff_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvExamProviderStaff.SelectedIndexChanged
    '    'Retrieve the personid from the selected person and store it in the SV Table
    '    Dim row As GridViewRow = gvExamProviderStaff.SelectedRow
    '    Dim providerid As String
    '    providerid = row.Cells(0).Text
    '    InsertSVTableValue(Of String)("providerid", providerid)
    'End Sub

    Protected Sub staffGridView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles staffGridView.SelectedIndexChanged

        Session("examProviderStaffId") = staffGridView.SelectedValue


        Dim dtPersonInfo As DataTable = oUser.getPersonAsExamProviderStaff(CInt(Session("examProviderStaffId")), cn)

        Session("selectedPersonId") = dtPersonInfo.Rows(0)("personid").ToString()
    End Sub


End Class
