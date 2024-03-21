﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagementApp.ViewModels
{
    public class DirectoryPageVM : INotifyPropertyChanged
    {
        private ObservableCollection<CategoryVM>? _categoryListVM;

        public ObservableCollection<CategoryVM> CategoryListVM
        {
            get { return _categoryListVM; }
            set
            {
                _categoryListVM = value;
                OnPropertyChanged("CategoryListVM");
            }
        }

        public void SetCategoryListVM(ObservableCollection<CategoryVM> categoryListVM)
        {
            if (categoryListVM != null)
            {
                this.CategoryListVM = categoryListVM;
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