Imports Discord
Imports Discord.WebSocket
Module command_eligible
    Async Sub run(message As IMessage)
        Dim eb As EmbedBuilder = New EmbedBuilder
        Dim chgui As IGuildChannel = message.Channel
        Dim guild As SocketGuild = discordEv.GetGuild(chgui.Guild.Id)
        Dim channels = guild.Channels.Where(Function(x) Not (TypeOf x Is ICategoryChannel Or TypeOf x Is IVoiceChannel))
        Dim description = ""

        For Each channel In channels.ToList
            If channel.Name Is Nothing Then
                Continue For
            End If
            If channel.Name.ToString.ToLower.Contains("pepsi") Then
                description = description & "<#" & channel.Id & "> is eligible for daily pepsi pictures in this guild." & vbCrLf
            End If
            'System.Threading.Thread.Sleep(200)
        Next
        If description = "" Then
            description = "No channels are eligible for daily pepsi pictures, please create a channel that contains the word ""pepsi"" in it. The name can be either #pepsi-pics, #pog-pepsi-pics or just #pepsi. It can be bascially anything as long as it got the word pepsi in it's name."
        End If
        eb.WithTitle("Eligible channels for daily pepsi pictures")
        eb.WithColor(Color.Gold)
        eb.WithDescription(description)

        Await message.Channel.SendMessageAsync("", False, eb.Build)
    End Sub
End Module
