Imports System.Web
Imports Discord
Module command_doggo
    Async Sub run(message As IMessage, memberToTest As String)
        Dim mguild As IGuildChannel = message.Channel
        Dim user As IGuildUser
        Try
            user = mguild.Guild.GetUserAsync(memberToTest).Result
        Catch ex As Exception
            message.Channel.SendMessageAsync("No user found.")
            Exit Sub
        End Try
        Dim eb As EmbedBuilder = New EmbedBuilder
        eb.WithTitle("Sussy baka")
        eb.WithColor(Color.Gold)
        Console.WriteLine(message.Author.GetAvatarUrl(ImageFormat.Auto, 1024))
        Dim avatarEncoded = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(user.GetAvatarUrl(ImageFormat.Auto, 1024)))
        Dim img1 As String = "https://bot.shadowcat.club/api/image-based/style-doggo.php?avatar=" & avatarEncoded & "&username=" & user.Username & "&discrim=" & user.Discriminator
        Dim vOut() As Byte = System.Text.Encoding.UTF8.GetBytes(img1)
        Dim b64encoded As String = System.Convert.ToBase64String(vOut)
        Dim r = New System.Net.WebClient().DownloadString("https://bot.shadowcat.club/api/image-based/image.php?url=" & b64encoded)
        eb.WithImageUrl(r)
        Await message.Channel.SendMessageAsync("", False, eb.Build)
    End Sub
End Module
