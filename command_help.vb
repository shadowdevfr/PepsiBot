Imports Discord
Module command_help
    Async Sub run(message As IMessage)
        Dim eb As EmbedBuilder = New EmbedBuilder
        eb.WithTitle("Help")
        eb.WithColor(Color.Gold)

        Dim fb = New EmbedFieldBuilder
        fb.WithName("$cat")
        fb.WithValue("Sends a random cat picture")
        fb.WithIsInline(False)
        eb.AddField(fb)

        fb = New EmbedFieldBuilder
        fb.WithName("$nextpic")
        fb.WithValue("Time before the next daily pepsi picture")
        fb.WithIsInline(False)
        eb.AddField(fb)

        fb = New EmbedFieldBuilder
        fb.WithName("$xp or $i")
        fb.WithValue("Your user information (XP, cattos etc..)")
        fb.WithIsInline(False)
        eb.AddField(fb)

        fb = New EmbedFieldBuilder
        fb.WithName("$shop")
        fb.WithValue("Shop of available items you can buy with cattos")
        fb.WithIsInline(False)
        eb.AddField(fb)

        fb = New EmbedFieldBuilder
        fb.WithName("$daily")
        fb.WithValue("Daily cattos")
        fb.WithIsInline(False)
        eb.AddField(fb)

        fb = New EmbedFieldBuilder
        fb.WithName("$gamble")
        fb.WithValue("Gamble coins")
        fb.WithIsInline(False)
        eb.AddField(fb)

        fb = New EmbedFieldBuilder
        fb.WithName("$rob")
        fb.WithValue("Rob an user")
        fb.WithIsInline(False)
        eb.AddField(fb)

        fb = New EmbedFieldBuilder
        fb.WithName("$inv")
        fb.WithValue("Your inventory")
        fb.WithIsInline(False)
        eb.AddField(fb)

        fb = New EmbedFieldBuilder
        fb.WithName("$lb")
        fb.WithValue("XP leaderboard")
        fb.WithIsInline(False)
        eb.AddField(fb)

        Await message.Channel.SendMessageAsync("", False, eb.Build)
    End Sub
End Module
