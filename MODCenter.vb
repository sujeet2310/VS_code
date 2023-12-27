
'Option Explicit On
'Option Strict On
Imports System.Data.OleDb

Module MODCenter

    Public con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\FileStorage.accdb")
    Public da As OleDbDataAdapter
    Public dt As DataTable
    Public cmd As OleDbCommand
    Public sql As String
    Public conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\FileStorage.accdb"
    Public strLang As String = "File Vault"
    Public strAnd As String = Chr(38) ' &
    Public strSpace As String = Chr(32) ' Blank space
    Public dbName As String = "FileStorageBox"
    Public smilingFace As String = Char.ConvertFromUtf32(&H1F60A)
    Public mainProjectName As String = "File Storage"
    Public SubProjectName As String = "Protected Vault"

    Public appTitle1 As String = String.Format("{0} {1}", strLang, mainProjectName)
    Public appTitlewithdb As String = String.Format("{0} {1} {2} {3}", strLang, strAnd, dbName, mainProjectName)

    Public appTitle2 As String = String.Format("{0} {1}", strLang, SubProjectName)
    Public apTiltle2withdb As String = String.Format("{0} {1} {2} {3}", strLang, strAnd, dbName, SubProjectName)

    Public conState As Boolean = False

    Public currentUserID As String = ""
    Public currentUsername As String = ""
    Public currentPermission As String = ""

    ' This sub routing is for manage connection b|w database and show database is connected or not in status bar
    Public Sub ManageConnection()
        conState = False
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con.ConnectionString = conString
            con.Open()
            conState = True
            coolBlue.ToolDatabaseConnect.Text = "Connected to Database"
            coolBlue.ToolDatabaseConnect.ForeColor = Color.ForestGreen
            coolBlue.ToolDatabaseConnect.Image = My.Resources.databases
        Catch ex As Exception
            conState = False

            coolBlue.ToolDatabaseConnect.Text = "Failed to Connect with Database"
            coolBlue.ToolDatabaseConnect.ForeColor = Color.OrangeRed
            coolBlue.ToolDatabaseConnect.Image = My.Resources.plug_in


        End Try
    End Sub
    Public Function DisplayData(str As String, tbl As String, myDS As DataSet) As DataSet
        If conState = False Then
            ManageConnection()
        End If
        Dim ds As New DataSet
        Try
            ds.Clear()
            da = New OleDbDataAdapter(str, con)
            da.Fill(myDS, tbl)
            ds = myDS

        Catch ex As Exception
            ds = Nothing
            conState = False
        Finally
            conState = False
            con.Close()

        End Try
        DisplayData = ds
    End Function
    Public Function ExecuteDb(mySQL As String) As Boolean

        Dim bCheck As Boolean = False

        If conState = False Then
            ManageConnection()
        End If

        Try
            cmd = New OleDbCommand(mySQL, con)
            cmd.CommandTimeout = 600
            cmd.ExecuteNonQuery()
            bCheck = True

        Catch ex As Exception
            bCheck = False
            MessageBox.Show("Error: " & ex.Message, appTitlewithdb, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conState = False
            con.Close()

        End Try
        ExecuteDb = bCheck
    End Function

End Module
