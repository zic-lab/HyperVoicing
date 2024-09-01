<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalquesMIDI
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CalquesMIDI))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ButtonApply = New System.Windows.Forms.Button()
        Me.ImageBas = New System.Windows.Forms.PictureBox()
        Me.ImageHaut = New System.Windows.Forms.PictureBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ImageBas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageHaut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonApply)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ImageBas)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ImageHaut)
        Me.SplitContainer1.Size = New System.Drawing.Size(469, 283)
        Me.SplitContainer1.SplitterDistance = 32
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 21)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Init"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(385, 210)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 31)
        Me.Button1.TabIndex = 41
        Me.Button1.Text = "Annuler"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ButtonApply
        '
        Me.ButtonApply.Location = New System.Drawing.Point(302, 210)
        Me.ButtonApply.Name = "ButtonApply"
        Me.ButtonApply.Size = New System.Drawing.Size(79, 31)
        Me.ButtonApply.TabIndex = 40
        Me.ButtonApply.Text = "OK"
        Me.ButtonApply.UseVisualStyleBackColor = True
        '
        'ImageBas
        '
        Me.ImageBas.Image = CType(resources.GetObject("ImageBas.Image"), System.Drawing.Image)
        Me.ImageBas.Location = New System.Drawing.Point(482, 43)
        Me.ImageBas.Name = "ImageBas"
        Me.ImageBas.Size = New System.Drawing.Size(34, 192)
        Me.ImageBas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ImageBas.TabIndex = 39
        Me.ImageBas.TabStop = False
        Me.ImageBas.Visible = False
        '
        'ImageHaut
        '
        Me.ImageHaut.Image = Global.HyperVoicing.My.Resources.Resources.flèche_bas_v2_
        Me.ImageHaut.Location = New System.Drawing.Point(482, 41)
        Me.ImageHaut.Name = "ImageHaut"
        Me.ImageHaut.Size = New System.Drawing.Size(34, 192)
        Me.ImageHaut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ImageHaut.TabIndex = 38
        Me.ImageHaut.TabStop = False
        '
        'CalquesMIDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 283)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "CalquesMIDI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calques MIDI"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ImageBas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageHaut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ImageHaut As PictureBox
    Friend WithEvents ImageBas As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ButtonApply As Button
    Friend WithEvents Button2 As Button
End Class
