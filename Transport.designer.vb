<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Transport
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Arrêt = New System.Windows.Forms.Button()
        Me.Play = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Début = New System.Windows.Forms.NumericUpDown()
        Me.Terme = New System.Windows.Forms.NumericUpDown()
        Me.Tempo = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Répéter = New System.Windows.Forms.CheckBox()
        Me.ComboBox8 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LoopNumber = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.AuDessus = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LFinal = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Comp = New System.Windows.Forms.NumericUpDown()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Remote = New System.Windows.Forms.CheckBox()
        Me.Bassemoins1 = New System.Windows.Forms.CheckBox()
        Me.Fournotes = New System.Windows.Forms.CheckBox()
        CType(Me.Début, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Terme, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tempo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoopNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Comp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(245, 5)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "1111111"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Arrêt
        '
        Me.Arrêt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Arrêt.BackColor = System.Drawing.Color.Transparent
        Me.Arrêt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Arrêt.FlatAppearance.BorderSize = 3
        Me.Arrêt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tan
        Me.Arrêt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Linen
        Me.Arrêt.Image = Global.HyperVoicing.My.Resources.Resources.stop_
        Me.Arrêt.Location = New System.Drawing.Point(172, 5)
        Me.Arrêt.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Arrêt.Name = "Arrêt"
        Me.Arrêt.Size = New System.Drawing.Size(34, 26)
        Me.Arrêt.TabIndex = 1
        Me.Arrêt.UseVisualStyleBackColor = False
        '
        'Play
        '
        Me.Play.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Play.BackColor = System.Drawing.Color.Transparent
        Me.Play.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Play.FlatAppearance.BorderSize = 3
        Me.Play.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tan
        Me.Play.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Linen
        Me.Play.Image = Global.HyperVoicing.My.Resources.Resources.Play1
        Me.Play.Location = New System.Drawing.Point(208, 5)
        Me.Play.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Play.Name = "Play"
        Me.Play.Size = New System.Drawing.Size(34, 26)
        Me.Play.TabIndex = 0
        Me.Play.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Play.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(60, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Début"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(131, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fin"
        '
        'Début
        '
        Me.Début.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Début.Location = New System.Drawing.Point(63, 5)
        Me.Début.Maximum = New Decimal(New Integer() {48, 0, 0, 0})
        Me.Début.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Début.Name = "Début"
        Me.Début.Size = New System.Drawing.Size(52, 21)
        Me.Début.TabIndex = 10
        Me.Début.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Terme
        '
        Me.Terme.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Terme.Location = New System.Drawing.Point(121, 5)
        Me.Terme.Maximum = New Decimal(New Integer() {48, 0, 0, 0})
        Me.Terme.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Terme.Name = "Terme"
        Me.Terme.Size = New System.Drawing.Size(48, 21)
        Me.Terme.TabIndex = 11
        Me.Terme.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Tempo
        '
        Me.Tempo.BackColor = System.Drawing.Color.DarkKhaki
        Me.Tempo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tempo.Location = New System.Drawing.Point(6, 5)
        Me.Tempo.Maximum = New Decimal(New Integer() {260, 0, 0, 0})
        Me.Tempo.Name = "Tempo"
        Me.Tempo.Size = New System.Drawing.Size(52, 21)
        Me.Tempo.TabIndex = 176
        Me.Tempo.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri Light", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 177
        Me.Label6.Text = "Tempo"
        '
        'Répéter
        '
        Me.Répéter.AutoSize = True
        Me.Répéter.Location = New System.Drawing.Point(631, 14)
        Me.Répéter.Name = "Répéter"
        Me.Répéter.Size = New System.Drawing.Size(76, 17)
        Me.Répéter.TabIndex = 178
        Me.Répéter.Text = "CheckBox2"
        Me.Répéter.UseVisualStyleBackColor = True
        Me.Répéter.Visible = False
        '
        'ComboBox8
        '
        Me.ComboBox8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox8.FormattingEnabled = True
        Me.ComboBox8.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8"})
        Me.ComboBox8.Location = New System.Drawing.Point(713, 12)
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(45, 23)
        Me.ComboBox8.TabIndex = 179
        Me.ComboBox8.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(318, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 180
        Me.Label7.Text = "Staccato"
        '
        'LoopNumber
        '
        Me.LoopNumber.BackColor = System.Drawing.Color.Chocolate
        Me.LoopNumber.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoopNumber.ForeColor = System.Drawing.Color.White
        Me.LoopNumber.Location = New System.Drawing.Point(281, 5)
        Me.LoopNumber.Maximum = New Decimal(New Integer() {16, 0, 0, 0})
        Me.LoopNumber.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.LoopNumber.Name = "LoopNumber"
        Me.LoopNumber.Size = New System.Drawing.Size(35, 21)
        Me.LoopNumber.TabIndex = 181
        Me.LoopNumber.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(276, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 182
        Me.Label8.Text = "Repeat"
        '
        'AuDessus
        '
        Me.AuDessus.AutoSize = True
        Me.AuDessus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuDessus.Location = New System.Drawing.Point(412, 4)
        Me.AuDessus.Name = "AuDessus"
        Me.AuDessus.Size = New System.Drawing.Size(46, 17)
        Me.AuDessus.TabIndex = 183
        Me.AuDessus.Text = "Top"
        Me.AuDessus.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LemonChiffon
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(410, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 184
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LFinal
        '
        Me.LFinal.BackColor = System.Drawing.Color.Green
        Me.LFinal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LFinal.ForeColor = System.Drawing.Color.SeaShell
        Me.LFinal.Location = New System.Drawing.Point(366, 5)
        Me.LFinal.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.LFinal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.LFinal.Name = "LFinal"
        Me.LFinal.Size = New System.Drawing.Size(35, 21)
        Me.LFinal.TabIndex = 212
        Me.LFinal.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(369, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 213
        Me.Label3.Text = "Final"
        '
        'Comp
        '
        Me.Comp.BackColor = System.Drawing.Color.Blue
        Me.Comp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Comp.ForeColor = System.Drawing.Color.Linen
        Me.Comp.Location = New System.Drawing.Point(324, 5)
        Me.Comp.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.Comp.Name = "Comp"
        Me.Comp.Size = New System.Drawing.Size(35, 21)
        Me.Comp.TabIndex = 214
        '
        'Remote
        '
        Me.Remote.AutoSize = True
        Me.Remote.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Remote.Location = New System.Drawing.Point(631, 27)
        Me.Remote.Name = "Remote"
        Me.Remote.Size = New System.Drawing.Size(113, 17)
        Me.Remote.TabIndex = 215
        Me.Remote.Text = "Télécommande"
        Me.Remote.UseVisualStyleBackColor = True
        Me.Remote.Visible = False
        '
        'Bassemoins1
        '
        Me.Bassemoins1.AutoSize = True
        Me.Bassemoins1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bassemoins1.Location = New System.Drawing.Point(458, 4)
        Me.Bassemoins1.Name = "Bassemoins1"
        Me.Bassemoins1.Size = New System.Drawing.Size(83, 17)
        Me.Bassemoins1.TabIndex = 216
        Me.Bassemoins1.Text = "Basse -12"
        Me.Bassemoins1.UseVisualStyleBackColor = True
        Me.Bassemoins1.Visible = False
        '
        'Fournotes
        '
        Me.Fournotes.AutoSize = True
        Me.Fournotes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fournotes.Location = New System.Drawing.Point(457, 23)
        Me.Fournotes.Name = "Fournotes"
        Me.Fournotes.Size = New System.Drawing.Size(69, 17)
        Me.Fournotes.TabIndex = 217
        Me.Fournotes.Text = "4 Notes"
        Me.Fournotes.UseVisualStyleBackColor = True
        Me.Fournotes.Visible = False
        '
        'Transport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 52)
        Me.ControlBox = False
        Me.Controls.Add(Me.Fournotes)
        Me.Controls.Add(Me.Bassemoins1)
        Me.Controls.Add(Me.Remote)
        Me.Controls.Add(Me.Comp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LFinal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.AuDessus)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LoopNumber)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ComboBox8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Arrêt)
        Me.Controls.Add(Me.Play)
        Me.Controls.Add(Me.Répéter)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Tempo)
        Me.Controls.Add(Me.Terme)
        Me.Controls.Add(Me.Début)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Transport"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  "
        Me.TopMost = True
        CType(Me.Début, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Terme, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tempo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoopNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Comp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Arrêt As Button
    Friend WithEvents Play As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Début As NumericUpDown
    Friend WithEvents Terme As NumericUpDown
    Friend WithEvents Tempo As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Répéter As CheckBox
    Friend WithEvents ComboBox8 As Windows.Forms.ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents LoopNumber As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents AuDessus As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LFinal As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Comp As NumericUpDown
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Remote As CheckBox
    Friend WithEvents Bassemoins1 As CheckBox
    Friend WithEvents Fournotes As CheckBox
End Class
