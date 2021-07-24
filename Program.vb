Imports System
Imports System.ComponentModel

Imports Discord
Imports Discord.WebSocket
Imports Discord.Audio

Module Program
    Public WithEvents discordEv As New DiscordSocketClient

    Private Async Function Connect(tt As TokenType, tstr As String) As Task
        Await discordEv.LoginAsync(tt, tstr)
        Await discordEv.StartAsync()
        Await Task.Delay(-1)
    End Function

    Sub Main(args As String())
        ' declare events
        AddHandler discordEv.Ready, AddressOf onReady
        AddHandler discordEv.MessageReceived, AddressOf onMessage
        AddHandler discordEv.MessageUpdated, AddressOf onMessageUpdate
        AddHandler discordEv.ReactionAdded, AddressOf reactionAdded
        ' Connect Discord
        Try
            Connect(TokenType.Bot, config.botToken)
            discordEv.StartAsync()
            Console.WriteLine("[bot] Logging in...")
        Catch ex As Exception
            Console.WriteLine("[ERROR] " & ex.Message)
        End Try

        Console.ReadLine()

    End Sub
    Private Delegate Sub mUpdateCaption(ByVal sCaption As String)
    Private Sub UpdateCaption(ByVal sCaption As String)
        Console.WriteLine("[INFO] " & sCaption)
    End Sub

    Private Function onReady() As Task
        UpdateCaption("Logged on as: " + discordEv.CurrentUser.Username) 'LoggedIn event still dosent capture CurrentUser info, so stuck with this.
        statusClock.updateStatus()
        statusClock.startStatusClock()
        timeCheckClock.startClock()

        Return Task.CompletedTask
    End Function

    Private Async Function onMessage(message As SocketMessage) As Task
        Dim msguild As SocketGuildChannel = message.Channel
        If message.Author.Id = discordEv.CurrentUser.Id Then 'Check if self message

        Else
            commandHandler.handle(message)
            levelingChat.handleLeveling(message)
        End If
    End Function

    Private Async Function onMessageUpdate(ByVal before As Cacheable(Of IMessage, ULong), ByVal after As SocketMessage, ByVal channel As ISocketMessageChannel) As Task

    End Function

    Private Async Function reactionAdded(ByVal message As Cacheable(Of IUserMessage, UInt64), ByVal channel As ISocketMessageChannel, ByVal reaction As SocketReaction) As Task
        ' HANDLE REACTION

    End Function


End Module
