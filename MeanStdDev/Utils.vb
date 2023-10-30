

Module Utils
    Public Sub HandleInput(ByRef sender As Object, ByRef strKeyChar As String)
        Dim intKeyCode As Integer = AscW(strKeyChar)
        If Not (
            intKeyCode = 8 OrElse
            intKeyCode > 47 And intKeyCode < 58 OrElse
            intKeyCode = 46 And (
                Not sender.Text.Contains(".") OrElse
                sender.SelectedText.Contains(".")) OrElse
            intKeyCode = 45 And (
                sender.Text = "" OrElse
                sender.SelectedText.Contains("-") OrElse
                sender.SelectionStart = 0)
            ) Then
            strKeyChar = Nothing
        End If

    End Sub
End Module
