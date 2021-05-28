Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class ListCurriculumpeople
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulateGVListCurriculumPeople()
        End If

    End Sub

#Region "Local Methods"
    Private Sub PopulateGVListCurriculumPeople()
        Dim dtCurriculumPeopleList As DataTable = GetCurriculumPeople()
        Dim dvCurriculumPeopleList As DataView

        Try
            If Not IsNothing(dtCurriculumPeopleList) AndAlso dtCurriculumPeopleList.Rows.Count > 0 Then
                dvCurriculumPeopleList = dtCurriculumPeopleList.DefaultView
                ' dvCurriculumList.Sort = String.Format("{0} {1}", gvCurriculumList.GridSortColumn, gvCurriculumList.GridSortDirection.ToString())
                gvListCurriculumPeople.DataSource = dtCurriculumPeopleList
                gvListCurriculumPeople.DataBind()
            Else
                gvListCurriculumPeople.DataSource = Nothing
                gvListCurriculumPeople.DataBind()
            End If
        Catch ex As Exception
            ' lblErrorMessage.Text = ex.Message
            ' lblErrorMessage.Visible = True
        End Try
    End Sub
    ' Function returns the list of Curriculum People
    Private Function GetCurriculumPeople() As DataTable
        Dim dtCurriculumPeopleList As DataTable
        Dim oCurriculumPeople As New DataAccessTier.daProgram
        Dim cn As String = GetConnectionString("connectionString")
        dtCurriculumPeopleList = oCurriculumPeople.GetCurriculumPeople(cn, CInt(Session("selectedCurriculumId")))
        If Not oCurriculumPeople.TransactionSuccessful Then
            dtCurriculumPeopleList = Nothing
        End If
        Return dtCurriculumPeopleList
    End Function
#End Region

#Region " Event "

    Private Sub GVListCurriculumPeople_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvListCurriculumPeople.Sorting
        PopulateGVListCurriculumPeople()
    End Sub

    Public Sub GVListCurriculumPeople_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvListCurriculumPeople.SelectedIndexChanged
        'Place selected data from Grid into the session variable
        Dim selectedPersonId As String = gvListCurriculumPeople.SelectedValue.ToString()
        Session.Add("selectedPersonId", selectedPersonId)

    End Sub

#End Region

End Class
