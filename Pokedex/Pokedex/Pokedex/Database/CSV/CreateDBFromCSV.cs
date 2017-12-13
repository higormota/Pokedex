using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Pokedex.Database.CSV
{
    public class CreateDBFromCSV
    {
        public static void CreateDB()
        {
            foreach (String line in CreateDBFromCSV.getText("Pokedex.Database.CSV.pokemon.csv"))
            {
                string temp = line.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                Pokemon pokemon = Pokemon.FromCsv(temp);
                int i = 0;
            }

            int j = 0;
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
