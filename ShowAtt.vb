﻿Imports System.IO

Public Class ShowAtt

    Dim att As New Attendances

    Private Sub loadabsensi()
        Dim sqlcommand As MySqlCommand = SQLConnection.CreateCommand
        '  sqlcommand.CommandText = "select b.FingerId, a.EmployeeCode, a.FullName, a.Tanggal as Dates, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal = @date1"
        Dim query As MySqlCommand = SQLConnection.CreateCommand
        query.CommandText = "select user from db_temp"
        Dim querr As String = CStr(query.ExecuteScalar)
        query.CommandText = "select kim3 from db_user where username = '" & Label2.Text & "'"
        Dim quer1 As String = CStr(query.ExecuteScalar)
        query.CommandText = "select kim4 from db_user where username= '" & Label2.Text & "'"
        Dim quer22 As String = CStr(query.ExecuteScalar)
        query.CommandText = "select pantailabu from db_user where username = '" & Label2.Text & "'"
        Dim quer3 As String = CStr(query.ExecuteScalar)
        If quer1 = "True" And quer22 = "False" And quer3 = "False" Then
            sqlcommand.CommandText = "select b.FingerId, a.EmployeeCode, a.FullName, a.Tanggal as Dates, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal = @date1 and b.officelocation = 'KIM 3'"
        ElseIf quer1 = "True" And quer22 = "True" And quer3 = "False" Then
            sqlcommand.CommandText = "select b.FingerId, a.EmployeeCode, a.FullName, a.Tanggal as Dates, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal = @date1 and b.officelocation <> 'Pantai Labu' and b.officelocation != '<empty>'"
        ElseIf quer1 = "True" And quer22 = "False" And quer3 = "True" Then
            sqlcommand.CommandText = "select b.FingerId, a.EmployeeCode, a.FullName, a.Tanggal as Dates, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal = @date1 and b.officelocation <> 'KIM 4' and b.officelocation != '<empty>'"
        ElseIf quer1 = "False" And quer22 = "True" And quer3 = "True" Then
            sqlcommand.CommandText = "select b.FingerId, a.EmployeeCode, a.FullName, a.Tanggal as Dates, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal = @date1 and b.officelocation <> 'KIM 3' and b.officelocation != '<empty>'"
        ElseIf quer1 = "False" And quer22 = "False" And quer3 = "True" Then
            sqlcommand.CommandText = "select b.FingerId, a.EmployeeCode, a.FullName, a.Tanggal as Dates, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal = @date1 and b.officelocation = 'Pantai Labu'"
        ElseIf quer1 = "False" And quer22 = "True" And quer3 = "False" Then
            sqlcommand.CommandText = "select b.FingerId, a.EmployeeCode, a.FullName, a.Tanggal as Dates, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal = @date1 and b.officelocation = 'KIM 4'"
        Else
            'sqlcommand.CommandText = "select b.FingerId, a.EmployeeCode, a.FullName, a.Tanggal as Dates, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal = @date1"
            sqlcommand.CommandText = "select b.FingerId, a.EmployeeCode, a.FullName, a.Tanggal as Dates, a.Shift, Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal = @date1"
        End If
        ' sqlcommand.CommandText = "select b.FingerId,  a.EmployeeCode, a.FullName, a.Tanggal as Dates, a.Shift , Date_Format(a.JamMulai, '%H:%i:%s') as SignIn, DATE_FORMAT(a.JamSelesai, '%H:%i:%s') as SignOut, b.EmployeeType from db_absensi a, db_pegawai b where a.EmployeeCode = b.EmployeeCode and a.tanggal = @date1"
        sqlcommand.Parameters.AddWithValue("@date1", DateTimePicker1.Value.Date)
        Dim dt As New DataTable
        dt.Load(sqlcommand.ExecuteReader)
        Attendances.Close()
        With Attendances
            .GridControl1.DataSource = dt
            .Label14.Text = Label2.Text
            .Show()
        End With
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'Attendances.Close()
        loadabsensi()
        Hide()
        '        Close()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Close()
    End Sub

    Private Sub ShowAtt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLConnection.Close()
        SQLConnection.ConnectionString = CONSTRING
        If SQLConnection.State = ConnectionState.Closed Then
            SQLConnection.Open()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub DateTimePicker1_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Attendances.Close()
            loadabsensi()
            Close()
        End If
    End Sub
End Class