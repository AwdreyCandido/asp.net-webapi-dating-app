using System.Text;
using API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Extension method to encapsulate the app core services
builder.Services.AddApplicationServices(builder.Configuration);
// Extension method to encapsulate the identity servvices services
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseAuthentication(); // Asks if you have a valid token

app.UseAuthorization(); // Yeah, you have a valid token, now you're allowed to do...

app.MapControllers();

app.Run();
