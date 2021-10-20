using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JSON_Serialization
{
    /// <summary>
    /// Interaction logic for WindowDetails.xaml
    /// </summary>
    public partial class WindowDetails : Window
    {
        public WindowDetails()
        {
            InitializeComponent();
        }

        public void SetData (Game selectedGame)
        {
            txtMetaScore.Text = selectedGame.meta_score.ToString();
            txtName.Text = selectedGame.name.ToString();
            txtPlatform.Text = selectedGame.platform.ToString();
            txtReleaseDate.Text = selectedGame.release_date.ToShortDateString();
            txtReview.Text = selectedGame.user_review.ToString();
            txtSummary.Text = selectedGame.summary.ToString();

            Title = $"{selectedGame.name}'s Info";
        }
    }
}
