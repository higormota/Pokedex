using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Database
{
    public class Habitat
    {

        [PrimaryKey, AutoIncrement]
        public long Id
        { get; set; }
        [NotNull]
        public string Name
        { get; set; }
        public Habitat(long id, string name)
        {
            Id = id;
            Name = name;
        }
        public static Habitat FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            return new Habitat(long.Parse(values[0]), values[1]);
        }
    }
}
