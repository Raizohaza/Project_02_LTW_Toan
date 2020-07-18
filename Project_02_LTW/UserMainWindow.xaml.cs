using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;

namespace Project_02_LTW
{
    /// <summary>
    /// Interaction logic for UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : UserControl
    {
        public UserMainWindow()
        {
            InitializeComponent();
        }


        ObservableCollection<TCH> _tour= new ObservableCollection<TCH>();

        ObservableCollection<TCH> _data_arrived = new ObservableCollection<TCH>();
        ObservableCollection<TCH> _data_non_arrived = new ObservableCollection<TCH>();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _tour = MainWindow._data;
            for (int i = 0; i < _tour.Count; i++)
            {
                var temp = _tour[i];
                if (temp.Pass == "true")
                {
                    _data_arrived.Add(temp);
                }
                else
                {
                    _data_non_arrived.Add(temp);
                }
            }

            _Arrived.ItemsSource = _data_arrived;
            _non_Arrived.ItemsSource = _data_non_arrived;
        }

        private void arrived_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var temp = (sender as ListView).SelectedItem as TCH;
            if (temp != null)
            {
                Grid2.Children.Add(new UserControlTourDetail(temp));
            }
        }

        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            UCMainWindow.Children.Clear();
            UCMainWindow.Children.Add(new UserMainWindow());
        }

        private void Button_AboutUs_Click(object sender, RoutedEventArgs e)
        {
            UCMainWindow.Children.Clear();
            UCMainWindow.Children.Add(new UserControlAboutUs());
        }

        private void Button_NewTour_Click(object sender, RoutedEventArgs e)
        {
            Grid2.Children.Clear();
            Grid2.Children.Add(new UserControlNewTour());

        }
        private void Button_Nominations_Click(object sender, RoutedEventArgs e)
        {
            Grid2.Children.Clear();
            Grid2.Children.Add(new UserControlNominations());
        }

    }
}
