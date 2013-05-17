

<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        ViewData("Message") = "Integer tincidunt Cras dapibus!"
        Return View()
    End Function

    Function About() As ActionResult
        Return View()
    End Function
End Class
