using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sp_bll;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Err e = User.login("5","2");
            Console.WriteLine(e.info);
        }
    }
}
