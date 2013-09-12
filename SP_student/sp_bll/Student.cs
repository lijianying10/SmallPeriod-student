using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using sp_dal;

namespace sp_bll
{
    /// <summary>
    /// mapping for object tbl_student
    /// </summary>
    public static  class Student
    {

        /// <summary>
        /// add a student to database
        /// </summary>
        /// <param name="ss">input student</param>
        /// <returns>error information</returns>
        public static Err add(tbl_student ss)
        {
            Err e = new Err();
            try
            {
                var db = new DataBase();
                db.tbl_student.AddObject(ss);
                db.SaveChanges();
                return e;
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
                return e;
            }
        }

        /// <summary>
        /// update a student information
        /// </summary>
        /// <param name="ss">input a student object</param>
        /// <returns>error information</returns>
        public static Err update(tbl_student ss)
        {
            Err e = new Err();
            try
            {
                var db = new DataBase();
                var before = (from d in db.tbl_student
                              where d.S_index == ss.S_index
                              select d).Single();
                before = ss;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
            }
            return e;
        }

        /// <summary>
        /// delete a object
        /// </summary>
        /// <param name="ss">input a student</param>
        /// <returns>error information</returns>
        public static Err delete(tbl_student ss)
        {
            Err e = new Err();
            try
            {
                var db = new DataBase();
                var before = (from d in db.tbl_student
                              where d.S_index == ss.S_index
                              select d).Single();
                db.DeleteObject(before);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
            }
            return e;
        }

        /// <summary>
        /// get all student
        /// </summary>
        /// <returns>return tbl_student </returns>
        public static List<tbl_student> get_all()
        {
            DataBase db = new DataBase();
            return db.tbl_student.ToList();
        }


        /// <summary>
        /// search student information
        /// </summary>
        /// <param name="query">query string </param>
        /// <param name="e">reference variable use for return query error information</param>
        /// <returns>query result</returns>
        /// 
        public static List<tbl_student> search(string keywords,ref Err e)
        {
            //todo judge query exist
            try
            {
                DataBase db = new DataBase();
                List<tbl_student> result = new List<tbl_student>();
                result.AddRange( (
                    from d in db.tbl_student
                    where d.S_Num.IndexOf(keywords) >=0
                    orderby d.S_index
                    select d
                    ).ToList());
                result.AddRange((
                    from d in db.tbl_student
                    where d.S_Name.IndexOf(keywords) >= 0
                    orderby d.S_index
                    select d
                    ).ToList());
                result.AddRange((
                    from d in db.tbl_student
                    where d.S_Gender.IndexOf(keywords) >= 0
                    orderby d.S_index
                    select d
                    ).ToList());
                result.AddRange((
                    from d in db.tbl_student
                    where d.S_Department.IndexOf(keywords) >= 0
                    orderby d.S_index
                    select d
                    ).ToList());
                return result;
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
                return null;
            }

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

        public static List<tbl_student> searchtime(
            DateTime birthday_start,
            DateTime birthday_end,
            ref Err e)
        {
            //todo judge query exist
            try
            {
                DataBase db = new DataBase();
                var q = from d in db.tbl_student
                        where d.S_Birthday >= birthday_start && d.S_Birthday <= birthday_end
                        orderby d.S_index
                        select d;
                return q.ToList();
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
                return null;
            }

        }

        public static List<tbl_student> search_student_by_id(string class_id)
        {
            try
            {
                using (var db = new DataBase())
                {
                    return (
                        from d in db.tbl_student
                        where d.S_ClassID == class_id
                        select d
                        ).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static tbl_student get_single_student(string id)
        {
            try
            {
                return (
                    from d in (new DataBase()).tbl_student
                    where d.S_Num == id
                    select d
                    ).Single();
            }
            catch (Exception ex)
            { 
                return null;
            }
        }
    }
}
