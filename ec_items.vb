Module ec_items
    Public items = New List(Of itemClass)

    Public Sub init()
        items.Add(New itemClass("ax41-nvme", "100", "So you can flex your dedi and start a new host"))
        items.Add(New itemClass("Yet another badsk host", "20", "No data leaks this time I- I s- swear"))
        items.Add(New itemClass("Kitten", "200", "Aw so cute"))
        items.Add(New itemClass("Cat", "300", "Aw so cute :3"))
        items.Add(New itemClass("100mbps gamer internet :sunglasses:", "300", "Not flexing, just showing!"))
        items.Add(New itemClass("1gbps gamer internet :sunglasses:", "600", "Dang, my internet is so slow today"))
        items.Add(New itemClass("3tbps ddos protection", "700", "Ddos 127.0.0.1 kid "))
        items.Add(New itemClass("OVH strasbourg 2 (burned)", "400", "With water cooling from firefighters!"))
        items.Add(New itemClass("Goose", "250", "honk honk honk honk honk honk"))
        items.Add(New itemClass("Pepsi cam", "1000000", "for 1 min call"))
    End Sub
End Module
