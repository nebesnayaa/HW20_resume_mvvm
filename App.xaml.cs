using System.Windows;
using HW20_resume_mvvm.ViewModels;

namespace HW20_resume_mvvm
{
    public partial class App : Application
    {
        private void StartUp(object sender, StartupEventArgs e)
        {
            MainWindow View = new MainWindow();
            MainViewModel ViewModel = new MainViewModel();
            View.DataContext = ViewModel;

            View.Show();
        }
    }
}
