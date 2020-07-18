using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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

namespace Project_02_LTW
{
    /// <summary>
    /// Interaction logic for UserControlTourDetail.xaml
    /// </summary>
    public partial class UserControlTourDetail : UserControl
    {
        private TCH _data;
        BindingList<TCH> _part;
        BindingList<list_member> _get_member;
        string get_tour;
        public UserControlTourDetail(TCH x)
        {
            InitializeComponent();
            _data = x;
            get_tour = _data.Name;
        }
        public string get_data { get => get_tour; set => get_tour = value; }


        private void ModifyData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Show_PieChart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //this.DataContext = _data;
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var tempp = $"{folder}imageeeee//{_data.Imagee}";

            IntroTour.Text = _data.Intro;
            ImageTour.Source = new BitmapImage(new Uri(tempp));
            NameTour.Text = _data.Name;
            data_member.ItemsSource = _data.list_member;

            _part = new BindingList<TCH>();
            _get_member = new BindingList<list_member>();
            data_member.ItemsSource = _get_member;
            imagee_of_team.ItemsSource = _part;
            // lấy data detail
            string filess = "member";
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            appStartPath = appStartPath + $"\\TourDetail\\{get_data}\\";
            //lo trinh
            string fileTxt = appStartPath + $"{get_data}.txt";
            var readTxt = File.ReadAllLines(fileTxt);


            // member
            string fileTxt2 = appStartPath + $"{filess}.txt";
            var readTxt2 = File.ReadAllLines(fileTxt2);

            //int i = 13;
            //int j = 1;

            int number_member = 2;
            
            //int number_member2 = 1;
            //string part_number = "G";

            //////////////////////
            


            var temppp2 = new list_member()
            {
                Member_Avatar = "",
                Member_Name = "",
            };

            if (number_member < 13)
            {
                temppp2.Member_Name = readTxt2[number_member];
                temppp2.Member_Avatar = readTxt2[number_member + 1];
            }
            number_member += 2;
            _get_member.Add(temppp2);



            ///////////////////////////////////////




            //while (i < readTxt.Length)
            //{
            //    var temppp = new TCH()
            //    {

            //        Part = "",
            //        Part_Detail = "",
            //        Part_Image = new BindingList<string>(),

            //    };

             



            //    ObservableCollection<string> listImages = new ObservableCollection<string>();
            //    if (part_number + j.ToString() == readTxt[i])
            //    {

            //        temppp.Part = readTxt[i].Replace("G ", "");
            //        temppp.Part_Detail = readTxt[i + 1];
            //        i += 2;
            //        for (int k = i, temp = j + 1; ; k++)
            //        {
            //            if (k >= readTxt.Length)
            //            {
            //                i = k;
            //                j++;
            //                break;
            //            }

            //            if (part_number + temp.ToString() == readTxt[k] && k < readTxt.Length)
            //            {
            //                i = k;
            //                j++;
            //                break;
            //            }
            //            temppp.Part_Image.Add(appStartPath + readTxt[k]);
            //        }
            //        _part.Add(temppp);

            //    }
            //}
        }
    }
}
