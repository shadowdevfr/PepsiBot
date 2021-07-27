Public Class itemClass
    Public name As String
    Public price As String
    Public description As String
    Public buyable As String

    Public Sub New(ByVal name As String, price As String, description As String, Optional buyable As Boolean = True)
        Me.name = name
        Me.price = price
        Me.description = description
        Me.buyable = buyable
    End Sub
End Class