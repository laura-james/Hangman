Public Class Form1
    Dim wordlist() As String = {"apple", "dinosaur", "banana", "guitar"}

    Dim random As Integer
    Dim word As String
    Dim attempts As Integer = 0
    Dim incorrectguesses As New List(Of String)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim letterfound As Boolean = False
        Dim letterguess As String = TextBox1.Text
        Dim lastguessedword() = Label1.Text.ToCharArray()
        For i = 0 To Len(word) - 1
            If letterguess = word(i) Then
                letterfound = True
                lastguessedword(i) = letterguess
            End If
        Next
        Label1.Text = New String(lastguessedword)
        If letterfound Then
            Label4.Text = "letter " & letterguess & " found in word"
        Else
            Label4.Text = "letter " & letterguess & " NOT found in word"
            attempts = attempts + 1
            Label2.Text = attempts
            incorrectguesses.Add(letterguess)
            For i = 0 To incorrectguesses.Count - 1
                Label3.Text = Label3.Text & " " & incorrectguesses(i)
            Next
        End If
        If attempts > 4 Then
            Label4.Text = "Game over! The word was " & word
            Me.BackColor = Color.Red
        End If
        If Label1.Text = word Then
            Label4.Text = "Congratulations! The word was " & word
            Me.BackColor = Color.Green
            pickword()
        End If
        TextBox1.Text = ""
    End Sub
    Private Sub pickword()
        Randomize()
        random = CInt(Rnd() * wordlist.Length)
        word = wordlist(random)
        Label1.Text = New String("-", Len(word))
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pickword()

    End Sub
End Class
