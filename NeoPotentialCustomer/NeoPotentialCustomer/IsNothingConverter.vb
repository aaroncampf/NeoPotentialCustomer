Imports System.Globalization


''' <summary>
''' Checks to see if a value is null
''' </summary>
''' <remarks></remarks>
Public Class IsNothingConverter
    Implements IValueConverter


    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        Return value IsNot Nothing
    End Function


    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class
