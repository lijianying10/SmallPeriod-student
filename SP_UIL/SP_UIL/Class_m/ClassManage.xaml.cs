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

namespace SP_UIL.Class_m
{
    /// <summary>
    /// Interaction logic for ClassManage.xaml
    /// </summary>
    ///     
    public class ui_Class
    {
        public bool Delete { get; set; }
        public bool Update { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public partial class ClassManage : UserControl
    {
        public static ObservableCollection<ui_Class> tablebefore;
        public ClassManage()
        {
            InitializeComponent();
            loadtable();
        }

        public void loadtable()
        {
            ObservableCollection<ui_Class> custdata = GetData();
            dg_class.DataContext = custdata;
            tablebefore = new ObservableCollection<ui_Class>();
            foreach (var item in custdata)
            {
                tablebefore.Add(item);
            }
        }

        private ObservableCollection<ui_Class> GetData()
        {
            var student = new ObservableCollection<ui_Class>();
            List<tbl_class> class_list = obj_Class.get_all();
            foreach (tbl_class single_class in class_list)
            {
                student.Add(new ui_Class { Delete = false, Update = false, ID = single_class.cl_ID,Name = single_class.cl_Name });
            }
            return student;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ObservableCollection<ui_Class> custdata;
            custdata = (ObservableCollection<ui_Class>)dg_class.DataContext;
            int i = 0;

            foreach (ui_Class uu in custdata)
            {
                if (uu.Update == true)
                {
                    tbl_class cccc = obj_Class.get_single_class(tablebefore[i].ID);
                    cccc.cl_ID = uu.ID;
                    cccc.cl_Name = uu.Name;
                    Err eeee = obj_Class.update(cccc);
                }
                if (uu.Delete == true)
                {
                    obj_Class.delete(obj_Class.get_single_class(uu.ID));
                }
                i++;
            }
            loadtable();
        }
    }
}
