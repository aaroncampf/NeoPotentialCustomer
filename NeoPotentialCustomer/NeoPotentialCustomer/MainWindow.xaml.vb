Imports Xceed.Wpf.DataGrid

Class MainWindow
    Dim db As New Database

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        gridPotentialCustomers.ItemsSource = New DataGridCollectionView(db.PotentialCustomers.ToArray)
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Exit Sub
        db.Database.CreateIfNotExists()

        Dim Data = XElement.Load("C:\Users\acampf\Documents\GitHub\NeoPotentialCustomer\Original\CallCust.xml")

        For Each Customer In Data.<Cust>
            db.PotentialCustomers.Add(New PotentialCustomer With {
                                        .Name = Customer.@Name,
                                        .Address = Customer.@Address,
                                        .City = Customer.@City,
                                        .State = Customer.@State,
                                        .Phone = Customer.@Phone,
                                        .Zip = Customer.@Zip,
                                        .Type = Customer.@Type,
                                        .Email = Customer.@Email,
                                        .Details = Customer.@Details
                                      }
            )


            '.Interested = Boolean.Parse(Customer.@Interested),
            '.Contacted = Boolean.Parse(Customer.@Contacted)
        Next

        db.SaveChanges()
    End Sub

    Private Sub gridPotentialCustomers_CurrentChanged(sender As Object, e As DataGridCurrentChangedEventArgs) Handles gridPotentialCustomers.CurrentChanged
        pgridSelectedRow.SelectedObject = e.NewCurrent
    End Sub

    Private Sub btnEditPotentialCustomers_Click(sender As Object, e As RoutedEventArgs) Handles btnEditPotentialCustomers.Click
        Dim Form As New EditPotentialCustomers
        Form.ShowDialog()
    End Sub
End Class
