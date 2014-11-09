Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable
Public Class ListCurriculum
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulateGVCurriculum()
        End If

    End Sub

#Region "Local Methods"
    Private Sub PopulateGVCurriculum()
        Dim dtCurriculumList As DataTable = GetCurriculumList()
        Dim dvCurriculumList As DataView

        Try
            If Not IsNothing(dtCurriculumList) AndAlso dtCurriculumList.Rows.Count > 0 Then
                dvCurriculumList = dtCurriculumList.DefaultView
                '  dvCurriculumList.Sort = String.Format("{0} {1}", gvCurriculumList.GridSortColumn, gvCurriculumList.GridSortDirection.ToString())
                gvCurriculumList.DataSource = dvCurriculumList
                gvCurriculumList.DataBind()
            Else
                gvCurriculumList.DataSource = Nothing
                gvCurriculumList.DataBind()
            End If
        Catch ex As Exception
            ' lblErrorMessage.Text = ex.Message
            ' lblErrorMessage.Visible = True
        End Try
    End Sub
    ' Function returns the list of Curriculums and its status
    Private Function GetCurriculumList() As DataTable
        Dim dtCurriculumList As DataTable
        Dim oCurriculum As New DataAccessTier.daProgram
        Dim cn As String = GetConnectionString("connectionString")
        dtCurriculumList = oCurriculum.GetCurriculumList(cn)
        If Not oCurriculum.TransactionSuccessful Then
            dtCurriculumList = Nothing
        End If
        Return dtCurriculumList
    End Function
#End Region

#Region " Event "

    Private Sub gvCurriculumList_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvCurriculumList.Sorting
        PopulateGVCurriculum()
    End Sub

    Public Sub gvCurriculumList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvCurriculumList.SelectedIndexChanged
        'Place selected data from Grid into the session variable
        Dim selectedCurriculumId As String = gvCurriculumList.SelectedValue.ToString()


        Dim s As Boolean = InsertSVTableValue(Of Integer)("CurriculumId", CInt(selectedCurriculumId)) 'Using SV Table
        Session.Add("selectedCurriculumId", selectedCurriculumId) ' Instead of using SV Table some code may just be requesting from Session Variable
        Session.Add("selectedCurriculumName", gvCurriculumList.SelectedDataKey.Values.Item("curriculum_shortname"))

    End Sub

#End Region

End Class