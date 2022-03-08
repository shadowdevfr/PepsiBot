Imports Discord
Module command_shop
    Async Sub run(message As IMessage)
        Dim eb = New EmbedBuilder
        eb.WithTitle("Item shop")
        eb.WithColor(Color.Gold)

        For Each item As itemClass In ec_items.items
            If item.buyable Then
                Dim fb = New EmbedFieldBuilder
                fb.WithName(ec_items.items.IndexOf(item) + 1 & ". " & item.name)
                fb.WithValue(":moneybag: **Price**" & vbCrLf & "> **" & item.price & "**:cat2: cattos." & vbCrLf & vbCrLf & ":scroll: **Description**" & vbCrLf & "> " & item.description)
                fb.WithIsInline(True)
                eb.AddField(fb)
            End If
        Next

        eb.WithFooter("Buy with the command $buy <number of the item>")
        Await message.Channel.SendMessageAsync("", False, eb.Build)
    End Sub
End Module
