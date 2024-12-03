Module Module1
    Public random As New Random()
    Const pi As Double = 3.1415926
    Dim min As Integer = 0
    Dim max As Integer = 64
    Dim trn(2, max) As Integer

    Dim Outp(max, max) As Byte
    Dim out(max * max) As Byte
    Dim i1 As Integer
    Dim i2 As Integer
    Dim i3 As Integer
    Dim j1 As Integer
    Dim j2 As Integer
    Dim j3 As Integer



    Sub Main()
        Dim imgcnt As Integer = 0
        Do Until imgcnt = 1000
            Dim c As Boolean = False
            Do Until c = True
                i1 = random.Next(min, max + 1)
                i2 = random.Next(min, max + 1)
                i3 = random.Next(min, max + 1)
                j1 = random.Next(min, max + 1)
                j2 = random.Next(min, max + 1)
                j3 = random.Next(min, max + 1)

                If i1 < i2 And (i2 - i1) > 2 Then
                    If j1 < j2 And (j2 - j1) > 2 Then
                        c = True
                    End If
                End If

            Loop
            c = False
            'Do Until c = True
            'i1 = random.Next(min + 1, max + 1)
            'j1 = random.Next(min + 1, max + 1)
            'i2 = random.Next(min, max - 2)

            'If i1 + i2 <= max And i1 - i2 >= min Then
            'If j1 + i2 <= max And j1 - i2 >= min Then
            'If i2 > 2 Then
            ' c = True
            'End If
            'End If
            'End If

            'Loop
            'drwsqr(i1, j1, i2, j2)
            drwtrn(i1, j1, i2, j2, i3, j3)
            'drwcircle(i1, j1, j1, i1, i2)

            'fillin("c")
            setout()
            'printout()

            Dim x() As Byte
            x = My.Computer.FileSystem.ReadAllBytes("C:\Users\Dulara Rupasinghe\Desktop\out\tmp.bmp")
            Dim i As Integer = 0
            Dim a As Integer = 0
            i = x.Length - (max * max)
            Do Until i = x.Length
                x(i) = Val(out(a))
                i += 1
                a += 1
            Loop
            If My.Computer.FileSystem.FileExists("C:\Users\Dulara Rupasinghe\Desktop\out\" & imgcnt & ".bmp") Then
                My.Computer.FileSystem.DeleteFile("C:\Users\Dulara Rupasinghe\Desktop\out\" & imgcnt & ".bmp")
            End If

            My.Computer.FileSystem.WriteAllBytes("C:\Users\Dulara Rupasinghe\Desktop\out\" & imgcnt & ".bmp", x, True)
            imgcnt += 1

            i = 0
            a = 0
            Do Until i = max + 1
                Do Until a = max + 1
                    Outp(a, i) = 0
                    a += 1
                Loop
                a = 0
                i += 1
            Loop
            'Console.WriteLine(imgcnt)
        Loop
        Console.ReadLine()

    End Sub

    Sub drwsqr(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
        Console.WriteLine("(" & x1 & "," & y1 & ")")
        Console.WriteLine("(" & x2 & "," & y2 & ")")
        Dim r As Integer = 0
        Dim c As Integer = 0

        Do Until r = max + 1
            Do Until c = max + 1
                If r >= y1 And r <= y2 Then
                    If c >= x1 And c <= x2 Then
                        Outp(c, r) = 1
                    Else
                        Outp(c, r) = 0
                    End If
                Else
                    Outp(c, r) = 0
                End If
                c += 1
            Loop
            c = 0
            r += 1
        Loop

    End Sub
    Sub drwtrn(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal x3 As Integer, ByVal y3 As Integer)
        Dim p1 As Double
        Dim p2 As Double
        Dim p3 As Double

        Dim up As Integer = 0
        Dim dwn As Integer = 0
        Dim ri As Integer = 0
        Dim ls As Integer = 0

        Dim i As Integer = 0

        If y1 < y2 Then
            If y1 > y3 Then
                up = x1
                dwn = y1
                x1 = x3
                y1 = y3
                x3 = up
                y3 = dwn
            End If
        ElseIf y2 < y3 Then
            If y1 > y2 Then
                up = x1
                dwn = y1
                x1 = x2
                y1 = y2
                x2 = up
                y2 = dwn
            End If
        End If

        i = y1


        Do Until i = max + 1

            p1 = (((y2 - y1) / (x2 - x1)) * (i - x1)) + y1
            p2 = (((y3 - y2) / (x3 - x2)) * (i - x2)) + y2
            p3 = (((y1 - y3) / (x1 - x3)) * (i - x3)) + y3

            If ((y2 - y1) / (x2 - x1)) = 5 / 0 Then
                p1 = -1
            ElseIf ((y3 - y2) / (x3 - x2)) = 5 / 0 Then
                p2 = -1
            ElseIf ((y1 - y3) / (x1 - x3)) = 5 / 0 Then
                p3 = -1
            End If

            If p1 >= 0 And p1 <= max Then
                p1 = Convert.ToInt32(p1)
                Outp(i, p1) = 1
            End If
            If p2 >= 0 And p2 <= max Then
                p2 = Convert.ToInt32(p2)
                Outp(i, p2) = 1
            End If
            If p3 >= 0 And p3 <= max Then
                p3 = Convert.ToInt32(p3)
                Outp(i, p3) = 1
            End If

            p1 = (((x2 - x1) / (y2 - y1)) * (i - y1)) + x1
            p2 = (((x3 - x2) / (y3 - y2)) * (i - y2)) + x2
            p3 = (((x1 - x3) / (y1 - y3)) * (i - y3)) + x3

            If ((x2 - x1) / (y2 - y1)) = 5 / 0 Then
                p1 = -1
            ElseIf ((x3 - x2) / (y3 - y2)) = 5 / 0 Then
                p2 = -1
            ElseIf ((x1 - x3) / (y1 - y3)) = 5 / 0 Then
                p3 = -1
            End If


            If p1 >= 0 And p1 <= max Then
                p1 = Convert.ToInt32(p1)
                Outp(p1, i) = 1
            End If
            If p2 >= 0 And p2 <= max Then
                p2 = Convert.ToInt32(p2)
                Outp(p2, i) = 1
            End If
            If p3 >= 0 And p3 <= max Then
                p3 = Convert.ToInt32(p3)
                Outp(p3, i) = 1
            End If

            i += 1
        Loop

    End Sub

    Sub drwcircle(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal r As Integer)
        Dim i As Integer = 0
        Dim angle As Double
        angle = (y2 - y1) / (x2 - x1)
        Dim x As Integer = 0
        Dim y As Integer = 0
        Console.WriteLine()
        If angle > 1 Then

        ElseIf angle <= 1 And angle >= 0 Then

        ElseIf angle < 0 And angle >= -1 Then

        Else

        End If

        'y = (((y2 - y1) / (x2 - x1)) * (i - x1)) + y1

        Dim p1 As Integer = 0
        Dim p2 As Integer = 0
        Do Until i = 91
            p1 = Convert.ToInt32((r * Math.Cos(2 * i * pi / 360)) + x1)
            p2 = Convert.ToInt32((r * Math.Sin(2 * i * pi / 360)) + y1)
            If p1 >= 0 And p1 <= max Then
                If p2 >= 0 And p2 <= max Then
                    Outp(p1, p2) = 1
                    If r >= 60 Then
                        Try
                            Outp(p1 + 1, p2 - 1) = 1
                        Catch ex As Exception

                        End Try
                    End If
                End If
            End If
            i += 1
        Loop

        Do Until i = 181
            p1 = Convert.ToInt32((r * Math.Cos(2 * i * pi / 360)) + x1)
            p2 = Convert.ToInt32((r * Math.Sin(2 * i * pi / 360)) + y1)
            If p1 >= 0 And p1 <= max Then
                If p2 >= 0 And p2 <= max Then
                    Outp(p1, p2) = 1
                    If r >= 60 Then
                        Try
                            Outp(p1 + 1, p2 + 1) = 1
                        Catch ex As Exception

                        End Try
                    End If
                End If
            End If
            i += 1
        Loop

        Do Until i = 271
            p1 = Convert.ToInt32((r * Math.Cos(2 * i * pi / 360)) + x1)
            p2 = Convert.ToInt32((r * Math.Sin(2 * i * pi / 360)) + y1)
            If p1 >= 0 And p1 <= max Then
                If p2 >= 0 And p2 <= max Then
                    Outp(p1, p2) = 1
                    If r >= 60 Then
                        Try
                            Outp(p1 - 1, p2 + 1) = 1
                        Catch ex As Exception

                        End Try

                    End If
                End If
            End If
            i += 1
        Loop

        Do Until i = 361
            p1 = Convert.ToInt32((r * Math.Cos(2 * i * pi / 360)) + x1)
            p2 = Convert.ToInt32((r * Math.Sin(2 * i * pi / 360)) + y1)
            If p1 >= 0 And p1 <= max Then
                If p2 >= 0 And p2 <= max Then
                    Outp(p1, p2) = 1
                    If r >= 60 Then
                        Try
                            Outp(p1 + 1, p2 + 1) = 1
                        Catch ex As Exception

                        End Try
                    End If
                End If

            End If
            i += 1
        Loop
    End Sub

    Sub fillin(ByVal type As Char)
        Dim i As Integer = 0
        Dim c As Integer = 0
        Dim x As Integer = 0
        Dim cnt As Integer = 0
        Dim cnttmp As Integer = 0
        Dim isOK As Boolean = False

        If type = "c" Then
            Do Until i = max + 1
                c = 0
                Do Until c = max + 1
                    If Outp(c, i) = 1 Then

                        If isOK = True Then
                            cnttmp += 1
                            If cnttmp = cnt Then
                                isOK = False
                            End If
                        Else
                            x = c + 1
                            Do Until x = max + 1
                                If Outp(x, i) = 1 Then
                                    cnt += 1
                                End If
                                x += 1
                            Loop

                            If cnt > 0 Then
                                isOK = True
                            End If

                        End If
                    Else
                        If isOK = True Then
                            Outp(c, i) = 1
                        End If
                    End If

                    c += 1
                Loop
                i += 1
            Loop
        ElseIf type = "t" Then

        End If

    End Sub
    Sub printout()
        Dim i As Integer = 0
        Dim j As Integer = 0
        Do Until i = max + 1
            Do Until j = max
                If Outp(j, i) = 0 Then
                    Console.ForegroundColor = ConsoleColor.White
                    Console.Write("██")
                Else
                    Console.ForegroundColor = ConsoleColor.Black
                    Console.Write("██")
                End If
                j += 1
            Loop
            If Outp(j, i) = 0 Then
                Console.ForegroundColor = ConsoleColor.White
                Console.WriteLine("██")
            Else
                Console.ForegroundColor = ConsoleColor.Black
                Console.WriteLine("██")
            End If
            j = 0
            i += 1
        Loop
    End Sub
    Sub setout()
        Dim i As Integer = 0
        Dim c As Integer = 0

        Do Until i = max
            Do Until c = max
                out((max * max) - (c + (i * max))) = Outp(c, i) * 255
                'Console.WriteLine(c + (i * max))
                c += 1
            Loop
            c = 0
            i += 1
        Loop
    End Sub
    Function inRange(ByVal val As Integer, ByVal low As Integer, ByVal high As Integer) As Integer
        Do Until val >= low And val <= high
            If val < low Then
                val = val + (high - low + 1)
            ElseIf val > high Then
                val = val - (high - low + 1)
            End If
        Loop
        Return val
    End Function
    Function getmax(ByVal n1, ByVal n2, ByVal n3)
        If n1 > n2 Then
            If n3 > n1 Then
                Return n3
            Else
                Return n1
            End If
        Else
            If n3 > n2 Then
                Return n3
            Else
                Return n2
            End If
        End If
    End Function
End Module
