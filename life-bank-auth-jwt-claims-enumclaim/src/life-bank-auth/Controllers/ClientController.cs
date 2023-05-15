using LifeBankAuth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeBankAuth.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
  /// <summary>
  /// Message function that does needs authorization
  /// </summary>
  /// <returns>Returns a message</returns>
  [HttpGet]
  [Route("PlataformWelcome")]
  [Authorize]
  public ActionResult<string> PlataformWelcome()
  {
    return Ok("Que ótimo ter você aqui novamente, sinta-se a vontade!");
  }

  /// <summary>
  /// Message function that needs authorization claims based
  /// </summary>
  /// <returns>Returns a message</returns>
  [HttpGet]
  [Route("NewPromoAlert")]
  [AuthorizeMultiplePolicy("CustomerRole;CustomerCurrency", true)]
  public ActionResult<string> NewPromoAlert()
  {
    return Ok("Aproveite a nova promoção da Life Bank agora mesmo!");
  }
}
