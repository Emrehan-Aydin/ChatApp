using System;
using FluentAssertions;
using Library;
using Xunit;

namespace ChatApp.UnitTests.CryptoTest
{
    public class SPN_EncodeUnitThrowTest
    {// Test Edilen değerler
        [Theory]
        [InlineData("Emrehan ","sifre")]
        [InlineData("Burak ","123")]
        [InlineData("Halil ","deneme")]
        // SPN algoritmasına istenilen formatta şifre verilmediği zaman 8 Karakterli Bir şifre girin hatası fırlatıyor mu ?
        public void WhenGivenInValidPassword_EncodeMessageMethod_ShouldBeThrowException(string message,string password)
        {
            SPN spn = new SPN();
            
            FluentActions.Invoking(() => spn.Encode(message,password))
            .Should().Throw<InvalidOperationException>().WithMessage("8 Karakterli Bir şifre girin");
        }
        // Test Edilen değerler
        [Theory]
        [InlineData("Emrehan","sifre123")]
        [InlineData("Burak","123sifre")]
        [InlineData("Halil","deneme12")]
        // SPN algoritmasına istenilen formatta data verilmediği zaman Bu şifreleme verilen datayı desteklemiyor. hatası fırlatıyor mu ?
        public void WhenGivenInValidData_EncodeMessageMethod_ShouldBeThrowException(string message,string password)
        {
            SPN spn = new SPN();
            
            FluentActions.Invoking(() => spn.Encode(message,password))
            .Should().Throw<InvalidOperationException>().WithMessage("Bu şifreleme verilen datayı desteklemiyor.");
        }
    }
}