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
using sp_bll;
using sp_dal;
using FirstFloor.ModernUI.Windows.Controls;

namespace SP_UIL.Class_m
{
    /// <summary>
    /// Interaction logic for ClassAdd.xaml
    /// </summary>
    public partial class ClassAdd : UserControl
    {
        public ClassAdd()
        {
            InitializeComponent();
        }

        private void btn_submit_Click_1(object sender, RoutedEventArgs e)
        {
            tbl_class cc = new tbl_class();
            cc.cl_ID = tb_id.Text;
            cc.cl_Name = tb_class_name.Text;
            Err ee = obj_Class.add(cc);
            if (ee.res == false)
            {
                ModernDialog.ShowMessage(ee.info,"Input Error",MessageBoxButton.OK);
            }
            else
            {
                ModernDialog.ShowMessage(ee.info, "op success", MessageBoxButton.OK);
            }
        }
    }
}
