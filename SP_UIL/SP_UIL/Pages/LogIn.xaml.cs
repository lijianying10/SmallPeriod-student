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
using FirstFloor.ModernUI.Windows.Controls;
using sp_bll;
using sp_dal;

namespace SP_UIL.Pages
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : UserControl
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btn_login_Click_1(object sender, RoutedEventArgs e)
        {
            //new ModernDialog
            //{
            //    Title = "Common dialog",
            //    Content = new Home()
            //}.ShowDialog();
            Err err =  User.login(tb_id.Text,pb_pwd.Password);
            if (err.res == true)
            {
                MainWindow.is_loged_in = true;
                MainWindow.loginuser = User.get_single_user(tb_id.Text);
                ModernDialog.ShowMessage("Login success user name " + tb_id.Text + " user power " + MainWindow.loginuser.U_Power, "LogIn status", MessageBoxButton.OK);
                BBCodeBlock bb = new BBCodeBlock();

            }
            else
            {
                ModernDialog.ShowMessage("Login failed\ncause of "+err.info, "LogIn status", MessageBoxButton.OK);
                this.tb_id.Text = "";
                this.pb_pwd.Password = "";
            }
        }
    }
}
