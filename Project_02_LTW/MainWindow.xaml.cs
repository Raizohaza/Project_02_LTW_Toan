using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
using System.ComponentModel;

namespace Project_02_LTW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        public static ObservableCollection<TCH> _data = new ObservableCollection<TCH>();
        public void traveling()
        {
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var database = $"{folder}data_travel.txt";
            var lines = File.ReadAllLines(database);
            int count = int.Parse(lines[0]);
            for (int i = 0; i < count; i++)
            {
                var line1 = lines[i * 4 + 1];
                var line2 = lines[i * 4 + 2];

                var line3 = lines[i * 4 + 3];
                var line4 = lines[i * 4 + 4];


                var temp = new TCH()
                {
                    Name = line1,
                    Imagee = line3,
                    Intro = line2,
                    Pass = line4,
                };
                _data.Add(temp);
            }
            _data[0].list_member.Add("abc");
            _data[0].list_member.Add("xyz");
            _data[0].list_member.Add("ccc");

            _data[0].bill.Add(new bill { CostName = "Di chuyen" , Cost = 100000});
            _data[0].bill.Add(new bill { CostName = "Di" , Cost = 100000});
            _data[0].bill.Add(new bill { CostName = "chuyen" , Cost = 100000});

            _data[0].Milestones.Add(new Milestone
            {
                Images = new BindingList<string>() { "vinh_ha_long.jpg", "vinh_ha_long.jpg" }
            ,
                Places = new BindingList<string>() { "Vinh", "Du thuyen" }
            });
            _data[0].Milestones.Add(new Milestone
            {
                Images = new BindingList<string>() { "vinh_ha_long.jpg", "vinh_ha_long.jpg" }
            ,
                Places = new BindingList<string>() { "Vinh", "Du thuyen" }
            });
            _data[0].Milestones.Add(new Milestone
            {
                Images = new BindingList<string>() { "vinh_ha_long.jpg", "vinh_ha_long.jpg" }
            ,
                Places = new BindingList<string>() { "Vinh", "Du thuyen" }
            });

            _data[0].Advance_Moneys.Add(new Advance_Money() { Info = "A tra cho B", Money = 100000});
            _data[0].Advance_Moneys.Add(new Advance_Money() { Info = "A tra cho B", Money = 100000});
            _data[0].Advance_Moneys.Add(new Advance_Money() { Info = "A tra cho B", Money = 100000});
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            traveling();
            var screen = new UserMainWindow();
            Main.Children.Add(screen);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        
       
    }
}
