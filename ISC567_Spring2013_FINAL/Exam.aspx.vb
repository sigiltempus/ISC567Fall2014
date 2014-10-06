Imports JSIM.Bases.SVTable

Public Class Exam
    Inherits JSIM.Bases.BaseClass

    Dim time1 As TimeSpan = DateTime.Now.AddSeconds(300) - DateTime.Now

    Dim oUser As New DataAccessTier.daUser
    Dim cn As String = GetConnectionString("connectionString")
    Dim Questionid As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("examid") = 1
        Session("rosterid") = 3
        If Not IsPostBack Then
            SetForm()

            If Session("timerCount") Is Nothing Then
                Session("timerCount") = time1.TotalSeconds
            End If

            Timer1.Enabled = True
        End If
    End Sub


    Private Sub SetForm()
        Dim examid As Integer = CInt(Session("examid"))
        Dim dtExamprofile As DataTable = oUser.GetExamDetails(examid, cn)
        Dim dtquestionanswer As DataTable
        Dim currentQuestion As Integer = 0
        dtquestionanswer = oUser.GetQuestionanswers(examid, cn)

        If dtquestionanswer IsNot Nothing Then
            Session("questionDataTable") = dtquestionanswer
            Session("questionCount") = dtquestionanswer.Rows.Count

            If Session("currentQuestion") IsNot Nothing Then
                currentQuestion = CType(Session("currentQuestion"), Integer)
            Else
                Session("currentQuestion") = currentQuestion
            End If

            populateQuestionAnswers(dtquestionanswer, currentQuestion)
            GetAnswers()
            EnableButtons(0, dtquestionanswer.Rows.Count)
        End If

    End Sub


    Protected Sub linknext_Click(sender As Object, e As EventArgs) Handles linknext.Click
        GetNextQuestion()
    End Sub


    Protected Sub linkprev_Click(sender As Object, e As EventArgs) Handles linkprev.Click
        GetPreviousQuestion()
    End Sub

    Protected Sub btnFinished_Click(sender As Object, e As EventArgs) Handles btnFinished.Click
        saveAnswers()
        Response.Redirect("Roster.aspx")
    End Sub


    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim counter As Integer = CType(Session("timerCount"), Integer)
        If (counter = 0) Then
            Label7.Text = "TimeOut!"
            linkprev.Enabled = False
            linknext.Enabled = False
            MsgBox("Timeout!!")
            saveAnswers()
            Response.Redirect("Roster.aspx")
        Else
            counter -= 1
            Label7.Text = TimeSpan.FromSeconds(counter).ToString()
        End If

        Session("timerCount") = counter
    End Sub

    Private Sub GetNextQuestion()
        Dim dtquestionanswer As DataTable = CType(Session("questionDataTable"), DataTable)
        Dim questionCount As Integer = CType(Session("questionCount"), Integer)
        Dim currentQuestion As Integer = CType(Session("currentQuestion"), Integer)

        saveAnswers()
        If dtquestionanswer IsNot Nothing And currentQuestion < questionCount Then
            currentQuestion = currentQuestion + 1
            Session("currentQuestion") = currentQuestion

            populateQuestionAnswers(dtquestionanswer, currentQuestion)
            EnableButtons(currentQuestion, questionCount)
        End If
    End Sub


    Private Sub GetPreviousQuestion()
        Dim dtquestionanswer As DataTable = CType(Session("questionDataTable"), DataTable)
        Dim questionCount As Integer = CType(Session("questionCount"), Integer)
        Dim currentQuestion As Integer = CType(Session("currentQuestion"), Integer)

        saveAnswers()
        If dtquestionanswer IsNot Nothing And currentQuestion > 0 Then
            currentQuestion = currentQuestion - 1
            Session("currentQuestion") = currentQuestion

            populateQuestionAnswers(dtquestionanswer, currentQuestion)
            EnableButtons(currentQuestion, questionCount)
        End If
    End Sub


    Private Sub saveAnswers()

        If rbAnswerOptions.SelectedItem IsNot Nothing Then
            Dim examItemId As Integer = CType(Session("examitemid"), Integer)
            Dim rosterId As Integer = CType(Session("rosterid"), Integer)

            oUser.InsertAnswers(rosterId, examItemId, rbAnswerOptions.SelectedValue.ToString, cn)
        End If
    End Sub


    Private Sub populateQuestionAnswers(dtquestionanswer As DataTable, currentQuestion As Integer)
        rbAnswerOptions.Items.Clear()

        Dim item As ListItem
        Session("examitemid") = dtquestionanswer.Rows(currentQuestion)("examitemid").ToString

        lblQuestion.Text = dtquestionanswer.Rows(currentQuestion)("stem").ToString
        item = New ListItem(dtquestionanswer.Rows(currentQuestion)("destractor1").ToString, "A")
        rbAnswerOptions.Items.Add(item)
        item = New ListItem(dtquestionanswer.Rows(currentQuestion)("destractor2").ToString, "B")
        rbAnswerOptions.Items.Add(item)
        item = New ListItem(dtquestionanswer.Rows(currentQuestion)("destractor3").ToString, "C")
        rbAnswerOptions.Items.Add(item)
        item = New ListItem(dtquestionanswer.Rows(currentQuestion)("destractor4").ToString, "D")
        rbAnswerOptions.Items.Add(item)

        GetAnswers()
    End Sub


    Private Sub GetAnswers()
        Dim examItemId As Integer = CType(Session("examitemid"), Integer)
        Dim rosterId As Integer = CType(Session("rosterid"), Integer)
        Dim dtAnswer As DataTable = oUser.GetAnswer(examItemId, rosterId, cn)

        If dtAnswer.Rows.Count > 0 Then
            For Each item As ListItem In rbAnswerOptions.Items
                If item.Value.Trim() = dtAnswer.Rows(0)(2).ToString().Trim() Then
                    item.Selected = True
                Else

                End If
            Next
        End If
    End Sub


    Private Sub EnableButtons(currentQuestion As Integer, questionCount As Integer)
        If rbAnswerOptions.SelectedItem IsNot Nothing Then
            If (currentQuestion + 1) = questionCount Then
                linknext.Enabled = False
            Else
                linknext.Enabled = True
            End If

            If currentQuestion = 0 Then
                linkprev.Enabled = False
            Else
                linkprev.Enabled = True
            End If
        Else
            linkprev.Enabled = False
            linknext.Enabled = False
        End If
    End Sub

    
    Protected Sub rbAnswerOptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbAnswerOptions.SelectedIndexChanged
        Dim questionCount As Integer = CType(Session("questionCount"), Integer)
        Dim currentQuestion As Integer = CType(Session("currentQuestion"), Integer)
        saveAnswers()
        EnableButtons(currentQuestion, questionCount)
    End Sub

End Class
