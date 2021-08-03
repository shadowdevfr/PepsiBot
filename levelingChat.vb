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
            Dim gusersArray() As String = redis.getArray("Guilds_" & guild.Guild.Id & "_Users")
            If Not gusersArray.Contains(message.Author.Id) Then
                redis.addValueToArray("Guilds_" & guild.Guild.Id & "_Users", message.Author.Id)
            End If

            ' store GLOBAL user xp
            Dim curlvl = redis.getValue("Users_" & message.Author.Id & "_XP")
            If curlvl = Nothing Then
                curlvl = 0
            End If
            redis.setValue("Users_" & message.Author.Id & "_XP", Math.Round(CDbl(curlvl + config.pointsMultiplier), 2))

            Dim curobj = redis.getValue("Users_" & message.Author.Id & "_objective")
            If curobj = Nothing Then
                curobj = 20
            End If
            Dim percentage = Math.Round((100 * curlvl) / curobj, 1)
            If percentage >= 100 Then
                ' objective done
                Dim curcoins = redis.getValue("Users_" & message.Author.Id & "_coins")
                redis.setValue("Users_" & message.Author.Id & "_coins", Math.Ceiling(curcoins + (curobj * 0.1)))
                redis.setValue("Users_" & message.Author.Id & "_objective", Math.Round(CDbl(curobj + 50), 2))
            End If


            ' store GUILD user xp
            curlvl = redis.getValue("Guilds_" & guild.Guild.Id & "_Users_" & message.Author.Id & "_XP")
            If curlvl = Nothing Then
                curlvl = 0
            End If
            Console.WriteLine("[LVL] Storing lvl for " & message.Author.Id)
            redis.setValue("Guilds_" & guild.Guild.Id & "_Users_" & message.Author.Id & "_XP", Math.Round(CDbl(curlvl + config.pointsMultiplier), 2))
            Console.WriteLine("[LVL] stored lvl for " & message.Author.Id)

            ' store GLOBAL GUILD xp
            curlvl = redis.getValue("Guilds_" & guild.Guild.Id & "_XPGLOBAL")
            If curlvl = Nothing Then
                curlvl = 0
            End If
            redis.setValue("Guilds_" & guild.Guild.Id & "_XPGLOBAL", curlvl + Math.Round(CDbl(curlvl + config.pointsMultiplier), 2))
        Catch ex As Exception
            Console.WriteLine("[E] " & ex.Message & ex.StackTrace)
        End Try
    End Sub
End Module
