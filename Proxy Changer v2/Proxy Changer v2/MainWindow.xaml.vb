Class MainWindow
    Dim isclosing As New String("0")
    Private Sub MainWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        If isclosing = "1" Then

        Else
            e.Cancel = True
            Me.Hide()
            TaskbarIcon.ShowBalloonTip("Proxy Changer V2", "Proxy Changer V2 is now running in the backround, to close, right click this icon and select 'Close'.", Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Info)
        End If
    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        If ProxyChangerAPI.Proxy.GetStatus Then
            EnableButton.IsEnabled = False
            DisableButton.IsEnabled = True
            ProxyStatusLabel.Content = "Proxy is Enabled"
        Else
            EnableButton.IsEnabled = True
            DisableButton.IsEnabled = False
            ProxyStatusLabel.Content = "Proxy is Disabled"
        End If
        Dim url As New String("")
        Dim port As New String("")
        Dim urlsplit
        url = ProxyChangerAPI.Proxy.GetProxyUrl
        urlsplit = url.Split(":")
        port = urlsplit(1)
        url = urlsplit(0)
        urlTextBox.Text = url
        PortTextBox.Text = port
    End Sub

    Private Sub ChangeProxyButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ChangeProxyButton.Click
        ProxyChangerAPI.Proxy.ChangeProxy(urlTextBox.Text, PortTextBox.Text)

    End Sub

    Private Sub EnableButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles EnableButton.Click
        ProxyChangerAPI.Proxy.Enable()
        If ProxyChangerAPI.Proxy.GetStatus Then
            EnableButton.IsEnabled = False
            DisableButton.IsEnabled = True
            ProxyStatusLabel.Content = "Proxy is Enabled"
        Else
            EnableButton.IsEnabled = True
            DisableButton.IsEnabled = False
            ProxyStatusLabel.Content = "Proxy is Disabled"
        End If
    End Sub

    Private Sub DisableButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles DisableButton.Click
        ProxyChangerAPI.Proxy.Disable()
        If ProxyChangerAPI.Proxy.GetStatus Then
            EnableButton.IsEnabled = False
            DisableButton.IsEnabled = True
            ProxyStatusLabel.Content = "Proxy is Enabled"
        Else
            EnableButton.IsEnabled = True
            DisableButton.IsEnabled = False
            ProxyStatusLabel.Content = "Proxy is Disabled"
        End If
    End Sub

    Private Sub AboutButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim about As New Window1
        about.Show()
    End Sub

    Private Sub CloseProxyMenu_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles CloseProxyMenu.Click
        isclosing = "1"
        Me.Close()
    End Sub

    Private Sub OpenProxyMenu_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles OpenProxyMenu.Click
        Me.Show()
    End Sub

    Private Sub DisableProxyMenu_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles DisableProxyMenu.Click
        ProxyChangerAPI.Proxy.Disable()
        If ProxyChangerAPI.Proxy.GetStatus Then
            EnableButton.IsEnabled = False
            DisableButton.IsEnabled = True
            ProxyStatusLabel.Content = "Proxy is Enabled"
        Else
            EnableButton.IsEnabled = True
            DisableButton.IsEnabled = False
            ProxyStatusLabel.Content = "Proxy is Disabled"
        End If
    End Sub

    Private Sub EnableProxyMenu_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles EnableProxyMenu.Click
        ProxyChangerAPI.Proxy.Enable()
        If ProxyChangerAPI.Proxy.GetStatus Then
            EnableButton.IsEnabled = False
            DisableButton.IsEnabled = True
            ProxyStatusLabel.Content = "Proxy is Enabled"
        Else
            EnableButton.IsEnabled = True
            DisableButton.IsEnabled = False
            ProxyStatusLabel.Content = "Proxy is Disabled"
        End If
    End Sub

    Private Sub menu_Opened(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles menu.Opened
        If ProxyChangerAPI.Proxy.GetStatus Then
            EnableProxyMenu.IsEnabled = False
            DisableProxyMenu.IsEnabled = True
        Else
            EnableProxyMenu.IsEnabled = True
            DisableProxyMenu.IsEnabled = False
        End If
        UrlProxyMenu.Header = "Proxy Url: " & ProxyChangerAPI.Proxy.GetProxyUrl()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        isclosing = "1"
        Me.Close()
    End Sub
End Class
