using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.DAL
{
   public class Web_Teacher_dal
    {
       public DataTable TeacherClassesOnload(String TeacherId)
       {

           SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

           DataTable Class = new DataTable();

           String query = "select DISTINCT Class.className,classId from Class  where Class.teacherId='" + TeacherId + "' ";

           SqlCommand cmd = new SqlCommand(query, con);

           con.Open();
           SqlDataAdapter dap = new SqlDataAdapter(cmd);

           dap.Fill(Class);
           con.Close();



           return Class;





       }
    }
}
