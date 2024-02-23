using FinancialManagementApp.Infrastructure.ModelDto;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinancialManagementApp.ViewModels
{
    public class UserVM : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string? middleName;

        public string FirstName 
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string? MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
