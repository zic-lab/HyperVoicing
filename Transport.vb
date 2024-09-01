Public Class Transport
    Dim Ouvert As Boolean = True
    Dim Enchargement As Boolean = True
    ''' <summary>
    ''' Bouton Play
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>                                                                                                          
    Private Sub Play_Click(sender As Object, e As EventArgs) Handles Play.Click
        If Terme.BackColor <> Color.Red Then ' backcolor=rouge quand les délimiteurs ont des valeurs incohérentes (Début > Terme)
            Me.Cursor = Cursors.WaitCursor
            If Module1.JeuxActif = False Then
                Me.Terme.BackColor = Color.White
                TermeFin = Me.Terme.Value
                'i = Form1.Det_DerEventH2()
                'If Me.Début.Value <= i Then
                'If i < Me.Terme.Value Then
                'If Me.Début.Value = i Then
                'TermeFin = i
                'Me.Terme.Value = i
                'Me.Terme.BackColor = Color.Orange
                'TermeFin = nbMesures
                'Me.Terme.Value = nbMesures
                'End If
                Form1.Calcul_AutoVoicingZ_PLAY()
                    INIT_LesPistes()
                        CalculMusique(False)
                        '
                        Module1.JeuxActif = True
                        Play.Enabled = False
                        Form1.PlayArp()
                '
                'End If
            End If
        End If
        '
        Me.Cursor = Cursors.Default
    End Sub
    ''' <summary>
    ''' Bouton Stop
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Arrêt_Click(sender As Object, e As EventArgs) Handles Arrêt.Click
        StopPlay()
    End Sub
    Public Sub StopPlay()
        'Form1.Horloge1.Stop()
        'ArrêterTimer = True ' permet d'appeler la procédure FIN dans la tempo Tempo_Aff_EventH_Tick
        'Form1.Tempo_Aff_EventH.Stop()
        Form1.StopPlay()
        'Form1.MIDIReset()
        Play.Enabled = True
        Form1.Enabled = True
        Module1.JeuxActif = False
        Form1.MIDIReset()
    End Sub
    Private Sub Transport_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Me.Opacity = 1
        'Panel1.Visible = True
        'Label1.Visible = True
    End Sub
    Private Sub Transport_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If Ouvert Then
            'Me.Opacity = 1 '0.6 le 21-05-20
            'Panel1.Visible = False
            'Label1.Visible = False
        End If
    End Sub
    Private Sub Transport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Ouvert = False
        'Me.Visible = False
        e.Cancel = True ' permet d'annuler le déchargement de la form qui est remplacé après par un Hide. La forme reste chargée mais n'est plus visible : elle garde les valeurs de ses composants.
        Me.Hide()
    End Sub
    Private Sub Transport_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim i As Integer

        Dim s1 As New Size(477, 83) ' Size(514, 83) 
        Dim s2 As New Size(560, 83)

        'Dim P1 As New Point(380, 25) ' 411
        'Dim P2 As New Point(502, 6)

        Me.Size = s1
        'Label2.Location = P1 ' label2 = compteur de secondes
        If Remote.Visible = True Then
            Me.Size = s2
            'Label2.Location = P2
        End If


        ' Me.FormBorderStyle = FormBorderStyle.FixedToolWindow
        Label1.Text = "--"
        Label1.ForeColor = Color.Yellow 'Color.FromArgb(255, 213, 91)
        '
        If Module1.LangueIHM = "fr" Then
            Me.Text = "TRANSPORT HYPERVOICING" '"TRANSPORT" ' "BARRE DE TRANSPORT HYPERARP"
        Else
            Me.Text = "TRANSPORT HYPERVOICING"  '"TRANSPORT" ' "HYPERARP TRANPORT BAR"
        End If
        '
        If Module1.LangueIHM = "fr" Then
            Label4.Text = "Début"
            Label5.Text = "Fin"
            Répéter.Text = "Boucle"
            Label7.Text = "Staccato"
            AuDessus.Text = "Top"
            Bassemoins1.Text = "Basse-12"
        Else
            Label4.Text = "Start"
            Label5.Text = "End"
            Répéter.Text = "Loop"
            Label7.Text = "Staccato"
            AuDessus.Text = "Top"
            Bassemoins1.Text = "Bass-12"
        End If
        '
        Me.KeyPreview = True
        '
        Début.Minimum = 1
        Début.Maximum = nbMesuresUtiles
        Début.Value = 1
        '
        Terme.Minimum = 1
        Terme.Maximum = nbMesuresUtiles
        Terme.Value = nbMesures

        'Tempo.Minimum = 30
        'Tempo.Maximum = 240
        Tempo.Value = 120
        Tempo.Increment = 1

        '
        ComboBox8.Items.Clear()

        For i = 0 To 8
            ComboBox8.Items.Add(i.ToString) ' combo des compressions de longueur
        Next
        ComboBox8.SelectedIndex = 0
        '
        ' Calcul du temps de l'interval désigné par Début et Terme
        ' ********************************************************
        Label2.Text = TempsInterval()
        Enchargement = False


        If LangueIHM = "fr" Then
            ToolTip1.SetToolTip(Début, "Début = N° de mesure")
            ToolTip1.SetToolTip(Terme, "Fin = N° de mesure")
            ToolTip1.SetToolTip(Comp, "Compression des longueurs de notes")
            ToolTip1.SetToolTip(LoopNumber, "Nombre de répétitions")
            ToolTip1.SetToolTip(LFinal, "Longueur en mesures du dernier accord")
            ToolTip1.SetToolTip(Play, "Ecouter")
            ToolTip1.SetToolTip(Arrêt, "Arrêter")
        Else
            ToolTip1.SetToolTip(Début, "Start = measure number")
            ToolTip1.SetToolTip(Terme, "End = measure number")
            ToolTip1.SetToolTip(Comp, "Notes lenght compression")
            ToolTip1.SetToolTip(LoopNumber, "Loop number")
            ToolTip1.SetToolTip(LFinal, "Measure length of the last chord")
            ToolTip1.SetToolTip(Play, "Play")
            ToolTip1.SetToolTip(Arrêt, "Stop")
        End If
    End Sub
    Function TempsInterval() As String
        Dim d1 As Double = 1 / (Tempo.Value / 60) ' calcul de la durée d'une noire
        Dim d2 As Double = d1 * 4 ' calcul de la durée d'une mesure
        Dim I As Double = (Terme.Value - Début.Value) + 1
        I = (I * d2)
        I = Convert.ToInt16(I)
        Return (I).ToString + " " + "s"
    End Function


    Private Sub SortirToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Visible = False
    End Sub

    Private Sub Transport_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        ' PLAY, RECALCUL : F5
        ' *******************
        'If e.KeyCode = Keys.F5 Then
        'If Not Form1.Horloge1.IsRunning Then
        'Form1.PlayAccords()
        'Button1.Enabled = False
        'Else
        'Form1.ReCalcul()
        'End If
        'End If
        '
        ' STOP : F4
        ' *********
        'If e.KeyCode = Keys.F4 Then
        'Form1.StopPlay()
        'Button1.Enabled = True
        'End If
        '
        ' STOP : F2
        ' *********
        'If e.KeyCode = Keys.F2 Then
        'Dim r As Rectangle
        '
        'If Parent IsNot Nothing Then
        'r = Parent.RectangleToScreen(Parent.ClientRectangle)
        'Else
        'r = Screen.FromPoint(Me.Location).WorkingArea
        'End If

        'Dim x = Form1.Location.X + (Form1.Size.Width - Me.Width) \ 2
        'Dim y = Form1.Location.Y 'r.Top + (r.Height - Me.Height) \ 2
        'Me.TopLevel = True
        'Me.TopMost = True
        'Me.Location = New Point(x, y)
        'End If
    End Sub

    Private Sub Début_ValueChanged(sender As Object, e As EventArgs) Handles Début.ValueChanged
        Cohérence_Délim()
    End Sub

    Private Sub Tempo_ValueChanged(sender As Object, e As EventArgs) Handles Tempo.ValueChanged
        Form1.Horloge1.BeatsPerMinute = Tempo.Value
        If Not Enchargement Then Label2.Text = TempsInterval()
    End Sub
    Private Sub Terme_ValueChanged(sender As Object, e As EventArgs) Handles Terme.ValueChanged
        'If Terme.Value < Début.Value Then
        'Terme.Value = Terme.Value + 1
        'End If
        ' Temps en secondes de l'interval désigné Par Début et Terme et calculé par TempsInterval
        ' ***************************************************************************************
        'If Terme.Value >= Début.Value Then
        'If Not (Enchargement) Then Label2.Text = TempsInterval()
        'Else
        'Label2.Text = "?"
        'End If
        '
        Cohérence_Délim()
    End Sub

    Private Sub LoopNumber_ValueChanged(sender As Object, e As EventArgs) Handles LoopNumber.ValueChanged
        Me.Répéter.Checked = False
        If Me.LoopNumber.Value > 1 Then
            Me.Répéter.Checked = True
        End If

    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.SelectedIndexChanged
        Me.ComboBox8.BackColor = Color.White
        If Me.ComboBox8.SelectedIndex <> 0 Then
            Me.ComboBox8.BackColor = Color.Chartreuse
        End If
    End Sub

    Private Sub AuDessus_CheckedChanged(sender As Object, e As EventArgs) Handles AuDessus.CheckedChanged
        Me.TopMost = Me.AuDessus.Checked
    End Sub

    Private Sub Terme_KeyUp(sender As Object, e As KeyEventArgs) Handles Terme.KeyUp
        Cohérence_Délim()
    End Sub

    Private Sub Début_KeyUp(sender As Object, e As KeyEventArgs) Handles Début.KeyUp
        Cohérence_Délim()
    End Sub
    Private Sub Cohérence_Délim()

        If Terme.Value >= Début.Value Then
            If Not (Enchargement) Then Label2.Text = TempsInterval()
            Terme.BackColor = Color.White
            Début.BackColor = Color.White
            Terme.ForeColor = Color.Black
            Début.ForeColor = Color.Black
        Else
            Label2.Text = "?"
            Terme.BackColor = Color.Red
            Début.BackColor = Color.Red
            Terme.ForeColor = Color.White
            Début.ForeColor = Color.White
        End If
    End Sub
    Private Sub Tempo_KeyUp(sender As Object, e As KeyEventArgs) Handles Tempo.KeyUp
        If Not Enchargement Then Label2.Text = TempsInterval()
    End Sub

    Public Function EnregistrerTransport() As String

        Dim a As String = Nothing
        Dim b As String = Nothing

        Dim tbl1(0 To 1) As String
        Dim tbl2(0 To 7) As String

        ' Tempo
        ' *****
        tbl1(0) = "Tempo"
        tbl1(1) = Trim(Tempo.Value.ToString)
        tbl2(0) = Join(tbl1, ";")

        ' Début
        ' *****
        tbl1(0) = "Début"
        tbl1(1) = Trim(Début.Value.ToString)
        tbl2(1) = Join(tbl1, ";")

        ' Fin (Terme)
        ' ***********
        tbl1(0) = "Terme"
        tbl1(1) = Trim(Terme.Value.ToString)
        tbl2(2) = Join(tbl1, ";")

        ' LoopNumber(Repeat)
        ' ******************
        tbl1(0) = "Repeat"
        tbl1(1) = "1" ' sauvegardé toujours à 1 pour eviter les calculs long (répétition>1) pas forcément utilise après un chargement
        tbl2(3) = Join(tbl1, ";")
        '
        ' Comp (Réduction)
        ' ****************
        tbl1(0) = "Réduction"
        tbl1(1) = Trim(Comp.Value.ToString)
        tbl2(4) = Join(tbl1, ";")
        '
        ' LFinal
        ' ******
        tbl1(0) = "Final"
        tbl1(1) = Trim(LFinal.Value.ToString)
        tbl2(5) = Join(tbl1, ";")
        '
        ' 4Notes
        ' ******
        tbl1(0) = "4Notes"
        tbl1(1) = Trim(Fournotes.Checked.ToString)
        tbl2(6) = Join(tbl1, ";")
        '
        ' Bassemoins1
        ' ***********
        tbl1(0) = "Basse-1"
        tbl1(1) = Trim(Bassemoins1.Checked.ToString)
        tbl2(7) = Join(tbl1, ";")

        Return "TRANSPORT" + "," + Join(tbl2, ",")
    End Function
    Public Sub Maj_TRANSPORT(ligne As String)
        Dim tbl1() As String

        tbl1 = ligne.Split(",")

        For Each a As String In tbl1
            tbl2 = a.Split(";")
            Select Case tbl2(0)
                Case "Tempo"
                    Tempo.Value = Convert.ToDecimal(tbl2(1))
                Case "Début"
                    Début.Value = Convert.ToDecimal(tbl2(1))
                Case "Terme"
                    Terme.Value = Convert.ToDecimal(tbl2(1))
                Case "Repeat"
                    'LoopNumber.Value = Convert.ToDecimal(tbl2(1)) ' <--- la valeur de loopnumber vient de la base de registre (Voir CréationRegistry)
                Case "Réduction"
                    Comp.Value = Convert.ToDecimal(tbl2(1))
                Case "Final"
                    LFinal.Value = Convert.ToDecimal(tbl2(1))
                Case "Basse-1"
                    Bassemoins1.Checked = Convert.ToBoolean(tbl2(1))
                Case "4Notes"
                    Fournotes.Checked = Convert.ToBoolean(tbl2(1))
            End Select
        Next
        Me.Refresh()
    End Sub
    Public Sub TRANSPORT_Refresh()
        Tempo.Value = 120
        Début.Value = 1
        Terme.Value = nbMesures
        'LoopNumber.Value = 1 ' <--- la valeur de loopnumber vient de la base de regsitre au chargement de l'appli (voir CreationRegsitry)
        Comp.Value = 0
        LFinal.Value = 2
        Me.Refresh()
    End Sub

    Private Sub Fournotes_CheckedChanged(sender As Object, e As EventArgs) Handles Fournotes.CheckedChanged
        Form1.Calcul_AutoVoicingZ()
    End Sub

    Private Sub Bassemoins1_CheckedChanged(sender As Object, e As EventArgs) Handles Bassemoins1.CheckedChanged
        Form1.Calcul_AutoVoicingZ()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label1_DoubleClick(sender As Object, e As EventArgs) Handles Label1.DoubleClick
        ' OngletCours_Edition
        Form1.AllerVerPR(Trim(Label1.Text))
    End Sub
End Class