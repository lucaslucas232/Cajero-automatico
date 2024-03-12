Imports System.Data.OleDb
Imports System.IO

Public Class CLS_CAJERO_CREDITOS

    Dim ComandoSql As OleDbCommand
    Dim Sql As String

    Function Agregamovimiento1(ByVal nro_cuenta As String, ByVal IMPORTE As String,
                           ByVal fecha As String, ByVal usuario As String, ByVal observacion As String) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_cajero) 'APUNTA A LA BASE DE DATOS.. CON = CONEXION 
            con.Open()

            Sql = "Insert into CREDITOS (nro_cuenta, importe, fecha, usuario, observacion) " _
                + "Values (@nro_cuenta,@importe,@fecha,@usuario,@observacion)"

            ComandoSql = New OleDbCommand
            With ComandoSql
                .Connection = con
                .CommandText = Sql
                .Parameters.AddWithValue("@nro_cuenta", nro_cuenta.ToUpper)
                .Parameters.AddWithValue("@importe", IMPORTE)
                .Parameters.AddWithValue("@fecha", fecha)
                .Parameters.AddWithValue("@usuario", usuario)
                .Parameters.AddWithValue("@observacion", observacion.ToUpper)

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


    Function Modificacreditos(ByVal nro_cuenta As Integer, ByVal importe As String,
                             ByVal fecha As String, ByVal usuario As String, ByVal observacion As String, ByVal IDUSUARIO As Integer) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_cajero)

            Dim MS As New MemoryStream

            con.Open()
            'TOUPPER  MAYUSCULAS  TOLOWER MINUSCULAS
            Sql = "UPDATE creditos SET nro_cuenta = " & nro_cuenta & ",
importe = '" & importe & "',
fecha = '" & fecha.ToUpper & "',
usuario= '" & usuario.ToUpper & "'
WHERE ID=" & IDUSUARIO & ""


            ComandoSql = New OleDbCommand(Sql, con)

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

    Function Eliminacreditos(ByVal id As Integer) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_cajero)
            con.Open()
            Sql = "DELETE * FROM creditos WHERE id =" & id
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

End Class



