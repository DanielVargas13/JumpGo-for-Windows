﻿'Imports Skybound.Gecko
Imports System.Net
Imports System.IO

Imports Gecko
'Imports System.IO
Imports System.Linq
Imports System.Reflection

Public Class IncognitoTab

    Dim MenuOpen As Boolean = False

    Sub New()

        InitializeComponent()
        'Xpcom.Initialize(Environment.CurrentDirectory + "/xulrunner")
        Dim app_dir = Path.GetDirectoryName(Application.ExecutablePath)
        Gecko.Xpcom.Initialize(Path.Combine(app_dir, "xulrunner"))
        'Xpcom.CreateInstance(Of AppDomainManager)("@mozilla.org/login-manager;1")
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FasterBrowser1.GoBack()
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FasterBrowser1.GoForward()
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "JumpGo://Getting Started" Then
            FasterBrowser1.Navigate(Environment.CurrentDirectory + "\Getting Started.html")
            TextBox1.Text = "JumpGo://Getting Started"
        Else
            FasterBrowser1.Navigate(TextBox1.Text)
            'AxWebBrowser1.Navigate(TextBox1.Text)
        End If
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FasterBrowser1.Reload()
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        FasterBrowser1.Navigate(My.Settings.Home)
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub FasterBrowser1_Click(sender As Object, e As EventArgs) Handles FasterBrowser1.Click
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub FasterBrowser1_MouseClick(sender As Object, e As MouseEventArgs) Handles FasterBrowser1.MouseClick
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub FasterBrowser1_MouseDown(sender As Object, e As MouseEventArgs) Handles FasterBrowser1.MouseDown
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub FasterBrowser1_MouseHover(sender As Object, e As EventArgs) Handles FasterBrowser1.MouseHover
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub FasterBrowser1_Navigated(sender As Object, e As GeckoNavigatedEventArgs) Handles FasterBrowser1.Navigated
        'AxWebBrowser1.Navigate(FasterBrowser1.Url)
        'FasterBrowser1.Url.ToString()
        TextBox1.Text = FasterBrowser1.Url.ToString
        'Me.Icon
        'Me.Text = FasterBrowser1.Document.Title.ToString
        'Me.Text = FasterBrowser1.Text.ToString
        Me.Text = FasterBrowser1.DocumentTitle.ToString
        'Me.Text = FasterBrowser1.Url.AbsoluteUri
        If FasterBrowser1.Url.AbsolutePath = Environment.CurrentDirectory + "\Getting Started.html" Then
            TextBox1.Text = "JumpGo://Getting Started"
        End If
        FavIconChange()
        geticon()
    End Sub

    Private Sub FasterBrowser1_DocumentCompleted(sender As Object, e As EventArgs) Handles FasterBrowser1.DocumentCompleted
        'AxWebBrowser1.Navigate(FasterBrowser1.Url)
        'FasterBrowser1.Url.ToString()
        TextBox1.Text = FasterBrowser1.Url.ToString
        'Me.Icon
        'Me.Text = FasterBrowser1.Document.Title.ToString
        'Me.Text = FasterBrowser1.Text.ToString
        Me.Text = FasterBrowser1.DocumentTitle.ToString
        'Me.Text = FasterBrowser1.Url.AbsoluteUri
        If FasterBrowser1.Url.AbsolutePath = Environment.CurrentDirectory + "\Getting Started.html" Then
            TextBox1.Text = "JumpGo://Getting Started"
        End If
        If FasterBrowser1.Url.AbsoluteUri = Environment.CurrentDirectory + "\Getting Started.html" Then
            TextBox1.Text = "JumpGo://Getting Started"
        End If
        FavIconChange()
        geticon()
    End Sub

    Private Sub geticon()
        Try
            Dim url As Uri = New Uri(FasterBrowser1.Url.ToString)

            If url.HostNameType = UriHostNameType.Dns Then

                ' Get the URL of the favicon
                ' url.Host will return such string as www.google.com
                Dim iconURL = "http://" & url.Host & "/favicon.ico"

                Dim newFileName As String
                newFileName = "favicon.ico"

                ' Download the favicon
                Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(iconURL)
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim stream As System.IO.Stream = response.GetResponseStream()
                Dim favicon = Image.FromStream(stream)
                'Dim bmp As System.Drawing.Image = System.Drawing.Image.FromFile(favicon, True)
                Dim bmp As System.Drawing.Bitmap = favicon
                Dim ico As System.Drawing.Icon = System.Drawing.Icon.FromHandle(bmp.GetHicon())
                'Dim icofs As Stream = File.Create(newFileName)
                'ico.Save(icofs)
                'icofs.Close()

                ' Display the favicon on ToolStripLabel1
                'Me.favicon.Image = favicon
                Me.Icon = ico
            End If
        Catch ex As Exception
            'Me.favicon.Image = Nothing
        End Try
    End Sub

    Function FavIconSwtich()

        Return 0
    End Function

    Function FavIconChange()


        Return 0
    End Function

    Private Sub AboutGoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        AboutBox1.Visible = True
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        FasterBrowser1.Navigate(My.Settings.Search & TextBox2.Text)
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Button3.PerformClick()
            Panel4.Visible = False
            MenuOpen = False
        End If
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Button6.PerformClick()
            Panel4.Visible = False
            MenuOpen = False
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub BToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FasterBrowser1.Stop()
    End Sub

    Private Sub Tab_Click(sender As Object, e As EventArgs) Handles Me.Click
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Tab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.FirstRun = True Then
            FasterBrowser1.Navigate(Environment.CurrentDirectory + "\Incognito\New Tab.html")
            My.Settings.FirstRun = False
            JumpGoMain.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Else
            FasterBrowser1.Navigate(My.Settings.NewTab)
            'FasterBrowser1.Navigate(Environment.CurrentDirectory + "\Incognito\New Tab.html")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MenuOpen = False Then
            Panel4.Visible = True
            MenuOpen = True
        Else
            Panel4.Visible = False
            MenuOpen = False
        End If
    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        IncognitoMain.CreateNewTab(My.Settings.NewTab)
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim SecondForm As New IncognitoMain
        SecondForm.Show()
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        FasterBrowser1.SaveDocument(SaveFileDialog1.ShowDialog)
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        OpenFileDialog1.ShowDialog()
        FasterBrowser1.Navigate(OpenFileDialog1.FileName)
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        AboutBox1.Visible = True
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Settings.Visible = True
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        JumpGoMain.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'geticon()
        'FasterBrowser1.Refresh()
    End Sub

    Function themetimer()
        If My.Settings.NavPanelBG = "" Then
            Panel1.BackgroundImage = My.Resources.Transparent
        Else
            Panel1.BackgroundImage = System.Drawing.Image.FromFile(My.Settings.NavPanelBG)
        End If

        If My.Settings.MenuPanelBG = "" Then
            Panel4.BackgroundImage = My.Resources.Transparent
        Else
            Panel4.BackgroundImage = System.Drawing.Image.FromFile(My.Settings.MenuPanelBG)
        End If

        If My.Settings.ThemeColor = "Dark" Then
            Button1.BackgroundImage = My.Resources.Back_Icon
            Button2.BackgroundImage = My.Resources.Forward_Icon1
            Button3.BackgroundImage = My.Resources.Forward_Icon1
            Button4.BackgroundImage = My.Resources.Refresh_Icon
            Button5.BackgroundImage = My.Resources.Home_Icon
            Button6.BackgroundImage = My.Resources.dgjkbv
            Button7.BackgroundImage = My.Resources.Menu_Icon
        Else
            Button1.BackgroundImage = My.Resources.Back_Icon___Light
            Button2.BackgroundImage = My.Resources.Forward_Icon___Light
            Button3.BackgroundImage = My.Resources.Forward_Icon___Light
            Button4.BackgroundImage = My.Resources.Refresh_Icon___Light
            Button5.BackgroundImage = My.Resources.Home_Icon___Light
            Button6.BackgroundImage = My.Resources.dgjkbv___Light
            Button7.BackgroundImage = My.Resources.Menu_Icon___Light
        End If
        Return 0
    End Function

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        ThemeDesign.Visible = True
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        'WebSource.Visible = True
        'WebSource.FastColoredTextBox1.Text = FasterBrowser1.DocumentTitle
        FasterBrowser1.ViewSource()
        Panel4.Visible = False
        MenuOpen = False

    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        SourceWriter.Visible = True
        Panel4.Visible = False
        MenuOpen = False
    End Sub

    Private Sub FasterBrowser1_Navigating(sender As Object, e As Events.GeckoNavigatingEventArgs) Handles FasterBrowser1.Navigating

    End Sub

    Private Sub FasterBrowser1_DocumentCompleted(sender As Object, e As Events.GeckoDocumentCompletedEventArgs) Handles FasterBrowser1.DocumentCompleted

    End Sub
End Class