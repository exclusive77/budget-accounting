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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<consumption> consumptions { get; set; }
    }
   
    public partial class MainWindow : MetroWindow
    {
        public string login;
        public MainWindow()
        {
            InitializeComponent();
          /*using (MyDbContext ctx = new MyDbContext())
            {
                // Жадная загрузка
              
                consumption pl1 = new consumption { consumption_name = "Шкаф", Price = 2200, DateTime = new DateTime(2018, 11, 12) } ;
                consumption pl2 = new consumption { consumption_name = "Диван", Price = 4200, DateTime = new DateTime(2018, 06, 10) };
                consumption pl3 = new consumption { consumption_name = "Штаны", Price = 1000, DateTime = new DateTime(2018, 02, 05) };

               
                ctx.Accounts.Add(new Account
              {
                  Login = "vas_2018",
                  Password = "2018_vvv",


                 user = new User
                 {
                     Firstname = "Vasya",
                     Lastname = "Petrov",
                 },
                consumption = new List<consumption> { pl1, pl2, pl3 }
                });
            

                ctx.SaveChanges();
            }

         */
        }
       

        private void BT_avoriz_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TB_login.Text) && (!String.IsNullOrEmpty(PS_password.Password)))
            {
                using (MyDbContext ctx = new MyDbContext())
                {
                    var account = ctx.Accounts.ToList();

                    if (account.Exists(u => u.Login == TB_login.Text)&& (account.Exists(u => u.Password == PS_password.Password)))
                    {
                        login = TB_login.Text;
        costs dlgM = new costs(login);


                        dlgM.ShowDialog();

                    }

                    else
                        DialogManager.ShowMessageAsync(this, "Внимание", "Неверный логин или пароль! ");

                }
            }

        
            else
                DialogManager.ShowMessageAsync(this, "Внимание", "Не все поля заполнены! ");
        }
    


        private void BT_rigisr_Click(object sender, RoutedEventArgs e)
        {

            Reg dlgReg = new Reg();

            dlgReg.ShowDialog();
            if (dlgReg.DialogResult == true)
            {
                DialogManager.ShowMessageAsync(this, "Сообщение", "Регестрация прошла успешно ");

            }
        }
    }
}

