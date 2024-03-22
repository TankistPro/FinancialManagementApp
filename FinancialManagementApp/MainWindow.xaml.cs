using System.Windows;
using System.Windows.Navigation;


namespace FinancialManagementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow(AuthPage authPage)
        {
            InitializeComponent();
            
            this.mainWindowFraim.Content = authPage;

            this.Closed += (e, x) => Application.Current.Shutdown();
        }
    }
}