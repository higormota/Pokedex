using Pokedex.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        User currentUser = new User();
        Entry txtName = new Entry();
        Entry txtGender = new Entry();
        public UserPage()
        {
            InitializeComponent();
            loadUser();
        }

        void loadUser() {
            var usuario = App.DAUtil.GetUserById(currentUser.Id);
            currentUser = usuario != null ? usuario : currentUser ;

           if (currentUser.Name == null)
           {
                txtName.Placeholder = "Enter your name... ";
                txtName.SetValue(Grid.RowProperty, 0);
                txtGender.Placeholder = "Enter your gender...";
                txtGender.SetValue(Grid.RowProperty, 1);

                grdUserData.Children.Add(txtName);
                grdUserData.Children.Add(txtGender);
                dismissButton.Text = "Create";
          }
          else
          {
              lblName.Text = currentUser.Name;
              lblName.IsVisible = true;
              lblGender.Text = currentUser.Gender;
              lblGender.IsVisible = true;
              imgUser.Source = currentUser.Gender == "Male" ? ImageSource.FromResource("Pokedex.Resources.layout.icon_male.png") : ImageSource.FromResource("Pokedex.Resources.layout.icon_female.png");
              lblNumberPokemons.Text = "Catch: "+ App.DAUtil.GetAllOwnedPokemon().Count.ToString();
              lblNumberPokemons.IsVisible = true;
          }            
        } 


        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
           if (lblName.IsVisible)
           {
                await Navigation.PopModalAsync();
            }
            else
            {
                currentUser.Name = txtName.Text;
                currentUser.Gender = txtGender.Text;
                App.DAUtil.InsertUser(currentUser);
                currentUser = App.DAUtil.GetUserById(0);
                txtName.IsVisible = false;
                txtGender.IsVisible = false;
                loadUser();
            }
        }

        void OnTapNumberPokemons(object sender, EventArgs args) {
            List<Pokemon> listPokemon = App.DAUtil.GetAllOwnedPokemon();
            lvPokemon.ItemsSource = listPokemon;
            lvPokemon.IsVisible = true;

        }
    }
}