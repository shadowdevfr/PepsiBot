Imports Discord
Module levelingChat
    Public Sub handleLeveling(message As IMessage)
        ' store new xp
        Dim curlvl = twdb.getValue(message.Author.Id & "_XP")
        twdb.storeValue(message.Author.Id & "_XP", curlvl + multiplier)

    End Sub
End Module
