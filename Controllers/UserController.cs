using ForumWebApp.Data.Entities;
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

    [HttpPost]
    [Route("users")]
    public async Task<IActionResult> AddUser()
    {
        var user = await Request.ReadFromJsonAsync<UserEntity>();
        if (user == null) return BadRequest("Invalid data");

        user = userRepository.Add(user);
        return Json(user);
    }

    [HttpPut]
    [Route("users")]
    public async Task<IActionResult> UpdateUser()
    {
        var user = await Request.ReadFromJsonAsync<UserEntity>();
        if (user == null) return BadRequest("Invalid data");

        userRepository.Update(user);
        return Ok();
    }

    [HttpDelete]
    [Route("users/{id:int}")]
    public IActionResult DeleteUser(int id)
    {
        var isDeleted = userRepository.Delete(id);
        if (isDeleted)
            return Ok();
        else
            return NotFound();
    }
}
