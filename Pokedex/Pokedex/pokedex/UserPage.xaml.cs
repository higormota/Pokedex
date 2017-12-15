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
            LoadOwnedPokemon();
        }

        void loadUser() {
            var usuario = App.DAUtil.GetUserById(currentUser.Id);
            currentUser = usuario != null ? usuario : currentUser ;

           if (currentUser.Name == null)
           {
                txtName.Placeholder = "Enter your name... ";
                txtName.HorizontalOptions = LayoutOptions.Start;
                txtName.SetValue(Grid.RowProperty, 1);
                txtName.FontSize = 12;
                txtGender.Placeholder = "Enter your gender...";
                txtGender.HorizontalOptions = LayoutOptions.Start;
                txtGender.FontSize = 12;
                txtGender.SetValue(Grid.RowProperty, 2);
    


                grdUserData.Children.Add(txtName);
                grdUserData.Children.Add(txtGender);
                createButton.IsVisible = true;
                createButton.Text = "Create";
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


        async void OnCreateUserClicked(object sender, EventArgs args)
        {
           if (lblName.IsVisible)
           {
                createButton.IsVisible = false;
            }
            else
            {
                currentUser.Name = txtName.Text;
                currentUser.Gender = txtGender.Text;
                App.DAUtil.InsertUser(currentUser);
                currentUser = App.DAUtil.GetUserById(0);
                txtName.IsVisible = false;
                txtGender.IsVisible = false;
                createButton.IsVisible = false;
                loadUser();
            }
        }

        async void OnTapBack(object sender, EventArgs args)
        {
                await Navigation.PopModalAsync();
         
        }

        void LoadOwnedPokemon() {
            List<Pokemon> listPokemon = App.DAUtil.GetAllOwnedPokemon();
            List<KeyValuePair<long,ImageSource>> images = new List<KeyValuePair<long, ImageSource>>();
            foreach (var pokemon in listPokemon)
            {
                images.Add(new KeyValuePair<long, ImageSource>(pokemon.Id, ImageSource.FromResource("Pokedex.Resources.pokemon.pokemon(" + pokemon.Id + ").ico")));
            }


            var query = from order in listPokemon
                        join plan in images
                             on order.Id equals plan.Key
                        select new
                        {
                            order.Id,
                            order.Name,
                            plan.Value
                        };

            lvPokemon.ItemsSource = query;
            

        }
    }
}