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
using System.Collections.ObjectModel;
using FirstFloor.ModernUI.Windows.Controls;
//TODO fix name can't be show and can't update
namespace SP_UIL.student
{
    /// <summary>
    /// Interaction logic for studentmanage.xaml
    /// </summary>
    public class ui_student
    {
        public bool Delete { get; set; }
        public bool Update { get; set; }
        public string Num { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Department { get; set; }
        public string className { get; set; }
    }

    public partial class studentmanage : UserControl
    {
        ObservableCollection<ui_student> tablebefore;
        public studentmanage()
        {
            InitializeComponent();
            loadtable();
        }

        public void loadtable()
        {
            ObservableCollection<ui_student> custdata = GetData();
            dg_student.DataContext = custdata;
            tablebefore = new ObservableCollection<ui_student>();
            foreach (var item in custdata)
            {
                tablebefore.Add(item);
            }
        }

        private ObservableCollection<ui_student> GetData()
        {
            var student = new ObservableCollection<ui_student>();
            List<tbl_student> student_list = Student.get_all();
            foreach (tbl_student single_student in student_list)
            {
                student.Add(new ui_student { Delete = false, Update = false, Num = single_student.S_Num, Gender = single_student.S_Gender, Birthday = single_student.S_Birthday.Date.ToShortDateString(), Department = single_student.S_Department, className = obj_Class.get_className(single_student.S_ClassID) });
            }
            return student;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Err ee = new Err();
            
            ObservableCollection<ui_student> collection = new ObservableCollection<ui_student>();

            List<tbl_student> student_list = Student.search(tb_condation.Text, ref ee);
            //string[] class_ids = obj_Class.get_classids(tb_condation.Text);
            //foreach (string class_id in class_ids)
            //{
            //    student_list.AddRange(Student.search_student_by_id(class_id));
            //}

            foreach (tbl_student single_student in student_list)
            {
                collection.Add(new ui_student { Delete = false, Update = false, Num = single_student.S_Num,Name = single_student.S_Name, Gender = single_student.S_Gender, Birthday = single_student.S_Birthday.Date.ToShortDateString(), Department = single_student.S_Department, className = obj_Class.get_className(single_student.S_ClassID) });
            }
            tablebefore = new ObservableCollection<ui_student>();
            foreach (var item in collection)
            {
                tablebefore.Add(item);
            }
            dg_student.DataContext = collection;
        }

        private void btn_submit_Click_1(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ui_student> custdata;
            custdata = (ObservableCollection<ui_student>)dg_student.DataContext;
            int i = 0;
            foreach (ui_student ss in custdata)
            {
                if (ss.Delete == true)
                {
                    Student.delete(Student.get_single_student(ss.Num));
                }
                if (ss.Update == true)
                {
                    tbl_student student_update = Student.get_single_student(tablebefore[i].Num);
                    try
                    {
                        student_update.S_Num = ss.Num;
                        student_update.S_Name = ss.Name;
                        student_update.S_Gender = ss.Gender;
                        student_update.S_Birthday = Convert.ToDateTime(ss.Birthday);
                        student_update.S_Department = ss.Department;
                        student_update.S_ClassID = obj_Class.get_classid(ss.className);
                    }
                    catch (Exception ex)
                    {
                        ModernDialog.ShowMessage("Some important data may be change unsuccessful \nsystem message:"+ ex.Message  + MainWindow.loginuser.U_Power, "User Input ERROR", MessageBoxButton.OK);
                    }
                    Student.update(student_update);
                }
                i++;
            }
            loadtable();
        }
    }
}
