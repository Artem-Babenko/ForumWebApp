using AutoMapper;
using ForumWebApp.Data.Entities;
using ForumWebApp.Data.Repositories;
using ForumWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApp.Controllers;

[Route("api")]
public class UserController : Controller
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    [HttpGet]
    [Route("users")]
    public IActionResult GetUsers()
    {
        var userEntities = userRepository.GetAll();
        var userModels = mapper.Map<List<UserFullModel>>(userEntities);
        return Json(userModels);
    }

    [HttpGet]
    [Route("users/{id:int}")]
    public IActionResult GetUser(int id)
    {
        var userEntity = userRepository.Get(id);
        var userModel = mapper.Map<UserFullModel>(userEntity);
        return Json(userModel);
    }

    [HttpPost]
    [Route("users")]
    public async Task<IActionResult> AddUser()
    {
        var userModel = await Request.ReadFromJsonAsync<UserFullModel>();
        if (userModel == null) return BadRequest("Invalid data");

        var userEntity = mapper.Map<UserEntity>(userModel);
        userRepository.Add(userEntity);

        userModel = mapper.Map<UserFullModel>(userEntity);
        
        return Json(userModel);
    }

    [HttpPut]
    [Route("users")]
    public async Task<IActionResult> UpdateUser()
    {
        var userModel = await Request.ReadFromJsonAsync<UserFullModel>();
        if (userModel == null) return BadRequest("Invalid data");

        var userEntity = mapper.Map<UserEntity>(userModel);

        var isUpdated = userRepository.Update(userEntity);
        if (isUpdated)
            return Ok();
        else
            return NotFound();
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
