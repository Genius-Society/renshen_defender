Module MazeUpper
    Public Function TopLimit(ByVal s As String) As Integer
        Select Case s
            Case "砂上の空中庭園"
                Return 12
            Case "大国主の書棚"
                Return 16
            Case "虹の橋の袂1周目"
                Return 31
            Case "虹の橋の袂2周目"
                Return 41
            Case "孤高の挑戦者", "雲上の摩天楼", "天壌無窮の夢幻回廊", "ちょっと孤高の挑戦者", "クライマーズ・ハイ", "旅は道連れ", "異世界のキャラバン"
                Return 99
            Case "早苗と天子の真剣遊戯", "腸の迷い路", "電脳神社の地下室"
                Return 10
            Case "電脳世界に宝の浪曼を見た"
                Return 1
            Case "紡げ、ｵｰﾙﾌﾟﾚｲﾔｰ大決戦!!", "地下室の先には……", "宴会デリバリー"
                Return 50
            Case "みら超ボンバープラス!!"
                Return 11
            Case "電脳少女の試練"
                Return 60
            Case "道は自分で切り開け!!"
                Return 20
            Case "夢幻泡沫1周目"
                Return 999
            Case "夢幻泡沫2周目"
                Return 10000
            Case "長城制覇", "オールプレイヤー2!極大決戦!"
                Return 100

            Case "仮初の非武装地帯", "太陽の祭壇"
                Return 5
            Case "古の城塞都市"
                Return 7
            Case "天上へ至る道程"
                Return 50
            Case "河童の試験遊戯"
                Return 21
            Case "八坂神奈子の徹ゲー遊戯"
                Return 15

            Case Else
                Return 0
        End Select

    End Function

    Private Function GaussBubble1(x As Decimal) As Integer

        Select Case CInt(x)
            Case Is < 2
                Return 1
            Case Is < 981
                Return 20 * CInt(Val(x) / 20.0) + 20 * Phi(Val(x) / 20.0 > Val(CInt(Val(x) / 20.0)))
            Case Else
                Return 999
        End Select

    End Function


    Private Function GaussBubble2(x As Decimal) As Integer

        Select Case CInt(x)
            Case Is < 1002
                Return 1001
            Case Is < 9981
                Return 20 * CInt(Val(x) / 20.0) + 20 * Phi(Val(x) / 20.0 > Val(CInt(Val(x) / 20.0)))
            Case Else
                Return 10000
        End Select 
    End Function


    Private Function GaussGreatWall(x As Decimal) As Integer
        Select Case CInt(x)
            Case Is < 21
                Return 20
            Case Is < 36
                Return 35
            Case Is < 51
                Return 50
            Case Is < 66
                Return 65
            Case Is < 81
                Return 80
            Case Is < 91
                Return 90
            Case Is < 100
                Return 99
            Case Else
                Return 100
        End Select
    End Function

    Private Function phiGreatWall(x As Decimal) As Integer
        Select Case Val(x)
            Case Is < 27.5
                Return 20
            Case Is < 42.5
                Return 35
            Case Is < 57.5
                Return 50
            Case Is < 72.5
                Return 65
            Case Is < 85
                Return 80
            Case Is < 94.5
                Return 90
            Case Is < 99.5
                Return 99
            Case Else
                Return 100
        End Select
    End Function

    Private Function stepGreatWall(x As Decimal) As Integer
        Return 8 * Phi(Val(x) < 99.5) + Phi(Val(x) > 99.5)
    End Function

    Private Function phiBubble1(x As Decimal) As Integer
        Select Case CInt(x)
            Case Is < 2
                Return 1
            Case Is < 982
                Return 20 * CInt(Val(x) / 20.0)
            Case Else
                Return 999
        End Select
    End Function

    Private Function phiBubble2(x As Decimal) As Integer
        Select Case CInt(x)
            Case Is < 1002
                Return 1001
            Case Else
                Return 20 * CInt(Val(x) / 20.0)
        End Select
    End Function


    Public Function REnabled(mn As String) As Boolean
        Return (mn = "夢幻泡沫" Or mn = "長城制覇")
    End Function

    Public Function RMin(mn As String, sv As Decimal, Optional week As Integer = -1) As Decimal 
        Return CDec(GaussGreatWall(sv) * Phi(mn = "長城制覇") + (GaussBubble1(sv) * Phi(week = 0) + GaussBubble2(sv) * Phi(week = 1)) * Phi(mn = "夢幻泡沫"))
    End Function

    Public Function RStep(mn As String, rv As Decimal) As Decimal
        Return CDec(stepGreatWall(rv) * Phi(mn = "長城制覇") + 20 * Phi(mn = "夢幻泡沫"))
    End Function

    Public Function RValue(mn As String, rv As Decimal, Optional week As Integer = -1) As Decimal
        Return CDec(phiGreatWall(rv) * Phi(mn = "長城制覇") + (phiBubble1(rv) * Phi(week = 0) + phiBubble2(rv) * Phi(week = 1)) * Phi(mn = "夢幻泡沫"))
    End Function

    Public Function WEnabled(mn As String) As Boolean
        Return (mn = "夢幻泡沫" Or mn = "虹の橋の袂")
    End Function

    Public Function SEnabled(mn As String) As Boolean
        Return Not (mn = "仮初の非武装地帯" Or mn = "太陽の祭壇" Or mn = "古の城塞都市" Or mn = "天上へ至る道程" Or mn = "河童の試験遊戯" Or mn = "八坂神奈子の徹ゲー遊戯")
    End Function

    Public Function SMin(mn As String, Optional week As Integer = -1) As Decimal
        Return CDec(1000 * Phi(week = 1 And mn = "夢幻泡沫"))
    End Function

    Public Sub AdjNumRange(num As Object)
        If TypeName(num) = "NumericUpDown" Then
            If num.Value < num.Minimum Then num.Value = num.Minimum
            If num.Value > num.Maximum Then num.Value = num.Maximum
        End If
    End Sub

End Module
