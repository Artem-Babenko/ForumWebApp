using Microsoft.AspNetCore.Mvc;

namespace ForumWebApp.Controllers;

public class PageController : Controller
{
    [HttpGet]
    [Route("/")]
    public IActionResult GetMainPage()
    {
        return File("html/index.html", "text/html; charset=utf-8;");
    }
}
