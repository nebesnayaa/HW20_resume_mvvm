using System.Windows;
using System.Windows.Input;
using HW20_resume_mvvm.Models;
using HW20_resume_mvvm.Commands;

namespace HW20_resume_mvvm.ViewModels
{
    internal class ResumeViewModel : ViewModelBase
    {

        private static readonly DependencyProperty ResumeInfoProperty;

        static ResumeViewModel()
        {
            ResumeInfoProperty = DependencyProperty.Register(
                "Name", typeof(string), typeof(ResumeViewModel));
        }

        DelegateCommand closeCommand;
        public ICommand CloseCommand { get { return closeCommand; } }

        public ResumeViewModel(Resume resumeModel)
        {
            ResumeInfo = GeneratedInfo(resumeModel);
            closeCommand = new DelegateCommand(CloseWindow, CanAlways);
        }

        private bool CanAlways(object obj)
        {
            return true;
        }

        private void CloseWindow(object obj)
        {
            (obj as Window).Close();
        }

        public string ResumeInfo
        {
            get { return (string)GetValue(ResumeInfoProperty); }
            set { SetValue(ResumeInfoProperty, value); }
        }

        private string GeneratedInfo(Resume resumeModel)
        {
            return $"\t\tОсобиста інформація\n" + 
                   $"Ім'я: {resumeModel.Name} {resumeModel.Surname}\n" +
                   $"Вік: {resumeModel.Age}\n" +
                   $"Сімейний статус: {resumeModel.Status}\n" +
                   $"Адреса:: {resumeModel.Address}\n" +
                   $"Контакт: {resumeModel.Phone}\n" +
                   "\t\tНавички роботи\n" +
                   $"Java: {resumeModel.Java}\nC#: {resumeModel.DotNet}\n.Net: {resumeModel.CSharp}\nFluentEngish: {resumeModel.FluentEngish}\n";
        }
    }
}
