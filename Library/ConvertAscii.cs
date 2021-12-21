using System.Linq;
namespace Library
{
    public class ConvertAscii
    {
        public string ConvertToAsciFormat(string _message)
        {
            // Türkçe karakterleri asci karşılıklarına çeviren metodumuz.
            char[] turkishCharacterset = { 'ğ', 'Ğ', 'ç', 'Ç', 'ş', 'Ş', 'ü', 'Ü', 'ö', 'Ö', 'ı', 'İ' };
            char[] turkishToAsci = { 'g', 'G', 'c', 'C', 's', 'S', 'u', 'U', 'o', 'O', 'i', 'I' };
            for (int i = 0; i < turkishCharacterset.Count(); i++)
            {
                if (_message.Contains(turkishCharacterset[i]))
                    _message = _message.Replace(turkishCharacterset[i], turkishToAsci[i]);
            }
            return _message;
        }
    }
}
