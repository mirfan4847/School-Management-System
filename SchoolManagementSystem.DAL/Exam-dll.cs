using SchoolManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.DAL
{
    public class Exam_dll
    {
        SqlConnection con = new SqlConnection(Connections.AddStudentConnection());
        SqlDataAdapter da;


        public DataTable getSection()
        {
            DataTable Section = new DataTable();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("select sectionId,sectionName from Section", con);
            da.Fill(Section);
            return Section;
        }
        public DataTable getClasses()
        {
            DataTable Classes = new DataTable();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("select classId,className from Class", con);
            da.Fill(Classes);
            return Classes;
        }

        //Muneeb Date Sheet
        public void insertGrades(DataTable dt)
        {
            DataTable result = new DataTable();
            string query = "Select Id from SetGrades";
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(query, con);
            da.Fill(result);
            if (result.Rows.Count < 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    query = "insert into SetGrades(GradeName,Percentage,Status) Values('" + dt.Rows[i]["GradeName"] + "','" + dt.Rows[i]["Percentage"] + "','" + dt.Rows[i]["Status"] + "')";
                    SqlCommand comm = new SqlCommand(query, con);
                    con.Open();
                    comm.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        public void insertDateSheetDll(Student st)
        {

         SqlCommand   cmd = new SqlCommand("spSaveDateSheet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@P1", st.xmlRecord));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable selectDateSheet(Student st)
        {
            DataTable dt = new DataTable();

            //for testing Datesheet table whether it has the datesheet for selected class or not

            da = new SqlDataAdapter();

            string query = "select * from DateSheet where DateSheet.Classid='" + st.classForDateSheet + "' and DateSheet.Term='" + st.termOfClass + "' ";
            da.SelectCommand = new SqlCommand(query, con);
            da.Fill(dt);
            if (dt.Rows.Count > 1)
            {
                DataTable dt1 = new DataTable();
                da = new SqlDataAdapter();
                //string query = "select Subject.id,Subject.Name,Subject.ClassId, DateSheet.Date, DateSheet.Subjectid,DateSheet.Start_Time,DateSheet.End_Time,DateSheet.Term,DateSheet.Classid from Subject INNER JOIN DateSheet ON Subject.ClassId=DateSheet.Classid where DateSheet.Classid='"+st.classForDateSheet+"' AND DateSheet.Term='"+st.termOfClass+"'  ";
                query = "select 0 AS ISUPDATE, DateSheet.id DateSheetId, DateSheet.Date, DateSheet.Subjectid,DateSheet.Start_Time,DateSheet.End_Time,DateSheet.Term,DateSheet.Classid,Subject.id SubId,Subject.Name,Subject.ClassId SubClassId from DateSheet INNER JOIN Subject ON Subject.id=DateSheet.Subjectid where DateSheet.Classid='" + st.classForDateSheet + "' AND DateSheet.Term='" + st.termOfClass + "' ";
                da.SelectCommand = new SqlCommand(query, con);

                da.Fill(dt1);
                //if (dt.Rows.Count < 1)
                //{
                //    DataTable dummyTable = new DataTable();
                //    dummyTable.Columns.Add("Sr");
                //    dummyTable.Columns.Add("Date");
                //    dummyTable.Columns.Add("Name");
                //    dummyTable.Columns.Add("Start_Time");
                //    dummyTable.Columns.Add("End_Time");
                //    dummyTable.Columns.Add("DateSheetId");
                //    dummyTable.Rows.Add("Enter Reocrd", "Enter Reocrd", "Enter Reocrd", "Enter Reocrd", "Enter Reocrd", "0");
                //    return dummyTable;
                //}
                //else
                //{
                dt1.Columns.Add(new DataColumn("Sr", Type.GetType("System.String")));
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    dt1.Rows[i]["Sr"] = i + 1;
                }
                return dt1;
                //}
            }
            else
            {
                DataTable dt2 = new DataTable();
                da = new SqlDataAdapter();
                //string query = "select Subject.id,Subject.Name,Subject.ClassId, DateSheet.Date, DateSheet.Subjectid,DateSheet.Start_Time,DateSheet.End_Time,DateSheet.Term,DateSheet.Classid from Subject INNER JOIN DateSheet ON Subject.ClassId=DateSheet.Classid where DateSheet.Classid='"+st.classForDateSheet+"' AND DateSheet.Term='"+st.termOfClass+"'  ";
                //query = " select 0 AS ISUPDATE, DateSheet.id DateSheetId, DateSheet.Date, DateSheet.Subjectid,DateSheet.Start_Time,DateSheet.End_Time,DateSheet.Term,DateSheet.Classid,Subject.id,Subject.Name,Subject.ClassId from DateSheet RIGHT OUTER JOIN Subject ON Subject.id=DateSheet.Subjectid where Subject.ClassId='" + st.classForDateSheet + "'";
                query = "select '0' AS ISNEW,'0' AS ISUPDATE,Subject.id,Subject.Name,Subject.ClassId as ClassId1 from Subject where ClassId='" + st.classForDateSheet + "'";
                da.SelectCommand = new SqlCommand(query, con);

                da.Fill(dt2);
                //if (dt.Rows.Count < 1)
                //{
                //    DataTable dummyTable = new DataTable();
                //    dummyTable.Columns.Add("Sr");
                //    dummyTable.Columns.Add("Date");
                //    dummyTable.Columns.Add("Name");
                //    dummyTable.Columns.Add("Start_Time");
                //    dummyTable.Columns.Add("End_Time");
                //    dummyTable.Columns.Add("DateSheetId");
                //    dummyTable.Rows.Add("Enter Reocrd", "Enter Reocrd", "Enter Reocrd", "Enter Reocrd", "Enter Reocrd", "0");
                //    return dummyTable;
                //}
                //else
                //{
                dt2.Columns.Add(new DataColumn("Sr", Type.GetType("System.String")));
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    dt2.Rows[i]["Sr"] = i + 1;
                }
                dt2.Columns.Add(new DataColumn("Terms", Type.GetType("System.String")));
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    dt2.Rows[i]["Terms"] = st.termOfClass;
                }
                dt2.Columns.Add(new DataColumn("DateSheetId", Type.GetType("System.String")));
                dt2.Columns.Add(new DataColumn("Date", Type.GetType("System.String")));
                dt2.Columns.Add(new DataColumn("Start_Time", Type.GetType("System.String")));
                dt2.Columns.Add(new DataColumn("End_Time", Type.GetType("System.String")));
                dt2.Columns.Add(new DataColumn("Classid", Type.GetType("System.String")));
                dt2.Columns.Add(new DataColumn("Term", Type.GetType("System.String")));
                dt2.Columns.Add(new DataColumn("Subjectid", Type.GetType("System.String")));



                //}
                return dt2;
            }


           
           




        }

        public DataTable setDateSheet(Student st)
        {
            da = new SqlDataAdapter();
            // string query = "select Subject.id,Subject.Name, DateSheet.Date, DateSheet.Subjectid,DateSheet.Start_Time,DateSheet.End_Time, Class.classId, Class.className from Subject INNER JOIN ";
            string query = "select Class.classId, Class.className from Class";
            da.SelectCommand = new SqlCommand(query, con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }
        public DataTable setSubjects(Student st)
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("select id,Name,SubjectMarks,'0' AS ISNEW,'0' AS ISUPDATE from Subject where classId='" + st.subject + "'", con);
            da.Fill(dt);


            dt.Columns.Add(new DataColumn("Sr", Type.GetType("System.String")));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Sr"] = i + 1;
            }

            dt.Columns.Add(new DataColumn("ClassId", Type.GetType("System.String")));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["ClassId"] = st.subject;
            }
            return dt;
        }





        //Muneeb Date Sheet



        public DataTable EnterMarks(String Class, String Section, int term)
        {


            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            DataTable Collection = new DataTable();

            String query = "select AddStudent.AdmissionId,AddStudent.Name,Class.className,Class.classId,Section.sectionName,Section.sectionId from AddStudent INNER JOIN Class ON AddStudent.Class=Class.classId INNER JOIN Section ON AddStudent.Section=Section.sectionId  where AddStudent.Class='" + Class + "' AND AddStudent.Section='" + Section + "'";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(Collection);



            for (int i = 0; i < Collection.Rows.Count; i++)
            {

                String duplicate = "select Studentid from  ExamMarks where Studentid='" + Collection.Rows[i]["AdmissionId"] + "' and Term='" + term + "' ";

                SqlCommand cmm = new SqlCommand(duplicate, con);
                cmm.ExecuteNonQuery();
                DataTable dtCheck = new DataTable();
                SqlDataAdapter daCheck = new SqlDataAdapter(cmm);
                daCheck.Fill(dtCheck);
                if (dtCheck.Rows.Count < 1)
                {
                    String query1 = "insert into ExamMarks(Studentid,classId,sectionId,Term,StudentName)values('" + Collection.Rows[i]["AdmissionId"] + "','" + Class + "','" + Section + "','" + term + "','" + Collection.Rows[i]["Name"] + "')";

                    SqlCommand com = new SqlCommand(query1, con);

                    com.ExecuteNonQuery();
                }

            }


            String Mainquery = "select  '0' AS ISNEW, '0' AS ISUPDATE,AddStudent.AdmissionId,AddStudent.Name,ExamMarks.Term,ExamMarks.Sub1,ExamMarks.Sub2,ExamMarks.Sub3,ExamMarks.Sub4,ExamMarks.Sub5,ExamMarks.Sub6,ExamMarks.Sub7,ExamMarks.Sub8,ExamMarks.ObtainedMarks,ExamMarks.TotalMarks,ExamMarks.Percentage,ExamMarks.Grade,ExamMarks.PromotedStatus,Class.className,Class.classId,Section.sectionName,Section.sectionId from  AddStudent INNER JOIN Class ON AddStudent.Class=Class.classId INNER JOIN Section ON AddStudent.Section=Section.sectionId FULL OUTER JOIN ExamMarks ON ExamMarks.Studentid=AddStudent.AdmissionId where AddStudent.Class='" + Class + "' AND AddStudent.Section='" + Section + "'and Term ='" + term + "' ORDER BY AddStudent.AdmissionId ASC ";

            DataTable maindt = new DataTable();
            SqlCommand mainCom = new SqlCommand(Mainquery, con);
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

            //getsubject.Columns.Add(new DataColumn("L0", Type.GetType("System.String")));
            //getsubject.Columns.Add(new DataColumn("L1", Type.GetType("System.String")));
            //getsubject.Columns.Add(new DataColumn("L2", Type.GetType("System.String")));
            //getsubject.Columns.Add(new DataColumn("L3", Type.GetType("System.String")));
            //getsubject.Columns.Add(new DataColumn("L4", Type.GetType("System.String")));
            //getsubject.Columns.Add(new DataColumn("L5", Type.GetType("System.String")));
            //getsubject.Columns.Add(new DataColumn("L6", Type.GetType("System.String")));
            //getsubject.Columns.Add(new DataColumn("L7", Type.GetType("System.String")));


            SqlCommand comsubject = new SqlCommand(subject, con);
            comsubject.ExecuteNonQuery();
            SqlDataAdapter comdap = new SqlDataAdapter(comsubject);
            comdap.Fill(getsubject);
            //getsubject.Rows[0][0]=getsubject.Rows[][]

            //maindt.Columns.Add(new DataColumn(getsubject.Rows[0][0].ToString(), Type.GetType("System.String")));
            //maindt.Columns[getsubject.Rows[0][0].ToString()].ColumnName = "S1";

            int TotalSubjects=getsubject.Rows.Count;

            

            for (int i = 0; i < getsubject.Rows.Count; i++)
            {
                System.Data.DataColumn newColumni = new System.Data.DataColumn("S"+i, typeof(System.String));

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



            int TotalMarks=0;
            System.Data.DataColumn TotalSubjectMarks = new System.Data.DataColumn("TotalSubjectMarks", typeof(System.String));
            for (int i = 0; i <  getsubject.Rows.Count; i++)
            {
                TotalMarks = TotalMarks + Convert.ToInt32(getsubject.Rows[i]["Marks"].ToString());

                
            }
            TotalSubjectMarks.DefaultValue = TotalMarks;

            maindt.Columns.Add(TotalSubjectMarks);



          
            //System.Data.DataColumn newColumn2 = new System.Data.DataColumn("S2", typeof(System.String));

            //if (getsubject.Rows[1][0].ToString() == "")
            //{
            //    newColumn2.DefaultValue = "Empty";

            //}
            //else
            //{
            //    newColumn2.DefaultValue = getsubject.Rows[1][0].ToString();

            //}
            //maindt.Columns.Add(newColumn2);





            //System.Data.DataColumn newColumn3 = new System.Data.DataColumn("S3", typeof(System.String));

            //if (getsubject.Rows[2][0].ToString() == "")
            //{
            //    newColumn3.DefaultValue = "Empty";

            //}
            //else
            //{
            //    newColumn3.DefaultValue = getsubject.Rows[2][0].ToString();

            //}
            //maindt.Columns.Add(newColumn3);



            //System.Data.DataColumn newColumn4 = new System.Data.DataColumn("S4", typeof(System.String));

            //if (getsubject.Rows[3][0].ToString() == "")
            //{
            //    newColumn4.DefaultValue = "Empty";

            //}
            //else
            //{
            //    newColumn4.DefaultValue = getsubject.Rows[3][0].ToString();

            //}
            //maindt.Columns.Add(newColumn4);






            //System.Data.DataColumn newColumn5 = new System.Data.DataColumn("S5", typeof(System.String));

            //if (getsubject.Rows[4][0].ToString() == "")
            //{
            //    newColumn5.DefaultValue = "Empty";

            //}
            //else
            //{
            //    newColumn5.DefaultValue = getsubject.Rows[4][0].ToString();

            //}
            //maindt.Columns.Add(newColumn5);



            //System.Data.DataColumn newColumn6 = new System.Data.DataColumn("S6", typeof(System.String));

            //if (getsubject.Rows[5][0].ToString() == "")
            //{
            //    newColumn6.DefaultValue = "Empty";

            //}
            //else
            //{
            //    newColumn6.DefaultValue = getsubject.Rows[5][0].ToString();

            //}
            //maindt.Columns.Add(newColumn6);






            //System.Data.DataColumn newColumn7 = new System.Data.DataColumn("S7", typeof(System.String));

            //if (getsubject.Rows[6][0].ToString() == "")
            //{
            //    newColumn7.DefaultValue = "Empty";

            //}
            //else
            //{
            //    newColumn7.DefaultValue = getsubject.Rows[6][0].ToString();

            //}
            //maindt.Columns.Add(newColumn7);




            //System.Data.DataColumn newColumn8 = new System.Data.DataColumn("S8", typeof(System.String));

            //if (getsubject.Rows[7][0].ToString() == "")
            //{
            //    newColumn8.DefaultValue = "Empty";

            //}
            //else
            //{
            //    newColumn8.DefaultValue = getsubject.Rows[7][0].ToString();

            //}
            //maindt.Columns.Add(newColumn8);





            con.Close();


            return maindt;

        }



        public void UpdateEnterMarks(DataTable dt)
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());


            dt.TableName = "MYTABLE";

            StringWriter sw = new StringWriter();
            dt.WriteXml(sw);

            String xml = sw.ToString();



            SqlCommand comm = new SqlCommand("spUpdateExams", con);

            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@P1", xml));

            con.Open();
            comm.ExecuteNonQuery();
            con.Close();




        }

        public DataTable ViewMarks(String Class, String Section, int term)
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());
            String Mainquery = "select ExamMarks.Studentid,ExamMarks.StudentName,ExamMarks.Term,ExamMarks.Sub1,ExamMarks.Sub2,ExamMarks.Sub3,ExamMarks.Sub4,ExamMarks.Sub5,ExamMarks.Sub6,ExamMarks.Sub7,ExamMarks.Sub8,ExamMarks.ObtainedMarks,ExamMarks.TotalMarks,ExamMarks.Percentage,ExamMarks.Grade,ExamMarks.PromotedStatus,Class.className,Class.classId from ExamMarks INNER JOIN Class ON ExamMarks.ClassId=Class.classId   where ExamMarks.ClassId='" + Class + "' and ExamMarks.SectionId='"+Section+"' and Term='" + term + "'  ORDER BY ExamMarks.Studentid ASC";
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

        public DataTable getFailedStudents(Student st)
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());
            con.Open();
            DataTable result = new DataTable();
            string query = "Select AddStudent.Email,Studentid,StudentName,ObtainedMarks,TotalMarks,Percentage,Grade,PromotedStatus from ExamMarks INNER JOIN AddStudent on ExamMarks.Studentid=AddStudent.AdmissionId where ClassId='" + st.currentClass + "' and SectionId='" + st.currentSection + "' and Term='" + st.termOfClass + "'and PromotedStatus='Failed'";
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(query, con);
            da.Fill(result);

            String subject = "select Name,Sum(SubjectMarks)As Marks from Subject where ClassId='" + st.currentClass + "' Group by Name";
            DataTable getsubject = new DataTable();




            SqlCommand comsubject = new SqlCommand(subject, con);
            comsubject.ExecuteNonQuery();
            SqlDataAdapter comdap = new SqlDataAdapter(comsubject);
            comdap.Fill(getsubject);

            int TotalMarks = 0;
            System.Data.DataColumn TotalSubjectMarks = new System.Data.DataColumn("TotalSubjectMarks", typeof(System.String));
            for (int i = 0; i < getsubject.Rows.Count; i++)
            {
                TotalMarks = TotalMarks + Convert.ToInt32(getsubject.Rows[i]["Marks"].ToString());


            }
            TotalSubjectMarks.DefaultValue = TotalMarks;

            result.Columns.Add(TotalSubjectMarks);



            return result;
        }
        public DataTable getPromotedStudents(Student st)
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());
            con.Open();
            DataTable result = new DataTable();
            string query = "Select AddStudent.Email,Studentid,StudentName,ObtainedMarks,TotalMarks,Percentage,Grade,PromotedStatus from ExamMarks INNER JOIN AddStudent on ExamMarks.Studentid=AddStudent.AdmissionId where ClassId='" + st.currentClass + "' and SectionId='" + st.currentSection + "' and Term='" + st.termOfClass + "' and PromotedStatus='Promoted'";
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(query, con);
            da.Fill(result);

            String subject = "select Name,Sum(SubjectMarks)As Marks from Subject where ClassId='" + st.currentClass + "' Group by Name";
            DataTable getsubject = new DataTable();




            SqlCommand comsubject = new SqlCommand(subject, con);
            comsubject.ExecuteNonQuery();
            SqlDataAdapter comdap = new SqlDataAdapter(comsubject);
            comdap.Fill(getsubject);

            int TotalMarks = 0;
            System.Data.DataColumn TotalSubjectMarks = new System.Data.DataColumn("TotalSubjectMarks", typeof(System.String));
            for (int i = 0; i < getsubject.Rows.Count; i++)
            {
                TotalMarks = TotalMarks + Convert.ToInt32(getsubject.Rows[i]["Marks"].ToString());


            }
            TotalSubjectMarks.DefaultValue = TotalMarks;

            result.Columns.Add(TotalSubjectMarks);



            return result;
        }
        public void SendEmailToOne(String AddmissionId,string cls,string section, int term)
        {
            string curntYear = DateTime.Now.Year.ToString();


            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            String query = "select AddStudent.AdmissionId,AddStudent.Email from AddStudent where  AddStudent.AdmissionId='" + AddmissionId + "' ";

            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.ExecuteNonQuery();

            SqlDataAdapter dap = new SqlDataAdapter(com);

            DataTable dt = new DataTable();

            dap.Fill(dt);

            MailMessage Msg = new MailMessage();

            Msg.From = new MailAddress("zeeshanchogtai@gmail.com");
            Msg.To.Add(dt.Rows[0]["Email"].ToString());

            Msg.Subject = "Exams Results";
            Msg.IsBodyHtml = false;
            Msg.Body = "Congratulations Your Son/Daughter against Roll Number" + "  '" + AddmissionId + "' " + "has successfully passed the exams of Class" + "  '" + cls + "' " + "Section " + "  '" + section + "' " + "and Term" + "  '" + term + "' " + "of" + "'" + curntYear + "'\n\n\n" + "From Principle of Zamp School System Gujranwala";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("zeeshanchogtai@gmail.com", "Chaireman@me");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
            con.Close();


        }



        public void SendEmailToAll(DataTable dt,string cls,string section, int term)
        {
            string curntYear = DateTime.Now.Year.ToString();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String AdmissionId=dt.Rows[i]["Studentid"].ToString();
                MailMessage Msg = new MailMessage();

                Msg.From = new MailAddress("zeeshanchogtai@gmail.com");
                Msg.To.Add(dt.Rows[i]["Email"].ToString());

                Msg.Subject = "Exams Results";
               
                Msg.IsBodyHtml = false;
                Msg.Body = "Congratulations Your Son/Daughter against Roll Number" + "  '" + AdmissionId + "' " + "has successfully passed the exams of Class" + "  '" + cls + "' " + "Section " + "  '" + section + "' " + "and Term" + "  '" + term + "' " + "of" + "'" + curntYear + "'\n\n\n" + "From Principle of Zamp School System Gujranwala";


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("zeeshanchogtai@gmail.com", "Chaireman@me");
                smtp.EnableSsl = true;
                smtp.Send(Msg);

            }




        }



        public void SendEmailToOneFail(String AddmissionId, string cls, string section, int term)
        {
            string curntYear = DateTime.Now.Year.ToString();


            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            String query = "select AddStudent.AdmissionId,AddStudent.Email from AddStudent where  AddStudent.AdmissionId='" + AddmissionId + "' ";

            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.ExecuteNonQuery();

            SqlDataAdapter dap = new SqlDataAdapter(com);

            DataTable dt = new DataTable();

            dap.Fill(dt);

            MailMessage Msg = new MailMessage();

            Msg.From = new MailAddress("Muneebgulzar72@gmail.com");
            Msg.To.Add(dt.Rows[0]["Email"].ToString());

            Msg.Subject = "Exams Results";
            Msg.IsBodyHtml = false;
            Msg.Body = "Your Son/Daughter against Roll Number" + "  '" + AddmissionId + "' " + "has been Failed in the exams of Class" + "  '" + cls + "' " + "Section " + "  '" + section + "' " + "and Term" + "  '" + term + "' " + "of" + "'" + curntYear + "'\n\n\n" + "From Principle of Zamp School System Gujranwala";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("Muneebgulzar72@gmail.com", "sajawaljamil123");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
            con.Close();


        }



        public void SendEmailToAllFail(DataTable dt, string cls, string section, int term)
        {
            string curntYear = DateTime.Now.Year.ToString();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String AdmissionId = dt.Rows[i]["Studentid"].ToString();
                MailMessage Msg = new MailMessage();

                Msg.From = new MailAddress("Muneebgulzar72@gmail.com");
                Msg.To.Add(dt.Rows[i]["Email"].ToString());

                Msg.Subject = "Exams Results";

                Msg.IsBodyHtml = false;
                Msg.Body = "Congratulations Your Son/Daughter against Roll Number" + "  '" + AdmissionId + "' " + "has successfully passed the exams of Class" + "  '" + cls + "' " + "Section " + "  '" + section + "' " + "and Term" + "  '" + term + "' " + "of" + "'" + curntYear + "'\n\n\n" + "From Principle of Zamp School System Gujranwala";


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
               // smtp.Credentials = new System.Net.NetworkCredential("zeeshanchogtai@gmail.com", "Chaireman@me");
                smtp.Credentials = new System.Net.NetworkCredential("Muneebgulzar72@gmail.com ", "sajawaljamil123");
                
                smtp.EnableSsl = true;
                smtp.Send(Msg);

            }




        }

      public DataTable getPositionHolders(string Class,int term)
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());
            con.Open();
            DataTable result = new DataTable();
            String query = "select top 3 ExamMarks.Studentid,ExamMarks.StudentName,ExamMarks.ObtainedMarks,ExamMarks.TotalMarks,ExamMarks.Grade,ExamMarks.Percentage,ExamMarks.PromotedStatus from ExamMarks where ExamMarks.ClassId='" + Class + "' and ExamMarks.Term='" + term + "' and ExamMarks.ObtainedMarks is not null and PromotedStatus Not In('Failed')   order by ExamMarks.ObtainedMarks desc ";
          da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(query, con);
            da.Fill(result);


            String subject = "select Name,Sum(SubjectMarks)As Marks from Subject where ClassId='" + Class + "' Group by Name";
            DataTable getsubject = new DataTable();




            SqlCommand comsubject = new SqlCommand(subject, con);
            comsubject.ExecuteNonQuery();
            SqlDataAdapter comdap = new SqlDataAdapter(comsubject);
            comdap.Fill(getsubject);

            int TotalMarks = 0;
            System.Data.DataColumn TotalSubjectMarks = new System.Data.DataColumn("TotalSubjectMarks", typeof(System.String));
            for (int i = 0; i < getsubject.Rows.Count; i++)
            {
                TotalMarks = TotalMarks + Convert.ToInt32(getsubject.Rows[i]["Marks"].ToString());


            }
            TotalSubjectMarks.DefaultValue = TotalMarks;

            result.Columns.Add(TotalSubjectMarks);

            con.Close();
            return result;


        }

    }
}
