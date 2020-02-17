using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.DAL
{
    public class Web_Student_dal
    {


        public DataTable StudentClassesOnload(String StudentId)
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            DataTable Class = new DataTable();

            String query = "select DISTINCT Class.className,ExamMarks.ClassId from ExamMarks INNER JOIN Class on ExamMarks.ClassId=Class.classId where ExamMarks.Studentid='" + StudentId + "' ";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);

            dap.Fill(Class);
            con.Close();



            return Class;

        }

        public DataTable ShowResults(int Class,int term,String StudentId )
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());
            String Mainquery = "select ExamMarks.Studentid,ExamMarks.StudentName,ExamMarks.Term,ExamMarks.Sub1,ExamMarks.Sub2,ExamMarks.Sub3,ExamMarks.Sub4,ExamMarks.Sub5,ExamMarks.Sub6,ExamMarks.Sub7,ExamMarks.Sub8,ExamMarks.ObtainedMarks,ExamMarks.TotalMarks,ExamMarks.Percentage,ExamMarks.Grade,ExamMarks.PromotedStatus,Class.className,Class.classId from ExamMarks INNER JOIN Class ON ExamMarks.ClassId=Class.classId   where ExamMarks.ClassId='" + Class + "' and Term='" + term + "' and ExamMarks.Studentid='" + StudentId + "' ORDER BY ExamMarks.Studentid ASC";
            DataTable maindt = new DataTable();
            SqlCommand mainCom = new SqlCommand(Mainquery, con);
            con.Open();
            mainCom.ExecuteNonQuery();
            SqlDataAdapter maindap = new SqlDataAdapter(mainCom);
            maindap.Fill(maindt);
            maindt.Columns.Add(new DataColumn("New_Stu_Id", Type.GetType("System.String")));

            for (int i = 0; i < maindt.Rows.Count; i++)
            {
                maindt.Rows[i]["New_Stu_Id"] = i + 1;
            }

            String subject = "select Name,Sum(SubjectMarks)As Marks from Subject where ClassId='" + Class + "' Group by Name";
            DataTable getsubject = new DataTable();




            SqlCommand comsubject = new SqlCommand(subject, con);
            comsubject.ExecuteNonQuery();
            SqlDataAdapter comdap = new SqlDataAdapter(comsubject);
            comdap.Fill(getsubject);


            int TotalSubjects = getsubject.Rows.Count;



            for (int i = 0; i < getsubject.Rows.Count; i++)
            {
                System.Data.DataColumn newColumni = new System.Data.DataColumn("S" + i, typeof(System.String));

                if (getsubject.Rows[i][0].ToString() == "")
                {
                    newColumni.DefaultValue = "Empty";

                }
                else
                {
                    newColumni.DefaultValue = getsubject.Rows[i][0].ToString();

                }
                maindt.Columns.Add(newColumni);

            }

            System.Data.DataColumn TotalSubject = new System.Data.DataColumn("TotalSubject", typeof(System.String));
            TotalSubject.DefaultValue = getsubject.Rows.Count;
            maindt.Columns.Add(TotalSubject);



            int TotalMarks = 0;
            System.Data.DataColumn TotalSubjectMarks = new System.Data.DataColumn("TotalSubjectMarks", typeof(System.String));
            for (int i = 0; i < getsubject.Rows.Count; i++)
            {
                TotalMarks = TotalMarks + Convert.ToInt32(getsubject.Rows[i]["Marks"].ToString());


            }
            TotalSubjectMarks.DefaultValue = TotalMarks;

            maindt.Columns.Add(TotalSubjectMarks);


            con.Close();

            return maindt;

        }


    }
}
