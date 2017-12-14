using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using Pokedex.Database.Models;
using System;

namespace Pokedex.Database.CSV
{
    public class CreateDBFromCSV
    {
        public static void CreateDB()
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            List<Habitat> habitats = new List<Habitat>();
            List<Models.Type> types = new List<Models.Type>();
            List<PokemonType> pokemonTypes = new List<PokemonType>();

            foreach (String line in CreateDBFromCSV.getText("Pokedex.Database.CSV.pokemons.csv"))
            {
                string temp = line.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                pokemons.Add(Pokemon.FromCsv(temp));
            }

            foreach (String line in CreateDBFromCSV.getText("Pokedex.Database.CSV.habitats.csv"))
            {
                string temp = line.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                habitats.Add(Habitat.FromCsv(temp));
            }

            foreach (String line in CreateDBFromCSV.getText("Pokedex.Database.CSV.types.csv"))
            {
                string temp = line.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                types.Add(Models.Type.FromCsv(temp));
            }

            foreach (String line in CreateDBFromCSV.getText("Pokedex.Database.CSV.pokemon_types.csv"))
            {
                string temp = line.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                pokemonTypes.Add(PokemonType.FromCsv(temp));
            }

            App.DAUtil.InsertPokemons(pokemons);
            App.DAUtil.InsertHabitats(habitats);
            App.DAUtil.InsertTypes(types);
            App.DAUtil.InsertPokemonTypes(pokemonTypes);
        }

        public static string[] getText(string file)
        {
            var assembly = typeof(CreateDBFromCSV).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(file);
            string[] text;
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd().Split('\n');
            }

            text = text.Skip(1).ToArray();

            return text;
        }
    }
}
