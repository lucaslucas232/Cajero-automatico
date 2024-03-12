Imports System.Data.OleDb
Imports System.IO
Public Class CLS_CAJERO_USUARIOS

    Dim ComandoSql As OleDbCommand
    Dim Sql As String
    Dim arrImage() As Byte
    Dim mstream As New System.IO.MemoryStream()

    Function AgregaUsuario(ByVal nombre As String, ByVal apellido As String,
                           ByVal telefono As String, ByVal correo As String,
                           ByVal cedula As String, ByVal fecha_nac As String,
                           ByVal nro_cuenta As Integer,
                           ByVal usuario As String, ByVal tipo As String,
                           ByVal contraseña As String, pic As PictureBox) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_cajero) 'APUNTA A LA BASE DE DATOS.. CON = CONEXION 
            con.Open()

            Dim FileSize As UInt32
            If pic.ImageLocation = Nothing Then
                FileSize = 0
            Else
                FileSize = mstream.Length
            End If

            Try
                pic.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                arrImage = mstream.GetBuffer()
                FileSize = mstream.Length
                mstream.Close()
            Catch
                FileSize = 0
            End Try

            Sql = "Insert into usuarios (nombre, apellido, telefono, correo, cedula, fecha_nac, nro_cuenta, usuario, tipo, contraseña, foto) " _
                + "Values (@nombre,@apellido,@telefono,@correo,@cedula,@fecha_nac,@nro_cuenta,@usuario,@tipo,@contraseña,@foto)"

            ComandoSql = New OleDbCommand
            With ComandoSql
                .Connection = con
                .CommandText = Sql
                .Parameters.AddWithValue("@nombre", nombre.ToUpper)
                .Parameters.AddWithValue("@apellido", apellido.ToUpper)
                .Parameters.AddWithValue("@telefono", telefono)
                .Parameters.AddWithValue("@correo", correo)
                .Parameters.AddWithValue("@cedula", cedula)
                .Parameters.AddWithValue("@fecha_nac", fecha_nac)
                .Parameters.AddWithValue("@nro_cuenta", nro_cuenta)
                .Parameters.AddWithValue("@usuario", usuario.ToUpper)
                .Parameters.AddWithValue("@tipo", tipo)
                .Parameters.AddWithValue("@contraseña", contraseña)
                .Parameters.AddWithValue("@foto", arrImage)

                .ExecuteNonQuery()
            End With

            ComandoSql.Dispose()
            Sql = String.Empty
            con.Close()
            Return True

        Catch exsql As OleDbException
            MsgBox(exsql.Message)
            Return False

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function


    Function Modificausuario(ByVal nombre As String,
                             ByVal apellido As String,
                           ByVal telefono As Integer,
                             ByVal correo As String,
                           ByVal cedula As String,
                             ByVal fecha_nac As String,
                           ByVal nro_cuenta As Integer,
                           ByVal usuario As String,
                             ByVal tipo As String,
                           ByVal contraseña As String,
                              pic As PictureBox,
                           ByVal IDUSUARIO As Integer) As Boolean
        Try

            Dim con As New OleDbConnection(RutaDB_cajero)

            Dim MS As New MemoryStream

            pic.Image.Save(MS, pic.Image.RawFormat)

            Dim Imagenes() As Byte = MS.GetBuffer

            con.Open()
            'TOUPPER  MAYUSCULAS  TOLOWER MINUSCULAS
            Sql = "UPDATE usuarios 
SET Nombre = '" & nombre.ToUpper & "',
apellido = '" & apellido.ToUpper & "', 
telefono = " & telefono & ", 
correo = '" & correo.ToUpper & "', 
cedula= '" & cedula & "', 
fecha_nac = '" & fecha_nac & "', 
nro_cuenta = " & nro_cuenta & ",
usuario = '" & usuario & "',
tipo = '" & tipo & "', 
contraseña = '" & contraseña & "',
foto=@pic
WHERE ID=" & IDUSUARIO & ""

            ComandoSql = New OleDbCommand(Sql, con)
            ComandoSql.Parameters.AddWithValue("@foto", Imagenes)

            ComandoSql.ExecuteNonQuery() 'EJECUTA LOS CAMBIOS
            ComandoSql.Dispose() 'LIMPIA LA VARIABLE 
            Sql = String.Empty 'EMPTY  LIMPIA LA VARIABLE
            con.Close()
            Return True

        Catch exsql As OleDbException
            Return False

        Catch ex As Exception
            Return False
        End Try

    End Function

    Function EliminaUsuarios(ByVal id As Integer) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_cajero)
            con.Open()
            Sql = "DELETE * FROM usuarios WHERE id =" & id
            ComandoSql = New OleDbCommand(Sql, con)
            ComandoSql.ExecuteNonQuery()
            ComandoSql.Dispose()
            Sql = String.Empty
            con.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Friend Function Modificausuario(text1 As String, text2 As String, text3 As String, id As Integer, pictureBox1 As PictureBox, text4 As String) As Boolean
        Throw New NotImplementedException()
    End Function
End Class