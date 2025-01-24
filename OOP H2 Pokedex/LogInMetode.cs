using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OOP_H2_Pokedex
{
    internal class LogInMetode
    {
        private string brugernavn;
        private string password;

        public void login()
        {
            string LoginFile = @"C:\Users\josef\source\repos\OOP H2 Pokedex\OOP H2 Pokedex\Pokedexlogins.txt";

            Console.WriteLine("Indtast brugernavn");
            brugernavn = Console.ReadLine();
            Console.WriteLine("Indtast password");
            password = Console.ReadLine();

            string hashedPassword = ComputeSha256Hash(password);

            using (StreamReader reader = new StreamReader(LoginFile))
            {
                string line;
                bool login = false;
                while ((line = reader.ReadLine()) != null && !login)
                {
                    string[] credentials = line.Split(',');
                    if (credentials.Length == 2 && credentials[0] == brugernavn && credentials[1] == hashedPassword)
                    {
                        Console.WriteLine("Du er nu logget ind");
                        login = true;

                        Menu menu = new Menu();
                        menu.logedInMenu();
                    }
                }
                if (!login)
                {
                    Console.WriteLine("Forkert brugernavn eller password");
                }
            }
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
