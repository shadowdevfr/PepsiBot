Imports Discord
Module command_buyitem
    Async Sub run(message As IMessage, item As String)
        Try
            Dim curcoins = redis.getValue("Users_" & message.Author.Id & "_coins")

            If item Is Nothing Then
                Dim ebe As EmbedBuilder = New EmbedBuilder
                ebe.WithDescription("<:denied:869341509160419399> You did not provide any item to buy!")
                ebe.WithColor(Color.Red)
                Await message.Channel.SendMessageAsync("", False, ebe.Build)
                Exit Sub
            End If

            If Not ec_items.items.Contains(ec_items.items(item - 1)) Then
                Dim ebe As EmbedBuilder = New EmbedBuilder
                ebe.WithDescription("<:denied:869341509160419399> Cannot find this item!")
                ebe.WithColor(Color.Red)
                Await message.Channel.SendMessageAsync("", False, ebe.Build)
                Exit Sub
            End If

            Dim itemname = ec_items.items(item - 1).name
            Dim price = ec_items.items(item - 1).price

            If (curcoins - price) < 0 Then
                Dim ebe As EmbedBuilder = New EmbedBuilder
                ebe.WithDescription("<:denied:869341509160419399> You need **" & Math.Abs(curcoins - price) & "**:cat2: cattos more to buy this item!")
                ebe.WithColor(Color.Red)
                Await message.Channel.SendMessageAsync("", False, ebe.Build)
                Exit Sub
            End If

            redis.setValue("Users_" & message.Author.Id & "_coins", Math.Round(curcoins - price, 2))
            redis.addValueToArray("Users_" & message.Author.Id & "_inventory", item)

            Dim eb As EmbedBuilder = New EmbedBuilder
            eb.WithDescription("<:good:869341729222959115> You just bought **" & itemname & "** for **" & price & "**:cat2: cattos!")
            eb.WithColor(Color.Green)

            Await message.Channel.SendMessageAsync("", False, eb.Build)
        Catch ex As Exception

        End Try
    End Sub
End Module
