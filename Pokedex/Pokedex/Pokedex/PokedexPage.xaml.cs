using Pokedex.Database;
using Pokedex.Database.CSV;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Pokedex
{
    public partial class PokedexPage : ContentPage
    {
 
        public PokedexPage()
        {
            InitializeComponent();
            insertPokemon();

            //CreateDBFromCSV.CreateDB();
            List<Pokemon> pokemons = App.DAUtil.GetAllPokemons();
            List<Habitat> habitats = App.DAUtil.GetAllHabitats();
            List<Database.Type> types = App.DAUtil.GetAllTypes();
            List<PokemonType> pokemonTypes = App.DAUtil.GetAllPokemonTypes();
            int i = 0;
        }

        private void insertPokemon()
        {
            insertPokemonImage();
            insertPokemonType();
            insertPokemonDescription();
            insertPokemonOwned();
        }

        private void insertPokemonImage()
        {
            
            Image pokemonIcon = new Image();
            pokemonIcon.HeightRequest = 200;
            pokemonIcon.WidthRequest = 200;
            pokemonIcon.Aspect = Aspect.AspectFill;
            pokemonIcon.Source = ImageSource.FromResource("Pokedex.Resources.pokemon.pokemon(1).ico");
            pokemonIcon.VerticalOptions = LayoutOptions.CenterAndExpand;
            pokemonIcon.HorizontalOptions = LayoutOptions.CenterAndExpand;
            gridMain.Children.Add(pokemonIcon,0,1);
        }

        private void insertPokemonType()
        {
            String[] types = {"poison", "grass"};
            foreach(String type in types)
            {
                Image pokemonType = new Image();
                pokemonType.Source = ImageSource.FromResource("Pokedex.Resources.types." + type + ".png");
                pokemonType.Margin = 0;
                stackTypes.Children.Add(pokemonType);
            }
        }

        private void insertPokemonDescription()
        {
            labelDescription.Text = "A strange seed was planted on its back at birth.The plant sprouts and grows with this POKEMON.A strange seed was planted on its back at birth.The plant sprouts and grows with this POKEMON.";
        }

        private void insertPokemonOwned()
        {
            if(true)
            {
                imageOwned.Source = ImageSource.FromResource("Pokedex.Resources.layout.img_pokedex_bottom_cell1ON.png");
            } else
            {
                imageOwned.Source = ImageSource.FromResource("Pokedex.Resources.layout.img_pokedex_bottom_cell1OFF.png");
            }
        }

        async void OnTapGestureRecognizerTapped(object sender, EventArgs args) {
            var userPage = new UserPage();
            await Navigation.PushModalAsync(userPage);

        }

        void OnChangePokemon(object sender, EventArgs args) {
            var imageSender = (Image)sender;

            if (imageSender == next)
            {
                insertPokemon();
            }
            else
            {
                insertPokemon();
            }

        }






    }
}
