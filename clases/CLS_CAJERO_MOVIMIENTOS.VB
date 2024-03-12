Imports System.Data.OleDb
Imports System.IO

Public Class CLS_CAJERO_MOVIMIENTOS

    Dim ComandoSql As OleDbCommand
    Dim Sql As String


    Function Agregamovimiento1(ByVal nro_cuenta As Integer,
                               ByVal fecha As String,
                           ByVal tipo_operacion As String,
                               ByVal importe As Integer,
                               ByVal observacion As String) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_cajero)
            con.Open()

            Sql = "Insert into movimientos (nro_cuenta, fecha, tipo_operacion, importe, observacion) " _
                + "Values (@nro_cuenta,@fecha,@tipo_operacion,@importe,@observacion)"

            ComandoSql = New OleDbCommand
            With ComandoSql
                .Connection = con
                .CommandText = Sql
                .Parameters.AddWithValue("@nro_cuenta", nro_cuenta)
                .Parameters.AddWithValue("@fecha", fecha.ToUpper)
                .Parameters.AddWithValue("@tipo_operacion", tipo_operacion.ToUpper)
                .Parameters.AddWithValue("@importe", importe)
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
End Class
