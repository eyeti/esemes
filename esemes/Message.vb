
''' <summary>
''' An EsEmEs message to be sent via Provider
''' </summary>
''' <remarks></remarks>
Public MustInherit Class Message
    Protected _Identity As String
    Protected _Recipients As List(Of String)
    Protected _MessageText As String

    ''' <summary>
    '''Send a message. Make sure recipients have been specified 
    ''' </summary>
    ''' <param name="objProvider">EsEmEs provider to send message with</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Send(ByRef objProvider As Provider) As Response
        Return Nothing
    End Function
End Class
