Module MoteurMIDI


    ' ***********
    ' * CLASSES *
    ' ***********
    ' Classe utilisée par l'export MIDI : détermine le nombre de pistes à créer dans le fichier MIDI
    Class NbPistesUtiles
            Public Nb As Integer ' nombre de pistes utilisées
        Public TPisteUtil(0 To nb_TotalPistes) As Boolean ' table des pistes utilisées (booleen indique si la piste est utilisée ou non)


        ''' <summary>
        ''' Constructeur de la classe 
        ''' cette classe sert à déterminier le nombre
        ''' de pistes utilies qu'il est nécessaire de connaître pour la création d'un fichier MIDI.
        ''' REMARQUE : cette classe analyse l'état de "Mute"  des pistes pour déterminer si elles sont utilisées ou non
        ''' </summary>
        Public Sub New()
            Dim i As Integer
            Dim NotesAcc() As String = {String.Empty} ' notes des accords
            Dim MagnétoAcc() As String = {String.Empty} ' Numéros des magnéto


            ' Initialisation du nombre de pistes utiles
            ' ****************************************
            Nb = 0
            For i = 0 To (TPisteUtil).Count - 1
                TPisteUtil(i) = False
            Next


            ' 1 - Piste Acccords
            ' ******************
            TPisteUtil(N_PisteAcc) = True

            ' 2 - Détermination de l'activitéde des pistes pianoroll
            ' ******************************************************
            For i = 1 To nb_PianoRoll
                TPisteUtil(i) = True 'Form1.listPIANOROLL(i).PMute
            Next
            '
            ' 3 - Détermination de l'activité de la piste de Batterie
            ' *******************************************************
            TPisteUtil(N_PisteDrums) = True 'Form1.Drums.PMute

            ' 3 - RESULTAT : Détermination du nombre de pistes utilisées
            ' **********************************************************
            For i = 0 To UBound(TPisteUtil)
                If TPisteUtil(i) Then Nb = Nb + 1 ' Nb est une propriété publique de la classe qui donne le nombre de piste utilzs
            Next i
        End Sub
        End Class

        ' Classe Partition
        ' ****************
        Public Class Partition
            Public Tempo As String = String.Empty
            Public Métrique = String.Empty
            Public NomFichier As String = String.Empty
        ' Public ReadOnly Nb_Magnetos As Integer = 7
        ' Public ReadOnly Nb_PistesMidi As Integer = NombrePistes - 2 ' cette info fournit l'index de la dernière piste
        ' Public ReadOnly Nb_Pistes As Integer = Nb_Magnetos * 6 ' Pistes (dans NB_Pistes) est pris ici au sens de générateurs
        ' Public ReadOnly nbMesures As Integer = 48
        Public NumAccords As New AffAcc

        Class AffAcc
                Public NumAcc As New List(Of String)
                Public LectEcr As Boolean
                Public PointeurLect As Integer
            End Class
            '
            ' **********************************************************************
            ' Récup_NumAcc : récupération du N° du 1er accord devant être joué     *
            ' **********************************************************************
            Public ReadOnly Property PAcc(num As Integer) As Integer
                Get
                    Dim i As Integer = Me.NumAccords.NumAcc(num)
                    Return i
                End Get
            End Property
            Public Sub New(oMétrique As String, oNomFichier As String) ' oTempo As String,
                'Tempo = Form1.Tempo.Value.ToString
                Métrique = oMétrique
                NomFichier = oNomFichier
            End Sub
        End Class
        ' Classe DEBUG : outils de debug
        '        *****   ***************
        Public Class DbgParNotes
            Public durée As String
            Public note As String
            Public dyn As String
            Public canal As String
            Public numPiste As String
            Public position As String
        End Class

        ''' <summary>
        ''' CLASSE PISTE : La classe PISTE de décomposer le travail de génération du fichier MIDI et du Scheduler MIDI. Les notes
        ''' et les contrôleuers sont placées dans la liste .part de cette classe sous un format "propriétaire" qui est utilisé p
        ''' our la génération MIDI.
        ''' </summary>
        Public Class Piste
            ' Constantes
            ' **********
            Public ValNote As New List(Of String) From {
                   "C-1", "C#-1", "D-1", "D#-1", "E-1", "F-1", "F#-1", "G-1", "G#-1", "A-1", "A#-1", "B-1",
                   "C0", "C#0", "D0", "D#0", "E0", "F0", "F#0", "G0", "G#0", "A0", "A#0", "B0",
                    "C1", "C#1", "D1", "D#1", "E1", "F1", "F#1", "G1", "G#1", "A1", "A#1", "B1",
                    "C2", "C#2", "D2", "D#2", "E2", "F2", "F#2", "G2", "G#2", "A2", "A#2", "B2",
                    "C3", "C#3", "D3", "D#3", "E3", "F3", "F#3", "G3", "G#3", "A3", "A#3", "B3",
                    "C4", "C#4", "D4", "D#4", "E4", "F4", "F#4", "G4", "G#4", "A4", "A#4", "B4",
                    "C5", "C#5", "D5", "D#5", "E5", "F5", "F#5", "G5", "G#5", "A5", "A#5", "B5",
                    "C6", "C#6", "D6", "D#6", "E6", "F6", "F#6", "G6", "G#6", "A6", "A#6", "B6",
                    "C7", "C#7", "D7", "D#7", "E7", "F7", "F#7", "G7", "G#7", "A7", "A#7", "B7",
                    "C8", "C#8", "D8", "D#8", "E8", "F8", "F#8", "G8", "G#8", "A8", "A#8", "B8",
                    "C9", "C#9", "D9", "D#9", "E9", "F9", "F#9", "G9"}

            Public ValNoteCubase As New List(Of String) From {
                   "C-2", "C#-2", "D-2", "D#-2", "E-2", "F-2", "F#-2", "G-2", "G#-2", "A-2", "A#-2", "B-2",
                   "C-1", "C#-1", "D-1", "D#-1", "E-1", "F-1", "F#-1", "G-1", "G#-1", "A-1", "A#-1", "B-1",
                   "C0", "C#0", "D0", "D#0", "E0", "F0", "F#0", "G0", "G#0", "A0", "A#0", "B0",
                    "C1", "C#1", "D1", "D#1", "E1", "F1", "F#1", "G1", "G#1", "A1", "A#1", "B1",
                    "C2", "C#2", "D2", "D#2", "E2", "F2", "F#2", "G2", "G#2", "A2", "A#2", "B2",
                    "C3", "C#3", "D3", "D#3", "E3", "F3", "F#3", "G3", "G#3", "A3", "A#3", "B3",
                    "C4", "C#4", "D4", "D#4", "E4", "F4", "F#4", "G4", "G#4", "A4", "A#4", "B4",
                    "C5", "C#5", "D5", "D#5", "E5", "F5", "F#5", "G5", "G#5", "A5", "A#5", "B5",
                    "C6", "C#6", "D6", "D#6", "E6", "F6", "F#6", "G6", "G#6", "A6", "A#6", "B6",
                    "C7", "C#7", "D7", "D#7", "E7", "F7", "F#7", "G7", "G#7", "A7", "A#7", "B7",
                    "C8", "C#8", "D8", "D#8", "E8", "F8", "F#8", "G8"}

            ' Attributs
            ' *********
            Public part As New List(Of String)
            ' Propriétés
            ' **********
            ' Piste
            Public NumPiste As Byte = 0
            Public NomPiste As String = String.Empty
            ' 
            Public PositCours As Integer = 0
            Public Début As Integer ' exprimé en nombre de doubles croches (= 0 si départ immédiat, ensuite on part toujours en début d'une autre mesure jamais au milieu d'une mesure)
            Public intervAccent As Integer = 4
            Public valeurAccent As Integer = 10
            Public actifAccent As Boolean = False
            Public NbEvts As Double = -1 '

            ' MIDI
            Public Marq As New List(Of String)
            Public Mute As New List(Of Boolean)
            Public Motifs As New List(Of String)
            Public Durée As New List(Of Double) 'Public DuréeNote As Double = SN ' DuréeNote
            Public Octave As New List(Of Integer)
            Public Volume As Byte = 0
            Public Dyn As New List(Of Byte)
            Public PRG As New List(Of Integer) ' on utilise integer pour gérer off=-1 - piano acc par défaut
            Public Canal As Byte = 0
            Public PAN As New List(Of Byte)
            Public Accent As New List(Of String)
            Public Souche As New List(Of Byte)
            Public Delay As New List(Of Boolean)
            Public DébutSouche As New List(Of Boolean)
            Public Retard As New List(Of Byte)
            Public Start As Integer
            '
            Public LongDerNote As New List(Of Integer)
            Public DelayAvant As Boolean = False
            '
            ' Autres Variables 
            Private SilenceDéjàCompt As Boolean = False
        Public Répétition As Integer
        Public PrésenceNotes As Boolean = False



        '
        Public DbgTabNotes As New List(Of DbgParNotes)
            '
            ' Constructeur
            ' ************
            Public Sub New(NomPiste As String, NumPiste As Byte, Canal As Byte)
                Me.NomPiste = Trim(NomPiste)
                Me.NumPiste = NumPiste
            Me.Canal = Canal ' No canal = No Piste sauf batterie
        End Sub

        ' Méthodes
        ' ********
        Public Sub AddPRG(Position As String, ValPRG As String)
            Dim numPRG As Integer = Convert.ToInt32(ValPRG)
            If numPRG <> -1 Then
                Me.part.Add("PRG" + " " + Trim(Str(Me.NumPiste)) + " " + Trim(Str(Me.Canal)) + " " + Trim(Position) + " " + Trim(Str(numPRG)))
            End If
        End Sub
        '
        Public Sub AddCTRL(Position As String, NumCTRL As String, ValCTRL As String, Magnéto As Integer)
            Select Case Convert.ToInt16(NumCTRL)
                Case CVolume 'volume
                    'If Me.Mute(Magnéto) = True Then ValCTRL = 0
                    Me.part.Add("CTRL" + " " + Trim(Str(Me.NumPiste)) + " " + Trim(Str(Me.Canal)) + " " + Trim(Position) + " " + Trim(NumCTRL) + " " + Trim(ValCTRL))

                Case CPAN
                    Me.part.Add("CTRL" + " " + Trim(Str(Me.NumPiste)) + " " + Trim(Str(Me.Canal)) + " " + Trim(Position) + " " + Trim(NumCTRL) + " " + Trim(ValCTRL))
                Case Else
            End Select
        End Sub

        Public Sub AddMarq(marq As String, PisteNonMute As Byte)
            Me.part.Add("MRQ" + " " + marq + " " + Convert.ToString(Me.PositCours))
        End Sub
        Public Sub AddAcc(Chiff As String, Numacc As Integer) ' As String
                Dim a As String
                Chiff = Chiff.Replace(" ", "")
                a = "Acc" + " " + Chiff + " " + Convert.ToString(Me.NumPiste) + " " + Convert.ToString(Numacc) + " " + Convert.ToString(Me.PositCours)
                Me.part.Add(a)
            End Sub
            Private Function CalcOctave(Octave As Integer, valeurNote As Integer) As Byte
                Dim OctNote As Integer = 0
                CalcOctave = CByte(valeurNote)

                OctNote = valeurNote + Octave
                If Not (OctNote < 0 Or OctNote > 127) Then
                    CalcOctave = CByte(OctNote)
                End If
                'End If
            End Function
            Public Function Det_PositionPrésente() As Integer
                Dim i As Integer
                Dim tbl() As String

                Det_PositionPrésente = 0
                i = IndexNotePrécédente() ' note précédente
                If i <> -1 Then ' avant le 1er enregistrement dans part count = 0 donc Me.part.Count - 1 = -1
                    tbl = Split(part(i))
                    Det_PositionPrésente = Val(tbl(4))
                End If
            End Function
            Public Function Det_Position(Delay As Boolean) As Integer
                Dim i As Integer
                Dim SommeSilences As Integer = 0
                Dim tbl() As String

                Det_Position = 0
                i = IndexNotePrécédente() ' note précédente
                If i <> -1 Then ' avant le 1er enregistrement dans part count = 0 donc Me.part.Count - 1 = -1 --> Det_Position = 0
                    tbl = Split(part(i))
                    Det_Position = Val(tbl(4)) + Val(tbl(5)) '+ SommeSilences 'Position=position derniere note+Durée dernière note+ mesures de silences précédentes
                Else ' position 1ere note
                    Det_Position = 0 ' + SommeSilences
                    If Delay Then Det_Position = 1 ' + SommeSilences
                End If
                '
                Me.PositCours = Det_Position
            End Function

        Function IndexNotePrécédente() As Integer
            Dim i As Integer
            Dim tbl() As String
            IndexNotePrécédente = -1
            For i = Me.part.Count - 1 To 0 Step -1
                tbl = Split(part(i))
                If Trim(tbl(0)) = "Note" Then
                    IndexNotePrécédente = i
                    Exit For
                End If
            Next i
        End Function
    End Class
        '
        ' *********************************************************
        ' *                                                       *
        ' *                FIN DE DELA CLASSE PISTE               *
        ' *                                                       *
        ' *********************************************************


        ' *********************************************************
        ' *                                                       *
        ' *                DEBUT DU MODULE MAINARP                *
        ' *                                                       *
        ' *********************************************************

        ' ***************************
        ' * VARIABLES ET CONSTANTES *
        ' ***************************
        ' Valeur de durée de notes
        Public Const WN = 4
        Public Const HN = 2
        Public Const QN = 1
        Public Const EN = 0.5
        Public Const SN = 0.25
        '
        Public Const RN = 4
        Public Const BL = 2
        Public Const NR = 1
        Public Const CR = 0.5
        Public Const DC = 0.25

        ' Valeurs de dynamique
        Public Const FFF = 120
        Public Const FF = 100
        Public Const F = 85
        Public Const MF = 70
        Public Const MP = 60
        Public Const P = 50
        Public Const PP = 25
        Public Const PPP = 10



    Public Const QNvSN = 4 ' nombre de double croches dans une noire
    'Public Const TN = 0.125

    ' Liste des notes MIDI
    ' ********************
    ' Remarques sur utilisation
    '   Récupératuin du n0 de note MIDI
    '   Dim i As Byte
    '   i = ValNote.IndexOf("F9")

    '
    Public Arrangement1 As New Partition("4/4", "HyperVoicing")
    Public part As New List(Of String)
    Public LesPistes As New List(Of Piste) ' les objets LesPistes sont créées à la fin de Pistes_Création dans form1
    Dim nbMesuresUtiles As Integer
    '
    Dim Numérateur As Integer
        Dim Dénominateur As Integer
        Dim DivisionMes As Integer

    ' NOTES
    ' Syntaxe des notes dans .part de "Les Pistes"
    '     | "Note" | NumPiste | Canal | Valeur Note | début | durée | Vélocité |
    ' ex. | "Note" |     0    |   0   |      72     |   16  |   16  |    90    | 
    ' Les paramètres 'début et 'durée' sont exprimés en nombre de double croches
    ' dans l'ex. la note est une ronde commençant à la mesure 2 (le début commence à 0).

    ' CTRL
    ' Syntaxe des controleurs dans .part de "Les Pistes"
    '     | "CTRL" | NumPiste | Canal | début | N° CTRL | Valeur |
    ' ex. | "CTRL" |     6    |   6   |  0    |   7     |   16   |

    ' PRG
    ' Syntaxe des Programmes dans .part de "Les Pistes"
    '     | "PRG" | NumPiste | Canal | début | N° PRG |
    ' ex. | "PRG" |     6    |   6   |  0    |   7    |

    Public Sub CalculMusique(Midifi As Boolean)
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim PositFin As String = ""
        Dim motif_acc1 As String = String.Empty
        '
        Dim ii As Integer
        Dim VolumeEnvoyé As Boolean = False
        '
        ' Métrique
        ' ********
        Numérateur = Det_Numérateur(Form1.Métrique.Text)
        Dénominateur = Det_Dénominateur(Form1.Métrique.Text)
        DivisionMes = Det_DivisionMes()
        '
        ' Ajustement des locators
        ' ***********************
        'locator Terme
        'Dim loc As Integer = Form1.Det_NumDerAccord()
        'Dim Allonge As Integer = 32
        '
        ' INITIALISATIONS
        ' ***************
        Arrangement1.NumAccords.NumAcc.Clear()
        Arrangement1.NumAccords.LectEcr = True
        '
        ' Syntaxe des notes dans .part de "Les Pistes"
        '     | "Note" | NumPiste | Canal | Valeur Note | début | durée | Vélocité |
        ' ex. | "Note" |     6    |   6   |      72     |   16  |   16  |    90    | 
        ' Les paramètres 'début et 'durée' sont exprimés en nombre de double croches
        ' dans l'ex. la note est une ronde commençant à la mesure 2
        '

        Dim aa As String = ""
        Dim b, c As Boolean
        Dim tbl() As String
        '
        Dim Boucle As Integer = Convert.ToInt16(Transport.LoopNumber.Value)
        Dim ExtFin As Integer = 0
        If Midifi Then Boucle = 1
        '
        If Boucle = 1 And TermeFin = Form1.Det_DerEventH Then
            ExtFin = Transport.LFinal.Value - 1
        End If
        If Midifi Then
            TermeFin = Form1.Det_DerMesure()
            Transport.Terme.Value = TermeFin
        End If
        PositFin = (((((TermeFin - Transport.Début.Value) + 1) * 16)) * Boucle) + (Transport.LFinal.Value * 16)
        '
        ' Mise à jour de la piste des Accords
        ' ***********************************
        If Form1.Mix.soloVolume.Item(0).Checked = True Then
            LesPistes.Item(0).part.Clear()
            LesPistes.Item(0).PrésenceNotes = True ' il y a toujours au moins 1 accord dans la piste Accord
            aa = Form1.Contruction_ListeNotesAcc(TermeFin, Midifi) ' le stacking est géré ici dans Contruction_ListeNotesAcc 
            If Trim(aa) <> "" Then
                tbl = aa.Split("-")
                LesPistes.Item(0).PrésenceNotes = True
                For i = 0 To UBound(tbl)
                    LesPistes.Item(0).part.Add(tbl(i))
                Next i
            End If
        End If
        '
        LesPistes.Item(0).part.Add("FIN" + " " + Convert.ToString(LesPistes.Item(0).NumPiste) + " " + Convert.ToString(PositFin))
        '
        ' Mise à jour des pistes des Pianoroll et drumedit
        ' ************************************************
        For j = 1 To (nb_PianoRoll + nb_DrumEdit)
            LesPistes.Item(j).part.Clear()
            aa = ""
            If j <= (nb_PianoRoll) Then 'traitement des piano roll 
                If Form1.Mix.soloVolume.Item(j).Checked = True Then ' si =true c'est non muet
                    b = Form1.PIANOROLLChargé(j - 1)
                    c = Form1.listPIANOROLL(j - 1).PMute
                    ' aa = Form1.listPIANOROLL(j - 1).PListNotes(Form1.Répéter.Checked, Boucle, Form1.Début.Value, Form1.Terme.Value, nbMesures - 1) ' Form1.Terme.Value
                    aa = Form1.listPIANOROLL(j - 1).PListNotes(Transport.Répéter.Checked, Boucle, Transport.Début.Value, TermeFin + ExtFin, nbMesures - 1)
                    LesPistes.Item(j).PrésenceNotes = Form1.listPIANOROLL(j - 1).PPresNotes
                End If
            Else ' traitement de la piste batterie

                If j = (nb_PianoRoll + nb_DrumEdit) Then ' traitement du DrumEdit '  
                    'aa = Form1.Drums.PListNotes(Form1.Répéter.Checked, Boucle, Form1.Début.Value, Form1.Terme.Value, nbMesures - 1)
                    aa = Form1.Drums.PListNotes(Transport.Répéter.Checked, Boucle, Transport.Début.Value, TermeFin, nbMesures - 1)
                    LesPistes.Item(j).PrésenceNotes = Form1.Drums.PPresNotes
                End If
            End If
            If Trim(aa) <> "" Then
                tbl = aa.Split("-")
                For i = 0 To UBound(tbl)
                    LesPistes.Item(j).part.Add(tbl(i))
                Next i
            End If
            ' écriture de "FIN"
            LesPistes.Item(j).part.Add("FIN" + " " + Convert.ToString(LesPistes.Item(j).NumPiste) + " " + Convert.ToString(PositFin))
        Next j
        '
        ' CREATION DU FICHIER MIDI
        ' ************************
        Dim Ob As New NbPistesUtiles
        Dim Origine As String = "" ' pour debug dans le catch
        Try
            If Midifi Then
                Dim NPisteStack As Integer = Det_nbPistesAvecnotes()
                Dim tbl2(nbMesures) As String
                'Dim Midifile1 As New MidifileX(96, Ob.Nb + 1, Module1.nbMesures) '
                Dim Midifile1 As New MidifileX(480, NPisteStack + 1, Module1.nbMesures) '
                Midifile1.AddTempo(Transport.Tempo.Value.ToString)
                Midifile1.AddMétrique(Arrangement1.Métrique)
                Midifile1.AddNomFichier(Arrangement1.NomFichier)
                Dim PsteMidF As Integer = -1
                ' Ajout des éléments MIDI
                k = 0 ' pour comptage du nombre de pistes
                For i = 0 To nb_TotalPistes - 1 ' 
                    If LesPistes.Item(i).PrésenceNotes Then ' Ob.TPisteUtil(i) And
                        PsteMidF = PsteMidF + 1
                        Midifile1.AddNomPiste(PsteMidF, Det_NomPisteMIDI2(i)) ' 
                        For j = 0 To LesPistes.Item(i).part.Count - 1
                            tbl2 = Split(LesPistes.Item(i).part(j))

                            Select Case tbl2(0)
                                Case "Note"
                                    ii = Val(tbl2(3))
                                    '                      piste      canal          note        debut        durée         velo
                                    If Val(tbl2(2)) >= 10 Then 'si piste de stacking(n° canal>=10) alors le N° de piste = après dernière piste PianoRoll
                                        Midifile1.AddNote(NPisteStack, Val(tbl2(2)), Val(tbl2(3)), Val(tbl2(4)), Val(tbl2(5)), Val(tbl2(6)))
                                    Else '                 piste      canal          note        debut        durée         velo
                                        Midifile1.AddNote(PsteMidF, Val(tbl2(2)), Val(tbl2(3)), Val(tbl2(4)), Val(tbl2(5)), Val(tbl2(6)))
                                    End If
                                    Origine = "Note" + LesPistes.Item(i).part(j)
                                Case "CTRL" ' comprend tous les controles Volume, Panoralique etc.
                                    'If Form1.ExporterCTRL = True Then 'Form1.ExportCTRLMenu.Checked Then
                                    Midifile1.AddCTRL(PsteMidF, Val(tbl2(2)), Val(tbl2(3)), Val(tbl2(4)), Val(tbl2(5)))
                                    Origine = "CTRL" + LesPistes.Item(i).part(j)
                                'End If
                                Case "PRG"
                                    'If Form1.ExporterCTRL = True Then 'Form1.ExportCTRLMenu.Checked Then
                                    Midifile1.AddProgram(PsteMidF, Val(tbl2(2)), Val(tbl2(3)), Val(tbl2(4)))
                                    Origine = "PRG" + LesPistes.Item(i).part(j)
                                    'End If
                                Case "MRQ"
                                    Midifile1.AddMarqueur(tbl2(1), Convert.ToInt32(tbl2(2)))
                            End Select
                        Next j
                    End If
                Next i
                Midifile1.ConstruiredMidFile() ' construction du fichier MIDI
            End If

        Catch ex As Exception
            MessageHV.PContenuMess = Origine + " FIN ORIGINE " + "Détection erreur dans procédure : " + "Méthode :  Moteur MIDI/CalculMusique" + Constants.vbCrLf + "Message  : " + ex.Message
            MessageHV.PTypBouton = "OK"
            Cacher_FormTransparents()
            MessageHV.ShowDialog()
            End
        End Try

    End Sub
    Function Pos_DerNoteOff() As Integer
        Dim tbl() As String
        Dim a As String = Nothing
        Dim LPos As New List(Of Integer)
        Dim i As Integer = -1
        'For Each lst As List(Of String) in LesPistes.Item(0).part
        For i = 0 To LesPistes.Count - 1
            If LesPistes.Item(i).part.Count <> 0 Then
                a = LesPistes.Item(i).part.Item(LesPistes.Item(i).part.Count - 1)
                tbl = a.Split
                ' 'tbl2(4)=Position
                LPos.Add(Val(tbl(4)))
            End If
        Next
        If LPos.Count <> 0 Then
            LPos.Sort()
            i = LPos.Item(LPos.Count - 1) / 16
        End If
        Return i
    End Function

    Private Function Det_nbPistesAvecnotes() As Integer
        Dim i As Integer
        Dim j As Integer = 0

        For i = 0 To nb_TotalPistes - 1 ' 
            If LesPistes.Item(i).PrésenceNotes Then
                j = j + 1
            End If
        Next i
        Return j
    End Function

    Private Sub AllongeDernIerAcc(Allonge As Integer)
        Dim pos As Integer
        Dim a, c As String
        Dim i As Integer
        Dim SauvLg As String
        '
        Dim fin As Boolean = False
        pos = LesPistes.Item(0).part.Count - 2
        a = LesPistes.Item(0).part.Item(pos)
        tbl = a.Split()
        SauvLg = tbl(5) ' lecture longueur de la note
        If tbl(0) = "Note" Then
            Do
                tbl = a.Split()
                SauvLg = tbl(5) ' lecture de la longueur de la note
                i = Convert.ToInt16(tbl(5))
                i = i + Allonge ' rallongement de la note
                tbl(5) = i.ToString
                c = Join(tbl, " ")
                LesPistes.Item(0).part.Item(pos) = Trim(c)
                '
                pos = pos - 1
                a = LesPistes.Item(0).part.Item(pos)
                tbl = a.Split()
                If SauvLg <> tbl(5) Then fin = True
            Loop Until fin = True
        End If
    End Sub




    Public Sub INIT_LesPistes()
        Dim i As Integer

        LesPistes.Clear()
        For i = 0 To nb_TotalPistes - 1 '
            canal = i
            'If i = 7 Then canal = 9 ' supprimer pour ajouts des volumes complémentaires dan la table de mixage
            Dim oo As New Piste("piste" + Str(i + 1), i, canal)
            LesPistes.Add(oo)
            LesPistes.Item(i).NomPiste = "Piste" + Convert.ToString(i + 1)
            LesPistes.Item(i).Start = Form1.Début.Value - 1
            LesPistes.Item(i).NumPiste = i
            'LesPistes.Item(i).Canal = i
            'If i = 4 Then LesPistes.Item(i).Canal = 9
            LesPistes.Item(i).part.Clear()
            LesPistes.Item(i).Marq.Clear()
            LesPistes.Item(i).Motifs.Clear()
            LesPistes.Item(i).Durée.Clear()
            LesPistes.Item(i).Motifs.Clear()
            LesPistes.Item(i).Volume = 0
            LesPistes.Item(i).Mute.Clear()
            LesPistes.Item(i).Octave.Clear()
            LesPistes.Item(i).PRG.Clear()
            LesPistes.Item(i).Dyn.Clear()
            LesPistes.Item(i).PAN.Clear()
            LesPistes.Item(i).Accent.Clear()
            LesPistes.Item(i).Souche.Clear()
            LesPistes.Item(i).Retard.Clear()
            LesPistes.Item(i).Delay.Clear()
            LesPistes.Item(i).DébutSouche.Clear()
            LesPistes.Item(i).LongDerNote.Clear()
            LesPistes.Item(i).DbgTabNotes.Clear()
            LesPistes.Item(i).PositCours = 0
            LesPistes.Item(i).DelayAvant = False
        Next i
    End Sub
    Function Det_NomPisteMIDI2(ii As Integer) As String

        Dim a As String

        If LangueIHM = "fr" Then
            a = "Canal"
        Else
            a = "Channel"
        End If

        Select Case ii
            Case 0
                Return "HyperVoicing" + " " + a + " " + "1"
            Case 1
                Return "PianoRoll" + " " + a + " " + "2"
            Case 2
                Return "PianoRoll" + " " + a + " " + "3"
            Case 3
                Return "PianoRoll" + " " + a + " " + "4"
            Case 4
                Return "PianoRoll" + " " + a + " " + "5"
            Case 5
                Return "PianoRoll" + " " + a + " " + "6"
            Case 6
                Return "PianoRoll" + " " + a + " " + "7"
            Case 7
                Return "PianoRoll" + " " + a + " " + "8"
            Case 8
                Return "PianoRoll" + " " + a + " " + "9"
            Case Else
                Return "DRUMS" + " " + a + " " + "10"
        End Select

    End Function

    Function Det_NomPisteMIDI(ii As Integer) As String

        Det_NomPisteMIDI = ""
        Dim NPianoRoll As Integer
        Select Case ii
            '
            Case N_PisteAcc  ' Piste accords
                If Module1.LangueIHM = "fr" Then
                    Det_NomPisteMIDI = "HyperVoicing" + Convert.ToString(ii + 1) + " " + "Canal " + Convert.ToString(ii + 1)
                Else
                    Det_NomPisteMIDI = "HyperVoicing" + Convert.ToString(ii + 1) + " " + "Channel " + Convert.ToString(ii + 1)
                End If
                '
            Case N_PistePianoR1, N_PistePianoR2, N_PistePianoR3, N_PistePianoR4, N_PistePianoR5, N_PistePianoR6  ' Pistes PianRoll
                NPianoRoll = ii - 1
                If Module1.LangueIHM = "fr" Then
                    Det_NomPisteMIDI = "PR" + Convert.ToString(NPianoRoll + 1) + " " + Form1.listPIANOROLL(NPianoRoll).NomduSon.Text + " Canal " + Convert.ToString(ii + 1)
                Else
                    Det_NomPisteMIDI = "PR" + Convert.ToString(NPianoRoll + 1) + " " + Form1.listPIANOROLL(NPianoRoll).NomduSon.Text + " Channel " + Convert.ToString(ii + 1)
                End If
                '
            Case Else ' Piste Drum
                If Module1.LangueIHM = "fr" Then
                    Det_NomPisteMIDI = "DR" + " Canal 10"
                Else
                    Det_NomPisteMIDI = "DR" + " Channel 10"
                End If
        End Select
    End Function
    ' Syntaxe des notes dans .part de "Les Pistes"
    '     |   0    |     1    |   2   |      3      |   4   |   5   |     6    |
    '     +--------+----------+-------+-------------+-------+-------+----------+
    '     | "Note" | NumPiste | Canal | Valeur Note | début | durée | Vélocité |
    ' ex. | "Note" |     6    |   6   |      72     |   16  |   16  |    90    | 
    ' Les paramètres 'début et 'durée' sont exprimés en nombre de double croches
    ' dans l'ex. la note est une ronde commençant à la mesure 2
    '
    Function Det_FIN2(Boucle As Integer)
        Dim e As Integer
        Dim k As Integer
        Dim PositFin As Integer


        e = Form1.Det_DerEventH2() ' postion du dernier accord
        If e <= Form1.Terme.Value Then ' si le dernier accord est avant le terme, alors la fin est au dernier accord
            k = (e - Val(Form1.Début.Value)) + 1
        Else
            k = (Val(Form1.Terme.Value) - Val(Form1.Début.Value)) + 1
        End If
        PositFin = Convert.ToString((k * (Boucle + 1) * 16) + 16) ' à modifier si on passe à un autre type de métrique que 4/4
        Return PositFin
    End Function

    Private Function Det_DivisionMes() As Integer
        '
        Select Case Dénominateur
            Case 4
                Det_DivisionMes = Numérateur * 4
            Case 8
                Det_DivisionMes = Numérateur * 2
            Case Else
                Det_DivisionMes = 16
        End Select
    End Function
    Function Det_Numérateur(Métrique As String) As Integer
            Dim tbl() As String = Métrique.Split("/")
            Det_Numérateur = Convert.ToInt16(tbl(0))
        End Function
    Function Det_Dénominateur(Métrique As String) As Integer
        Dim tbl() As String = Métrique.Split("/")
        Det_Dénominateur = Convert.ToInt16(tbl(1))
    End Function

End Module
