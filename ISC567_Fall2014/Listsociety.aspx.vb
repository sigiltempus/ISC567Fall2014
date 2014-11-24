Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class Listsociety
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulateGVsociety()
        End If

    End Sub
#Region "Local Methods"
    Private Sub PopulateGVsociety()
        Dim dtsocietyList As DataTable = GetsocietyList()
        Dim dvsocietyList As DataView

        Try
            If Not IsNothing(dtsocietyList) AndAlso dtsocietyList.Rows.Count > 0 Then
                dvsocietyList = dtsocietyList.DefaultView
                '  dvsocietyList.Sort = String.Format("{0} {1}", gvsocietyList.GridSortColumn, gvsocietyList.GridSortDirection.ToString())
                gvsocietyList.DataSource = dvsocietyList
                gvsocietyList.DataBind()
            Else
                gvsocietyList.DataSource = Nothing
                gvsocietyList.DataBind()
            End If
        Catch ex As Exception
            ' lblErrorMessage.Text = ex.Message
            ' lblErrorMessage.Visible = True
        End Try
    End Sub
    ' Function returns the list of societys and its status
    Private Function GetsocietyList() As DataTable
        Dim dtsocietyList As DataTable
        Dim osociety As New DataAccessTier.dasociety
        Dim cn As String = GetConnectionString("connectionString")
        dtsocietyList = osociety.GetsocietyList(cn)
        If Not osociety.TransactionSuccessful Then
            dtsocietyList = Nothing
        End If
        Return dtsocietyList
    End Function
#End Region

#Region " Event "

    Private Sub gvsocietyList_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvsocietyList.Sorting
        PopulateGVsociety()
    End Sub

    Public Sub gvsocietyList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvsocietyList.SelectedIndexChanged
        'Place selected data from Grid into the session variable
        Dim selectedsocietyId As String = gvsocietyList.SelectedValue.ToString()


        Dim s As Boolean = InsertSVTableValue(Of Integer)("societyId", CInt(selectedsocietyId)) 'Using SV Table
        Session.Add("selectedsocietyId", selectedsocietyId) ' Instead of using SV Table some code may just be requesting from Session Variable
        Session.Add("selectedsocietyName", gvsocietyList.SelectedDataKey.Values.Item("shortname"))

    End Sub

#End Region


End Class