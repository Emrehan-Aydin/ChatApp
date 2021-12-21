using System;
using System.Linq;

namespace Library
{
    public class BinaryToText
    {
        // Binary ifadeyi ASCI karþýlýklarýna çevirir ve geri döndürür
        public string GetBytesFromBinaryString(char[] binary)
        {
            string message = "";
            string[] text = new string[binary.Count() / 8];
            for (int i = 0; i < binary.Count() / 8; i++)
            {
                text[i] = "";
                for (int j = 0; j < 8; j++)
                {
                    text[i] += binary[i * 8 + j];
                }
                message += (char)Convert.ToInt32(text[i].Substring(0, 8), 2);
            }
            return message;
        }
    }
}