using Microsoft.AspNetCore.Mvc;
using ProjectLeeApi.Models;

namespace ProjectLeeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    // Lista em memória para exemplo
    private static readonly List<User> Users = new List<User>();

    [HttpGet]
    public IActionResult GetAll() => Ok(Users);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        user.Id = Users.Count + 1;
        Users.Add(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }
}
