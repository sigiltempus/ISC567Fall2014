Imports JSIM.Bases.SVTable

Public Class Roster
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

#Region "Local Methods"
    Private Sub SetForm()
        Populategvroster()
    End Sub

    'Populates our gridview
    Private Sub Populategvroster()

        Dim dtrosterlist As DataTable = GetRosterList()
        Dim dvrosterlist As DataView

        Try
            If Not IsNothing(dtrosterlist) AndAlso dtrosterlist.Rows.Count > 0 Then
                dvrosterlist = dtrosterlist.DefaultView
                dvrosterlist.Sort = String.Format("{0} {1}", gvroster.GridSortColumn, gvroster.GridSortDirection.ToString())
                gvroster.DataSource = dvrosterlist
                gvroster.DataBind()
            Else
                gvroster.DataSource = Nothing
                gvroster.DataBind()
            End If

        Catch ex As Exception
            'lblErrorMessage.Text = ex.Message
            'lblErrorMessage.Visible = True
        End Try

    End Sub

#End Region

#Region "Functions"
    ' Function that helps to return a list of users
    Private Function GetRosterList() As DataTable
        Dim dtRosterList As DataTable
        Dim personid As Integer = GetSVTableValue(Of Integer)("personid")
        Dim oUser As New DataAccessTier.daUser
        Dim cn As String = GetConnectionString("ConnectionString")
        dtRosterList = oUser.GetRosterList(personid, cn)
        If Not oUser.TransactionSuccessful Then
            dtRosterList = Nothing
        End If
        Return dtRosterList
    End Function


#End Region

#Region "Event Handlers for Gridview controls"

    Private Sub gvroster_Sorting(sender As Object, e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvroster.Sorting
        Populategvroster()
    End Sub
#End Region

#Region "Click Event Handlers for Page Controls"

#End Region

    Protected Sub gvroster_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvroster.SelectedIndexChanged
        Dim SelScheduleExamID As Integer
        SelScheduleExamID = Convert.ToInt32(gvroster.SelectedValue)
        Session.Add("examid", SelScheduleExamID)
        btnifTakeExam.Enabled = True
    End Sub
End Class
