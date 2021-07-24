Imports Discord

Module timeCheckClock
    Dim aTimer As New System.Timers.Timer

    Public Sub startClock()
        aTimer.AutoReset = True
        aTimer.Interval = 60000 '60 seconds
        AddHandler aTimer.Elapsed, AddressOf tick
        aTimer.Start()
        Console.WriteLine("[Picture check clock] Started picture check clock (60s)!")
    End Sub

    Private Sub tick(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        checkForTimeNewPepsiPic()
    End Sub
    Public Function checkForTimeNewPepsiPic() As Task
        ' soon
    End Function

End Module
