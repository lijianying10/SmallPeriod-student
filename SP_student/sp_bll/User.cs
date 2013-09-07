using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sp_dal;

namespace sp_bll
{
    /// <summary>
    /// mapping for object tbl_user
    /// implementation the bussiness part of object user
    /// </summary>
    public static class User
    {


        #region get_all_user
        /// <summary>
        /// this function implemtation get all user
        /// 
        /// 1. connect to database by entity framework
        /// 2. get all data from entity frmework
        /// </summary>
        /// <returns>List<tbl_user> the list of object tbl_user</returns>
        public static List<tbl_user> get_all()
        {

            DataBase db = new DataBase();
            return db.tbl_user.ToList();
        }
        #endregion

        #region add_user
        /// <summary>
        /// add a new user
        /// </summary>
        /// <param name="user">object tbl_user</param>
        /// <returns>error information</returns>
        public static Err add(tbl_user user)
        {
            Err e = new Err();
            try
            {
                var db = new DataBase();
                db.tbl_user.AddObject(user);
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
        /// change user information(not include index!!!!)
        /// 
        /// 1. connecting to database
        /// 2. find the object befor information
        /// 3. change the value of the object
        /// 4. save change in database
        /// </summary>
        /// <param name="user">input user information</param>
        /// <returns>error information</returns>
        public static Err update(tbl_user user)
        {
            Err e = new Err();
            try
            {
                var db = new DataBase();
                var before = (from d in db.tbl_user
                                where d.U_index == user.U_index
                                select d).Single();
                before.U_ID = user.U_ID;
                before.U_Power = user.U_Power;
                before.U_PWD = user.U_PWD;
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
        /// delete a user
        /// 
        /// 1.connect to database
        /// 2.reget the user from database
        /// 3.save database change
        /// </summary>
        /// <param name="user">input user</param>
        /// <returns>error information</returns>
        public static Err delete(tbl_user user)
        {
            Err e = new Err();
            try
            {
                var db = new DataBase();
                tbl_user deleteuser = (from d in db.tbl_user
                                       where d.U_ID == user.U_ID
                                       select d).Single();
                db.DeleteObject(deleteuser);
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

        #region login
        /// <summary>
        /// judge the id and passwd wheather correct 
        /// 
        /// 1. query the id passwd
        /// 2. id exists
        /// 3. passws whether correct
        /// </summary>
        /// <param name="ID">input ID</param>
        /// <param name="PWD">input password</param>
        /// <returns></returns>
        public static Err login(string ID, string PWD)
        {
            Err e = new Err();
            try
            {
                var db = new DataBase();
                var vu = from data in db.tbl_user
                        where data.U_ID == ID
                        select data;
                //bug: ID exist
                if (vu.Count() == 0)
                {
                    e.res = false;
                    e.info = "ID not exists";
                    return e;
                }
                tbl_user u = vu.Single();
                if (PWD == u.U_PWD)
                {
                    return e;
                }
                else
                {
                    e.res = false;
                    e.info = "Passwd error";
                }
            }
            catch (Exception ex)
            {
                e.res = false;
                e.info = ex.Message;
            }
            return e;
        }
        #endregion

    }
}
