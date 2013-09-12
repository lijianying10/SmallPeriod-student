using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using sp_dal;

namespace sp_bll
{
    /// <summary>
    /// mapping for objcet tbl_class 
    /// </summary>
    public static class obj_Class
    {

        #region get_all
        /// <summary>
        /// direct invoke this api and U will get all class information in list
        /// </summary>
        /// <returns>return class list</returns>
        public static List<tbl_class> get_all()
        {
            DataBase db = new DataBase();
            return db.tbl_class.ToList();
        }
        #endregion

        #region add_class
        /// <summary>
        /// add a class object to database
        /// </summary>
        /// <param name="objclass">input class object</param>
        /// <returns>error information</returns>
        public static Err add(tbl_class objclass)
        {
            Err e = new Err();
            try
            {
                var db = new DataBase();
                db.tbl_class.AddObject(objclass);
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
        #endregion

        #region update
        /// <summary>
        /// update class information
        /// pay attention to that only attribute named cl_name can be change
        /// </summary>
        /// <param name="objclass">class object input</param>
        /// <returns>error information</returns>
        public static Err update(tbl_class objclass)
        {
            Err e = new Err();
            try
            {
                var db = new DataBase();
                tbl_class before = (from d in db.tbl_class
                                   where d.cl_ID == objclass.cl_ID
                                   select d).Single();
                before.cl_Name = objclass.cl_Name;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
            }
            return e;
        }
        #endregion

        #region delete
        /// <summary>
        /// delete a class 
        /// </summary>
        /// <param name="objclass">insert a class</param>
        /// <returns>error information</returns>
        public static Err delete(tbl_class objclass)
        {
            Err e = new Err();
            try
            {
                var db = new DataBase();
                tbl_class before = (from d in db.tbl_class
                                    where d.cl_ID == objclass.cl_ID
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
        #endregion

        public static string get_classid(string class_name)
        {
            try { 
                using(var db = new DataBase())
                {
                    return (
                        from d in db.tbl_class
                        where d.cl_Name == class_name
                        select d
                        ).Single().cl_ID;
                }
            }
            catch(Exception ex)
            {
                return "not exists";
            }
        }

        public static string get_className(string class_id)
        {
            try
            {
                using (var db = new DataBase())
                {
                    return (
                        from d in db.tbl_class
                        where d.cl_ID == class_id
                        select d
                        ).Single().cl_Name;
                }
            }
            catch (Exception ex)
            {
                return "not exists";
            }
        }

        public static string[] get_classids(string class_name)
        {
            try
            {
                using (var db = new DataBase())
                {
                    List<tbl_class> ccc = (
                        from d in db.tbl_class
                        where d.cl_Name.IndexOf(class_name) >= 0
                        select d
                        ).ToList();
                    List<string> res = new List<string>();
                    foreach (var c in ccc)
                    {
                        res.Add(c.cl_ID);
                    }
                    return res.ToArray();
                }
               
            }
            catch (Exception ex)
            {
                return new string[]{"not exists",""};
            }
        }

        public static tbl_class get_single_class(string class_id)
        {
            try
            {
                using (var db = new DataBase())
                {
                    return (
                        from d in db.tbl_class
                        where d.cl_ID == class_id
                        select d
                        ).Single();
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #region other
        
        #endregion

    }
}
