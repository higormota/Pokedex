using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Database.Models
{
    public class Pokemon
    {
        [PrimaryKey, AutoIncrement]
        public long Id
        { get; set; }
        [NotNull]
        public string Name
        { get; set; }
        public int Height
        { get; set; }
        public int Weight
        { get; set; }
        public int EvolvesFromSpeciesId
        { get; set; }
        public int EvolutionChanId
        { get; set; }
        public int HabitatId
        { get; set; }
        public int HasGenderDifferences
        { get; set; }
        public string Description
        { get; set; }
        public Pokemon() { }
        public Pokemon(long id, string name, int height, int weight, int evolvesFromSpeciesId, int evolutionChanId, int habitatId, int hasGenderDifferences, string description)
        {
            Id = id;
            Name = name;
            Height = height;
            Weight = weight;
            EvolvesFromSpeciesId = evolvesFromSpeciesId;
            EvolutionChanId = evolutionChanId;
            HabitatId = habitatId;
            HasGenderDifferences = hasGenderDifferences;
            Description = description;
        }
        public static Pokemon FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            return new Pokemon(long.Parse(values[0]), values[1], int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]), values[8]);
        }
    }
}
