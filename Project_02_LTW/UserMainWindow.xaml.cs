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
using System.Linq.Expressions;
using System.Security.Policy;
using System.ComponentModel;

namespace Project_02_LTW
{
    /// <summary>
    /// Interaction logic for UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : UserControl
    {
        public UserMainWindow()
        {
            _tour = MainWindow._data;

            InitializeComponent();
        }


        ObservableCollection<TCH> _tour= new ObservableCollection<TCH>();

        ObservableCollection<TCH> _data_arrived = new ObservableCollection<TCH>();
        ObservableCollection<TCH> _data_non_arrived = new ObservableCollection<TCH>();
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _tour = new ObservableCollection<TCH>();
            _tour = MainWindow._data;
            for (int i = 0; i < _tour.Count; i++)
            {
                var temp = _tour[i];
                if (temp.Pass == "true" && !_data_arrived.Contains(temp))
                {
                    _data_arrived.Add(temp);
                }
                else if (temp.Pass != "true" && !_data_non_arrived.Contains(temp))
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
                var index = _tour.IndexOf(temp);
                Grid2.Children.Clear();
                Grid2.Children.Add(new UserControlTourDetail(temp, index));
            }
        }
        private void _non_Arrived_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var temp = (sender as ListView).SelectedItem as TCH;
            if (temp != null)
            {
                var index = _tour.IndexOf(temp);
                Grid2.Children.Clear();
                Grid2.Children.Add(new UserControlTourDetail(temp, index));
            }

        }
        private void txtNameToSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            string txtOrig = txtNameToSearch.Text;
            string upper = txtOrig.ToUpper();
            var empFilteredArrived = from Emp in _data_arrived
                                     let ename = Emp.Name.ToUpper()
                                     where
                                      ename.StartsWith(upper)
                                      || ename.StartsWith(upper)
                                      || ename.Contains(txtOrig.ToUpper())
                                     select Emp;
            var empFilteredNon_Arrived = from Emp in _data_non_arrived
                                         let ename = Emp.Name.ToUpper()
                                         where
                                          ename.StartsWith(upper)
                                          || ename.StartsWith(upper)
                                          || ename.Contains(txtOrig.ToUpper())
                                         select Emp;
            var tmpArrived = empFilteredArrived.ToList();
            var tmpNon_Arrived = empFilteredNon_Arrived.ToList();
            var tmp = new ObservableCollection<TCH>();
            var tmp2 = new ObservableCollection<TCH>();

            for (int i = 0; i < tmpArrived.Count; i++)
            {
                tmp.Add(tmpArrived[i]);

            }
            for (int i = 0; i < tmpNon_Arrived.Count; i++)
            {
                tmp2.Add(tmpNon_Arrived[i]);
            }
            if (txtNameToSearch.Text.Length != 0)
            {
                _Arrived.ItemsSource = tmp;
                _non_Arrived.ItemsSource = tmp2;
            }
            else
            {
                UCMainWindow.Children.Clear();
                UCMainWindow.Children.Add(new UserMainWindow());
            }
        }
        private void TextNameToSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            string txtOrig = TextNameToSearch.Text.ToUpper();

            var tmp = new ObservableCollection<TCH>();
            var tmp2 = new ObservableCollection<TCH>();

            for (int i = 0; i < _data_arrived.Count; i++)
            {
                for (int j = 0; j < _data_arrived[i].Members.Count; j++)
                {
                    if (_data_arrived[i].Members[j].Member_Name.ToUpper().Contains(txtOrig) && !tmp.Contains(_data_arrived[i]))
                        tmp.Add(_data_arrived[i]);
                }
            }
            for (int i = 0; i < _data_non_arrived.Count; i++)
            {
                for (int j = 0; j < _data_non_arrived[i].Members.Count; j++)
                {
                    if (_data_non_arrived[i].Members[j].Member_Name.ToUpper().Contains(txtOrig) && !tmp2.Contains(_data_non_arrived[i]))
                        tmp2.Add(_data_non_arrived[i]);
                }
            }
            if (TextNameToSearch.Text.Length != 0)
            {
                _Arrived.ItemsSource = tmp;
                _non_Arrived.ItemsSource = tmp2;
            }
            else
            {
                UCMainWindow.Children.Clear();
                UCMainWindow.Children.Add(new UserMainWindow());
            }

        }

        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            UCMainWindow.Children.Clear();
            UCMainWindow.Children.Add(new UserMainWindow());
        }

        private void Button_AboutUs_Click(object sender, RoutedEventArgs e)
        {
            Grid2.Children.Clear();
            Grid2.Children.Add(new UserControlAboutUs());
        }

        private void Button_NewTour_Click(object sender, RoutedEventArgs e)
        {
            Grid2.Children.Add(new UserControlNewTour());
        }
        private void Button_Nominations_Click(object sender, RoutedEventArgs e)
        {
            Grid2.Children.Clear();
            Grid2.Children.Add(new UserControlNominations());
        }

       
    }
}
