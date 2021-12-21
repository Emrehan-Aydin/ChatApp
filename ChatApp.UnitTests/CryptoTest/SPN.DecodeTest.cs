using FluentAssertions;
using Library;
using Xunit;

namespace ChatApp.UnitTests.CryptoTest
{
    public class SPN_DecodeUnitTest
    {// Test Edilen deðerler
        [Theory]
        [InlineData("Emrehan ","Sifre123")]
        [InlineData("Karisik birkac cumle yazalim ?","12345678")]
        [InlineData("Sayilari test edelim 1 12 123 1234","Sifre123")]
        [InlineData("Sembolleri . , ? - _ / * - +","Sifre123")]
        // Girilen mesaj þifrelenip geri çözüldüðünde veri kaybý yaþýyor mu ?
        public void WhenGivenValidParameters_DecodeMessageMethod_ShouldBeReturnSameAsMessagesParameters(string message,string password)
        {
            BinaryToText Get = new BinaryToText();
            SPN spn = new SPN();
            string _message = Get.GetBytesFromBinaryString(spn.Decode(spn.Encode(message,password),password));
            _message.Should().Be(message);
        }
    }
}