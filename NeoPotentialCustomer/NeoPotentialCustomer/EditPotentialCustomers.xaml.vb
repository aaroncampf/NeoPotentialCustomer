Public Class EditPotentialCustomers
	Dim db As New Database

	Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
		If Not My.Computer.Network.IsAvailable Then
			MsgBox("Internet is required")
			Me.Close()
			Exit Sub
		End If


		Dim Dropbox = New Dropbox.Api.DropboxClient(My.Resources.API_Key)
		Dim Test = Dropbox.Files.DownloadAsync("/Storage/PotentialCustomers.sdf")
		Dim Path = If(AppDomain.CurrentDomain.GetData("DataDirectory") Is Nothing, "", AppDomain.CurrentDomain.GetData("DataDirectory") & "\") & "PotentialCustomers.sdf"
		My.Computer.FileSystem.WriteAllBytes(Path, Test.Result.GetContentAsByteArrayAsync().Result, False)

		cbxPotentialCustomers.ItemsSource = db.PotentialCustomers.ToArray
	End Sub

	Private Sub btnCreatePotentialCustomer_Click(sender As Object, e As RoutedEventArgs) Handles btnCreatePotentialCustomer.Click
		Dim New_PotentialCustomer As New PotentialCustomer
		db.PotentialCustomers.Add(New_PotentialCustomer)
		cbxPotentialCustomers.Items.Add(New_PotentialCustomer)
		txtName.Focus()
	End Sub

	Private Sub btnUploadData_Click(sender As Object, e As RoutedEventArgs) Handles btnUploadData.Click
		Dim Dropbox = New Dropbox.Api.DropboxClient(My.Resources.API_Key)
		'|DataDirectory|\PotentialCustomers.sdf

		Dim Path = If(AppDomain.CurrentDomain.GetData("DataDirectory") Is Nothing, "", AppDomain.CurrentDomain.GetData("DataDirectory") & "\") & "PotentialCustomers.sdf"
		Dim Data = IO.File.OpenRead(Path)
		Dim Test = Dropbox.Files.UploadAsync("/Storage/PotentialCustomers.sdf", body:=Data)
		Dim Test_Result = Test.Result
	End Sub
End Class
