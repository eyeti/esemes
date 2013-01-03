esemes
=========

SMS library for .NET developers written in VB.NET and can be extended to your own Bulk SMS platform or account

smstopupng.com implementation
=========
Dim testSMSPro As New SMSTopUpProvider
testSMSPro.Authentication = "username=mail@abc.com&password=xxxx&"

Dim testSMSMsg As New SMSTopUpMessage
testSMSMsg.Identity = "olibenu.com"
testSMSMsg.MessageText = "Have a nice day"

Dim lstRecipients As New List(Of String)
lstRecipients.Add("08012345678")

testSMSMsg.Recipients = lstRecipients

testSMSMsg.Send(testSMSPro)
