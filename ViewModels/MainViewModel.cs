using HW20_resume_mvvm.Commands;
using HW20_resume_mvvm.Models;
using HW20_resume_mvvm.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Text.Json;
using System.ComponentModel;



namespace HW20_resume_mvvm.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {

        private static readonly DependencyProperty NameProperty;
        private static readonly DependencyProperty SurnameProperty;
        private static readonly DependencyProperty AgeProperty;
        private static readonly DependencyProperty StatusProperty;
        private static readonly DependencyProperty AddressProperty;
        private static readonly DependencyProperty PhoneProperty;

        private static readonly DependencyProperty IsJavaProperty;
        private static readonly DependencyProperty DotNetProperty;
        private static readonly DependencyProperty IsCSharpProperty;
        private static readonly DependencyProperty FluentEnglishProperty;

        private static readonly DependencyProperty SelectedResumeItemProperty;

        static MainViewModel()
        {
            NameProperty = DependencyProperty.Register(
                "Name", typeof(string), typeof(MainViewModel));

            SurnameProperty = DependencyProperty.Register(
                "Surname", typeof(string), typeof(MainViewModel));

            AgeProperty = DependencyProperty.Register(
                "Age", typeof(string), typeof(MainViewModel));

            StatusProperty = DependencyProperty.Register(
                "Status", typeof(string), typeof(MainViewModel));

            AddressProperty = DependencyProperty.Register(
                "Address", typeof(string), typeof(MainViewModel));

            PhoneProperty = DependencyProperty.Register(
                "Phone", typeof(string), typeof(MainViewModel));

            IsJavaProperty = DependencyProperty.Register(
                "Java", typeof(bool), typeof(MainViewModel));

            IsCSharpProperty = DependencyProperty.Register(
                "CSharp", typeof(bool), typeof(MainViewModel));

            DotNetProperty = DependencyProperty.Register(
                "CPlusPlus", typeof(bool), typeof(MainViewModel));

            FluentEnglishProperty = DependencyProperty.Register(
                "English", typeof(bool), typeof(MainViewModel));

            SelectedResumeItemProperty = DependencyProperty.Register(
                "SelectedResumeItem", typeof(Resume), typeof(MainViewModel));
        }

        public MainViewModel()
        {
            Resumes = new ObservableCollection<Resume>();

            string json = File.ReadAllText("Resumes.json");
        }

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public string Surname
        {
            get { return (string)GetValue(SurnameProperty); }
            set { SetValue(SurnameProperty, value); }
        }

        public string Age
        {
            get { return (string)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public string Address
        {
            get { return (string)GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }

        public string Phone
        {
            get { return (string)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }

        public bool IsJava
        {
            get { return (bool)GetValue(IsJavaProperty); }
            set { SetValue(IsJavaProperty, value); }
        }

        public bool IsCSharp
        {
            get { return (bool)GetValue(IsCSharpProperty); }
            set { SetValue(IsCSharpProperty, value); }
        }

        public bool DotNet
        {
            get { return (bool)GetValue(DotNetProperty); }
            set { SetValue(DotNetProperty, value); }
        }

        public bool FluentEnglish
        {
            get { return (bool)GetValue(FluentEnglishProperty); }
            set { SetValue(FluentEnglishProperty, value); }
        }

        public Resume SelectedResumeItem
        {
            get { return (Resume)GetValue(SelectedResumeItemProperty); }
            set { SetValue(SelectedResumeItemProperty, value); }
        }

        public ObservableCollection<Resume> Resumes { get; set; }

        DelegateCommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new DelegateCommand(SaveResume, CanSaveResume);
                }

                return saveCommand;
            }
        }

        private void SaveResume(object obj)
        {
            Resumes.Add(new Resume(Name, Surname, Age, Status, Address, Phone, FluentEnglish, IsJava, DotNet, IsCSharp));

            string json = JsonSerializer.Serialize(Resumes);
            File.WriteAllText("Resumes.json", json);
        }

        private bool CanSaveResume(object obj)
        {
            return true;
        }

        DelegateCommand clearCommand;

        public ICommand ClearCommand
        {
            get
            {
                clearCommand = new DelegateCommand(ClearResume, CanClearResume);
                return clearCommand;
            }
        }

        private void ClearResume(object obj)
        {
            Name = "";
            Surname = "";
            Age = "";
            Status = "";
            Address = "";
            Phone = "";
            IsJava = false;
            IsCSharp = false;
            DotNet = false;
            FluentEnglish = false;
        }

        private bool CanClearResume(object obj)
        {
            return true;
        }

        DelegateCommand showCommand;

        public ICommand ShowCommand
        {
            get
            {
                if (showCommand == null)
                {
                    showCommand = new DelegateCommand(ShowResume, CanShowResume);
                }

                return showCommand;
            }
        }

        private bool CanShowResume(object obj)
        {
            return SelectedResumeItem != null;
        }

        private void ShowResume(object obj)
        {
            ResumeWindow resume = new ResumeWindow();
            ResumeViewModel resumeModel = new ResumeViewModel(SelectedResumeItem);
            resume.DataContext = resumeModel;
            resume.Show();
        }
    }
   
}
