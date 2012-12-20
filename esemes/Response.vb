
''' <summary>
''' Message carrier between EsEmEs internal functions 
''' </summary>
''' <remarks></remarks>
Public Class Response
    Protected _State As Boolean = False
    Protected _Code As Integer = 0
    Protected _Message As String = ""

    ''' <summary>
    ''' Boolean state. An OK (true) or an Error (false)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property State() As Boolean
        Get
            Return _State
        End Get

        Set(ByVal value As Boolean)
            _State = value
        End Set
    End Property

    ''' <summary>
    ''' Integer code for more specific details or logging
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Code() As Integer
        Get
            Return _Code
        End Get

        Set(ByVal value As Integer)
            _Code = value
        End Set
    End Property


    ''' <summary>
    ''' Verbose message, typically more user friendly
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Message() As String
        Get
            Return _Message
        End Get

        Set(ByVal value As String)
            _Message = value
        End Set
    End Property
End Class