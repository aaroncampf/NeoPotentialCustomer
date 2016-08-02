Public Class EditPotentialCustomers
    Dim db As New Database

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        If Not My.Computer.Network.IsAvailable Then
            MsgBox("Internet is required")
            Me.Close()
            Exit Sub
        End If


        Dim Using_OneDrive = False
        If Using_OneDrive Then
            'Note: Do not put the credentials inside the code, this is public!
            MsgBox("OneDrive support not added yet for synchronizing data")
        End If

        cbxPotentialCustomers.ItemsSource = db.PotentialCustomers.ToArray
    End Sub

    Private Sub btnCreatePotentialCustomer_Click(sender As Object, e As RoutedEventArgs) Handles btnCreatePotentialCustomer.Click
        gbxPotentialCustomer.DataContext = New PotentialCustomer
        txtName.Focus()
    End Sub

End Class
