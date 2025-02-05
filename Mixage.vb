Public Class Mixage
    Public F3 As New Form
    Private Langue As String

    Public WriteOnly Property PLangue As String
        Set(ByVal value As String)
            Me.Langue = value
        End Set
    End Property
    Public PisteVolume As New List(Of TrackBar) ' ces composants sont publiques car ils sont accèdés par Form1.INIT_Piste
    Public labelAff As New List(Of Label)
    Public soloVolume As New List(Of CheckBox) ' Mutes des pistes
    Dim soloPiste As New List(Of Button) ' bouton solo 
    Dim LSauvMute As New List(Of Boolean)
    '
    Dim labelVolume As New List(Of Label)
    Dim LabelNom As New List(Of Label)
    Dim Panneau As New SplitContainer
    Dim Titre As New Label
    Public NomduSon As New List(Of TextBox)
    Private DockButton As New Button
    Public AutorisVol As New CheckBox
    ' 
    Dim Plus5 As New Button
    Dim Moins5 As New Button
    Dim Max As New Button
    Dim Tous As New Button

    ReadOnly Send As New Button
    ReadOnly Devant As New CheckBox
    '
    ' Menu4
    Private Menu1 As New System.Windows.Forms.MenuStrip()
    Private Fichier As New System.Windows.Forms.ToolStripMenuItem()
    Private Quitter As New System.Windows.Forms.ToolStripMenuItem()


    ' Fonts
    ' *****
    ReadOnly fnt1 As New System.Drawing.Font("Calibri", 13, FontStyle.Regular)
    ReadOnly fnt2 As New System.Drawing.Font("Calibri", 15, FontStyle.Regular)
    ReadOnly fnt3 As New System.Drawing.Font("Tahoma", 10, FontStyle.Regular)
    ReadOnly fnt4 As New System.Drawing.Font("Calibri", 18, FontStyle.Bold)
    ReadOnly fnt5 As New System.Drawing.Font("Calibri", 12, FontStyle.Regular)
    ReadOnly fnt6 As New Font("Verdana", 8, FontStyle.Regular)
    ReadOnly fnt7 As New Font("Tahoma", 8.25, FontStyle.Regular)
    ReadOnly fnt8 As New Font("Tahoma", 8.25, FontStyle.Bold)
    ReadOnly fnt9 As New Font("Mistral", 15, FontStyle.Regular)
    'Sub New()


    'End Sub
    Public Sub Construction_Formulaire()
        Construction_F3()
        Construction_Barrout()
        Construction_Table()
        Construction_Menu()
        AddHandler F3.KeyUp, AddressOf F3_KeyUp
        Me.F3.KeyPreview = True ' pour réception des touches F4 et F5 (stop, play (recalcul)
    End Sub
    Private Sub F3_KeyUp(sender As Object, e As KeyEventArgs)

        ' PLAY, RECALCUL : F5
        ' *******************
        'If e.KeyCode = Keys.F5 Then
        'If Not Form1.Horloge1.IsRunning Then
        'Form1.PlayAccords()
        'Else
        'Form1.ReCalcul()
        'End If
        'End If
        '
        '' STOP : F4
        '' *********
        'If e.KeyCode = Keys.F4 Then
        'Form1.StopPlay()
        'End If
    End Sub
    Sub Construction_F3()
        F3.Controls.Add(Panneau)
        Panneau.Dock = DockStyle.Fill
        Panneau.Orientation = Orientation.Horizontal
        Panneau.SplitterDistance = 50
        Panneau.IsSplitterFixed = True
        Panneau.BorderStyle = BorderStyle.FixedSingle
        Panneau.Panel1.BorderStyle = BorderStyle.FixedSingle
        Panneau.Panel1.BackColor = Color.FromArgb(240, 240, 240)
        Panneau.Panel2.BackColor = Color.FromArgb(240, 240, 240)
        Panneau.FixedPanel = FixedPanel.Panel1
        '
        If Module1.LangueIHM = "fr" Then
            F3.Text = "MIX"
        Else
            F3.Text = "MIX"
        End If
        F3.ControlBox = False
        F3.Tag = 10 ' 10 = N° de l'onglet de Tabcontrol4 contenant la table de mixage
    End Sub
    Sub Construction_Barrout()
        '
        ' bouton -5
        Panneau.Panel1.Controls.Add(Moins5)
        Moins5.TabStop = False
        Moins5.Text = "-5"
        Moins5.Size = New Size(45, 45)
        Moins5.Location = New Point(3, 2) '70,10
        Moins5.BackColor = Color.BurlyWood
        Moins5.TabStop = False
        Moins5.TabIndex = 1
        Moins5.ResumeLayout(False)

        '
        ' bouton +5
        Panneau.Panel1.Controls.Add(Plus5)
        Plus5.TabStop = False
        Plus5.Text = "+5"
        Plus5.Size = New Size(45, 45)
        Plus5.Location = New Point(70, 2) ' 3,10
        Plus5.BackColor = Color.BurlyWood
        '
        ' bouton normaliser
        Panneau.Panel1.Controls.Add(Max)
        Max.TabStop = False
        If Me.Langue = "fr" Then
            Max.Text = "Normaliser"
        Else
            Max.Text = "Normalize"
        End If
        '
        Max.Size = New Size(80, 45)
        Max.Location = New Point(135, 2)
        Max.BackColor = Color.BurlyWood
        '
        ' bouton "Mute act."
        Panneau.Panel1.Controls.Add(Tous)
        Tous.TabStop = False
        If Me.Langue = "fr" Then
            Tous.Text = "Mute act."
        Else
            Tous.Text = "All"
        End If
        '
        Tous.Size = New Size(80, 45)
        Tous.Location = New Point(234, 2)
        Tous.BackColor = Color.BurlyWood

        ' Activation/Désactivation de la table de mixage
        ' **********************************************
        Panneau.Panel1.Controls.Add(AutorisVol)
        AutorisVol.TabStop = False
        If Me.Langue = "fr" Then
            AutorisVol.Text = "MIX Activation"
        Else
            AutorisVol.Text = "MIX Activation"
        End If
        '
        AutorisVol.Size = New Size(100, 42)
        AutorisVol.Font = fnt8
        AutorisVol.Location = New Point(330, 2)
        AutorisVol.BackColor = Color.BurlyWood
        AutorisVol.Checked = True


        ' Bouton Send
        ' ***********
        Panneau.Panel1.Controls.Add(Send)
        Send.Size = New Size(120, 45)
        Send.Location = New Point(450, 2) '70,10
        Send.BackColor = Color.BurlyWood
        Send.TabStop = False
        Send.ResumeLayout(False)
        '
        If LangueIHM = "fr" Then
            Send.Text = "Envoyer tous les volumes"
        Else
            Send.Text = "Send all volumes"
        End If
        '
        ' Check Devant
        ' ************
        Panneau.Panel1.Controls.Add(Devant)
        Devant.Location = New Point(600, 5)
        Devant.AutoSize = True
        If LangueIHM = "fr" Then
            Devant.Text = "Toujours devant"
        Else
            Devant.Text = "Always on top"
        End If
        Devant.Visible = False

        '
        ' boutton attacher/détacher
        Panneau.Panel1.Controls.Add(DockButton)
        DockButton.TabStop = False
        Dim P As New Point(750, 2)
        Dim s As New Size(100, 45)
        '
        DockButton.FlatStyle = FlatStyle.Standard
        DockButton.BackColor = Color.DarkOliveGreen
        DockButton.ForeColor = Color.Yellow
        DockButton.Font = fnt5
        DockButton.Location = P
        DockButton.Size = s
        DockButton.AutoSize = True
        '
        If Module1.LangueIHM = "fr" Then
            DockButton.Text = "Détacher"
        Else
            DockButton.Text = "Undock"
        End If
        '
        DockButton.Visible = True
        '
        AddHandler Devant.CheckedChanged, AddressOf Devant_CheckedChanged
        AddHandler Send.Click, AddressOf Send_Click
        AddHandler Moins5.Click, AddressOf Moins5_Click
        AddHandler Plus5.Click, AddressOf Plus5_Click
        AddHandler Max.Click, AddressOf Max_Click
        AddHandler Tous.Click, AddressOf Tous_Click
        AddHandler DockButton.MouseClick, AddressOf DockButton_MouseClick
        AddHandler AutorisVol.MouseClick, AddressOf AutorisVol_Mouseclick
    End Sub
    Sub Devant_CheckedChanged(sender As Object, e As EventArgs)
        If Devant.Checked Then
            Me.F3.TopMost = True
        Else
            Me.F3.TopMost = False
        End If

    End Sub
    Sub Send_Click(Sender As Object, e As EventArgs)

        Dim pst As Integer
        Dim i As Integer = Form1.ChoixSortieMidi
        Dim canal As Byte

        For pst = 0 To nb_TotalCurseurs - 1
            If Not (EnChargement) And AutorisVol.Checked And PisteVolume.Item(pst).Enabled And soloVolume.Item(pst).Checked Then
                Dim volume As Byte = CByte(PisteVolume.Item(pst).Value)
                labelAff.Item(pst).Text = Convert.ToString(volume)
                canal = Convert.ToByte(pst) 'LesPistes.Item(pst).Canal
                If Not (Form1.SortieMidi.Item(Form1.ChoixSortieMidi).IsOpen) Then
                    Form1.SortieMidi.Item(Form1.ChoixSortieMidi).Open()
                End If
                Form1.SortieMidi.Item(Form1.ChoixSortieMidi).SendControlChange(canal, CVolume, volume)
            End If
        Next
    End Sub
    Public Sub Construction_Menu()
        '
        Fichier.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Quitter})
        Fichier.Size = New System.Drawing.Size(87, 20)
        If Me.Langue = "fr" Then
            Fichier.Text = "Fichier"
        Else
            Fichier.Text = "File"
        End If
        Fichier.Visible = True
        ' Quitter (de Fichier)
        '
        If Me.Langue = "fr" Then
            Quitter.Text = "Attacher"
        Else
            Quitter.Text = "Dock"
        End If
        Quitter.ShortcutKeys = Shortcut.CtrlD
        Quitter.Size = New System.Drawing.Size(180, 22)
        '
        Menu1.Text = "Menu"
        Me.Menu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Fichier})
        F3.MainMenuStrip = Menu1
        F3.MainMenuStrip.Visible = False
        Menu1.Location = New System.Drawing.Point(0, 0)
        F3.Controls.Add(Menu1)
        F3.MainMenuStrip = Menu1

        AddHandler Quitter.Click, AddressOf Quitter_Click
    End Sub
    Sub Quitter_Click(Sender As Object, e As EventArgs)
        Dim NumOnglet As Integer = Convert.ToUInt16(F3.Tag)
        Attacher(NumOnglet)
    End Sub
    Sub Attacher(NumOnglet As Integer)
        Me.F3.FormBorderStyle = FormBorderStyle.None
        Me.F3.TopMost = False   ' un seul des 2 suffit ?
        Me.F3.TopLevel = False
        F3.MainMenuStrip.Visible = False
        Form1.TabControl4.TabPages.Item(NumOnglet).Controls.Add(Me.F3)
        Me.F3.Dock = DockStyle.Fill
        '
        If Module1.LangueIHM = "fr" Then
            DockButton.Text = "Détacher"
        Else
            DockButton.Text = "UnDock"
        End If
    End Sub


    Private Sub DockButton_MouseClick(sender As Object, e As EventArgs)
        Dim com As Button = sender
        Dim ind As Integer = com.Tag

        Dim NumOnglet As Integer = Convert.ToInt16(Me.F3.Tag)
        If Me.F3.Dock = DockStyle.Fill Then
            'Me.F3.Visible = False '   --> DETACHER
            Me.F3.FormBorderStyle = FormBorderStyle.SizableToolWindow
            F3.Text = "MIX" ' - 5)
            ' 
            Me.F3.Dock = DockStyle.None
            Form1.TabControl4.TabPages.Item(NumOnglet).Controls.Remove(Me.F3)
            Dim p As New Point With {
                .X = Me.F3.Location.X,
                .Y = Me.F3.Location.Y + 10
            }
            Me.F3.Location = p

            Me.F3.StartPosition = FormStartPosition.Manual ' permet de tenir compte de la location calculée dans p
            F3.TopMost = True '
            F3.TopLevel = True
            '

            Dim s As New Size With {
                .Width = Panneau.Width + 330,
                .Height = Panneau.Height - 22
            }
            Me.F3.Size = s
            Me.F3.FormBorderStyle = FormBorderStyle.Sizable
            '
            If Module1.LangueIHM = "fr" Then
                DockButton.Text = "Attacher"
            Else
                DockButton.Text = "Dock"
            End If
            '
            Me.F3.Visible = True
            F3.MainMenuStrip.Visible = True


            'Refresh_Général()
            'Maj_Tooltips()
        Else                            ' --> ATTACHER
            'Me.F3.Visible = False
            Me.F3.FormBorderStyle = FormBorderStyle.None ' attacher
            Me.F3.TopMost = False   ' un seul des 2 suffit ?
            Me.F3.TopLevel = False
            Form1.TabControl4.TabPages.Item(NumOnglet).Controls.Add(Me.F3)
            Me.F3.Dock = DockStyle.Fill
            '
            If Module1.LangueIHM = "fr" Then
                DockButton.Text = "Détacher"
            Else
                DockButton.Text = "UnDock"
            End If
            Me.F3.Visible = True
            F3.Refresh()
            '
        End If

    End Sub
    Public Sub AutorisVol_MouseClick(sender As Object, e As EventArgs)
        VolumesEnabled(AutorisVol.Checked)
    End Sub
    Private Sub Moins5_Click(sender As Object, e As EventArgs)
        '

        Dim minV, i, j As Integer
        minV = Det_MinVolume()
        j = minV - 5
        If j >= 0 Then
            For i = 0 To nb_TotalCurseurs - 1
                PisteVolume.Item(i).Value = PisteVolume.Item(i).Value - 5
                labelAff.Item(i).Text = Convert.ToString(PisteVolume.Item(i).Value)
            Next i
        End If
        '
        Form1.Send_AllVolumes()

    End Sub
    Private Sub Plus5_Click(sender As Object, e As EventArgs)

        Dim maxV, i, j As Integer
        maxV = Det_MaxVolume()
        j = maxV + 5
        If j <= 127 Then
            For i = 0 To nb_TotalCurseurs - 1
                PisteVolume.Item(i).Value = PisteVolume.Item(i).Value + 5
                labelAff.Item(i).Text = Convert.ToString(PisteVolume.Item(i).Value)
            Next i
        End If
        '
        Form1.Send_AllVolumes()

    End Sub

    Private Sub Max_Click(sender As Object, e As EventArgs)

        Dim maxV, i, j As Integer
        maxV = Det_MaxVolume()
        j = 127 - maxV
        '
        If j > 0 Then
            For i = 0 To nb_TotalCurseurs - 1
                PisteVolume.Item(i).Value = PisteVolume.Item(i).Value + j
                labelAff.Item(i).Text = Convert.ToString(PisteVolume.Item(i).Value)
            Next i
            Form1.ValCompress = j
        Else
            If Form1.ValCompress <> -1 Then
                For i = 0 To nb_TotalCurseurs - 1
                    PisteVolume.Item(i).Value = PisteVolume.Item(i).Value - Form1.ValCompress
                    labelAff.Item(i).Text = Convert.ToString(PisteVolume.Item(i).Value)
                Next i
            End If
        End If
        Form1.Send_AllVolumes()

    End Sub
    Private Sub Tous_Click(sender As Object, e As EventArgs)
        If soloVolume.Item(0).Checked Then
            For Each ck As CheckBox In soloVolume
                ck.Checked = False
            Next
        Else
            For Each ck As CheckBox In soloVolume
                ck.Checked = True
            Next
        End If
    End Sub
    Function Det_MaxVolume() As Integer
        Dim i, v As Integer
        Dim MaxV As Integer
        '
        Dim List1 As New List(Of Integer)

        For i = 0 To nb_TotalPistes - 1 'Arrangement1.Nb_PistesMidi
            v = PisteVolume.Item(i).Value ' Me.Récup_Volume(i) 'PisteVolume.Item(i).Value
            List1.Add(v)
        Next i
        '
        MaxV = List1.Item(0)
        For Each v1 As Integer In List1
            If v1 > MaxV Then
                MaxV = v1
            End If
        Next
        Return MaxV
    End Function
    Function Det_MinVolume() As Integer
        Dim i, v As Integer
        Dim MinV As Integer
        '
        Dim List1 As New List(Of Integer)

        For i = 0 To nb_TotalPistes - 1
            v = PisteVolume.Item(i).Value 'Me.Récup_Volume(i)
            List1.Add(v)
        Next i
        '
        MinV = List1.Item(0)
        For Each v1 As Integer In List1
            If v1 < MinV Then
                MinV = v1
            End If
        Next
        Return MinV
    End Function
    Sub Construction_Table()
        Dim i As Integer
        Dim s As New Size
        Dim PP As Integer = 100 ' constant servant au positionnement des éléments sur l'axe des x

        For i = 0 To 15 'Module1.nb_TotalPistes - 1 'Arrangement1.Nb_PistesMidi
            '
            PisteVolume.Add(New TrackBar)
            labelVolume.Add(New Label)
            labelAff.Add(New Label)
            soloVolume.Add(New CheckBox) ' activation de la tranche (en haut de la track bar)
            soloPiste.Add(New Button)    ' bouton de passage en mode solo
            LabelNom.Add(New Label)
            NomduSon.Add(New TextBox)
            '
            Panneau.Panel2.BackColor = Color.White  ' 
            Panneau.Panel2.AutoScroll = True
            '
            Panneau.Panel2.Controls.Add(PisteVolume.Item(i))
            PisteVolume.Item(i).TabStop = False
            Panneau.Panel2.Controls.Add(labelVolume.Item(i))
            Panneau.Panel2.Controls.Add(labelAff.Item(i))
            Panneau.Panel2.Controls.Add(soloVolume.Item(i))
            soloVolume.Item(i).TabStop = False
            Panneau.Panel2.Controls.Add(soloPiste.Item(i))
            soloPiste.Item(i).TabStop = False
            Panneau.Panel2.Controls.Add(LabelNom.Item(i))
            Panneau.Panel2.Controls.Add(NomduSon.Item(i))
            NomduSon.Item(i).TabStop = False
            '
            ' sélection des pistes
            soloVolume.Item(i).Location = New Point(5 + (i * PP), 420) '
            soloVolume.Item(i).Visible = True
            soloVolume.Item(i).Checked = True
            '
            If Module1.LangueIHM = "fr" Then
                soloVolume.Item(i).Text = "PISTE" + Str(i + 1)
            Else
                soloVolume.Item(i).Text = "TRACK" + Str(i + 1)
            End If
            '
            If i = 0 Then
                soloVolume.Item(i).Text = "HyperV"
            End If
            '
            NomduSon.Item(i).Visible = True
            '
            ' traitement du DrumEdit
            If i = 9 Then
                If Module1.LangueIHM = "fr" Then
                    soloVolume.Item(i).Text = "Batterie"
                    'NomduSon.Item(i).Visible = False
                Else
                    soloVolume.Item(i).Text = "Drums"
                    'NomduSon.Item(i).Visible = False
                End If
            End If
            '
            soloVolume.Item(i).Size = New Size(85, 30)
            soloVolume.Item(i).Font = Module1.fontNomduSon
            soloVolume.Item(i).Tag = i
            soloVolume.Item(i).BringToFront()
            '
            ' Nom du son (en bas)
            NomduSon.Item(i).Location = New Point(5 + (i * PP), 455) ' checkbox.
            'If i = 9 Then NomduSon.Item(i).Visible = False ' pas de nom du son pour la batterie
            NomduSon.Item(i).Text = ""
            NomduSon.Item(i).Size = New Size(95, 20)
            NomduSon.Item(i).Font = Module1.fontNomduSon
            NomduSon.Item(i).BackColor = Color.Beige
            NomduSon.Item(i).ForeColor = Color.Black
            NomduSon.Item(i).BorderStyle = BorderStyle.FixedSingle
            NomduSon.Item(i).Tag = i
            AddHandler NomduSon.Item(i).TextChanged, AddressOf NomduSon_TextChanged
            '
            ' Nom des Pistes 
            LabelNom.Item(i).Location = New Point(5 + (i * PP), 5) ' checkbox
            LabelNom.Item(i).Visible = True
            'LabelNom.Item(i).Text = "Piste"
            LabelNom.Item(i).Font = fnt8
            LabelNom.Item(i).AutoSize = True
            LabelNom.Item(i).Tag = i
            '
            Select Case i
                Case N_PisteAcc
                    NomduSon.Item(i).BackColor = Color.Tan
                    soloVolume.Item(i).BackColor = Color.White 'CoulHyperV
                    'labelAff.Item(i).ForeColor = CoulHyperV
                    labelAff.Item(i).BackColor = Color.Tan
                    labelAff.Item(i).ForeColor = Color.Black
                    PisteVolume.Item(i).BackColor = Color.Tan

                Case N_PistePianoR1, N_PistePianoR2, N_PistePianoR3, N_PistePianoR4, N_PistePianoR5, N_PistePianoR6 ' on laisse les curseurs 7 et 8 en gris pour le moment
                    NomduSon.Item(i).BackColor = Color.Cornsilk
                    soloVolume.Item(i).BackColor = Color.White 'CoulPRoll1
                    labelAff.Item(i).BackColor = Color.Cornsilk
                    PisteVolume.Item(i).BackColor = Color.Cornsilk ' Color.Gold    

                Case N_PisteDrums
                    NomduSon.Item(i).BackColor = CoulDrumEd
                    soloVolume.Item(i).BackColor = Color.White ' CoulDrumEd
                    labelAff.Item(i).BackColor = CoulDrumEd
                    PisteVolume.Item(i).BackColor = CoulDrumEd
            End Select

            '
            PisteVolume.Item(i).Location = New Point(5 + (i * PP), 50) 'track bar ' la valeur 57 dans le calcul de X permet de placer 2 autres Tracbar (9 et 10)
            PisteVolume.Item(i).Orientation = Orientation.Vertical
            PisteVolume.Item(i).Minimum = 0
            PisteVolume.Item(i).Maximum = 127
            PisteVolume.Item(i).Value = 100
            PisteVolume.Item(i).Size = New Size(35, 320)
            PisteVolume.Item(i).Visible = True
            PisteVolume.Item(i).Tag = i
            PisteVolume.Item(i).TickStyle = TickStyle.Both
            '
            '
            labelAff.Item(i).Location = New Point(5 + (i * PP), 27) '30  valeur du volume en haut de la trackbar
            labelAff.Item(i).Visible = True
            labelAff.Item(i).AutoSize = False
            labelAff.Item(i).TextAlign = ContentAlignment.MiddleCenter
            s.Width = PisteVolume(i).Size.Width
            s.Height = labelAff.Item(i).Size.Height
            labelAff.Item(i).Size = s

            labelAff.Item(i).Font = fnt6
            labelAff.Item(i).Text = Convert.ToString(PisteVolume.Item(i).Value)
            labelAff.Item(i).BorderStyle = BorderStyle.None
            '
            soloPiste.Item(i).Location = New Point(3 + (i * PP), 390) ' bouton solo sous les track bars
            soloPiste.Item(i).Font = New Font("Calibri", 8, FontStyle.Regular)
            soloPiste.Item(i).Size = New Size(50, 20)
            soloPiste.Item(i).BackColor = Color.Beige
            soloPiste.Item(i).Text = "SOLO"
            soloPiste.Item(i).Tag = i
            '
            soloPiste.Item(i).Visible = False
            '
            labelVolume.Item(i).Location = New Point(7 + (i * PP), 420) ' label nom des track bar en bas des track bars
            labelVolume.Item(i).Visible = True
            labelVolume.Item(i).Font = fnt6
            labelVolume.Item(i).AutoSize = True ' New Size(55, 20)
            If Module1.LangueIHM = "fr" Then
                If (i + 1) <> 5 Then
                    labelVolume.Item(i).Text = "Piste" + Str(i + 1)
                Else
                    labelVolume.Item(i).Text = "Piste 10"
                End If
            Else
                If (i + 1) <> 5 Then
                    labelVolume.Item(i).Text = "Track" + Str(i + 1)
                Else
                    labelVolume.Item(i).Text = "Track 10"
                End If
            End If
            '
            'AddHandler PisteVolume.Item(i).MouseDown, AddressOf PisteVolume_MouseDown
            AddHandler PisteVolume.Item(i).Scroll, AddressOf PisteVolume_Scroll
            'AddHandler soloVolume.Item(i).MouseUp, AddressOf soloVolume_MouseUp
            AddHandler soloVolume.Item(i).CheckedChanged, AddressOf soloVolume_CheckedChanged
            AddHandler soloPiste.Item(i).MouseUp, AddressOf soloPiste_MouseUp

        Next i

        Panneau.Panel2.Controls.Add(Titre)

        ' Activation de la table de mixage
        ' ********************************
        RemoveHandler AutorisVol.MouseClick, AddressOf AutorisVol_MouseClick
        AutorisVol.Checked = False
        AddHandler AutorisVol.MouseClick, AddressOf AutorisVol_MouseClick
        VolumesEnabled(False)

        ' Titre des pistes HyperArp
        ' 
        Titre.Location = New Point(5, 3)
        Titre.Visible = True
        Titre.AutoSize = False
        Titre.BackColor = Color.DarkKhaki
        Titre.ForeColor = Color.DarkRed
        Titre.Size = New Size(530, 25)
        Titre.TextAlign = ContentAlignment.TopCenter
        Titre.Font = fnt9
        Titre.Text = "Piste Accords"
        Titre.BringToFront()
        Titre.Visible = False
    End Sub
    Public Sub NomduSon_TextChanged(sender As Object, e As EventArgs)
        Dim com As TextBox = sender
        Dim ind As Integer
        ind = Val(com.Tag)
        Dim canal As Integer = ind
        Dim k As Integer
        Dim a As String

        ' Retrait des séparateurs interdits
        If InStr(Trim(NomduSon.Item(ind).Text), ",") <> 0 Or InStr(Trim(NomduSon.Item(ind).Text), "&") <> 0 Then ' on retire les caractères qui peuvent servir de séparateurs
            k = NomduSon.Item(ind).SelectionStart
            a = NomduSon.Item(ind).Text.Replace(",", "")
            NomduSon.Item(ind).Text = Trim(a)
            a = NomduSon.Item(ind).Text.Replace("&", "")
            NomduSon.Item(ind).Text = Trim(a) '
            NomduSon.Item(ind).SelectionStart = k - 1
        End If
        '
        ' Mise à jour du nom son dans les autres onglets : PianoRoll, etc..
        Select Case canal
            Case N_PisteAcc ' nom du son des accords HyperVoicing
                RemoveHandler Form1.NomduSon.TextChanged, AddressOf Form1.NomduSon_TextChanged
                Form1.NomduSon.Text = Trim(NomduSon.Item(ind).Text)
                AddHandler Form1.NomduSon.TextChanged, AddressOf Form1.NomduSon_TextChanged

            Case N_PistePianoR1, N_PistePianoR2, N_PistePianoR3, N_PistePianoR4, N_PistePianoR5, N_PistePianoR6  'piano roll
                RemoveHandler Form1.listPIANOROLL.Item(ind - 1).NomduSon.TextChanged, AddressOf Form1.listPIANOROLL.Item(ind - 1).NomduSon_TextChanged
                Form1.listPIANOROLL.Item(ind - 1).NomduSon.Text = Trim(NomduSon.Item(ind).Text)
                AddHandler Form1.listPIANOROLL.Item(ind - 1).NomduSon.TextChanged, AddressOf Form1.listPIANOROLL.Item(ind - 1).NomduSon_TextChanged
                ' Maj nom du son dans les onglets
                'b = Trim(NomduSon.Item(ind).Text)
                'If Len(b) > 8 Then
                ' b = Microsoft.VisualBasic.Left(b, 8)
                'End If
                ''
                'If Trim(b) = "" Then
                'b = "PianoRoll"
                'End If
                ''
                'a = Trim((ind + 1).ToString + " - " + Trim(b))
                'Form1.TabControl4.TabPages.Item(ind).Text = a
                ''
                Maj_NomOnglet(Trim(NomduSon.Item(ind).Text), ind)
        End Select
    End Sub
    Sub PisteVolume_Scroll(sender As Object, e As EventArgs)
        Dim com As TrackBar = sender
        Dim pst As Integer
        Dim canal As Byte

        pst = Val(com.Tag)

        If EnChargement = False Then
            Dim volume As Byte = CByte(PisteVolume.Item(pst).Value)
            labelAff.Item(pst).Text = Convert.ToString(volume)
            canal = Convert.ToByte(pst) 'LesPistes.Item(pst).Canal
            If Not (Form1.SortieMidi.Item(Form1.ChoixSortieMidi).IsOpen) Then
                Form1.SortieMidi.Item(Form1.ChoixSortieMidi).Open()
            End If
            Form1.SortieMidi.Item(Form1.ChoixSortieMidi).SendControlChange(canal, CVolume, volume)
        End If
    End Sub
    Sub soloVolume_CheckedChanged(sender As Object, e As EventArgs) ' contenu mis en commentaires lors insertion Pianoroll, drumedit et mix
        Dim com As CheckBox = sender
        Dim ind As Integer
        ind = Val(com.Tag)
        Dim b As Boolean = soloVolume.Item(ind).Checked
        ''
        If b Then
            'PisteVolume.Item(ind).Enabled = True
            'RétablirVolume(ind)
        Else
            'PisteVolume.Item(ind).Enabled = False
            'CouperVolume(ind)
        End If
        ''

        If ind > 0 And ind < 4 Then
            'RemoveHandler Form1.listPIANOROLL.Item(i).CheckMute.CheckedChanged, AddressOf Form1.listPIANOROLL(i).CheckMute_CheckedChanged
            'Form1.listPIANOROLL(i).PMute = soloVolume.Item(ind).Checked
            'AddHandler Form1.listPIANOROLL.Item(i).CheckMute.CheckedChanged, AddressOf Form1.listPIANOROLL(i).CheckMute_CheckedChanged
        Else
            If ind = 4 Then
                'RemoveHandler Form1.Drums.CheckMute.CheckedChanged, AddressOf Form1.Drums.CheckMute_CheckedChanged
                'Form1.Drums.PMute = soloVolume.Item(ind).Checked
                'AddHandler Form1.Drums.CheckMute.CheckedChanged, AddressOf Form1.Drums.CheckMute_CheckedChanged
            End If
        End If

    End Sub
    Sub RétablirVolume(pst As Integer)
        Dim canal As Byte
        If EnChargement = False Then
            Dim volume As Byte = CByte(PisteVolume.Item(pst).Value)
            labelAff.Item(pst).Text = Convert.ToString(volume)
            canal = Convert.ToByte(pst) 'LesPistes.Item(pst).Canal
            If Not (Form1.SortieMidi.Item(Form1.ChoixSortieMidi).IsOpen) Then
                Form1.SortieMidi.Item(Form1.ChoixSortieMidi).Open()
            End If
            Form1.SortieMidi.Item(Form1.ChoixSortieMidi).SendControlChange(canal, 7, volume)
        End If
    End Sub
    Sub CouperVolume(pst As Integer)
        Dim canal As Byte
        If EnChargement = False Then
            Dim volume As Byte = 0
            labelAff.Item(pst).Text = Convert.ToString(volume)
            canal = Convert.ToByte(pst) 'LesPistes.Item(pst).Canal
            If Not (Form1.SortieMidi.Item(Form1.ChoixSortieMidi).IsOpen) Then
                Form1.SortieMidi.Item(Form1.ChoixSortieMidi).Open()
            End If
            Form1.SortieMidi.Item(Form1.ChoixSortieMidi).SendControlChange(canal, 7, volume)
        End If
    End Sub
    Public Sub GestMute()
        ' sauvegarde/restit état des mutes
        ' ********************************
        If Form1.PisteSolo = -1 Then
            LSauvMute.Clear()
            For i = 0 To PisteVolume.Count - 1
                LSauvMute.Add(soloVolume.Item(i).Checked)
            Next i
        Else
            For i = 0 To PisteVolume.Count - 1
                soloVolume.Item(i).Checked = LSauvMute.Item(i)
            Next i
        End If
    End Sub
    Sub soloPiste_MouseUp(sender As Object, e As EventArgs) ' bouton solo de la piste
        Dim com As Button = sender
        Dim ind As Integer
        '
        ind = Val(com.Tag)
        '
        GestMute()
        ' Gestion de la table de mixage
        Gestion_Solo2(ind) ' on transmet le canal MIDI

        ' Gestion des solo de HyperArp, PianoRoll et Batterie
        Select Case ind
            Case 1
               ' La Piste accord n' qu'un seul Mute dans la table de mixage

            Case 2, 3, 4 ' --> PianoRoll
                'i = ind - 1
                'If i >= 10 Then
                'i = ind - 7
                'End If
                'Form1.listPIANOROLL(i).TraitementSoloPR(ind)

            Case 5 ' --> Batterie
                'Form1.Drums.TraitementSoloDRM(ind)
        End Select

    End Sub
    ''' <summary>
    ''' Gestion_Solo :procédure réservée pour la gestion des solos à partir de la table de mixage
    ''' </summary>
    ''' <param name="ind"></param>
    Public Sub Gestion_Solo(ind As Integer)
        Dim i As Integer

        If ind <> Form1.PisteSolo Then ' activation du mode solo
            For i = 0 To PisteVolume.Count - 1
                If i <> ind Then
                    PisteVolume.Item(i).Enabled = False  ' PisteVolume est le trackbar du volume
                    soloVolume.Item(i).Checked = False   ' soloVolume est le checkbox d'activation d'une tranche placé en haut des trackbar
                    CouperVolume(i)
                End If
            Next
            PisteVolume.Item(ind).Enabled = True
            soloVolume.Item(ind).Checked = True
            Form1.PisteSolo = ind
            RétablirVolume(ind)
            '
            soloPiste.Item(ind).BackColor = Color.OrangeRed
            soloPiste.Item(ind).ForeColor = Color.Yellow
        Else                  ' rétablissement du mode normal
            For i = 0 To PisteVolume.Count - 1
                PisteVolume.Item(i).Enabled = True
                soloVolume.Item(i).Checked = True
                RétablirVolume(i)
            Next
            Form1.PisteSolo = -1
            '
            soloPiste.Item(ind).BackColor = Color.Beige
            soloPiste.Item(ind).ForeColor = Color.Black
        End If
    End Sub

    ''' <summary>
    ''' Gestion_Solo2 : procédure réservée pour la gestion des solos des pistes HyperArp (1-6) à partir d'HyperArp, PianoRoll et Batterie
    ''' </summary>
    ''' <param name="ind">Index de la piste dand la table de mixage</param>
    Public Sub Gestion_Solo2(ind As Integer)
        Dim i As Integer
        Dim j As Integer


        j = Form1.PisteSolo ' piste solo contient la piste actuellement en solo - si pas de pistes actuellement en solo alors PisteSolo=-1
        If ind <> Form1.PisteSolo Then ' activation du mode solo
            For i = 0 To PisteVolume.Count - 1 ' ici il n'existe pas de piste déjà en mode solo
                'If i <> ind - 1 Then
                PisteVolume.Item(i).Enabled = False  ' PisteVolume est le trackbar du volume
                'soloVolume.Item(i).Checked = False   ' soloVolume est le checkbox d'activation d'une tranche placé en haut des trackbar
                soloPiste.Item(i).Enabled = False     '  sauvegarde de l'état des mutes
                CouperVolume(i) ' on commence par couper tous les volumes
                'End If
            Next
            ' on rétablit le volume de la piste en solo
            Form1.PisteSolo = ind
            ind = ind
            PisteVolume.Item(ind).Enabled = True
            soloVolume.Item(ind).Checked = True
            soloPiste.Item(ind).Enabled = True
            soloPiste.Item(ind).BackColor = Color.Red
            soloPiste.Item(ind).ForeColor = Color.Yellow
            RétablirVolume(ind)
        Else                  ' rétablissement du mode normal : annulation du mode solo sur ind
            For i = 0 To PisteVolume.Count - 1 '
                PisteVolume.Item(i).Enabled = True
                soloPiste.Item(i).Enabled = True
                If soloVolume.Item(i).Checked = True Then
                    RétablirVolume(i)
                End If
            Next
            ind = ind
            soloPiste.Item(ind).BackColor = Color.Beige
            soloPiste.Item(ind).ForeColor = Color.Black
            Form1.PisteSolo = -1
        End If

    End Sub
    Public Function ListVolumesMix() As String
        Dim a As String = "MixListVolumes,"
        Dim i As Integer

        For i = 0 To PisteVolume.Count - 1
            a = a + PisteVolume.Item(i).Value.ToString + ","
        Next i
        a = Microsoft.VisualBasic.Left(a, a.Length - 1)
        Return a
    End Function

    Public Sub Maj_ListVolumesMix(ListVolumes As String)
        Dim tbl() As String
        Dim i As Integer = -1
        tbl = ListVolumes.Split(",")
        '
        For Each a As String In tbl
            If IsNumeric(a) Then
                i = i + 1
                PisteVolume.Item(i).Value = Convert.ToDecimal(a)
                labelAff.Item(i).Text = Trim(a)
            End If
        Next
    End Sub
    Public Function ListMute() As String
        Dim a As String = "MixListMute,"
        Dim i As Integer

        For i = 0 To soloVolume.Count - 1
            a = a + soloVolume.Item(i).Checked.ToString + ","
        Next i
        a = Microsoft.VisualBasic.Left(a, a.Length - 1)
        Return a
    End Function
    Public Sub Maj_ListMute(ListMute As String)
        Dim tbl() As String
        Dim i As Integer = -1
        tbl = ListMute.Split(",")
        '
        For Each a As String In tbl
            i = i + 1
            If Trim(tbl(i)) <> "MixListMute" Then
                If Trim(tbl(i)) = "True" Then
                    RemoveHandler soloVolume.Item(i - 1).CheckedChanged, AddressOf soloVolume_CheckedChanged
                    soloVolume.Item(i - 1).Checked = True
                    PisteVolume.Item(i - 1).Enabled = True
                    AddHandler soloVolume.Item(i - 1).CheckedChanged, AddressOf soloVolume_CheckedChanged
                Else
                    RemoveHandler soloVolume.Item(i - 1).CheckedChanged, AddressOf soloVolume_CheckedChanged
                    soloVolume.Item(i - 1).Checked = False
                    PisteVolume.Item(i - 1).Enabled = False
                    AddHandler soloVolume.Item(i - 1).CheckedChanged, AddressOf soloVolume_CheckedChanged
                End If
            End If
        Next
        '
    End Sub
    Public Function AutorisVolumes() As String
        Dim a As String = "AutorisVolumes,"
        '
        a = a + AutorisVol.Checked.ToString()
        Return a
    End Function
    Public Sub Maj_AutorisVolumes(autorisV As String)
        Dim tbl() As String

        RemoveHandler AutorisVol.MouseClick, AddressOf AutorisVol_MouseClick
        tbl = autorisV.Split(",")
        If tbl(1) = "True" Then
            AutorisVol.Checked = True
            VolumesEnabled(True)
        Else
            AutorisVol.Checked = False
            VolumesEnabled(False)
        End If
        AddHandler AutorisVol.MouseClick, AddressOf AutorisVol_MouseClick
    End Sub
    '
    Public Sub VolumesEnabled(act As Boolean)
        '
        Moins5.Enabled = act
        Plus5.Enabled = act
        Max.Enabled = act
        Tous.Enabled = act

        For i = 0 To PisteVolume.Count - 1
            PisteVolume.Item(i).Enabled = act
        Next
        '
        For i = 0 To soloVolume.Count - 1 ' soloVolume =Mute 
            soloVolume.Item(i).Enabled = True ' Mute toujours utilisable
        Next
        If act Then
            AutorisVol.BackColor = Color.BurlyWood
            AutorisVol.ForeColor = Color.Black
        Else
            AutorisVol.BackColor = Color.Red
            AutorisVol.ForeColor = Color.Yellow
        End If

    End Sub
End Class
