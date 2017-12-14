using Pokedex.Database;
using Pokedex.Database.CSV;
using Pokedex.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Pokedex
{
    public partial class PokedexPage : ContentPage
    {
        Pokemon currentPokemon;
 
        public PokedexPage()
        {
            InitializeComponent();

            if (App.DAUtil.GetAllPokemons().Count == 0)
            {
                CreateDBFromCSV.CreateDB();
            }

            currentPokemon = App.DAUtil.GetPokemonById(1);
            showPokemon();
        }

        private void showPokemon()
        {
            showPokemonImage();
            showPokemonTypes();
            showPokemonDescription();
            showPokemonOwned();
        }

        private void showPokemonImage()
        {
            imagePokemon.Source = ImageSource.FromResource("Pokedex.Resources.pokemon.pokemon(" + currentPokemon.Id.ToString() + ").ico");
        }

        private void showPokemonTypes()
        {
            stackTypes.Children.Clear();
            List<Database.Models.Type> typeList = App.DAUtil.GetPokemonTypes(currentPokemon.Id);
            foreach(Database.Models.Type type in typeList)
            {
                Image pokemonTypeImage = new Image();
                pokemonTypeImage.Source = ImageSource.FromResource("Pokedex.Resources.types." + type.Name + ".png");
                pokemonTypeImage.Margin = 0;
                stackTypes.Children.Add(pokemonTypeImage);
            }
        }

        private void showPokemonDescription()
        {
            string pokemonNumber = currentPokemon.Id.ToString();
            while(pokemonNumber.Length < 3)
            {
                pokemonNumber = "0" + pokemonNumber;
            }

            labelDescription.Text = "#" + pokemonNumber + " - ";
            labelDescription.Text += currentPokemon.Description;
            labelDescription.Text += "\nHeight: " + currentPokemon.Height;
            labelDescription.Text += "\nWeight: " + currentPokemon.Weight;
            labelDescription.Text += "\nHabitat: " + App.DAUtil.GetHabitatById(currentPokemon.HabitatId).Name;
        }

        private void showPokemonOwned()
        {
            if(currentPokemon.Owned == 1)
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

        void OnChangePokemon(object sender, EventArgs args)
        {
          
            var imageSender = (Image)sender;

            if (imageSender == next)
            {
                if (currentPokemon.Id == 151)
                {
                    currentPokemon = App.DAUtil.GetPokemonById(1);
                }
                else
                {
                    currentPokemon = App.DAUtil.GetPokemonById(currentPokemon.Id + 1);
                }
                showPokemon();
            }
            else
            {
                if (currentPokemon.Id == 1)
                {
                    currentPokemon = App.DAUtil.GetPokemonById(151);
                }
                else
                {
                    currentPokemon = App.DAUtil.GetPokemonById(currentPokemon.Id - 1);
                }
 
                showPokemon();
            }

        }

        void OnOwnedPokemon(object sender, EventArgs args)
        {
            if (currentPokemon.Owned == 1)
            {
                currentPokemon.Owned = 0;
            } else
            {
                currentPokemon.Owned = 1;
            }

            App.DAUtil.UpdatePokemon(currentPokemon);

            showPokemonOwned();
        }
    }
}
