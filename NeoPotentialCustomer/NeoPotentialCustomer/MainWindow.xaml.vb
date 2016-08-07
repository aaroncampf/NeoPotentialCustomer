Imports Xceed.Wpf.DataGrid

'NO ---To Get Token: https://dev.onedrive.com/auth/msa_oauth.htm => Press [Get Token] Button

Class MainWindow
	Dim db As New Database

	Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
		gridPotentialCustomers.ItemsSource = New DataGridCollectionView(db.PotentialCustomers.ToArray)
	End Sub

	Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
		db.Database.CreateIfNotExists()

		Dim Data = XElement.Load("C:\Users\aaron\Documents\GitHub\NeoPotentialCustomer\Original\CallCust.xml")

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
			})

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
		gridPotentialCustomers.ItemsSource = New DataGridCollectionView(db.PotentialCustomers.ToArray)
	End Sub


	Private Sub btnUpdate_Click(sender As Object, e As RoutedEventArgs) Handles btnUpdate.Click
		If Not My.Computer.Network.IsAvailable Then
			MsgBox("No Internet")
			Exit Sub
		End If

		db.Dispose()

		Dim Dropbox = New Dropbox.Api.DropboxClient(My.Resources.API_Key)
		Dim Test = Dropbox.Files.DownloadAsync("/Storage/PotentialCustomers.sdf")


		Dim Path = If(AppDomain.CurrentDomain.GetData("DataDirectory") Is Nothing, "", AppDomain.CurrentDomain.GetData("DataDirectory") & "\") & "PotentialCustomers.sdf"
		My.Computer.FileSystem.WriteAllBytes(Path, Test.Result.GetContentAsByteArrayAsync().Result, False)


		db = New Database
		gridPotentialCustomers.ItemsSource = New DataGridCollectionView(db.PotentialCustomers.ToArray)
	End Sub
End Class