using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await context.Users.ToListAsync();
    }
    
    [HttpGet("{id:int}")] // api/Users/id
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
       var user =  await context.Users.FindAsync(id);
         return user == null ? NotFound() : user;
       
       
    }
}