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
        public NewModuleViewModel NewModuleViewModel { get; set; }
        public PlannabelleDbContext DbContext { get; }

        public NewModuleWindow()
        {
            InitializeComponent();
            
            NewModuleViewModel = new NewModuleViewModel();
            this.DataContext = NewModuleViewModel;
            DbContext = PlannabelleContextDbFactory.GetDbContext();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            int semesterId = Int32.Parse(cmbSemesters.SelectedValue.ToString());
            var selectedSemester = (Semester) DbContext.Semester.Where(x => x.Id == semesterId).First();

            // TEMP5212 | "Temporary Module" | 15 |
            var moduleCode = txtModuleCode.Text;
            var moduleName = txtModuleName.Text;
            var numberOfCredits = Int32.Parse(txtNumberOfCredits.Text);
            var numberOfClassHours = Int32.Parse(txtNumberOfClassHours.Text);
            var selfStudyHours = Int32.Parse(NewModuleViewModel.calculateSelfStudyHours(numberOfCredits, selectedSemester, numberOfClassHours).ToString());
            var selfStudyHoursRemaining = Int32.Parse(txtSelfStudyHoursRemainingForTheWeek.Text);


            Module module = new Module(moduleCode, moduleName, numberOfCredits);
            DbContext.Module.Add(module);
            DbContext.SaveChanges();

            var lastModule = DbContext.Module.OrderBy(x => x.Id).Last();
            Enrollment enrollment = new Enrollment(BaseViewModel.User, lastModule, selectedSemester, numberOfClassHours, selfStudyHours, selfStudyHoursRemaining);
            DbContext.Enrollment.Add(enrollment);
            DbContext.SaveChanges();
        }
    }
}
