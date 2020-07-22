using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_02_LTW
{
    public class TCH
    {
        public string Name { get; set; } = "";
        public string Imagee { get; set; } = "";
        public string Intro { get; set; } = "";
        public string Pass { get; set; } = "";
        public BindingList<list_member> Members { get; set; } = new BindingList<list_member>();
        public BindingList<bill> bill { get; set; } = new BindingList<bill>();
        public BindingList<Milestone> Milestones { get; set; } = new BindingList<Milestone>();
        public BindingList<Advance_Money> Advance_Moneys { get; set; } = new BindingList<Advance_Money>();//ung truoc

    }
    // lo trinh
    public class Milestone
    {
        public string Part { get; set; }
        public string Part_Detail { get; set; }
        public string Part_Image { get; set; } = "";
    }
    public class Advance_Money
    {
        public int Money { get; set; } = 0;
        public string Info { get; set; } = "";//nguoi ung truoc va nguoi duoc ung truoc
    }
}
