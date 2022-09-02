
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
    public IActionResult PostUser(InsertUserDto userDto)
    {
        using (context)
        {
            service.InsertUser(userDto);

        }
        return Ok(userDto);
    }


    [HttpGet]
    public List<User> GetModels()
    {
        List<User> models = service.SelectUser();
        return models;
    }

    [HttpPut("{id}")]
    public User PutModel(int id, InsertUserDto userDto)
    {
        User user = service.UpdateUser(id, userDto);
        return user;
    }

    [HttpDelete("{id}")]
    public User DeleteTodoItem(int id)
    {
        User user = service.DeleteUser(id);
        return user;
    }

}

