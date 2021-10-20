using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace JSON_Serialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Game> AllGames = new List<Game>();

        public MainWindow()
        {
            InitializeComponent();
            cboPlatforms.Items.Add("All");
            string[] linesOfFile = File.ReadAllLines("all_games.csv").Skip(1).ToArray();

            foreach (string line in linesOfFile)
            {

                string[] pieces = line.Split(',');

                //0       1             2           3       4           5
                //name, platform,    release_date, summary, meta_score, user_review

                Game g = new Game()
                {
                    name = pieces[0].Trim(),
                    platform = pieces[1].Trim(),
                    release_date = Convert.ToDateTime(pieces[2]),
                    summary = pieces[3].Trim(),
                    meta_score = Convert.ToInt32(pieces[4]),
                    user_review = pieces[5].Trim()
                };

                if (cboPlatforms.Items.Contains(g.platform.Trim()) == false)
                {
                    cboPlatforms.Items.Add(g.platform.Trim()); 
                }

                lstGames.Items.Add(g);
                AllGames.Add(g);
            }
            lblResultCount.Content = $"Result Count: {lstGames.Items.Count.ToString("n")}";

        }

        private void cboPlatforms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string selectedPlatform = cboPlatforms.Text;
            //string selectedPlatform = cboPlatforms.SelectedItem.ToString();
            string selectedPlatform = (string)cboPlatforms.SelectedItem;
            lstGames.Items.Clear();
            foreach (Game game in AllGames)
            {
                if (selectedPlatform.ToLower() == "all")
                {
                    lstGames.Items.Add(game);
                }
                else if (selectedPlatform == game.platform)
                {
                    lstGames.Items.Add(game);
                }


            }
            lblResultCount.Content = $"Result Count: {lstGames.Items.Count.ToString("n")}";

        }

        private void lstGames_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Game selected = (Game)lstGames.SelectedItem;

            if (selected is null)
            {
                return;
            }

            WindowDetails wd = new WindowDetails();
            wd.SetData(selected);

            wd.ShowDialog();

        }
    }
}
