
Imports System.IO
Imports System.Net

''' <summary>
''' SMSTopUpNG constants and utilities
''' </summary>
''' <remarks></remarks>
Public Class SMSTopUp
    Public Const IDENTITY As String = "SMSTopUpNG"
    Public Const ID_LEN_MAX As Integer = 11
    Public Const URL As String = "http://executive.smstopupng.com/api.aspx?"

    ''' <summary>
    ''' Maximum message length for truncation
    ''' </summary>
    ''' <remarks></remarks>
    Public Const MSG_LEN_MAX As Integer = 160

    ''' <summary>
    ''' Seperating character of message recipient numbers
    ''' </summary>
    ''' <remarks></remarks>
    Public Const MSG_NUM_SPR As Char = ","

    ''' <summary>
    ''' Country code e.g 234 for Nigeria
    ''' </summary>
    ''' <remarks></remarks>
    Public Const COUNTRY_CODE As String = "234"

	''' <summary>
    ''' Build a list of recipents into SMSTopUpNG format 
    ''' </summary>
    ''' <param name="lstRaw">List of recipients</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Build(ByRef lstRaw As List(Of String), Optional ByVal charDelimiter As Char = SMSTopUp.MSG_NUM_SPR) As String
        Dim retString As String = ""
        For Each SingleString In lstRaw
            retString &= Polish(SingleString) & charDelimiter
        Next
        Return retString.Substring(0, retString.Length - 1) 'remove trailing delimiter
    End Function

    ''' <summary>
    ''' Polish an unformatted phone number into SMSTopUpNG format
    ''' </summary>
    ''' <param name="strRawNumber">Unformatted phone number</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Polish(ByVal strRawNumber As String) As String
        Dim retString As String = ""

        'change 08025336506 to 2348025336506
        If strRawNumber.StartsWith("0") Then
            retString = SMSTopUp.COUNTRY_CODE & strRawNumber.Substring(1)
        End If

        'change +2348025336506 to 2348025336506
        If strRawNumber.StartsWith("+") Then
            retString = strRawNumber.Substring(1)
        End If

        Return retString
    End Function

    ''' <summary>
    ''' HTTP Query to url
    ''' </summary>
    ''' <param name="strUrl">Url to query</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function HttpGET(ByVal strUrl As String) As EsEmEs.Response
        Dim retResponse As New EsEmEs.Response
        Dim strMessage As String = ""

        Try
            Dim objRequest As HttpWebRequest = WebRequest.Create(strUrl)
            Dim objResponse As HttpWebResponse = objRequest.GetResponse
            Dim objReader As New StreamReader(objResponse.GetResponseStream())


            strMessage = objReader.ReadToEnd

            objReader.Close()

            retResponse.State = True
            retResponse.Message = strMessage

        Catch ex As Exception
            retResponse.State = False
            retResponse.Message = ex.ToString
        End Try

        If retResponse.Message.StartsWith("success:") Then
            retResponse.State = True
        Else
            retResponse.State = False
        End If

        Return retResponse
    End Function

End Class
