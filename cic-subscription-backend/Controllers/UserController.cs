
using cic_subscription_backend.DTOs;
using cic_subscriptions_backend.Context;
using cic_subscriptions_backend.Dtos.user;
using cic_subscriptions_backend.Models;
using cic_subscriptions_backend.Services.UserServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[EnableCors("myPolicy")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService service;
    private readonly DatabaseContext context;

    public UserController(DatabaseContext context, IUserService service)
    {
        this.service = service;
        this.context = context;
    }


    [HttpPost]
    public async Task<ActionResult<User>> PostUser(InsertUserDto userDto)
    {
        return Ok(await service.InsertUser(userDto));
    }



    [HttpGet]
    public async Task<List<User>> GetUsers()
    {
        List<User> models = await service.SelectUsers();
        return models;
    }

    [HttpPut("{id}")]
    public async Task<User> PutUser(long id, InsertUserDto userDto)
    {
        User user = await service.UpdateUser(id, userDto);
        return user;
    }

    [HttpDelete("{id}")]
    public async Task<User> DeleteUser(long id)
    {
        User user = await service.RemoveUser(id);
        return user;
    }

}

