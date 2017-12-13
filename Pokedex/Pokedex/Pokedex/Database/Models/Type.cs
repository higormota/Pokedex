using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Database.Models
{
    public class Type
    {
        [PrimaryKey, AutoIncrement]
        public long Id
        { get; set; }
        [NotNull]
        public string Name
        { get; set; }
        public Type(long id, string name)
        {
            Id = id;
            Name = name;
        }
        public static Type FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            return new Type(long.Parse(values[0]), values[1]);
        }
    }
}
