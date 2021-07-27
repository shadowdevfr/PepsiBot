Imports Discord
Module command_level
    Async Sub run(message As IMessage, Optional userid As String = "no")
        Try

            Dim userToSee = message.Author.Id
            If Not userid = "no" Then
                userToSee = userid
            End If

            Dim eb As EmbedBuilder = New EmbedBuilder
            Dim description As String = "__**Global user info**__" & vbCrLf
            Dim curlvl = redis.getValue("Users_" & userToSee & "_XP")
            If curlvl Is Nothing Then
                curlvl = New Integer
                curlvl = 0.15
            End If
            description = description & "> You have **" & curlvl & "** cat XP around all servers." & vbCrLf
            Dim curcoins = redis.getValue("Users_" & userToSee & "_coins")
            If curcoins Is Nothing Then
                curcoins = New Integer
                curcoins = 0
            End If
            description = description & "> You have **" & curcoins & "**:cat2: cattos." & vbCrLf & vbCrLf
            Dim guild As IGuildChannel = message.Channel
            description = description & "__**Local info**__" & vbCrLf
            Dim lcurlvl = redis.getValue("Guilds_" & guild.Id & "_Users_" & userToSee & "_XP")
            If lcurlvl Is Nothing Then
                lcurlvl = New Integer
                lcurlvl = 0.15
            End If
            description = description & "> You have **" & curlvl & "** cat XP on this server." & vbCrLf
            eb.WithTitle("Stats of " & redis.getValue("Users_" & userToSee & "_username"))
            eb.WithDescription(description)
            eb.WithColor(Color.Gold)

            Await message.Channel.SendMessageAsync("", False, eb.Build)
        Catch ex As Exception

        End Try
    End Sub
End Module
