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
    /// Interaction logic for NewModuleWindow.xaml
    /// </summary>
    public partial class NewModuleWindow : Window
    {
        public NewModuleViewModule NewModuleViewModel { get; set; }

        public NewModuleWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Module module = new Module(0, "TEMP5212", "Temporary Module", 20);
            Enrollment enrollment = new Enrollment(0, BaseViewModel.User, module, )
        }
    }
}
