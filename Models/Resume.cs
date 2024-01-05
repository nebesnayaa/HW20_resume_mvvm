
namespace HW20_resume_mvvm.Models
{
    internal class Resume
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        
        public bool Java { get; set; }
        public bool CSharp { get; set; }
        public bool DotNet { get; set; }
        public bool FluentEngish { get; set; }

        public Resume(string name, string surname, string age, string status, string address, string phone,
                      bool java, bool cSharp, bool dotNet, bool english)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Status = status;
            Address = address;
            Phone = phone;

            Java = java;
            CSharp = cSharp;
            DotNet = dotNet;
            FluentEngish = english;
        }

        public override string ToString()
        {
            return Name + ' ' + Surname;
        }
    }
}