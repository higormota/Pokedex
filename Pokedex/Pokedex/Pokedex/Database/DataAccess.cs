using Pokedex.Database.Models;
using SQLite.Net;
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
            dbConn.CreateTable<User>();
        }

        public void createTableUser()
        {
            dbConn.CreateTable<User>();
        }

        public Pokemon GetPokemonById(long Id)
        {
            return dbConn.Find<Pokemon>(Id.ToString());
        }
        public Habitat GetHabitatById(long Id)
        {
            return dbConn.Find<Habitat>(Id.ToString());
        }
        public Type GetTypeById(long Id)
        {
            return dbConn.Find<Type>(Id.ToString());
        }
        public User GetUserById(long? Id)
        {
            User userDefault = dbConn.Query<User>("Select * From [User]").FirstOrDefault();
            if (Id == 0 && userDefault != null)
            {
                Id = userDefault.Id;
            }
            return dbConn.Find<User>(Id.ToString());
        }
        
        public List<Type> GetPokemonTypes(long pokemonId)
        {
            List<PokemonType> pokemonTypeList = dbConn.Query<PokemonType>("Select * From [PokemonType] Where PokemonId = " + pokemonId.ToString());
            if (pokemonTypeList.Count == 0)
            {
                return new List<Type>();
            }
            string where = "";
            foreach(PokemonType pokemonType in pokemonTypeList)
            {
                where += pokemonType.TypeId + ",";
            }
            if (where.Length > 1)
            {
                where = where.Remove(where.Length - 1);
            }

            return dbConn.Query<Type>("Select * From [Type] Where Id IN (" + where + ")");
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

        public List<Pokemon> GetAllOwnedPokemon()
        {
            return dbConn.Query<Pokemon>("Select * From [Pokemon] Where Owned = 1");
        }

        public int UpdatePokemon(Pokemon pokemon)
        {
            return dbConn.Update(pokemon);
        }
        public int InsertPokemons(List<Pokemon> pokemons)
        {
            return dbConn.InsertAll(pokemons);
        }
        public int InsertHabitats(List<Habitat> habitats)
        {
            return dbConn.InsertAll(habitats);
        }
        public int InsertTypes(List<Type> types)
        {
            return dbConn.InsertAll(types);
        }
        public int InsertPokemonTypes(List<PokemonType> pokemonTypes)
        {
            return dbConn.InsertAll(pokemonTypes);
        }

        public int InsertUser(User user) {
            return dbConn.Insert(user);
        }
    }
}
