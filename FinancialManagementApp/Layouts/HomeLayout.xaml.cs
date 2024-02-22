using FinancialManagementApp.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinancialManagementApp.Layouts
{
    /// <summary>
    /// Логика взаимодействия для HomeLayout.xaml
    /// </summary>
    public partial class HomeLayout : Page
    {
        public HomeLayout()
        {

            InitializeComponent();

            if(this.sideBar.Items.Count > 0)
            {
                this.sideBar.SelectedIndex = 0;
            }

            WindowWidth = 1200;
            WindowHeight = 700;

            this.Loaded += (s, e) => MainWindow.PostitionWindowOnScreen(0, 0);

        }

        private void sideBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = sideBar.SelectedItem as NavButtonControl;

            mainFraim.Navigate(selected.NavLink);
        }
    }
}
