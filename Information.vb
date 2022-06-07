Public Class Information
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub Information_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub
    Private Sub Information_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mousex
            Me.Top = Cursor.Position.Y - mousey

        End If
    End Sub

    Private Sub Information_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub
    Private Sub btnInfoOk_Click(sender As Object, e As EventArgs) Handles btnInfoOk.Click
        Close()
    End Sub
End Class