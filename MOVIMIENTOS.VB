Imports System.Data.OleDb

Public Class MOVIMIENTOS
    Dim SQL As String
    Dim ini As Integer
    Dim obj_movimientos As New CLS_CAJERO_MOVIMIENTOS

    'Private da As OleDbDataAdapter, consulta As OleDbDataAdapter
    Private da1 As OleDbDataAdapter
    Private da2 As OleDbDataAdapter
    Private da3 As OleDbDataAdapter
    Dim INDICA As String
    Dim contadorErrores As Byte = 0
    Dim LLAVE As Integer

    ' Dim fecha1 As String
    Sub LimpiarCampos()
        txt_importe.Text = ""
        txt_observacion.Text = ""
        RadioButton1.Text = "0"
        RadioButton2.Text = "0"
        RadioButton3.Text = "0"
        RadioButton4.Text = "0"
        RadioButton5.Text = "0"
        RadioButton6.Text = "0"
        DateTimePicker1.Select()

    End Sub

    Sub CONTADOR()
        MsgBox("CEDULA EQUIVOCADA, REINTENTE")

        If contadorErrores >= 2 Then
            MsgBox("ERROR EN VALIDACION DE CEDULA")
            txt_importe.Text = ""
            txt_observacion.Text = ""
            RadioButton1.Text = "0"
            RadioButton2.Text = "0"
            RadioButton3.Text = "0"
            RadioButton4.Text = "0"
            RadioButton5.Text = "0"
            RadioButton6.Text = "0"
            INDICA = ""
            contadorErrores = 0


        End If
    End Sub

    Sub carga_datos()
        'fecha1 = CDate(DateTimePicker1.Text).ToString("MM/dd/yyyy")

        Dim SQL As String
        '               0                   1
        SQL = "SELECT USUARIOS.NOMBRE,
USUARIOS.APELLIDO, USUARIOS.NRO_CUENTA, USUARIOS.usuario, usuarios.tipo From USUARIOS order by APELLIDO"

        Dim da As New OleDbDataAdapter(SQL, RutaDB_cajero)
        Dim dt As New DataTable

        da.Fill(dt)

        For i = 0 To dt.Rows.Count - 1
            Dim dr As DataRow 'dr datarow
            dr = dt.Rows(i)
        Next
    End Sub
    Function VALIDARCEDULA() As Boolean
        Try
            If RadioButton1.Checked = modulo_cajero.cedula Then

            Else
                MsgBox("CEDULA EQUIVOCADA")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        Return True

    End Function

    Sub saldo()

        Try

            Dim CRED As Double

            Dim retiro As String = "RETIRO"
            Dim DEPOSITO As String = "DEPOSITO"
            Dim DEP As Double
            Dim SQL As String
            SQL = " SELECT CREDITOS.NRO_CUENTA, Sum(CREDITOS.IMPORTE) AS SumaDeIMPORTE
From CREDITOS
Group By CREDITOS.NRO_CUENTA
HAVING(((CREDITOS.NRO_CUENTA) = " & LBL_NUMERO_CUENTA.Text & "));"

            da1 = New OleDbDataAdapter(SQL, RutaDB_cajero)
            Dim dt1 As New DataTable
            da1.Fill(dt1)

            Dim dr1 As DataRow
            If dt1.Rows.Count > 0 Then




                dr1 = dt1.Rows(0)

                CRED = Val(dr1(1).ToString)


            Else
                CRED = 0

            End If



            '***************************************
            SQL = " SELECT MOVIMIENTOS.NRO_CUENTA, Sum(MOVIMIENTOS.IMPORTE) AS SumaDeIMPORTE
FROM MOVIMIENTOS
WHERE (((MOVIMIENTOS.TIPO_OPERACION)='" & retiro & "'))
GROUP BY MOVIMIENTOS.NRO_CUENTA
HAVING (((MOVIMIENTOS.NRO_CUENTA)=" & LBL_NUMERO_CUENTA.Text & "));"

            da2 = New OleDbDataAdapter(SQL, RutaDB_cajero)
            Dim dt2 As New DataTable
            da2.Fill(dt2)
            Dim dr2 As DataRow
            dr2 = dt2.Rows(0)

            Dim RET As Double

            RET = Val(dr2(1).ToString)

            '*************************************

            SQL = "SELECT MOVIMIENTOS.NRO_CUENTA, Sum(MOVIMIENTOS.IMPORTE) AS SumaDeIMPORTE
FROM MOVIMIENTOS
WHERE (((MOVIMIENTOS.TIPO_OPERACION)='" & DEPOSITO & "'))
GROUP BY MOVIMIENTOS.NRO_CUENTA
HAVING (((MOVIMIENTOS.NRO_CUENTA)=" & LBL_NUMERO_CUENTA.Text & "));"

            da3 = New OleDbDataAdapter(SQL, RutaDB_cajero)
            Dim dt3 As New DataTable
            da3.Fill(dt3)
            Dim dr3 As DataRow
            dr3 = dt3.Rows(0)
            DEP = Val(dr3(1).ToString)

            Dim SALDO As Double

            SALDO = CRED - RET + DEP
            LBL_SALDO.Text = SALDO.ToString

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Function ValidarDatos() As Boolean
        Try

            SQL = " Select USUARIOS.NRO_CUENTA, USUARIOS.CEDULA
