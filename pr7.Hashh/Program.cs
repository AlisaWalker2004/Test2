using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Policy;

namespace pr7.Hashh
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку:");
            string sSourceData1 = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            string sSourceData2 = Console.ReadLine();

            byte[] tmpSource1 = ASCIIEncoding.ASCII.GetBytes(sSourceData1);
            byte[] tmpHash1;
            tmpHash1 = new MD5CryptoServiceProvider().ComputeHash(tmpSource1);

            using (var md5Hash = MD5.Create())
            {
                var sourceBytes = Encoding.UTF8.GetBytes(sSourceData1);
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                var hash1 = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                Console.WriteLine("Первое предложение: " + hash1);

                var sourceByte2 = Encoding.UTF8.GetBytes(sSourceData2);
                var hashBytes2 = md5Hash.ComputeHash(sourceByte2);
                var hash2 = BitConverter.ToString(hashBytes2).Replace("-", string.Empty);
                Console.WriteLine("Второе предложение: " + hash2);

                if (hash1 == hash2)
                    Console.WriteLine("Хэши равны");
                else
                    Console.WriteLine("Хэши не равны");
            }

            Console.ReadLine();
        }
    }
}
