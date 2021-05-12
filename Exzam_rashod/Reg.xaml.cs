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
using System.Linq;
namespace Exzam_rashod
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
   
        public partial class Reg : MetroWindow
        {
           // public string connStr = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            public Reg()
            {
                InitializeComponent();
            singliton_user _User = singliton_user.GetInstance();
        }

            private void Bt_regist_Click(object sender, RoutedEventArgs e)
            {

            if (!String.IsNullOrEmpty(TB_Firstname.Text) && (!String.IsNullOrEmpty(TB_Lastname.Text))
                && !String.IsNullOrEmpty(TB_login1.Text) && !String.IsNullOrEmpty(TB_login1.Text))
            {
                using (MyDbContext ctx = new MyDbContext())
                {
                    var account = ctx.Accounts.ToList();

                    if (!account.Exists(u => u.Login == TB_login1.Text))
                    {
                        singliton_user _User = singliton_user.GetInstance();

                        User user_1 = new User { Firstname = TB_Firstname.Text, Lastname = TB_Lastname.Text };
                        _User.Create(user_1);
                        //  db.Companies.AddRange(c1, c2);

                        Account ac1 = new Account { Login = TB_login1.Text, Password = TB_pass1.Text };
                        singliton_account _Account = singliton_account.GetInstance();
                        _Account.Create(ac1);


                        ctx.SaveChanges();
                        this.DialogResult = true;
                        this.Close();

                    }

                    else
                    {
                        MessageBox.Show("Логин занят!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Поля не заполнены!");
            }
                    }
                }
            }

    
