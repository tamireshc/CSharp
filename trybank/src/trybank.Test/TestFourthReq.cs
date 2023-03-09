using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestFourthReq
{
    [Theory(DisplayName = "Deve transefir um valor com uma conta logada")]
    [InlineData(80, 10)]
    public void TestTransferSucess(int balance, int value)
    {
        var trybankInstance = new Trybank();
        trybankInstance.RegisterAccount(10, 30, 440);
        trybankInstance.RegisterAccount(20, 60, 880);
        trybankInstance.Login(10, 30, 440);
        trybankInstance.Deposit(balance);
        trybankInstance.Transfer(20, 60, value);
        trybankInstance.CheckBalance().Should().Be(balance - value);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestTransferWithoutLogin(int value)
    {
        var trybankInstance = new Trybank();
        Action act = () => trybankInstance.Transfer(20, 60, value);
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário já está logado");
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(10, 20)]
    public void TestTransferWithoutBalance(int balance, int value)
    {
        var trybankInstance = new Trybank();
        trybankInstance.RegisterAccount(10, 30, 440);
        trybankInstance.RegisterAccount(20, 60, 880);
        trybankInstance.Login(10, 30, 440);
        trybankInstance.Deposit(balance);
        Action act = () => trybankInstance.Transfer(20, 60, value);
        act.Should().Throw<InvalidOperationException>().WithMessage("Saldo insuficiente");
    }
}
