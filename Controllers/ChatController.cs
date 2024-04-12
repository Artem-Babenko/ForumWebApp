using AutoMapper;
using ForumWebApp.Data.Repositories;
using ForumWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApp.Controllers;

[ApiController]
[Route("chat")]
public class ChatController : Controller
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    
    public ChatController(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    [HttpGet]
    [Route("search")]
    public IActionResult Search(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return BadRequest();
            
        var usersByName = userRepository.GetAllByName(value);
        var userModels = mapper.Map<List<UserSmallModel>>(usersByName);

        return Json(new { users = userModels });
    } 
}
