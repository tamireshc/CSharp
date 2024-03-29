using System.Security.Claims;
using System.Text;
using LifeBankAuth.Constants;
using LifeBankAuth.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
  options.SaveToken = true;
  options.RequireHttpsMetadata = false;
  options.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret))
  };
});

builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("Name", policy =>
  policy.RequireClaim(ClaimTypes.Name));
  options.AddPolicy("CustomerRole", policy => policy.RequireClaim(ClaimTypes.UserData, "PessoaFisica"));
  options.AddPolicy("CustomerCurrency", policy => policy.RequireClaim(ClaimTypes.Role, new List<string>() { "Real", "Peso" }));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

public partial class Program { }