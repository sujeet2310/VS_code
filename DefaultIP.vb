Public Class DefaultIP
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub pnlTitle_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlTitle.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub pnlTitle_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlTitle.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mousex
            Me.Top = Cursor.Position.Y - mousey

        End If
    End Sub

    Private Sub pnlTitle_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlTitle.MouseUp
        drag = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub DefaultIP_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub
    Private Sub DefaultIP_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mousex
            Me.Top = Cursor.Position.Y - mousey

        End If
    End Sub

    Private Sub DefaultIP_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub
End Class