Public Class Proxy
    ''' <summary>
    ''' Enables the users' current proxy settings
    ''' </summary>
    ''' <returns>Proxy State (Integer): 1 for enabled, 0 for diabled, 2 for error</returns>
    ''' <remarks></remarks>
    Shared Function Enable()
        Dim WSH 'Wscript object
        Dim value As New String("") 'value string
        WSH = CreateObject("WScript.Shell") 'create Wscript
        WSH.RegWrite("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\ProxyEnable", "1") 'write enable reg key
        value = WSH.RegRead("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\ProxyEnable") 'read key to check if sucessful
        If value = "0" Then ' if diabled
            Return 0 'return disabled
        ElseIf value = "1" Then ' if enabled
            Return 1 'return enabled
        ElseIf value = "0x00000000" Then 'if disabled (binary)
            Return 0 'return disabled
        ElseIf value = "0x00000001" Then 'id enabled (binary)
            Return 1 'return enabled
        Else 'else if error
            Return 2 'return error code 2
        End If 'end if
    End Function
    ''' <summary>
    ''' Disables the users' current proxy settings
    ''' </summary>
    ''' <returns>Proxy State (Integer): 1 for enabled, 0 for diabled, 2 for error</returns>
    ''' <remarks></remarks>
    Shared Function Disable()
        Dim WSH 'Wscript object
        Dim value As New String("") 'value string
        WSH = CreateObject("WScript.Shell") 'create Wscript
        WSH.RegWrite("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\ProxyEnable", "0x00000000") 'write diabled (binary so internet explorer understands)
        value = WSH.RegRead("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\ProxyEnable") 'read key to check if sucessful
        If value = "0" Then ' if diabled
            Return 0 'return disabled
        ElseIf value = "1" Then ' if enabled
            Return 1 'return enabled
        ElseIf value = "0x00000000" Then 'if disabled (binary)
            Return 0 'return disabled
        ElseIf value = "0x00000001" Then 'id enabled (binary)
            Return 1 'return enabled
        Else 'else if error
            Return 2 'return error code 2
        End If 'end if
    End Function
    ''' <summary>
    ''' Gets users' proxy state, i.e Enabled/Disabled
    ''' </summary>
    ''' <returns>True for Enabled, False for Disabled</returns>
    ''' <remarks></remarks>
    Shared Function GetStatus()
        Dim WSH 'Wscript object
        Dim value As New String("") 'value string
        WSH = CreateObject("WScript.Shell") 'create Wscript
        value = WSH.RegRead("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\ProxyEnable") 'read status reg key
        If value = "0" Then 'if disabled
            Return False 'return false
        ElseIf value = "1" Then 'if enabled
            Return True 'return true
        ElseIf value = "0x00000000" Then 'if disabled (binary)
            Return False 'return false
        ElseIf value = "0x00000001" Then 'if enabled (binary)
            Return True 'return true
        Else 'else on error
            Return False 'return false
        End If
    End Function
    ''' <summary>
    ''' Changes the procy url and port
    ''' </summary>
    ''' <param name="url">Url of proxy server</param>
    ''' <param name="port">Port of proxy server</param>
    ''' <returns>True on completion</returns>
    ''' <remarks></remarks>
    Shared Function ChangeProxy(ByVal url As String, ByVal port As String)
        Dim WSH 'Wscript object
        WSH = CreateObject("WScript.Shell") 'Create Wscript object
        If port = "" Then 'if port is empty
            WSH.RegWrite("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\ProxyServer", url) 'just write the url
        Else 'else if port and url
            WSH.RegWrite("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\ProxyServer", url & ":" & port) 'write url:port
        End If
        Return 1 'return done
    End Function
    ''' <summary>
    ''' Gets the users current proxy Url in the form http://www.url.com:port, if there is no port, then it is in the form http://www.url.com
    ''' </summary>
    ''' <returns>Proxy url in form http://www.url.com:port, if there is no port, then it is in the form http://www.url.com</returns>
    ''' <remarks></remarks>
    Shared Function GetProxyUrl()
        Dim WSH 'Wscript object
        WSH = CreateObject("WScript.Shell") 'Create Wscript object
        Return WSH.RegRead("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\ProxyServer") 'return proxy url and port
    End Function
End Class
