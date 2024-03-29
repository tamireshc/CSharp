using LifeBankAuth.Models;
using LifeBankAuth.Services;

namespace LifeBankAuth.Test;

public class TestTokenGenerator
{
  /// <summary>
  /// Test function that validates if Token is being generated, if it is not returning null or empty
  /// </summary>
  [Theory(DisplayName = "Teste para TokenGenerator em que token não é nulo")]
  [InlineData("Mayara", false, CurrencyEnum.Real)]
  public void TestTokenGeneratorSuccess(string name, bool isCompany, CurrencyEnum currency)
  {
    var client = new Client { Name = name, IsCompany = isCompany, Currency = currency };
    var token = new TokenGenerator().Generate(client);
    token.Should().NotBeNullOrEmpty();
  }

  /// <summary>
  /// Test function that validates if Token is being generated according to JWT methodology, having 3 keys.
  /// </summary>
  [Theory(DisplayName = "Teste para TokenGenerator em que token JWT possui 3 partes")]
  [InlineData("Mayara", false, CurrencyEnum.Real)]
  public void TestTokenGeneratorKeysSuccess(string name, bool isCompany, CurrencyEnum currency)
  {
    var client = new Client { Name = name, IsCompany = isCompany, Currency = currency };
    var token = new TokenGenerator().Generate(client);
    token.Split(".").Length.Should().Be(3);
  }
}
