
''' <summary>
''' A message to be sent via smstopupng.com
''' </summary>
''' <remarks></remarks>
Public Class SMSTopUpMessage
    Inherits EsEmEs.Message

	''' <summary>
    ''' Sender ID for SMS message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Identity() As String
        Get
            Return _Identity
        End Get

        Set(ByVal value As String)
            If value.Length > SMSTopUp.ID_LEN_MAX Then
                _Identity = value.Substring(0, SMSTopUp.ID_LEN_MAX)
            Else
                _Identity = value
            End If
        End Set
    End Property

	''' <summary>
    ''' SMS message recipients. SMSTopUp.Polish formats them before Send
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Recipients() As List(Of String)
        Get
            Return (_Recipients)
        End Get

        Set(ByVal value As List(Of String))
            _Recipients = value
        End Set
    End Property

	''' <summary>
    ''' Contents of the SMS message. Will be truncated if above SMSTopUp.MSG_LEN_MAX
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MessageText() As String
        Get
            Return _MessageText
        End Get

        Set(ByVal value As String)
            If value.Length > SMSTopUp.MSG_LEN_MAX Then
                'truncate
                _MessageText = value.Substring(0, SMSTopUp.MSG_LEN_MAX)
            Else
                _MessageText = value
            End If
        End Set
    End Property

	''' <summary>
    ''' Send a message. Make sure recipients have been specified 
    ''' </summary>
    ''' <param name="objProvider">Provider to query</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Send(ByRef objProvider As SMSTopUpProvider) As EsEmEs.Response
        Return objProvider.Query(Me)
    End Function
End Class
