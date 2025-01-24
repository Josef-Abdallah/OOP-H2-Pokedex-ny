using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OOP_H2_Pokedex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("velkommen til pokedex");
            Console.WriteLine("a: log in, b: fortsæt uden login");

            var Valg = Console.ReadLine();

            LogInMetode metoder = new LogInMetode();
            Menu menu = new Menu();

            switch (Valg)
            {
                case "a":

                    metoder.login();
                    Console.ReadKey();
                    break;
                case "b":
                    Console.WriteLine("Du er nu logget ind som gæst");
                    menu.notLogedInMenu();
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Ugyldigt valg");
                    break;
            }

        }
    }
}
