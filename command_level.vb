Imports Discord
Module command_level
    Async Sub run(message As IMessage)
        Dim eb As EmbedBuilder = New EmbedBuilder
        Dim description As String = "__**Global XP**__" & vbCrLf
        Dim curlvl = twdb.getValue(message.Author.Id & "_XP")
        If curlvl.Contains("NOT_FOUND") Then
            curlvl = New Integer
            curlvl = 0.15
        End If
        description = description & "> You have :cat2: " & Math.Round(CDec(curlvl), 2) & " cattos around all servers." & vbCrLf & vbCrLf
        Dim guild As IGuildChannel = message.Channel
        description = description & "__**Local XP**__" & vbCrLf
        Dim lcurlvl = twdb.getValue(message.Author.Id & "_" & guild.Id & "_XP")
        If lcurlvl.Contains("NOT_FOUND") Then
            lcurlvl = New Integer
            lcurlvl = 0.15
        End If
        description = description & "> You have :cat2: " & Math.Round(CDec(lcurlvl), 2) & " cattos on this server." & vbCrLf
        eb.WithTitle("Progress")
        eb.WithDescription(description)
        eb.WithColor(Color.Gold)

        Await message.Channel.SendMessageAsync("", False, eb.Build)
    End Sub
End Module
