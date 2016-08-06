Imports System.Threading.Tasks
Imports Microsoft.OneDrive.Sdk
Imports Xceed.Wpf.DataGrid

'NO ---To Get Token: https://dev.onedrive.com/auth/msa_oauth.htm => Press [Get Token] Button

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

	Private Sub button_Click_1(sender As Object, e As RoutedEventArgs) Handles button.Click
		Dim Client = Microsoft.OneDrive.Sdk.OneDriveClient.GetMicrosoftAccountClient(
			"51c470c8-7391-441d-8e53-9df884072802", "https://login.live.com/oauth20_desktop.srf", {"onedrive.readwrite"},
			webAuthenticationUi:=New FormsWebAuthenticationUi()
		)

		Client.AuthenticateAsync()

	End Sub
End Class


Public Class FormsWebAuthenticationUi
	Implements Microsoft.OneDrive.Sdk.IWebAuthenticationUi

	Public Function AuthenticateAsync(requestUri As Uri, callbackUri As Uri) As Task(Of IDictionary(Of String, String)) Implements IWebAuthenticationUi.AuthenticateAsync
		Throw New NotImplementedException()
	End Function
End Class