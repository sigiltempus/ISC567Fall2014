Imports JSIM.Bases.SVTable
Public Class SubSkillInBK
    Inherits JSIM.Bases.BaseClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Setform()
        End If
    End Sub
    
    '#Region "Local Methods  "
    ''Intial Loading Operations
    Private Sub Setform()
        'Displaying Error Message
        lblStatus1.Text = ""
        'Setting Color to label
        lblStatus1.ForeColor = Drawing.Color.Blue
        Populating DropDownList
        populatesubskillinbk()
        'Populating Gridview
        ' PopulateAssignedSubskills()
        'End Sub

        ''Populates ProgramOutcome to label
        'Private Sub populatesubskillinbk()
        'Dim dt As DataTable = GetProgramOutCome()
        'If Not IsNothing(dtProgram) AndAlso dtProgram.Rows.Count > 0 Then
        'With dtProgram
        'lblProgOutcome.Text = lblProgOutcome.Text + " " + .Rows(0)("prgshortoutcome").ToString() + "  Choose SubSkill"
        ' End With
        ' Else
        'lblStatus1.Text = " "
        'lblStatus.ForeColor = Drawing.Color.Red
        'End If
        'End Sub
        '#End Region
    End Sub
End Class