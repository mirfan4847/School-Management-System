using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.DAL;
namespace SchoolManagementSystem.Bll
{
  public  class Web_Student_bll
    {
      public DataTable StudentClassesOnload(String StudentId)
      {

          DataTable dt = new DataTable();
          Web_Student_dal dal=new Web_Student_dal();
          dt = dal.StudentClassesOnload(StudentId);

          return dt;

      }

      public DataTable ShowResults(int Class,int term,String StudentId)
      {
          DataTable dt = new DataTable();
          Web_Student_dal dal = new Web_Student_dal();
          dt = dal.ShowResults(Class,term,StudentId);

          return dt;


      }

    }
}
