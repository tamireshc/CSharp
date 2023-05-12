using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MyWine.Constants;
using MyWine.Models;
using Microsoft.IdentityModel.Tokens;


namespace MyWine.Services
{
  public class TokenGenerator
  {
    public string Generate(User user)
    {
      var tokenHandler = new JwtSecurityTokenHandler();

      var tokenDescriptor = new SecurityTokenDescriptor()
      {
        Subject = AddClaims(user),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)), SecurityAlgorithms.HmacSha256Signature),
        Expires = DateTime.Now.AddDays(3)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }

    /// <summary>
    /// Function that adds the claims to the token
    /// </summary>
    /// <param name="user"> A user object value</param>
    /// <returns>Returns an object of type ClaimsIdentity</returns>
    private ClaimsIdentity AddClaims(User user)
    {
      var claims = new ClaimsIdentity();
      claims.AddClaim(new Claim(ClaimTypes.StateOrProvince, user.State));
      claims.AddClaim(new Claim(ClaimTypes.UserData, user.Lover));

      return claims;
    }
  }
}
