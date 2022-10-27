using PlannabelleClassLibrary.ViewModels;
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

namespace Plannabelle_WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;
        }

        private void mniNewSemesterOnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new NewSemesterWindow().ShowDialog();
            this.Show();
        }

        private void mniNewModuleOnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new NewModuleWindow().ShowDialog();
            this.Show();
        }

        private void mniShowAllSemestersOnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new ViewAllSemestersWindow().ShowDialog();
            this.Show();
        }

        private void mniAddSelfHoursOnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new AddSelfStudyHoursWindow().ShowDialog();
            this.Show();
        }

        private void btnLeftAngleNav_Click(object sender, RoutedEventArgs e)
        {
                btnLeftAngleNav.IsEnabled = mainViewModel.moveToPreviousSemester();

                if (mainViewModel.semesters.Count > 1)
                {
                    if (btnLeftAngleNav.IsEnabled == false)
                    {
                        btnRignAngleNav.IsEnabled = true;
                    }
                }
        }

        private void btnRignAngleNav_Click(object sender, RoutedEventArgs e)
        {
            btnRignAngleNav.IsEnabled = mainViewModel.moveToNextSemester();

            if (mainViewModel.semesters.Count > 1)
            {
                if (btnRignAngleNav.IsEnabled == false)
                {
                    btnLeftAngleNav.IsEnabled = true;
                }
            } 
        }

        private void winMain_Loaded(object sender, RoutedEventArgs e)
        {
            var enrollments = DbContext.Enrollment.Where(x => x.User.Id == MainViewModel.User.Id);
        }
    }
}
