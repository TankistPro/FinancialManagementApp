using FinancialManagementApp.Infrastructure.ModelDto;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinancialManagementApp.ViewModels
{
    public class UserVM : BaseViewModel
    {
        private int id;
        private string firstName;
        private string lastName;
        private string? middleName;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

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
    }
}
