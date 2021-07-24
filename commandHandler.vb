Imports Discord
Module commandHandler
    Public Async Function handle(message As IMessage) As Task
        Dim args() As String = message.Content.Split(" ")

        If args(0) = "$cat" Then
            command_cat.run(message)
        End If
        If args(0) = "$ec" Then
            For Each guild In discordEv.Guilds
                Dim channels = guild.Channels.Where(Function(x) Not (TypeOf x Is ICategoryChannel Or TypeOf x Is IVoiceChannel))

                For Each channel In channels.ToList
                    If channel.Name Is Nothing Then
                        Console.WriteLine("channel nothing")
                        Continue For
                    End If
                    If channel.Name.ToString.ToLower.Contains("pepsi") Then
                        Console.WriteLine("[" & channel.Guild.Name & "] #" & channel.Name.ToString)
                    Else
                        'Console.WriteLine(channel.Name.ToString.ToLower)
                    End If
                    'System.Threading.Thread.Sleep(200)
                Next
                Console.WriteLine("[Guild] Checking for guild " & guild.Name)
                System.Threading.Thread.Sleep(1000)
            Next
        End If
    End Function
End Module
