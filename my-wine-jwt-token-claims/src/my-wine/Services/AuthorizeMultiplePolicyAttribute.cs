namespace MyWine.Services;
public class AuthorizeMultiplePolicyAttribute : Microsoft.AspNetCore.Mvc.TypeFilterAttribute
{
  public AuthorizeMultiplePolicyAttribute(string policies, bool IsAll) : base(typeof(AuthorizeMultiplePolicyFilter))
  {
    Arguments = new object[] { policies, IsAll };
  }
}