From USUARIOS
Where (((USUARIOS.NRO_CUENTA) = " & LBL_NUMERO_CUENTA.Text & "));"

            da3 = New OleDbDataAdapter(SQL, RutaDB_cajero)
            Dim dt3 As New DataTable
            da3.Fill(dt3)
            Dim dr3 As DataRow
            dr3 = dt3.Rows(0)
            modulo_cajero.cedula = Val(dr3(1).ToString)


            Dim ALEATORIO As Byte
            '31257894
            ALEATORIO = Int((9 - 1 + 1) * Rnd() + 1)
            Dim CI1 As String = Mid(modulo_cajero.cedula, 1, 7) & ALEATORIO
            ALEATORIO = Int((9 - 1 + 1) * Rnd() + 1)
            Dim CI2 As String = Mid(modulo_cajero.cedula, 1, 7) & ALEATORIO
            ALEATORIO = Int((9 - 1 + 1) * Rnd() + 1)
            Dim CI3 As String = Mid(modulo_cajero.cedula, 1, 7) & ALEATORIO
            ALEATORIO = Int((9 - 1 + 1) * Rnd() + 1)
            Dim CI4 As String = Mid(modulo_cajero.cedula, 1, 7) & ALEATORIO
            ALEATORIO = Int((9 - 1 + 1) * Rnd() + 1)
            Dim CI5 As String = Mid(modulo_cajero.cedula, 1, 7) & ALEATORIO


            Dim ALEATORIO1 As Byte = Int((6 - 1 + 1) * Rnd() + 1)
            LLAVE = ALEATORIO

            Select Case ALEATORIO1

                Case 1
                    RadioButton1.Text = modulo_cajero.cedula
                    RadioButton2.Text = CI1
                    RadioButton3.Text = CI2
                    RadioButton4.Text = CI3
                    RadioButton5.Text = CI4
                    RadioButton6.Text = CI5

                Case 2
                    RadioButton2.Text = modulo_cajero.cedula
                    RadioButton1.Text = CI1
                    'RadioButton2.Text = CI1
                    RadioButton3.Text = CI2
                    RadioButton4.Text = CI3
                    RadioButton5.Text = CI4
                    RadioButton6.Text = CI5
                Case 3
                    RadioButton3.Text = modulo_cajero.cedula
                    RadioButton1.Text = CI2
                    RadioButton2.Text = CI1
                    'RadioButton3.Text = CI2
                    RadioButton4.Text = CI3
                    RadioButton5.Text = CI4
                    RadioButton6.Text = CI5
                Case 4
                    RadioButton4.Text = modulo_cajero.cedula
                    RadioButton1.Text = CI2
                    RadioButton2.Text = CI1
                    RadioButton3.Text = CI3
                    ' RadioButton4.Text = CI3
                    RadioButton5.Text = CI4
                    RadioButton6.Text = CI5

                Case 5
                    RadioButton5.Text = modulo_cajero.cedula
                    RadioButton1.Text = CI1
                    RadioButton2.Text = CI2
                    RadioButton3.Text = CI3
                    RadioButton4.Text = CI4
                    ' RadioButton5.Text = CI4
                    RadioButton6.Text = CI5

                Case 6
                    RadioButton6.Text = modulo_cajero.cedula
                    RadioButton2.Text = CI1
                    RadioButton3.Text = CI2
                    RadioButton4.Text = CI3
                    RadioButton5.Text = CI4
                    ' RadioButton6.Text = CI5

            End Select


            If txt_importe.Text.Trim = "" Then
                MsgBox("ingrese importe valido")
                txt_importe.Focus()
                Return False
                Exit Function
            End If
            Return True
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub MOVIMIENTOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carga_datos()

        LBL_USUARIO.Text = usuario
        LBL_NUMERO_CUENTA.Text = nro_cuenta

        saldo()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        MDI_CAJERO.muestra()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Val(LBL_SALDO.Text) > Val(txt_importe.Text) Then
                MsgBox("SELECCIONE SU NUMERO DE CEDULA")
                ValidarDatos()
            Else
                MsgBox("SALDO INSUFICIENTE")
                LimpiarCampos()
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
        End Try
    End Sub

    Private Sub BTN_REALIZAR_Click(sender As Object, e As EventArgs) Handles btn_realizar.Click
        Dim fecha1 As String
        fecha1 = CDate(DateTimePicker1.Text).ToString("MM/dd/yyyy")
        Try
            If INDICA = modulo_cajero.cedula Then

                If obj_movimientos.Agregamovimiento1(LBL_NUMERO_CUENTA.Text, DateTimePicker1.Text, CMB_TIPO_OPERACION.Text, txt_importe.Text, txt_observacion.Text) = True Then

                    MsgBox("Registro ingresado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                    LimpiarCampos()
                    saldo()

                    ' ActualizarTabla1("movimientos", "", "fecha")
                Else
                    MsgBox("Error al ingresar el registro, reintente la accion", MsgBoxStyle.Critical, "Error")
                End If
            Else
                Me.contadorErrores += 1
                CONTADOR()


            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
        End Try
    End Sub
    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        INDICA = RadioButton1.Text
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        INDICA = RadioButton2.Text

    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        INDICA = RadioButton3.Text
    End Sub

    Private Sub RadioButton5_Click(sender As Object, e As EventArgs) Handles RadioButton5.Click
        INDICA = RadioButton5.Text
    End Sub

    Private Sub RadioButton4_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click
        INDICA = RadioButton4.Text
    End Sub

    Private Sub RadioButton6_Click(sender As Object, e As EventArgs) Handles RadioButton6.Click
        INDICA = RadioButton6.Text
    End Sub

    Private Sub txt_importe_TextChanged(sender As Object, e As EventArgs) Handles txt_importe.TextChanged

    End Sub

    Private Sub MOVIMIENTOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        MDI_CAJERO.muestra()
    End Sub

    Private Sub txt_importe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_importe.KeyPress

        If InStr("0123456789" & Chr(8), e.KeyChar) Then
            e.Handled = False

        Else
            e.Handled = True
        End If

    End Sub

    Private Sub CMB_TIPO_OPERACION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_TIPO_OPERACION.SelectedIndexChanged

    End Sub
End Class