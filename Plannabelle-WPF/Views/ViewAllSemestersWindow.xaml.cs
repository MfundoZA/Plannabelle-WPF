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
    /// Interaction logic for ViewAllSemestersWindow.xaml
    /// </summary>
    public partial class ViewAllSemestersWindow : Window
    {
        public ViewAllSemestersViewModel ViewAllSemestersViewModel { get; set; }
        public ViewAllSemestersWindow()
        {
            InitializeComponent();

            ViewAllSemestersViewModel = new ViewAllSemestersViewModel();
            DataContext = ViewAllSemestersViewModel;
        }

        private void lstSemesters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewAllSemestersViewModel.SemesterSelected(lstSemesters.SelectedIndex);
            this.Close();
        }
    }
}
