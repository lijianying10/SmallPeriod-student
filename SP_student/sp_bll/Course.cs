using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sp_dal;

namespace sp_bll
{
    /// <summary>
    /// mapping for object tbl_course
    /// </summary>
    public static class Course
    {

        public static List<tbl_course> get_all()
        {
            DataBase db = new DataBase();
            return db.tbl_course.ToList();
        }

        public static Err add(tbl_course cc)
        {
            Err e = new Err();
            try
            {
                DataBase db = new DataBase();
                db.tbl_course.AddObject(cc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
            }
            return e;
        }

        public static Err update(tbl_course cc)
        {
            Err e = new Err();
            try
            {
                DataBase db = new DataBase();
                tbl_course c = (
                    from d in db.tbl_course
                    where d.C_index == cc.C_index
                    select d
                    ).Single();
                c = cc;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
            }
            return e;
        }

        public static Err delete(tbl_course cc)
        {
            Err e = new Err();
            try
            {
                DataBase db = new DataBase();
                db.DeleteObject(cc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
            }
            return e;
        }


        private static int searchParameter(string data)
        {
            if (data == "")
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public static List<tbl_course> search(string keyword,ref Err e)
        {
            try
            {
                using (var db = new DataBase())
                {
                    List<tbl_course> result = new List<tbl_course>();
                    result.AddRange((
                        from d in db.tbl_course
                        where d.C_Num.IndexOf(keyword)>=0
                        orderby d.C_Num
                        select d
                        ).ToList());
                    result.AddRange((
                    from d in db.tbl_course
                    where d.C_Name.IndexOf(keyword) >= 0
                    orderby d.C_Num
                    select d
                    ).ToList());
                   result.AddRange((
                    from d in db.tbl_course
                    where d.C_Course.IndexOf(keyword) >= 0
                    orderby d.C_Num
                    select d
                    ).ToList());
                   
                    return result;
                }
                
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
                return null;
            }
        }

        public static tbl_course get_single_course(string id)
        {
            try
            {
                using (var db = new DataBase())
                {
                    return (
                        from d in db.tbl_course
                        where d.C_Num == id
                        select d
                        ).Single();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
