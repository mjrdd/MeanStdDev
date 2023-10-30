Imports System.ComponentModel

Public Class MainForm
    Public dblValue() As Double
    Public intCounter As Integer = 0

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtData.Text = "Index" & vbTab & "Value"
        lblOutput.Text = "Mean: N/A" & vbCrLf & "Std. Dev.: N/A"
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        Try
            ReDim Preserve dblValue(intCounter)
            dblValue(intCounter) = txtEnter.Text

            intCounter += 1
            DisplayData()

            txtEnter.Focus()
            txtEnter.SelectAll()

            btnCompute.Enabled = True
            btnChange.Enabled = True

            lblOutput.Text = "Mean: N/A" & vbCrLf & "Std. Dev.: N/A"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCompute_Click(sender As Object, e As EventArgs) Handles btnCompute.Click
        Dim dblMean As Double = dblValue.Average()

        Dim dblSqDiff As Double = 0
        For i As Integer = 0 To intCounter - 1
            dblSqDiff += (dblValue(i) - dblMean) ^ 2
        Next

        Dim dblStdDev As Double = Math.Sqrt((1 / intCounter) * dblSqDiff)
        lblOutput.Text = "Mean: " & CStr(Math.Round(dblMean, 3)) & vbCrLf & "Std. Dev.: " & CStr(Math.Round(dblStdDev, 3))
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        ChangePrompt.ShowDialog()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click, ResetToolStripMenuItem.Click
        txtEnter.Clear()

        intCounter = 0
        ReDim dblValue(0)

        txtData.Text = "Index" & vbTab & "Value"
        lblOutput.Text = "Mean: N/A" & vbCrLf & "Std. Dev.: N/A"

        btnCompute.Enabled = False
        btnChange.Enabled = False
    End Sub

    Public Sub DisplayData()
        txtData.Text = "Index" & vbTab & "Value" & vbCrLf

        For i As Integer = 0 To intCounter - 1
            txtData.Text += CStr(i) & vbTab & CStr(dblValue(i)) & vbCrLf
        Next

    End Sub

    Private Sub txtEnter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEnter.KeyPress
        Utils.HandleInput(sender, e.KeyChar)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub
End Class
