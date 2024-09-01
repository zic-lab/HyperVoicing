Public Class Signature

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Signature_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        '
        ComboBox1.Items.Add("2/4")
        ComboBox1.Items.Add("3/4")
        ComboBox1.Items.Add("4/4")
        ComboBox1.Items.Add("5/4")
        ComboBox1.Items.Add("6/4")
        ComboBox1.Items.Add("7/4")
        'ComboBox1.Items.Add("3/8") retiré pour le moment le 14/07/15
        ComboBox1.Items.Add("6/8")
        ComboBox1.Items.Add("7/8")
        ComboBox1.Items.Add("9/8")
        ComboBox1.Items.Add("12/8")
        '
        ComboBox1.SelectedIndex = 2 ' par défaut 4/4
        PictureBox1.Image = My.Resources.Resources.Base_Binaire
        '
        If Module1.LangueIHM = "fr" Then
            Me.Text = "Métrique"
        Else
            Me.Text = "Time Signature"
        End If
    End Sub
    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Dim tbl() As String
        Dim a As String
        tbl = Split(ComboBox1.Text, "/")
        '
        a = tbl(1)
        Select Case a
            Case "4"
                PictureBox1.Image = My.Resources.Resources.Base_Binaire
            Case "8"
                PictureBox1.Image = My.Resources.Resources.Base_Ternaire
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Retour = "OK"
        RetourSTR = Trim(ComboBox1.Text)
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Retour = "Annuler"
        RetourSTR = ""
        Me.Close()
    End Sub
End Class