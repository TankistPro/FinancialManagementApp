﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace FinancialManagementApp.Controls.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CurrencyInputControl.xaml
    /// </summary>
    public partial class CurrencyInputControl : UserControl, INotifyPropertyChanged
    {
        public CurrencyInputControl()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        private string placeholder;
        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                placeholder = value;
                OnPropertyChanged("Placeholder");
            }
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(inputValue.Text))
            {
                inputPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                inputPlaceholder.Visibility = Visibility.Hidden;
            }
        }
    }
}
