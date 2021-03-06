﻿using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Database.Models
{
    public class PokemonType
    {
        [PrimaryKey, AutoIncrement]
        public long Id
        { get; set; }
        [NotNull]
        public long PokemonId
        { get; set; }
        [NotNull]
        public long TypeId
        { get; set; }
        public PokemonType() { }
        public PokemonType(long id, long pokemonId, long typeId)
        {
            Id = id;
            PokemonId = pokemonId;
            TypeId = typeId;
        }
        public static PokemonType FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            return new PokemonType(long.Parse(values[0]), long.Parse(values[1]), long.Parse(values[2]));
        }
    }
}
