Imports System.Data.SqlClient

Public Class Form3
    Dim sqlCon As New SqlConnection("server=DELL-PC\SQLEXPRESS; database=course ; integrated security=true")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim query As String = "select * from student where email= '" & TextBox1.Text & "' and  password = '" & TextBox2.Text & "' "
        Dim cmd As New SqlCommand(query, sqlCon)
        Dim count
        sqlCon.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader
        reader.Read()
        If reader.HasRows Then
            Me.Hide()
        Else
            MsgBox("falued!")

        End If
        reader.Close()
        sqlCon.Close()

        sqlCon.Open()
        count = Convert.ToInt16(cmd.ExecuteScalar())
        Dim OBJ As New Form1
        Dim object2 As New Form1
        OBJ.nameStudent = count.ToString() ' رقم الصف الذي يطابق الايميل والباسورد المدخل 
        OBJ.Show()
        sqlCon.Close()
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox2.Text = ""
        TextBox2.PasswordChar = "*"
    End Sub
End Class