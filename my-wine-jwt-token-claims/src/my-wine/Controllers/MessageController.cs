
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWine.Services;

namespace MyWine.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class NotificationController : Controller
  {

    /// <summary>
    /// Message function that does not need authorization
    /// </summary>
    /// <returns>Returns a message</returns>
    [HttpGet]
    [Route("NotifyEveryone")]
    [AllowAnonymous]
    public ActionResult<string> MessageForEveryone()
    {
      return Ok("Se você tem mais de 18 anos, vamos assinar o My Wine ? !");
    }

    /// <summary>
    /// Message function that needs authorization
    /// </summary>
    /// <returns>Returns a message</returns>
    [HttpGet]
    [Route("NotifyCustomers")]
    [Authorize]
    public ActionResult<string> MessageForCustomers()
    {

      return Ok("Avalie sua experiência com a My Wine!");


    }

    /// <summary>
    /// Message function that needs authorization claims based
    /// </summary>
    /// <returns>Returns a message</returns>
    [HttpGet]
    [Route("NotifyCustomCustomers")]
    [AuthorizeMultiplePolicy("CustomOffer;CustomerType", true)]
    public ActionResult<string> MessageForCustomOffer()
    {
      return Ok("Aproveite 86% de desconto até sexta-feira em qualquer produto!");
    }
  }
}


