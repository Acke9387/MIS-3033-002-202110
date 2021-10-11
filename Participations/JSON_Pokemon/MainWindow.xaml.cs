using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JSON_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PokemonInfo pokemon;
        private bool showBack;
        public MainWindow()
        {
            InitializeComponent();

            string url = "https://pokeapi.co/api/v2/pokemon?offset=0&limit=1200";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    AllPokemonAPI api = JsonConvert.DeserializeObject<AllPokemonAPI>(json);

                    foreach (var resultItem in api.results)
                    {
                        cboPokies.Items.Add(resultItem);
                    }

                }

            }

        }

        private void cboPokies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResultItem selected = (ResultItem)cboPokies.SelectedItem;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(selected.url).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                     pokemon = JsonConvert.DeserializeObject<PokemonInfo>(json);

                    imgPokemon.Source = new BitmapImage(new Uri(pokemon.sprites.front_default));
                    showBack = true;

                }

            }

        }

        private void btnToggle_Click(object sender, RoutedEventArgs e)
        {
            if (showBack)
            {
                imgPokemon.Source = new BitmapImage(new Uri(pokemon.sprites.back_default));
                showBack = false;
            }
            else
            {
                imgPokemon.Source = new BitmapImage(new Uri(pokemon.sprites.front_default));
                showBack = true;
            }
        }
    }
}
