using FluentAssertions;
using Library;
using Xunit;

namespace ChatApp.UnitTests.ConverterTest.Ascii
{
    public class ConvertCharacterTest
    {
        // Test Edilen değerler
        [Theory]
        [InlineData("Ğ")]
        [InlineData("ğ")]
        [InlineData("İ")]
        [InlineData("ı")]
        [InlineData("Ü")]
        [InlineData("ü")]
        [InlineData("Ö")]
        [InlineData("ö")]
        [InlineData("Ç")]
        [InlineData("ç")]
        [InlineData("ş")]
        [InlineData("Ş")]
        // Türkçe karakter verildiğinde geri türkçe karakter dönmemesi gerekir.
        public void WhenGivenTurkishCharacter_ConverterAsciiMethod_ShouldNotReturnTurkishCharacter(string turkishCharacter)
        {
            ConvertAscii command = new ConvertAscii();
            FluentActions
            .Invoking(()=>command.ConvertToAsciFormat(turkishCharacter))
            // assert {Doğrulama}
            .Should().NotThrow() // Hata fırlatmamalı
            .Should().NotBeNull() // Boş Geçmemeli
            .Should().NotBeSameAs(turkishCharacter); // Geldiği veriyi geri dönmemeli
            
        }
        // Türkçe kelime verildiğinde türkçe ifade içermemeli
        [Theory]
        // Test Edilen değerler
        [InlineData("ĞğÜüİıŞşÇçÖö")]
        public void WhenGivenTurkishString_ConverterAsciiMethod_ShouldNotReturnTurkishString(string turkishCharacter)
        {
            ConvertAscii command = new ConvertAscii();
            FluentActions
            .Invoking(()=>command.ConvertToAsciFormat(turkishCharacter))
            // assert {Doğrulama}
            .Should().NotThrow() // Hata fırlatmamalı
            .Should().NotBeNull() // Boş Geçmemeli
            .Should().Equals("GgUuIiSsCcOo"); // 
            
        }
    }
}

