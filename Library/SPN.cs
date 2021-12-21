using System;
using System.Linq;
using System.Text;

namespace Library
{
    public class SPN
    {
        // SPN Şifreleme metodu
        public byte[] Encode(string _data, string _sifre)
        {
            // veri ve anahtar SPA algoritması gereği 16 bitlik katlar halinde olması lazım.
            if(_sifre.Length!=8)
                throw new InvalidOperationException("8 Karakterli Bir şifre girin");
            if(_data.Length%2!=0)
                throw new InvalidOperationException("Bu şifreleme verilen datayı desteklemiyor.");   
            // SPN karıştırma dizisi
            int[] compare = { 5, 9, 0, 12, 7, 3, 11, 14, 1, 4, 13, 8, 2, 15, 6, 10 };
            StringBuilder data = new StringBuilder();
            StringBuilder sifre = new StringBuilder();
            //Mesajın binary çevirilmesi
            foreach (char c in _data.ToCharArray())
            {
                data.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            // Şifrenin binary çevrilmesi
            foreach (char c in _sifre.ToCharArray())
            {
                sifre.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            // mesajın binary olarak şifrelenip atılacağı değişken
            byte[] SPNdata = new byte[data.Length];
            // SPN algoritması
            for (int i = 0; i < data.Length / 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                        SPNdata[compare[j] + i * 16] = (byte)(data[j + i * 16] ^ sifre[(j + i * 16) % 64]);
                }
            }
            return SPNdata;
        }
        //SPN Verinin çözülmesi.
        public char[] Decode(char[] _data, string _sifre)
        {
            // Gelen mesajın binary ye çevrilmesi
            StringBuilder sifre = new StringBuilder();
            foreach (char c in _sifre.ToCharArray())
            {
                sifre.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            // SPN karma dizisi
            int[] compare = { 5, 9, 0, 12, 7, 3, 11, 14, 1, 4, 13, 8, 2, 15, 6, 10 };
            // Çözülecek verinin saklanması
            char[] data = new char[_data.Count()];
            // SPN çözücü algoritması
            for (int i = 0; i < _data.Count() / 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    data[j + i * 16] = (char)((int)_data[compare[j] + i * 16] ^ (int)sifre[(i * 16 + j) % 64]);
                }
            }
            return data;
        }

    }
}