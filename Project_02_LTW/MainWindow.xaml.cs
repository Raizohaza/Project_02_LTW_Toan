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
            _data[1].Advance_Moneys.Add(new Advance_Money() { Info = "A tra cho B", Money = 100000});
            _data[1].Advance_Moneys.Add(new Advance_Money() { Info = "A tra cho B", Money = 100000});
            _data[1].Advance_Moneys.Add(new Advance_Money() { Info = "A tra cho B", Money = 100000});

            // lấy data detail
            for (int index = 0; index < count; index++)
            {
                BindingList<Milestone> Milestones = new BindingList<Milestone>();
                BindingList<list_member> list_member = new BindingList<list_member>();
                BindingList<bill> bill = new BindingList<bill>();
                folder = AppDomain.CurrentDomain.BaseDirectory;
                folder = folder + $"TourDetail\\{_data[index].Name}\\";

                //lo trinh
                var MemberFile = File.ReadAllLines(folder + "member.TXT");
                var CostFile = File.ReadAllLines(folder + "cost.txt");
                var MilestoneFile = File.ReadAllLines(folder + "milestone.txt");

                var num = Int32.Parse(MemberFile[0]);

                for (int i = 0; i < num; i++)
                {
                    list_member.Add(new list_member() { Member_Name = MemberFile[1 + 2 * i], Member_Avatar = $"{ folder }{ MemberFile[2 + 2 * i] }" });
                }

                num = Int32.Parse(CostFile[0]);

                for (int i = 0; i < num; i++)
                {
                    bill.Add(new bill() { CostName = CostFile[1 + 2 * i], Cost = Int32.Parse(CostFile[2 + 2 * i]) });
                }

                num = Int32.Parse(MilestoneFile[0]);

                for (int i = 0; i < num; i++)
                {
                    Milestones.Add(new Milestone()
                    {
                        Part = MilestoneFile[1 + 3 * i],
                        Part_Detail = MilestoneFile[2 + 3 * i],
                        Part_Image = $"{folder}{MilestoneFile[3 + 3 * i]}",
                    });
                }
                _data[index].Members = list_member;
                _data[index].bill = bill;
                _data[index].Milestones = Milestones;
            }
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
