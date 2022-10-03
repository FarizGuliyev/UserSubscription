using cic_subscriptions_backend.Context;
using Microsoft.EntityFrameworkCore;
using cic_subscriptions_backend.Services.UserServices;
using cic_subscription_backend.Services.PaymentServices;
using cic_subscription_backend.Services.PhoneNumberServices;
using cic_subscription_backend.Services.SubscriptionTypeServices;
using cic_subscription_backend.Services.AddressServices.ApartmentServices;
using cic_subscription_backend.Services.AddressServices.CityServices;
using cic_subscription_backend.Services.AddressServices.FlatServices;
using cic_subscription_backend.Services.AddressServices.FloorServices;
using cic_subscription_backend.Services.AddressServices.HouseAddressServices;
using cic_subscription_backend.Services.AddressServices.RegionServices;
using cic_subscription_backend.Services.AddressServices.StreetServices;
using cic_subscription_backend.Services.AddressServices.VillageServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var MyAllowOrigin = "myPolicy";
builder.Services.AddCors(options =>
{

    options.AddPolicy(name: MyAllowOrigin, policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });

});

var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<DatabaseContext>(option => option.UseNpgsql(connectionString));


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPhoneNumberService, PhoneNumberService>();
builder.Services.AddScoped<ISubscriptionTypeService, SubscriptionTypeService>();
builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IFlatService, FlatService>();
builder.Services.AddScoped<IFloorService, FloorService>();
builder.Services.AddScoped<IHouseAddressService, HouseAddressService>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IStreetService, StreetService>();
builder.Services.AddScoped<IVillageService, VillageService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowOrigin);
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
