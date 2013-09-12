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

namespace SP_UIL.Course
{
    /// <summary>
    /// Interaction logic for CourseAdd.xaml
    /// </summary>
    public partial class CourseAdd : UserControl
    {
        public CourseAdd()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
             Err ee =  sp_bll.Course.add(new tbl_course { C_Num = tb_id.Text , C_Name = tb_name.Text , C_Course = tb_describe.Text });
        }
    }
}
