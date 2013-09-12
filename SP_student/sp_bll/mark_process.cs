using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sp_dal;
using System.IO;

namespace sp_bll
{
    public static class mark_process
    {

        public static Err mark_delete(v_mark vv)
        {
            Err e = new Err();
            try
            {
                using (var db = new DataBase())
                {
                    tbl_stu_mark tsm = (
                        from d in db.tbl_stu_mark
                        where d.mk_index == vv.mk_index
                        select d
                        ).Single();
                    db.tbl_stu_mark.DeleteObject(tsm);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
            }
            return e;
        }

        public static Err mark_update(v_mark vv)
        {
            Err e = new Err();
            try
            {
                using (var db = new DataBase())
                {
                    tbl_stu_mark tsm = (
                        from d in db.tbl_stu_mark
                        where d.mk_index == vv.mk_index
                        select d
                        ).Single();
                    tsm.mk_mark = vv.mk_mark;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
            }
            return e;
        }

        public static List<v_mark> search(string keyword,ref Err e)
        {
            //search column stu_num s_name s_gender S_department C_name C_course cl_name
            try
            {
                #region access database
                using (var db = new DataBase())
                {
                    List<v_mark>[] res = new List<v_mark>[7];
                    res[0] = (from d in db.v_mark where d.stu_num.IndexOf(keyword) >= 0 select d).ToList();
                    res[1] = (from d in db.v_mark where d.S_Name.IndexOf(keyword) >= 0 select d).ToList();
                    res[2] = (from d in db.v_mark where d.S_Gender.IndexOf(keyword) >= 0 select d).ToList();
                    res[3] = (from d in db.v_mark where d.S_Department.IndexOf(keyword) >= 0 select d).ToList();
                    res[4] = (from d in db.v_mark where d.C_Name.IndexOf(keyword) >= 0 select d).ToList();
                    res[5] = (from d in db.v_mark where d.C_Course.IndexOf(keyword) >= 0 select d).ToList();
                    res[6] = (from d in db.v_mark where d.cl_Name.IndexOf(keyword) >= 0 select d).ToList();
                    List<v_mark> result = new List<v_mark>();
                    foreach (List<v_mark> single in res)
                    {
                        result.AddRange(single);
                    }
                    return result;
                }
                #endregion
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
                return null;
            }
        }

        public static Err analyse(string class_name,string path)
        {
            //search column stu_num s_name s_gender S_department C_name C_course cl_name
            Err e = new Err();
            try 
            {
                string class_id = (from d in (new DataBase()).tbl_class where d.cl_Name == class_name select d).Single().cl_ID;
                List<v_mark> vv = (from d in (new DataBase()).v_mark where d.cl_Name == class_name select d).ToList();
                string FileConst = "学号,姓名,性别,系别,课程名称,课程成绩,课程描述,班级名\n";
                foreach (v_mark v in vv)
                {
                    FileConst += v.stu_num + "," + v.S_Name + "," + v.S_Gender + "," + v.S_Department + "," + v.C_Name + ","+v.mk_mark+ "," + v.C_Course + "," + v.cl_Name+"\n";
                }
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("utf-8"));
                sw.Write(FileConst);
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
            }
            return e;
        }

        public static v_mark get_single(int index)
        {
            return (
                from d in (new DataBase()).v_mark
                where d.mk_index == index
                select d
                ).Single();
        }

        public static List<v_mark> get_all()
        {
            using (var db = new DataBase())
            {
                return db.v_mark.ToList();
            }
        }

        public static Err mark_update(int index,decimal new_mark)
        {
            Err e = new Err();
            try
            {
                using (var db = new DataBase())
                {
                    tbl_stu_mark tsm = (
                        from d in (new DataBase()).tbl_stu_mark
                        where d.mk_index == index
                        select d
                        ).Single();
                    tsm.mk_mark = new_mark;
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
            }
            return e;
        }
    }
}
