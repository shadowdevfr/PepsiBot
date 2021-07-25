Imports Discord
Imports Discord.WebSocket
Module command_publishcatpicture
    Async Sub run(message As IMessage, imagelink As String, description As String)
        Dim eb As EmbedBuilder = New EmbedBuilder
        eb.WithTitle(":rotating_light: Exclusive picture!")
        eb.WithDescription(description)
        eb.WithColor(Color.Gold)
        eb.WithImageUrl(imagelink)
        Dim channelamounts = 0
        Dim guildamount = 0
        For Each guild In discordEv.Guilds
            Dim channels = guild.Channels.Where(Function(x) Not (TypeOf x Is ICategoryChannel Or TypeOf x Is IVoiceChannel))
            For Each channel As ISocketMessageChannel In channels.ToList
                If channel.Name Is Nothing Then
                    Continue For
                End If
                If channel.Name.ToString.ToLower.Contains("pepsi") Then
                    Await channel.SendMessageAsync("", False, eb.Build)
                    channelamounts += 1
                    System.Threading.Thread.Sleep(200)
                End If
            Next
            guildamount += 1
        Next
        Await message.Channel.SendMessageAsync("Successfully sent the picture globally to **" & channelamounts & "** channels (" & guildamount & " guilds)")
    End Sub
End Module
