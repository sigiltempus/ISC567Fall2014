Imports JSIM.Bases.SVTable
Public Class SubSkillInBK
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("BKLevel2ID")) AndAlso IsNothing(Session("skillsnum")) Then
            Response.Redirect("Login.aspx")
        End If

        If Not IsPostBack Then
            Setform()
        End If
    End Sub
    
#Region "Local Methods  "
    ''Intial Loading Operations
    Private Sub Setform()
        lblStatus.Text = ""
        lblStatus.ForeColor = Drawing.Color.Blue

        ' Populating DropDownList
        PopulateBK2DropDown()

        ' And the grid view
        PopulateSubskillGridView()
    End Sub

    Private Function GetBK2ID() As Integer
        ' The hackiest of hacks, the kludgiest of kludges to get the page working from subskill before the demo.        
        Dim BK2ID As Integer = -1
        If Not IsNothing(Session("BKLevel2ID")) Then BK2ID = Convert.ToInt32(Session("BKLevel2ID").ToString())
        Return BK2ID
    End Function

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

        Dim SelectedID As String = GetBK2ID().ToString()
        If SelectedID = "-1" AndAlso ddlBK2.Items.Count > 0 Then          
            ddlBK2.SelectedIndex = 0
            Session("BKLevel2ID") = ddlBK2.SelectedValue
        Else
            ddlBK2.SelectedValue = SelectedID
        End If

    End Sub

    ''' <summary>
    ''' Display all subskills in the grid view, with those matching the selected
    ''' BK2ID being checked.
    ''' </summary>
    Private Sub PopulateSubskillGridView()
        Dim BK2ID As Integer = GetBK2ID()
        Dim dt As DataTable = GetSubskillList(BK2ID)
        gvSubSkill.Parameters = CreateParameters()

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

    ''' <summary>
    ''' Parameter creation for web services.
    ''' </summary>
    ''' <returns>Created parameters</returns>
    Protected Overrides Function CreateParameters() As JSIM.ParameterContainer
        MyBase.paramContainer = New JSIM.ParameterContainer()
        Dim BK2ID As String = GetBK2ID().ToString()
        paramContainer.AddParameter("BKLevel2ID", BK2ID, False)
        Return MyBase.CreateParameters()
    End Function

    ''' <summary>
    ''' Executes the stored procedure to toggle the intersection record.
    ''' </summary>
    ''' <param name="BK2ID">BK2ID to toggle</param>
    ''' <param name="SubSkillID">SubSkillID to toggle</param>
    ''' <returns>Message as to whether the function succeeded</returns>
    ''' <remarks></remarks>
    Private Shared Function ToggleSubskillInBK(ByVal BK2ID As Integer, ByVal SubSkillID As Integer) As String
        Dim da As New DataAccessTier.daBodyOfKnowledge
        Dim cn As String = GetConnectionString("ConnectionString")
        Dim msg As String = String.Format("BK2 {0} Subskill {1}: ", BK2ID, SubSkillID)
        da.ToggleSubskillInBK2(BK2ID, SubSkillID, cn)
        If da.TransactionSuccessful Then
            msg += "Toggled"
        Else
            msg += "Toggle FAILED"
        End If
        Return msg
    End Function

#Region "Local Webservice Methods"

    ''' <summary>
    ''' Page web service method to handle callbacks for toggling checkboxes.
    ''' </summary>
    ''' <param name="checked">Whether the record is checked</param>
    ''' <param name="subskillid">SubSkillID to edit</param>
    ''' <param name="BKLevel2ID">BK2ID to edit</param>
    ''' <returns>Message indicating transaction success or failure.</returns>
    <Services.WebMethod()> _
    Public Shared Function wsToggleSubskillBK(ByVal checked As Boolean, ByVal subskillid As Integer, ByVal BKLevel2ID As Integer) As String
        Return ToggleSubskillInBK(BKLevel2ID, subskillid)
    End Function
#End Region
End Class