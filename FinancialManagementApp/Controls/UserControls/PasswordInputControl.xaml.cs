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

        //public string PasswordValue
        //{
        //    get { return (string)GetValue(PasswordValueProperty); }
        //    set { SetValue(PasswordValueProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for PasswordValue.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty PasswordValueProperty =
        //    DependencyProperty.Register("PasswordValue", typeof(string), typeof(PasswordInputControl), new FrameworkPropertyMetadata(String.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

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
