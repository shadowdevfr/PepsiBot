Imports Discord
Module command_leaderboard
    Async Sub run(message As IMessage)
        Dim guild As IGuildChannel = message.Channel
        Dim eb As EmbedBuilder = New EmbedBuilder
        eb.WithTitle("Cat XP leaderboard in " & guild.Name)
        eb.WithColor(Color.Gold)
        Dim description As String = "This is the leaderboard of people with the biggest amount of cat XP in " & guild.Name & vbCrLf
        Dim gusersarray() As String = redis.getArray("Guilds_" & guild.Id & "_Users")
        Dim usersByXp As New List(Of String)
        Dim leaderboard As New List(Of LeaderboardHandler)
        For Each user In gusersarray
            Dim username As String = redis.getValue("Users_" & user & "_username")
            Dim XP As String = redis.getValue("Guilds_" & guild.Id & "_Users_" & user & "_XP")
            leaderboard.Add(New LeaderboardHandler(username, XP))
        Next
        leaderboard.Sort(Function(x, y) y.score.CompareTo(x.score))
        Dim i As Integer = 0
        For Each user In leaderboard
            i += 1
            If i >= 10 Then
                Exit For
            End If
            description = description & leaderboard.IndexOf(user) + 1 & ". **" & user.username & "** - " & user.score & " cat XP." & vbCrLf

        Next

        eb.WithDescription(description)


        Await message.Channel.SendMessageAsync("", False, eb.Build)
    End Sub
End Module
