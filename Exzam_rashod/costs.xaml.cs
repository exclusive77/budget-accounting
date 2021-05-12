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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
namespace Exzam_rashod
{
    /// <summary>
    /// Логика взаимодействия для costs.xaml

    /// 
    /// 
    /// </summary>
    public class consumption_list
    {

        public int ID { get; set; }

        public string consumption_name { get; set; }
        public double Price { get; set; }
        public DateTime DateTime_ { get; set; }


    }
    public partial class costs : MetroWindow
    {
        int id;
        DateTime begin_date;
        DateTime end_date;
        public bool user_status { get; set; } = false;
        //  List<Products> products = new List<Products>();
        public double total_sum { get; set; } = 0;
        public double max { get; set; } = 0;
        public costs(string login)
        {

            InitializeComponent();
            TB_user.Text = login;

            DataContext = this;


            using (MyDbContext ctx = new MyDbContext())
            {

                var user_Account = ctx.Accounts.Where(p => p.Login == login).FirstOrDefault();
                id = user_Account.Id;
                this.ProdLb.Items.Clear();
                var costs_ = ctx.consumptions.Include(u => u.Account).Where(p => p.AccountId == id).ToList();
                var user_costs = ctx.Accounts.Where(p => p.Login == login).Include(u => u.consumption).ToList();



                foreach (var item in costs_)
                {
                    this.ProdLb.Items.Add(new consumption_list { ID = item.Id, consumption_name = item.consumption_name, Price = item.Price, DateTime_ = item.DateTime });

                }
                if (costs_.Count > 0)
                {
                    total_sum = costs_.Sum(p => p.Price);
                    max = costs_.Max(p => p.Price);

                }
                else
                {
                    max = 0;
                    total_sum = 0;
                }
                TB_sum.Text = total_sum.ToString();
                TB_Max.Text = max.ToString();
            }

        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add dlg = new Add(id);
            dlg.ShowDialog();

            using (MyDbContext ctx = new MyDbContext())
            {
                this.ProdLb.Items.Clear();
                var costs_ = ctx.consumptions.Include(u => u.Account).Where(p => p.AccountId == id).ToList();




                foreach (var item in costs_)
                {
                    this.ProdLb.Items.Add(new consumption_list { ID = item.Id, consumption_name = item.consumption_name, Price = item.Price, DateTime_ = item.DateTime });

                }
                if (costs_.Count > 0)
                {
                    total_sum = costs_.Sum(p => p.Price);
                    max = costs_.Max(p => p.Price);

                }
                else
                {
                    max = 0;
                    total_sum = 0;
                }
                TB_sum.Text = total_sum.ToString();
                TB_Max.Text = max.ToString();
            }
        }



        private void Del_Click(object sender, RoutedEventArgs e)
        {
            dell dlg = new dell();
            dlg.ShowDialog();
            if (dlg.DialogResult == true)
            {
                using (MyDbContext ctx = new MyDbContext())
                {
                    this.ProdLb.Items.Clear();
                    var costs_ = ctx.consumptions.Include(u => u.Account).Where(p => p.AccountId == id).ToList();




                    foreach (var item in costs_)
                    {
                        this.ProdLb.Items.Add(new consumption_list { ID = item.Id, consumption_name = item.consumption_name, Price = item.Price, DateTime_ = item.DateTime });

                    }
                    if (costs_.Count > 0)
                    {
                        total_sum = costs_.Sum(p => p.Price);
                        max = costs_.Max(p => p.Price);

                    }
                    else
                    {
                        max = 0;
                        total_sum = 0;
                    }
                    TB_sum.Text = total_sum.ToString();
                    TB_Max.Text = max.ToString();
                }
            }

        }

