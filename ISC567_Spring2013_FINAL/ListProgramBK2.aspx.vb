Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class ListProgramBK2
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            setform()
        End If
    End Sub

    Private Sub setform()
        PopulateGVBKLevel2()
    End Sub

    Private Sub PopulateGVBKLevel2()
        'Populate the Gridview for Body OF Knowledge BKLevel2 based on BKLevel1
        Dim dtBKLevel2 As DataTable = GetBKLevel2List()
        If Not IsNothing(dtBKLevel2) AndAlso dtBKLevel2.Rows.Count > 0 Then
            ProjectsGridView.DataSource = dtBKLevel2
            ProjectsGridView.DataBind()
        Else
            ProjectsGridView.DataSource = Nothing
            ProjectsGridView.DataBind()
        End If

    End Sub

#Region "Local Functions"
    Private Function GetBKLevel2List() As DataTable
        Dim dtBKLevel2 As DataTable
        Dim oBKLevel2 As New DataAccessTier.daBodyOfKnowledge
        Dim cn As String = GetConnectionString("connectionString")
        Dim NumberL1 As Integer = CInt(Session("NumberL1"))
        Dim ISModelID As Integer = CInt(Session("selectedProgramId"))
        dtBKLevel2 = oBKLevel2.getBKLevel2byBKLevel1(ISModelID, NumberL1, cn)
        If Not oBKLevel2.TransactionSuccessful Then
            dtBKLevel2 = Nothing
        End If
        Return dtBKLevel2
    End Function
#End Region

    Protected Sub ProjectsGridView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProjectsGridView.SelectedIndexChanged
        Dim row As Integer = ProjectsGridView.SelectedIndex
        Dim BKLevel2ID As Integer = Convert.ToInt32(ProjectsGridView.DataKeys(row).Value.ToString())
        Dim ls As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblNumberL1"), Label)
        Dim NumberL1 As Integer = Convert.ToInt32(ls.Text)
        Dim ls1 As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblNumberL2"), Label)
        Dim NumberL2 As Integer = Convert.ToInt32(ls1.Text)
        Session.Add("BKLevel2ID", BKLevel2ID)
        Session.Add("NumberL1", NumberL1)
        Session.Add("NumberL2", NumberL2)

    End Sub
End Class