using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinancialManagementApp.Controls.UserControls
{
    /// <summary>
    /// Логика взаимодействия для PasswordInputControl.xaml
    /// </summary>
    public partial class PasswordInputControl : UserControl, INotifyPropertyChanged
    {
        public PasswordInputControl()
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

        private void inputValue_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(inputValue.Password))
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
