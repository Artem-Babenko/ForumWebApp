using ForumWebApp.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApp.Controllers;

[Route("api")]
public class UserController : Controller
{
    private readonly IUserRepository userRepository;

    public UserController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;    
    }

    [HttpGet]
    [Route("users")]
    public IActionResult GetUsers()
    {
        var users = userRepository.GetAll();
        return Json(users);
    }

    [HttpGet]
    [Route("users/{id:int}")]
    public IActionResult GetUser(int id)
    {
        var user = userRepository.Get(id);
        return Json(user);
    }
}
