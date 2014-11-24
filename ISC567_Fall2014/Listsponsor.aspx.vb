Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class Listsponsor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulateGVsponsor()
        End If
    End Sub
#Region "Local Methods"
    Private Sub PopulateGVsponsor()
        Dim dtsponsorList As DataTable = GetsponsorList()
        Dim dvsponsorList As DataView

        Try
            If Not IsNothing(dtsponsorList) AndAlso dtsponsorList.Rows.Count > 0 Then
                dvsponsorList = dtsponsorList.DefaultView
                '  dvsponsorList.Sort = String.Format("{0} {1}", gvsponsorList.GridSortColumn, gvsponsorList.GridSortDirection.ToString())
                gvsponsorList.DataSource = dvsponsorList
                gvsponsorList.DataBind()
            Else
                gvsponsorList.DataSource = Nothing
                gvsponsorList.DataBind()
            End If
        Catch ex As Exception
            ' lblErrorMessage.Text = ex.Message
            ' lblErrorMessage.Visible = True
        End Try
    End Sub
    ' Function returns the list of sponsors and its status
    Private Function GetsponsorList() As DataTable
        Dim dtsponsorList As DataTable
        Dim osponsor As New DataAccessTier.dasponsor
        Dim cn As String = GetConnectionString("connectionString")

        dtsponsorList = osponsor.GetsponsorList(cn, CInt(Session("selectedsocietyId")))
        If Not osponsor.TransactionSuccessful Then
            dtsponsorList = Nothing
        End If
        Return dtsponsorList
    End Function
#End Region

#Region " Event "

    Private Sub gvsponsorList_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvsponsorList.Sorting
        PopulateGVsponsor()
    End Sub

    Public Sub gvsponsorList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvsponsorList.SelectedIndexChanged
        'Place selected data from Grid into the session variable
        Dim selectedsponsorId As String = gvsponsorList.SelectedValue.ToString()


        Dim s As Boolean = InsertSVTableValue(Of Integer)("sponsorId", CInt(selectedsponsorId)) 'Using SV Table
        Session.Add("selectedsponsorId", selectedsponsorId) ' Instead of using SV Table some code may just be requesting from Session Variable
        Session.Add("selectedsponsorName", gvsponsorList.SelectedDataKey.Values.Item("shortname"))

    End Sub

#End Region



End Class