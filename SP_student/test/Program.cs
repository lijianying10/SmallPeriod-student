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

        
    }
}
