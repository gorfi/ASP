Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data


Public Class dbLogin

    Public Sub PreencheAtributo(ByVal lDataReader As System.Data.IDataReader, ByVal NumeroColuna As Integer, ByRef Atributo As String)
        If (lDataReader.IsDBNull(NumeroColuna) = True) Then
            Atributo = Nothing
        Else
            Dim Valor As String = lDataReader.GetString(NumeroColuna)
            Atributo = CType(Valor, Object)
        End If
    End Sub
    Public Function VerificarUser(ByVal cpUser As String, cpPass As String) As Boolean
        Dim atrUser As String = Nothing
        Dim atrPass As String = Nothing
        Dim loginValido As Boolean = Nothing
        Dim DataBase As Database = DatabaseFactory.CreateDatabase
        Dim DataReader As IDataReader = Nothing

        Dim SQL As System.Text.StringBuilder = New System.Text.StringBuilder
        'select * from despMain.dbo.despLogin where cpUser = 'admin' and cpPass = 'teste'
        SQL.Append("select * from despLogin")
        SQL.Append(" where cpUser = '" & cpUser & "'")
        SQL.Append(" and cpPass = '" & cpPass & "'")
        'Criação do command com seus parametros
        '======================================
        Dim Command As System.Data.Common.DbCommand = DataBase.GetSqlStringCommand(SQL.ToString)

        Try
            DataReader = DataBase.ExecuteReader(Command)
            loginValido = DataReader.Read
            If (DataReader.Read = True) Then
                ' atrUser = DataReader.GetString(0)
                ' atrPass = DataReader.GetString(1)
            End If
        Finally
            If (Not (DataReader) Is Nothing) Then
                If (DataReader.IsClosed = False) Then
                    DataReader.Close()
                End If
                DataReader = Nothing
            End If

        End Try
        Return loginValido
    End Function
    Public Function RegistrarUser(ByVal cpUser As String, cpPass As String) As Boolean
        Dim atrUser As String = Nothing
        Dim atrPass As String = Nothing
        Dim registroValido As Boolean = Nothing
        Dim DataBase As Database = DatabaseFactory.CreateDatabase
        Dim DataReader As IDataReader = Nothing

        Dim SQL As System.Text.StringBuilder = New System.Text.StringBuilder
        'if not exists (select * from despLogin where cpUser = 'dev')
        'insert into despLogin VALUES ('dev','senha')
        SQL.Append("if not exists ")
        SQL.Append("(select * from despLogin where cpUser = '" & cpUser & "')" & vbNewLine)
        SQL.Append("insert into despLogin VALUES ('" & cpUser & "','" & cpPass & "')")
        'Criação do command com seus parametros
        '======================================
        Dim Command As System.Data.Common.DbCommand = DataBase.GetSqlStringCommand(SQL.ToString)

        Try
            DataReader = DataBase.ExecuteReader(Command)
            registroValido = DataReader.Read
            If (DataReader.Read = True) Then
                ' atrUser = DataReader.GetString(0)
                ' atrPass = DataReader.GetString(1)
            End If
        Finally
            If (Not (DataReader) Is Nothing) Then
                If (DataReader.IsClosed = False) Then
                    DataReader.Close()
                End If
                DataReader = Nothing
            End If

        End Try
        Return registroValido
    End Function
End Class
