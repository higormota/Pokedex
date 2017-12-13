using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pokedex.Database
{
    public class DataAccess
    {
        SQLiteConnection dbConn;
        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            // create the table(s)
            dbConn.CreateTable<Pokemon>();
            dbConn.CreateTable<Habitat>();
            dbConn.CreateTable<Type>();
            dbConn.CreateTable<PokemonType>();
        }
        public List<Pokemon> GetAllPokemons()
        {
            return dbConn.Query<Pokemon>("Select * From [Pokemon]");
        }
        public List<Habitat> GetAllHabitats()
        {
            return dbConn.Query<Habitat>("Select * From [Habitat]");
        }
        public List<Type> GetAllTypes()
        {
            return dbConn.Query<Type>("Select * From [Type]");
        }
        public List<PokemonType> GetAllPokemonTypes()
        {
            return dbConn.Query<PokemonType>("Select * From [PokemonType]");
        }
        public int SavePokemons(List<Pokemon> pokemons)
        {
            return dbConn.InsertAll(pokemons);
        }
        public int SaveHabitats(List<Habitat> habitats)
        {
            return dbConn.InsertAll(habitats);
        }
        public int SaveTypes(List<Type> types)
        {
            return dbConn.InsertAll(types);
        }
        public int SavePokemonTypes(List<PokemonType> pokemonTypes)
        {
            return dbConn.InsertAll(pokemonTypes);
        }
    }
}
