Imports System.Windows.Forms

Public Class MDI_CAJERO

    Private Sub Logout()
        ' Close all open child forms
        For Each childForm As Form In MdiChildren
            childForm.Close()
        Next

        ' Perform any additional cleanup logic, such as resetting user session, etc.
        ' ...

        ' Show the login form or any other form to initiate a new session
        Dim loginForm As New LOGIN_CAJERO()
        loginForm.MdiParent = Me
        loginForm.Show()
    End Sub


    ' ... existing code ...
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

    Private Sub BTN_MOVIMIENTOS_Click_1(sender As Object, e As EventArgs) Handles BTN_MOVIMIENTOS.Click
        Carga_formulario(MOVIMIENTOS)
        oculta()

    End Sub

    Private Sub BTN_ADM_USUARIOS_Click(sender As Object, e As EventArgs) Handles BTN_ADM_USUARIOS.Click
        Carga_formulario(ADMINISTRAR_USUARIOS)
        oculta()


    End Sub
    Sub oculta()
        BTN_MOVIMIENTOS.Hide()
        BTN_ADM_USUARIOS.Hide()
        BTN_CREDITOS.Hide()
        BTN_REGISTRO.Hide()
        BTNLOGOUT.Hide()
    End Sub
    Sub muestra()
        BTNLOGOUT.Show()
        BTN_MOVIMIENTOS.Show()
        BTN_ADM_USUARIOS.Show()
        BTN_CREDITOS.Show()
        BTN_REGISTRO.Show()

    End Sub

    Private Sub BTN_CREDITOS_Click(sender As Object, e As EventArgs) Handles BTN_CREDITOS.Click
        Carga_formulario(CREDITOS)
        oculta()

    End Sub

    Private Sub BTN_REGISTRO_Click(sender As Object, e As EventArgs) Handles BTN_REGISTRO.Click
        Carga_formulario(REGISTRO_CAJERO)
        oculta()

    End Sub

    Private Sub BTN_ADM_USUARIOS_MouseHover(sender As Object, e As EventArgs) Handles BTN_ADM_USUARIOS.MouseHover
        ToolTip.SetToolTip(BTN_ADM_USUARIOS, "ADMINISTRAR USUARIOS")

    End Sub
    Private Sub BTN_CREDITOS_MouseHover(sender As Object, e As EventArgs) Handles BTN_CREDITOS.MouseHover
        ToolTip.SetToolTip(BTN_CREDITOS, "ACREDITAR CUENTAS")

    End Sub

    Private Sub BTN_MOVIMENTOS_MouseHover(sender As Object, e As EventArgs) Handles BTN_MOVIMIENTOS.MouseHover
        ToolTip.SetToolTip(BTN_MOVIMIENTOS, "MOVIMIENTOS")

    End Sub

    Private Sub BTN_REGISTRO_MouseHover(sender As Object, e As EventArgs) Handles BTN_REGISTRO.MouseHover
        ToolTip.SetToolTip(BTN_REGISTRO, "REGISTRO DE MOVIMIENTOS")

    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        Logout()
        oculta()
        LOGIN_CAJERO.TXT_USER.Clear()

        LOGIN_CAJERO.TXT_PASS.Clear()


    End Sub

    Private Sub BTNLOGOUT_MouseHover(sender As Object, e As EventArgs) Handles BTNLOGOUT.MouseHover
        ToolTip.SetToolTip(BTNLOGOUT, "LOG OUT")

    End Sub
End Class
