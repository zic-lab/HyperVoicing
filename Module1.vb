Imports System.Windows.Forms.Control
Imports Control = System.Windows.Forms.Control

Public Module Module1

    ' Numéro de version de publication
    ' ********************************
    Public NumVersion As String = "v2.0.7.2"
    Public Dateversion As String = "10/01/2025"
    '
    ' Constantes application
    ' **********************
    Public Const nbMesures = 64
    Public Const nbMesuresUtiles = nbMesures '- 8
    Public Const nbLignesGrid1 = nbMesures * 4
    Public Const nbColonnesGrid1 = 20 ' 17
    ' Pour test
    ' ********
    Public AutorizeReset As Boolean = True

    ' Colonnes dans grid1
    ' *******************
    Public Const ColMesure = 1
    Public Const ColMarqueur = 2
    Public Const ColTonalité = 3
    Public Const ColAccord = 4
    Public Const ColGamme = 5
    Public Const ColDegré = 6
    Public Const ColVélo = 7
    Public Const ColRacine = 8

    ' dimension de l'application
    Public hauteurApp As Integer = 698 ' 727
    '
    ' Numéro des pistes
    ' *****************
    Public Const N_PisteAcc = 0
    Public Const N_PistePianoR1 = 1
    Public Const N_PistePianoR2 = 2
    Public Const N_PistePianoR3 = 3
    Public Const N_PistePianoR4 = 4
    Public Const N_PistePianoR5 = 5
    Public Const N_PistePianoR6 = 6
    Public Const N_PistePianoR7 = 7
    Public Const N_PistePianoR8 = 8
    Public Const N_PisteDrums = 9


    Public Const N_Courbexp = 11
    Public Const N_Modes = 10
    ' 
    Public CoulHyperV As Color = Color.LightYellow
    Public CoulPRoll1 As Color = Color.FromArgb(252, 248, 180)
    Public CoulPRoll2 As Color = Color.LightSteelBlue
    Public CoulPRoll3 As Color = Color.FromArgb(241, 212, 179)
    Public CoulPRoll4 As Color = Color.LightCyan
    Public CoulPRoll5 As Color = Color.LightGreen
    Public CoulPRoll6 As Color = Color.LightGray
    Public CoulPRoll7 As Color = Color.Ivory
    Public CoulPRoll8 As Color = Color.LightGray
    Public CoulDrumEd As Color = Color.LightSkyBlue

    '
    ' Couleur de fon de compogrid
    ' ***************************
    Public CouleurFondG1 As Color = Color.FromArgb(240, 240, 240)
    '
    ' Variables pour chargement et le changement de langue
    ' ****************************************************
    Public ChangementLangue As Boolean = False
    '
    Public EnChargement As Boolean = True
    Public EnrechercheGammes As Boolean = False
    Public EnChargementCalquesMIDI As Boolean = True

    '
    ' Constantes couleurs basiques
    ' ****************************
    Public Const vbBlack = &H0 'Noir 
    Public Const vbRed = &HFF ' Rouge 
    Public Const vbGreen = &HFF00 ' Vert 
    Public Const vbYellow = &HFFFF ' Jaune 
    Public Const vbBlue = &HFF0000 ' Bleu 
    Public Const vbMagenta = &HFF00FF ' Magenta 
    Public Const vbCyan = &HFFFF00 ' Cyan 
    Public Const vbWhite = &HFFFFFF ' Blanc
    '
    ' Couleur des grilles
    ' *******************
    Public Couleur_Positions As Color = Color.AliceBlue
    Public Couleur_Marqueurs As Color = Color.Beige ' couleur de la colonne Armures/Marqueurs quand il n'y a pas de marqueur
    Public Coul_Marq As Color = Color.Green ' backcolor d'un marqueur dans la colonne Armures/Marqueurs
    Public Couleur_Tonalités As Color = Color.PaleTurquoise
    Public Couleur_Accords As Color = Color.Khaki
    Public Couleur_Gammes As Color = Color.Lavender
    Public Couleur_Degrés As Color = Color.Gainsboro
    Public Couleur_Vel As Color = Color.Beige
    Public Couleur_Root As Color = Color.Beige
    '
    Public Const Color_Lettres_Gammes = vbBlack
    Public Const Color_Lettres_Position = vbBlue
    Public Const Color_Lettres_Tonalités = vbBlue   ' ( gras )
    Public Const Color_Lettres_Acords = vbRed       ' ( gras )
    '
    Public Const Color_NotesAccords = &HEE8D3E&
    Public Const Color_NotesEnrichissements = &H659C&
    Public Const Color_NotesAltérations = &H5900&
    Public Const Color_NotesEXtérieures = &H800000&
    '
    Public Const Color_Navigateur = vbWhite ' &HFFFCF2
    Public Const Color_Lettres_Navigateur = vbBlue
    '
    Public Couleur_Accord_Sélectionné As Color = Color.Khaki
    Public Couleur_Accord_DéSélectionné As Color = Color.LightGoldenrodYellow
    '
    Public Couleur_TonCours As Color = Color.WhiteSmoke
    Public Couleur_Accord_Majeur As Color = Color.Goldenrod
    Public Couleur_Accord_Mineur As Color = Color.Khaki 'Color.LightGoldenrodYellow
    Public Couleur_Accord_Marqué As Color = Color.Olive 'CadetBlue
    Public Couleur_lettres_Accord_Marqué As Color = Color.Yellow
    Public Couleur_Accord_Grid3 As Color = Color.DarkRed
    '
    ' Couleurs des boutons d'extension
    ' ********************************
    Public Couleur_ButtTonalités As Color = Color.Khaki
    Public Couleur_ButtAccords As Color = Color.LightSkyBlue
    Public Couleur_ButtGammes As Color = Color.LightSeaGreen
    Public Couleur_ButtModes As Color = Color.Beige

    ' Couleurs Grid3
    Public Couleur_Temps = Color.Orange
    Public Couleur_CTemps = Color.AliceBlue
    '
    Public Const SplitNligne = 57
    '
    ' Pour Split1
    Public Const SplitPositions = 116
    Public Const SplitMarqueurs = 176
    Public Const SplitCompogrid = 537
    '
    Public Const SplitTonalités = 296
    Public Const SplitAccords = 416
    Public Const SplitGammes = 537
    Public Const SplitNotes = 806
    ' Etats Grid1
    Public Const NLignes = "NLignes"
    Public Const Positions = "Positions"
    Public Const Marqueurs = "Marqueurs"
    Public Const Tonalités = "Tonalités"
    Public Const Accords = "Accords"
    Public Const Gammes = "Gammes"
    Public Const Notes = "Notes"
    '
    Public Const Grid1Largeur = 1000
    ' Pour Split2
    Public Const SplitEditeurs = 1235
    ' Pour Split3
    Public Const SplitDétails = 222
    Public Const SplitSansDétail = 146
    Public Const SplitSansGrid3 = 83
    Public Const SplitAvecGrid3 = 96

    ' Etats Grid3
    Public Const Détail = "Détails"
    Public Const SansDétail = "SansDétail"
    Public Const SansGrid3 = "SansGrid3"

    ' Zoom Grid3
    Public Const Grid3Largeur1 = 24 '18
    Public Const Grid3Largeur2 = 60
    Public Const Grid3Largeur3 = 100
    Public Const Grid3Largeur4 = 160
    '
    ' Zoom Grid2
    Public Const Grid2Largeurmini = 19
    Public Const Grid2Largeur0 = 19
    Public Const Grid2Largeur1 = 60
    Public Const Grid2Largeur2 = 100
    Public Const Grid2Largeur3 = 160
    Public Const Grid2Largeur4 = 200

    ' Pour Split4
    Public Const SplitGrid4 = 39
    Public Largeur_Zoom As Integer = 18
    Public Largeur_ZoomGrid2 As Integer = 60
    '
    ' Pour créationpiano
    Public Const HauteurTouche = 75 '72
    Public Const LargeurTouche = 31 '30
    ' Longueur des barres de sélection Rouge/Bleu
    Public Const LonBarresBleuRouge = 815
    Public Const EpaisBarresBleuRouge = 2
    ' Zones
    ' *****
    Public Const NbZones = 12 '8 '16 '7 ' attention le nombre de zones ne peut pas dépasser 16 à cause de tabcoulzone
    '
    Public Coul_ZoneG As Color = Color.Firebrick
    Public Coul_Zone1 As Color = Color.YellowGreen
    Public Coul_Zone2 As Color = Color.Khaki
    Public Coul_Zone3 As Color = Color.LightSteelBlue
    Public Coul_Zone4 As Color = Color.DarkKhaki
    Public Coul_Zone5 As Color = Color.Thistle
    Public Coul_Zone6 As Color = Color.Gold
    Public Coul_Zone7 As Color = Color.Cyan
    Public Coul_Zone8 As Color = Color.Beige
    Public Coul_Zone9 As Color = Color.Tan
    Public Coul_Zone10 As Color = Color.Orange
    Public Coul_Zone11 As Color = Color.GreenYellow
    Public Coul_Zone12 As Color = Color.Peru
    Public Coul_Zone13 As Color = Color.Gainsboro
    Public Coul_Zone14 As Color = Color.PeachPuff
    Public Coul_Zone15 As Color = Color.Khaki
    Public Coul_Zone16 As Color = Color.PaleGreen
    '
    Public TabCoulZone(0 To (16 + 1)) As Color
    '
    ' Notation Latine
    ' ***************
    Public NotLat As Boolean = False

    ' Présence d'au moins une sortie MIDI
    ' ***********************************
    Public Exist_MIDIout As Boolean = True

    ' Pour Moteur MIDI
    ' ****************
    Public TermeFin As Integer

    ' Ecrit Une fois
    ' **************
    Public EcritUneFois As Boolean = False
    '
    ' Variable globale partégée entre Les Modules PianoRoll et CalquesMIDI
    ' ********************************************************************
    Public nbCalques As Integer = 6
    Public PassChoixCalques(0 To nbCalques - 1) As Boolean
    Public PassChoixPédale As Integer
    Public PassTessDeb As String = "C-2"
    Public PassTessFin As String = "G8"
    Public PassNouvCalque As String = False
    Public PassTessListe As Integer = 0
    Public ValMetrique As Integer = 0


    '
    ' Couleur calques MIDI
    ' ********************
    Public ReadOnly CoulCalqTon As Color = Color.CadetBlue
    Public ReadOnly CoulCalqGammes As Color = Color.Khaki
    Public ReadOnly CoulCalqAcc As Color = Color.DarkOrange
    Public ReadOnly CDiv_12_8 As Color = Color.DarkKhaki
    Public ReadOnly CoulCalqPed As Color = Color.Tan
    Public ReadOnly CoulCalqTess As Color = Color.LightBlue

    ' Pour Formulaire Vélocités aléatoires par Menu contextuel
    ' ********************************************************
    Public Posx As Integer = 100
    Public Posy As Integer = 100
    Public ValMn As Integer = 64
    Public ValMx As Integer = 100
    Public VéloAléat_Chargé As Boolean = False
    Structure Signa
        Public Signature As String
        Public Position As Integer
    End Structure
    ' Piano
    ' *****
    Structure TouchePiano
        Public Nom As String
        Public Vélo As Byte
    End Structure
    Public Enum GridCours
        Rien = 0
        Autre = 0
        Grid1 = 1
        Grid2 = 2
        Grid3 = 3
        TabTon = 4
        Piano = 5
        Grid4 = 6
        TabTonVoisin = 7
    End Enum
    Class NotesJouéesPiano
        Public Notes(0 To 7) As Integer
        Public OldBackColor(0 To 7) As Color
        Public OldForeColor(0 To 7) As Color
        Public OldText(0 To 7) As String
        '
        ' Méthodes
        Sub Raz_NotesJouéesPiano()
            Dim i As Integer

            For i = 0 To UBound(Notes)
                Notes(i) = -1
            Next
        End Sub
    End Class
    Class Visual_MajAutoVoicing
        Public ColDeb As Integer
        Public Colfin As Integer
        Public Colcours As Integer
        Public CouleurPréced As Color
        Public AutoVoiceValid As Boolean = False
    End Class
    '
    Public TContext1 As New Visual_MajAutoVoicing

    'Public LabelPiano As New List(Of Label)

    '
    'Public Piano(128) As TouchePiano
    '
    ' **********************
    ' * Variables Communes *
    ' **********************
    Public TSignat(6) As Signa ' 
    Public Retour As String   ' valeur de sortie retournée par un formulaire :  OK, Annuler ..
    Public RetourSTR As String
    Public RetourINT As Integer
    Public nbColonnesGrid3ParMesure As Integer
    Public nbColonnesGrid3 As Integer

    Public TAccents(25) As Boolean
    '
    Public Dirty As Boolean = False '
    '
    Public LangueCours As String = "fr" ' non utilisé
    ' Public Langue As String = "en" ' langue des notes : toujours à "en" (notation anglo-saxonne)
    Public LangueIHM As String ' c'est la langue de l'Interface Homme Machine - elle peut être soit "fr", soit "en".
    Public ChangeLangue As Boolean = False ' un changement de langue a eu lieu
    Public form2_Retour As String
    Public RacineDéfaut As String = "c2"
    '
    ' Pour form2 "Pramètres export HTML"
    ' ********************************
    Public Avertis As String

    Public EtatSplit1 As String ' variable pour automate des positions de split1
    Public EtatSplit3 As String ' variable pour automate des positions de split1 

    ' Dimension de l'onglet de navigation PDF (TabePage9)
    ' ***************************************************
    Public DimNav As Size
    Public DimApp As Size
    ' 
    ' Onglet en cours pour COUPER-COPIER-COLLER
    ' *****************************************
    Public OngletCours_Edition As Integer = 0 ' utilisé dans pianoroll et form1


    Public Sub MajTabCouZone()
        TabCoulZone(0) = Coul_ZoneG
        TabCoulZone(1) = Coul_Zone1
        TabCoulZone(2) = Coul_Zone2
        TabCoulZone(3) = Coul_Zone3
        TabCoulZone(4) = Coul_Zone4
        TabCoulZone(5) = Coul_Zone5
        TabCoulZone(6) = Coul_Zone6
        TabCoulZone(7) = Coul_Zone7
        TabCoulZone(8) = Coul_Zone8
        TabCoulZone(9) = Coul_Zone9
        TabCoulZone(10) = Coul_Zone10
        TabCoulZone(11) = Coul_Zone11
        TabCoulZone(12) = Coul_Zone12
        TabCoulZone(13) = Coul_Zone13
        TabCoulZone(14) = Coul_Zone14
        TabCoulZone(15) = Coul_Zone15
        TabCoulZone(16) = Coul_Zone16
    End Sub
    ' Variables pour les Try catch
    Public messa As String = ""

    ' Variables pour onglet tons voisins
    ' **********************************
    Public TonVois As String
    Public ModeVois As String

    ' Insertion PIANOROLL, DRUMEDIT ET MIX
    ' ************************************
    ' Fonts communs
    ' *************
    Public ReadOnly fontNomduSon = New Font("Verdana", 8, FontStyle.Regular)
    Public ReadOnly fontMutePiste = New Font("Rubik", 9, FontStyle.Bold)
    '
    Public Const nbRépétitionMax = 16
    Public ReadOnly Couleur_ModelDrum As Color = Color.FromArgb(1, 153, 229)

    Public Const NbDrumPrésets = 8  ' Constantes drumEdit
    Public Const nb_PianoRoll = 8
    Public Const nb_DrumEdit = 1
    Public Const nb_PistAcc = 1
    Public Const NombrePistes = nb_PistAcc + nb_PianoRoll
    Public Const nb_TotalPistes = nb_PistAcc + nb_PianoRoll + nb_DrumEdit ' = 8  nombre total de pistes : pistes variation + Pistes PianoRoll + Piste Drum
    Public Const nb_TotalCurseurs = nb_TotalPistes + 6
    Public Const nbCourbes = 7

    ' Couleurs des controleurs
    Public ReadOnly CoulExp As Color = Color.Red 'Color.FromArgb(&HCCCC99)
    Public ReadOnly CoulMod As Color = Color.Lime 'Color.LightSeaGreen
    Public ReadOnly CoulPan As Color = Color.PowderBlue 'Color.Red
    Public ReadOnly CoulCC50 As Color = Color.YellowGreen
    Public ReadOnly CoulCC51 As Color = Color.Orange
    Public ReadOnly CoulCC52 As Color = Color.MediumTurquoise
    Public ReadOnly CoulCC53 As Color = Color.Thistle
    Public ReadOnly CoulPB As Color = Color.Red
    '
    ' Controleurs MIDI
    Public Const CMod = 1
    Public Const CVolume = 7
    Public Const CPAN = 10

    Public EnRecalcul As Boolean = False

    Public TValPréced2(0 To nb_PistAcc - 1, 0 To nbCourbes - 1) As Integer ' sans doute à supprimer car concerne automation des varaiations

    Dim RockSet1 As String = "RockSet1;1 4 92 1.1,4 4 82 1.1,4 6 67 1.3,2 8 84 2.1,4 8 82 2.1,1 10 67 2.3,4 10 67 2.3,5 12 45 3.1,1 14 92 3.3,4 14 67 3.3,1 16 92 4.1,2 16 85 4.1,4 16 81 4.1,5 18 54 4.3,;Acoustic Bass Drum/B0,Acoustic Snare/D1,Hand Clap/D#1,Closed Hi Hat/F#1,Open Hi Hat/A#1,Low Tom/A1,High Tom/D2,Side Stick/C#1,Claves/D#4,Ride Bell/F2,Cowbell/G#2,Tambourine/F#2"
    Dim RockSet2 As String = "RockSet2;1 4 76 1.1,4 4 103 1.1,4 6 67 1.3,2 8 67 2.1,4 8 103 2.1,1 10 76 2.3,4 10 67 2.3,1 12 76 3.1,4 12 103 3.1,4 14 67 3.3,2 16 67 4.1,4 16 103 4.1,5 18 59 4.3,;Acoustic Bass Drum/B0,Acoustic Snare/D1,Hand Clap/D#1,Closed Hi Hat/F#1,Open Hi Hat/A#1,Low Tom/A1,High Tom/D2,Side Stick/C#1,Claves/D#4,Ride Bell/F2,Cowbell/G#2,Tambourine/F#2"
    Dim RockSet3 As String = "RockSet3;1 4 76 1.1,4 4 103 1.1,4 6 67 1.3,2 8 67 2.1,4 8 103 2.1,1 10 76 2.3,4 10 67 2.3,1 12 76 3.1,4 12 103 3.1,1 14 56 3.3,4 14 67 3.3,2 16 67 4.1,4 16 103 4.1,1 18 67 4.3,4 18 67 4.3,;Acoustic Bass Drum/B0,Acoustic Snare/D1,Hand Clap/D#1,Closed Hi Hat/F#1,Open Hi Hat/A#1,Low Tom/A1,High Tom/D2,Side Stick/C#1,Claves/D#4,Ride Bell/F2,Cowbell/G#2,Tambourine/F#2"
    Dim RockSet4 As String = "RockSet4;1 4 90 1.1,4 4 90 1.1,4 6 90 1.3,1 8 90 2.1,2 8 90 2.1,4 8 90 2.1,4 10 90 2.3,1 12 90 3.1,4 12 90 3.1,4 14 90 3.3,1 16 90 4.1,2 16 90 4.1,4 16 90 4.1,4 18 90 4.3,;Acoustic Bass Drum/B0,Acoustic Snare/D1,Hand Clap/D#1,Closed Hi Hat/F#1,Open Hi Hat/A#1,Low Tom/A1,High Tom/D2,Side Stick/C#1,Claves/D#4,Ride Bell/F2,Cowbell/G#2,Tambourine/F#2"
    Dim RockSet5 As String = "RockSet5;1 4 90 1.1,4 4 90 1.1,4 6 90 1.3,2 8 90 2.1,1 10 90 2.3,4 10 90 2.3,1 12 77 3.1,4 12 90 3.1,4 14 90 3.3,1 16 90 4.1,4 18 90 4.3,;Acoustic Bass Drum/B0,Acoustic Snare/D1,Hand Clap/D#1,Closed Hi Hat/F#1,Open Hi Hat/A#1,Low Tom/A1,High Tom/D2,Side Stick/C#1,Claves/D#4,Ride Bell/F2,Cowbell/G#2,Tambourine/F#2"
    Dim RockSet6 As String = "RockSet6;1 4 92 1.1,4 4 96 1.1,4 6 81 1.3,2 8 84 2.1,4 8 96 2.1,1 10 67 2.3,4 10 81 2.3,1 12 90 3.1,5 12 45 3.1,4 14 81 3.3,2 16 85 4.1,4 16 95 4.1,5 18 54 4.3,;Acoustic Bass Drum/B0,Acoustic Snare/D1,Hand Clap/D#1,Closed Hi Hat/F#1,Open Hi Hat/A#1,Low Tom/A1,High Tom/D2,Side Stick/C#1,Claves/D#4,Ride Bell/F2,Cowbell/G#2,Tambourine/F#2"
    Dim RockSet6_Break As String = "RockSet6_Break;1 4 92 1.1,1 10 90 2.3,1 14 90 3.3,2 15 70 3.4,2 16 85 4.1,2 18 90 4.3,;Acoustic Bass Drum/B0,Acoustic Snare/D1,Hand Clap/D#1,Closed Hi Hat/F#1,Open Hi Hat/A#1,Low Tom/A1,High Tom/D2,Side Stick/C#1,Claves/D#4,Ride Bell/F2,Cowbell/G#2,Tambourine/F#2"
    Dim RockSet7 As String = "RockSet7 (guide rapide);1 4 74 1.1,4 4 107 1.1,12 4 75 1.1,4 5 72 1.2,1 6 64 1.3,4 6 107 1.3,12 6 75 1.3,4 7 70 1.4,2 8 49 2.1,3 8 57 2.1,4 8 107 2.1,8 8 90 2.1,12 8 75 2.1,4 9 70 2.2,4 10 107 2.3,12 10 75 2.3,4 11 68 2.4,1 12 88 3.1,4 12 107 3.1,12 12 75 3.1,4 13 69 3.2,1 14 70 3.3,4 14 107 3.3,12 14 75 3.3,4 15 70 3.4,2 16 49 4.1,3 16 60 4.1,4 16 107 4.1,8 16 90 4.1,12 16 75 4.1,4 17 70 4.2,1 18 65 4.3,4 18 107 4.3,12 18 75 4.3,4 19 68 4.4,;Acoustic Bass Drum/B0,Acoustic Snare/D1,Hand Clap/D#1,Closed Hi Hat/F#1,Open Hi Hat/A#1,Low Tom/A1,High Tom/D2,Side Stick/C#1,Claves/D#4,Ride Bell/F2,Cowbell/G#2,Tambourine/F#2"

    Dim RBSet1 As String = "RBSet1;1 4 90 1.1,4 4 82 1.1,1 5 90 1.2,4 6 98 1.3,1 8 90 2.1,2 8 90 2.1,4 8 82 2.1,4 10 99 2.3,1 12 90 3.1,4 12 82 3.1,1 14 90 3.3,4 14 101 3.3,2 16 90 4.1,4 16 82 4.1,4 17 90 4.2,1 18 90 4.3,;Acoustic Bass Drum/B0,Acoustic Snare/D1,Hand Clap/D#1,Closed Hi Hat/F#1,Open Hi Hat/A#1,Low Tom/A1,High Tom/D2,Side Stick/C#1,Claves/D#4,Ride Bell/F2,Cowbell/G#2,Tambourine/F#2"
    Dim RBSet2 As String = "RBSet2;1 4 90 1.1,4 4 90 1.1,4 6 90 1.3,2 8 71 2.1,4 8 90 2.1,4 9 90 2.2,4 10 90 2.3,1 11 90 2.4,4 11 90 2.4,1 13 90 3.2,4 13 90 3.2,1 15 90 3.4,4 15 90 3.4,2 16 71 4.1,4 17 90 4.2,4 19 90 4.4,;Acoustic Bass Drum/B0,Acoustic Snare/D1,Hand Clap/D#1,Closed Hi Hat/F#1,Open Hi Hat/A#1,Low Tom/A1,High Tom/D2,Side Stick/C#1,Claves/D#4,Ride Bell/F2,Cowbell/G#2,Tambourine/F#2"
    Dim RBSet3 As String = "RBSet3;1 4 90 1.1,4 4 111 1.1,4 5 79 1.2,4 6 79 1.3,4 7 79 1.4,4 8 108 2.1,4 9 79 2.2,4 10 79 2.3,1 11 90 2.4,4 11 79 2.4,1 12 90 3.1,4 12 113 3.1,4 13 79 3.2,4 14 79 3.3,4 15 79 3.4,4 16 112 4.1,4 17 79 4.2,4 18 79 4.3,4 19 79 4.4,;Acoustic Bass Drum/B0,Acoustic Snare/D1,Hand Clap/D#1,Closed Hi Hat/F#1,Open Hi Hat/A#1,Low Tom/A1,High Tom/D2,Side Stick/C#1,Claves/D#4,Ride Bell/F2,Cowbell/G#2,Tambourine/F#2"
    Dim Div1 As String = "Div1;1 4 90 1.1,4 4 81 1.1,4 6 81 1.3,4 7 55 1.4,1 8 90 2.1,4 8 81 2.1,9 8 79 2.1,4 10 81 2.3,2 12 75 3.1,4 12 81 3.1,1 14 90 3.3,4 14 81 3.3,9 14 79 3.3,5 15 44 3.4,4 16 81 4.1,1 18 90 4.3,4 18 81 4.3,9 18 90 4.3,;Acoustic Bass Drum/B0,Acoustic Snare/D1,Hand Clap/D#1,Closed Hi Hat/F#1,Open Hi Hat/A#1,Low Tom/A1,High Tom/D2,Side Stick/C#1,Claves/D#4,Ride Bell/F2,Cowbell/G#2,Tambourine/F#2"

    '
    ' Enumération pour reconnaitre origine ctrl c,x,v entre Pianoroll et courbes dans module PianoRoll
    Public Enum OrigPianoCourbe
        Piano = 0
        Courbe = 1
    End Enum

    'liste des préset de la drumedit
    Public ListDesPrésets As New List(Of String)
    ' 
    Function EstImpair(ByVal n As Integer) As Boolean
        ' Utilisation de l'opérateur Mod pour vérifier si le nombre est impair
        Return n Mod 2 <> 0
    End Function
    Function Estpair2(ByVal n As Integer) As Boolean
        ' Utilisation de l'opérateur Mod pour vérifier si le nombre est impair
        Return n Mod 2 = 0
    End Function
    ' Mettre tous les tabstop à false
    ' *******************************
    <System.Runtime.CompilerServices.Extension()>
    Public Sub setAllControlsTabstop(ByVal instance As ControlCollection, ByVal value As Boolean)
        For Each ctrl As Control In instance
            If ctrl.TabIndex <> Nothing Then
                ctrl.TabStop = value
            End If
            ctrl.Controls.setAllControlsTabstop(value)
        Next

    End Sub


    ' Variable utilisée par Barre de transport
    ' ****************************************
    Public JeuxActif As Boolean = False
    Public Sub Cacher_FormTransparents()
        Clavier.Hide()
        Form1.Position_Transport()
    End Sub
    Public Sub Init_ListDesPrésets()
        ListDesPrésets.Add(RockSet1)
        ListDesPrésets.Add(RockSet2)
        ListDesPrésets.Add(RockSet3)
        ListDesPrésets.Add(RockSet4)
        ListDesPrésets.Add(RockSet5)
        ListDesPrésets.Add(RockSet6)
        ListDesPrésets.Add(RockSet6_Break)
        ListDesPrésets.Add(RockSet7)
        ListDesPrésets.Add(RBSet1)
        ListDesPrésets.Add(RBSet2)
        ListDesPrésets.Add(RBSet3)
        ListDesPrésets.Add(Div1)
    End Sub
    Public Function IsMultiple(ByVal W_Chiffre As Double, ByVal W_Multiple As Double) As Boolean
        IsMultiple = ((W_Chiffre Mod W_Multiple) = 0)
    End Function

    Public Sub Maj_TAccents(Signa As String)

        '-------------------------------------------------------------------+
        ' Beat unit	    !				Signatures					!  Dev	!
        '-----------------------------------------------------------!------	!
        ' croche		!	2/8	3/8	4/8	5/8	6/8	7/8	8/8	    		!   0   !
        '-----------------------------------------------------------!------	!
        ' croche pointée!      	3/16		6/16	7/4				!   0	!
        '-----------------------------------------------------------!------	!
        ' noire			!	2/4	3/4	4/4	5/4	6/4  	7/4 			!   X	!
        '-----------------------------------------------------------!-------!
        ' noire pointée	!		3/8		    6/8			9/9	12/8	!   X	!
        '-----------------------------------------------------------!------	!
        ' blanche		!	2/2	3/2	    							!   0	!
        '-----------------------------------------------------------!-------!
        ' blanche point.!		3/4			6/4			    		!   0   !
        '-----------------------------------------------------------!------	+

        Dim i As Integer
        Dim Taille As Integer
        Taille = UBound(TAccents)
        For i = 0 To (UBound(TAccents) - 1)
            TAccents(i) = False
        Next i
        '
        Select Case Signa
            Case "2/4", "3/4"
                TAccents(1) = True ' remrque Taccents(0) n'est jamais utilisé
            Case "4/4"
                TAccents(1) = True
                TAccents(5) = True
            Case "5/4"              ' f-p-mf-p-p / binaire- ternaire
                TAccents(1) = True
                TAccents(5) = True
            Case "6/4"              ' f-p-mf-p-p-p / binaire - binaire
                TAccents(1) = True
                TAccents(5) = True
            Case "7/4"
                TAccents(1) = True  ' f-p-p-mf-p-p-p / ternaire-binaire
                TAccents(7) = True
                'TAccents(11) = True
            Case "3/8"
                TAccents(1) = True
            Case "6/8"
                TAccents(1) = True
                'TAccents(4) = True
                'Case "7/8"
                '    TAccents(1) = True  ' f-p-p-mf-p-p-p / ternaire-binaire
                '    TAccents(4) = True
            Case "7/8"
                TAccents(1) = True
                TAccents(4) = True
            Case "9/8"
                TAccents(1) = True
                'TAccents(4) = True
                TAccents(7) = True
            Case "12/8"
                TAccents(1) = True
                'TAccents(4) = True
                TAccents(7) = True
                'TAccents(10) = True
                'Case "15/8"
                '    TAccents(1) = True
                '    TAccents(4) = True
                '    TAccents(7) = True
                '    TAccents(10) = True
                '    TAccents(13) = True
                'Case "18/8"
                '    TAccents(1) = True
                '    TAccents(4) = True
                '    TAccents(7) = True
                'TAccents(10) = True
                'TAccents(13) = True
                'TAccents(16) = True
        End Select
    End Sub
    Public Function Det_NMesure(Position As String) As Integer
        Dim TBL() As String

        TBL = Split(Position, ".")
        Det_NMesure = Val(TBL(0))
    End Function
    '
    Public Function EstPair(n As Long) As Boolean
        EstPair = (n Mod 2) = 0
    End Function
    Function Création_CTemp() As String
        Dim DossierDocuments As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim a As String
        a = DossierDocuments + "\HyperVoicing"
        Création_CTemp = a
        With My.Computer.FileSystem
            If Not (.DirectoryExists(a)) Then
                .CreateDirectory(a)
            End If
        End With

    End Function
    Public Sub Effacer_CTemp()
        Dim a As String
        Dim DossierDocuemnts As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        a = DossierDocuemnts + "\Hypervoicing"
        Dim PATHDOSSIER As String = a
        If My.Computer.FileSystem.DirectoryExists(PATHDOSSIER) Then
            For Each files As String In My.Computer.FileSystem.GetFiles(PATHDOSSIER)
                If My.Computer.FileSystem.FileExists(files) Then
                    'My.Computer.FileSystem.DeleteFile(files)
                End If
            Next
        End If

        'If My.Computer.FileSystem.DirectoryExists("c:\temp\hypervoicing") Then
        '        My.Computer.FileSystem.DeleteDirectory("c:\temp\hypervoicing", FileIO.DeleteDirectoryOption.DeleteAllContents)
        'End If
    End Sub
    Public Function IsLoaded(ByRef frm As Form) As Boolean
        Dim b As Boolean = False
        Dim f As Form

        For Each f In Application.OpenForms
            If f Is frm Then
                b = True
                Exit For
            End If
        Next
        Return b
    End Function
    Sub Maj_NomOnglet(NomduSon As String, index As Integer)
        Dim a, b As String

        ' Maj nom du son dans les onglets
        b = Trim(NomduSon)
        If Len(b) > 10 Then
            b = Microsoft.VisualBasic.Left(b, 10)
        End If
        '
        If Trim(b) = "" Then
            b = "PianoRoll"
            '  ReadOnly fnt1 As New System.Drawing.Font("Calibri", 13, FontStyle.Regular)
            'Form1.TabControl4.TabPages.Item(index).Font = New System.Drawing.Font("Verdana", 8, FontStyle.Regular)
            'Else
            'Form1.TabControl4.TabPages.Item(index).Font = New System.Drawing.Font("Verdana", 8, FontStyle.Bold)
        End If
        '
        a = Trim((index + 1).ToString + "-" + Trim(b))
        Form1.TabControl4.TabPages.Item(index).Text = a
    End Sub
    ''' <summary>
    ''' Cette procédure est destinée à être utilisée en fin de chargement de l'appli afin de vérifier
    ''' que l'on peut ouvrir sans problème le driver de sortie du Microsoft GS WaveTable Synth" qui se trouve
    ''' normalement toujours en 1ere position (position=0).
    ''' Il s'agit de mettre en évidence un problème de driver asio (généralement Asio4all) qui
    ''' ne voit pas la sortie 0 ouverte (elle est donc fermée) mais qui plante quand on essai de d'ouvrir cette sortie. Cubase doit être 
    ''' préalablement lancé pour que l'erreur se manifeste.
    '''      - Le problème est mis en évidence avec asio4all quand Cubase est lancé. Mais il disparaît si l'on choisit dans Cubase l'option 
    '''        "Mettre le driver Asio en tâche de fond etc..".
    '''      - Le problème ne se manifeste jamais avec le driver asio  steinberg de la carte son steinberg.
    ''' </summary>
    Public Sub TestInterfaceMIDI()
        Dim a As String = ""
        Dim b As String = ""
        Dim n As String = ""
        Dim i As Integer
        Try
            ' Test de l'ouverture de la sortie midi 
            For i = 0 To Form1.SortieMidi.Count - 1
                a = "Output MIDI"
                b = i.ToString
                n = Form1.SortieMidi.Item(i).Name
                If Not (Form1.SortieMidi.Item(i).IsOpen) Then
                    '
                    Form1.SortieMidi.Item(i).Open()
                    Form1.SortieMidi.Item(i).Close()
                Else
                    Form1.SortieMidi.Item(i).Close()
                End If
            Next i


            '


            ' le catch est appelé si l'ouverture se passe mal
        Catch ex As Exception
            If LangueIHM = "fr" Then
                MessageHV.PTitre = "Avertissement"
                MessageHV.PContenuMess = "Erreur de : " + a + "n° : " + b + " - " + n _
                    + " qui pourrait être occupée par une autre application." _
    + vbCrLf + "- choisissez une autre sortie MIDI " + "(" + n + ")" _
    + vbCrLf + "- ou une autre application MIDI pourrait être présente : quitter cette application ou libérez son pilote ASIO quand elle est en tâche de fond" _
    + vbCrLf + "- ou redémarrez votre PC," _
    + vbCrLf + "- ou choisissez un autre driver ASIO," _
    + vbCrLf + ex.Message
                MessageHV.PTypBouton = "OK"
            Else
                MessageHV.PTitre = "Warning"
                MessageHV.PContenuMess = "Error of : " + a + "n° : " + b + " - " + n _
                    + "  which could be occupied by another application." _
    + vbCrLf + "- choose another MIDI output," + "(" + a + ")" _
    + vbCrLf + "- or another MIDI application might be present: release this application or or free its ASIO driver when it is in the background," _
    + vbCrLf + "- or reboot your PC." _
    + vbCrLf + "- or choose another ASIO driver," _
    + vbCrLf + ex.Message
                MessageHV.PTypBouton = "OK"
            End If
            Cacher_FormTransparents()
            MessageHV.ShowDialog()
            End ' on sort de l'appli - l'appli est inutilisable.
        End Try
    End Sub
    Public Sub TestInterfaceMIDI2()
        Dim a As String = ""
        Dim b As String = ""
        Dim n As String = ""
        Dim i As Integer

        Try
            ' Test de l'ouverture de la sortie midi 
            i = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\CalquesMIDI\HyperVoicing\Préférences", "ChoixSortieMIDI", a)
            a = "Output MIDI"
            b = i.ToString
            n = Form1.SortieMidi.Item(i).Name
            If Not (Form1.SortieMidi.Item(i).IsOpen) Then
                '
                Form1.SortieMidi.Item(i).Open()
                Form1.SortieMidi.Item(i).Close()
            Else
                Form1.SortieMidi.Item(i).Close()
            End If

            ' le catch est appelé si l'ouverture se passe mal
        Catch ex As Exception

            If Module1.LangueIHM = "fr" Then
                titre = "Veuillez noter que ..."
                Avertis = "La Sortie MIDI " + Form1.SortieMidi.Item(i).Name + " est  indisponible. Veuillez choisir une autre sortie MIDI."
            Else
                titre = "Please note that ..."
                Avertis = "The MIDI output " + Form1.SortieMidi.Item(i).Name + " is not avaliable. Please choose an other MIDI Output."
            End If
            MessageHV.PContenuMess = Avertis
            MessageHV.Titre = titre
            MessageHV.PTypBouton = "OK"
            Cacher_FormTransparents()
            MessageHV.ShowDialog()
        End Try
    End Sub

    Public Function TradTonaD(tona As String) As String
        Dim a As String = tona
        Select Case tona
            Case "A# Major"
                a = " Bb Major"
            Case "D# Major"
                a = " Eb Major"
            Case "G# Major"
                a = " Ab Major"
        End Select
        Return a
    End Function
    Public Function TradTonaD2(tona As String) As String
        Dim a As String = Trim(tona)
        Select Case tona
            Case "A# Maj"
                a = "Bb Maj"
            Case "D# Maj"
                a = "Eb Maj"
            Case "G# Maj"
                a = "Ab Maj"
        End Select
        Return a
    End Function
    Public Function AIDE_TEXTE(Langue As String) As String
        Dim a As String = ""
        If Langue = "fr" Then
            a = "But : guide d'utilisation du logiciel HyperVoicing" + Chr(13) + Chr(13) +
"1 - Cochez la case Afficher l'Aide dans la barre d'outils (inutile pour la Piste Batterie)." + Chr(13) +
"2 - Maintenez touche Maj enfoncé et survolez un composant pour afficher son aide dans le panneau." + Chr(13) +
"3 - Pour les onglets, survolez leur titre en maintenant Maj." + Chr(13) + Chr(13) +
"Les 3 fonctions principales de l'application sont : " + Chr(13) +
"1- Piste Accords :" + Chr(13) +
"- Contient des sources d'accords et la Piste Accords." + Chr(13) +
"- Comprend une grille de composition réunissant tous les éléments harmoniques." + Chr(13) +
"- Propose une liste de gammes adaptées aux accords." + Chr(13) +
"2 - Pistes PianoRolls : écriture mélodique avec système d'Aide à la Composition." + Chr(13) +
"3 - Piste Batterie : création et assignation de patterns rythmiques."
        Else
        End If
        Return a
    End Function
End Module
