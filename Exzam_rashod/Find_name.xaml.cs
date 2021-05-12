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
    /// Логика взаимодействия для Find_name.xaml
    /// </summary>
    public partial class Find_name : MetroWindow
    {
        public string name_consumption { get; set; }
        public Find_name()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TB_name_consumption.Text) )
            {

                name_consumption = TB_name_consumption.Text;
                   

                    this.DialogResult = true;
                    this.Close();
                
            }
            else
                DialogManager.ShowMessageAsync(this, "Внимание", "Не все поля заполнены! ");
        }
    }
    }
