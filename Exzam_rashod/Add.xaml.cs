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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : MetroWindow
    {
        int ID;
        public Add(int id)
        {
            ID = id;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            singliton_consumption consumption = singliton_consumption.GetInstance();
            if (nameProdTb.Text != "" && priceProdTb.Text != "")
            {
                using (MyDbContext ctx = new MyDbContext())
                {
                    consumption pl4 = new consumption { consumption_name = nameProdTb.Text, Price = double.Parse(priceProdTb.Text), DateTime = DateTime.Parse(DatePicker1.Text), AccountId = ID };
                    consumption.Create(pl4);
                    ctx.SaveChanges();
                    this.DialogResult = true;
                    this.Close();
                }
            }
            else
                MessageBox.Show("Не все поля заполнены!");
        }
    }
}
  