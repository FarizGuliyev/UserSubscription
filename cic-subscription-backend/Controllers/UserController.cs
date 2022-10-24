using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using cic_subscription_backend.DTOs;
using cic_subscriptions_backend.Context;
using cic_subscriptions_backend.Dtos.user;
using cic_subscriptions_backend.Models;
using cic_subscriptions_backend.Services.UserServices;
using cic_subscription_backend.DTOs.MainDTOs;

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

    [HttpGet("/User/ByRegion/{id}")]
    public async Task<List<SelectUserDto>> GetUsersByRegionId(long id)
    {
        List<SelectUserDto> models = await service.SelectUsersByRegionId(id);;
        return models;
    }

     [HttpGet("/User/ByCity/{id}")]
    public async Task<List<SelectUserDto>> GetUsersByCityId(long id)
    {
        List<SelectUserDto> models = await service.SelectUsersByCityId(id);;
        return models;
    }

     [HttpGet("/User/ByVillage/{id}")]
    public async Task<List<SelectUserDto>> GetUsersByVillageId(long id)
    {
        List<SelectUserDto> models = await service.SelectUsersByVillageId(id);;
        return models;
    }

     [HttpGet("/User/ByStreet/{id}")]
    public async Task<List<SelectUserDto>> GetUsersByStreetId(long id)
    {
        List<SelectUserDto> models = await service.SelectUsersByStreetId(id);;
        return models;
    }

     [HttpGet("/User/ByApartment/{id}")]
    public async Task<List<SelectUserDto>> GetUsersByApartmentId(long id)
    {
        List<SelectUserDto> models = await service.SelectUsersByApartmentId(id);;
        return models;
    }

     [HttpGet("/User/ByFloor/{id}")]
    public async Task<List<SelectUserDto>> GetUsersByFloorId(long id)
    {
        List<SelectUserDto> models = await service.SelectUsersByFloorId(id);;
        return models;
    }

     [HttpGet("/User/ByFlat/{id}")]
    public async Task<List<SelectUserDto>> GetUsersByFlatId(long id)
    {
        List<SelectUserDto> models = await service.SelectUsersByFlatId(id);;
        return models;
    }

    [HttpGet]
    public async Task<List<SelectUserDto>> GetUsers()
    {
        List<SelectUserDto> models = await service.SelectUsers();
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
