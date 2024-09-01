Public Class ActionsPianoRoll
    Public Enum TypeAct
        Rien = 0
        Effacer
        Coller
        Transposer
    End Enum
    Public TypeAction As TypeAct
    Public Début As Integer
    Public Fin As Integer
    Public Destination As Integer
    Public ValeurTransp As Integer

    Private Sub ActionsPianoRoll_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '
        ComboBox4.Items.Clear()
        ComboBox4.Items.Add("+12")
        ComboBox4.Items.Add("+11")
        ComboBox4.Items.Add("+10")
        ComboBox4.Items.Add("+9")
        ComboBox4.Items.Add("+8")
        ComboBox4.Items.Add("+7")
        ComboBox4.Items.Add("+6")
        ComboBox4.Items.Add("+5")
        ComboBox4.Items.Add("+4")
        ComboBox4.Items.Add("+3")
        ComboBox4.Items.Add("+2")
        ComboBox4.Items.Add("+1")
        ComboBox4.Items.Add("+0")
        ComboBox4.Items.Add("-1")
        ComboBox4.Items.Add("-2")
        ComboBox4.Items.Add("-3")
        ComboBox4.Items.Add("-4")
        ComboBox4.Items.Add("-5")
        ComboBox4.Items.Add("-6")
        ComboBox4.Items.Add("-7")
        ComboBox4.Items.Add("-8")
        ComboBox4.Items.Add("-9")
        ComboBox4.Items.Add("-10")
        ComboBox4.Items.Add("-11")
        ComboBox4.Items.Add("-12")
        '
        ComboBox4.SelectedIndex = 12
        '
        If Module1.LangueIHM = "fr" Then
            Me.Text = "Actions dans une sélection de mesures"
            Label1.Text = "Début"
            Label2.Text = "Fin"
            Label3.Text = "Destination"
            Label4.Text = "Valeurs"
            Button1.Text = "Effacer"
            Button2.Text = "Coller"
            Button3.Text = "Transposer"
            Button4.Text = "Annuler"
            GroupBox1.Text = "SELECTION DES MESURES"
            GroupBox2.Text = "ACTIONS DANS LA SELECTION"
        Else
            Me.Text = "Actions inside a measures selection"
            Label1.Text = "Start"
            Label2.Text = "End"
            Label3.Text = "Destination"
            Label4.Text = "Values"
            Button1.Text = "Clear"
            Button2.Text = "Paste"
            Button3.Text = "Transpose"
            Button4.Text = "Cancel"
            GroupBox1.Text = "MEASURES SELECTION"
            GroupBox2.Text = "ACTIONS IN THE SELECTION"
        End If
        '
        Me.StartPosition = FormStartPosition.CenterScreen
        ' 
        Debut.Maximum = Module1.nbMesures
        Debut.Minimum = 1
        '
        Terme.Maximum = Module1.nbMesures
        Terme.Minimum = 1
        '
        Dest.Maximum = Module1.nbMesures
        Dest.Minimum = 1
    End Sub

    ' Bouton Annuler
    ' **************
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TypeAction = TypeAct.Rien
        Me.Hide()
    End Sub

    ' Bouton Effacer
    ' **************
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If LangueIHM = "fr" Then
            MessageHV.PTitre = "Avertissement"
            MessageHV.PContenuMess = "Voulez-vous effacer les notes entre la mesure " + Debut.Value.ToString + " et la mesure " + Terme.Value.ToString
            MessageHV.PTypBouton = "OuiNon"
        Else
            MessageHV.PTitre = "Warning"
            MessageHV.PContenuMess = "Do you want to clear notes between measure " + Debut.Value.ToString + " and measure " + Terme.Value.ToString
            MessageHV.PTypBouton = "OK"
            MessageHV.PTypBouton = "OuiNon"
        End If
        Cacher_FormTransparents()
        MessageHV.ShowDialog()
        If MessageHV.Sortie <> "Non" Then
            Début = Convert.ToInt16(Debut.Value)
            Fin = Convert.ToInt16(Terme.Value)
            TypeAction = TypeAct.Effacer
            Me.Hide()
        End If

    End Sub


    ' Bouton Coller
    ' *************
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If LangueIHM = "fr" Then
            MessageHV.PTitre = "Avertissement"
            MessageHV.PContenuMess = "Voulez-vous coller les notes entre la mesure " + Debut.Value.ToString + " et la mesure " + Terme.Value.ToString + " (comprise) à partir de la mesure " + Dest.Value.ToString
            MessageHV.PTypBouton = "OuiNon"
        Else
            MessageHV.PTitre = "Warning"
            MessageHV.PContenuMess = "Do you want to paste notes between measure " + Debut.Value.ToString + " and measure " + Terme.Value.ToString + " (included) from measure " + Dest.Value.ToString
            MessageHV.PTypBouton = "OuiNon"
            MessageHV.PTypBouton = "OK"
            MessageHV.PTypBouton = "OuiNon"
        End If
        Cacher_FormTransparents()
        MessageHV.ShowDialog()
        If MessageHV.Sortie <> "Non" Then
            Début = Convert.ToInt16(Debut.Value)
            Fin = Convert.ToInt16(Terme.Value)
            Destination = Convert.ToInt16(Dest.Value)
            TypeAction = TypeAct.Coller
            Me.Hide()
        End If
    End Sub
    ' Bouton Tranposer
    ' ****************
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If LangueIHM = "fr" Then
            MessageHV.PTitre = "Avertissement"
            MessageHV.PContenuMess = "Voulez-vous transposer les notes dans votre sélection comprise entre la mesure " + Debut.Value.ToString + " et la mesure " + Terme.Value.ToString
        Else
            MessageHV.PTitre = "Warning"
            MessageHV.PContenuMess = "Do you want to transpose the notes in your selection between the measure " + Debut.Value.ToString + " and measure " + Terme.Value.ToString
        End If
        '
        MessageHV.PTypBouton = "OuiNon"
        MessageHV.ShowDialog()
        If MessageHV.Sortie <> "Non" Then
            Début = Convert.ToInt16(Debut.Value)
            Fin = Convert.ToInt16(Terme.Value)
            ValeurTransp = Convert.ToInt16(ComboBox4.Text)
            TypeAction = TypeAct.Transposer
            Me.Hide()
        End If
    End Sub
    Private Sub Debut_ValueChanged(sender As Object, e As EventArgs) Handles Debut.ValueChanged
        If Debut.Value >= Terme.Value Then
            If Terme.Value <> 0 Then
                Debut.Value = Terme.Value '- 1
            End If
        End If
    End Sub

    Private Sub Terme_ValueChanged(sender As Object, e As EventArgs) Handles Terme.ValueChanged
        If Terme.Value < Debut.Value Then
            Terme.Value = Terme.Value + 1
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub
End Class