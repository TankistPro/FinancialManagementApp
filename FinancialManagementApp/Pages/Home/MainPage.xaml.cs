using FinancialManagementApp.Domain.Entities;
using FinancialManagementApp.Infrastructure.ModelDto;
using FinancialManagementApp.Interfaces;
using FinancialManagementApp.Services;
using FinancialManagementApp.ViewModels;
using ScottPlot;
using System.Text.RegularExpressions;
using System.Windows.Controls;


namespace FinancialManagementApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly StatisticMonthVM _statisticMonthVM;
        private readonly PeriodStatisticVM _periodStatisticVM;
        private readonly StatisticService _statisticService;
		private HomeLayoutVM _homeLayoutVM;

        public MainPage(StatisticMonthVM statisticMonthVM, HomeLayoutVM homeLayoutVM, PeriodStatisticVM periodStatisticVM)
        {
            InitializeComponent();

			_statisticService = new StatisticService();

			_periodStatisticVM = periodStatisticVM;
            _statisticMonthVM = statisticMonthVM;
            _homeLayoutVM = homeLayoutVM;

            this.DataContext = _periodStatisticVM;
        }
        async public void InitPage()
        {
            await InitPeriodStatistic(DateTime.Now);
            await InitStatisticPlot();
        }

        async public Task InitStatisticPlot()
        {
            StatisticMonthDto statisticMonthDto = await _statisticService.InitStatiscticByMonth(DateTime.Now.Month, DateTime.Now.Year, _homeLayoutVM.WalletVM.Id);
            _statisticMonthVM.InitStatistic(statisticMonthDto);

            StatisticChart.Reset();

            var income = (double)_statisticMonthVM.Income + (double)_statisticMonthVM.Expenses + (double)_statisticMonthVM.Other;

            PieSlice slice1 = new() { Value = Math.Abs((double)_statisticMonthVM.Expenses), FillColor = Colors.IndianRed, Label = $"Расходы за месяц: {_statisticMonthVM.Expenses.ToString("N2")} руб." };
            PieSlice slice2 = new() { Value = Math.Abs(income), FillColor = Colors.LightGreen, Label = $"Текущий баланс: {income.ToString("N2")} руб." };
            PieSlice slice3 = new() { Value = Math.Abs((double)_statisticMonthVM.Other), FillColor = Colors.LightGray, Label = $"Другие расходы за месяц: {_statisticMonthVM.Other.ToString("N2")} руб." };

            slice1.LabelStyle.FontSize = 18;
            slice2.LabelStyle.FontSize = 18;
            slice3.LabelStyle.FontSize = 18;

            slice1.LabelStyle.Bold = true;
            slice2.LabelStyle.Bold = true;
            slice3.LabelStyle.Bold = true;

            slice1.LabelStyle.ForeColor = Colors.IndianRed;
            slice2.LabelStyle.ForeColor = Colors.Green;
            slice3.LabelStyle.ForeColor = Colors.LightGray;

            List<PieSlice> slices = new() { slice1, slice2, slice3 };

            var pie = StatisticChart.Plot.Add.Pie(slices);
            pie.ExplodeFraction = .04;

            StatisticChart.Plot.ShowLegend(Alignment.LowerLeft);
            StatisticChart.Plot.HideGrid();
            StatisticChart.Plot.ScaleFactor = 1.5f;
            StatisticChart.Plot.Layout.Frameless();
            StatisticChart.Plot.Axes.AutoScale();
            StatisticChart.Refresh();
		}

        async public Task InitPeriodStatistic(DateTime startDate, DateTime? endDate = null)
        {
            PeriodStatisticDto periodStatisticDto = await _statisticService.InitPeriodStatistic(startDate, _homeLayoutVM.WalletVM.Id, endDate);

			_periodStatisticVM.InitStatistic(periodStatisticDto);
		}
    }
}
