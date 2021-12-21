using System;
using FluentAssertions;
using Library;
using Xunit;

namespace ChatApp.UnitTests.Ipv4ValidatorTest
{
    public class Ipv4ValidatorTest
    {
        // Test Edilen deðerler
        [Theory]
        [InlineData("192.168.1.1")]
        [InlineData("0.0.0.0")]
        [InlineData("255.255.255.255")]
        // Geçerli IP adresi girildiðinde hata geri dönmemeli
        public void WhenGivenValidIp_IpValidator_ReturnNotBeShouldThrow(string _Ipv4)
        {
            Ipv4Validator validator = new Ipv4Validator();
            FluentActions.Invoking(()=>validator.ValidateIPv4(_Ipv4))
            .Should().NotThrow();
        }
        // Test Edilen deðerler
        [Theory]
        [InlineData("192.168.1.256")]
        [InlineData(" ")]
        [InlineData("-1.0.0.0")]
        [InlineData("192.168.1")]
        // Geçersiz Ip adrsi girildiðinde InvalidOperationException tipinde hata geri fýrlatmasý gerekir.
        public void WhenGivenInvalidIp_IpValidator_ReturnNotBeShouldThrow(string _Ipv4)
        {
            Ipv4Validator validator = new Ipv4Validator();
            FluentActions.Invoking(()=>validator.ValidateIPv4(_Ipv4))
            .Should().Throw<InvalidOperationException>();
        }
    }
}