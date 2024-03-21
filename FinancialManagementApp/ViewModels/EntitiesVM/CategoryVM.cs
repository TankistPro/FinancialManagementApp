using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.ViewModels
{
    public class CategoryVM : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private int? _parentId;
        private string? _color;
        private int _order;
        private string _directoryType;

        public int Id { 
            get { return _id; } 
            set { 
                _id = value; 
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public int? ParentId
        {
            get { return _parentId; }
            set
            {
                _parentId = value;
                OnPropertyChanged("ParentId");
            }
        }

        public string? Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }

        public int Order
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged("Order");
            }
        }

        public string DirectoryType
        {
            get { return _directoryType; }
            set
            {
                _directoryType = value;
                OnPropertyChanged("DirectoryType");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
