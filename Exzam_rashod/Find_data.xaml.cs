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
    /// Логика взаимодействия для Find_data.xaml
    /// </summary>
    public partial class Find_data : MetroWindow
    {
        public DateTime begin_date { get; set; }
        public DateTime end_date { get; set; }
    
        public Find_data()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(DatePicker_begin.Text) && (!String.IsNullOrEmpty(DatePicker_end.Text)))
            {
                if (DateTime.Parse(DatePicker_begin.Text) <= DateTime.Parse(DatePicker_end.Text))
                {
                    begin_date = DateTime.Parse(DatePicker_begin.Text);
                    end_date = DateTime.Parse(DatePicker_end.Text);
                    
                    this.DialogResult = true;
                    this.Close();
                }
                else
                    DialogManager.ShowMessageAsync(this, "Внимание", "Дата поиска заданна не верно! ");
            }
            else
                DialogManager.ShowMessageAsync(this, "Внимание", "Не все поля заполнены! ");
        }
    }
}