        private void UpdateProd_Click(object sender, RoutedEventArgs e)
        {
            UpdateProd dlg = new UpdateProd();
            dlg.ShowDialog();
            if (dlg.DialogResult == true)
            {
                MessageBox.Show("Cтатья расходов изменена!");
                using (MyDbContext ctx = new MyDbContext())
                {
                    this.ProdLb.Items.Clear();
                    var costs_ = ctx.consumptions.Include(u => u.Account).Where(p => p.AccountId == id).ToList();




                    foreach (var item in costs_)
                    {
                        this.ProdLb.Items.Add(new consumption_list { ID = item.Id, consumption_name = item.consumption_name, Price = item.Price, DateTime_ = item.DateTime });

                    }
                    if (costs_.Count > 0)
                    {
                        total_sum = costs_.Sum(p => p.Price);
                        max = costs_.Max(p => p.Price);

                    }
                    else
                    {
                        max = 0;
                        total_sum = 0;
                    }
                    TB_sum.Text = total_sum.ToString();
                    TB_Max.Text = max.ToString();
                }
            }


            else
                MessageBox.Show("Действия отменены!");
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            Find_data find_Data = new Find_data();
            find_Data.ShowDialog();
            DateTime begin_date1 = find_Data.begin_date;
            DateTime end_date1 = find_Data.end_date;
            if (find_Data.DialogResult == true)
            {

                using (MyDbContext ctx = new MyDbContext())
                {

                    this.ProdLb.Items.Clear();
                    var costs_ = ctx.consumptions.Include(u => u.Account).Where(p => p.AccountId == id && (p.DateTime > begin_date1 && p.DateTime < end_date1)).ToList();

                    ;
                    if (costs_.Count > 0)
                    {

                        foreach (var item in costs_)
                        {
                            this.ProdLb.Items.Add(new consumption_list { ID = item.Id, consumption_name = item.consumption_name, Price = item.Price, DateTime_ = item.DateTime });

                        }

                        total_sum = costs_.Sum(p => p.Price);
                        max = costs_.Max(p => p.Price); ;
                    }
                    else
                    {
                        max = 0;
                        total_sum = 0;
                        TB_Max.Text = max.ToString();
                        TB_sum.Text = total_sum.ToString();
                        MessageBox.Show("Нет расходов в заданном периоде!");
                    }
                    TB_Max.Text = max.ToString();
                    TB_sum.Text = total_sum.ToString();


                }
            }

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            using (MyDbContext ctx = new MyDbContext())
            {


                this.ProdLb.Items.Clear();
                var costs_ = ctx.consumptions.Include(u => u.Account).Where(p => p.AccountId == id).ToList();




                foreach (var item in costs_)
                {
                    this.ProdLb.Items.Add(new consumption_list { ID = item.Id, consumption_name = item.consumption_name, Price = item.Price, DateTime_ = item.DateTime });

                }
                if (costs_.Count > 0)
                {
                    total_sum = costs_.Sum(p => p.Price);
                    max = costs_.Max(p => p.Price);

                }
                else
                {
                    max = 0;
                    total_sum = 0;
                }
                TB_sum.Text = total_sum.ToString();
                TB_Max.Text = max.ToString();
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Find_name find_Name = new Find_name();
            find_Name.ShowDialog();
            string _Name_consumption = find_Name.name_consumption;

            if (find_Name.DialogResult == true)
            {

                using (MyDbContext ctx = new MyDbContext())
                {

                    this.ProdLb.Items.Clear();
                    var costs_ = ctx.consumptions.Include(u => u.Account).Where(p => p.AccountId == id && (p.consumption_name.Contains(_Name_consumption))).ToList();

                    ;
                    if (costs_.Count > 0)
                    {

                        foreach (var item in costs_)
                        {
                            this.ProdLb.Items.Add(new consumption_list { ID = item.Id, consumption_name = item.consumption_name, Price = item.Price, DateTime_ = item.DateTime });

                        }

                        total_sum = costs_.Sum(p => p.Price);
                        max = costs_.Max(p => p.Price); ;
                    }
                    else
                    {
                        max = 0;
                        total_sum = 0;
                        TB_Max.Text = max.ToString();
                        TB_sum.Text = total_sum.ToString();
                        MessageBox.Show("Нет расходов  заданного типа!");
                    }
                    TB_Max.Text = max.ToString();
                    TB_sum.Text = total_sum.ToString();


                }
            }
        }
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Find_Price find_price = new Find_Price();
            find_price.ShowDialog();
            double min_p = find_price.Мin_price;
            double max_p = find_price.Мax_price;
            if (find_price.DialogResult == true)
            {

                using (MyDbContext ctx = new MyDbContext())
                {

                    this.ProdLb.Items.Clear();
                    var costs_ = ctx.consumptions.Include(u => u.Account).Where(p => p.AccountId == id && (p.Price >= min_p && p.Price <= max_p)).ToList();

                    ;
                    if (costs_.Count > 0)
                    {

                        foreach (var item in costs_)
                        {
                            this.ProdLb.Items.Add(new consumption_list { ID = item.Id, consumption_name = item.consumption_name, Price = item.Price, DateTime_ = item.DateTime });

                        }

                        total_sum = costs_.Sum(p => p.Price);
                        max = costs_.Max(p => p.Price); ;
                    }
                    else
                    {
                        max = 0;
                        total_sum = 0;
                        TB_Max.Text = max.ToString();
                        TB_sum.Text = total_sum.ToString();
                        MessageBox.Show("Нет расходов  заданного типа!");
                    }
                    TB_Max.Text = max.ToString();
                    TB_sum.Text = total_sum.ToString();


                }
            }
        }
        private void dell_cont_Click(object sender, RoutedEventArgs e)
        {
            int iD = -1;
            singliton_consumption consumptionss = singliton_consumption.GetInstance();
            if (this.ProdLb.Items.Count != 0)
            {
                if (ProdLb.SelectedIndex > 0)
                {
                    //  checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;


                    consumption_list dd = (consumption_list)(ProdLb.SelectedItem);

                    iD = dd.ID;
                   

                    
                }

                

                using (MyDbContext ctx = new MyDbContext())
                {

                    consumptionss.Delete(iD);
                    ctx.SaveChanges();


                    this.ProdLb.Items.Clear();
                    var costs_ = ctx.consumptions.Include(u => u.Account).Where(p => p.AccountId == id).ToList();




                    foreach (var item in costs_)
                    {
                        this.ProdLb.Items.Add(new consumption_list { ID = item.Id, consumption_name = item.consumption_name, Price = item.Price, DateTime_ = item.DateTime });

                    }
                    if (costs_.Count > 0)
                    {
                        total_sum = costs_.Sum(p => p.Price);
                        max = costs_.Max(p => p.Price);

                    }
                    else
                    {
                        max = 0;
                        total_sum = 0;
                    }
                    TB_sum.Text = total_sum.ToString();
                    TB_Max.Text = max.ToString();
                }
            }

        }

