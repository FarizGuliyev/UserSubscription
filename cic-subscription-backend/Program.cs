using cic_subscriptions_backend.Context;
using Microsoft.EntityFrameworkCore;
using cic_subscriptions_backend.Services.UserServices;
using cic_subscription_backend.Services.PaymentServices;
using cic_subscription_backend.Services.PhoneNumberServices;
using cic_subscription_backend.Services.SubscriptionTypeServices;

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
