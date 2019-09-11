Imports System.Drawing.Text
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Threading
Imports System.Configuration

Public Class coolBlue
    Private Sub coolBlue_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Enabled = True
        Timer1.Start()
        Timer2.Enabled = True
        Timer2.Interval = 50 '10 times a second
        lblTile.BackColor = Color.FromArgb(0, 0, 0)
    End Sub
    Private Function pingIPcamera(ByVal IPAddress As String) As String
        Dim camIpAddress As String
        camIpAddress = My.Computer.Network.Ping(IPAddress)
        Return camIpAddress
    End Function
    'Timer1 is for time and date dislay
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTime.Text = Date.Now.ToString("hh:mm:ss")
        lblPM.Text = Date.Now.ToString("tt")
        lblDate.Text = Date.Now.ToString("dddd, MMMM d, yyyy")
        'network Status check
        If System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable = True Then
            With sslStatus2
                .Text = "Network Connected"
                .BackColor = Color.Green
            End With
        ElseIf System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable = False Then
            With sslStatus2
                .Text = "Network Not Connected"
                .BackColor = Color.OrangeRed
            End With

        End If
    End Sub

    'close button
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    'Maximise button
    Private Sub btnMaximise_Click(sender As Object, e As EventArgs) Handles btnMaximise.Click
        If Me.WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        ElseIf Me.WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
        End If
    End Sub
    'Minimize button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btmMinimize.Click
        If Me.WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Minimized
        ElseIf Me.WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Minimized
        End If
    End Sub
    'Title bar mouse movement and drag and drop 
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    'Title menu drag and drop
    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles lblMainTitle.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles lblMainTitle.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mousex
            Me.Top = Cursor.Position.Y - mousey
        End If
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles lblMainTitle.MouseUp
        drag = False
    End Sub
    'Tilte panel drag and drop movement
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlTitlebar.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlTitlebar.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mousex
            Me.Top = Cursor.Position.Y - mousey

        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlTitlebar.MouseUp
        drag = False
    End Sub

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlClosebar.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlClosebar.MouseMove
        If drag Then
            Me.Left = Cursor.Position.X - mousex
            Me.Top = Cursor.Position.Y - mousey

        End If
    End Sub

    Private Sub Panel2_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlClosebar.MouseUp
        drag = False
    End Sub
    'Title label color opacity change on form load
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Static aa As Integer
        lblTile.BackColor = Color.FromArgb(aa, 240, 240, 243)
        lblTile.ForeColor = Color.FromArgb(aa, 19, 149, 181)
        aa += 5 'amount of opacity change for each timer tick
        If aa > 255 Then Timer2.Enabled = False 'finished fade-in
    End Sub
    'Status change value get and set
    Public Property StatusText() As String
        Get
            Return sslStatus.Text
        End Get
        Set(value As String)
            sslStatus.Text = value
        End Set
    End Property
    'Status change value get and set
    Public Property StatusText1() As String
        Get
            Return sslStatus2.Text
        End Get
        Set(value As String)
            sslStatus2.Text = value
        End Set
    End Property
    'Ping camera From lblCam 1 to 28 
    Dim intCount As Integer = 0
    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        Try
            intCount += 1
            StatusText = intCount & "  Times"
            Dim gateCam As String
            gateCam = pingIPcamera("192.168.1.3")
            If gateCam = True Then
                lblCam1.Text = "1. Gate-1 Entry"
                lblCam1.ForeColor = Color.White
                picBox.Image = My.Resources.confirm
            Else
                lblCam1.Text = "1. Gate-1 Entry"
                lblCam1.ForeColor = Color.OrangeRed
                picBox.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.4")
            If gateCam = True Then
                lblCam2.Text = "2. Gate-1 Exit"
                lblCam2.ForeColor = Color.White
                picBox2.Image = My.Resources.confirm
            Else
                lblCam2.Text = "2. Gate-1 Exit"
                lblCam2.ForeColor = Color.OrangeRed
                picBox2.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.5")
            If gateCam = True Then
                lblCam3.Text = "3. Gate-2 Entry"
                lblCam3.ForeColor = Color.White
                picBox3.Image = My.Resources.confirm
            Else
                lblCam3.Text = "3. Gate-2 Entry"
                lblCam3.ForeColor = Color.OrangeRed
                picBox3.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.6")
            If gateCam = True Then
                lblCam4.Text = "4. Gate-2 Exit"
                lblCam4.ForeColor = Color.White
                picBox4.Image = My.Resources.confirm
            Else
                lblCam4.Text = "4. Gate-2 Exit"
                lblCam4.ForeColor = Color.OrangeRed
                picBox4.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.7")
            If gateCam = True Then
                lblCam5.Text = "5. Gate-2 UP"
                lblCam5.ForeColor = Color.White
                picBox5.Image = My.Resources.confirm
            Else
                lblCam5.Text = "5. Gate-2 Up"
                lblCam5.ForeColor = Color.OrangeRed
                picBox5.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.8")
            If gateCam = True Then
                lblCam6.Text = "6. Gate-3 Entry"
                lblCam6.ForeColor = Color.White
                picBox6.Image = My.Resources.confirm
            Else
                lblCam6.Text = "6. Gate-3 Entry"
                lblCam6.ForeColor = Color.OrangeRed
                picBox6.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.9")
            If gateCam = True Then
                lblCam7.Text = "7. Gate-3 Exit"
                lblCam7.ForeColor = Color.White
                picBox7.Image = My.Resources.confirm
            Else
                lblCam7.Text = "7. Gate-3 Exit"
                lblCam7.ForeColor = Color.OrangeRed
                picBox7.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.10")
            If gateCam = True Then
                lblCam8.Text = "8. Gate-3 UP"
                lblCam8.ForeColor = Color.White
                picBox8.Image = My.Resources.confirm
            Else
                lblCam8.Text = "8. Gate-3 UP"
                lblCam8.ForeColor = Color.OrangeRed
                picBox8.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.11")
            If gateCam = True Then
                lblCam9.Text = "9. TKF Finishing Goods"
                lblCam9.ForeColor = Color.White
                picBox9.Image = My.Resources.confirm
            Else
                lblCam9.Text = "9. TKF Finishing Goods"
                lblCam9.ForeColor = Color.OrangeRed
                picBox9.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.12")
            If gateCam = True Then
                lblCam10.Text = "10. Roadside Cam-1"
                lblCam10.ForeColor = Color.White
                picBox10.Image = My.Resources.confirm
            Else
                lblCam10.Text = "10. Roadside Cam-1"
                lblCam10.ForeColor = Color.OrangeRed
                picBox10.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.13")
            If gateCam = True Then
                lblCam11.Text = "11. Roadside Cam-2"
                lblCam11.ForeColor = Color.White
                picBox11.Image = My.Resources.confirm
            Else
                lblCam11.Text = "11. Roadside Cam-2"
                lblCam11.ForeColor = Color.OrangeRed
                picBox11.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.14")
            If gateCam = True Then
                lblCam12.Text = "12. Roadside Cam-3"
                lblCam12.ForeColor = Color.White
                picBox12.Image = My.Resources.confirm
            Else
                lblCam12.Text = "12. Roadside Cam-3"
                lblCam12.ForeColor = Color.OrangeRed
                picBox12.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.15")
            If gateCam = True Then
                lblCam13.Text = "13. Roadside Cam-4"
                lblCam13.ForeColor = Color.White
                picBox13.Image = My.Resources.confirm
            Else
                lblCam13.Text = "13. Roadside Cam-4"
                lblCam13.ForeColor = Color.OrangeRed
                picBox13.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.16")
            If gateCam = True Then
                lblCam14.Text = "14. Pipe Factory Road"
                lblCam14.ForeColor = Color.White
                picBox14.Image = My.Resources.confirm
            Else
                lblCam14.Text = "14. Pipe Factory Road"
                lblCam14.ForeColor = Color.OrangeRed
                picBox14.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.17")
            If gateCam = True Then
                lblCam15.Text = "15. Roadside Cam"
                lblCam15.ForeColor = Color.White
                picBox15.Image = My.Resources.confirm
            Else
                lblCam15.Text = "15. Roadside Cam"
                lblCam15.ForeColor = Color.OrangeRed
                picBox15.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.18")
            If gateCam = True Then
                lblCam16.Text = "16. Readymix Roadside"
                lblCam16.ForeColor = Color.White
                picBox16.Image = My.Resources.confirm
            Else
                lblCam16.Text = "16. Readymix Roadside"
                lblCam16.ForeColor = Color.OrangeRed
                picBox16.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.19")
            If gateCam = True Then
                lblCam17.Text = "17. Readymix Tower"
                lblCam17.ForeColor = Color.White
                picBox17.Image = My.Resources.confirm
            Else
                lblCam17.Text = "17. Readymix Tower"
                lblCam17.ForeColor = Color.OrangeRed
                picBox17.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.20")
            If gateCam = True Then
                lblCam18.Text = "18. Tower PTZ"
                lblCam18.ForeColor = Color.White
                picBox18.Image = My.Resources.confirm
            Else
                lblCam18.Text = "18. Tower PTZ"
                lblCam18.ForeColor = Color.OrangeRed
                picBox18.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.21")
            If gateCam = True Then
                lblCam19.Text = "19. Transport PTZ"
                lblCam19.ForeColor = Color.White
                picBox19.Image = My.Resources.confirm
            Else
                lblCam19.Text = "19. Transport PTZ"
                lblCam19.ForeColor = Color.OrangeRed
                picBox19.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.22")
            If gateCam = True Then
                lblCam20.Text = "20. Transport Front"
                lblCam20.ForeColor = Color.White
                picBox20.Image = My.Resources.confirm
            Else
                lblCam20.Text = "20. Transport Front"
                lblCam20.ForeColor = Color.OrangeRed
                picBox20.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.23")
            If gateCam = True Then
                lblCam21.Text = "21. Transport Parking Area"
                lblCam21.ForeColor = Color.White
                picBox21.Image = My.Resources.confirm
            Else
                lblCam21.Text = "21. Transport Parking Area"
                lblCam21.ForeColor = Color.OrangeRed
                picBox21.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.24")
            If gateCam = True Then
                lblCam22.Text = "22. Transport Roadside"
                lblCam22.ForeColor = Color.White
                picBox22.Image = My.Resources.confirm
            Else
                lblCam22.Text = "22. Transport Roadside"
                lblCam22.ForeColor = Color.OrangeRed
                picBox22.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.25")
            If gateCam = True Then
                lblCam23.Text = "23. Safety Office Side"
                lblCam23.ForeColor = Color.White
                picBox23.Image = My.Resources.confirm
            Else
                lblCam23.Text = "23. Safety Office Side"
                lblCam23.ForeColor = Color.OrangeRed
                picBox23.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.26")
            If gateCam = True Then
                lblCam24.Text = "24. Tarrace Admin Parking"
                lblCam24.ForeColor = Color.White
                picBox24.Image = My.Resources.confirm
            Else
                lblCam24.Text = "24. Tarrace Admin Parking"
                lblCam24.ForeColor = Color.OrangeRed
                picBox24.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.27")
            If gateCam = True Then
                lblCam25.Text = "25. Adming Parking"
                lblCam25.ForeColor = Color.White
                picBox25.Image = My.Resources.confirm
            Else
                lblCam25.Text = "25. Admin Parking"
                lblCam25.ForeColor = Color.OrangeRed
                picBox25.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.28")
            If gateCam = True Then
                lblCam26.Text = "26. Clinicside Admin Parking"
                lblCam26.ForeColor = Color.White
                picBox26.Image = My.Resources.confirm
            Else
                lblCam26.Text = "26. Clinicside Admin Parking"
                lblCam26.ForeColor = Color.OrangeRed
                picBox26.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.29")
            If gateCam = True Then
                lblCam27.Text = "27. Car Parking"
                lblCam27.ForeColor = Color.White
                picBox27.Image = My.Resources.confirm
            Else
                lblCam27.Text = "27. Car Parking"
                lblCam27.ForeColor = Color.OrangeRed
                picBox27.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.30")
            If gateCam = True Then
                lblCam28.Text = "28. Gate-1 Roadside"
                lblCam28.ForeColor = Color.White
                picBox28.Image = My.Resources.confirm
            Else
                lblCam28.Text = "28. Gate-1 Roadside"
                lblCam28.ForeColor = Color.OrangeRed
                picBox28.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.31")
            If gateCam = True Then
                lblCam29.Text = "29. Gate-3 Outside Parking-A"
                lblCam29.ForeColor = Color.White
                picBox29.Image = My.Resources.confirm
            Else
                lblCam29.Text = "29. Gate-3 Outside Parking-A"
                lblCam29.ForeColor = Color.OrangeRed
                picBox29.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.32")
            If gateCam = True Then
                lblCam30.Text = "30. Gate-3 Outside Parking-B"
                lblCam30.ForeColor = Color.White
                picBox30.Image = My.Resources.confirm
            Else
                lblCam30.Text = "30. Gate-3 Outside Parking-B"
                lblCam30.ForeColor = Color.OrangeRed
                picBox30.Image = My.Resources.close__1_
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Camera ip address on hover hikvision camera name at status bar 
    Private Sub lblCam1_MouseHover(sender As Object, e As EventArgs) Handles lblCam1.MouseHover
        StatusText = "Cam IP : 192.168.1.3"
    End Sub
    Private Sub lblCam2_MouseHover(sender As Object, e As EventArgs) Handles lblCam2.MouseHover
        StatusText = "Cam IP : 192.168.1.4"
    End Sub

    Private Sub lblCam3_MouseHover(sender As Object, e As EventArgs) Handles lblCam3.MouseHover
        StatusText = "Cam IP : 192.168.1.5"
    End Sub

    Private Sub lblCam4_MouseHover(sender As Object, e As EventArgs) Handles lblCam4.MouseHover
        StatusText = "Cam IP : 192.168.1.6"
    End Sub

    Private Sub lblCam5_MouseHover(sender As Object, e As EventArgs) Handles lblCam5.MouseHover
        StatusText = "Cam IP : 192.168.1.7"
    End Sub

    Private Sub lblCam6_MouseHover(sender As Object, e As EventArgs) Handles lblCam6.MouseHover
        StatusText = "Cam IP : 192.168.1.8"
    End Sub

    Private Sub lblCam7_MouseHover(sender As Object, e As EventArgs) Handles lblCam7.MouseHover
        StatusText = "Cam IP : 192.168.1.9"
    End Sub

    Private Sub lblCam8_MouseHover(sender As Object, e As EventArgs) Handles lblCam8.MouseHover
        StatusText = "Cam IP : 192.168.1.10"
    End Sub

    Private Sub lblCam9_MouseHover(sender As Object, e As EventArgs) Handles lblCam9.MouseHover
        StatusText = "Cam IP : 192.168.1.11"
    End Sub

    Private Sub lblCam10_MouseHover(sender As Object, e As EventArgs) Handles lblCam10.MouseHover
        StatusText = "Cam IP : 192.168.1.12"
    End Sub

    Private Sub lblCam11_MouseHover(sender As Object, e As EventArgs) Handles lblCam11.MouseHover
        StatusText = "Cam IP : 192.168.1.13"
    End Sub

    Private Sub lblCam12_MouseHover(sender As Object, e As EventArgs) Handles lblCam12.MouseHover
        StatusText = "Cam IP : 192.168.1.14"
    End Sub

    Private Sub lblCam13_MouseHover(sender As Object, e As EventArgs) Handles lblCam13.MouseHover
        StatusText = "Cam IP : 192.168.1.15"
    End Sub

    Private Sub lblCam14_MouseHover(sender As Object, e As EventArgs) Handles lblCam14.MouseHover
        StatusText = "Cam IP : 192.168.1.16"
    End Sub

    Private Sub lblCam15_MouseHover(sender As Object, e As EventArgs) Handles lblCam15.MouseHover
        StatusText = "Cam IP : 192.168.1.17"
    End Sub

    Private Sub lblCam16_MouseHover(sender As Object, e As EventArgs) Handles lblCam16.MouseHover
        StatusText = "Cam IP : 192.168.1.18"
    End Sub

    Private Sub lblCam17_MouseHover(sender As Object, e As EventArgs) Handles lblCam17.MouseHover
        StatusText = "Cam IP : 192.168.1.19"
    End Sub

    Private Sub lblCam18_MouseHover(sender As Object, e As EventArgs) Handles lblCam18.MouseHover
        StatusText = "Cam IP : 192.168.1.20"
    End Sub

    Private Sub lblCam19_MouseHover(sender As Object, e As EventArgs) Handles lblCam19.MouseHover
        StatusText = "Cam IP : 192.168.1.21"
    End Sub
    Private Sub lblCam20_MouseHover(sender As Object, e As EventArgs) Handles lblCam20.MouseHover
        StatusText = "Cam IP : 192.168.1.22"
    End Sub

    Private Sub lblCam21_MouseHover(sender As Object, e As EventArgs) Handles lblCam21.MouseHover
        StatusText = "Cam IP : 192.168.1.23"
    End Sub
    Private Sub lblCam22_MouseHover(sender As Object, e As EventArgs) Handles lblCam22.MouseHover
        StatusText = "Cam IP : 192.168.1.24"
    End Sub

    Private Sub lblCam23_MouseHover(sender As Object, e As EventArgs) Handles lblCam23.MouseHover
        StatusText = "Cam IP : 192.168.1.25"
    End Sub

    Private Sub lblCam24_MouseHover(sender As Object, e As EventArgs) Handles lblCam24.MouseHover
        StatusText = "Cam IP : 192.168.1.26"
    End Sub

    Private Sub lblCam25_MouseHover(sender As Object, e As EventArgs) Handles lblCam25.MouseHover
        StatusText = "Cam IP : 192.168.1.27"
    End Sub

    Private Sub lblCam26_MouseHover(sender As Object, e As EventArgs) Handles lblCam26.MouseHover
        StatusText = "Cam IP : 192.168.1.28"
    End Sub

    Private Sub lblCam27_MouseHover(sender As Object, e As EventArgs) Handles lblCam27.MouseHover
        StatusText = "Cam IP : 192.168.1.29"
    End Sub
    Private Sub lblCam28_MouseHover(sender As Object, e As EventArgs) Handles lblCam28.MouseHover
        StatusText = "Cam IP : 192.168.1.30"
    End Sub
    Private Sub lblCam29_MouseHover(sender As Object, e As EventArgs) Handles lblCam29.MouseHover
        StatusText = "Cam IP : 192.168.1.31"
    End Sub
    Private Sub lblCam30_MouseHover(sender As Object, e As EventArgs) Handles lblCam30.MouseHover
        StatusText = "Cam IP : 192.168.1.32"
    End Sub
    Private Sub btnTestConnection_MouseHover(sender As Object, e As EventArgs) Handles btnTestConnection.MouseHover
        StatusText = "Check Working Camera List"
    End Sub

    Private Sub btnTestConnection_MouseLeave(sender As Object, e As EventArgs) Handles btnTestConnection.MouseLeave
        StatusText = "Ready"
    End Sub
    Private Sub btnHik_Click(sender As Object, e As EventArgs) Handles btnHik.Click
        pnlHik.Visible = True
        pnlGeo.Visible = False

    End Sub

    Private Sub btnGeo_Click(sender As Object, e As EventArgs) Handles btnGeo.Click
        pnlGeo.Visible = True
        pnlHik.Visible = False
    End Sub


End Class
