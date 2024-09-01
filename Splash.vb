Public Class Splash

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown

    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        FermetureSplash()
        '
    End Sub

    Private Sub FermetureSplash()
        Me.Visible = False
        Me.Close()
        'Me.Dispose()

        Timer1.Stop() ' timer de durée de la splash image
        Form1.Visible = True
        '
        If Exist_MIDIout = False Then
            If Module1.LangueIHM = "fr" Then
                Avertis = "Pas de sortie MIDI : l'écoute des accords ne pourra pas fonctionner."
            Else
                Avertis = "No MIDI out : listening chords will not work."
            End If
            MessageHV.PContenuMess = Avertis
            MessageHV.PTypBouton = "OK"
            Cacher_FormTransparents()
            MessageHV.ShowDialog()
            'end
            '

        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' Specify that the link was visited.
        Me.LinkLabel1.LinkVisited = True
        ' Navigate to a URL.
        System.Diagnostics.Process.Start("https://sourceforge.net/p/hypervoicing/wiki/Home/")
    End Sub

    Private Sub Label2_MouseUp(sender As Object, e As MouseEventArgs)
        Me.Close()
        'Me.Dispose()
        Form1.Visible = True
    End Sub

    Private Sub Label3_MouseUp(sender As Object, e As MouseEventArgs)
        Me.Close()
        'Me.Dispose()
        Form1.Visible = True
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        Me.Close()
        'Me.Dispose()
        Form1.Visible = True
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles Me.Load



        Dim a As System.DateTime
        Dim b As String
        Dim c As String
        '
        a = System.DateTime.Today
        b = a.ToString("dd/MM/yy")
        c = a.ToString("yyyy")

        If Module1.LangueIHM = "fr" Then
            Label1.Text = "Tous droits réservés - HyperVoicing " + Trim(c)
            Label2.Text = "Version beta : " + NumVersion + "  -  " + Dateversion
        Else
            Label1.Text = "All rights reserved - HyperVoicing " + Trim(c)
            Label2.Text = "Beta version : " + NumVersion + "  -  " + Dateversion
        End If
        ' Timer de durée d'affichage de la splah image
        ' ********************************************
        Timer1.Interval = 5000
        Timer1.Start()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        FermetureSplash()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class