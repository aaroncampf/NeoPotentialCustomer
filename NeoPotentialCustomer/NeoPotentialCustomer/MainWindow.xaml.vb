Imports Xceed.Wpf.DataGrid

Class MainWindow
    Dim db As New Database

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
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

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim Customers = db.PotentialCustomers.Where(Function(x) x.Name IsNot Nothing AndAlso x.Name <> "").Take(100)

        Dim collectionView As New DataGridCollectionView(Customers.ToArray)
        'collectionView.GroupDescriptions.Add(New DataGridGroupDescription("Name"))
        'collectionView.GroupDescriptions.Add(New DataGridGroupDescription("City"))
        gridPotentialCustomers.ItemsSource = collectionView

        'gridPotentialCustomers.group()


        'For Each Customer In Customers.ToArray
        '    gridPotentialCustomers.Items.Add(Customer)
        'Next




    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        pgridSelectedRow.SelectedObject = New With {.Name = "Aaron Campf", .Age = 26}
    End Sub

    Private Sub gridPotentialCustomers_CurrentChanging(sender As Object, e As DataGridCurrentChangingEventArgs) Handles gridPotentialCustomers.CurrentChanging
        pgridSelectedRow.SelectedObject = e.NewCurrent
    End Sub
End Class
