using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.DAL
{
   public class Connections
    {

       public static String AddStudentConnection()
       {
           String con = "Data Source=.; DataBase=School;Integrated Security=true;";

          // String con = "Data Source=SQL5009.Smarterasp.net;Initial Catalog=DB_9D556E_school;User Id=DB_9D556E_school_admin;Password=abcd1234;";
               return con;

       }


    }
}
