using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sp_bll;
using sp_dal;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            //user_test();
            //class_test();

            //高级lamda表达式实现模糊查询indexof可以换成startwith或者endwith
            DataBase db = new DataBase();
            List<tbl_class> q = (from d in db.tbl_class
                                 where d.cl_Name.IndexOf("")>=-1
                                 where d.cl_ID.IndexOf("1")>=0
                                 orderby d.cl_index
                                 select d).ToList();

            //student_teset();

            //Mark.GetTemplate(@"C:\Users\jianYing\Desktop\template.csv","2班",new string[]{"课程1","2课程","课3程"});

            //Mark.ReadTemplate(@"C:\Users\jianYing\Desktop\template.csv");

            Err e = mark_process.analyse("2班", @"C:\Users\jianYing\Desktop\template2.csv");

            Console.WriteLine("just test");
        }

        static void user_test()
        {
            
            #region test login
            /*
             
             * judge： id exist
             * passwd exist
             
             */

            Err e = User.login("5","2");
            Console.WriteLine(e.info);
            #endregion

            #region user_add
            /*
             * input u_id
             * input u_pwd
             * input power //maybe power need add a default value
             */
            //List<tbl_user> ulist = User.get_all();
            //tbl_user single = new tbl_user();
            //single.U_PWD = "123456";
            //single.U_ID = "123456";
            //single.U_Power = 1;
            //User.add(single);
            #endregion

            #region user update
            /*
             * be attention that the u_id is the key value can't be change
             * 1.get target value and change value 
             * 2.send the target object to API
             */

            //List<tbl_user> ulist = User.get_all();
            //ulist[2].U_PWD = "1234567";
            //User.update(ulist[2]);

            #endregion

            #region user delete
            // todo bug can't delete user in tbl_user
            //bug fixed by reget the user object
            
            /*
             * send the user object to API
             * 
             */
            //List<tbl_user> ulist = User.get_all();
            //User.delete(ulist[2]);
            #endregion

        }

        static void class_test()
        {
            #region get all calss
            //List<tbl_class> c = obj_Class.get_all();
            //foreach (tbl_class single in c)
            //{
            //    Console.WriteLine(single.cl_Name);
            //}
            #endregion

            #region add class
            //tbl_class cc = new tbl_class();
            //cc.cl_Name = "6班";
            //cc.cl_ID = "0006";
            //obj_Class.add(cc);
            //Console.WriteLine("add success");
            #endregion

            #region delete class
            tbl_class cc = new tbl_class();
            cc.cl_Name = "6班";
            cc.cl_ID = "0006";
            obj_Class.delete(cc);
            Console.WriteLine("delete success");
            #endregion

            #region update class data
            //List<tbl_class> ccc = obj_Class.get_all();
            //ccc[2].cl_Name = "班级修改";
            //obj_Class.update(ccc[2]);
            #endregion


        }

        
    }
}
