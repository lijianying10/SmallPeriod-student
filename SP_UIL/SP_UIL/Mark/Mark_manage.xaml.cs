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
using FirstFloor.ModernUI.Windows.Controls;
using System.Collections.ObjectModel;

namespace SP_UIL.Mark
{
    /// <summary>
    /// Interaction logic for Mark_manage.xaml
    /// </summary>
    public class ui_mark
    {
        //search column stu_num s_name s_gender S_department C_name C_course cl_name
        public bool Delete { get; set; }
        public bool Update { get; set; }
        public string stu_num { get; set; }
        public string s_name { get; set; }
        public string s_gender { get; set; }
        public string S_department { get; set; }
        public string C_name { get; set; }
        public string C_mark { get; set; }
        public string C_course { get; set; }
        public string cl_name { get; set; }
        public int mk_index { get; set; }
    }
    public partial class Mark_manage : UserControl
    {

        public ObservableCollection<ui_mark> tablebefore;

        public Mark_manage()
        {
            InitializeComponent();
            //initial combobox
            List<tbl_class> class_all = obj_Class.get_all();
            foreach (tbl_class c in class_all)
            {
                cb_class.Items.Add(new ComboBoxItem { Content = c.cl_Name });
                cb_class_Copy.Items.Add(new ComboBoxItem { Content = c.cl_Name });
            }
            loadtable();
        }

        public void loadtable()
        {
            ObservableCollection<ui_mark> custdata = GetData();
            dg_mark.DataContext = custdata;
            tablebefore = new ObservableCollection<ui_mark>();
            foreach (var item in custdata)
            {
                tablebefore.Add(item);
            }
        }

        private ObservableCollection<ui_mark> GetData()
        {
            var marks = new ObservableCollection<ui_mark>();
            List<v_mark> mark_list = sp_bll.mark_process.get_all();
            foreach (v_mark single_mark in mark_list)
            {
                marks.Add(new ui_mark { Delete = false, Update = false, 
                stu_num = single_mark.stu_num,
                s_name = single_mark.S_Name,
                s_gender = single_mark.S_Gender,
                S_department = single_mark.S_Department,
                C_name = single_mark.C_Name,
                C_mark = single_mark.mk_mark.ToString(),
                C_course = single_mark.C_Course,
                cl_name = single_mark.cl_Name,
                mk_index = single_mark.mk_index
                });
            }
            return marks;
        }

        private void btn_temp_output_Click_1(object sender, RoutedEventArgs e)
        {
            string selected_classname;
            try
            {
                ComboBoxItem cbbb = (ComboBoxItem)cb_class.SelectedItem;
                selected_classname = (string)cbbb.Content;
                string class_id = sp_bll.obj_Class.get_classid(selected_classname);
                
            }
            catch (Exception ex)
            {
                ModernDialog.ShowMessage(ex.Message,"No item selected",MessageBoxButton.OK);
                return;
            }
            System.Windows.Forms.SaveFileDialog ofd = new System.Windows.Forms.SaveFileDialog();
            
            ofd.ShowDialog();
            List<tbl_course> ccc=  sp_bll.Course.get_all();
            List<string> cn  = new List<string>();
            foreach(tbl_course c in ccc)
            {
                cn.Add(c.C_Name);
            }
            sp_bll.Mark.GetTemplate(ofd.FileName, selected_classname, cn.ToArray());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.ShowDialog();
            sp_bll.Mark.ReadTemplate(ofd.FileName);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ////search column stu_num s_name s_gender S_department C_name C_course cl_name
            Err ee = new Err();

            ObservableCollection<ui_mark> collection = new ObservableCollection<ui_mark>();

            List<v_mark> mark_list;
            if (tb_condation.Text == "")
            {
                mark_list = sp_bll.mark_process.get_all();
            }
            else
            {
                mark_list = sp_bll.mark_process.search(tb_condation.Text, ref ee);
            }

            foreach (v_mark single_mark in mark_list)
            {
                collection.Add(new ui_mark
                {
                    Delete = false,
                    Update = false,
                    stu_num = single_mark.stu_num,
                    s_name = single_mark.S_Name,
                    s_gender = single_mark.S_Gender,
                    S_department = single_mark.S_Department,
                    C_name = single_mark.C_Name,
                    C_mark = single_mark.mk_mark.ToString(),
                    C_course = single_mark.C_Course,
                    cl_name = single_mark.cl_Name,
                    mk_index = single_mark.mk_index
                });
            }
            tablebefore = new ObservableCollection<ui_mark>();
            foreach (var item in collection)
            {
                tablebefore.Add(item);
            }
            dg_mark.DataContext = collection;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//submit
        {
            
            ObservableCollection<ui_mark> custdata;
            custdata = (ObservableCollection<ui_mark>)dg_mark.DataContext;

            int i = 0;
            foreach (ui_mark ss in custdata)
            {
                if (ss.Delete == true)
                {
                    sp_bll.mark_process.mark_delete(sp_bll.mark_process.get_single(ss.mk_index));
                }
                if (ss.Update == true)
                {
                    //tbl_course course_update = sp_bll.Course.get_single_course(tablebefore[i].Num);
                    //try
                    //{
                    //    course_update.C_Num = ss.Num;
                    //    course_update.C_Name = ss.Name;
                    //    course_update.C_Course = ss.Describe;
                    //}
                    //catch (Exception ex)
                    //{
                    //    ModernDialog.ShowMessage("Some important data may be change unsuccessful \nsystem message:" + ex.Message + MainWindow.loginuser.U_Power, "User Input ERROR", MessageBoxButton.OK);
                    //}
                    //sp_bll.Course.update(course_update);
                    v_mark mark_update = sp_bll.mark_process.get_single(tablebefore[i].mk_index);
                    try
                    {
                        Err ee =  sp_bll.mark_process.mark_update(mark_update.mk_index, Convert.ToDecimal(ss.C_mark));
                    }
                    catch (Exception ex)
                    {
                        ModernDialog.ShowMessage(ex.Message,"ERROR",MessageBoxButton.OK);
                    }
                }
                i++;
            }
            loadtable();
        }

        private void btn_temp_output_Copy_Click_1(object sender, RoutedEventArgs e)//analyse
        {
            System.Windows.Forms.SaveFileDialog ofd = new System.Windows.Forms.SaveFileDialog();
            ofd.ShowDialog();
            string selected_classname;

            try
            {
                ComboBoxItem cbbb = (ComboBoxItem)cb_class_Copy.SelectedItem;
                selected_classname = (string)cbbb.Content;
                sp_bll.mark_process.analyse(selected_classname, ofd.FileName);
            }
            catch (Exception ex)
            {
                ModernDialog.ShowMessage(ex.Message, "Input ERROR", MessageBoxButton.OK);
            }
            
        }
    }
}
