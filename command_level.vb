Imports Discord
Module command_level
    Async Sub run(message As IMessage, Optional userid As String = "no")
        Try
            Dim pronom1 = "You have"
            Dim pronom2 = "You are"
            Dim userToSee = message.Author.Id
            If Not userid = "no" Then
                userToSee = userid
                pronom1 = "This user has"
                pronom2 = "This user is"
            End If

            Dim eb As EmbedBuilder = New EmbedBuilder
            Dim description As String
            description = ":warning: XP boost for shadow's birthday (from 0.15 to 0.30!)" & vbCrLf & vbCrLf
            description = "__**Global user info**__" & vbCrLf
            Dim curlvl = redis.getValue("Users_" & userToSee & "_XP")
            If curlvl Is Nothing Then
                curlvl = New Integer
                curlvl = 0.15
            End If
            description = description & "> " & pronom1 & " **" & curlvl & "** cat XP around all servers." & vbCrLf
            Dim curcoins = redis.getValue("Users_" & userToSee & "_coins")
            If curcoins Is Nothing Then
                curcoins = New Integer
                curcoins = 0
            End If
            description = description & "> " & pronom1 & " **" & curcoins & "**:cat2: cattos." & vbCrLf
            If curcoins < 0 Then
                description = description & "> <:warn:869887800210755614> **" & pronom2 & " in debt!!**" & vbCrLf
            End If
            description = description & "> You need **" & redis.getValue("Users_" & message.Author.Id & "_objective") - curlvl & "** cat XP more to earn " & Math.Round((redis.getValue("Users_" & message.Author.Id & "_objective") * 0.8), 2) & " cattos." & vbCrLf
            Dim percentage = Math.Round((100 * curlvl) / redis.getValue("Users_" & message.Author.Id & "_objective"), 1)
            Dim bar = New System.Net.WebClient().DownloadString("https://bot.shadowcat.club/api/bar.php?num=" & percentage)
            description = description & "> [" & bar & "] " & percentage & "%" & vbCrLf & vbCrLf

            Dim guild As IGuildChannel = message.Channel
            description = description & "__**Local info**__" & vbCrLf
            Dim lcurlvl = redis.getValue("Guilds_" & guild.Guild.Id & "_Users_" & userToSee & "_XP")
            If lcurlvl Is Nothing Then
                lcurlvl = New Integer
                lcurlvl = 0.15
            End If
            description = description & "> " & pronom1 & " **" & lcurlvl & "** cat XP on this server." & vbCrLf
            eb.WithTitle("Stats of " & redis.getValue("Users_" & userToSee & "_username"))
            eb.WithDescription(description)
            eb.WithColor(Color.Gold)
            eb.WithThumbnailUrl(message.Author.GetAvatarUrl)

            Await message.Channel.SendMessageAsync("", False, eb.Build)
        Catch ex As Exception
            Console.WriteLine(ex.Message & ex.StackTrace)
        End Try
    End Sub
End Module
