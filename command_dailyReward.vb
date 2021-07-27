Imports Discord
Module command_dailyReward
    Async Sub run(message As IMessage)
        Dim nextClaim = redis.getValue("Users_" & message.Author.Id & "_dailyClaimNext")
        Dim secondsBeforeClaim = 0
        Dim uTime = New System.Net.WebClient().DownloadString("https://bot.shadowcat.club/api/time.php")
        Dim eb As EmbedBuilder = New EmbedBuilder
        If nextClaim Is Nothing Then
            nextClaim = 0
        End If
        secondsBeforeClaim = nextClaim - uTime
        If secondsBeforeClaim <= 0 Then
            Dim random = New Random
            Dim amount = random.Next(2, 16)

            Dim curcoins = redis.getValue("Users_" & message.Author.Id & "_coins")
            redis.setValue("Users_" & message.Author.Id & "_coins", Math.Round(curcoins + amount, 2))

            redis.setValue("Users_" & message.Author.Id & "_dailyClaimNext", uTime + 86400)
            eb.WithDescription("<:good:869341729222959115> You received " & amount & ":cat2: cattos for today!")
            eb.WithColor(Color.Green)
        Else
            Dim nDateTime As System.DateTime = New System.DateTime(1970, 1, 1, 0, 0, 0, 0)
            Dim cooldownEnd = nDateTime.AddSeconds(nextClaim)
            Dim lastFormat = "s"
            If DateDiff(DateInterval.Second, DateTime.Now, cooldownEnd) > 60 Then
                If DateDiff(DateInterval.Minute, DateTime.Now, cooldownEnd) > 60 Then
                    lastFormat = DateDiff(DateInterval.Hour, DateTime.Now, cooldownEnd) & " hours"
                Else
                    lastFormat = DateDiff(DateInterval.Minute, DateTime.Now, cooldownEnd) & " minutes"
                End If
            Else
                lastFormat = DateDiff(DateInterval.Second, DateTime.Now, cooldownEnd) & " seconds"
            End If
            eb.WithDescription("<:denied:869341509160419399> You need to wait **" & lastFormat & "** before claiming again.")
            eb.WithColor(Color.Red)
        End If
            Await message.Channel.SendMessageAsync("", False, eb.Build)
    End Sub
End Module
