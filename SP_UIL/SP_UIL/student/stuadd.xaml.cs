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
using sp_bll;
using sp_dal;

namespace SP_UIL.student
{
    /// <summary>
    /// Interaction logic for stuadd.xaml
    /// </summary>
    public partial class stuadd : UserControl
    {
        public stuadd()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string faileddata = "";
                string data = tb_student.Text;
                data = data.Replace("\r\n", "\n");
                string[] students = data.Split('\n');
                foreach (var student in students)
                {
                    string[] atts = student.Split(',');
                    tbl_student ss = new tbl_student();
                    ss.S_Num = atts[0];
                    ss.S_Name = atts[1];
                    ss.S_Gender = atts[2];
                    ss.S_Birthday=Convert.ToDateTime(atts[3]);
                    ss.S_Department=atts[4];
                    ss.S_ClassID=  obj_Class.get_classid(atts[5]);
                    Err eee =  Student.add(ss);
                    if (eee.res == false)
                    {
                        faileddata += student+"\n";
                    }
                }
                ModernDialog.ShowMessage("then the box will show the add failed student", "Operation finished", MessageBoxButton.OK);
                tb_student.Text = faileddata;
            }
            catch(Exception ex)
            {
                ModernDialog.ShowMessage("Input data error" + MainWindow.loginuser.U_Power, "Input error", MessageBoxButton.OK);
            }

        }
    }
}
