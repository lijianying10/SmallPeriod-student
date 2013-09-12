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
using sp_bll;
using sp_dal;
using FirstFloor.ModernUI.Windows.Controls;

namespace SP_UIL.Course
{
    /// <summary>
    /// Interaction logic for CourManage.xaml
    /// </summary>
    public class ui_course
    {
        public bool Delete { get; set; }
        public bool Update { get; set; }
        public string Num { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
    }
    public partial class CourManage : UserControl
    {

        public static ObservableCollection<ui_course> tablebefore;

        public CourManage()
        {
            InitializeComponent();
            loadtable();
        }

        public void loadtable()
        {
            ObservableCollection<ui_course> custdata = GetData();
            dg_course.DataContext = custdata;
            tablebefore = new ObservableCollection<ui_course>();
            foreach (var item in custdata)
            {
                tablebefore.Add(item);
            }
        }

        private ObservableCollection<ui_course> GetData()
        {
            var student = new ObservableCollection<ui_course>();
            List<tbl_course> student_list = sp_bll.Course.get_all();
            foreach (tbl_course single_student in student_list)
            {
                student.Add(new ui_course { Delete = false, Update = false,Num = single_student.C_Num,Name = single_student.C_Name,Describe=single_student.C_Course});
            }
            return student;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Err ee = new Err();

            ObservableCollection<ui_course> collection = new ObservableCollection<ui_course>();

            List<tbl_course> student_list;
            if (tb_condation.Text == "")
            {
                student_list = sp_bll.Course.get_all();
            }
            else
            {
                student_list = sp_bll.Course.search(tb_condation.Text, ref ee);
            }

            foreach (tbl_course single_student in student_list)
            {
                collection.Add(new ui_course { Delete = false, Update = false, Num = single_student.C_Num, Name = single_student.C_Name, Describe = single_student.C_Course });
            }
            tablebefore = new ObservableCollection<ui_course>();
            foreach (var item in collection)
            {
                tablebefore.Add(item);
            }
            dg_course.DataContext = collection;
        }

        private void btn_submit_Click_1(object sender, RoutedEventArgs e)//todo : fix bug
        {
            ObservableCollection<ui_course> custdata;
            custdata = (ObservableCollection<ui_course>)dg_course.DataContext;

            int i = 0;
            foreach (ui_course ss in custdata)
            {
                if (ss.Delete == true)
                {
                    sp_bll.Course.delete(sp_bll.Course.get_single_course(ss.Num));
                }
                if (ss.Update == true)
                {
                    tbl_course course_update = sp_bll.Course.get_single_course(tablebefore[i].Num);
                    try
                    {
                        course_update.C_Num = ss.Num;
                        course_update.C_Name = ss.Name;
                        course_update.C_Course = ss.Describe;
                    }
                    catch (Exception ex)
                    {
                        ModernDialog.ShowMessage("Some important data may be change unsuccessful \nsystem message:" + ex.Message + MainWindow.loginuser.U_Power, "User Input ERROR", MessageBoxButton.OK);
                    }
                    sp_bll.Course.update(course_update);
                }
                i++;
            }
            loadtable();
        }
    }
}
