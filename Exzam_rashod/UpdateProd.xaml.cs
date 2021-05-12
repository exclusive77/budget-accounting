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
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using MahApps.Metro.Controls;
using System.Configuration;
using System.Data.SqlClient;
using MahApps.Metro.Controls.Dialogs;

namespace Exzam_rashod
{
    /// <summary>
    /// Логика взаимодействия для UpdateProd.xaml
    /// </summary>
    public partial class UpdateProd : MetroWindow
    {
        consumption select;

        public UpdateProd()
        {
            InitializeComponent();
            UpdateBtn.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            singliton_consumption consumption = singliton_consumption.GetInstance();

            try
            {
                int id = int.Parse(IdTb.Text);
                startBtn.IsEnabled = false;
                IdTb.IsEnabled = false;
                UpdateBtn.IsEnabled = true;
                using (MyDbContext ctx = new MyDbContext())
                {
                   select = consumption.Get(id);
                    if (select != null)
                    {
                        titleTB.Text = "Название:";
                        PriceTB.Text = "Цена:";
                        titleTb.Text = select.consumption_name;
                        PriceTb.Text = $"{select.Price}";
                        DatePicker2.SelectedDate = select.DateTime;
                        startBtn.IsEnabled = false;
                        IdTb.IsEnabled = false;
                        UpdateBtn.IsEnabled = true;


                    }
                    else
                    {
                        MessageBox.Show("Расход с таким ид не найден!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Некорректно введены данные!");
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            singliton_consumption consumption = singliton_consumption.GetInstance();
            if (titleTb.Text != "" && PriceTb.Text != "")
            {
                try
                {
                    int id = int.Parse(IdTb.Text);
                    using (MyDbContext ctx = new MyDbContext())
                    {
                       select.consumption_name = titleTb.Text ;
                        select.Price = double.Parse(PriceTb.Text);
                        select.DateTime= DateTime.Parse(DatePicker2.Text);
                        startBtn.IsEnabled = false;
                        IdTb.IsEnabled = false;
                        UpdateBtn.IsEnabled = true;
                        var up = consumption.Get(id);
                        consumption.Update(select);


                        ctx.SaveChanges();
                        this.DialogResult = true;
                        this.Close();


                    }
                }
                catch
                {
                    MessageBox.Show("Некорректно введены данные!");
                }
            }
            else
            {
                MessageBox.Show("Поля не должны быть пустыми!");
            }

        }
    }
}

