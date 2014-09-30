Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class ConfirmationPage
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

    Private Sub SetForm()
        populatepage()
    End Sub
    Private Sub populatepage()
        Dim personid As Integer = GetSVTableValue(Of Integer)("personid")
        Dim SEID As Integer = CInt(Session("SelScheduleExamID").ToString())
        Dim oUser As New DataAccessTier.daUser
        Dim dtpersonInfo As DataTable
        Dim dtExamInfo As DataTable
        Dim cn As String = GetConnectionString("ConnectionString")
        dtpersonInfo = oUser.GetUserProfileByID(personid, cn)
        dtExamInfo = oUser.GetExambyID(SEID, cn)

        If Not IsNothing(dtpersonInfo) AndAlso dtpersonInfo.Rows.Count > 0 Then
            With dtpersonInfo
                txtName.Text = .Rows(0)("FirstName").ToString() + " " + .Rows(0)("LastName").ToString()
                txtAddress.Text = .Rows(0)("address1").ToString()
                lblCity.Text = .Rows(0)("city").ToString()
                lblSt.Text = .Rows(0)("st").ToString()
                lblZip.Text = .Rows(0)("zip").ToString()
            End With
        End If

        If Not IsNothing(dtExamInfo) AndAlso dtExamInfo.Rows.Count > 0 Then
            With dtExamInfo
                lblexamName.Text = .Rows(0)("examname").ToString()
                lblDate.Text = .Rows(0)("examdate").ToString()
                lblLocation.Text = .Rows(0)("examlocation").ToString()
                lblTime.Text = .Rows(0)("starttime").ToString()
            End With
        End If
    End Sub
End Class