        private void update_con (object sender, RoutedEventArgs e)
        {
            
            int iD = -1;
            singliton_consumption consumptionss = singliton_consumption.GetInstance();
            if (this.ProdLb.Items.Count != 0)
            {
                ;
                if (ProdLb.SelectedIndex >= 0)
                {
                   

                    consumption_list dd = (consumption_list)(ProdLb.SelectedItem);

                    iD = dd.ID;

                    ;

                }
                Update_con dlg_con = new Update_con(iD);
               
                ;
                dlg_con.ShowDialog();
            if (dlg_con.DialogResult == true)
            {
                MessageBox.Show("Cтатья расходов изменена!");
                using (MyDbContext ctx = new MyDbContext())
                {
                    this.ProdLb.Items.Clear();
                    var costs_ = ctx.consumptions.Include(u => u.Account).Where(p => p.AccountId == id).ToList();




                    foreach (var item in costs_)
                    {
                        this.ProdLb.Items.Add(new consumption_list { ID = item.Id, consumption_name = item.consumption_name, Price = item.Price, DateTime_ = item.DateTime });

                    }
                    if (costs_.Count > 0)
                    {
                        total_sum = costs_.Sum(p => p.Price);
                        max = costs_.Max(p => p.Price);

                    }
                    else
                    {
                        max = 0;
                        total_sum = 0;
                    }
                    TB_sum.Text = total_sum.ToString();
                    TB_Max.Text = max.ToString();
                }
            }


            else
                MessageBox.Show("Действия отменены!");
        }

    }
}
}
