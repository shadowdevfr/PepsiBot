Imports StackExchange.Redis

Module redis
    Public redis As ConnectionMultiplexer = ConnectionMultiplexer.Connect(config.redisIP & ",password=" & config.redisPass)
    Public db As IDatabase = redis.GetDatabase()

    Public Sub setValue(tag As String, value As String)
        db.StringSet(tag, value)
    End Sub

    Public Function getValue(tag As String) As String
        Return db.StringGet(tag)
    End Function

    Public Sub addValueToArray(tag As String, value As String)
        Dim source As String = db.StringGet(tag)
        Dim result As String
        If source = "" Then
            result = value
        Else
            result = source & "," & value
        End If

        db.StringSet(tag, result)
    End Sub

    Public Function getArray(tag As String) As Array
        Dim source As String = db.StringGet(tag)
        Dim result() As String = Split(source, ",")
        Return result
    End Function

    Public Function checkConnection() As Boolean
        Try
            db.StringGet("test")
            Return redis.IsConnected
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module
