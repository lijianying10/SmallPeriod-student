using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sp_dal;
using System.IO;

namespace sp_bll
{
    public static class Mark
    {
        #region API
        /// <summary>
        /// output a marktable template for input student mark
        /// </summary>
        /// <param name="File_path">output file path</param>
        /// <param name="couseName">array for course name input</param>
        /// <param name="ClassName">input class name</param>
        /// <returns>error information</returns>
        public static Err GetTemplate(string File_path, string ClassName,string[] couseName)
        {
            /*
             * table contain
             * stunumber studentname couse1 course2
             * number name NULL NULL
             * .........................
             * .........................
             */
            Err e = new Err();
            //start algothrem

            string header = "学号,姓名";
            foreach (string str in couseName)
            {
                header += ","+str;
            }
            header += ",";
            
            //get class id
            string classid = (from d in (new DataBase()).tbl_class where d.cl_Name == ClassName select d).Single().cl_ID;
            //get all student in calss
            List<tbl_student> stu = (from dd in (new DataBase()).tbl_student where dd.S_ClassID == classid select dd ).ToList();

            string FileCons = header + "\n";
            foreach (tbl_student student in stu)
            {
                FileCons += student.S_Num + "," + student.S_Name + ",\n";
            }

            FileStream fs = new FileStream(File_path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
            sw.Write(FileCons);
            sw.Close();
            fs.Close();
            //end alg
            return e;
        }

        /// <summary>
        /// read file input data to database
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>error information</returns>
        public static Err ReadTemplate(string path)
        {
            Err e = new Err();

            //data container
            string FileCon = "";

            //read file
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
                FileCon = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
            }

            FileCon = FileCon.Replace("\r\n", "\n");

            string[] lines = FileCon.Split('\n');//in windows os using \r\n split each line

            string[] courseNames = lines[0].Split(',');

            List<string> courses = new List<string>();//import variable for store courses 
            for (int a = 2; a < courseNames.Length; a++)
            {
                string coursename =  courseNames[a];//linq can't work with array (may be cause of index)
                courses.Add((from d in (new DataBase()).tbl_course where d.C_Name == coursename select d).Single().C_Num);
            }

            for (int a = 1; a < lines.Length; a++)
            {
                string[] cells = lines[a].Split(',');
                for (int c = 2; c < cells.Length; c++)
                {
                    using (var db = new DataBase())
                    {
                        tbl_stu_mark tsm = new tbl_stu_mark();
                        tsm.stu_num = cells[0];
                        tsm.cou_num = courses[c - 2];
                        tsm.mk_mark = Convert.ToDecimal(cells[c]);
                        db.tbl_stu_mark.AddObject(tsm);
                        db.SaveChanges();
                    }
                }
            }

                return e;
        }


        #endregion
    }
}
