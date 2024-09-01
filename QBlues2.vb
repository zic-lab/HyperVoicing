Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class QBlues2
    Dim ligne As Integer = 0
    Dim Mode As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        majBlues(Trim(ComboBox1.Text), Trim(Mode))
    End Sub

    Private Sub QBlues2_Load(sender As Object, e As EventArgs) Handles Me.Load
        majBlues("C", "Majeur")
        Mode = "Majeur"

        ComboBox1.Items.Clear()

        ComboBox1.Items.Add("C")
        ComboBox1.Items.Add("C#")
        ComboBox1.Items.Add("D")
        ComboBox1.Items.Add("D#")
        ComboBox1.Items.Add("E")
        ComboBox1.Items.Add("F")
        ComboBox1.Items.Add("F#")
        ComboBox1.Items.Add("G")
        ComboBox1.Items.Add("G#")
        ComboBox1.Items.Add("A")
        ComboBox1.Items.Add("A#")
        ComboBox1.Items.Add("B")
        '
        ComboBox1.SelectedIndex = 0
        '

    End Sub
    Sub majBlues(Tonique As String, Mode_x As String)
        Maj_TabNotes_Majus()
        Tonique = Trim(Tonique)
        Dim sDomin As String = TabNotes(Array.IndexOf(TabNotes, Tonique) + 5)
        Dim Domin As String = TabNotes(Array.IndexOf(TabNotes, Tonique) + 7)
        '
        Select Case Trim(Mode_x)
            Case "Majeur"
                Label1.Text = Tonique + " 7"
                Label2.Text = sDomin + " 7"
                Label3.Text = Tonique + " 7"
                Label4.Text = Domin + " 7"
                Label5.Text = sDomin + " 7"
                Label6.Text = Tonique + " 7"
                Label7.Text = Domin + " 7"
            Case "Mineur"
                Label1.Text = Tonique + " m7"
                Label2.Text = sDomin + " m7"
                Label3.Text = Tonique + " m7"
                Label4.Text = Domin + " 7"
                Label5.Text = sDomin + " m7"
                Label6.Text = Tonique + " m7"
                Label7.Text = Domin + " 7"
        End Select
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            majBlues(Trim(ComboBox1.Text), "Majeur")
            Mode = "Majeur"
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            majBlues(Trim(ComboBox1.Text), "Mineur")
            Mode = "Mineur"
        End If
    End Sub

    Sub ECR_Standard(Accord As String, Degré As String, Position As String)

        Dim tbl() As String = Accord.Split()
        Maj_TabNotes_Majus()
        Dim i As Integer = Array.IndexOf(TabNotes, Trim(tbl(0))) ' index de la tonique de l'accord
        Dim Tona As String = Trim(TabNotes(i + 5)) + " Maj"
        Dim Mode As String = Tona
        Dim Gamme As String = Trim(tbl(0)) + " Blues"
        '
        Form1.ECR_Acc(Accord, Degré, Position, Tona, Mode, Gamme)
        '

        '


    End Sub

    Sub ECR_Acc(Acc As String, Degré As Integer, Colonne As Integer, Tona As String, Mode As String, Gamme As String)
        Dim m As Integer = Colonne


        ' Maj des données de l'accord dans TableEventh
        ' ********************************************
        TableEventH(m, 1, 1).Tonalité = Tona
        TableEventH(m, 1, 1).Mode = Mode '
        TableEventH(m, 1, 1).Gamme = Gamme
        TableEventH(m, 1, 1).Accord = Trim(Acc)
        TableEventH(m, 1, 1).NumAcc = Colonne
        TableEventH(m, 1, 1).Position = Str(Colonne) + ".1" + ".1"
        TableEventH(m, 1, 1).Degré = Degré - 1
        TableEventH(m, 1, 1).Ligne = Colonne
        TableEventH(m, 1, 1).Racine = "b1"
        TableEventH(m, 1, 1).Vel = "100"
        '
        ' Mise à jour des Grilles de Form1 : Grid1, Grid2 et Grid3
        ' ********************************************************
        Form1.Grid2.AutoRedraw = False
        Form1.Grid3.AutoRedraw = False
        '
        ' Mise à jour de Grid2
        Form1.Grid2.Cell(1, m).Text = Trim(Acc)
        ' mise à jour des couleurs de Grid2 et Grid3
        i = Form1.Det_IndexGrid3_De_ColGrid2(m) ' Det_IndexGrid3_De_ColGrid2(Grid2.ActiveCell.Col)
        If i <> 1 Then                '
            Form1.Grid3.Cell(2, i).BackColor = Couleur_Accord_Grid3
            Form1.Grid3.Cell(2, i).ForeColor = Color.White
            a = TableEventH(m, 1, 1).Tonalité 'Det_TonalitédDuPremierAccordDsMesure(m)
            a = Form1.Det_RelativeMajeure2(a) ' si la tonalité est mineure alors on affiche la couleur de la relative majeure
            tbl = Split(a)
            Form1.Grid2.Cell(1, m).BackColor = DicoCouleur.Item(Trim(tbl(0))) ' la couleur est fonction de la tonalité
            Form1.Grid2.Cell(1, m).ForeColor = DicoCouleurLettre.Item(tbl(0))
            '
        End If
        '
        Form1.Grid2.AutoRedraw = True
        Form1.Grid3.AutoRedraw = True
        Form1.Grid2.Refresh()
        Form1.Grid3.Refresh()
        '
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim I As String = Trim(Label1.Text)
        Dim IV As String = Trim(Label2.Text)
        Dim V As String = Trim(Label7.Text)

        ' Ecriture I sur 1
        ECR_Standard(I, 5, 1)
        ' Ecriture IV sur 5
        ECR_Standard(IV, 5, 5)
        ' Ecriture I sur 7
        ECR_Standard(I, 5, 7)
        ' Ecriture V sur 9
        ECR_Standard(V, 5, 9)
        ' Ecriture IV sur 10
        ECR_Standard(IV, 5, 10)
        ' Ecriture I sur 11
        ECR_Standard(I, 5, 11)
        ' Ecriture V sur 12
        ECR_Standard(V, 5, 12)
        '
        Form1.Grid1.AutoRedraw = False
        Form1.Ecriture_Entrée_Ds_CompoGrid() ' ' Mise à jour correspondante dans Grid1
        Form1.Grid1.AutoRedraw = True
        Form1.Grid1.Refresh()
        '
        Form1.Calcul_AutoVoicingZ()
        EcritUneFois = True
        Form1.LockageColonnes() ' loackage des colonnes de grid1 et grid4
        Form1.Maj_PianoRoll()
        Form1.Maj_DrumEdit()
        Form1.Refresh_Courbexp()
        Me.Hide()

    End Sub
End Class