Imports Discord
Imports Discord.WebSocket

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
        Console.WriteLine("[Picture check clock] Checking...")
        Dim nextPicture = New System.Net.WebClient().DownloadString("https://bot.shadowcat.club/api/sendNow.php")
        If nextPicture.Contains("NOW") Then
            Console.WriteLine("[Picture check clock] It's time! Preparing...")
            Dim picture As String = ""
            Dim extrainfo As String = ""
            Dim today As String = DateTime.Today.Day
            Dim manualPic As String = redis.getValue("Pics_dailymanualpic_" & today)
            If manualPic Is Nothing Then
                picture = New System.Net.WebClient().DownloadString("https://api.shadowcat.club/pic.php")
                extrainfo = "*This picture is random out of all pictures already sent. This is not an exclusive one, and can be the same than some other day, as shadow hasn't published an exclusive one for today. Stay tuned for tomorrow!*"
            Else
                picture = manualPic
                extrainfo = "This picture is **EXCLUSIVE**!! This is the first time it's getting posted. Enjoy!"
            End If
            Dim eb As EmbedBuilder = New EmbedBuilder
            eb.WithColor(Color.Gold)
            eb.WithTitle(":flushed: Daily Pepsi picture delivered!")
            eb.WithDescription("Here is the pepsi pic for today! Enjoy! You can react with :+1: or :-1: if you like it or no!" & vbCrLf & ":arrow_right: **Can't see the picture?** That's maybe because the picture is in 4K, which it's too big for discord to display properly. If it's not loading, [click here for the direct link of that picture](" & picture & ")." & vbCrLf & vbCrLf & extrainfo)
            eb.WithFooter("Pepsi bot - Made by X_Shadow_#5962 - Invite it at https://bot.shadowcat.club")
            eb.WithImageUrl(picture)
            Console.WriteLine("[Picture check clock] Started to send")
            For Each guild In discordEv.Guilds
                Dim channels = guild.Channels.Where(Function(x) TypeOf x Is ISocketMessageChannel)
                For Each channel As ISocketMessageChannel In channels.ToList
                    If channel.Name Is Nothing Then
                        Continue For
                    End If
                    If channel.Name.ToString.ToLower.Contains("pepsi") Then
                        Dim message = channel.SendMessageAsync("", False, eb.Build).Result
                        message.AddReactionAsync(New Emoji("👍"))
                        message.AddReactionAsync(New Emoji("👎"))
                        Console.WriteLine("Sent to #" & channel.Name.ToString)
                        System.Threading.Thread.Sleep(200)
                    End If
                Next
            Next
        Else
            Console.WriteLine("[Picture check clock] Not the time.")
        End If
    End Function

End Module
