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

namespace SP_UIL.system
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : UserControl
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            if (MainWindow.is_loged_in == false)
            {
                ModernDialog.ShowMessage("you did not login please login first","Login status error",MessageBoxButton.OK);
                return;
            }
            if (MainWindow.loginuser.U_Power > 1)
            {
                ModernDialog.ShowMessage("You are not in manager group you have no right to do that", "User group error", MessageBoxButton.OK);
                return;
            }

            if (tb_uid.Text == "" || tb_pwd.Text == "" || cb_group.SelectedIndex == -1)
            {
                ModernDialog.ShowMessage("the input data can't be NULL", "Input data error", MessageBoxButton.OK);
                return;
            }

            if (User.get_single_user(tb_uid.Text) != null)
            {
                ModernDialog.ShowMessage("User exist", "User data error ", MessageBoxButton.OK);
                return;
            }

            tbl_user u = new tbl_user();
            u.U_ID = tb_uid.Text;
            u.U_PWD = tb_pwd.Text;
            u.U_Power = cb_group.SelectedIndex + 1;
            User.add(u);

            ModernDialog.ShowMessage("User add successful", "Message", MessageBoxButton.OK);

            tb_uid.Text = "";
            tb_pwd.Text = "";
            cb_group.SelectedIndex = -1;
            
            return;



        }
    }
}
