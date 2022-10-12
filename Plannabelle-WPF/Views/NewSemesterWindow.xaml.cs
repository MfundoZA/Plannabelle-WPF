using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.ViewModels;
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

namespace Plannabelle_WPF.Views
{
    /// <summary>
    /// Interaction logic for NewSemesterWindow.xaml
    /// </summary>
    public partial class NewSemesterWindow : Window
    {
        public NewSemesterViewModel NewSemesterViewModel;

        public NewSemesterWindow()
        {
            InitializeComponent();

            NewSemesterViewModel = new NewSemesterViewModel();
            DataContext = NewSemesterViewModel;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Parse(dtpSemesterStartDate.Text);
            DateTime endDate = DateTime.Parse(dtpSemesterEndDate.Text);

            Semester newSemester = new Semester(startDate, endDate);

             // TODO: Implement this using exception handling
            if(NewSemesterViewModel.WriteSemesterToDatabase(newSemester) == false)
            {
                MessageBox.Show("Semester could not be created!");

            }
            else
            {
                MessageBox.Show("Semester created!");
            }

            this.Close();
        }
    }
}
