using ScottPlot;

using System.Windows.Controls;


namespace FinancialManagementApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            InitStatisticPlot();
        }

        private void InitStatisticPlot()
        {
            double[] values = { 778, 283, 184, 76, 43 };

            PieSlice slice1 = new() { Value = 11204.80, FillColor = Colors.LightGray, Label = $"Расходы - {11204.80}руб." };
            PieSlice slice2 = new() { Value = 13019.50, FillColor = Colors.LightGreen, Label = $"Доходы  - {13019.50}руб." };

            slice1.LabelStyle.FontSize = 18;
            slice2.LabelStyle.FontSize = 18;

            slice1.LabelStyle.Bold = true;
            slice2.LabelStyle.Bold = true;

            slice1.LabelStyle.ForeColor = Colors.Gray;
            slice2.LabelStyle.ForeColor = Colors.Green;

            List<PieSlice> slices = new() { slice1, slice2 };

            var pie = StatisticChart.Plot.Add.Pie(slices);
            pie.ExplodeFraction = .04;
            pie.ShowSliceLabels = true;

            StatisticChart.Plot.ShowLegend(Alignment.LowerLeft);
            StatisticChart.Plot.HideGrid();
            StatisticChart.Plot.ScaleFactor = 1.5f;
            StatisticChart.Plot.Layout.Frameless();
            StatisticChart.Plot.Axes.AutoScale();
            StatisticChart.Refresh();
        }
    }
}
