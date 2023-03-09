using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestThirdReq
{
    [Theory(DisplayName = "Deve devolver o saldo em uma conta logada")]
    [InlineData(50)]
    public void TestCheckBalanceSucess(int balance)
    {
        var trybankInstance = new Trybank();
        trybankInstance.RegisterAccount(10, 30, 440);
        trybankInstance.Login(10, 30, 440);
        trybankInstance.Deposit(balance);
        trybankInstance.CheckBalance().Should().Be(balance);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestCheckBalanceWithoutLogin(int balance)
    {
        var trybankInstance = new Trybank();
        Action act = () => trybankInstance.CheckBalance();
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário já está logado");
    }

    [Theory(DisplayName = "Deve depositar um saldo em uma conta logada")]
    [InlineData(100)]
    public void TestDepositSucess(int value)
    {
        var trybankInstance = new Trybank();
        trybankInstance.RegisterAccount(10, 30, 440);
        trybankInstance.Login(10, 30, 440);
        trybankInstance.Deposit(value);
        trybankInstance.CheckBalance().Should().Be(value);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestDepositWithoutLogin(int value)
    {
        var trybankInstance = new Trybank();
        Action act = () => trybankInstance.Deposit(value);
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário já está logado");
    }

    [Theory(DisplayName = "Deve sacar um valor em uma conta logada")]
    [InlineData(80, 20)]
    public void TestWithdrawSucess(int balance, int value)
    {
        var trybankInstance = new Trybank();
        trybankInstance.RegisterAccount(10, 30, 440);
        trybankInstance.Login(10, 30, 440);
        trybankInstance.Deposit(balance);
        trybankInstance.Withdraw(value);
        trybankInstance.CheckBalance().Should().Be(balance - value);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(10)]
    public void TestWithdrawWithoutLogin(int value)
    {
        var trybankInstance = new Trybank();
        Action act = () => trybankInstance.Withdraw(value);
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário já está logado");
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0, 100)]
    public void TestWithdrawWithoutBalance(int balance, int value)
    {
        var trybankInstance = new Trybank();
        trybankInstance.RegisterAccount(10, 30, 440);
        trybankInstance.Login(10, 30, 440);
        trybankInstance.Deposit(balance);
        Action act = () => trybankInstance.Withdraw(value);
        act.Should().Throw<InvalidOperationException>().WithMessage("Saldo insuficiente");
    }
}