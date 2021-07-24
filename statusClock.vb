Imports Discord
Imports Newtonsoft.Json

Module statusClock
    Dim aTimer As New System.Timers.Timer

    Public Sub startStatusClock()
        aTimer.AutoReset = True
        aTimer.Interval = 30000 '60 seconds
        AddHandler aTimer.Elapsed, AddressOf tick
        aTimer.Start()
        Console.WriteLine("[Status] Status clock started (30s)")
    End Sub

    Private Sub tick(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        updateStatus()
    End Sub

    Public Sub updateStatus()
        Dim status = "pepsi"
        Program.discordEv.SetGameAsync(status, "", ActivityType.Watching)
        Console.WriteLine("[Status] Updated status to " & status)
    End Sub
End Module
