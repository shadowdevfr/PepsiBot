Imports Discord
Module levelingChat
    Public Sub handleLeveling(message As IMessage)
        ' store GLOBAL xp
        Dim curlvl = twdb.getValue(message.Author.Id & "_XP")
        If curlvl = "NOT_FOUND" Then
            curlvl = 0
        End If
        twdb.storeValue(message.Author.Id & "_XP", curlvl + config.pointsMultiplier)

        ' store GLOBAL xp
        Dim guild As IGuildChannel = message.Channel
        curlvl = twdb.getValue(message.Author.Id & "_" & guild.Id & "_XP")
        If curlvl = "NOT_FOUND" Then
            curlvl = 0
        End If
        twdb.storeValue(message.Author.Id & "_" & guild.Id & "_XP", curlvl + config.pointsMultiplier)
    End Sub
End Module
