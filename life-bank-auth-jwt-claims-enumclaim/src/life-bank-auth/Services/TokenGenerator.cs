using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LifeBankAuth.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using LifeBankAuth.Constants;


namespace LifeBankAuth.Services
{
  public class TokenGenerator
  {
    /// <summary>
    /// This function is to Generate Token 
    /// </summary>
    /// <returns>A string, the token JWT</returns>
    public string Generate(Client client)
    {
      var tokenHandler = new JwtSecurityTokenHandler();

      var tokenDescriptor = new SecurityTokenDescriptor()
      {
        Subject = AddClaims(client),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)), SecurityAlgorithms.HmacSha256Signature),
        Expires = DateTime.Now.AddDays(3)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

    /// <summary>
    /// Function that adds the claims to the token
    /// </summary>
    /// <param name="client"> A client object value</param>
    /// <returns>Returns an object of type ClaimsIdentity</returns>
    private ClaimsIdentity AddClaims(Client client)
    {
      var claims = new ClaimsIdentity();
      claims.AddClaim(new Claim(ClaimTypes.Name, client.Name));
      claims.AddClaim(new Claim(ClaimTypes.Role, client.Currency.ToString()));
      claims.AddClaim(new Claim(ClaimTypes.UserData, client.IsCompany ? "PessoaJuridica" : "PessoaFisica"));

      return claims;
    }
  }
}