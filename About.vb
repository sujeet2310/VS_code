Public Class About
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub pnlTitleAbout_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlTitleAbout.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub pnlTitleAbout_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlTitleAbout.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mousex
            Me.Top = Cursor.Position.Y - mousey

        End If
    End Sub

    Private Sub pnlTitleAbout_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlTitleAbout.MouseUp
        drag = False
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub About_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub
    Private Sub About_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mousex
            Me.Top = Cursor.Position.Y - mousey

        End If
    End Sub

    Private Sub About_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub
End Class
