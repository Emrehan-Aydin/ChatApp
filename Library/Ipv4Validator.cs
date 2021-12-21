using System;
using System.Linq;

namespace Library
{
    public class Ipv4Validator
    {
        public void ValidateIPv4(string ipString)
        {
            // Ip alaný boþ mu kontrol
            if (string.IsNullOrWhiteSpace(ipString))
            {
                throw new InvalidOperationException("Ip is null");
            }
            // Ip adresi IPV4 standartýnda mý kontrol
            string[] splitValues = ipString.Split('.');
            if(splitValues.Count()!=4)
            {
                throw new InvalidOperationException("Ip is should be Ipv4 format");
            }
            // Ip adresi sýnýrlarý 0-255 arasýnda mý ?
            foreach (string item in splitValues)
            {
                if(Convert.ToInt32(item) < 0 || Convert.ToInt32(item) > 255)
                    throw new InvalidOperationException("Ipv4 adress should be 0-255");
            }
        }
    }
}