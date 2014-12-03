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
        PopulateBK2()

        '        populatesubskillinbk()
        'Populating Gridview
        ' PopulateAssignedSubskills()
    End Sub

    ''' <summary>
    ''' Display available BK2 information in the drop down list
    ''' </summary>
    Private Sub PopulateBK2()
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

    ''Populates ProgramOutcome to label
    Private Sub populatesubskillinbk()
        'Dim dt As DataTable = GetProgramOutCome()
        'If Not IsNothing(dtProgram) AndAlso dtProgram.Rows.Count > 0 Then
        'With dtProgram
        'lblProgOutcome.Text = lblProgOutcome.Text + " " + .Rows(0)("prgshortoutcome").ToString() + "  Choose SubSkill"
        ' End With
        ' Else
        lblStatus1.Text = " "
        lblStatus1.ForeColor = Drawing.Color.Red
        'End If
    End Sub
#End Region

    ''' <summary>
    ''' Ensure our session variable is kept up to date when the index changes.
    ''' </summary>
    Private Sub ddlBK2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBK2.SelectedIndexChanged
        Dim SelectedID As String = ddlBK2.SelectedValue.ToString()
        Session("BKLevel2ID") = SelectedID
    End Sub
End Class