using System;
using System.Collections.Generic;
using System.Linq;
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
using LiveCharts;
using LiveCharts.Wpf;

namespace Project_02_LTW
{
    /// <summary>
    /// Interaction logic for UserControlPieChart.xaml
    /// </summary>
    public partial class UserControlPieChart : UserControl
    {
        TCH _data;
        public UserControlPieChart(TCH tCH)
        {
            InitializeComponent();
            _data = tCH;
            PieChartView.Series = new SeriesCollection();

            for (int i = 0; i < _data.bill.Count; i++)
            {
                var tmp = new PieSeries() { Values = new ChartValues<int>() { _data.bill[i].Cost }, Title = _data.bill[i].CostName };
                PieChartView.Series.Add(
                    new PieSeries()
                    {
                        Values = new ChartValues<float> { _data.bill[i].Cost },
                        Title = _data.bill[i].CostName
                    }
                );
            }
            PieChartView.DataContext = this;
        }

        private void UserControl_Initialized_2(object sender, EventArgs e)
        {
            this.DataContext = this;
        }

        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            var chart = chartPoint.ChartView as PieChart;
            foreach (PieSeries pie in chart.Series)
            {
                pie.PushOut = 0;
            }

            var neo = chartPoint.SeriesView as PieSeries;
            neo.PushOut = 30;
        }

        private void Done_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}