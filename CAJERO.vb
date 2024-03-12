Imports System.Data.OleDb

Public Class CAJERO
    Private Function Carga_formulario(ByVal form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = form.Name Then
                form.Select()
                Return False
            End If
        Next
        form.MdiParent = Me
        form.Show()
        Return True
    End Function

    Private Sub NewToolStripButton_Click(sender As Object, e As EventArgs) Handles NewToolStripButton.Click
        Carga_formulario(ADMINISTRAR_USUARIOS)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Carga_formulario(MOVIMIENTOS)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

    End Sub

    Private Sub CAJERO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class