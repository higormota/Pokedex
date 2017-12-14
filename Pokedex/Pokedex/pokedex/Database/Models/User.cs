using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Database.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public long Id
        { get; set; }
        [NotNull]
        public string Name
        { get; set; }
        public string Gender
        { get; set; }


        public User() { }
        public User(long id,string name, string gender) {
            Id = id;
            Name = name;
            Gender = gender;
        }




    }
}
