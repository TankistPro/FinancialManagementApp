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

        public Uri NavLink
        {
            get { return (Uri)GetValue(NavLinkProperty); }
            set { SetValue(NavLinkProperty, value); }
        }
        public static readonly DependencyProperty NavLinkProperty =
            DependencyProperty.Register("NavLink", typeof(Uri), typeof(NavButtonControl), new PropertyMetadata(null));



        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Geometry), typeof(NavButtonControl), new PropertyMetadata(null));

    }
}
