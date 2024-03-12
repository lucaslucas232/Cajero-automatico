Imports System.Data.OleDb
Public Class CREDITOS
    Dim id As Integer
    Dim obj_creditos As New CLS_CAJERO_CREDITOS
    Dim n As Integer
    Function ValidarDatos() As Boolean

        If TXT_IMPORTE.Text.Trim = "" Then
            MsgBox("ingrese importe valido")
            TXT_IMPORTE.Focus()
            Return False
            Exit Function
        End If
        Return True

    End Function
    Sub ModoModificacion()
        BTN_AGREGAR.Enabled = False
        BTN_ELIMINAR.Enabled = True
        BTN_MODIFICAR.Enabled = True
        BTN_CANCELAR.Enabled = True
    End Sub
    Sub LimpiarCampos()
        TXT_IMPORTE.Text = ""
        TXT_OBSERVACION.Text = ""
    End Sub
    Sub ModoInsercion()
        BTN_CANCELAR.Enabled = True
        BTN_ELIMINAR.Enabled = False
        BTN_MODIFICAR.Enabled = True
        BTN_AGREGAR.Enabled = True
    End Sub
    Sub pinta_fila(ByVal nn As Integer)
        Try
            For i As Integer = 0 To DGV1.Rows.Count - 1
                DGV1.Rows(i).Selected = False
            Next
            If nn > 0 Then
                DGV1.Rows(nn).Selected = True
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DGV1_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV1.MouseClick
        Dim fecha1 As String
        fecha1 = CDate(DateTimePicker1.Text).ToString("MM/dd/yyyy")

        If DGV1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un usuario para poder editarlo", MsgBoxStyle.Critical, "Error")
            DGV1.Focus()
        Else
            Me.ModoModificacion()
            '            consulta = "Select CREDITOS.NRO_CUENTA, CREDITOS.FECHA, CREDITOS.USUARIO, CREDITOS.OBSERVACION, CREDITOS.IMPORTE
            'From CREDITOS
            'Where (((CREDITOS.NRO_CUENTA) = " & LBL_NUMERO_CUENTA.Text & "))
            'Order By CREDITOS.FECHA;"

            TXT_IMPORTE.Text = ObtenerCampo(Me.DGV1, 4)
            TXT_OBSERVACION.Text = ObtenerCampo(Me.DGV1, 3)
            LBL_NUMERO_CUENTA.Text = ObtenerCampo(Me.DGV1, 0)
            lbl_usuario.Text = ObtenerCampo(Me.DGV1, 2)
            DateTimePicker1.Text = ObtenerCampo(Me.DGV1, 1)
            id = ObtenerCampo(Me.DGV1, 5)
            BTN_AGREGAR.Enabled = False
            BTN_ELIMINAR.Enabled = True

            'ini = dgv1.CurrentRow.Index

        End If

    End Sub
    Function ObtenerCampo(ByVal grilla As DataGridView, ByVal indice_columna As Byte)
        Try
            If Not IsDBNull(grilla.Item(indice_columna, grilla.CurrentCell.RowIndex).Value) Then
                Return CStr(grilla.Item(indice_columna, grilla.CurrentCell.RowIndex).Value)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Sub ActualizarTabla1(ByVal grilla As DataGridView, ByVal nombre_tabla As String,
                        ByVal campoSql As String, ByVal C_ORDEN As String)
        Try
            Dim da As OleDbDataAdapter 'DATAADPTER
            Dim dt As DataTable
            Dim consulta As String 'f9
            consulta = "Select "
            If campoSql = "" Then
                consulta += "*"
            Else
                consulta += campoSql
            End If
            consulta += " From " & nombre_tabla & " ORDER BY " & C_ORDEN
            da = New OleDbDataAdapter(consulta, RutaDB_cajero)
            dt = New DataTable
            da.Fill(dt)
            n = dt.Rows.Count

            grilla.DataSource = dt
            grilla.ReadOnly = True 'SOLO DE LECTURA
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub ActualizarTabla(ByVal grilla As DataGridView)
        Try
            Dim da As OleDbDataAdapter 'DATAADPTER
            Dim dt As DataTable
            Dim consulta As String 'f9
            '            consulta = "SELECT CREDITOS.NRO_CUENTA, CREDITOS.IMPORTE, CREDITOS.FECHA, CREDITOS.USUARIO, CREDITOS.OBSERVACION 
            'From CREDITOS
            'Order By CREDITOS.FECHA DESC;"

            consulta = "Select CREDITOS.NRO_CUENTA, CREDITOS.FECHA, CREDITOS.USUARIO, CREDITOS.OBSERVACION, CREDITOS.IMPORTE, creditos.id
