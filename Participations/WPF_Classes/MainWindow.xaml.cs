using System;
using System.Collections.Generic;
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

namespace WPF_Classes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool foundError = false;

            if (string.IsNullOrWhiteSpace(txtImage.Text) == true)
            {
                foundError = true;
                MessageBox.Show("Invalid Image");
            }

            if (string.IsNullOrWhiteSpace(txtManufacturer.Text) == true)
            {
                foundError = true;
                MessageBox.Show("Invalid Manufacturer");
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) == true)
            {
                foundError = true;
                MessageBox.Show("Invalid Name");
            }
            double price;
            if (double.TryParse(txtPrice.Text, out price) == false)
            {
                foundError = true;
                MessageBox.Show("Invalid Price");
            }

            if (foundError == true)
            {
                return;
            }

            Toy t = new Toy();
            t.Image = txtImage.Text;
            t.Manufacturer = txtManufacturer.Text;
            t.Name = txtName.Text;
            t.Price = price;

            lstToys.Items.Add(t);

        }

        private void lstToys_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Toy selectedToy = (Toy)lstToys.SelectedItem;
            MessageBox.Show(selectedToy.GetAisle());

            var uri = new Uri(selectedToy.Image);
            var img = new BitmapImage(uri);

            imgToy.Source = img;
        }
    }
}
