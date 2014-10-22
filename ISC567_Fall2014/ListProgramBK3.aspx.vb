Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class ListProgramBK3
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            setform()
        End If
    End Sub
    Private Sub setform()
        PopulateGVBKLevel3()
    End Sub
    Private Sub PopulateGVBKLevel3()
        'Populate the Gridview for Body OF Knowledge BKLevel2 based on BKLevel1
        Dim dtBKLevel3 As DataTable = GetBKLevel3List()
        If Not IsNothing(dtBKLevel3) AndAlso dtBKLevel3.Rows.Count > 0 Then
            ProjectsGridView.DataSource = dtBKLevel3
            ProjectsGridView.DataBind()
        Else
            ProjectsGridView.DataSource = Nothing
            ProjectsGridView.DataBind()
        End If

    End Sub
#Region "Local Functions"
    Private Function GetBKLevel3List() As DataTable
        Dim dtBKLevel3 As DataTable
        Dim oBKLevel3 As New DataAccessTier.daBodyOfKnowledge
        Dim cn As String = GetConnectionString("connectionString")
        Dim NumberL1 As Integer = CInt(Session("NumberL1"))
        Dim NumberL2 As Integer = CInt(Session("NumberL2"))
        Dim ISModelID As Integer = CInt(Session("selectedProgramId"))
        dtBKLevel3 = oBKLevel3.getBKLevel3byBKLevel2(ISModelID, NumberL1, NumberL2, cn)
        If Not oBKLevel3.TransactionSuccessful Then
            dtBKLevel3 = Nothing
        End If
        Return dtBKLevel3
    End Function
#End Region

    Protected Sub ProjectsGridView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProjectsGridView.SelectedIndexChanged
        Dim row As Integer = ProjectsGridView.SelectedIndex
        Dim BKLevel3ID As Integer = Convert.ToInt32(ProjectsGridView.DataKeys(row).Value.ToString())
        Dim ls As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblNumberL1"), Label)
        Dim NumberL1 As Integer = Convert.ToInt32(ls.Text)
        Dim ls1 As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblNumberL2"), Label)
        Dim NumberL2 As Integer = Convert.ToInt32(ls1.Text)
        Dim ls2 As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblNumberL3"), Label)
        Dim NumberL3 As Integer = Convert.ToInt32(ls2.Text)
        Session.Add("BKLevel3ID", BKLevel3ID)
        Session.Add("NumberL1", NumberL1)
        Session.Add("NumberL2", NumberL2)
        Session.Add("NumberL3", NumberL3)
    End Sub
End Class