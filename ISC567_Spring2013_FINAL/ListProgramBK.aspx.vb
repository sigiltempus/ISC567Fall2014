Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class ListProgramBK
    Inherits JSIM.Bases.BaseClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            setform()
        End If

    End Sub

    Private Sub setform()
        PopulateGVBKLevel1()
    End Sub
    Private Sub PopulateGVBKLevel1()
        'Populate the Gridview for Body OF Knowledge BKLevel1
        Dim dtBKLevel1 As DataTable = GetBKLevel1List()

        If Not IsNothing(dtBKLevel1) AndAlso dtBKLevel1.Rows.Count > 0 Then
            ProjectsGridView.DataSource = dtBKLevel1
            ProjectsGridView.DataBind()
        Else
            ProjectsGridView.DataSource = Nothing
            ProjectsGridView.DataBind()
        End If
    End Sub
    Protected Sub ProjectsGridView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProjectsGridView.SelectedIndexChanged
        Dim cn As String = GetConnectionString("connectionString")
        'CreateSVTable(cn)
        Dim row As Integer = ProjectsGridView.SelectedIndex
        Dim BKLevel1ID As Integer = Convert.ToInt32(ProjectsGridView.DataKeys(row).Value.ToString())
        Dim ls As Label = DirectCast(ProjectsGridView.Rows(row).FindControl("lblNumberL1"), Label)
        Dim NumberL1 As Integer = Convert.ToInt32(ls.Text)

        Session.Add("BKLevel1ID", BKLevel1ID)
        Session.Add("NumberL1", NumberL1)

    End Sub

#Region "Local Functions"
    Private Function GetBKLevel1List() As DataTable
        Dim dtBKLevel1 As DataTable
        Dim oBKLevel1 As New DataAccessTier.daBodyOfKnowledge
        Dim cn As String = GetConnectionString("connectionString")
        Dim ISModelID As Integer = CInt(Session("selectedProgramId"))
        dtBKLevel1 = oBKLevel1.ListBKLevel1(ISModelID, cn)
        If Not oBKLevel1.TransactionSuccessful Then
            dtBKLevel1 = Nothing
        End If
        Return dtBKLevel1
    End Function
#End Region
End Class

