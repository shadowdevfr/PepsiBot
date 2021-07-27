Public Class LeaderboardHandler
    Public username As String
    Public score As String

    Public Sub New(ByVal name As String, ByVal score As String)
        Me.username = name
        Me.score = score
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0}, {1}", Me.username, Me.score)
    End Function
End Class