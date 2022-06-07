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
        pingTimer.Enabled = True
        Timer2.Interval = 50 '10 times a second
        lblTile.BackColor = Color.FromArgb(0, 0, 0)
        My.Settings.Save()
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
    Private Sub btnMaximise_Click(sender As Object, e As EventArgs)
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
    'Title change when click on tabs

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
                lblCam1.ForeColor = Color.White
                picBox.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.4")
            If gateCam = True Then
                lblCam2.Text = "2. Gate-1 Exit"
                lblCam2.ForeColor = Color.White
                picBox2.Image = My.Resources.confirm
            Else
                lblCam2.Text = "2. Gate-1 Exit"
                lblCam2.ForeColor = Color.White
                picBox2.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.5")
            If gateCam = True Then
                lblCam3.Text = "3. Gate-2 Entry"
                lblCam3.ForeColor = Color.White
                picBox3.Image = My.Resources.confirm
            Else
                lblCam3.Text = "3. Gate-2 Entry"
                lblCam3.ForeColor = Color.White
                picBox3.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.6")
            If gateCam = True Then
                lblCam4.Text = "4. Gate-2 Exit"
                lblCam4.ForeColor = Color.White
                picBox4.Image = My.Resources.confirm
            Else
                lblCam4.Text = "4. Gate-2 Exit"
                lblCam4.ForeColor = Color.White
                picBox4.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.7")
            If gateCam = True Then
                lblCam5.Text = "5. Gate-2 UP"
                lblCam5.ForeColor = Color.White
                picBox5.Image = My.Resources.confirm
            Else
                lblCam5.Text = "5. Gate-2 Up"
                lblCam5.ForeColor = Color.White
                picBox5.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.8")
            If gateCam = True Then
                lblCam6.Text = "6. Gate-3 Entry"
                lblCam6.ForeColor = Color.White
                picBox6.Image = My.Resources.confirm
            Else
                lblCam6.Text = "6. Gate-3 Entry"
                lblCam6.ForeColor = Color.White
                picBox6.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.9")
            If gateCam = True Then
                lblCam7.Text = "7. Gate-3 Exit"
                lblCam7.ForeColor = Color.White
                picBox7.Image = My.Resources.confirm
            Else
                lblCam7.Text = "7. Gate-3 Exit"
                lblCam7.ForeColor = Color.White
                picBox7.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.10")
            If gateCam = True Then
                lblCam8.Text = "8. Gate-3 UP"
                lblCam8.ForeColor = Color.White
                picBox8.Image = My.Resources.confirm
            Else
                lblCam8.Text = "8. Gate-3 UP"
                lblCam8.ForeColor = Color.White
                picBox8.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.11")
            If gateCam = True Then
                lblCam9.Text = "9. TKF Finishing Goods"
                lblCam9.ForeColor = Color.White
                picBox9.Image = My.Resources.confirm
            Else
                lblCam9.Text = "9. TKF Finishing Goods"
                lblCam9.ForeColor = Color.White
                picBox9.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.12")
            If gateCam = True Then
                lblCam10.Text = "10. Roadside Cam-1"
                lblCam10.ForeColor = Color.White
                picBox10.Image = My.Resources.confirm
            Else
                lblCam10.Text = "10. Roadside Cam-1"
                lblCam10.ForeColor = Color.White
                picBox10.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.13")
            If gateCam = True Then
                lblCam11.Text = "11. Roadside Cam-2"
                lblCam11.ForeColor = Color.White
                picBox11.Image = My.Resources.confirm
            Else
                lblCam11.Text = "11. Roadside Cam-2"
                lblCam11.ForeColor = Color.White
                picBox11.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.14")
            If gateCam = True Then
                lblCam12.Text = "12. Roadside Cam-3"
                lblCam12.ForeColor = Color.White
                picBox12.Image = My.Resources.confirm
            Else
                lblCam12.Text = "12. Roadside Cam-3"
                lblCam12.ForeColor = Color.White
                picBox12.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.15")
            If gateCam = True Then
                lblCam13.Text = "13. Roadside Cam-4"
                lblCam13.ForeColor = Color.White
                picBox13.Image = My.Resources.confirm
            Else
                lblCam13.Text = "13. Roadside Cam-4"
                lblCam13.ForeColor = Color.White
                picBox13.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.16")
            If gateCam = True Then
                lblCam14.Text = "14. Pipe Factory Road"
                lblCam14.ForeColor = Color.White
                picBox14.Image = My.Resources.confirm
            Else
                lblCam14.Text = "14. Pipe Factory Road"
                lblCam14.ForeColor = Color.White
                picBox14.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.17")
            If gateCam = True Then
                lblCam15.Text = "15. Roadside Cam"
                lblCam15.ForeColor = Color.White
                picBox15.Image = My.Resources.confirm
            Else
                lblCam15.Text = "15. Roadside Cam"
                lblCam15.ForeColor = Color.White
                picBox15.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.18")
            If gateCam = True Then
                lblCam16.Text = "16. Readymix Roadside"
                lblCam16.ForeColor = Color.White
                picBox16.Image = My.Resources.confirm
            Else
                lblCam16.Text = "16. Readymix Roadside"
                lblCam16.ForeColor = Color.White
                picBox16.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.19")
            If gateCam = True Then
                lblCam17.Text = "17. Readymix Tower"
                lblCam17.ForeColor = Color.White
                picBox17.Image = My.Resources.confirm
            Else
                lblCam17.Text = "17. Readymix Tower"
                lblCam17.ForeColor = Color.White
                picBox17.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.20")
            If gateCam = True Then
                lblCam18.Text = "18. Tower PTZ"
                lblCam18.ForeColor = Color.White
                picBox18.Image = My.Resources.confirm
            Else
                lblCam18.Text = "18. Tower PTZ"
                lblCam18.ForeColor = Color.White
                picBox18.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.21")
            If gateCam = True Then
                lblCam19.Text = "19. Transport PTZ"
                lblCam19.ForeColor = Color.White
                picBox19.Image = My.Resources.confirm
            Else
                lblCam19.Text = "19. Transport PTZ"
                lblCam19.ForeColor = Color.White
                picBox19.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.22")
            If gateCam = True Then
                lblCam20.Text = "20. Transport Front"
                lblCam20.ForeColor = Color.White
                picBox20.Image = My.Resources.confirm
            Else
                lblCam20.Text = "20. Transport Front"
                lblCam20.ForeColor = Color.White
                picBox20.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.23")
            If gateCam = True Then
                lblCam21.Text = "21. Transport Parking Area"
                lblCam21.ForeColor = Color.White
                picBox21.Image = My.Resources.confirm
            Else
                lblCam21.Text = "21. Transport Parking Area"
                lblCam21.ForeColor = Color.White
                picBox21.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.24")
            If gateCam = True Then
                lblCam22.Text = "22. Transport Roadside"
                lblCam22.ForeColor = Color.White
                picBox22.Image = My.Resources.confirm
            Else
                lblCam22.Text = "22. Transport Roadside"
                lblCam22.ForeColor = Color.White
                picBox22.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.25")
            If gateCam = True Then
                lblCam23.Text = "23. Safety Office Side"
                lblCam23.ForeColor = Color.White
                picBox23.Image = My.Resources.confirm
            Else
                lblCam23.Text = "23. Safety Office Side"
                lblCam23.ForeColor = Color.White
                picBox23.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.26")
            If gateCam = True Then
                lblCam24.Text = "24. Tarrace Admin Parking"
                lblCam24.ForeColor = Color.White
                picBox24.Image = My.Resources.confirm
            Else
                lblCam24.Text = "24. Tarrace Admin Parking"
                lblCam24.ForeColor = Color.White
                picBox24.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.27")
            If gateCam = True Then
                lblCam25.Text = "25. Adming Parking"
                lblCam25.ForeColor = Color.White
                picBox25.Image = My.Resources.confirm
            Else
                lblCam25.Text = "25. Admin Parking"
                lblCam25.ForeColor = Color.White
                picBox25.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.28")
            If gateCam = True Then
                lblCam26.Text = "26. Clinicside Admin Parking"
                lblCam26.ForeColor = Color.White
                picBox26.Image = My.Resources.confirm
            Else
                lblCam26.Text = "26. Clinicside Admin Parking"
                lblCam26.ForeColor = Color.White
                picBox26.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.29")
            If gateCam = True Then
                lblCam27.Text = "27. Time Keeper Exit"
                lblCam27.ForeColor = Color.White
                picBox27.Image = My.Resources.confirm
            Else
                lblCam27.Text = "27. Time Keeper Exit"
                lblCam27.ForeColor = Color.White
                picBox27.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.30")
            If gateCam = True Then
                lblCam28.Text = "28. Gate-1 Roadside"
                lblCam28.ForeColor = Color.White
                picBox28.Image = My.Resources.confirm
            Else
                lblCam28.Text = "28. Gate-1 Roadside"
                lblCam28.ForeColor = Color.White
                picBox28.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.31")
            If gateCam = True Then
                lblCam29.Text = "29. Gate-3 Outside Parking-A"
                lblCam29.ForeColor = Color.White
                picBox29.Image = My.Resources.confirm
            Else
                lblCam29.Text = "29. Gate-3 Outside Parking-A"
                lblCam29.ForeColor = Color.White
                picBox29.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.32")
            If gateCam = True Then
                lblCam30.Text = "30. Gate-3 Outside Parking-B"
                lblCam30.ForeColor = Color.White
                picBox30.Image = My.Resources.confirm
            Else
                lblCam30.Text = "30. Gate-3 Outside Parking-B"
                lblCam30.ForeColor = Color.White
                picBox30.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.33")
            If gateCam = True Then
                lblCam31.Text = "31. Car Parking-A"
                lblCam31.ForeColor = Color.White
                picBox31.Image = My.Resources.confirm
            Else
                lblCam31.Text = "31. Car Parking-A"
                lblCam31.ForeColor = Color.White
                picBox31.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.34")
            If gateCam = True Then
                lblCam32.Text = "32. Car Parking-B"
                lblCam32.ForeColor = Color.White
                picBox32.Image = My.Resources.confirm
            Else
                lblCam32.Text = "32. Car Parking-B"
                lblCam32.ForeColor = Color.White
                picBox32.Image = My.Resources.close__1_
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Ping camera From lblCam 1 to 28 Hikvision NVR-2
    Private Sub btnHikTest2_Click(sender As Object, e As EventArgs) Handles btnHikTest2.Click
        Try
            intCount += 1
            StatusText = intCount & "  Times"
            Dim gateCam As String
            gateCam = pingIPcamera("192.168.1.41")
            If gateCam = True Then
                lblHik1.Text = "1. Treatment Plant Water Tank"
                lblHik1.ForeColor = Color.White
                picHikv1.Image = My.Resources.confirm
            Else
                lblHik1.Text = "1. Treatment Plant Water Tank"
                lblHik1.ForeColor = Color.White
                picHikv1.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.42")
            If gateCam = True Then
                lblHik2.Text = "2. Treatment Plant Roadside"
                lblHik2.ForeColor = Color.White
                picHikv2.Image = My.Resources.confirm
            Else
                lblHik2.Text = "2. Treatment Plant Roadside"
                lblHik2.ForeColor = Color.White
                picHikv2.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.43")
            If gateCam = True Then
                lblHik3.Text = "3. Ice Plnat MEKA-5"
                lblHik3.ForeColor = Color.White
                picHikv3.Image = My.Resources.confirm
            Else
                lblHik3.Text = "3. Ice Plnat MEKA-5"
                lblHik3.ForeColor = Color.White
                picHikv3.Image = My.Resources.close__1_
            End If
            If gateCam = True Then
                gateCam = pingIPcamera("192.168.1.44")
                lblHik4.Text = "4. Ready mix front side"
                lblHik4.ForeColor = Color.White
                picHikv4.Image = My.Resources.confirm
            Else
                lblHik4.Text = "4. Ready mix front side"
                lblHik4.ForeColor = Color.White
                picHikv4.Image = My.Resources.close__1_
            End If

            If gateCam = True Then
                gateCam = pingIPcamera("192.168.1.45")
                lblHik5.Text = "5. MEKA-3 Front"
                lblHik5.ForeColor = Color.White
                picHikv5.Image = My.Resources.confirm
            Else
                lblHik5.Text = "5. MEKA-3 Front"
                lblHik5.ForeColor = Color.White
                picHikv5.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.46")
            If gateCam = True Then
                lblHik6.Text = "6. Workshop leth machine"
                lblHik6.ForeColor = Color.White
                picHikv6.Image = My.Resources.confirm
            Else
                lblHik6.Text = "6. Workshop leth machine"
                lblHik6.ForeColor = Color.White
                picHikv6.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.47")
            If gateCam = True Then
                lblHik7.Text = "7. IBF PTZ"
                lblHik7.ForeColor = Color.White
                picHikv7.Image = My.Resources.confirm
            Else
                lblHik7.Text = "7. IBF PTZ"
                lblHik7.ForeColor = Color.White
                picHikv7.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.48")
            If gateCam = True Then
                lblHik8.Text = "8. Masjid Upside"
                lblHik8.ForeColor = Color.White
                picHikv8.Image = My.Resources.confirm
            Else
                lblHik8.Text = "8. Masjid Upside"
                lblHik8.ForeColor = Color.White
                picHikv8.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.49")
            If gateCam = True Then
                lblHik9.Text = "9. Office Roadside"
                lblHik9.ForeColor = Color.White
                picHikv9.Image = My.Resources.confirm
            Else
                lblHik9.Text = "9. Office Roadside"
                lblHik9.ForeColor = Color.White
                picHikv9.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.50")
            If gateCam = True Then
                lblHik10.Text = "10. QC Front Side"
                lblHik10.ForeColor = Color.White
                picHikv10.Image = My.Resources.confirm
            Else
                lblHik10.Text = "10. QC Front Side"
                lblHik10.ForeColor = Color.White
                picHikv10.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.51")
            If gateCam = True Then
                lblHik11.Text = "11. Safety Office Roadside"
                lblHik11.ForeColor = Color.White
                picHikv11.Image = My.Resources.confirm
            Else
                lblHik11.Text = "11. Safety Office Roadside"
                lblHik11.ForeColor = Color.White
                picHikv11.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.52")
            If gateCam = True Then
                lblHik12.Text = "12. Safety Lecture Room"
                lblHik12.ForeColor = Color.White
                picHikv12.Image = My.Resources.confirm
            Else
                lblHik12.Text = "12. Safety Lecture Room"
                lblHik12.ForeColor = Color.White
                picHikv12.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.53")
            If gateCam = True Then
                lblHik13.Text = "13. Diesel Workshop Inside"
                lblHik13.ForeColor = Color.White
                picHikv13.Image = My.Resources.confirm
            Else
                lblHik13.Text = "13. Diesel Workshop Inside"
                lblHik13.ForeColor = Color.White
                picHikv13.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.54")
            If gateCam = True Then
                lblHik14.Text = "14. Workshop Outside Cam"
                lblHik14.ForeColor = Color.White
                picHikv14.Image = My.Resources.confirm
            Else
                lblHik14.Text = "14. Workshop Outside Cam"
                lblHik14.ForeColor = Color.White
                picHikv14.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.55")
            If gateCam = True Then
                lblHik15.Text = "15. IBF Finishing Good"
                lblHik15.ForeColor = Color.White
                picHikv15.Image = My.Resources.confirm
            Else
                lblHik15.Text = "15. IBF Finishing Good"
                lblHik15.ForeColor = Color.White
                picHikv15.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.56")
            If gateCam = True Then
                lblHik16.Text = "16. Air Station Outside"
                lblHik16.ForeColor = Color.White
                picHikv16.Image = My.Resources.confirm
            Else
                lblHik16.Text = "16. Air Station Outside"
                lblHik16.ForeColor = Color.White
                picHikv16.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.57")
            If gateCam = True Then
                lblHik17.Text = "17. QC Inside"
                lblHik17.ForeColor = Color.White
                picHikv17.Image = My.Resources.confirm
            Else
                lblHik17.Text = "17. QC Inside"
                lblHik17.ForeColor = Color.White
                picHikv17.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.58")
            If gateCam = True Then
                lblHik18.Text = "18. MEKA-3 Ice Plant"
                lblHik18.ForeColor = Color.White
                picHikv18.Image = My.Resources.confirm
            Else
                lblHik18.Text = "18. MEKA-3 Ice Plant"
                lblHik18.ForeColor = Color.White
                picHikv18.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.59")
            If gateCam = True Then
                lblHik19.Text = "19. Admin Garden Cam"
                lblHik19.ForeColor = Color.White
                picHikv19.Image = My.Resources.confirm
            Else
                lblHik19.Text = "19. Admin Garden Cam"
                lblHik19.ForeColor = Color.White
                picHikv19.Image = My.Resources.close__1_
            End If
            gateCam = pingIPcamera("192.168.1.60")
            If gateCam = True Then
                lblHik20.Text = "20. Clinic parking side"
                lblHik20.ForeColor = Color.White
                picHikv20.Image = My.Resources.confirm
            Else
                lblHik20.Text = "20. Clinic parking side"
                lblHik20.ForeColor = Color.White
                picHikv20.Image = My.Resources.close__1_
            End If
            'gateCam = pingIPcamera("192.168.1.23")
            ' If gateCam = True Then
            'lblCam21.Text = "21. Transport Parking Area"
            'lblCam21.ForeColor = Color.White
            ' picBox21.Image = My.Resources.confirm
            ' Else
            'lblCam21.Text = "21. Transport Parking Area"
            ' lblCam21.ForeColor = Color.White
            '    picBox21.Image = My.Resources.close__1_
            '  End If
            'gateCam = pingIPcamera("192.168.1.24")
            'If gateCam = True Then
            'lblCam22.Text = "22. Transport Roadside"
            'lblCam22.ForeColor = Color.White
            'picBox22.Image = My.Resources.confirm
            'Else
            'lblCam22.Text = "22. Transport Roadside"
            'lblCam22.ForeColor = Color.White
            'picBox22.Image = My.Resources.close__1_
            '   End If
            ' gateCam = pingIPcamera("192.168.1.25")
            ' If gateCam = True Then
            ' lblCam23.Text = "23. Safety Office Side"
            ' lblCam23.ForeColor = Color.White
            ' picBox23.Image = My.Resources.confirm
            ' Else
            'lblCam23.Text = "23. Safety Office Side"
            'lblCam23.ForeColor = Color.White
            'picBox23.Image = My.Resources.close__1_
            ' End If
            ' gateCam = pingIPcamera("192.168.1.26")
            'If gateCam = True Then
            'lblCam24.Text = "24. Tarrace Admin Parking"
            'lblCam24.ForeColor = Color.White
            'picBox24.Image = My.Resources.confirm
            ' Else
            'lblCam24.Text = "24. Tarrace Admin Parking"
            'lblCam24.ForeColor = Color.White
            'picBox24.Image = My.Resources.close__1_
            ' End If
            '  gateCam = pingIPcamera("192.168.1.27")
            ' If gateCam = True Then
            ' lblCam25.Text = "25. Adming Parking"
            'lblCam25.ForeColor = Color.White
            'picBox25.Image = My.Resources.confirm
            ' Else
            'lblCam25.Text = "25. Admin Parking"
            'lblCam25.ForeColor = Color.White
            'picBox25.Image = My.Resources.close__1_
            '  End If
            '  gateCam = pingIPcamera("192.168.1.28")
            ' If gateCam = True Then
            ' lblCam26.Text = "26. Clinicside Admin Parking"
            'lblCam26.ForeColor = Color.White
            ' picBox26.Image = My.Resources.confirm
            ' Else
            'lblCam26.Text = "26. Clinicside Admin Parking"
            'lblCam26.ForeColor = Color.White
            'picBox26.Image = My.Resources.close__1_
            ' End If
            ' gateCam = pingIPcamera("192.168.1.29")
            ' If gateCam = True Then
            'lblCam27.Text = "27. Time Keeper Exit"
            'lblCam27.ForeColor = Color.White
            'picBox27.Image = My.Resources.confirm
            ' Else
            'lblCam27.Text = "27. Time Keeper Exit"
            'lblCam27.ForeColor = Color.White
            'picBox27.Image = My.Resources.close__1_
            '  End If
            'gateCam = pingIPcamera("192.168.1.30")
            '  If gateCam = True Then
            'lblCam28.Text = "28. Gate-1 Roadside"
            'lblCam28.ForeColor = Color.White
            '  picBox28.Image = My.Resources.confirm
            'Else
            ' lblCam28.Text = "28. Gate-1 Roadside"
            ' lblCam28.ForeColor = Color.White
            'picBox28.Image = My.Resources.close__1_
            ' End If
            '  gateCam = pingIPcamera("192.168.1.31")
            '  If gateCam = True Then
            ' lblCam29.Text = "29. Gate-3 Outside Parking-A"
            ' lblCam29.ForeColor = Color.White
            ' picBox29.Image = My.Resources.confirm
            ' Else
            'lblCam29.Text = "29. Gate-3 Outside Parking-A"
            'lblCam29.ForeColor = Color.White
            'picBox29.Image = My.Resources.close__1_
            ' End If
            ' gateCam = pingIPcamera("192.168.1.32")
            ' If gateCam = True Then
            'lblCam30.Text = "30. Gate-3 Outside Parking-B"
            'lblCam30.ForeColor = Color.White
            '   picBox30.Image = My.Resources.confirm
            ' Else
            'lblCam30.Text = "30. Gate-3 Outside Parking-B"
            'lblCam30.ForeColor = Color.White
            'picBox30.Image = My.Resources.close__1_
            'End If
            ' gateCam = pingIPcamera("192.168.1.33")
            ' If gateCam = True Then
            'lblCam31.Text = "31. Car Parking-A"
            'lblCam31.ForeColor = Color.White
            'picBox31.Image = My.Resources.confirm
            'Else
            'lblCam31.Text = "31. Car Parking-A"
            'lblCam31.ForeColor = Color.White
            'picBox31.Image = My.Resources.close__1_
            'End If
            ' gateCam = pingIPcamera("192.168.1.34")
            'If gateCam = True Then
            'lblCam32.Text = "32. Car Parking-B"
            'lblCam32.ForeColor = Color.White
            ' picBox32.Image = My.Resources.confirm
            ' Else
            'lblCam32.Text = "32. Car Parking-B"
            'lblCam32.ForeColor = Color.White
            'picBox32.Image = My.Resources.close__1_
            ' End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'This can display status of ip address of selected cam

    Private Sub pnlHik2_MouseEnter(sender As Object, e As EventArgs) Handles pnlHik2.MouseEnter
        sslStatus.Text = "Ready"
        txtIp.Text = " "
    End Sub

    Private Sub lblHik1_MouseHover(sender As Object, e As EventArgs) Handles lblHik1.MouseHover
        StatusText = "Cam IP : 192.168.1.41"
        txtIp.Text = "192.168.1.41"
    End Sub

    Private Sub lblHik2_MouseHover(sender As Object, e As EventArgs) Handles lblHik2.MouseHover
        StatusText = "Cam IP : 192.168.1.42"
        txtIp.Text = "192.168.1.42"
    End Sub

    Private Sub lblHik3_MouseHover(sender As Object, e As EventArgs) Handles lblHik3.MouseHover
        StatusText = "Cam IP : 192.168.1.43"
        txtIp.Text = "192.168.1.43"
    End Sub

    Private Sub lblHik4_MouseHover(sender As Object, e As EventArgs) Handles lblHik4.MouseHover
        StatusText = "Cam IP : 192.168.1.44"
        txtIp.Text = "192.168.1.44"
    End Sub

    Private Sub lblHik5_MouseHover(sender As Object, e As EventArgs) Handles lblHik5.MouseHover
        StatusText = "Cam IP : 192.168.1.45"
        txtIp.Text = "192.168.1.45"
    End Sub

    Private Sub lblHik6_MouseHover(sender As Object, e As EventArgs) Handles lblHik6.MouseHover
        StatusText = "Cam IP : 192.168.1.46"
        txtIp.Text = "192.168.1.46"
    End Sub

    Private Sub lblHik7_MouseHover(sender As Object, e As EventArgs) Handles lblHik7.MouseHover
        StatusText = "Cam IP : 192.168.1.47"
        txtIp.Text = "192.168.1.47"
    End Sub

    Private Sub lblHik8_MouseHover(sender As Object, e As EventArgs) Handles lblHik8.MouseHover
        StatusText = "Cam IP : 192.168.1.48"
        txtIp.Text = "192.168.1.48"
    End Sub

    Private Sub lblHik9_MouseHover(sender As Object, e As EventArgs) Handles lblHik9.MouseHover
        StatusText = "Cam IP : 192.168.1.49"
        txtIp.Text = "192.168.1.49"
    End Sub

    Private Sub lblHik10_MouseHover(sender As Object, e As EventArgs) Handles lblHik10.MouseHover
        StatusText = "Cam IP : 192.168.1.50"
        txtIp.Text = "192.168.1.50"
    End Sub

    Private Sub lblHik11_MouseHover(sender As Object, e As EventArgs) Handles lblHik11.MouseHover
        StatusText = "Cam IP : 192.168.1.51"
        txtIp.Text = "192.168.1.51"
    End Sub

    Private Sub lblHik12_MouseHover(sender As Object, e As EventArgs) Handles lblHik12.MouseHover
        StatusText = "Cam IP : 192.168.1.52"
        txtIp.Text = "192.168.1.52"
    End Sub

    Private Sub lblHik13_MouseHover(sender As Object, e As EventArgs) Handles lblHik13.MouseHover
        StatusText = "Cam IP : 192.168.1.53"
        txtIp.Text = "192.168.1.53"
    End Sub

    Private Sub lblHik14_MouseHover(sender As Object, e As EventArgs) Handles lblHik14.MouseHover
        StatusText = "Cam IP : 192.168.1.54"
        txtIp.Text = "192.168.1.54"
    End Sub

    Private Sub lblHik15_MouseHover(sender As Object, e As EventArgs) Handles lblHik15.MouseHover
        StatusText = "Cam IP : 192.168.1.55"
        txtIp.Text = "192.168.1.55"
    End Sub

    Private Sub lblHik16_MouseHover(sender As Object, e As EventArgs) Handles lblHik16.MouseHover
        StatusText = "Cam IP : 192.168.1.56"
        txtIp.Text = "192.168.1.56"
    End Sub

    Private Sub lblHik17_MouseHover(sender As Object, e As EventArgs) Handles lblHik17.MouseHover
        StatusText = "Cam IP : 192.168.1.57"
        txtIp.Text = "192.168.1.57"
    End Sub

    Private Sub lblHik18_MouseHover(sender As Object, e As EventArgs) Handles lblHik18.MouseHover
        StatusText = "Cam IP : 192.168.1.58"
        txtIp.Text = "192.168.1.58"
    End Sub

    Private Sub lblHik19_MouseHover(sender As Object, e As EventArgs) Handles lblHik19.MouseHover
        StatusText = "Cam IP : 192.168.1.59"
        txtIp.Text = "192.168.1.59"
    End Sub

    Private Sub lblHik20_MouseHover(sender As Object, e As EventArgs) Handles lblHik20.MouseHover
        StatusText = "Cam IP : 192.168.1.60"
        txtIp.Text = "192.168.1.60"
    End Sub
    'This code is for check running status in CMD seperate window (Hik-vision NVR-2)

    Private Sub picHikv1_DoubleClick(sender As Object, e As EventArgs) Handles picHikv1.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.41")
    End Sub

    Private Sub picHikv2_DoubleClick(sender As Object, e As EventArgs) Handles picHikv2.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.42")
    End Sub

    Private Sub picHikv3_DoubleClick(sender As Object, e As EventArgs) Handles picHikv3.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.43")
    End Sub

    Private Sub picHikv4_DoubleClick(sender As Object, e As EventArgs) Handles picHikv4.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.44")
    End Sub

    Private Sub picHikv5_DoubleClick(sender As Object, e As EventArgs) Handles picHikv5.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.45")
    End Sub

    Private Sub picHikv6_DoubleClick(sender As Object, e As EventArgs) Handles picHikv6.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.46")
    End Sub

    Private Sub picHikv7_DoubleClick(sender As Object, e As EventArgs) Handles picHikv7.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.47")
    End Sub

    Private Sub picHikv8_DoubleClick(sender As Object, e As EventArgs) Handles picHikv8.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.48")
    End Sub

    Private Sub picHikv9_DoubleClick(sender As Object, e As EventArgs) Handles picHikv9.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.49")
    End Sub

    Private Sub picHikv10_DoubleClick(sender As Object, e As EventArgs) Handles picHikv10.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.50")
    End Sub

    Private Sub picHikv11_DoubleClick(sender As Object, e As EventArgs) Handles picHikv11.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.51")
    End Sub

    Private Sub picHikv12_DoubleClick(sender As Object, e As EventArgs) Handles picHikv12.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.52")
    End Sub

    Private Sub picHikv13_DoubleClick(sender As Object, e As EventArgs) Handles picHikv13.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.53")
    End Sub

    Private Sub picHikv14_DoubleClick(sender As Object, e As EventArgs) Handles picHikv14.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.54")
    End Sub

    Private Sub picHikv15_DoubleClick(sender As Object, e As EventArgs) Handles picHikv15.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.55")
    End Sub

    Private Sub picHikv16_DoubleClick(sender As Object, e As EventArgs) Handles picHikv16.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.56")
    End Sub

    Private Sub picHikv17_DoubleClick(sender As Object, e As EventArgs) Handles picHikv17.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.57")
    End Sub

    Private Sub picHikv18_DoubleClick(sender As Object, e As EventArgs) Handles picHikv18.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.58")
    End Sub

    Private Sub picHikv19_DoubleClick(sender As Object, e As EventArgs) Handles picHikv19.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.59")
    End Sub

    Private Sub picHikv20_DoubleClick(sender As Object, e As EventArgs) Handles picHikv20.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.60")
    End Sub

    'This code is for check running status in CMD seperate window (Hik-vision)
    Private Sub picBox_DoubleClick(sender As Object, e As EventArgs) Handles picBox.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.3")
    End Sub
    Private Sub picBox2_DoubleClick(sender As Object, e As EventArgs) Handles picBox2.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.4")
    End Sub

    Private Sub picBox3_DoubleClick(sender As Object, e As EventArgs) Handles picBox3.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.5")
    End Sub

    Private Sub picBox4_DoubleClick(sender As Object, e As EventArgs) Handles picBox4.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.6")
    End Sub

    Private Sub picBox5_DoubleClick(sender As Object, e As EventArgs) Handles picBox5.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.7")
    End Sub

    Private Sub picBox6_DoubleClick(sender As Object, e As EventArgs) Handles picBox6.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.8")
    End Sub

    Private Sub picBox7_DoubleClick(sender As Object, e As EventArgs) Handles picBox7.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.9")
    End Sub

    Private Sub picBox8_DoubleClick(sender As Object, e As EventArgs) Handles picBox8.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.10")
    End Sub

    Private Sub picBox9_DoubleClick(sender As Object, e As EventArgs) Handles picBox9.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.11")
    End Sub

    Private Sub picBox10_DoubleClick(sender As Object, e As EventArgs) Handles picBox10.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.12")
    End Sub

    Private Sub picBox11_DoubleClick(sender As Object, e As EventArgs) Handles picBox11.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.13")
    End Sub

    Private Sub picBox12_DoubleClick(sender As Object, e As EventArgs) Handles picBox12.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.14")
    End Sub

    Private Sub picBox13_DoubleClick(sender As Object, e As EventArgs) Handles picBox13.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.15")
    End Sub

    Private Sub picBox14_DoubleClick(sender As Object, e As EventArgs) Handles picBox14.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.16")
    End Sub

    Private Sub picBox15_DoubleClick(sender As Object, e As EventArgs) Handles picBox15.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.17")
    End Sub

    Private Sub picBox16_DoubleClick(sender As Object, e As EventArgs) Handles picBox16.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.18")
    End Sub

    Private Sub picBox17_DoubleClick(sender As Object, e As EventArgs) Handles picBox17.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.19")
    End Sub

    Private Sub picBox18_DoubleClick(sender As Object, e As EventArgs) Handles picBox18.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.20")
    End Sub

    Private Sub picBox19_DoubleClick(sender As Object, e As EventArgs) Handles picBox19.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.21")
    End Sub

    Private Sub picBox20_DoubleClick(sender As Object, e As EventArgs) Handles picBox20.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.22")
    End Sub

    Private Sub picBox21_DoubleClick(sender As Object, e As EventArgs) Handles picBox21.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.23")
    End Sub

    Private Sub picBox22_DoubleClick(sender As Object, e As EventArgs) Handles picBox22.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.24")
    End Sub

    Private Sub picBox23_DoubleClick(sender As Object, e As EventArgs) Handles picBox23.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.25")
    End Sub

    Private Sub picBox24_DoubleClick(sender As Object, e As EventArgs) Handles picBox24.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.26")
    End Sub

    Private Sub picBox25_DoubleClick(sender As Object, e As EventArgs) Handles picBox25.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.27")
    End Sub

    Private Sub picBox26_DoubleClick(sender As Object, e As EventArgs) Handles picBox26.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.28")
    End Sub

    Private Sub picBox27_DoubleClick(sender As Object, e As EventArgs) Handles picBox27.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.29")
    End Sub

    Private Sub picBox28_DoubleClick(sender As Object, e As EventArgs) Handles picBox28.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.30")
    End Sub

    Private Sub picBox29_DoubleClick(sender As Object, e As EventArgs) Handles picBox29.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.31")
    End Sub

    Private Sub picBox30_DoubleClick(sender As Object, e As EventArgs) Handles picBox30.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.32")
    End Sub

    Private Sub picBox31_DoubleClick(sender As Object, e As EventArgs) Handles picBox31.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.33")
    End Sub

    Private Sub picBox32_DoubleClick(sender As Object, e As EventArgs) Handles picBox32.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.34")
    End Sub

    'Camera ip address on hover hikvision camera name at status bar 
    Private Sub pnlHik_MouseEnter(sender As Object, e As EventArgs) Handles pnlHik.MouseEnter
        sslStatus.Text = "Ready"
        txtIp.Text = " "
    End Sub

    Private Sub lblCam1_MouseHover(sender As Object, e As EventArgs) Handles lblCam1.MouseHover
        StatusText = "Cam IP : 192.168.1.3"
        txtIp.Text = "192.168.1.3"
    End Sub
    Private Sub lblCam2_MouseHover(sender As Object, e As EventArgs) Handles lblCam2.MouseHover
        StatusText = "Cam IP : 192.168.1.4"
        txtIp.Text = "192.168.1.4"
    End Sub

    Private Sub lblCam3_MouseHover(sender As Object, e As EventArgs) Handles lblCam3.MouseHover
        StatusText = "Cam IP : 192.168.1.5"
        txtIp.Text = "192.168.1.5"
    End Sub

    Private Sub lblCam4_MouseHover(sender As Object, e As EventArgs) Handles lblCam4.MouseHover
        StatusText = "Cam IP : 192.168.1.6"
        txtIp.Text = "192.168.1.6"
    End Sub

    Private Sub lblCam5_MouseHover(sender As Object, e As EventArgs) Handles lblCam5.MouseHover
        StatusText = "Cam IP : 192.168.1.7"
        txtIp.Text = "192.168.1.7"
    End Sub

    Private Sub lblCam6_MouseHover(sender As Object, e As EventArgs) Handles lblCam6.MouseHover
        StatusText = "Cam IP : 192.168.1.8"
        txtIp.Text = "192.168.1.8"
    End Sub

    Private Sub lblCam7_MouseHover(sender As Object, e As EventArgs) Handles lblCam7.MouseHover
        StatusText = "Cam IP : 192.168.1.9"
        txtIp.Text = "192.168.1.9"
    End Sub

    Private Sub lblCam8_MouseHover(sender As Object, e As EventArgs) Handles lblCam8.MouseHover
        StatusText = "Cam IP : 192.168.1.10"
        txtIp.Text = "192.168.1.10"
    End Sub

    Private Sub lblCam9_MouseHover(sender As Object, e As EventArgs) Handles lblCam9.MouseHover
        StatusText = "Cam IP : 192.168.1.11"
        txtIp.Text = "192.168.1.11"
    End Sub

    Private Sub lblCam10_MouseHover(sender As Object, e As EventArgs) Handles lblCam10.MouseHover
        StatusText = "Cam IP : 192.168.1.12"
        txtIp.Text = "192.168.1.12"
    End Sub

    Private Sub lblCam11_MouseHover(sender As Object, e As EventArgs) Handles lblCam11.MouseHover
        StatusText = "Cam IP : 192.168.1.13"
        txtIp.Text = "192.168.1.13"
    End Sub

    Private Sub lblCam12_MouseHover(sender As Object, e As EventArgs) Handles lblCam12.MouseHover
        StatusText = "Cam IP : 192.168.1.14"
        txtIp.Text = "192.168.1.14"
    End Sub

    Private Sub lblCam13_MouseHover(sender As Object, e As EventArgs) Handles lblCam13.MouseHover
        StatusText = "Cam IP : 192.168.1.15"
        txtIp.Text = "192.168.1.15"
    End Sub

    Private Sub lblCam14_MouseHover(sender As Object, e As EventArgs) Handles lblCam14.MouseHover
        StatusText = "Cam IP : 192.168.1.16"
        txtIp.Text = "192.168.1.16"
    End Sub

    Private Sub lblCam15_MouseHover(sender As Object, e As EventArgs) Handles lblCam15.MouseHover
        StatusText = "Cam IP : 192.168.1.17"
        txtIp.Text = "192.168.1.17"
    End Sub

    Private Sub lblCam16_MouseHover(sender As Object, e As EventArgs) Handles lblCam16.MouseHover
        StatusText = "Cam IP : 192.168.1.18"
        txtIp.Text = "192.168.1.18"
    End Sub

    Private Sub lblCam17_MouseHover(sender As Object, e As EventArgs) Handles lblCam17.MouseHover
        StatusText = "Cam IP : 192.168.1.19"
        txtIp.Text = "192.168.1.19"
    End Sub

    Private Sub lblCam18_MouseHover(sender As Object, e As EventArgs) Handles lblCam18.MouseHover
        StatusText = "Cam IP : 192.168.1.20"
        txtIp.Text = "192.168.1.20"
    End Sub

    Private Sub lblCam19_MouseHover(sender As Object, e As EventArgs) Handles lblCam19.MouseHover
        StatusText = "Cam IP : 192.168.1.21"
        txtIp.Text = "192.168.1.21"
    End Sub
    Private Sub lblCam20_MouseHover(sender As Object, e As EventArgs) Handles lblCam20.MouseHover
        StatusText = "Cam IP : 192.168.1.22"
        txtIp.Text = "192.168.1.22"
    End Sub

    Private Sub lblCam21_MouseHover(sender As Object, e As EventArgs) Handles lblCam21.MouseHover
        StatusText = "Cam IP : 192.168.1.23"
        txtIp.Text = "192.168.1.23"
    End Sub
    Private Sub lblCam22_MouseHover(sender As Object, e As EventArgs) Handles lblCam22.MouseHover
        StatusText = "Cam IP : 192.168.1.24"
        txtIp.Text = "192.168.1.24"
    End Sub

    Private Sub lblCam23_MouseHover(sender As Object, e As EventArgs) Handles lblCam23.MouseHover
        StatusText = "Cam IP : 192.168.1.25"
        txtIp.Text = "192.168.1.25"
    End Sub

    Private Sub lblCam24_MouseHover(sender As Object, e As EventArgs) Handles lblCam24.MouseHover
        StatusText = "Cam IP : 192.168.1.26"
        txtIp.Text = "192.168.1.26"
    End Sub

    Private Sub lblCam25_MouseHover(sender As Object, e As EventArgs) Handles lblCam25.MouseHover
        StatusText = "Cam IP : 192.168.1.27"
        txtIp.Text = "192.168.1.27"
    End Sub

    Private Sub lblCam26_MouseHover(sender As Object, e As EventArgs) Handles lblCam26.MouseHover
        StatusText = "Cam IP : 192.168.1.28"
        txtIp.Text = "192.168.1.28"
    End Sub

    Private Sub lblCam27_MouseHover(sender As Object, e As EventArgs) Handles lblCam27.MouseHover
        StatusText = "Cam IP : 192.168.1.29"
        txtIp.Text = "192.168.1.29"
    End Sub
    Private Sub lblCam28_MouseHover(sender As Object, e As EventArgs) Handles lblCam28.MouseHover
        StatusText = "Cam IP : 192.168.1.30"
        txtIp.Text = "192.168.1.30"
    End Sub
    Private Sub lblCam29_MouseHover(sender As Object, e As EventArgs) Handles lblCam29.MouseHover
        StatusText = "Cam IP : 192.168.1.31"
        txtIp.Text = "192.168.1.31"
    End Sub
    Private Sub lblCam30_MouseHover(sender As Object, e As EventArgs) Handles lblCam30.MouseHover
        StatusText = "Cam IP : 192.168.1.32"
        txtIp.Text = "192.168.1.32"
    End Sub
    Private Sub lblCam31_MouseHover(sender As Object, e As EventArgs) Handles lblCam31.MouseHover
        StatusText = "Cam IP : 192.168.1.33"
        txtIp.Text = "192.168.1.33"
    End Sub
    Private Sub lblCam32_MouseHover(sender As Object, e As EventArgs) Handles lblCam32.MouseHover
        StatusText = "Cam IP : 192.168.1.34"
        txtIp.Text = "192.168.1.34"
    End Sub
    Private Sub btnTestConnection_MouseHover(sender As Object, e As EventArgs) Handles btnTestConnection.MouseHover
        StatusText = "Check Working Camera List"
    End Sub

    Private Sub btnTestConnection_MouseLeave(sender As Object, e As EventArgs) Handles btnTestConnection.MouseLeave
        StatusText = "Ready"
    End Sub
    'When click in these button other associated panel hide and show
    Private Sub btnHik_Click(sender As Object, e As EventArgs) Handles btnHik.Click
        pnlHik.Visible = True
        pnlGeo.Visible = False
        pnlSen.Visible = False
        pnlWire.Visible = False
        pnlHik2.Visible = False
        pnlBackup.Visible = False
        pnlOther.Visible = False
        lblTile.Text = "HIK VISION CAMERA"
        txtIp.Text = "192.168.1.2"
    End Sub
    Private Sub btnHik2_Click(sender As Object, e As EventArgs) Handles btnHik2.Click
        pnlHik.Visible = False
        pnlGeo.Visible = False
        pnlSen.Visible = False
        pnlWire.Visible = False
        pnlHik2.Visible = True
        pnlOther.Visible = False
        pnlBackup.Visible = False
        lblTile.Text = "HIK VISION NVR-2 CAMERA"
        txtIp.Text = "192.168.1.40"
    End Sub

    Private Sub btnGeo_Click(sender As Object, e As EventArgs) Handles btnGeo.Click
        pnlGeo.Visible = True
        pnlHik.Visible = False
        pnlSen.Visible = False
        pnlWire.Visible = False
        pnlHik2.Visible = False
        pnlOther.Visible = False
        pnlBackup.Visible = False
        lblTile.Text = "GEO VISION CAMERA"
        txtIp.Text = "192.168.100.1"
    End Sub
    Private Sub btnSensor_Click(sender As Object, e As EventArgs) Handles btnSensor.Click
        pnlSen.Visible = True
        pnlHik.Visible = False
        pnlGeo.Visible = False
        pnlWire.Visible = False
        pnlOther.Visible = False
        pnlBackup.Visible = False
        lblTile.Text = "NIC SENSOR DEVICE"
    End Sub
    Private Sub btnWire_Click_1(sender As Object, e As EventArgs) Handles btnWire.Click
        pnlWire.Visible = True
        pnlSen.Visible = False
        pnlHik.Visible = False
        pnlGeo.Visible = False
        pnlHik2.Visible = False
        pnlOther.Visible = False
        pnlBackup.Visible = False
        lblTile.Text = "NIC WIRELESS DEVICE"


    End Sub
    'Geo vision camera listing codes
    Private Sub btnckeck_Click(sender As Object, e As EventArgs) Handles btnckeck.Click

        Try
            sslStatus.Text = "Checking"
            Dim geoCam As String
            ListView1.Items.Clear()
            ListView2.Items.Clear()

            ListView1.ForeColor = Color.Green
            ListView2.ForeColor = Color.OrangeRed
            Dim lvitem As ListViewItem
            Dim lvitem2 As ListViewItem
            geoCam = pingIPcamera("192.168.100.21")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("1. TKF Entrance")
                lvitem.SubItems.Add("192.168.100.21")
            Else
                lvitem2 = Me.ListView2.Items.Add("1. TKF Entrance")
                lvitem2.SubItems.Add("192.168.100.21")
            End If
            geoCam = pingIPcamera("192.168.100.22")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("2. TKF-2")
                lvitem.SubItems.Add("192.168.100.22")
            Else
                lvitem2 = Me.ListView2.Items.Add("2. TKF-2")
                lvitem2.SubItems.Add("192.168.100.22")
            End If
            geoCam = pingIPcamera("192.168.100.23")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("3. TKF Masa")
                lvitem.SubItems.Add("192.168.100.23")
            Else
                lvitem2 = Me.ListView2.Items.Add("3. TKF Masa")
                lvitem2.SubItems.Add("192.168.100.23")
            End If
            geoCam = pingIPcamera("192.168.100.24")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("4. TKF Back Steam Room")
                lvitem.SubItems.Add("192.168.100.24")
            Else
                lvitem2 = Me.ListView2.Items.Add("4. TKF Back Steam Room")
                lvitem2.SubItems.Add("192.168.100.24")
            End If
            geoCam = pingIPcamera("192.168.100.27")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("5. TKF FingerCar")
                lvitem.SubItems.Add("192.168.100.27")
            Else
                lvitem2 = Me.ListView2.Items.Add("5  TKF FingerCar")
                lvitem2.SubItems.Add("192.168.100.27")
            End If
            geoCam = pingIPcamera("192.168.100.28")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("6. TKF Inside Room")
                lvitem.SubItems.Add("192.168.100.28")
            Else
                lvitem2 = Me.ListView2.Items.Add("6. TKF Inside Room")
                lvitem2.SubItems.Add("192.168.100.28")
            End If
            geoCam = pingIPcamera("192.168.100.25")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("7. Readymix Vehicle Cleaning Area")
                lvitem.SubItems.Add("192.168.100.25")
            Else
                lvitem2 = Me.ListView2.Items.Add("7. Readymix Vehicle Cleaning Area")
                lvitem2.SubItems.Add("192.168.100.25")
            End If
            geoCam = pingIPcamera("192.168.100.76")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("8. TKF Block Filling Area")
                lvitem.SubItems.Add("192.168.100.76")
            Else
                lvitem2 = Me.ListView2.Items.Add("8. TKF Block Filling Area")
                lvitem2.SubItems.Add("192.168.100.76")
            End If
            geoCam = pingIPcamera("192.168.100.33")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("9. IBF/TKF Office Building UP")
                lvitem.SubItems.Add("192.168.100.33")
            Else
                lvitem2 = Me.ListView2.Items.Add("9. IBF/TKF Office Building UP")
                lvitem2.SubItems.Add("192.168.100.33")
            End If
            geoCam = pingIPcamera("192.168.100.34")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("10. TKF Fielding 3&4")
                lvitem.SubItems.Add("192.168.100.34")
            Else
                lvitem2 = Me.ListView2.Items.Add("10. TKF Fielding 3&4")
                lvitem2.SubItems.Add("192.168.100.34")
            End If
            geoCam = pingIPcamera("192.168.100.35")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("11. TKF_2")
                lvitem.SubItems.Add("192.168.100.35")
            Else
                lvitem2 = Me.ListView2.Items.Add("11. TKF_2")
                lvitem2.SubItems.Add("192.168.100.35")
            End If
            geoCam = pingIPcamera("192.168.100.36")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("12. TKF_3")
                lvitem.SubItems.Add("192.168.100.36")
            Else
                lvitem2 = Me.ListView2.Items.Add("12. TKF_3")
                lvitem2.SubItems.Add("192.168.100.36")
            End If
            geoCam = pingIPcamera("192.168.100.37")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("13. TKF_4")
                lvitem.SubItems.Add("192.168.100.37")
            Else
                lvitem2 = Me.ListView2.Items.Add("13. TKF_4")
                lvitem2.SubItems.Add("192.168.100.37")
            End If
            geoCam = pingIPcamera("192.168.100.38")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("14. TKF_5")
                lvitem.SubItems.Add("192.168.100.38")
            Else
                lvitem2 = Me.ListView2.Items.Add("14. TKF_5")
                lvitem2.SubItems.Add("192.168.100.38")
            End If
            geoCam = pingIPcamera("192.168.100.39")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("15. TKF Fielding 1&2")
                lvitem.SubItems.Add("192.168.100.39")
            Else
                lvitem2 = Me.ListView2.Items.Add("15. TKF Fielding 1&2")
                lvitem2.SubItems.Add("192.168.100.39")
            End If
            geoCam = pingIPcamera("192.168.100.40")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("16. TKF 7")
                lvitem.SubItems.Add("192.168.100.40")
            Else
                lvitem2 = Me.ListView2.Items.Add("16. TKF 7")
                lvitem2.SubItems.Add("192.168.100.40")
            End If
            geoCam = pingIPcamera("192.168.100.41")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("17. TKF_8")
                lvitem.SubItems.Add("192.168.100.41")
            Else
                lvitem2 = Me.ListView2.Items.Add("17. TKF_8")
                lvitem2.SubItems.Add("192.168.100.41")
            End If
            geoCam = pingIPcamera("192.168.100.42")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("18. TKF_9")
                lvitem.SubItems.Add("192.168.100.42")
            Else
                lvitem2 = Me.ListView2.Items.Add("18. TKF_9")
                lvitem2.SubItems.Add("192.168.100.42")
            End If
            geoCam = pingIPcamera("192.168.100.43")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("19. TKF_10")
                lvitem.SubItems.Add("192.168.100.43")
            Else
                lvitem2 = Me.ListView2.Items.Add("19. TKF_10")
                lvitem2.SubItems.Add("192.168.100.43")
            End If
            geoCam = pingIPcamera("192.168.100.44")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("20. TKF Backside A")
                lvitem.SubItems.Add("192.168.100.44")
            Else
                lvitem2 = Me.ListView2.Items.Add("20. TKF Backside A")
                lvitem2.SubItems.Add("192.168.100.44")
            End If
            geoCam = pingIPcamera("192.168.100.45")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("21. TKF Backside B")
                lvitem.SubItems.Add("192.168.100.45")
            Else
                lvitem2 = Me.ListView2.Items.Add("21. TKF Backside B")
                lvitem2.SubItems.Add("192.168.100.45")
            End If
            geoCam = pingIPcamera("192.168.100.48")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("22. Air Station Inside")
                lvitem.SubItems.Add("192.168.100.48")
            Else
                lvitem2 = Me.ListView2.Items.Add("22. Air Station Inside")
                lvitem2.SubItems.Add("192.168.100.48")
            End If
            'geoCam = pingIPcamera("192.168.100.49")-------------------------------------------------------
            'If geoCam = True Then
            'lvitem = Me.ListView1.Items.Add("23. Air station Infront Side")
            'lvitem.SubItems.Add("192.168.100.49")
            'Else
            'lvitem2 = Me.ListView2.Items.Add("23. Air station Infront Side")
            'lvitem2.SubItems.Add("192.168.100.49")
            'End If ---------------------------------------------------------------------------------------------
            ' geoCam = pingIPcamera("192.168.100.50")
            ' If geoCam = True Then
            'lvitem = Me.ListView1.Items.Add("24. Lab. Inside")
            'lvitem.SubItems.Add("192.168.100.50")
            'Else
            'lvitem2 = Me.ListView2.Items.Add("24. Lab. Inside")
            'lvitem2.SubItems.Add("192.168.100.50")
            'End If
            geoCam = pingIPcamera("192.168.100.51")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("25. Lab. Inside The Room")
                lvitem.SubItems.Add("192.168.100.51")
            Else
                lvitem2 = Me.ListView2.Items.Add("25. Lab. Inside The Room")
                'lvitem2.SubItems.Add("192.168.100.51")
            End If
            geoCam = pingIPcamera("192.168.100.52")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("26. Technical Store UP On Gate")
                lvitem.SubItems.Add("192.168.100.52")
            Else
                lvitem2 = Me.ListView2.Items.Add("26. Technical Store UP On Gate")
                lvitem2.SubItems.Add("192.168.100.52")
            End If
            geoCam = pingIPcamera("192.168.100.53")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("27. Technical Store 2nd Floor")
                lvitem.SubItems.Add("192.168.100.53")
            Else
                lvitem2 = Me.ListView2.Items.Add("27. Technical Store 2nd Floor")
                lvitem2.SubItems.Add("192.168.100.53")
            End If
            geoCam = pingIPcamera("192.168.100.54")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("28. Technical Store Near Office")
                lvitem.SubItems.Add("192.168.100.54")
            Else
                lvitem2 = Me.ListView2.Items.Add("28. Technical Store Near Office")
                lvitem2.SubItems.Add("192.168.100.54")
            End If
            geoCam = pingIPcamera("192.168.100.55")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("29. Workshop Leth Machine Up")
                lvitem.SubItems.Add("192.168.100.55")
            Else
                lvitem2 = Me.ListView2.Items.Add("29. Workshop Leth Machine Up")
                lvitem2.SubItems.Add("192.168.100.55")
            End If
            geoCam = pingIPcamera("192.168.100.56")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("30. Workshop Diesel Up")
                lvitem.SubItems.Add("192.168.100.56")
            Else
                lvitem2 = Me.ListView2.Items.Add("30. Workshop Diesel Up")
                lvitem2.SubItems.Add("192.168.100.56")
            End If
            geoCam = pingIPcamera("192.168.100.57")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("31. Vehicle Maintenance Inside")
                lvitem.SubItems.Add("192.168.100.57")
            Else
                lvitem2 = Me.ListView2.Items.Add("31. Vehicle Maintenance Inside")
                lvitem2.SubItems.Add("192.168.100.57")
            End If
            geoCam = pingIPcamera("192.168.100.58")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("32. Back Diesel Workshop")
                lvitem.SubItems.Add("192.168.100.58")
            Else
                lvitem2 = Me.ListView2.Items.Add("32. Back Diesel Workshop")
                lvitem2.SubItems.Add("192.168.100.58")
            End If
            geoCam = pingIPcamera("192.168.100.59")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("33. Inside Vehicle")
                lvitem.SubItems.Add("192.168.100.59")
            Else
                lvitem2 = Me.ListView2.Items.Add("33. Inside Vehicle")
                lvitem2.SubItems.Add("192.168.100.59")
            End If
            geoCam = pingIPcamera("192.168.100.64")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("34. Infornt Of Vehicle Maintenance")
                lvitem.SubItems.Add("192.168.100.64")
            Else
                lvitem2 = Me.ListView2.Items.Add("34. Infornt Of Vehicle Maintenance")
                lvitem2.SubItems.Add("192.168.100.64")
            End If
            geoCam = pingIPcamera("192.168.100.65")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("35. Raw Material Store Room 1")
                lvitem.SubItems.Add("192.168.100.65")
            Else
                lvitem2 = Me.ListView2.Items.Add("35. Raw Material Store Room 1")
                lvitem2.SubItems.Add("192.168.100.65")
            End If
            geoCam = pingIPcamera("192.168.100.66")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("36. Raw Material Store 3")
                lvitem.SubItems.Add("192.168.100.66")
            Else
                lvitem2 = Me.ListView2.Items.Add("36. Raw Material Store 3")
                lvitem2.SubItems.Add("192.168.100.66")
            End If
            geoCam = pingIPcamera("192.168.100.67")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("37. RAW MATERIAL STORE ROOM 2")
                lvitem.SubItems.Add("192.168.100.67")
            Else
                lvitem2 = Me.ListView2.Items.Add("37. RAW MATERIAL STORE ROOM 2")
                lvitem2.SubItems.Add("192.168.100.67")
            End If
            geoCam = pingIPcamera("192.168.100.68")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("38. Up Fleet Office")
                lvitem.SubItems.Add("192.168.100.68")
            Else
                lvitem2 = Me.ListView2.Items.Add("38. Up Fleet Office")
                lvitem2.SubItems.Add("192.168.100.68")
            End If
            geoCam = pingIPcamera("192.168.100.126")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("39. TKF Block Yard")
                lvitem.SubItems.Add("192.168.100.126")
            Else
                lvitem2 = Me.ListView2.Items.Add("39. TKF Block Yard")
                lvitem2.SubItems.Add("192.168.100.126")
            End If
            geoCam = pingIPcamera("192.168.100.71")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("40. Transport Road side PTZ")
                lvitem.SubItems.Add("192.168.100.71")
            Else
                lvitem2 = Me.ListView2.Items.Add("40. Transport Road side PTZ")
                lvitem2.SubItems.Add("192.168.100.71")
            End If
            geoCam = pingIPcamera("192.168.100.29")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("41. TKF Block Yard Long View")
                lvitem.SubItems.Add("192.168.100.29")
            Else
                lvitem2 = Me.ListView2.Items.Add("41. TKF Block Yard Long View")
                lvitem2.SubItems.Add("192.168.100.29")
            End If
            geoCam = pingIPcamera("192.168.100.77")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("42. TREATMENT PLANT BOUNDARY")
                lvitem.SubItems.Add("192.168.100.77")
            Else
                lvitem2 = Me.ListView2.Items.Add("42. TREATMENT PLANT BOUNDARY")
                lvitem2.SubItems.Add("192.168.100.77")
            End If
            geoCam = pingIPcamera("192.168.100.26")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("43. Gate-3 Up")
                lvitem.SubItems.Add("192.168.100.26")
            Else
                lvitem2 = Me.ListView2.Items.Add("43. Gate-3 Up")
                lvitem2.SubItems.Add("192.168.100.26")
            End If
            geoCam = pingIPcamera("192.168.100.79")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("44. Washing Station Mizzan UP")
                lvitem.SubItems.Add("192.168.100.79")
            Else
                lvitem2 = Me.ListView2.Items.Add("44. Washing Station Mizzan UP")
                lvitem2.SubItems.Add("192.168.100.79")
            End If
            geoCam = pingIPcamera("192.168.100.80")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("45. Washing Station Backside RM")
                lvitem.SubItems.Add("192.168.100.80")
            Else
                lvitem2 = Me.ListView2.Items.Add("45. Washing Station Backside RM")
                lvitem2.SubItems.Add("192.168.100.80")
            End If
            'geoCam = pingIPcamera("192.168.100.81")--------------------------------------------------
            'If geoCam = True Then
            'lvitem = Me.ListView1.Items.Add("46. Ready Mix At Silo A")
            'lvitem.SubItems.Add("192.168.100.81")
            'Else
            'lvitem2 = Me.ListView2.Items.Add("46. Ready Mix At Silo A")
            'lvitem2.SubItems.Add("192.168.100.81")
            ' End If
            ' geoCam = pingIPcamera("192.168.100.82")
            ' If geoCam = True Then
            'lvitem = Me.ListView1.Items.Add("47. Ready Mix At Silo B")
            'lvitem.SubItems.Add("192.168.100.82")
            ' Else
            'lvitem2 = Me.ListView2.Items.Add("47. Ready Mix At Silo B")
            'lvitem2.SubItems.Add("192.168.100.82")
            '  End If --------------------------------------------------------------------------
            geoCam = pingIPcamera("192.168.100.83")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("48. Ready Mix At Meka 1")
                lvitem.SubItems.Add("192.168.100.83")
            Else
                lvitem2 = Me.ListView2.Items.Add("48. Ready Mix At Meka 1")
                lvitem2.SubItems.Add("192.168.100.83")
            End If
            geoCam = pingIPcamera("192.168.100.124")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("49. Scrap_Yard_Parking")
                lvitem.SubItems.Add("192.168.100.124")
            Else
                lvitem2 = Me.ListView2.Items.Add("49. Scrap_Yard_Parking")
                lvitem2.SubItems.Add("192.168.100.124")
            End If
            geoCam = pingIPcamera("192.168.100.101")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("50. Infront Of Pipe Factory")
                lvitem.SubItems.Add("192.168.100.101")
            Else
                lvitem2 = Me.ListView2.Items.Add("50. Infront Of Pipe Factory")
                lvitem2.SubItems.Add("192.168.100.101")
            End If
            geoCam = pingIPcamera("192.168.100.103")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("51. Pipe Factory Fleximatic")
                lvitem.SubItems.Add("192.168.100.103")
            Else
                lvitem2 = Me.ListView2.Items.Add("51. Pipe Factory Fleximatic")
                lvitem2.SubItems.Add("192.168.100.103")
            End If
            geoCam = pingIPcamera("192.168.100.104")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("52. Pipe Factory Supermatic")
                lvitem.SubItems.Add("192.168.100.104")
            Else
                lvitem2 = Me.ListView2.Items.Add("52. Pipe Factory Supermatic")
                lvitem2.SubItems.Add("192.168.100.104")
            End If
            geoCam = pingIPcamera("192.168.100.105")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("53. Pipe Factory Module 360")
                lvitem.SubItems.Add("192.168.100.105")
            Else
                lvitem2 = Me.ListView2.Items.Add("53. Pipe Factory Module 360")
                lvitem2.SubItems.Add("192.168.100.105")
            End If
            geoCam = pingIPcamera("192.168.100.106")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("54. Pipe Factory 160 Module")
                lvitem.SubItems.Add("192.168.100.106")
            Else
                lvitem2 = Me.ListView2.Items.Add("54. Pipe Factory 160 Module")
                lvitem2.SubItems.Add("192.168.100.106")
            End If
            geoCam = pingIPcamera("192.168.100.107")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("55. Pipe Wire Drwaing Machine")
                lvitem.SubItems.Add("192.168.100.107")
            Else
                lvitem2 = Me.ListView2.Items.Add("55. Pipe Wire Drwaing Machine")
                lvitem2.SubItems.Add("192.168.100.107")
            End If
            geoCam = pingIPcamera("192.168.100.108")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("56. Pipe Factory Zublin 2")
                lvitem.SubItems.Add("192.168.100.108")
            Else
                lvitem2 = Me.ListView2.Items.Add("56. Pipe Factory Zublin 2")
                lvitem2.SubItems.Add("192.168.100.108")
            End If
            geoCam = pingIPcamera("192.168.100.109")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("57. Pipe Factory Zublin 1")
                lvitem.SubItems.Add("192.168.100.109")
            Else
                lvitem2 = Me.ListView2.Items.Add("57. Pipe Factory Zublin 1")
                lvitem2.SubItems.Add("192.168.100.109")
            End If
            geoCam = pingIPcamera("192.168.100.110")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("58. Pipe Scrap Block Area")
                lvitem.SubItems.Add("192.168.100.110")
            Else
                lvitem2 = Me.ListView2.Items.Add("58. Pipe Scrap Block Area")
                lvitem2.SubItems.Add("192.168.100.110")
            End If
            geoCam = pingIPcamera("192.168.100.111")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("59. Pipe Scrap Block Area")
                lvitem.SubItems.Add("192.168.100.111")
            Else
                lvitem2 = Me.ListView2.Items.Add("59. Pipe Scrap Block Area")
                lvitem2.SubItems.Add("192.168.100.111")
            End If
            geoCam = pingIPcamera("192.168.100.112")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("60. Pipe Scrap Block Area")
                lvitem.SubItems.Add("192.168.100.112")
            Else
                lvitem2 = Me.ListView2.Items.Add("60. Pipe Scrap Block Area")
                lvitem2.SubItems.Add("192.168.100.112")
            End If
            geoCam = pingIPcamera("192.168.100.113")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("61. IBF Boundary Near ACICO")
                lvitem.SubItems.Add("192.168.100.113")
            Else
                lvitem2 = Me.ListView2.Items.Add("61. IBF Boundary Near ACICO")
                lvitem2.SubItems.Add("192.168.100.113")
            End If
            '--------------------------- ' geoCam = pingIPcamera("192.168.100.114") --------------------------------
            ' If geoCam = True Then
            '  lvitem = Me.ListView1.Items.Add("62. IBF PTZ")
            ' lvitem.SubItems.Add("192.168.100.114")
            ' Else
            '  lvitem2 = Me.ListView2.Items.Add("62. IBF PTZ")
            '    lvitem2.SubItems.Add("192.168.100.114")
            'End If-----------------------------------------------
            ' geoCam = pingIPcamera("192.168.100.115")
            'If geoCam = True Then
            'lvitem = Me.ListView1.Items.Add("63. Interblock Factory")
            'lvitem.SubItems.Add("192.168.100.115")
            'Else
            'lvitem2 = Me.ListView2.Items.Add("63. Interblock Factory")
            'lvitem2.SubItems.Add("192.168.100.115")
            ' End If --------------------------------------------------------

            geoCam = pingIPcamera("192.168.100.116")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("64. Interblock Masjid")
                lvitem.SubItems.Add("192.168.100.116")
            Else
                lvitem2 = Me.ListView2.Items.Add("64. Interblock Masjid")
                lvitem2.SubItems.Add("192.168.100.116")
            End If
            geoCam = pingIPcamera("192.168.100.117")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("65. Interblock Inside")
                lvitem.SubItems.Add("192.168.100.117")
            Else
                lvitem2 = Me.ListView2.Items.Add("65. Interblock Inside")
                lvitem2.SubItems.Add("192.168.100.117")
            End If
            geoCam = pingIPcamera("192.168.100.118")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("66. Interblock Henke")
                lvitem.SubItems.Add("192.168.100.118")
            Else
                lvitem2 = Me.ListView2.Items.Add("66. Interblock Henke")
                lvitem2.SubItems.Add("192.168.100.118")
            End If
            geoCam = pingIPcamera("192.168.100.119")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("67. IBF Henke Modules and Pallates")
                lvitem.SubItems.Add("192.168.100.119")
            Else
                lvitem2 = Me.ListView2.Items.Add("67. IBF Henke Modules and Pallates")
                lvitem2.SubItems.Add("192.168.100.119")
            End If
            geoCam = pingIPcamera("192.168.100.120")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("68. IBF MASA")
                lvitem.SubItems.Add("192.168.100.120")
            Else
                lvitem2 = Me.ListView2.Items.Add("68. IBF MASA")
                lvitem2.SubItems.Add("192.168.100.120")
            End If
            geoCam = pingIPcamera("192.168.100.121")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("69. IBF Masa Steam Room Beside")
                lvitem.SubItems.Add("192.168.100.121")
            Else
                lvitem2 = Me.ListView2.Items.Add("69. IBF Masa Steam Room Beside")
                lvitem2.SubItems.Add("192.168.100.121")
            End If
            geoCam = pingIPcamera("192.168.100.122")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("70. IBF Masa Corner Side")
                lvitem.SubItems.Add("192.168.100.122")
            Else
                lvitem2 = Me.ListView2.Items.Add("70. IBF Masa Corner Side")
                lvitem2.SubItems.Add("192.168.100.122")
            End If
            geoCam = pingIPcamera("192.168.100.123")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("71. IBF Masa Modules and Pallates")
                lvitem.SubItems.Add("192.168.100.123")
            Else
                lvitem2 = Me.ListView2.Items.Add("71. IBF Masa Modules and Pallates")
                lvitem2.SubItems.Add("192.168.100.123")
            End If
            geoCam = pingIPcamera("192.168.100.125")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("72. IBF Factory Finishing Goods")
                lvitem.SubItems.Add("192.168.100.125")
            Else
                lvitem2 = Me.ListView2.Items.Add("72. IBF Factory Finishing Goods")
                lvitem2.SubItems.Add("192.168.100.125")
            End If
            geoCam = pingIPcamera("192.168.100.127")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("73. Gate-2 Inside")
                lvitem.SubItems.Add("192.168.100.127")
            Else
                lvitem2 = Me.ListView2.Items.Add("73. Gate-2 Inside")
                lvitem2.SubItems.Add("192.168.100.127")
            End If
            geoCam = pingIPcamera("192.168.100.128")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("74. Gate-3 Inside")
                lvitem.SubItems.Add("192.168.100.128")
            Else
                lvitem2 = Me.ListView2.Items.Add("74. Gate-3 Inside")
                lvitem2.SubItems.Add("192.168.100.128")
            End If
            geoCam = pingIPcamera("192.168.100.46")
            If geoCam = True Then

                lvitem = Me.ListView1.Items.Add("75. QC Back Side")
                lvitem.SubItems.Add("192.168.100.46")
            Else
                lvitem2 = Me.ListView2.Items.Add("75. QC Back Side")
                lvitem2.SubItems.Add("192.168.100.46")
            End If
            geoCam = pingIPcamera("192.168.100.47")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("76. Back At Tech. Store")
                lvitem.SubItems.Add("192.168.100.47")
            Else
                lvitem2 = Me.ListView2.Items.Add("76. Back At Tech. Store")
                lvitem2.SubItems.Add("192.168.100.47")
            End If
            geoCam = pingIPcamera("192.168.100.90")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("77. Pipe Factory Terrace")
                lvitem.SubItems.Add("192.168.100.90")
            Else
                lvitem2 = Me.ListView2.Items.Add("77. Pipe Factory Terrace")
                lvitem2.SubItems.Add("192.168.100.90")
            End If
            geoCam = pingIPcamera("192.168.100.91")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("78. Transport_Panchar_Area")
                lvitem.SubItems.Add("192.168.100.91")
            Else
                lvitem2 = Me.ListView2.Items.Add("78. Transport_Panchar_Area")
                lvitem2.SubItems.Add("192.168.100.91")
            End If
            geoCam = pingIPcamera("192.168.100.93")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("79. Carpenter_block")
                lvitem.SubItems.Add("192.168.100.93")
            Else
                lvitem2 = Me.ListView2.Items.Add("79. Carpenter_block")
                lvitem2.SubItems.Add("192.168.100.93")
            End If
            geoCam = pingIPcamera("192.168.100.131")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("80. Clinic_Area")
                lvitem.SubItems.Add("192.168.100.131")
            Else
                lvitem2 = Me.ListView2.Items.Add("80. Clinic_Area")
                lvitem2.SubItems.Add("192.168.100.131")
            End If
            geoCam = pingIPcamera("192.168.100.132")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("81. Admin_Reception_Area")
                lvitem.SubItems.Add("192.168.100.132")
            Else
                lvitem2 = Me.ListView2.Items.Add("81. Admin_Reception_Area")
                lvitem2.SubItems.Add("192.168.100.132")
            End If
            geoCam = pingIPcamera("192.168.100.133")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("82. Admin_Entrance")
                lvitem.SubItems.Add("192.168.100.133")
            Else
                lvitem2 = Me.ListView2.Items.Add("82. Admin_Entrance")
                lvitem2.SubItems.Add("192.168.100.133")
            End If
            geoCam = pingIPcamera("192.168.100.134")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("83. Accounts_Section")
                lvitem.SubItems.Add("192.168.100.134")
            Else
                lvitem2 = Me.ListView2.Items.Add("83. Accounts_Section")
                lvitem2.SubItems.Add("192.168.100.134")
            End If
            geoCam = pingIPcamera("192.168.100.135")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("84. Admin_Upstair")
                lvitem.SubItems.Add("192.168.100.135")
            Else
                lvitem2 = Me.ListView2.Items.Add("84. Admin_Upstair")
                lvitem2.SubItems.Add("192.168.100.135")
            End If
            geoCam = pingIPcamera("192.168.100.137")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("85. security room")
                lvitem.SubItems.Add("192.168.100.137")
            Else
                lvitem2 = Me.ListView2.Items.Add("85. security room")
                lvitem2.SubItems.Add("192.168.100.137")
            End If
            geoCam = pingIPcamera("192.168.100.138")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("86. IT_Department_Entrance")
                lvitem.SubItems.Add("192.168.100.138")
            Else
                lvitem2 = Me.ListView2.Items.Add("86. IT_Department_Entrance")
                lvitem2.SubItems.Add("192.168.100.138")
            End If
            geoCam = pingIPcamera("192.168.100.92")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("87. Painting_Area")
                lvitem.SubItems.Add("192.168.100.92")
            Else
                lvitem2 = Me.ListView2.Items.Add("87. Painting_Area")
                lvitem2.SubItems.Add("192.168.100.92")
            End If
            geoCam = pingIPcamera("192.168.100.85")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("88. RM_Mixer_Clean_Area")
                lvitem.SubItems.Add("192.168.100.85")
            Else
                lvitem2 = Me.ListView2.Items.Add("88. RM_Mixer_Clean_Area")
                lvitem2.SubItems.Add("192.168.100.85")
            End If
            geoCam = pingIPcamera("192.168.100.96")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("89. TECHNICAL OIL STORE")
                lvitem.SubItems.Add("192.168.100.96")
            Else
                lvitem2 = Me.ListView2.Items.Add("89. TECHNICAL OIL STORE")
                lvitem2.SubItems.Add("192.168.100.96")
            End If
            geoCam = pingIPcamera("192.168.100.95")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("90. Workshop_Section")
                lvitem.SubItems.Add("192.168.100.95")
            Else
                lvitem2 = Me.ListView2.Items.Add("90. Workshop_Section")
                lvitem2.SubItems.Add("192.168.100.95")
            End If
            geoCam = pingIPcamera("192.168.100.88")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("91. Ready_Mix_Store A")
                lvitem.SubItems.Add("192.168.100.88")
            Else
                lvitem2 = Me.ListView2.Items.Add("91. Ready_Mix_Store A")
                lvitem2.SubItems.Add("192.168.100.88")
            End If
            geoCam = pingIPcamera("192.168.100.87")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("92. Ready_Mix_UP Electric_room")
                lvitem.SubItems.Add("192.168.100.87")
            Else
                lvitem2 = Me.ListView2.Items.Add("92. Ready_Mix_UP Electric_room")
                lvitem2.SubItems.Add("192.168.100.87")
            End If
            geoCam = pingIPcamera("192.168.100.89")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("93. Ready_Mix_Store B")
                lvitem.SubItems.Add("192.168.100.89")
            Else
                lvitem2 = Me.ListView2.Items.Add("93. Ready_Mix_Store B")
                lvitem2.SubItems.Add("192.168.100.89")
            End If
            geoCam = pingIPcamera("192.168.100.139")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("94. HR Department lobby")
                lvitem.SubItems.Add("192.168.100.139")
            Else
                lvitem2 = Me.ListView2.Items.Add("94. HR Department lobby")
                lvitem2.SubItems.Add("192.168.100.139")
            End If
            geoCam = pingIPcamera("192.168.100.94")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("95. Workshop Welding A")
                lvitem.SubItems.Add("192.168.100.94")
            Else
                lvitem2 = Me.ListView2.Items.Add("95. Workshop Welding A")
                lvitem2.SubItems.Add("192.168.100.94")
            End If
            geoCam = pingIPcamera("192.168.100.136")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("96. Sales and Marketing Front")
                lvitem.SubItems.Add("192.168.100.136")
            Else
                lvitem2 = Me.ListView2.Items.Add("96. Sales and Marketing Front")
                lvitem2.SubItems.Add("192.168.100.136")
            End If
            geoCam = pingIPcamera("192.168.100.140")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("97. Sales Reception Area")
                lvitem.SubItems.Add("192.168.100.140")
            Else
                lvitem2 = Me.ListView2.Items.Add("97. Sales Reception Area")
                lvitem2.SubItems.Add("192.168.100.140")
            End If
            geoCam = pingIPcamera("192.168.100.141")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("98. Sales_Cashier")
                lvitem.SubItems.Add("192.168.100.141")
            Else
                lvitem2 = Me.ListView2.Items.Add("98. Sales_Cashier")
                lvitem2.SubItems.Add("192.168.100.141")
            End If
            geoCam = pingIPcamera("192.168.100.142")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("99. Cladding_1")
                lvitem.SubItems.Add("192.168.100.142")
            Else
                lvitem2 = Me.ListView2.Items.Add("99. Cladding_1")
                lvitem2.SubItems.Add("192.168.100.142")
            End If
            geoCam = pingIPcamera("192.168.100.143")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("100. Cladding_2")
                lvitem.SubItems.Add("192.168.100.143")
            Else
                lvitem2 = Me.ListView2.Items.Add("100. Cladding_2")
                lvitem2.SubItems.Add("192.168.100.143")
            End If
            '-------------------------------------------------------------------------------
            ' geoCam = pingIPcamera("192.168.100.144")
            'If geoCam = True Then
            'lvitem = Me.ListView1.Items.Add("101. Cladding_3")
            ' lvitem.SubItems.Add("192.168.100.144")
            ' Else
            'lvitem2 = Me.ListView2.Items.Add("101. Cladding_3")
            'lvitem2.SubItems.Add("192.168.100.144")
            'End If
            '       -----------------------------------------------------------------------------------------
            geoCam = pingIPcamera("192.168.100.145")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("102. Cladding_4")
                lvitem.SubItems.Add("192.168.100.145")
            Else
                lvitem2 = Me.ListView2.Items.Add("102. Cladding_4")
                lvitem2.SubItems.Add("192.168.100.145")
            End If
            geoCam = pingIPcamera("192.168.100.146")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("103. Cladding_5")
                lvitem.SubItems.Add("192.168.100.146")
            Else
                lvitem2 = Me.ListView2.Items.Add("103. Cladding_5")
                lvitem2.SubItems.Add("192.168.100.146")
            End If
            geoCam = pingIPcamera("192.168.100.147")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("104. Cladding_6")
                lvitem.SubItems.Add("192.168.100.147")
            Else
                lvitem2 = Me.ListView2.Items.Add("104. Cladding_6")
                lvitem2.SubItems.Add("192.168.100.147")
            End If
            geoCam = pingIPcamera("192.168.100.148")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("105. Cladding_7")
                lvitem.SubItems.Add("192.168.100.148")
            Else
                lvitem2 = Me.ListView2.Items.Add("105. Cladding_7")
                lvitem2.SubItems.Add("192.168.100.148")
            End If
            geoCam = pingIPcamera("192.168.100.149")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("106. Cladding_8")
                lvitem.SubItems.Add("192.168.100.149")
            Else
                lvitem2 = Me.ListView2.Items.Add("106. Cladding_8")
                lvitem2.SubItems.Add("192.168.100.149")
            End If
            geoCam = pingIPcamera("192.168.100.150")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("107. Cladding_9")
                lvitem.SubItems.Add("192.168.100.150")
            Else
                lvitem2 = Me.ListView2.Items.Add("107. Cladding_9")
                lvitem2.SubItems.Add("192.168.100.150")
            End If
            geoCam = pingIPcamera("192.168.100.151")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("108. Cladding_10")
                lvitem.SubItems.Add("192.168.100.151")
            Else
                lvitem2 = Me.ListView2.Items.Add("108. Cladding_10")
                lvitem2.SubItems.Add("192.168.100.151")
            End If
            geoCam = pingIPcamera("192.168.100.152")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("109. Cladding_11")
                lvitem.SubItems.Add("192.168.100.152")
            Else
                lvitem2 = Me.ListView2.Items.Add("109. Cladding_11")
                lvitem2.SubItems.Add("192.168.100.152")
            End If
            geoCam = pingIPcamera("192.168.100.153")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("110. Cladding_12")
                lvitem.SubItems.Add("192.168.100.153")
            Else
                lvitem2 = Me.ListView2.Items.Add("110. Cladding_12")
                lvitem2.SubItems.Add("192.168.100.153")
            End If
            geoCam = pingIPcamera("192.168.100.154")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("111. Cladding_13")
                lvitem.SubItems.Add("192.168.100.154")
            Else
                lvitem2 = Me.ListView2.Items.Add("111. Cladding_13")
                lvitem2.SubItems.Add("192.168.100.154")
            End If
            geoCam = pingIPcamera("192.168.100.155")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("112. Cladding_14")
                lvitem.SubItems.Add("192.168.100.155")
            Else
                lvitem2 = Me.ListView2.Items.Add("112. Cladding_14")
                lvitem2.SubItems.Add("192.168.100.155")
            End If
            geoCam = pingIPcamera("192.168.100.156")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("113. Diesel_cam_1")
                lvitem.SubItems.Add("192.168.100.156")
            Else
                lvitem2 = Me.ListView2.Items.Add("113. Diesel_cam_1")
                lvitem2.SubItems.Add("192.168.100.156")
            End If
            geoCam = pingIPcamera("192.168.100.157")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("113. Diesel_cam_2")
                lvitem.SubItems.Add("192.168.100.157")
            Else
                lvitem2 = Me.ListView2.Items.Add("113. Diesel_cam_2")
                lvitem2.SubItems.Add("192.168.100.157")
            End If
            geoCam = pingIPcamera("192.168.100.158")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("115. Diesel_cam_3")
                lvitem.SubItems.Add("192.168.100.158")
            Else
                lvitem2 = Me.ListView2.Items.Add("115. Diesel_cam_3")
                lvitem2.SubItems.Add("192.168.100.158")
            End If
            geoCam = pingIPcamera("192.168.100.159")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("116. Diesel_cam_4")
                lvitem.SubItems.Add("192.168.100.159")
            Else
                lvitem2 = Me.ListView2.Items.Add("116. Diesel_cam_4")
                lvitem2.SubItems.Add("192.168.100.159")
            End If
            geoCam = pingIPcamera("192.168.100.144")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("117. Time keeper")
                lvitem.SubItems.Add("192.168.100.144")
            Else
                lvitem2 = Me.ListView2.Items.Add("117. Time keeper")
                lvitem2.SubItems.Add("192.168.100.144")
            End If
            geoCam = pingIPcamera("192.168.100.86")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("118. Readymix")
                lvitem.SubItems.Add("192.168.100.86")
            Else
                lvitem2 = Me.ListView2.Items.Add("118. Readymix")
                lvitem2.SubItems.Add("192.168.100.86")
            End If
            geoCam = pingIPcamera("192.168.100.161")
            If geoCam = True Then
                lvitem = Me.ListView1.Items.Add("119. Restaurant Inside")
                lvitem.SubItems.Add("192.168.100.161")
            Else
                lvitem2 = Me.ListView2.Items.Add("119. Restaurant Inside")
                lvitem2.SubItems.Add("192.168.100.161")
            End If
            intCount += 1
            StatusText = intCount & "  Times"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        lblWorking.Text = ListView1.Items.Count
        lblNotworking.Text = ListView2.Items.Count
        sslStatus.Text = "Done"
    End Sub
    'Sensor devices coding
    Private Sub btnClkSen_Click(sender As Object, e As EventArgs) Handles btnClkSen.Click
        Try
            'Ping Sensor From lblSen 1 to 34
            intCount += 1
            StatusText = intCount & "  Times"
            Dim gateCam As String
            gateCam = pingIPcamera("192.168.101.1")
            If gateCam = True Then
                lblSen1.Text = "1. Masa Room 1"
                lblSen1.ForeColor = Color.White
                picSen1.Image = My.Resources.motion_sensor_green
            Else
                lblSen1.Text = "1. Masa Room 1"
                lblSen1.ForeColor = Color.FromArgb(245, 54, 54)
                picSen1.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.2")
            If gateCam = True Then
                lblSen2.Text = "2. Masa Room 2"
                lblSen2.ForeColor = Color.White
                picSen2.Image = My.Resources.motion_sensor_green
            Else
                lblSen2.Text = "2. Masa Room 2"
                lblSen2.ForeColor = Color.FromArgb(245, 54, 54)
                picSen2.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.3")
            If gateCam = True Then
                lblSen3.Text = "3. Masa Room 3"
                lblSen3.ForeColor = Color.White
                picSen3.Image = My.Resources.motion_sensor_green
            Else
                lblSen3.Text = "3. Masa Room 3"
                lblSen3.ForeColor = Color.FromArgb(245, 54, 54)
                picSen3.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.4")
            If gateCam = True Then
                lblSen4.Text = "4. Masa Room 4"
                lblSen4.ForeColor = Color.White
                picSen4.Image = My.Resources.motion_sensor_green
            Else
                lblSen4.Text = "4. Masa Room 4"
                lblSen4.ForeColor = Color.FromArgb(245, 54, 54)
                picSen4.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.5")
            If gateCam = True Then
                lblSen5.Text = "5. Masa Room 5"
                lblSen5.ForeColor = Color.White
                picSen5.Image = My.Resources.motion_sensor_green
            Else
                lblSen5.Text = "5. Masa Room 5"
                lblSen5.ForeColor = Color.FromArgb(245, 54, 54)
                picSen5.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.6")
            If gateCam = True Then
                lblSen6.Text = "6. Masa Room 6"
                lblSen6.ForeColor = Color.White
                picSen6.Image = My.Resources.motion_sensor_green
            Else
                lblSen6.Text = "6. Masa Room 6"
                lblSen6.ForeColor = Color.FromArgb(245, 54, 54)
                picSen6.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.7")
            If gateCam = True Then
                lblSen7.Text = "7. Masa Room 7"
                lblSen7.ForeColor = Color.White
                picSen7.Image = My.Resources.motion_sensor_green
            Else
                lblSen7.Text = "7. Masa Room 7"
                lblSen7.ForeColor = Color.FromArgb(245, 54, 54)
                picSen7.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.8")
            If gateCam = True Then
                lblSen8.Text = "8. Masa Room 8"
                lblSen8.ForeColor = Color.White
                picSen8.Image = My.Resources.motion_sensor_green
            Else
                lblSen8.Text = "8. Masa Room 8"
                lblSen8.ForeColor = Color.FromArgb(245, 54, 54)
                picSen8.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.9")
            If gateCam = True Then
                lblSen9.Text = "9. Masa Room 9"
                lblSen9.ForeColor = Color.White
                picSen9.Image = My.Resources.motion_sensor_green
            Else
                lblSen9.Text = "9. Masa Room 9"
                lblSen9.ForeColor = Color.FromArgb(245, 54, 54)
                picSen9.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.10")
            If gateCam = True Then
                lblSen10.Text = "10. Server Room"
                lblSen10.ForeColor = Color.White
                picSen10.Image = My.Resources.motion_sensor_green
            Else
                lblSen10.Text = "10. Server Room"
                lblSen10.ForeColor = Color.FromArgb(245, 54, 54)
                picSen10.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.13")
            If gateCam = True Then
                lblSen11.Text = "11. IBF HENKE 1"
                lblSen11.ForeColor = Color.White
                picSen11.Image = My.Resources.motion_sensor_green
            Else
                lblSen11.Text = "11. IBF HENKE 1"
                lblSen11.ForeColor = Color.FromArgb(245, 54, 54)
                picSen11.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.14")
            If gateCam = True Then
                lblSen12.Text = "12. IBF HENKE 2"
                lblSen12.ForeColor = Color.White
                picSen12.Image = My.Resources.motion_sensor_green
            Else
                lblSen12.Text = "12. IBF HENKE 2"
                lblSen12.ForeColor = Color.FromArgb(245, 54, 54)
                picSen12.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.15")
            If gateCam = True Then
                lblSen13.Text = "13. IBF HENKE 3"
                lblSen13.ForeColor = Color.White
                picSen13.Image = My.Resources.motion_sensor_green
            Else
                lblSen13.Text = "13. IBF HENKE 3"
                lblSen13.ForeColor = Color.FromArgb(245, 54, 54)
                picSen13.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.16")
            If gateCam = True Then
                lblSen14.Text = "14. IBF HENKE 4"
                lblSen14.ForeColor = Color.White
                picSen14.Image = My.Resources.motion_sensor_green
            Else
                lblSen14.Text = "14. IBF HENKE 4"
                lblSen14.ForeColor = Color.FromArgb(245, 54, 54)
                picSen14.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.17")
            If gateCam = True Then
                lblSen15.Text = "15. IBF HENKE 5"
                lblSen15.ForeColor = Color.White
                picSen15.Image = My.Resources.motion_sensor_green
            Else
                lblSen15.Text = "15. IBF HENKE 5"
                lblSen15.ForeColor = Color.FromArgb(245, 54, 54)
                picSen15.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.18")
            If gateCam = True Then
                lblSen16.Text = "16. IBF HENKE 6"
                lblSen16.ForeColor = Color.White
                picSen16.Image = My.Resources.motion_sensor_green
            Else
                lblSen16.Text = "16. IBF HENKE 6"
                lblSen16.ForeColor = Color.FromArgb(245, 54, 54)
                picSen16.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.19")
            If gateCam = True Then
                lblSen17.Text = "17. IBF HENKE 7"
                lblSen17.ForeColor = Color.White
                picSen17.Image = My.Resources.motion_sensor_green
            Else
                lblSen17.Text = "17. IBF HENKE 7"
                lblSen17.ForeColor = Color.FromArgb(245, 54, 54)
                picSen17.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.20")
            If gateCam = True Then
                lblSen18.Text = "18. IBF HENKE 8"
                lblSen18.ForeColor = Color.White
                picSen18.Image = My.Resources.motion_sensor_green
            Else
                lblSen18.Text = "18. IBF HENKE 8"
                lblSen18.ForeColor = Color.FromArgb(245, 54, 54)
                picSen18.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.21")
            If gateCam = True Then
                lblSen19.Text = "19. IBF HENKE 9"
                lblSen19.ForeColor = Color.White
                picSen19.Image = My.Resources.motion_sensor_green
            Else
                lblSen19.Text = "19. IBF HENKE 9"
                lblSen19.ForeColor = Color.FromArgb(245, 54, 54)
                picSen19.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.22")
            If gateCam = True Then
                lblSen20.Text = "20. IBF HENKE 10"
                lblSen20.ForeColor = Color.White
                picSen20.Image = My.Resources.motion_sensor_green
            Else
                lblSen20.Text = "20. IBF HENKE 10"
                lblSen20.ForeColor = Color.FromArgb(245, 54, 54)
                picSen20.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.23")
            If gateCam = True Then
                lblSen21.Text = "21. IBF HENKE 11"
                lblSen21.ForeColor = Color.White
                picSen21.Image = My.Resources.motion_sensor_green
            Else
                lblSen21.Text = "21. IBF HENKE 11"
                lblSen21.ForeColor = Color.FromArgb(245, 54, 54)
                picSen21.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.24")
            If gateCam = True Then
                lblSen22.Text = "22. IBF HENKE 12"
                lblSen22.ForeColor = Color.White
                picSen22.Image = My.Resources.motion_sensor_green
            Else
                lblSen22.Text = "22. IBF HENKE 12"
                lblSen22.ForeColor = Color.FromArgb(245, 54, 54)
                picSen22.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.25")
            If gateCam = True Then
                lblSen23.Text = "23. CPF Room 1 - Sec 1"
                lblSen23.ForeColor = Color.White
                picSen23.Image = My.Resources.motion_sensor_green
            Else
                lblSen23.Text = "23. CPF Room 1 - Sec 1"
                lblSen23.ForeColor = Color.FromArgb(245, 54, 54)
                picSen23.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.26")
            If gateCam = True Then
                lblSen24.Text = "24. CPF Room 1 Sec 2"
                lblSen24.ForeColor = Color.White
                picSen24.Image = My.Resources.motion_sensor_green
            Else
                lblSen24.Text = "24. CPF Room 1 Sec 2"
                lblSen24.ForeColor = Color.FromArgb(245, 54, 54)
                picSen24.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.27")
            If gateCam = True Then
                lblSen25.Text = "25. CPF Room 1 Sec 3"
                lblSen25.ForeColor = Color.White
                picSen25.Image = My.Resources.motion_sensor_green
            Else
                lblSen25.Text = "25. CPF Room 1 Sec 3"
                lblSen25.ForeColor = Color.FromArgb(245, 54, 54)
                picSen25.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.28")
            If gateCam = True Then
                lblSen26.Text = "26. CPF Room 2 Sec 1"
                lblSen26.ForeColor = Color.White
                picSen26.Image = My.Resources.motion_sensor_green
            Else
                lblSen26.Text = "26. CPF Room 2 Sec 1"
                lblSen26.ForeColor = Color.FromArgb(245, 54, 54)
                picSen26.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.29")
            If gateCam = True Then
                lblSen27.Text = "27. CPF Room 2 Sec 2"
                lblSen27.ForeColor = Color.White
                picSen27.Image = My.Resources.motion_sensor_green
            Else
                lblSen27.Text = "27. CPF Room 2 Sec 2"
                lblSen27.ForeColor = Color.FromArgb(245, 54, 54)
                picSen27.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.30")
            If gateCam = True Then
                lblSen28.Text = "28. CPF Room2 Sec3"
                lblSen28.ForeColor = Color.White
                picSen28.Image = My.Resources.motion_sensor_green
            Else
                lblSen28.Text = "28. CPF Room2 Sec3"
                lblSen28.ForeColor = Color.FromArgb(245, 54, 54)
                picSen28.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.31")
            If gateCam = True Then
                lblSen29.Text = "29. CPF Room 3 Sec 1"
                lblSen29.ForeColor = Color.White
                picSen29.Image = My.Resources.motion_sensor_green
            Else
                lblSen29.Text = "29. CPF Room 3 Sec 1"
                lblSen29.ForeColor = Color.FromArgb(245, 54, 54)
                picSen29.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.32")
            If gateCam = True Then
                lblSen30.Text = "30. CPF Room 4 Sec 2"
                lblSen30.ForeColor = Color.White
                picSen30.Image = My.Resources.motion_sensor_green
            Else
                lblSen30.Text = "30. CPF Room 4 Sec 2"
                lblSen30.ForeColor = Color.FromArgb(245, 54, 54)
                picSen30.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.33")
            If gateCam = True Then
                lblSen31.Text = "31. CPF Room 3 Sec 3"
                lblSen31.ForeColor = Color.White
                picSen31.Image = My.Resources.motion_sensor_green
            Else
                lblSen31.Text = "31. CPF Room 3 Sec 3"
                lblSen31.ForeColor = Color.FromArgb(245, 54, 54)
                picSen31.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.34")
            If gateCam = True Then
                lblSen32.Text = "32. CPF Room 4 Sec 1"
                lblSen32.ForeColor = Color.White
                picSen32.Image = My.Resources.motion_sensor_green
            Else
                lblSen32.Text = "32. CPF Room 4 Sec 1"
                lblSen32.ForeColor = Color.FromArgb(245, 54, 54)
                picSen32.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.35")
            If gateCam = True Then
                lblSen33.Text = "33. CPF Room 4 Sec 2"
                lblSen33.ForeColor = Color.White
                picSen33.Image = My.Resources.motion_sensor_green
            Else
                lblSen33.Text = "33. CPF Room 4 Sec 2"
                lblSen33.ForeColor = Color.FromArgb(245, 54, 54)
                picSen33.Image = My.Resources.motion_sensor_red
            End If
            gateCam = pingIPcamera("192.168.101.36")
            If gateCam = True Then
                lblSen34.Text = "34. CPF Room 4 Sec 2"
                lblSen34.ForeColor = Color.White
                picSen34.Image = My.Resources.motion_sensor_green
            Else
                lblSen34.Text = "34. CPF Room 4 Sec 2"
                lblSen34.ForeColor = Color.FromArgb(245, 54, 54)
                picSen34.Image = My.Resources.motion_sensor_red
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'This code is for check running status in CMD seperate window (Hik-vision)
    Private Sub picSen1_DoubleClick(sender As Object, e As EventArgs) Handles picSen1.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.1")
    End Sub

    Private Sub picSen2_DoubleClick(sender As Object, e As EventArgs) Handles picSen2.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.2")
    End Sub

    Private Sub picSen3_DoubleClick(sender As Object, e As EventArgs) Handles picSen3.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.3")
    End Sub

    Private Sub picSen4_DoubleClick(sender As Object, e As EventArgs) Handles picSen4.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.4")
    End Sub

    Private Sub picSen5_DoubleClick(sender As Object, e As EventArgs) Handles picSen5.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.5")
    End Sub

    Private Sub picSen6_DoubleClick(sender As Object, e As EventArgs) Handles picSen6.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.6")
    End Sub

    Private Sub picSen7_DoubleClick(sender As Object, e As EventArgs) Handles picSen7.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.7")
    End Sub

    Private Sub picSen8_DoubleClick(sender As Object, e As EventArgs) Handles picSen8.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.8")
    End Sub

    Private Sub picSen9_DoubleClick(sender As Object, e As EventArgs) Handles picSen9.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.9")
    End Sub

    Private Sub picSen10_DoubleClick(sender As Object, e As EventArgs) Handles picSen10.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.10")
    End Sub

    Private Sub picSen11_DoubleClick(sender As Object, e As EventArgs) Handles picSen11.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.13")
    End Sub

    Private Sub picSen12_DoubleClick(sender As Object, e As EventArgs) Handles picSen12.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.14")
    End Sub

    Private Sub picSen13_DoubleClick(sender As Object, e As EventArgs) Handles picSen13.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.15")
    End Sub

    Private Sub picSen14_DoubleClick(sender As Object, e As EventArgs) Handles picSen14.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.16")
    End Sub

    Private Sub picSen15_DoubleClick(sender As Object, e As EventArgs) Handles picSen15.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.17")
    End Sub

    Private Sub picSen16_DoubleClick(sender As Object, e As EventArgs) Handles picSen16.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.18")
    End Sub

    Private Sub picSen17_DoubleClick(sender As Object, e As EventArgs) Handles picSen17.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.19")
    End Sub

    Private Sub picSen18_DoubleClick(sender As Object, e As EventArgs) Handles picSen18.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.20")
    End Sub

    Private Sub picSen19_DoubleClick(sender As Object, e As EventArgs) Handles picSen19.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.21")
    End Sub

    Private Sub picSen20_DoubleClick(sender As Object, e As EventArgs) Handles picSen20.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.22")
    End Sub

    Private Sub picSen21_DoubleClick(sender As Object, e As EventArgs) Handles picSen21.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.23")
    End Sub

    Private Sub picSen22_DoubleClick(sender As Object, e As EventArgs) Handles picSen22.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.24")
    End Sub

    Private Sub picSen23_DoubleClick(sender As Object, e As EventArgs) Handles picSen23.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.25")
    End Sub

    Private Sub picSen24_DoubleClick(sender As Object, e As EventArgs) Handles picSen24.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.26")
    End Sub

    Private Sub picSen25_DoubleClick(sender As Object, e As EventArgs) Handles picSen25.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.27")
    End Sub

    Private Sub picSen26_DoubleClick(sender As Object, e As EventArgs) Handles picSen26.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.28")
    End Sub

    Private Sub picSen27_DoubleClick(sender As Object, e As EventArgs) Handles picSen27.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.29")
    End Sub

    Private Sub picSen28_DoubleClick(sender As Object, e As EventArgs) Handles picSen28.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.30")
    End Sub

    Private Sub picSen29_DoubleClick(sender As Object, e As EventArgs) Handles picSen29.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.31")
    End Sub

    Private Sub picSen30_DoubleClick(sender As Object, e As EventArgs) Handles picSen30.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.32")
    End Sub

    Private Sub picSen31_DoubleClick(sender As Object, e As EventArgs) Handles picSen31.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.33")
    End Sub

    Private Sub picSen32_DoubleClick(sender As Object, e As EventArgs) Handles picSen32.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.34")
    End Sub

    Private Sub picSen33_DoubleClick(sender As Object, e As EventArgs) Handles picSen33.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.35")
    End Sub

    Private Sub picSen34_DoubleClick(sender As Object, e As EventArgs) Handles picSen34.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.101.36")
    End Sub
    'Sensor Status Code
    Private Sub lblSen1_MouseHover(sender As Object, e As EventArgs) Handles lblSen1.MouseHover
        StatusText = "Sensor IP : 192.168.101.1"
        txtIp.Text = "192.168.101.1"
    End Sub


    Private Sub pnlSen_MouseEnter(sender As Object, e As EventArgs) Handles pnlSen.MouseEnter
        StatusText = " "
        txtIp.Text = " "
    End Sub

    Private Sub lblSen2_MouseHover(sender As Object, e As EventArgs) Handles lblSen2.MouseHover
        StatusText = "Sensor IP : 192.168.101.2"
        txtIp.Text = "192.168.101.2"
    End Sub

    Private Sub lblSen3_MouseHover(sender As Object, e As EventArgs) Handles lblSen3.MouseHover
        StatusText = "Sensor IP : 192.168.101.3"
        txtIp.Text = "192.168.101.3"
    End Sub

    Private Sub lblSen4_MouseHover(sender As Object, e As EventArgs) Handles lblSen4.MouseHover
        StatusText = "Sensor IP : 192.168.101.4"
        txtIp.Text = "192.168.101.4"
    End Sub

    Private Sub lblSen5_MouseHover(sender As Object, e As EventArgs) Handles lblSen5.MouseHover
        StatusText = "Sensor IP : 192.168.101.5"
        txtIp.Text = "192.168.101.5"
    End Sub

    Private Sub lblSen6_MouseHover(sender As Object, e As EventArgs) Handles lblSen6.MouseHover
        StatusText = "Sensor IP : 192.168.101.6"
        txtIp.Text = "192.168.101.6"
    End Sub

    Private Sub lblSen7_MouseHover(sender As Object, e As EventArgs) Handles lblSen7.MouseHover
        StatusText = "Sensor IP : 192.168.101.7"
        txtIp.Text = "192.168.101.7"
    End Sub

    Private Sub lblSen8_MouseHover(sender As Object, e As EventArgs) Handles lblSen8.MouseHover
        StatusText = "Sensor IP : 192.168.101.8"
        txtIp.Text = "192.168.101.8"
    End Sub

    Private Sub lblSen9_MouseHover(sender As Object, e As EventArgs) Handles lblSen9.MouseHover
        StatusText = "Sensor IP : 192.168.101.9"
        txtIp.Text = "192.168.101.9"
    End Sub

    Private Sub lblSen10_MouseHover(sender As Object, e As EventArgs) Handles lblSen10.MouseHover
        StatusText = "Sensor IP : 192.168.101.10"
        txtIp.Text = "192.168.101.10"
    End Sub

    Private Sub lblSen11_MouseHover(sender As Object, e As EventArgs) Handles lblSen11.MouseHover
        StatusText = "Sensor IP : 192.168.101.13"
        txtIp.Text = "192.168.101.13"
    End Sub

    Private Sub lblSen12_MouseHover(sender As Object, e As EventArgs) Handles lblSen12.MouseHover
        StatusText = "Sensor IP : 192.168.101.14"
        txtIp.Text = "192.168.101.14"
    End Sub

    Private Sub lblSen13_MouseHover(sender As Object, e As EventArgs) Handles lblSen13.MouseHover
        StatusText = "Sensor IP : 192.168.101.15"
        txtIp.Text = "192.168.101.15"
    End Sub

    Private Sub lblSen14_MouseHover(sender As Object, e As EventArgs) Handles lblSen14.MouseHover
        StatusText = "Sensor IP : 192.168.101.16"
        txtIp.Text = "192.168.101.16"
    End Sub

    Private Sub lblSen15_MouseHover(sender As Object, e As EventArgs) Handles lblSen15.MouseHover
        StatusText = "Sensor IP : 192.168.101.17"
        txtIp.Text = "192.168.101.17"
    End Sub

    Private Sub lblSen16_MouseHover(sender As Object, e As EventArgs) Handles lblSen16.MouseHover
        StatusText = "Sensor IP : 192.168.101.18"
        txtIp.Text = "192.168.101.18"
    End Sub

    Private Sub lblSen17_MouseHover(sender As Object, e As EventArgs) Handles lblSen17.MouseHover
        StatusText = "Sensor IP : 192.168.101.19"
        txtIp.Text = "192.168.101.19"
    End Sub

    Private Sub lblSen18_MouseHover(sender As Object, e As EventArgs) Handles lblSen18.MouseHover
        StatusText = "Sensor IP : 192.168.101.20"
        txtIp.Text = "192.168.101.20"
    End Sub

    Private Sub lblSen19_MouseHover(sender As Object, e As EventArgs) Handles lblSen19.MouseHover
        StatusText = "Sensor IP : 192.168.101.21"
        txtIp.Text = "192.168.101.21"
    End Sub

    Private Sub lblSen20_MouseHover(sender As Object, e As EventArgs) Handles lblSen20.MouseHover
        StatusText = "Sensor IP : 192.168.101.22"
        txtIp.Text = "192.168.101.22"
    End Sub

    Private Sub lblSen21_MouseHover(sender As Object, e As EventArgs) Handles lblSen21.MouseHover
        StatusText = "Sensor IP : 192.168.101.23"
        txtIp.Text = "192.168.101.23"
    End Sub

    Private Sub lblSen22_MouseHover(sender As Object, e As EventArgs) Handles lblSen22.MouseHover
        StatusText = "Sensor IP : 192.168.101.24"
        txtIp.Text = "192.168.101.24"
    End Sub

    Private Sub lblSen23_MouseHover(sender As Object, e As EventArgs) Handles lblSen23.MouseHover
        StatusText = "Sensor IP : 192.168.101.25"
        txtIp.Text = "192.168.101.25"
    End Sub

    Private Sub lblSen24_MouseHover(sender As Object, e As EventArgs) Handles lblSen24.MouseHover
        StatusText = "Sensor IP : 192.168.101.26"
        txtIp.Text = "192.168.101.26"
    End Sub

    Private Sub lblSen25_MouseHover(sender As Object, e As EventArgs) Handles lblSen25.MouseHover
        StatusText = "Sensor IP : 192.168.101.27"
        txtIp.Text = "192.168.101.27"
    End Sub

    Private Sub lblSen26_MouseHover(sender As Object, e As EventArgs) Handles lblSen26.MouseHover
        StatusText = "Sensor IP : 192.168.101.28"
        txtIp.Text = "192.168.101.28"
    End Sub

    Private Sub lblSen27_MouseHover(sender As Object, e As EventArgs) Handles lblSen27.MouseHover
        StatusText = "Sensor IP : 192.168.101.29"
        txtIp.Text = "192.168.101.29"
    End Sub

    Private Sub lblSen28_MouseHover(sender As Object, e As EventArgs) Handles lblSen28.MouseHover
        StatusText = "Sensor IP : 192.168.101.30"
        txtIp.Text = "192.168.101.30"
    End Sub

    Private Sub lblSen29_MouseHover(sender As Object, e As EventArgs) Handles lblSen29.MouseHover
        StatusText = "Sensor IP : 192.168.101.31"
        txtIp.Text = "192.168.101.31"
    End Sub

    Private Sub lblSen30_MouseHover(sender As Object, e As EventArgs) Handles lblSen30.MouseHover
        StatusText = "Sensor IP : 192.168.101.32"
        txtIp.Text = "192.168.101.32"
    End Sub

    Private Sub lblSen31_MouseHover(sender As Object, e As EventArgs) Handles lblSen31.MouseHover
        StatusText = "Sensor IP : 192.168.101.33"
        txtIp.Text = "192.168.101.33"
    End Sub
    Private Sub lblSen32_MouseHover(sender As Object, e As EventArgs) Handles lblSen32.MouseHover
        StatusText = "Sensor IP : 192.168.101.34"
        txtIp.Text = "192.168.101.34"
    End Sub
    Private Sub lblSen33_MouseHover(sender As Object, e As EventArgs) Handles lblSen33.MouseHover
        StatusText = "Sensor IP : 192.168.101.35"
        txtIp.Text = "192.168.101.35"
    End Sub
    Private Sub lblSen34_MouseHover(sender As Object, e As EventArgs) Handles lblSen34.MouseHover
        StatusText = "Sensor IP : 192.168.101.36"
        txtIp.Text = "192.168.101.36"
    End Sub
    'wireless device coding
    Private Sub btnWireless_Click(sender As Object, e As EventArgs) Handles btnWireless.Click
        Try
            Dim gateCam As String
            gateCam = pingIPcamera("192.168.150.1")
            If gateCam = True Then
                lblWl1.Text = "1. IBF UP MASJID"
                lblWl1.ForeColor = Color.White
                picWire1.Image = My.Resources.wifi2
            Else
                lblWl1.Text = "1. IBF UP MASJID"
                lblWl1.ForeColor = Color.FromArgb(245, 54, 54)
                picWire1.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.2")
            If gateCam = True Then
                lblWl2.Text = "2. PIPE SCRAP 1 TO IBF"
                lblWl2.ForeColor = Color.White
                picWire2.Image = My.Resources.wifi2
            Else
                lblWl2.Text = "2. PIPE SCRAP 1 TO IBF"
                lblWl2.ForeColor = Color.FromArgb(245, 54, 54)
                picWire2.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.3")
            If gateCam = True Then
                lblWl3.Text = "3. PIPE SCRAP 2 TO IBF"
                lblWl3.ForeColor = Color.White
                picWire3.Image = My.Resources.wifi2
            Else
                lblWl3.Text = "3. PIPE SCRAP 2 TO IBF"
                lblWl3.ForeColor = Color.FromArgb(245, 54, 54)
                picWire3.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.4")
            If gateCam = True Then
                lblWl4.Text = "4. QA-QC DEPARTMENT"
                lblWl4.ForeColor = Color.White
                picWire4.Image = My.Resources.wifi2
            Else
                lblWl4.Text = "4. QA-QC DEPARTMENT"
                lblWl4.ForeColor = Color.FromArgb(245, 54, 54)
                picWire4.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.5")
            If gateCam = True Then
                lblWl5.Text = "5. QA-QC DEPT. TO AIR STATION "
                lblWl5.ForeColor = Color.White
                picWire5.Image = My.Resources.wifi2
            Else
                lblWl5.Text = "5. QA-QC DEPT. TO AIR STATION "
                lblWl5.ForeColor = Color.FromArgb(245, 54, 54)
                picWire5.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.7")
            If gateCam = True Then
                lblWl6.Text = "6. PIPE FACTORY CPF "
                lblWl6.ForeColor = Color.White
                picWire6.Image = My.Resources.wifi2
            Else
                lblWl6.Text = "6. PIPE FACTORY CPF "
                lblWl6.ForeColor = Color.FromArgb(245, 54, 54)
                picWire6.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.8")
            If gateCam = True Then
                lblWl7.Text = "7. JUBLIN TO CPF"
                lblWl7.ForeColor = Color.White
                picWire7.Image = My.Resources.wifi2
            Else
                lblWl7.Text = "7. JUBLIN TO CPF"
                lblWl7.ForeColor = Color.FromArgb(245, 54, 54)
                picWire7.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.13")
            If gateCam = True Then
                lblWl8.Text = "8. READY MIX SILO MEKA 1"
                lblWl8.ForeColor = Color.White
                picWire8.Image = My.Resources.wifi2
            Else
                lblWl8.Text = "8. READY MIX SILO MEKA 1"
                lblWl8.ForeColor = Color.FromArgb(245, 54, 54)
                picWire8.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.15")
            If gateCam = True Then
                lblWl9.Text = "9. GATE-3"
                lblWl9.ForeColor = Color.White
                picWire9.Image = My.Resources.wifi2
            Else
                lblWl9.Text = "9. GATE-3"
                lblWl9.ForeColor = Color.FromArgb(245, 54, 54)
                picWire9.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.16")
            If gateCam = True Then
                lblWl10.Text = "10. READY MIX"
                lblWl10.ForeColor = Color.White
                picWire10.Image = My.Resources.wifi2
            Else
                lblWl10.Text = "10. READY MIX"
                lblWl10.ForeColor = Color.FromArgb(245, 54, 54)
                picWire10.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.17")
            If gateCam = True Then
                lblWl11.Text = "11. TRANSPORT DEPARTMENT"
                lblWl11.ForeColor = Color.White
                picWire11.Image = My.Resources.wifi2
            Else
                lblWl11.Text = "11. TRANSPORT DEPARTMENT"
                lblWl11.ForeColor = Color.FromArgb(245, 54, 54)
                picWire11.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.19")
            If gateCam = True Then
                lblWl13.Text = "12. TILES & KERBSTONE"
                lblWl13.ForeColor = Color.White
                picWire12.Image = My.Resources.wifi2
            Else
                lblWl13.Text = "12. TILES & KERBSTONE"
                lblWl13.ForeColor = Color.FromArgb(245, 54, 54)
                picWire12.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.20")
            If gateCam = True Then
                lblWl14.Text = "13. STORE (FLEET)"
                lblWl14.ForeColor = Color.White
                picWire13.Image = My.Resources.wifi2
            Else
                lblWl14.Text = "13. STORE (FLEET)"
                lblWl14.ForeColor = Color.FromArgb(245, 54, 54)
                picWire13.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.21")
            If gateCam = True Then
                lblWl15.Text = "14. IBF OUTSIDE MASA"
                lblWl15.ForeColor = Color.White
                picWire14.Image = My.Resources.wifi2
            Else
                lblWl15.Text = "14. IBF OUTSIDE MASA"
                lblWl15.ForeColor = Color.FromArgb(245, 54, 54)
                picWire14.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.22")
            If gateCam = True Then
                lblWl16.Text = "15. IBF OUTSIDE"
                lblWl16.ForeColor = Color.White
                picWire15.Image = My.Resources.wifi2
            Else
                lblWl16.Text = "15. IBF OUTSIDE"
                lblWl16.ForeColor = Color.FromArgb(245, 54, 54)
                picWire15.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.23")
            If gateCam = True Then
                lblWl17.Text = "16. TREATMENT PLANT UP"
                lblWl17.ForeColor = Color.White
                picWire16.Image = My.Resources.wifi2
            Else
                lblWl17.Text = "16. TREATMENT PLANT UP"
                lblWl17.ForeColor = Color.FromArgb(245, 54, 54)
                picWire16.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.25")
            If gateCam = True Then
                lblWl18.Text = "17. TREATMENT PLANT LAST BOUNDARY"
                lblWl18.ForeColor = Color.White
                picWire17.Image = My.Resources.wifi2
            Else
                lblWl18.Text = "17. TREATMENT PLANT LAST BOUNDARY"
                lblWl18.ForeColor = Color.FromArgb(245, 54, 54)
                picWire17.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.26")
            If gateCam = True Then
                lblWl19.Text = "18. READY MIX STORE"
                lblWl19.ForeColor = Color.White
                picWire18.Image = My.Resources.wifi2
            Else
                lblWl19.Text = "18. READY MIX STORE"
                lblWl19.ForeColor = Color.FromArgb(245, 54, 54)
                picWire18.Image = My.Resources.wifi_red
            End If
            gateCam = pingIPcamera("192.168.150.27")
            If gateCam = True Then
                lblWl20.Text = "19. READY MIX DISTRIBUTION ROOM"
                lblWl20.ForeColor = Color.White
                picWire19.Image = My.Resources.wifi2
            Else
                lblWl20.Text = "19. READY MIX DISTRIBUTION ROOM"
                lblWl20.ForeColor = Color.FromArgb(245, 54, 54)
                picWire19.Image = My.Resources.wifi_red

            End If
            gateCam = pingIPcamera("192.168.150.28")
            If gateCam = True Then
                lblWl21.Text = "20. ROADSIDE BIG TOWER"
                lblWl21.ForeColor = Color.White
                picWire20.Image = My.Resources.wifi2
            Else
                lblWl21.Text = "20. ROADSIDE BIG TOWER"
                lblWl21.ForeColor = Color.FromArgb(245, 54, 54)
                picWire20.Image = My.Resources.wifi_red

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'REMOVED DEVICES LIST 
        lblWl12.Text = "1. READYMIX OLD OFFICE (REMOVED)"
        picWireRemove1.Image = My.Resources.wifi_disconnected
        lblRemoved1.Text = "2. COLUMBIA TO IBF (REMOVED)"
        picWireRemove2.Image = My.Resources.wifi_disconnected
        lblRemoved2.Text = "3. ENGINEER EMAD OFFICE (REMOVED)"
        picWireRemove3.Image = My.Resources.wifi_disconnected
        lblRemoved3.Text = "4. QA-QC DEPARTMENT (REMOVED)"
        picWireRemove4.Image = My.Resources.wifi_disconnected
        lblRemoved4.Text = "5. PIPE ROAD SIDE TO QA-QC DEPT (REMOVED)"
        picWireRemove5.Image = My.Resources.wifi_disconnected
        lblRemoved5.Text = "6. PIPE TESTING TO QA-QC (REMOVED)"
        picWireRemove6.Image = My.Resources.wifi_disconnected
        lblRemoved6.Text = "7. QA-QC LABORATORY INSIDE (REMOVED)"
        picWireRemove7.Image = My.Resources.wifi_disconnected
    End Sub
    'This code is for check running status in CMD seperate window (Wireless)
    Private Sub picWire1_DoubleClick(sender As Object, e As EventArgs) Handles picWire1.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.1")
    End Sub

    Private Sub picWire2_DoubleClick(sender As Object, e As EventArgs) Handles picWire2.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.2")
    End Sub

    Private Sub picWire3_DoubleClick(sender As Object, e As EventArgs) Handles picWire3.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.3")
    End Sub

    Private Sub picWire4_DoubleClick(sender As Object, e As EventArgs) Handles picWire4.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.4")
    End Sub

    Private Sub picWire5_DoubleClick(sender As Object, e As EventArgs) Handles picWire5.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.5")
    End Sub

    Private Sub picWire6_DoubleClick(sender As Object, e As EventArgs) Handles picWire6.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.7")
    End Sub

    Private Sub picWire7_DoubleClick(sender As Object, e As EventArgs) Handles picWire7.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.8")
    End Sub

    Private Sub picWire8_DoubleClick(sender As Object, e As EventArgs) Handles picWire8.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.13")
    End Sub

    Private Sub picWire9_DoubleClick(sender As Object, e As EventArgs) Handles picWire9.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.15")
    End Sub

    Private Sub picWire10_DoubleClick(sender As Object, e As EventArgs) Handles picWire10.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.16")
    End Sub

    Private Sub picWire11_DoubleClick(sender As Object, e As EventArgs) Handles picWire11.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.17")
    End Sub

    Private Sub picWire12_DoubleClick(sender As Object, e As EventArgs) Handles picWire12.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.19")
    End Sub

    Private Sub picWire13_DoubleClick(sender As Object, e As EventArgs) Handles picWire13.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.20")
    End Sub

    Private Sub picWire14_DoubleClick(sender As Object, e As EventArgs) Handles picWire14.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.21")
    End Sub

    Private Sub picWire15_DoubleClick(sender As Object, e As EventArgs) Handles picWire15.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.22")
    End Sub

    Private Sub picWire16_DoubleClick(sender As Object, e As EventArgs) Handles picWire16.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.23")
    End Sub

    Private Sub picWire17_DoubleClick(sender As Object, e As EventArgs) Handles picWire17.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.25")
    End Sub

    Private Sub picWire18_DoubleClick(sender As Object, e As EventArgs) Handles picWire18.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.26")
    End Sub

    Private Sub picWire19_DoubleClick(sender As Object, e As EventArgs) Handles picWire19.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.27")
    End Sub

    Private Sub picWire20_DoubleClick(sender As Object, e As EventArgs) Handles picWire20.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.150.28")
    End Sub
    Private Sub btnckeck_MouseHover(sender As Object, e As EventArgs) Handles btnckeck.MouseHover
        sslStatus.Text = "Click to Check Camera Status"
    End Sub

    Private Sub btnckeck_MouseLeave(sender As Object, e As EventArgs) Handles btnckeck.MouseLeave
        sslStatus.Text = "Ready"

    End Sub

    Private Sub lblWl12_MouseHover(sender As Object, e As EventArgs) Handles lblWl12.MouseHover
        sslStatus.Text = "Wireless Device : 192.168.150.18"
        txtIp.Text = "192.168.150.18"
    End Sub

    Private Sub lblRemoved1_MouseHover(sender As Object, e As EventArgs) Handles lblRemoved1.MouseHover
        sslStatus.Text = "Wireless Device : 192.168.150.6"
        txtIp.Text = "192.168.150.6"
    End Sub

    Private Sub lblRemoved2_MouseHover(sender As Object, e As EventArgs) Handles lblRemoved2.MouseHover
        sslStatus.Text = "Wireless Device : 192.168.150.9"
        txtIp.Text = "192.168.150.9"
    End Sub

    Private Sub lblRemoved3_MouseHover(sender As Object, e As EventArgs) Handles lblRemoved3.MouseHover
        sslStatus.Text = "Wireless Device : 192.168.150.10"
        txtIp.Text = "192.168.150.10"
    End Sub

    Private Sub lblRemoved4_MouseHover(sender As Object, e As EventArgs) Handles lblRemoved4.MouseHover
        sslStatus.Text = "Wireless Device : 192.168.150.11"
        txtIp.Text = "192.168.150.11"
    End Sub

    Private Sub lblRemoved5_MouseHover(sender As Object, e As EventArgs) Handles lblRemoved5.MouseHover
        sslStatus.Text = "Wireless Device : 192.168.150.12"
        txtIp.Text = "192.168.150.12"
    End Sub

    Private Sub lblRemoved6_MouseHover(sender As Object, e As EventArgs) Handles lblRemoved6.MouseHover
        sslStatus.Text = "Wireless Device : 192.168.150.14"
        txtIp.Text = "192.168.150.14"
    End Sub

    Private Sub pnlWire_MouseEnter(sender As Object, e As EventArgs) Handles pnlWire.MouseEnter
        sslStatus.Text = "Ready"
        txtIp.Text = " "
    End Sub
    'wireless status code
    Private Sub lblWl1_MouseHover(sender As Object, e As EventArgs) Handles lblWl1.MouseHover
        StatusText = "Wireless Device :: 192.168.150.1"
        txtIp.Text = "192.168.150.1"
    End Sub

    Private Sub lblWl2_MouseHover(sender As Object, e As EventArgs) Handles lblWl2.MouseHover
        StatusText = "Wireless Device : 192.168.150.2"
        txtIp.Text = "192.168.150.2"
    End Sub

    Private Sub lblWl3_MouseHover(sender As Object, e As EventArgs) Handles lblWl3.MouseHover
        StatusText = "Wireless Device : 192.168.150.3"
        txtIp.Text = "192.168.150.3"
    End Sub

    Private Sub lblWl4_MouseHover(sender As Object, e As EventArgs) Handles lblWl4.MouseHover
        StatusText = "Wireless Device : 192.168.150.4"
        txtIp.Text = "192.168.150.4"
    End Sub

    Private Sub lblWl5_MouseHover(sender As Object, e As EventArgs) Handles lblWl5.MouseHover
        StatusText = "Wireless Device : 192.168.150.5"
        txtIp.Text = "192.168.150.5"
    End Sub

    Private Sub lblWl6_MouseHover(sender As Object, e As EventArgs) Handles lblWl6.MouseHover
        StatusText = "Wireless Device : 192.168.150.7"
        txtIp.Text = "192.168.150.7"
    End Sub

    Private Sub lblWl7_MouseHover(sender As Object, e As EventArgs) Handles lblWl7.MouseHover
        StatusText = "Wireless Device : 192.168.150.8"
        txtIp.Text = "192.168.150.8"
    End Sub

    Private Sub lblWl8_MouseHover(sender As Object, e As EventArgs) Handles lblWl8.MouseHover
        StatusText = "Wireless Device : 192.168.150.13"
        txtIp.Text = "192.168.150.13"
    End Sub

    Private Sub lblWl9_MouseHover(sender As Object, e As EventArgs) Handles lblWl9.MouseHover
        StatusText = "Wireless Device : 192.168.150.15"
        txtIp.Text = "192.168.150.15"
    End Sub
    Private Sub lblWl10_MouseHover(sender As Object, e As EventArgs) Handles lblWl10.MouseHover
        StatusText = "Wireless Device : 192.168.150.16"
        txtIp.Text = "192.168.150.16"
    End Sub
    Private Sub lblWl11_MouseHover(sender As Object, e As EventArgs) Handles lblWl11.MouseHover
        StatusText = "Wireless Device : 192.168.150.17"
        txtIp.Text = "192.168.150.17"
    End Sub

    Private Sub lblWl13_MouseHover(sender As Object, e As EventArgs) Handles lblWl13.MouseHover
        StatusText = "Wireless Device : 192.168.150.19"
        txtIp.Text = "192.168.150.19"
    End Sub

    Private Sub lblWl14_MouseHover(sender As Object, e As EventArgs) Handles lblWl14.MouseHover
        StatusText = "Wireless Device : 192.168.150.20"
        txtIp.Text = "192.168.150.20"
    End Sub

    Private Sub lblWl15_MouseHover(sender As Object, e As EventArgs) Handles lblWl15.MouseHover
        StatusText = "Wireless Device : 192.168.150.21"
        txtIp.Text = "192.168.150.21"
    End Sub

    Private Sub lblWl16_MouseHover(sender As Object, e As EventArgs) Handles lblWl16.MouseHover
        StatusText = "Wireless Device : 192.168.150.22"
        txtIp.Text = "192.168.150.22"
    End Sub

    Private Sub lblWl17_MouseHover(sender As Object, e As EventArgs) Handles lblWl17.MouseHover
        StatusText = "Wireless Device : 192.168.150.23"
        txtIp.Text = "192.168.150.23"
    End Sub

    Private Sub lblWl18_MouseHover(sender As Object, e As EventArgs) Handles lblWl18.MouseHover
        StatusText = "Wireless Device : 192.168.150.25"
        txtIp.Text = "192.168.150.25"
    End Sub

    Private Sub lblWl19_MouseHover(sender As Object, e As EventArgs) Handles lblWl19.MouseHover
        StatusText = "Wireless Device : 192.168.150.26"
        txtIp.Text = "192.168.150.26"
    End Sub

    Private Sub lblWl20_MouseHover(sender As Object, e As EventArgs) Handles lblWl20.MouseHover
        StatusText = "Wireless Device : 192.168.150.27"
        txtIp.Text = "192.168.150.27"
    End Sub
    Private Sub lblWl21_MouseHover(sender As Object, e As EventArgs) Handles lblWl21.MouseHover
        StatusText = "Wireless Device : 192.168.150.28"
        txtIp.Text = "192.168.150.28"
    End Sub
    ' Default ip form fade background code
    Private Sub btndefaultip_Click_1(sender As Object, e As EventArgs) Handles btndefaultip.Click
        Dim bc As Color = BackColor
        DefaultIP.ShowDialog()
        BackColor = bc
    End Sub
    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        Dim bc As Color = BackColor
        About.ShowDialog()
        BackColor = bc
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim bc As Color = BackColor
        Information.ShowDialog()
        BackColor = bc
    End Sub
    'PAC panel coding
    Private Sub btnmekaping_Click(sender As Object, e As EventArgs) Handles btnmekaping.Click
        Dim PACmachine As String
        PACmachine = pingIPcamera("192.168.11.21")
        If PACmachine = True Then
            picMeka2.Image = My.Resources.mixer_truck_green
        Else
            picMeka2.Image = My.Resources.mixer_truck_red
        End If
        PACmachine = pingIPcamera("192.168.11.22")
        If PACmachine = True Then
            picMeka4.Image = My.Resources.mixer_truck_green
        Else
            picMeka4.Image = My.Resources.mixer_truck_red
        End If
        PACmachine = pingIPcamera("192.168.11.1")
        If PACmachine = True Then
            txtMeena.Text = "192.168.11.1"
            txtMeena.ForeColor = Color.LawnGreen
            txtMeena.BackColor = Color.Black
        Else
            txtMeena.Text = "192.168.11.1"
            txtMeena.ForeColor = Color.Red
            txtMeena.BackColor = Color.Pink
        End If
        ' PACmachine = pingIPcamera("192.168.12.1")
        'If PACmachine = True Then
        'txtIRMSserver.Text = "192.168.12.1"
        'Else
        'txtIRMSserver.Text = "192.168.12.1"
        'txtIRMSserver.ForeColor = Color.Red
        'txtIRMSserver.BackColor = Color.Pink
        'End If
        PACmachine = pingIPcamera("192.168.12.11")
        If PACmachine = True Then
            picMeka3.Image = My.Resources.mixer_truck_green
        Else
            picMeka3.Image = My.Resources.mixer_truck_red
        End If
        PACmachine = pingIPcamera("192.168.12.12")
        If PACmachine = True Then
            picMeka1.Image = My.Resources.mixer_truck_green
        Else
            picMeka1.Image = My.Resources.mixer_truck_red
        End If
        PACmachine = pingIPcamera("192.168.12.10")
        If PACmachine = True Then
            txtTkf1.Text = "192.168.12.10"
            txtTkf1.ForeColor = Color.LawnGreen
            txtTkf1.BackColor = Color.Black
        Else
            txtTkf1.Text = "192.168.12.10"
            txtTkf1.ForeColor = Color.Red
            txtTkf1.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.12.13")
        If PACmachine = True Then
            txtTkf2.Text = "192.168.12.13"
            txtTkf2.ForeColor = Color.LawnGreen
            txtTkf2.BackColor = Color.Black
        Else
            txtTkf2.Text = "192.168.12.13"
            txtTkf2.ForeColor = Color.Red
            txtTkf2.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.12.14")
        If PACmachine = True Then
            txtTkf3.Text = "192.168.12.14"
            txtTkf3.ForeColor = Color.LawnGreen
            txtTkf3.BackColor = Color.Black
        Else
            txtTkf3.Text = "192.168.12.14"
            txtTkf3.ForeColor = Color.Red
            txtTkf3.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.12.15")
        If PACmachine = True Then
            txtTkf4.Text = "192.168.12.15"
            txtTkf4.ForeColor = Color.LawnGreen
            txtTkf4.BackColor = Color.Black
        Else
            txtTkf4.Text = "192.168.12.15"
            txtTkf4.ForeColor = Color.Red
            txtTkf4.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.12.16")
        If PACmachine = True Then
            txtTkf5.Text = "192.168.12.16"
            txtTkf5.ForeColor = Color.LawnGreen
            txtTkf5.BackColor = Color.Black
        Else
            txtTkf5.Text = "192.168.12.16"
            txtTkf5.ForeColor = Color.Red
            txtTkf5.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.12.17")
        If PACmachine = True Then
            txtTkf6.Text = "192.168.12.17"
            txtTkf6.ForeColor = Color.LawnGreen
            txtTkf6.BackColor = Color.Black
        Else
            txtTkf6.Text = "192.168.12.17"
            txtTkf6.ForeColor = Color.Red
            txtTkf6.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.12.18")
        If PACmachine = True Then
            txtTkf7.Text = "192.168.12.18"
            txtTkf7.ForeColor = Color.LawnGreen
            txtTkf7.BackColor = Color.Black
        Else
            txtTkf7.Text = "192.168.12.18"
            txtTkf7.ForeColor = Color.Red
            txtTkf7.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.12.19")
        If PACmachine = True Then
            txtTkf8.Text = "192.168.12.19"
            txtTkf8.ForeColor = Color.LawnGreen
            txtTkf8.BackColor = Color.Black
        Else
            txtTkf8.Text = "19.168.12.19"
            txtTkf8.ForeColor = Color.Red
            txtTkf8.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.12.20")
        If PACmachine = True Then
            txtTkf9.Text = "192.168.12.20"
            txtTkf9.ForeColor = Color.LawnGreen
            txtTkf9.BackColor = Color.Black
        Else
            txtTkf9.Text = "192.168.12.20"
            txtTkf9.ForeColor = Color.Red
            txtTkf9.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.100.1")
        If PACmachine = True Then
            txtServer.Text = "192.168.100.1"
            txtServer.ForeColor = Color.LawnGreen
            txtServer.BackColor = Color.Black
        Else
            txtServer.Text = "192.168.100.1"
            txtServer.ForeColor = Color.Red
            txtServer.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.100.2")
        If PACmachine = True Then
            txtSynologyRac.Text = "192.168.100.2"
            txtSynologyRac.ForeColor = Color.LawnGreen
            txtSynologyRac.BackColor = Color.Black
        Else
            txtSynologyRac.Text = "192.168.100.2"
            txtSynologyRac.ForeColor = Color.Red
            txtSynologyRac.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.1.2")
        If PACmachine = True Then
            txtNVR1.Text = "192.168.1.2"
            txtNVR1.ForeColor = Color.LawnGreen
            txtNVR1.BackColor = Color.Black
        Else
            txtNVR1.Text = "192.168.1.2"
            txtNVR1.ForeColor = Color.Red
            txtNVR1.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.17.2")
        If PACmachine = True Then
            txtSynologyNAS.Text = "192.168.17.2"
            txtSynologyNAS.ForeColor = Color.LawnGreen
            txtSynologyNAS.BackColor = Color.Black
        Else
            txtSynologyNAS.Text = "192.168.17.2"
            txtSynologyNAS.ForeColor = Color.Red
            txtSynologyNAS.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.1.40")
        If PACmachine = True Then
            txtNVR2.Text = "192.168.1.40"
            txtNVR2.ForeColor = Color.LawnGreen
            txtNVR2.BackColor = Color.Black
        Else
            txtNVR2.Text = "192.168.1.40"
            txtNVR2.ForeColor = Color.Red
            txtNVR2.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.16.1")
        If PACmachine = True Then
            txtDiesel.Text = "192.168.16.1"
            txtDiesel.ForeColor = Color.LawnGreen
            txtDiesel.BackColor = Color.Black
        Else
            txtDiesel.Text = "192.168.16.1"
            txtDiesel.ForeColor = Color.Red
            txtDiesel.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("192.168.15.1")
        If PACmachine = True Then
            txtTransport.Text = "192.168.15.1"
            txtTransport.ForeColor = Color.LawnGreen
            txtTransport.BackColor = Color.Black
        Else
            txtTransport.Text = "192.168.15.1"
            txtTransport.ForeColor = Color.Red
            txtTransport.BackColor = Color.Pink
        End If
        PACmachine = pingIPcamera("194.193.192.1")
        If PACmachine = True Then
            txtRms.Text = "194.193.192.1"
            txtRms.ForeColor = Color.LawnGreen
            txtRms.BackColor = Color.Black
        Else
            txtRms.Text = "194.193.192.1"
            txtRms.ForeColor = Color.Red
            txtRms.BackColor = Color.Pink
        End If

    End Sub

    Private Sub btnPac_Click(sender As Object, e As EventArgs) Handles btnPac.Click
        pnlOther.Visible = True
        pnlSen.Visible = False
        pnlHik.Visible = False
        pnlGeo.Visible = False
        pnlWire.Visible = False
        pnlBackup.Visible = False
        lblTile.Text = "NIC MEKA PAC"
    End Sub

    Private Sub picMeka1_DoubleClick(sender As Object, e As EventArgs) Handles picMeka1.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.12.12")
    End Sub

    Private Sub picMeka2_DoubleClick(sender As Object, e As EventArgs) Handles picMeka2.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.11.21")
    End Sub

    Private Sub picMeka3_DoubleClick(sender As Object, e As EventArgs) Handles picMeka3.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.12.11")
    End Sub

    Private Sub picMeka4_DoubleClick(sender As Object, e As EventArgs) Handles picMeka4.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.11.22")
    End Sub
    'Main IP addresses status
    Private Sub lblServer_DoubleClick(sender As Object, e As EventArgs) Handles lblServer.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.100.1")
    End Sub

    Private Sub lblRms_DoubleClick(sender As Object, e As EventArgs) Handles lblRms.DoubleClick
        Process.Start("cmd", "/k ping -t 194.193.192.1")
    End Sub

    Private Sub lblNVR1_DoubleClick(sender As Object, e As EventArgs) Handles lblNVR1.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.2")
    End Sub

    Private Sub lblNVR2_DoubleClick(sender As Object, e As EventArgs) Handles lblNVR2.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.1.40")
    End Sub

    Private Sub lblSynologyNAS_DoubleClick(sender As Object, e As EventArgs) Handles lblSynologyNAS.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.17.2")
    End Sub

    Private Sub lblSynologyRac_DoubleClick(sender As Object, e As EventArgs) Handles lblSynologyRac.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.100.2")
    End Sub

    Private Sub lblDiesel_DoubleClick(sender As Object, e As EventArgs) Handles lblDiesel.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.16.1")
    End Sub

    Private Sub lblTransport_DoubleClick(sender As Object, e As EventArgs) Handles lblTransport.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.15.1")
    End Sub
    Private Sub lblMeena_DoubleClick(sender As Object, e As EventArgs) Handles lblMeena.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.11.1")
    End Sub
    Private Sub lblTkf1_DoubleClick(sender As Object, e As EventArgs) Handles lblTkf1.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.12.10")
    End Sub

    Private Sub lblTkf2_DoubleClick(sender As Object, e As EventArgs) Handles lblTkf2.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.12.13")
    End Sub

    Private Sub lblTkf3_DoubleClick(sender As Object, e As EventArgs) Handles lblTkf3.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.12.14")
    End Sub

    Private Sub lblTkf4_DoubleClick(sender As Object, e As EventArgs) Handles lblTkf4.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.12.15")
    End Sub

    Private Sub lblTkf5_DoubleClick(sender As Object, e As EventArgs) Handles lblTkf5.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.12.16")
    End Sub

    Private Sub lblTkf6_DoubleClick(sender As Object, e As EventArgs) Handles lblTkf6.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.12.17")
    End Sub

    Private Sub lblTkf7_DoubleClick(sender As Object, e As EventArgs) Handles lblTkf7.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.12.18")
    End Sub

    Private Sub lblTkf8_DoubleClick(sender As Object, e As EventArgs) Handles lblTkf8.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.12.19")
    End Sub

    Private Sub lblTkf9_DoubleClick(sender As Object, e As EventArgs) Handles lblTkf9.DoubleClick
        Process.Start("cmd", "/k ping -t 192.168.12.20")
    End Sub


    Dim elapsedTime As Integer = 0
    Dim elapsedTimeSensor As Integer = 0
    Dim elapsedTimeGeo As Integer = 0
    Dim elapsedTimeHik2 As Integer = 0
    Dim elapsedTimeWire As Integer = 0
    Dim elapsedTimePac As Integer = 0


    Private Sub pingTimer_Tick(sender As Object, e As EventArgs) Handles pingTimer.Tick
        elapsedTime += 1
        elapsedTimeSensor += 1
        elapsedTimeGeo += 1
        elapsedTimeHik2 += 1
        elapsedTimeWire += 1
        elapsedTimePac += 1
        If chkBox.CheckState = CheckState.Checked AndAlso elapsedTime >= 300 Then

            btnTestConnection.PerformClick()
            elapsedTime = 0
        End If
        If chkBox.CheckState = CheckState.Checked AndAlso elapsedTimeHik2 >= 327 Then
            btnHikTest2.PerformClick()
            elapsedTimeHik2 = 0
        End If
        If chkBox.CheckState = CheckState.Checked AndAlso elapsedTimeGeo >= 336 Then
            btnckeck.PerformClick()
            elapsedTimeGeo = 0
        End If
        If chkBox.CheckState = CheckState.Checked AndAlso elapsedTimeSensor >= 342 Then
            btnClkSen.PerformClick()
            elapsedTimeSensor = 0
        End If
        If chkBox.CheckState = CheckState.Checked AndAlso elapsedTimeWire >= 348 Then
            btnWireless.PerformClick()
            elapsedTimeWire = 0
        End If
        If chkBox.CheckState = CheckState.Checked AndAlso elapsedTimePac >= 357 Then
            btnmekaping.PerformClick()
            elapsedTimePac = 0
        End If
    End Sub
    'this subroutine Is For rms backup And fms diesel backup
    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to Backup", "Backup process", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Shell("cmd.exe /C" + txtBackup1.Text)
            Shell("cmd.exe /C" + txtBackup2.Text)
            Shell("cmd.exe /C" + txtBackup3.Text)
        Else
            result = DialogResult.No
        End If
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        txtBackup1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtBackup2.Enabled = True
    End Sub

    Private Sub btnQcedit_Click(sender As Object, e As EventArgs) Handles btnQcedit.Click
        txtBackup3.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtBackup1.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txtBackup2.Enabled = False
    End Sub

    Private Sub btnQcsave_Click(sender As Object, e As EventArgs) Handles btnQcsave.Click
        txtBackup3.Enabled = False
    End Sub


    Private Sub picLogo_DoubleClick(sender As Object, e As EventArgs) Handles picLogo.DoubleClick
        picLogo.Visible = False

    End Sub



    Private Sub picSetting_Click(sender As Object, e As EventArgs) Handles picSetting.Click
        pnlBackup.Visible = True
        pnlOther.Visible = False
        pnlSen.Visible = False
        pnlHik.Visible = False
        pnlHik2.Visible = False
        pnlGeo.Visible = False
        pnlWire.Visible = False
        lblTile.Text = "RMS AND DIESEL BACKUP"
    End Sub

    Private Sub picSetting_DoubleClick(sender As Object, e As EventArgs) Handles picSetting.DoubleClick
        picLogo.Visible = True
    End Sub

End Class
