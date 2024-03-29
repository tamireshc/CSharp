using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MyWine.Constants;

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

// Adicionar POLICY CLAIMS BASED aqui!

builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("CustomOffer", policy =>
    policy.RequireClaim(ClaimTypes.StateOrProvince, new List<string>() { "Bahia", "Ceará", "Minas Gerais", "Roraima" }));
  options.AddPolicy("CustomerType", policy => policy.RequireClaim(ClaimTypes.UserData, new List<string>() { "Lover", "Specialist" }))
;
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