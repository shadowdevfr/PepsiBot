Module twdb
    Public Function getValue(tag As String) As String
        Dim value As String = New System.Net.WebClient().DownloadString(config.databaseUrl & "getvalue.php?tag=" & tag)
        Return value
    End Function

    Public Function storeValue(tag As String, value As String) As String
        Dim result As String = New System.Net.WebClient().DownloadString(config.databaseUrl & "storeavalue.php?tag=" & tag & "&value=" & value)
        Return result
    End Function
End Module
