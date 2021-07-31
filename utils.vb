Module utils
    Public Function secondsToReadable(seconds As Double)
        Dim iSpan As TimeSpan = TimeSpan.FromSeconds(seconds)

        Return iSpan.Hours.ToString.PadLeft(2, "0"c) & " hours, " &
                                iSpan.Minutes.ToString.PadLeft(2, "0"c) & " minutes and " &
                                iSpan.Seconds.ToString.PadLeft(2, "0"c) & " seconds"
    End Function
End Module
