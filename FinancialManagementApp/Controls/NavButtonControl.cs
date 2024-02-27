using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FinancialManagementApp.Controls
{
    public class NavButtonControl : ListBoxItem
    {
        static NavButtonControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavButtonControl), new FrameworkPropertyMetadata(typeof(NavButtonControl)));
        }

        public string ComponentName
        {
            get { return (string)GetValue(ComponentNameProperty); }
            set { SetValue(ComponentNameProperty, value); }
        }
        public static readonly DependencyProperty ComponentNameProperty =
            DependencyProperty.Register("ComponentName", typeof(string), typeof(NavButtonControl), new PropertyMetadata(null));



        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Geometry), typeof(NavButtonControl), new PropertyMetadata(null));

    }
}
