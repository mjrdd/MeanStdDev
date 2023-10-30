Public Class ChangePrompt
    Private Sub ChangePrompt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIndex.Clear()
        txtValue.Clear()
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Try
            Dim intIndex As Integer = txtIndex.Text
            Dim dblValue As Double = txtValue.Text

            If intIndex < 0 OrElse intIndex >= MainForm.intCounter Then
                MessageBox.Show("Error")
            Else
                MainForm.dblValue(intIndex) = dblValue
                MainForm.DisplayData()
                MainForm.btnCompute.PerformClick()
                Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub txtIndex_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIndex.KeyPress, txtValue.KeyPress
        Utils.HandleInput(sender, e.KeyChar)

    End Sub
End Class