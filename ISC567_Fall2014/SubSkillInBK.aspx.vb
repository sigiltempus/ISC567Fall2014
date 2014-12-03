Imports JSIM.Bases.SVTable
Public Class SubSkillInBK
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("BKLevel2ID").ToString() = "" Then
            Response.Redirect("Login.aspx")
        End If

        If Not IsPostBack Then
            Setform()
        End If
    End Sub
    
#Region "Local Methods  "
    ''Intial Loading Operations
    Private Sub Setform()
        lblStatus1.Text = ""
        lblStatus1.ForeColor = Drawing.Color.Blue

        ' Populating DropDownList
        PopulateBK2DropDown()

        ' And the grid view
        PopulateSubskillGridView()
    End Sub

    ''' <summary>
    ''' Display available BK2 information in the drop down list
    ''' </summary>
    Private Sub PopulateBK2DropDown()
        Dim dt As DataTable = GetBK2ShortList()

        ' Bail out if we didn't receive any records
        If IsNothing(dt) Or dt.Rows.Count <= 0 Then
            ddlBK2.DataSource = Nothing
            ddlBK2.DataBind()
            Exit Sub
        End If

        ' Display our dataset and select the value provided in the session
        Dim dv As DataView = dt.DefaultView
        ddlBK2.DataSource = dv
        ddlBK2.DataBind()

        Dim SelectedID As String = Session("BKLevel2ID").ToString().Trim()
        If SelectedID <> "" Then
            ddlBK2.SelectedValue = SelectedID
        End If

    End Sub

    ''' <summary>
    ''' Display all subskills in the grid view, with those matching the selected
    ''' BK2ID being checked.
    ''' </summary>
    Private Sub PopulateSubskillGridView()
        Dim BK2ID As Integer = Convert.ToInt32(Session("BKLevel2ID").ToString())
        Dim dt As DataTable = GetSubskillList(BK2ID)

        ' Bail out if we didn't receive any records
        If IsNothing(dt) Or dt.Rows.Count <= 0 Then
            gvSubSkill.DataSource = Nothing
            gvSubSkill.DataBind()
            Exit Sub
        End If

        ' Display our dataset and select the value provided in the session
        Dim dv As DataView = dt.DefaultView
        gvSubSkill.DataSource = dv
        gvSubSkill.DataBind()
    End Sub

    ''' <summary>
    ''' Gets a "short listing" of BK2 records for compact display in a drop down list.
    ''' </summary>
    ''' <returns>DataTable</returns>
    Private Function GetBK2ShortList() As DataTable
        Dim dt As DataTable
        Dim cn As String = GetConnectionString("ConnectionString")
        Dim da As New DataAccessTier.daBodyOfKnowledge
        dt = da.GetBK2ShortList(cn)
        If Not da.TransactionSuccessful Then
            dt = Nothing
        End If
        Return dt
    End Function

    ''' <summary>
    ''' Returns a list of all subskills with records matching the BK2ID "checked"
    ''' </summary>
    ''' <param name="BK2ID">BK2ID to search</param>
    ''' <returns></returns>
    Private Function GetSubskillList(ByVal BK2ID As Integer) As DataTable
        Dim dt As DataTable
        Dim cn As String = GetConnectionString("ConnectionString")
        Dim da As New DataAccessTier.daBodyOfKnowledge
        dt = da.GetSubskillInBK2(BK2ID, cn)
        If Not da.TransactionSuccessful Then
            dt = Nothing
        End If
        Return dt
    End Function

#End Region

    ''' <summary>
    ''' Ensure our session variable and grid view are kept up to date when the index changes.
    ''' </summary>
    Private Sub ddlBK2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBK2.SelectedIndexChanged
        Dim SelectedID As String = ddlBK2.SelectedValue.ToString()
        Session("BKLevel2ID") = SelectedID
        PopulateSubskillGridView()
    End Sub
End Class