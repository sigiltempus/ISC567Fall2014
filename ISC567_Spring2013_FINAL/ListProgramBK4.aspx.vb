Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class ListProgramBK4
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            setform()
        End If
    End Sub
    Private Sub setform()
        PopulateGVBKLevel4()
    End Sub
    Private Sub PopulateGVBKLevel4()
        'Populate the Gridview for Body OF Knowledge BKLevel2 based on BKLevel1
        Dim dtBKLevel4 As DataTable = GetBKLevel4List()
        If Not IsNothing(dtBKLevel4) AndAlso dtBKLevel4.Rows.Count > 0 Then
            ProjectsGridView.DataSource = dtBKLevel4
            ProjectsGridView.DataBind()
        Else
            ProjectsGridView.DataSource = Nothing
            ProjectsGridView.DataBind()
        End If

    End Sub

#Region "Local Functions"
    Private Function GetBKLevel4List() As DataTable
        Dim dtBKLevel4 As DataTable
        Dim oBKLevel4 As New DataAccessTier.daBodyOfKnowledge
        Dim cn As String = GetConnectionString("connectionString")
        Dim NumberL1 As Integer = CInt(Session("NumberL1"))
        Dim NumberL2 As Integer = CInt(Session("NumberL2"))
        Dim NumberL3 As Integer = CInt(Session("NumberL3"))
        Dim ISModelID As Integer = CInt(Session("selectedProgramId"))
        dtBKLevel4 = oBKLevel4.getBKLevel4byBKLevel3(ISModelID, NumberL1, NumberL2, NumberL3, cn)
        If Not oBKLevel4.TransactionSuccessful Then
            dtBKLevel4 = Nothing
        End If
        Return dtBKLevel4
    End Function
#End Region

    Protected Sub ProjectsGridView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProjectsGridView.SelectedIndexChanged
        Dim row As Integer = ProjectsGridView.SelectedIndex
        Dim BKLevel4ID As Integer = Convert.ToInt32(ProjectsGridView.DataKeys(row).Value.ToString())
        Dim ls As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblNumberL1"), Label)
        Dim NumberL1 As Integer = Convert.ToInt32(ls.Text)
        Dim ls1 As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblNumberL2"), Label)
        Dim NumberL2 As Integer = Convert.ToInt32(ls1.Text)
        Dim ls2 As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblNumberL3"), Label)
        Dim NumberL3 As Integer = Convert.ToInt32(ls2.Text)
        Dim ls3 As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblNumberL4"), Label)
        Dim NumberL4 As Integer = Convert.ToInt32(ls3.Text)
        Session.Add("BKLevel4ID", BKLevel4ID)
        Session.Add("NumberL1", NumberL1)
        Session.Add("NumberL2", NumberL2)
        Session.Add("NumberL3", NumberL3)
        Session.Add("NumberL4", NumberL4)
    End Sub
End Class