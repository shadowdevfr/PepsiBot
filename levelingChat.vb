Imports Discord
Module levelingChat
    Public Sub handleLeveling(message As IMessage)
        Try
            ' register some user info
            redis.setValue("Users_" & message.Author.Id & "_username", message.Author.Username & "#" & message.Author.Discriminator)

            ' register user for leaderboard
            Dim usersArray() As String = redis.getArray("Users_array")
            If Not usersArray.Contains(message.Author.Id) Then
                redis.addValueToArray("Users_array", message.Author.Id)
            End If

            Dim guild As IGuildChannel = message.Channel
            ' register user for GUILD leaderboard
            Dim gusersArray() As String = redis.getArray("Guilds_" & guild.Id & "_Users")
            If Not gusersArray.Contains(message.Author.Id) Then
                redis.addValueToArray("Guilds_" & guild.Id & "_Users", message.Author.Id)
            End If

            ' store GLOBAL xp
            Dim curlvl = redis.getValue("Users_" & message.Author.Id & "_XP")
            If curlvl = Nothing Then
                curlvl = 0
            End If
            redis.setValue("Users_" & message.Author.Id & "_XP", Math.Round(CDec(curlvl + config.pointsMultiplier), 2))

            ' store GUILD xp
            curlvl = redis.getValue("Guilds_" & guild.Id & "_Users_" & message.Author.Id & "_XP")
            If curlvl = Nothing Then
                curlvl = 0
            End If
            redis.setValue("Guilds_" & guild.Id & "_Users_" & message.Author.Id & "_XP", Math.Round(CDec(curlvl + config.pointsMultiplier), 2))

            ' store GLOBAL GUILD xp
            curlvl = redis.getValue("Guilds_" & guild.Id & "_XPGLOBAL")
            If curlvl = Nothing Then
                curlvl = 0
            End If
            redis.setValue("Guilds_" & guild.Id & "_XPGLOBAL", curlvl + Math.Round(CDec(curlvl + config.pointsMultiplier), 2))
        Catch ex As Exception

        End Try
    End Sub
End Module
