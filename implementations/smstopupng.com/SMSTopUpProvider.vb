
''' <summary>
''' SMSTopUpNG SMS Provider available via smstopupng.com
''' </summary>
''' <remarks></remarks>
Public Class SMSTopUpProvider
    Inherits EsEmEs.Provider

	''' <summary>
    ''' Provider name which is SMSTopUpNG
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Identity() As String
        Get
            _Identity = SMSTopUp.IDENTITY
            Return _Identity
        End Get
    End Property

	''' <summary>
    ''' Provider root url
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Url() As String
        Get
            Return _Url
        End Get
        Set(ByVal value As String)
            _Url = value
        End Set
    End Property

	''' <summary>
    ''' About the Provider. A link to FAQ will suffice
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property About() As String
        Get
            Return _About
        End Get
        Set(ByVal value As String)
            _About = value
        End Set
    End Property

	''' <summary>
    ''' Provider authentication string. Dont forget the trailing ampersand
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Authentication() As String
        Get
            Return _Authentication
        End Get
        Set(ByVal value As String)
            _Authentication = value
        End Set
    End Property

    Sub New(Optional ByVal strUrl As String = SMSTopUp.URL)
        Me.Url = strUrl
    End Sub

	''' <summary>
    ''' Query the Provider and returning a Response
    ''' </summary>
    ''' <param name="objMessage">Message to ask Provider</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Query(ByVal objMessage As SMSTopUpMessage) As EsEmEs.Response
        Dim objResponse As New EsEmEs.Response
        Dim strUrl As String = ""

        strUrl = _Url & "type=sendmsg&" & _Authentication

        strUrl &= "recipients=" & SMSTopUp.Build(objMessage.Recipients) & "&"

        strUrl &= "campaignname=" & objMessage.Identity & "&"

        strUrl &= "message=" & System.Web.HttpUtility.UrlEncode(objMessage.MessageText) & "&"

        strUrl &= "isGrp=false"

        objResponse = SMSTopUp.HttpGET(strUrl)

        Return objResponse
    End Function

End Class
