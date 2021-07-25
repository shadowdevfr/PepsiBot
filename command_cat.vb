Imports Discord
Module command_cat
    Async Sub run(message As IMessage)
        Dim imageLink = New System.Net.WebClient().DownloadString("https://api.mythicalkitten.com/cats/shadowcat")
        Dim eb As EmbedBuilder = New EmbedBuilder
        eb.WithTitle("Catto")
        eb.WithColor(Color.Gold)
        eb.WithImageUrl(imageLink)

        Await message.Channel.SendMessageAsync("", False, eb.Build)
    End Sub
End Module
