Imports Discord
Module command_rob
    Async Sub run(message As IMessage, robUserID As String)
        Try
            If message.Author.Id = robUserID Then
                Dim ebe As EmbedBuilder = New EmbedBuilder
                ebe.WithDescription("<:denied:869341509160419399> Robbing yourself???")
                ebe.WithColor(Color.Red)
                Await message.Channel.SendMessageAsync("", False, ebe.Build)
                Exit Sub
            End If

            Dim curcoins = redis.getValue("Users_" & robUserID & "_coins")
            Dim nextRob = redis.getValue("Users_" & message.Author.Id & "_nextRob")
            Dim secondsBeforeClaim = 0
            Dim uTime As Double = CDbl(New System.Net.WebClient().DownloadString("https://bot.shadowcat.club/api/time.php"))
            secondsBeforeClaim = nextRob - uTime
            If secondsBeforeClaim <= 0 Then
                If curcoins <= 0 Then
                    Dim ebe As EmbedBuilder = New EmbedBuilder
                    ebe.WithDescription("<:denied:869341509160419399> This user has no coins!")
                    ebe.WithColor(Color.Red)
                    Await message.Channel.SendMessageAsync("", False, ebe.Build)
                    Exit Sub
                End If
                redis.setValue("Users_" & message.Author.Id & "_nextRob", uTime + 120)
                Dim ocurcoins = redis.getValue("Users_" & message.Author.Id & "_coins")
                Dim random = New Random
                Dim chance = 1
                If Not chance = 1 Then
                    Dim ebe As EmbedBuilder = New EmbedBuilder
                    ebe.WithDescription("<:denied:869341509160419399> Oh, no luck today...")
                    ebe.WithColor(Color.Red)
                    Await message.Channel.SendMessageAsync("", False, ebe.Build)
                    Exit Sub
                End If

                Dim calc1 = curcoins / 2
                If calc1 < 3 Then
                    Dim ebe As EmbedBuilder = New EmbedBuilder
                    ebe.WithDescription("<:denied:869341509160419399> Not worth it, this user got less than 3 coins...")
                    ebe.WithColor(Color.Red)
                    Await message.Channel.SendMessageAsync("", False, ebe.Build)
                    Exit Sub
                End If
                Dim toEarn = random.Next(2, calc1)

                redis.setValue("Users_" & robUserID & "_coins", Math.Round(curcoins - toEarn, 2))
                redis.setValue("Users_" & message.Author.Id & "_coins", Math.Round(ocurcoins + toEarn, 2))
                curcoins = redis.getValue("Users_" & robUserID & "_coins")
                Dim eb = New EmbedBuilder
                eb.WithDescription("<:good:869341729222959115> You just robbed this user for **" & toEarn & "**:cat2: cattos! He now has **" & curcoins & "**:cat2: cattos!")
                eb.WithColor(Color.Green)
                Await message.Channel.SendMessageAsync("", False, eb.Build)
                Exit Sub
            Else
                Dim ebe As EmbedBuilder = New EmbedBuilder
                ebe.WithDescription("<:denied:869341509160419399> You need to wait **" & Math.Abs(secondsBeforeClaim) & "** seconds before robbing someone again.")
                ebe.WithColor(Color.Red)
                Await message.Channel.SendMessageAsync("", False, ebe.Build)
                Exit Sub
            End If
        Catch ex As Exception
            Console.WriteLine("[E @ " & ex.ToString & "] " & ex.Message)
        End Try

    End Sub
End Module
