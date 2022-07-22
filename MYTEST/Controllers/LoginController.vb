Imports System.Web.Mvc

Namespace Controllers
    Public Class LoginController
        Inherits Controller
        Private db As New VBDatabaseEntities

        ' GET: Login
        Function Index() As ActionResult


            Return View()
        End Function
        ' POST: Login/Login
        <HttpPost>
        <ValidateAntiForgeryToken()>
        Function Index(tbl_users As tbl_User)
            If ModelState.IsValid Then

                Dim obj As tbl_User = db.tbl_User.Where(Function(x) x.UserName.Equals(tbl_users.UserName) And x.Password.Equals(tbl_users.Password)).FirstOrDefault

                If obj IsNot Nothing Then
                    Session("UserName") = obj.UserName.ToString
                    Return RedirectToAction("UserDashBoard")
                End If

            End If
            Return View(tbl_users)

        End Function

        Function UserDashBoard()
            If Session("UserName") IsNot Nothing Then
                Return View()
            End If
            Return RedirectToAction("Index")


        End Function
    End Class
End Namespace

'Dim _new = orders.Select(Function(x) x.Items > 0)

'Dim action As Action(Of Item) = Sub(x) Console.WriteLine(x.Items)



'Dim londonCusts = From cust In db.Customers
'                  Where cust.City = "London"
'                  Select cust

'' This query is compiled to the following code:
'Dim londonCusts = db.Customers.
'                  Where(Function(cust) cust.City = "London").
'                  Select(Function(cust) cust)

'Using (DB_Entities db = New DB_Entities())
'                {
'                    var obj = db.UserProfiles.Where(a >= a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
'                    If (obj!= null)
'                    {
'                        Session["UserID"] = obj.UserId.ToString();
'                        Session["UserName"] = obj.UserName.ToString();
'                        Return RedirectToAction("UserDashBoard");
'                    }
'                }

'BitmapImage bitmap = New BitmapImage();

'Byte[] buffer = GetHugeByteArray(); // from some external source
'Using (MemoryStream stream = New MemoryStream(buffer, false))
'{
'    bitmap.BeginInit();
'    bitmap.CacheOption = BitmapCacheOption.OnLoad;
'    bitmap.StreamSource = stream;
'    bitmap.EndInit();
'    bitmap.Freeze();
'}

'Dim bitmap As New BitmapImage()
'Dim buffer As Byte() = GetHugeByteArrayFromExternalSource()
'Using stream As New MemoryStream(buffer, False)
'bitmap.BeginInit()
'bitmap.CacheOption = BitmapCacheOption.OnLoad
'bitmap.StreamSource = stream
'bitmap.EndInit()
'bitmap.Freeze()
'End Using

