Class Application

	' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
	' can be handled in this file.


	Private Sub App_DispatcherUnhandledException(ByVal sender As Object, ByVal e As Windows.Threading.DispatcherUnhandledExceptionEventArgs)
		'TODO: See if this works
		MsgBox(e.Exception.ToString)
	End Sub



End Class
