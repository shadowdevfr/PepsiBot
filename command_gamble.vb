Imports Discord
Module command_gamble
    Async Sub run(message As IMessage)

        Dim curcoins = redis.getValue("Users_" & message.Author.Id & "_coins")
        Dim eb As EmbedBuilder = New EmbedBuilder

        Dim random = New Random
        Dim chance = random.Next(1, 3)


        If curcoins <= 0 Then
            eb.WithDescription("<:denied:869341509160419399> You do not have any cattos to gamble!")
            eb.WithColor(Color.Red)
            Await message.Channel.SendMessageAsync("", False, eb.Build)
            Exit Sub
        End If

        If chance = 1 Then
            ' good chance, add coins
            Dim coinsToAddOrRemove = random.Next(2, 10)
            redis.setValue("Users_" & message.Author.Id & "_coins", Math.Round(curcoins + coinsToAddOrRemove, 2))
            eb.WithDescription("<:good:869341729222959115> You just won **" & coinsToAddOrRemove & "**:cat2: cattos!")
            eb.WithColor(Color.Green)
        Else
            ' bad chance, remove coins
            Dim coinsToAddOrRemove = random.Next(2, 20)
            redis.setValue("Users_" & message.Author.Id & "_coins", Math.Round(curcoins - coinsToAddOrRemove, 2))
            eb.WithDescription("<:denied:869341509160419399> You just lost **" & coinsToAddOrRemove & "**:cat2: cattos.")
            eb.WithColor(Color.Red)
        End If

        Await message.Channel.SendMessageAsync("", False, eb.Build)
    End Sub
End Module
