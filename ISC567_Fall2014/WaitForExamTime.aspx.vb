Imports JSIM.Bases.SVTable
Public Class WaitForExamTime
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetForm()
    End Sub

    Private Sub SetForm()
        Dim cn As String = GetConnectionString("connectionString")

        ' Instance of Data Access Tier
        Dim oUser As New DataAccessTier.daUser

        Dim dtExamprofile As DataTable = oUser.GetExamDetails(1, cn)
        'Dim localfirstname As String = GetSVTableValue(Of String)("firstname")
        'Dim locallastname As String = GetSVTableValue(Of String)("lastname")
        Dim User As New DataAccessTier.daUser
        lblName.Text = Session("Lastname").ToString
        ' txtName.Text = .Rows(0)("FirstName").ToString() + " " + .Rows(0)("LastName").ToString()
        lblCourse.Text = dtExamprofile.Rows(0)(0).ToString

        lblDate.Text = dtExamprofile.Rows(0)(1).ToString
        lblTime.Text = dtExamprofile.Rows(0)(2).ToString
        lblTimeRem.Text = dtExamprofile.Rows(0)(4).ToString
        'txtTimeRem.Text = Convert.ToString(Session("ExamTime"))
    End Sub


    Protected Sub lbtnClose_Click(sender As Object, e As EventArgs) Handles lbtnClose.Click
        Response.Redirect("Roster.aspx")

    End Sub
End Class

