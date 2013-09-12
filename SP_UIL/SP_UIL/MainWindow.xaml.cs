using FirstFloor.ModernUI.Windows.Controls;
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
using sp_dal;
using sp_bll;

namespace SP_UIL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {

        #region globalSession
        public static bool is_loged_in;
        public static tbl_user loginuser;
        #endregion



        public MainWindow()
        {
            InitializeComponent();
            is_loged_in = false;
            //debug code
            //is_loged_in = true;
            //loginuser = User.get_single_user("1");
        }
    }
}
