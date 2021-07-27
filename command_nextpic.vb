Imports Discord
Module command_nextpic
    Async Sub run(message As IMessage)
        Try
            Dim nextPicture = New System.Net.WebClient().DownloadString("https://bot.shadowcat.club/api/nextDaily.php")
            Await message.Channel.SendMessageAsync("The next daily picture is in **" & nextPicture & "**")
        Catch ex As Exception

        End Try
    End Sub
End Module
