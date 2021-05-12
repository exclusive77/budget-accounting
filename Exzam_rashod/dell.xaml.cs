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
    /// Логика взаимодействия для dell.xaml
    /// </summary>
    public partial class dell : MetroWindow
    {
        public dell()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            singliton_consumption consumption = singliton_consumption.GetInstance();
            if (IdProdTb.Text != "")
            {
                using (MyDbContext ctx = new MyDbContext())
                {

                    consumption.Delete(int.Parse(IdProdTb.Text));
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