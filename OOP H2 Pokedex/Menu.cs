using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_H2_Pokedex
{
    internal class Menu
    {
        string PokemonsDokument = @"C:\Users\josef\Documents\PokemonDokument.txt";
        public List<string> Pokemons = new List<string> { "Id:1,Navn:bulbasaur,type:Plant,Styrke:40", "Id:2,Navn:Squirtle,type:Vand,Styrke:100", "Id:3,Navn:Charmander,type:Ild,Styrke:80", "Id:4,Navn:lucasTheMikuLover,type:Ild,Styrke:300" };

        public void logedInMenu()
        {
            while (true)
            {
                Console.WriteLine("a: tilføj pokemon, b: se pokemons, c:søg på pokemons, d: rediger pokemon, e: slet pokemons, f: log ud");
                var Valg = Console.ReadLine();
                LogInMetode menuPunkter = new LogInMetode();
                switch (Valg.ToLower())
                {
                    case "a":
                        tilføjPokemon();
                        break;
                    case "b":
                        sePokemons();
                        break;
                    case "c":
                        søgPokemon();
                        break;
                    case "d":
                        RedigerPokemon();
                        break;
                    case "e":
                        sletPokemon();
                        break;
                    case "f":
                        Console.WriteLine("Du er nu logget ud");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg");
                        break;
                }
            }
        }

        public void notLogedInMenu()
        {
            Console.WriteLine("1:se pokemons 2:søg pokemons");
            var Valg = Console.ReadLine();
            switch (Valg)
            {
                case "1":
                    Console.WriteLine("alle registret pokemons:");
                    sePokemons();
                    break;
                case "2":
                    søgPokemon();
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg");
                    break;
            }
        }

        public void tilføjPokemon()
        {
            Console.WriteLine("Indtast id på pokemon du ville tilføje");
            foreach (var pokemon in Pokemons)
            {
                Console.WriteLine(pokemon);
            }
            string pokemonId = Console.ReadLine();

            var selectedPokemon = Pokemons.FirstOrDefault(p => p.StartsWith("Id:" + pokemonId + ","));
            if (selectedPokemon != null)
            {
                using (StreamWriter writer = new StreamWriter(PokemonsDokument, true))
                {
                    writer.WriteLine(selectedPokemon);
                    writer.Close();
                }
                Console.Clear();
                Console.WriteLine("Pokemon tilføjet.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Pokemon ikke fundet.");
            }
        }

        public void sePokemons()
        {
            var lines = File.ReadAllLines(PokemonsDokument).ToList();
            int pageSize = 10;
            int totalPages = (int)Math.Ceiling((double)lines.Count / pageSize);
            int currentPage = 1;

            while (true)
            {
                Console.Clear();
                var paginatedPokemons = lines.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                foreach (var pokemon in paginatedPokemons)
                {
                    Console.WriteLine(pokemon);
                }

                Console.WriteLine($"\nPage {currentPage} of {totalPages}");
                Console.WriteLine("n: next page, p: previous page, q: quit");

                var input = Console.ReadLine().ToLower();
                if (input == "n" && currentPage < totalPages)
                {
                    currentPage++;
                }
                else if (input == "p" && currentPage > 1)
                {
                    currentPage--;
                }
                else if (input == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg");
                }
            }
        }

        public void søgPokemon()
        {
            Console.WriteLine("Søg efter pokemon via navn eller type:");
            string searchQuery = Console.ReadLine().ToLower();

            var foundPokemons = new List<string>();
            using (StreamReader reader = new StreamReader(PokemonsDokument))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.ToLower().Contains("navn:" + searchQuery) || line.ToLower().Contains("type:" + searchQuery))
                    {
                        foundPokemons.Add(line);
                    }
                }
            }

            if (foundPokemons.Any())
            {
                Console.Clear();
                Console.WriteLine("Fundne pokemons:");
                foreach (var pokemon in foundPokemons)
                {
                    Console.WriteLine(pokemon);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen pokemons fundet.");
            }
        }

        public void RedigerPokemon()
        {
            Console.WriteLine("Indtast id på pokemon du vil redigere:");
            string pokemonId = Console.ReadLine();

            var lines = File.ReadAllLines(PokemonsDokument).ToList();
            var selectedPokemonIndex = lines.FindIndex(p => p.StartsWith("Id:" + pokemonId + ","));

            if (selectedPokemonIndex != -1)
            {
                Console.WriteLine("skriv navn");
                string navn = Console.ReadLine();
                Console.WriteLine("skriv type");
                string type = Console.ReadLine();
                Console.WriteLine("skriv styrke");
                string styrke = Console.ReadLine();

                lines[selectedPokemonIndex] = $"Id:{pokemonId},Navn:{navn},type:{type},Styrke:{styrke}";
                File.WriteAllLines(PokemonsDokument, lines);
                Console.Clear();
                Console.WriteLine("Pokemon redigeret.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Pokemon ikke fundet.");
            }
        }

        public void sletPokemon()
        {
            using (StreamReader reader = new StreamReader(PokemonsDokument))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine("Indtast id på pokemon du ville slette");
            string pokemonId = Console.ReadLine();
            var selectedPokemon = Pokemons.FirstOrDefault(p => p.StartsWith("Id:" + pokemonId + ","));
            if (selectedPokemon != null)
            {
                var lines = File.ReadAllLines(PokemonsDokument).ToList();
                lines.Remove(selectedPokemon);
                File.WriteAllLines(PokemonsDokument, lines);
                Console.Clear();
                Console.WriteLine("Pokemon slettet.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Pokemon ikke fundet.");
            }
        }

        public int currentId()
        {
            var lines = File.ReadAllLines(PokemonsDokument).ToList();
            var highestId = 0;
            foreach (var line in lines)
            {
                var pokemonId = int.Parse(line.Split(',')[0].Split(':')[1]);
                if (pokemonId > highestId)
                {
                    highestId = pokemonId;
                }
            }
            return highestId;
        }
    }
}
