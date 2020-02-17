using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.DAL;

namespace SchoolManagementSystem.Bll
{
   public class Web_Teacher_bll
    {

       public DataTable TeacherClassesOnload(String TeacherId)
       {
           DataTable dt = new DataTable();
           Web_Teacher_dal dal=new Web_Teacher_dal();
           dt = dal.TeacherClassesOnload(TeacherId);
           return dt;
       }


    }
}
