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

namespace JSON_Chuck_Norris_Jokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cboCategories.Items.Clear();
            cboCategories.Items.Add("all");

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync("https://api.chucknorris.io/jokes/categories").Result;

                List<string> categories = JsonConvert.DeserializeObject<List<string>>(json);

                foreach (string cat in categories)
                {
                    cboCategories.Items.Add(cat);
                }
            }

        }

        private void btnGetJoke_Click(object sender, RoutedEventArgs e)
        {
            string url;
            string category = cboCategories.SelectedValue.ToString();
            if (category.ToLower() == "all")
            {
                url = "https://api.chucknorris.io/jokes/random";
            }
            else
            {
                url = "https://api.chucknorris.io/jokes/random?category=";

                url += category;
            }

           


            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;

                Joke joke = JsonConvert.DeserializeObject<Joke>(json);

                txtJoke.Text = joke.value;
            }


        }
    }
}