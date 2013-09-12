using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using sp_dal;
using sp_bll;

namespace SP_UIL.system
{
    public enum OrderStatus { Super_user,User };
    public class ui_user
    {
        public bool Delete { get; set; }
        public bool Updata { get; set; }
        public string ID { get; set; }
        public string password { get; set; }
        public OrderStatus power { get; set; }
    }
    /// <summary>
    /// Interaction logic for user_manage.xaml
    /// </summary>
    public partial class user_manage : UserControl
    {

        private ObservableCollection<ui_user> TableBefore;

        public user_manage()
        {
            InitializeComponent();
            loadtable();
        }

        public void loadtable()
        {
            ObservableCollection<ui_user> custdata = GetData();
            dg_user.DataContext = custdata;
            TableBefore = new ObservableCollection<ui_user>();
            foreach (var item in custdata)//add each data to tablebefore
            {
                TableBefore.Add(item);
            }
        }

        private ObservableCollection<ui_user> GetData()
        {
            var users = new ObservableCollection<ui_user>();
            List<tbl_user> user_list = User.get_all();
            foreach(tbl_user single_user in user_list)
            {
                users.Add(new ui_user {Delete=false,Updata=false,ID=single_user.U_ID,password = single_user.U_PWD,power = OrderStatus.Super_user -1 + single_user.U_Power });
            }
            return users;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ui_user> custdata;
            custdata = (ObservableCollection<ui_user>)dg_user.DataContext;

            int i = 0;

            foreach (ui_user uu in custdata)
            {
                if (uu.Updata == false)
                {
                    tbl_user user = User.get_single_user(TableBefore[i].ID);
                    user.U_ID = uu.ID;
                    user.U_PWD = uu.password;
                    user.U_Power = Convert.ToInt32(uu.power+1);
                     Err eeee =  User.update(user);
                }
                if (uu.Delete == true)
                {
                    User.delete(User.get_single_user(uu.ID));
                }
                i++;
            }
            loadtable();
        }

    }
}
