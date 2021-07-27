Imports Discord
Module command_inventory
    Async Sub run(message As IMessage)
        Dim eb As EmbedBuilder = New EmbedBuilder
        eb.WithTitle("Inventory of " & message.Author.Username & "#" & message.Author.Discriminator)

        Dim inventorya As Array = redis.getArray("Users_" & message.Author.Id & "_inventory")
        Dim inventory = New List(Of Integer)
        For Each itemID In inventorya
            Try
                inventory.Add(itemID)
            Catch ex As Exception

            End Try
        Next
        Dim groups = inventory.GroupBy(Function(value) value)
        For Each grp In groups
            Try
                Dim fb = New EmbedFieldBuilder
                fb.WithIsInline(True)
                fb.WithName(grp.Count & "x " & ec_items.items(grp(0) - 1).name)
                fb.WithValue("** **")
                eb.AddField(fb)
            Catch ex As Exception

            End Try

        Next

        eb.WithColor(Color.Gold)

        Await message.Channel.SendMessageAsync("", False, eb.Build)
    End Sub
End Module
