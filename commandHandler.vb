Imports Discord
Module commandHandler
    Public Function handle(message As IMessage) As Task
        Dim args() As String = message.Content.Split(" ")

        If args(0) = "$cat" Then
            Console.WriteLine("[Commands]" & message.Author.Username & "#" & message.Author.Discriminator & " executed command " & args(0))
            Task.Run(Sub() command_cat.run(message))
        End If
        If args(0) = "$eligible" Then
            Console.WriteLine("[Commands]" & message.Author.Username & "#" & message.Author.Discriminator & " executed command " & args(0))
            Task.Run(Sub() command_eligible.run(message))
        End If
        If args(0) = "$level" Or args(0) = "$xp" Or args(0) = "$userinfo" Or args(0) = "$i" Then
            Console.WriteLine("[Commands]" & message.Author.Username & "#" & message.Author.Discriminator & " executed command " & args(0))
            If args.Length > 1 Then
                Task.Run(Sub() command_level.run(message, args(1).Replace("<@", "").Replace("!", "").Replace(">", "")))
            Else
                Task.Run(Sub() command_level.run(message))
            End If

        End If
        If args(0) = "$nextpic" Then
            Console.WriteLine("[Commands]" & message.Author.Username & "#" & message.Author.Discriminator & " executed command " & args(0))
            Task.Run(Sub() command_nextpic.run(message))
        End If
        If args(0) = "$daily" Then
            Console.WriteLine("[Commands]" & message.Author.Username & "#" & message.Author.Discriminator & " executed command " & args(0))
            Task.Run(Sub() command_dailyReward.run(message))
        End If
        If args(0) = "$help" Then
            Console.WriteLine("[Commands]" & message.Author.Username & "#" & message.Author.Discriminator & " executed command " & args(0))
            Task.Run(Sub() command_help.run(message))
        End If
        If args(0) = "$lb" Or args(0) = "$leaderboard" Then
            Console.WriteLine("[Commands]" & message.Author.Username & "#" & message.Author.Discriminator & " executed command " & args(0))
            Task.Run(Sub() command_leaderboard.run(message))
        End If

        ' Economy
        If args(0) = "$shop" Then
            Console.WriteLine("[Commands]" & message.Author.Username & "#" & message.Author.Discriminator & " executed command " & args(0))
            Task.Run(Sub() command_shop.run(message))
        End If
        If args(0) = "$buy" Then
            Console.WriteLine("[Commands]" & message.Author.Username & "#" & message.Author.Discriminator & " executed command " & args(0))
            If args.Length < 1 Then
                message.Channel.SendMessageAsync("You need to put an item ID!")
            Else
                Task.Run(Sub() command_buyitem.run(message, args(1)))
            End If
        End If
        If args(0) = "$gamble" Then
            Console.WriteLine("[Commands]" & message.Author.Username & "#" & message.Author.Discriminator & " executed command " & args(0))
            Task.Run(Sub() command_gamble.run(message))
        End If
        If args(0) = "$inventory" Or args(0) = "$inv" Then
            Console.WriteLine("[Commands]" & message.Author.Username & "#" & message.Author.Discriminator & " executed command " & args(0))
            Task.Run(Sub() command_inventory.run(message))
        End If
        If args(0) = "$rob" Then
            Console.WriteLine("[Commands]" & message.Author.Username & "#" & message.Author.Discriminator & " executed command " & args(0))
            If args.Length < 1 Then
                message.Channel.SendMessageAsync("You need to ping an user!")
            Else
                Task.Run(Sub() command_rob.run(message, args(1).Replace("<@", "").Replace("!", "").Replace(">", "")))
            End If
        End If

        If message.Author.Id = 316818056049590282 Then
            If args(0) = "$addCoins" Then
                If args.Length < 1 Then
                    message.Channel.SendMessageAsync("You need to ping an user!")
                Else
                    Dim userid = args(1).Replace("<@", "").Replace("!", "").Replace(">", "")
                    Dim curcoins = redis.getValue("Users_" & userid & "_coins")
                    redis.setValue("Users_" & userid & "_coins", Math.Round(CDec(curcoins + args(2)), 2))
                    message.Channel.SendMessageAsync("Added coins to this user!")
                End If
            End If
            If args(0) = "$sendExclusivePic" Then
                Dim fulldesc As String = ""
                For Each arg As String In args
                    If arg = args(0) Or arg = args(1) Then
                        Continue For
                    End If
                    fulldesc = fulldesc & arg & " "
                Next
                Task.Run(Sub() command_publishcatpicture.run(message, args(1), fulldesc))
            End If
            If args(0) = "$setDayPic" Then
                Dim today As String = args(1)
                redis.setValue("Pics_dailymanualpic_" & today, args(2))
                message.Channel.SendMessageAsync("The daily pic of day #" & args(1) & " of this month got set to this picture.")
            End If
            If args(0) = "$getDailyPic" Then
                Dim today As String = args(1)
                Dim pic As String = redis.getValue("Pics_dailymanualpic_" & today)
                message.Channel.SendMessageAsync(pic)
            End If
        End If
    End Function
End Module
