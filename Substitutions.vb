Public Class Substitutions
    Dim VientDe As Form1.OrigSubsti
    Dim m, t, ct As Integer
    Dim Acc As String
    Dim Degré As String
    Dim Tonalité As String

    Private Sub Sustitutions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tbl() As String
        If LangueIHM = "fr" Then
            Button2.Text = "Annuler"
        Else
            Button2.Text = "Cancel"
        End If
        Select Case VientDe
            Case Form1.OrigSubsti.Grid2
                tbl = Form1.mesureSub.Split(".")
                m = tbl(0)
                t = tbl(1)
                ct = tbl(2)
            Case Form1.OrigSubsti.Grid3
        End Select
        '
        ListBox1.Items.Clear()
        Ident_Accord(m, t, ct)
    End Sub
    Sub Ident_Accord(m As Integer, t As Integer, ct As Integer)
        'Dim tbl() As String

        With Form1
            'tbl = TableEventH(m, t, ct).Mode.Split()
            'If tbl(1) <> "MinH" Then
            Acc = TableEventH(m, t, ct).Accord
                If Trim(Acc) <> "" Then
                Else

                End If
            'Else
            'ListBox1.
            'End If

        End With
    End Sub
    Private Function SubstDiatonique(degré As Integer, Mode As String)
        Dim a As String = ""
        Select Case degré
            Case 0 ' I
            Case 3 ' IV
            Case 4 ' V
        End Select
        Return a
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Visible = False
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class