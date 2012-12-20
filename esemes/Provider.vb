
''' <summary>
''' Main handler for EsEmEs. Response and Message are output and input respectively
''' </summary>
''' <remarks></remarks>
Public MustInherit Class Provider
    Protected Shared _Identity As String
    Protected Shared _Url As String
    Protected Shared _About As String

    Protected _Authentication As String 'id & pass

    ''' <summary>
    ''' Makes queries to the Provider returning a Response
    ''' </summary>
    ''' <param name="objMessage">Message to ask Provider</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Query(ByVal objMessage As Message) As Response
        Return Nothing
    End Function
End Class