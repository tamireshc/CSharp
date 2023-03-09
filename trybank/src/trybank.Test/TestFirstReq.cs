using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestFirstReq
{
    [Theory(DisplayName = "Deve cadastrar contas com sucesso!")]
    [InlineData(10, 30, 440)]
    public void TestRegisterAccountSucess(int number, int agency, int pass)
    {
        var trybankInstance = new Trybank();
        trybankInstance.RegisterAccount(number, agency, pass);
        trybankInstance.registeredAccounts.Should().Be(1);
    }

    [Theory(DisplayName = "Deve retornar ArgumentException ao cadastrar contas que já existem")]
    [InlineData(10, 30, 440)]
    public void TestRegisterAccountException(int number, int agency, int pass)
    {
        var trybankInstance = new Trybank();
        trybankInstance.RegisterAccount(number, agency, pass);
        Action act = () => trybankInstance.RegisterAccount(number, agency, pass);
        act.Should().Throw<ArgumentException>().WithMessage("A conta já está sendo usada!");
    }
}