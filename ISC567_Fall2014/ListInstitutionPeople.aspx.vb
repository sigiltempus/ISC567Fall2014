Imports JSIM.Bases.SVTable
Imports GlobalVariables.AppVariable

Public Class ListInstitutionPeople
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetForm()
        End If
    End Sub

#Region "Local Methods   "

    Private Sub SetForm()
        lblInstitutionName.Visible = False
        LoadInstitution()
        lbtnOpenScheduledExam.Enabled = False
    End Sub

    ' populates our gridview
    Private Sub PopulateGVInstitutionPeople()
        Dim dtInstitutionPeopleList As DataTable = GetInstitutionPeopleList()
        Dim dvInstitutionPeopleList As DataView

        Try
            If Not IsNothing(dtInstitutionPeopleList) AndAlso dtInstitutionPeopleList.Rows.Count > 0 Then
                dvInstitutionPeopleList = dtInstitutionPeopleList.DefaultView
                dvInstitutionPeopleList.Sort = String.Format("{0} {1}", gvInstitutionPersonList.GridSortColumn, gvInstitutionPersonList.GridSortDirection.ToString())
                gvInstitutionPersonList.DataSource = dvInstitutionPeopleList
                gvInstitutionPersonList.DataBind()
            Else
                gvInstitutionPersonList.DataSource = Nothing
                gvInstitutionPersonList.DataBind()
            End If
        Catch ex As Exception
            lblInstitutionName.ForeColor = Drawing.Color.Red
            lblInstitutionName.Text = ex.Message
            lblInstitutionName.Visible = True
        End Try
    End Sub

    ' Function that returns a list of Persons
    Private Function GetInstitutionPeopleList() As DataTable
        Dim dtInstitutionPeopleList As DataTable
        Dim oInstitutionPeople As New DataAccessTier.daInstitution
        Dim cn As String = GetConnectionString("connectionString")
        dtInstitutionPeopleList = oInstitutionPeople.GetInstitutionPeopleList(CInt(ddlInstitution.SelectedItem.Value), cn)
        If Not oInstitutionPeople.TransactionSuccessful Then
            dtInstitutionPeopleList = Nothing
        End If
        Return dtInstitutionPeopleList
    End Function

    ' Deletes a Person given a Personid
    'Private Function DeletePerson(ByVal PersonID As Integer) As Boolean
    '    Dim bIsDeleted As Boolean
    '    Dim oPerson As New DataAccessTier.daUser
    '    Dim cn As String = GetConnectionString("connectionString")
    '    ' oPerson.DeletePerson(PersonID, cn)
    '    If oPerson.TransactionSuccessful Then
    '        bIsDeleted = True
    '    Else
    '        bIsDeleted = False
    '    End If
    '    Return bIsDeleted
    'End Function
#End Region

#Region "Events"
    Private Sub LoadInstitution()
        Dim dtInstitutionNames As DataTable
        Dim oInstitution As New DataAccessTier.daInstitution

        dtInstitutionNames = oInstitution.GetInstitutionList(con)

        ddlInstitution.DataTextField = "name"
        ddlInstitution.DataValueField = "institutionid"
        ddlInstitution.DataSource = dtInstitutionNames
        ddlInstitution.DataBind()

        ddlInstitution.Items.Insert(0, New ListItem("-- Select Institution --", "-1"))

    End Sub

    Protected Sub ddlInstitution_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlInstitution.SelectedIndexChanged
        lblInstitutionName.ForeColor = Drawing.Color.Black
        lblInstitutionName.Text = ddlInstitution.SelectedItem.Text.ToString()
        lblInstitutionName.Visible = True

        If (ddlInstitution.SelectedItem.Value = "-1") Then
            lbtnOpenScheduledExam.Enabled = False
        Else
            lbtnOpenScheduledExam.Enabled = True
        End If

        PopulateGVInstitutionPeople()

        'Place selected institution into the session variable
        Dim selectedInstitution As String = ddlInstitution.SelectedItem.Value.ToString()
        Session.Add("institutionIdInContext", selectedInstitution)
    End Sub

    Protected Sub gvInstitutionPersonList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvInstitutionPersonList.SelectedIndexChanged
        ' Add the selected person's id in the grid to the session variable
        Dim selectedPersonId As String = gvInstitutionPersonList.SelectedValue.ToString()
        Session.Add("selectedPersonId", selectedPersonId)
    End Sub

    Protected Sub gvInstitutionPersonList_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvInstitutionPersonList.Sorting
        PopulateGVInstitutionPeople()
    End Sub
#End Region

End Class