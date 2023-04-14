using PlannabelleClassLibrary.Data;
using PlannabelleClassLibrary.Models;
using PlannabelleClassLibrary.ViewModels;
using System;
using System.Collections.ObjectModel;
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
        MainViewModel MainViewModel;
        PlannabelleDbContext DbContext;

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = new MainViewModel();
            this.DataContext = MainViewModel;

            DbContext = PlannabelleContextDbFactory.GetDbContext();
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
                btnLeftAngleNav.IsEnabled = MainViewModel.moveToPreviousSemester();

                if (MainViewModel.currentSemesterIndex < MainViewModel.semesters.Count - 1)
                {
                        btnRignAngleNav.IsEnabled = true;
                }

            refreshList();
        }

        private void btnRignAngleNav_Click(object sender, RoutedEventArgs e)
        {
            btnRignAngleNav.IsEnabled = MainViewModel.moveToNextSemester();

            if (MainViewModel.currentSemesterIndex > 0)
            {             
                    btnLeftAngleNav.IsEnabled = true;
            }

            refreshList();
        }

        private void winMain_Loaded(object sender, RoutedEventArgs e)
        {
            refreshList();
        }

        private void refreshList()
        {
            if (MainViewModel.semesters.Count != 0)
            {
                var modules = (from module in DbContext.Module
                               join enrollment in DbContext.Enrollment
                               on module.Id equals enrollment.Module.Id
                               where enrollment.Semester.Id == MainViewModel.CurrentSemester.Id
                               select module).ToList();

                MainViewModel.Modules = new ObservableCollection<Module>(modules);
            }
        }

        private void mniSettingsOnClick(object sender, RoutedEventArgs e)
        {
                this.Hide();
                new SettingsWindow().ShowDialog();
                this.Show();
        }
    }
}
