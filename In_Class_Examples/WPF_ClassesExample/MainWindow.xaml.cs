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

namespace WPF_ClassesExample
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
            string id, fname, lname, gpa, probation, balance;

            id = txtID.Text;
            fname = txtFirst.Text;
            lname = txtLast.Text;
            gpa = txtGpa.Text;
            //probation = txtProbation.Text;
            balance = txtBursarBalance.Text;

            Student stud = new Student(Convert.ToInt32(id), fname,lname, Convert.ToDouble(balance));
            stud.GPA = Convert.ToDouble(gpa);
            //if (probation.ToLower() == "yes")
            //{
            //    stud.IsOnProbation = true;
            //}
            //else
            //{
            //    stud.IsOnProbation = false;
            //}
            stud.IsOnProbation = chkProbation.IsChecked.Value;

            lstStudents.Items.Add(stud);
        }

        private void lstStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student selected = (Student)lstStudents.SelectedItem;

            MessageBox.Show(selected.CheckBalance().ToString("C"));
        }
    }
}
