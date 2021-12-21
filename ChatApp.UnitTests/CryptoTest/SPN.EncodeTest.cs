using FluentAssertions;
using Library;
using Xunit;

namespace ChatApp.UnitTests.CryptoTest
{
    public class SPN_EncodeUnitTest
    {// Test Edilen de�erler
        [Theory]
        [InlineData("Emrehan ","Sifre123")]
        [InlineData("Burak ","12345678")]
        [InlineData("Halil ","Sifre123")]
        // SPN Algoritmas� Encode ederken hata , bo� mesaj , girilen veriyi tekrar geri d�nd�rmemesi gerekir.
        public void WhenGivenValidPassword_EncodeMessageMethod_ShouldBeReturnCryptedMessage(string message,string password)
        {
            SPN spn = new SPN();
            
            FluentActions.Invoking(() => spn.Encode(message,password))
            .Should().NotThrow()
            .Should().NotBeNull()
            .Should().NotBeSameAs(message.ToCharArray());
        }
    }
}