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
    /// Логика взаимодействия для Find_Price.xaml
    /// </summary>
    public partial class Find_Price : MetroWindow
    {
        public double Мin_price { get; set; }
        public double Мax_price { get; set; }
        public Find_Price()
        {
            InitializeComponent();
        }
  
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if((!String.IsNullOrEmpty(TB_Мin_price.Text))&&(!String.IsNullOrEmpty(TB_Max_price.Text)))
            {

                Мin_price = double.Parse(TB_Мin_price.Text);
                Мax_price = double.Parse(TB_Max_price.Text);

                this.DialogResult = true;
                this.Close();

            }
            else
                DialogManager.ShowMessageAsync(this, "Внимание", "Не все поля заполнены! ");
        }
    }
}
  

