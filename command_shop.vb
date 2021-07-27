Imports Discord
Module command_shop
    Async Sub run(message As IMessage)
        Dim eb = New EmbedBuilder
        eb.WithTitle("Item shop")
        eb.WithColor(Color.Gold)

        For Each item In ec_items.items
            Dim fb = New EmbedFieldBuilder
            fb.WithName(ec_items.items.IndexOf(item) + 1 & ". " & item.name)
            fb.WithValue("Price: " & item.price & ":cat2: cattos." & vbCrLf & vbCrLf & item.description)
            fb.WithIsInline(True)
            eb.AddField(fb)
        Next

        eb.WithFooter("Buy with the command $buy <number of the item>")
        Await message.Channel.SendMessageAsync("", False, eb.Build)
    End Sub
End Module
