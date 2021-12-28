using System;
using FluentAssertions;
using Library;
using Xunit;

namespace ChatApp.UnitTests.Ipv4ValidatorTest
{
    public class Ipv4ValidatorTest
    {
        // Test Edilen de�erler
        [Theory]
        [InlineData("192.168.1.1")]
        [InlineData("0.0.0.0")]
        [InlineData("255.255.255.255")]
        // Ge�erli IP adresi girildi�inde hata geri d�nmemeli
        public void WhenGivenValidIp_IpValidator_ReturnNotBeShouldThrow(string _Ipv4)
        {
            Ipv4Validator validator = new Ipv4Validator();
            FluentActions.Invoking(()=>validator.ValidateIPv4(_Ipv4))
            .Should().NotThrow();
        }
        // Test Edilen de�erler
        [Theory]
        [InlineData("192.168.1.256")]
        [InlineData(" ")]
        [InlineData("-1.0.0.0")]
        [InlineData("192.168.1")]
        // Ge�ersiz Ip adrsi girildi�inde InvalidOperationException tipinde hata geri f�rlatmas� gerekir.
        public void WhenGivenInvalidIp_IpValidator_ReturnNotBeShouldThrow(string _Ipv4)
        {
            Ipv4Validator validator = new Ipv4Validator();
            FluentActions.Invoking(()=>validator.ValidateIPv4(_Ipv4))
            .Should().Throw<InvalidOperationException>();
        }
    }
}