From CREDITOS
Where (((CREDITOS.NRO_CUENTA) = " & LBL_NUMERO_CUENTA.Text & "))
Order By CREDITOS.FECHA;"


            da = New OleDbDataAdapter(consulta, RutaDB_cajero)
            dt = New DataTable
            da.Fill(dt)
            n = dt.Rows.Count

            grilla.DataSource = dt
            grilla.ReadOnly = True 'SOLO DE LECTURA
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub carga_datos()
        Dim SQL As String
        Try
            SQL = "SELECT USUARIOS.NOMBRE, USUARIOS.APELLIDO, USUARIOS.NRO_CUENTA, USUARIOS.usuario From USUARIOS order by APELLIDO"

            Dim da As New OleDbDataAdapter(SQL, RutaDB_cajero)
            Dim dt As New DataTable

            da.Fill(dt)

            ListBox1.Items.Clear()

            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow 'dr datarow
                dr = dt.Rows(i)
                ListBox1.Items.Add(dr(0) & " - " & dr(1))

                ListBox2.Items.Add(dr(2))
                ListBox3.Items.Add(dr(3))

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CREDITOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carga_datos()
        TXT_NUMERO_CUENTA.Select()
        BTN_ELIMINAR.Enabled = False
        BTN_AGREGAR.Enabled = True
        BTN_CANCELAR.Enabled = False
        BTN_MODIFICAR.Enabled = False
        Me.TXT_NUMERO_CUENTA.Focus()

    End Sub

    Private Sub TXT_NUMERO_CUENTA_TextChanged(sender As Object, e As EventArgs) Handles TXT_NUMERO_CUENTA.TextChanged
        Dim SQL As String
        Dim DATO As String

        DATO = TXT_NUMERO_CUENTA.Text & "%"
        '                   0                  1
        SQL = "Select USUARIOS.NOMBRE, USUARIOS.APELLIDO, USUARIOS.NRO_CUENTA, usuarios.usuario From USUARIOS
Where (((USUARIOS.nombre) Like '" & DATO & "'));"

        Dim da As New OleDbDataAdapter(SQL, RutaDB_cajero)
        Dim dt As New DataTable
        da.Fill(dt)
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()

        For i = 0 To dt.Rows.Count - 1
            Dim dr As DataRow
            dr = dt.Rows(i)
            ListBox1.Items.Add(dr(0) & " - " & dr(1))
            ListBox2.Items.Add(dr(2))
            ListBox3.Items.Add(dr(3))

        Next

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox2.SelectedIndex = ListBox1.SelectedIndex
        ListBox3.SelectedIndex = ListBox1.SelectedIndex

        LBL_NUMERO_CUENTA.Text = ListBox2.Text
        lbl_usuario.Text = ListBox3.Text

        ActualizarTabla(DGV1)

    End Sub


    Private Sub BTN_FIN_Click(sender As Object, e As EventArgs) Handles BTN_FIN.Click
        MDI_CAJERO.muestra()
        Me.Close()

    End Sub

    Private Sub BTN_CANCELAR_Click(sender As Object, e As EventArgs) Handles BTN_CANCELAR.Click
        BTN_MODIFICAR.Enabled = False
        BTN_ELIMINAR.Enabled = False
        BTN_AGREGAR.Enabled = True

        LimpiarCampos()

        Me.TXT_NUMERO_CUENTA.Focus()

    End Sub

    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            If ValidarDatos() Then
                If obj_creditos.Agregamovimiento1(LBL_NUMERO_CUENTA.Text, TXT_IMPORTE.Text, DateTimePicker1.Value, lbl_usuario.Text, TXT_OBSERVACION.Text) = True Then

                    MsgBox("Registro ingresado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")

                    ActualizarTabla1(Me.DGV1, "creditos", "", "fecha")
                    LimpiarCampos()
                Else
                    MsgBox("Error al ingresar el registro, reintente la accion", MsgBoxStyle.Critical, "Error")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
        End Try

    End Sub


    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        Try
            Dim i = MsgBox("¿Desea modificar ese registro?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmación")

            If i = MsgBoxResult.Yes Then

                If ValidarDatos() Then
                    If obj_creditos.Modificacreditos(Val(LBL_NUMERO_CUENTA.Text),
                                                     TXT_IMPORTE.Text,
                                                     DateTimePicker1.Value,
                                                     lbl_usuario.Text,
                                                     TXT_OBSERVACION.Text, id) = True Then
                        MsgBox("Registro actualizado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                        Me.LimpiarCampos()
                        ActualizarTabla1(Me.DGV1, "creditos", "", "fecha")

                        Me.ModoInsercion()
                    Else
                        MsgBox("Error al modificar el registro, reintente la acción", MsgBoxStyle.Critical, "Error")
                    End If
                End If
            End If
            Me.LimpiarCampos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
        End Try

    End Sub


    Private Sub BTN_ELIMINAR_Click(sender As Object, e As EventArgs) Handles BTN_ELIMINAR.Click
        Dim i = MsgBox("¿Desea eliminar este registro?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmación")
        If i = MsgBoxResult.Yes Then
            Try

                If obj_creditos.Eliminacreditos(id) = True Then
                    MsgBox("Registro Eliminado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                    Me.LimpiarCampos()
                    ActualizarTabla1(Me.DGV1, "creditos", "", "fecha")
                    Me.ModoInsercion()
                    Me.LimpiarCampos()
                Else
                    MsgBox("Error al eliminar el registro, reintente la accion", MsgBoxStyle.Critical, "Error")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
            End Try
        Else
        End If

    End Sub

    Private Sub CREDITOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Me.Close()
        MDI_CAJERO.muestra()
    End Sub

    Private Sub txt_importe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_IMPORTE.KeyPress

        If InStr("0123456789" & Chr(8), e.KeyChar) Then
            e.Handled = False

        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

    End Sub
End Class
