Public Class PotentialCustomer
    ''' <summary>The Unique Identifier for the record</summary> 
    Public Property id As Integer
    ''' <summary>The company's name</summary> 
    Public Property Name As String
    ''' <summary>The company's Address</summary> 
    Public Property Address As String
    ''' <summary>The company's city</summary> 
    Public Property City As String
    ''' <summary>The company's state</summary> 
    Public Property State As String
    ''' <summary>The company's zip code</summary> 
    Public Property Zip As String
    ''' <summary>The company's email address</summary> 
    Public Property Email As String
    ''' <summary>The customercompany's phone number</summary> 
    Public Property Phone As String
    ''' <summary>The company's type which is used to categorize the type of vusiness the company is for grouping and sorting</summary> 
    Public Property Type As String
    ''' <summary>Is the company interested in doing business?</summary> 
    Public Property Interested As Boolean
    ''' <summary>Has the company been contacted</summary> 
    Public Property Contacted As Boolean
    ''' <summary>Additional details about the company</summary> 
    Public Property Details As String
End Class
