<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDI_CAJERO
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDI_CAJERO))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.BTN_REGISTRO = New System.Windows.Forms.Button()
        Me.BTN_CREDITOS = New System.Windows.Forms.Button()
        Me.BTN_MOVIMIENTOS = New System.Windows.Forms.Button()
        Me.BTN_ADM_USUARIOS = New System.Windows.Forms.Button()
        Me.BTNLOGOUT = New System.Windows.Forms.Button()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 579)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1269, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel.Text = "Estado"
        '
        'BTN_REGISTRO
        '
        Me.BTN_REGISTRO.Image = CType(resources.GetObject("BTN_REGISTRO.Image"), System.Drawing.Image)
        Me.BTN_REGISTRO.Location = New System.Drawing.Point(944, 226)
        Me.BTN_REGISTRO.Name = "BTN_REGISTRO"
        Me.BTN_REGISTRO.Size = New System.Drawing.Size(209, 156)
        Me.BTN_REGISTRO.TabIndex = 3
        Me.BTN_REGISTRO.UseVisualStyleBackColor = True
        '
        'BTN_CREDITOS
        '
        Me.BTN_CREDITOS.Image = CType(resources.GetObject("BTN_CREDITOS.Image"), System.Drawing.Image)
        Me.BTN_CREDITOS.Location = New System.Drawing.Point(667, 226)
        Me.BTN_CREDITOS.Name = "BTN_CREDITOS"
        Me.BTN_CREDITOS.Size = New System.Drawing.Size(205, 156)
        Me.BTN_CREDITOS.TabIndex = 2
        Me.BTN_CREDITOS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_CREDITOS.UseVisualStyleBackColor = True
        '
        'BTN_MOVIMIENTOS
        '
        Me.BTN_MOVIMIENTOS.Image = CType(resources.GetObject("BTN_MOVIMIENTOS.Image"), System.Drawing.Image)
        Me.BTN_MOVIMIENTOS.Location = New System.Drawing.Point(399, 226)
        Me.BTN_MOVIMIENTOS.Name = "BTN_MOVIMIENTOS"
        Me.BTN_MOVIMIENTOS.Size = New System.Drawing.Size(207, 156)
        Me.BTN_MOVIMIENTOS.TabIndex = 1
        Me.BTN_MOVIMIENTOS.UseVisualStyleBackColor = True
        '
        'BTN_ADM_USUARIOS
        '
        Me.BTN_ADM_USUARIOS.Image = CType(resources.GetObject("BTN_ADM_USUARIOS.Image"), System.Drawing.Image)
        Me.BTN_ADM_USUARIOS.Location = New System.Drawing.Point(115, 226)
        Me.BTN_ADM_USUARIOS.Name = "BTN_ADM_USUARIOS"
        Me.BTN_ADM_USUARIOS.Size = New System.Drawing.Size(209, 156)
        Me.BTN_ADM_USUARIOS.TabIndex = 0
        Me.BTN_ADM_USUARIOS.UseVisualStyleBackColor = True
        '
        'BTNLOGOUT
        '
        Me.BTNLOGOUT.Image = CType(resources.GetObject("BTNLOGOUT.Image"), System.Drawing.Image)
        Me.BTNLOGOUT.Location = New System.Drawing.Point(1090, 475)
        Me.BTNLOGOUT.Name = "BTNLOGOUT"
        Me.BTNLOGOUT.Size = New System.Drawing.Size(63, 55)
        Me.BTNLOGOUT.TabIndex = 15
        Me.BTNLOGOUT.UseVisualStyleBackColor = True
        '
        'MDI_CAJERO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1269, 601)
        Me.Controls.Add(Me.BTNLOGOUT)
        Me.Controls.Add(Me.BTN_REGISTRO)
        Me.Controls.Add(Me.BTN_CREDITOS)
        Me.Controls.Add(Me.BTN_MOVIMIENTOS)
        Me.Controls.Add(Me.BTN_ADM_USUARIOS)
        Me.Controls.Add(Me.StatusStrip)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.IsMdiContainer = True
        Me.Name = "MDI_CAJERO"
        Me.Text = "BIENVENIDO"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents BTN_ADM_USUARIOS As Button
    Friend WithEvents BTN_MOVIMIENTOS As Button
    Friend WithEvents BTN_CREDITOS As Button
    Friend WithEvents BTN_REGISTRO As Button
    Friend WithEvents BTNLOGOUT As Button
End Class
