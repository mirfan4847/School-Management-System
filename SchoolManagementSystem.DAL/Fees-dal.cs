using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Entities;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Globalization;
using System.Net.Mail;

namespace SchoolManagementSystem.DAL
{
    public class Fees_dal
    {
        public DataTable ShowSetFess()
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            DataTable Fees = new DataTable();

            String query = "select classId,ClassName,ClassFee,id,Fees,'0' AS ISUPDATE from  Class INNER JOIN SetFees ON Class.ClassFee=SetFees.id";




            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();


            SqlDataAdapter dap = new SqlDataAdapter(cmd);

            dap.Fill(Fees);
            con.Close();



            return Fees;


        }

        public DataTable FeeCollection(String Class, String Section, int month)
        {
            string curntMnth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);

            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            DataTable Collection = new DataTable();

            String query = "select Fee_Month,AddStudent.AdmissionId,AddStudent.Name,Class.className,Class.classId,Section.sectionName,Section.sectionId,AddStudent.FeeStatus,lateFeeFine,Balance,Paid_Date,Slip,Fee_Status from AddStudent INNER JOIN Class ON AddStudent.Class=Class.classId INNER JOIN Section ON AddStudent.Section=Section.sectionId FULL OUTER JOIN FeesCollection ON FeesCollection.studentId=AddStudent.AdmissionId where AddStudent.Class='" + Class + "' AND AddStudent.Section='" + Section + "'";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(Collection);



            for (int i = 0; i < Collection.Rows.Count; i++)
            {

                String duplicate = "select studentId from  FeesCollection where studentId='" + Collection.Rows[i]["AdmissionId"] + "'and Fee_Month ='" + curntMnth + "'";

                SqlCommand cmm = new SqlCommand(duplicate, con);
                cmm.ExecuteNonQuery();
                DataTable dtCheck = new DataTable();
                SqlDataAdapter daCheck = new SqlDataAdapter(cmm);
                daCheck.Fill(dtCheck);
                if (dtCheck.Rows.Count < 1)
                {
                    String query1 = "insert into FeesCollection(studentId,classId,sectionId,Fee_Month)values('" + Collection.Rows[i]["AdmissionId"] + "','" + Class + "','" + Section + "','" + curntMnth + "')";

                    SqlCommand com = new SqlCommand(query1, con);

                    com.ExecuteNonQuery();
                }

            }




            String Mainquery = "select  '0' AS ISNEW, '0' AS ISUPDATE,Fee_Month,AddStudent.AdmissionId,AddStudent.Name,Class.className,Class.classId,Section.sectionName,Section.sectionId,AddStudent.FeeStatus,lateFeeFine,Balance,Paid_Date,Slip,Fee_Status from AddStudent INNER JOIN Class ON AddStudent.Class=Class.classId INNER JOIN Section ON AddStudent.Section=Section.sectionId FULL OUTER JOIN FeesCollection ON FeesCollection.studentId=AddStudent.AdmissionId where AddStudent.Class='" + Class + "' AND AddStudent.Section='" + Section + "'and Fee_Month ='" + curntMnth + "'";
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


           

            con.Close();


            return maindt;


        }

        public void AddFeesCollection_dll(DataTable dt)
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());


            dt.TableName = "MYTABLE";

            StringWriter sw = new StringWriter();
            dt.WriteXml(sw);

            String xml = sw.ToString();



            SqlCommand comm = new SqlCommand("spAddStudentFeesJanuary", con);

            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@P1", xml));

            con.Open();
            comm.ExecuteNonQuery();
            con.Close();

        }



        public DataTable FeeDefaulters(String Class, String Section, int month)
        {
            string curntMnth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);

            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            DataTable Defaulters = new DataTable();



            String query = "select FeesCollection.studentId,AddStudent.Name,AddStudent.AdmissionId,AddStudent.Email,Class.className,Section.sectionName,FeesCollection.Fee_Month,FeesCollection.Fee_Status from FeesCollection INNER JOIN Class ON FeesCollection.classId=Class.classId INNER JOIN Section ON FeesCollection.sectionId=Section.sectionId INNER JOIN AddStudent ON AddStudent.AdmissionId=FeesCollection.studentId where FeesCollection.classId='" + Class + "' AND FeesCollection.sectionId='" + Section + "' AND  FeesCollection.Fee_Month='" + curntMnth + "' AND  NULLIF( FeesCollection.Fee_Status, '') IS NULL    ";


            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(Defaulters);


            Defaulters.Columns.Add(new DataColumn("Sr", Type.GetType("System.String")));

            for (int i = 0; i < Defaulters.Rows.Count; i++)
            {
                Defaulters.Rows[i]["Sr"] = i + 1;
            }
            for (int i = 0; i < Defaulters.Rows.Count; i++)
            {
                Defaulters.Rows[i]["Fee_Status"] = "Nill";
            }




            con.Close();


            return Defaulters;


        }


        public DataTable AllFeeDefaulters(int month)
        {
            string curntMnth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);

            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            DataTable Defaulters = new DataTable();



            String query = "select FeesCollection.studentId,AddStudent.Name,AddStudent.Email,AddStudent.AdmissionId,Class.className,Section.sectionName,FeesCollection.Fee_Month,FeesCollection.Fee_Status from FeesCollection INNER JOIN Class ON FeesCollection.classId=Class.classId INNER JOIN Section ON FeesCollection.sectionId=Section.sectionId INNER JOIN AddStudent ON AddStudent.AdmissionId=FeesCollection.studentId where FeesCollection.Fee_Month='" + curntMnth + "' AND  NULLIF( FeesCollection.Fee_Status, '') IS NULL    ";


            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(Defaulters);


            Defaulters.Columns.Add(new DataColumn("Sr", Type.GetType("System.String")));

            for (int i = 0; i < Defaulters.Rows.Count; i++)
            {
                Defaulters.Rows[i]["Sr"] = i + 1;
            }
            for (int i = 0; i < Defaulters.Rows.Count; i++)
            {
                Defaulters.Rows[i]["Fee_Status"] = "Nill";
            }




            con.Close();


            return Defaulters;


        }



        public void SendEmailToOne(String AddmissionId, int month)
        {
            string curntMnth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
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

            Msg.Subject = "Please Submit Your Fees for Student";
            Msg.IsBodyHtml = false;
            Msg.Body = "Your Son/Daughter didn,t Pay the Fees of" + "  '" + curntMnth + "' " + "'" + curntYear + "'\n\n" + "Kindly Pay your Fees as soon as possible otherwise Your,s Son/Daughter admission against Roll Number" + "'" + dt.Rows[0]["AdmissionId"] + "'" + " Will be Canceled\n\n\n" + "From Principle of Zamp School System Gujranwala";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("zeeshanchogtai@gmail.com", "Chaireman@me");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
            con.Close();


        }



        public void SendEmailToAll(DataTable dt, int month)
        {
            string curntMnth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
            string curntYear = DateTime.Now.Year.ToString();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MailMessage Msg = new MailMessage();

                Msg.From = new MailAddress("zeeshanchogtai@gmail.com");
                Msg.To.Add(dt.Rows[i]["Email"].ToString());

                Msg.Subject = "Please Submit Your Fees for Student";
                Msg.IsBodyHtml = false;
                Msg.Body = "Your Son/Daughter didn,t Pay the Fees of" + "  '" + curntMnth + "' " + "'" + curntYear + "'\n\n" + "Kindly Pay your Fees as soon as possible otherwise Your,s Son/Daughter admission against Roll Number" + "'" + dt.Rows[i]["AdmissionId"] + "'" + " Will be Canceled\n\n\n" + "From Principle of Zamp School System Gujranwala";


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("zeeshanchogtai@gmail.com", "Chaireman@me");
                smtp.EnableSsl = true;
                smtp.Send(Msg);

            }




        }



        public DataTable DailyFeeDetails(String Date)
        {
            DataTable DailyFee = new DataTable();

            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());




            String query = "select FeesCollection.studentId,AddStudent.Name,Class.className,Section.sectionName,FeesCollection.Paid_Date,FeesCollection.Balance from FeesCollection INNER JOIN Class ON FeesCollection.classId=Class.classId INNER JOIN Section ON FeesCollection.sectionId=Section.sectionId INNER JOIN AddStudent ON AddStudent.AdmissionId=FeesCollection.studentId where FeesCollection.Paid_Date='" + Date + "' AND  FeesCollection.Fee_Status='OK'   ";


            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(DailyFee);


            DailyFee.Columns.Add(new DataColumn("Sr", Type.GetType("System.String")));

            for (int i = 0; i < DailyFee.Rows.Count; i++)
            {
                DailyFee.Rows[i]["Sr"] = i + 1;
            }



            con.Close();
            return DailyFee;
        }

        public DataTable MonthlyFeeDetails(int month)
        {
            string curntMnth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);

            DataTable DailyFee = new DataTable();

            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());




            String query = "select FeesCollection.studentId,AddStudent.Name,Class.className,Section.sectionName,FeesCollection.Fee_Month,FeesCollection.Balance from FeesCollection INNER JOIN Class ON FeesCollection.classId=Class.classId INNER JOIN Section ON FeesCollection.sectionId=Section.sectionId INNER JOIN AddStudent ON AddStudent.AdmissionId=FeesCollection.studentId where FeesCollection.Fee_Month='" + curntMnth + "' AND  FeesCollection.Fee_Status='OK'   ";


            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(DailyFee);


            DailyFee.Columns.Add(new DataColumn("Sr", Type.GetType("System.String")));

            for (int i = 0; i < DailyFee.Rows.Count; i++)
            {
                DailyFee.Rows[i]["Sr"] = i + 1;
            }



            con.Close();
            return DailyFee;
        }


        public DataTable YearlyFeeDetailsOnLoad(String Year)
        {


            DataTable DailyFee = new DataTable();

            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());




            String query = "select Class.className,FeesCollection.Paid_Date,FeesCollection.Fee_Status,FeesCollection.Balance from FeesCollection INNER JOIN Class ON FeesCollection.classId=Class.classId  where FeesCollection.Paid_Date Like '%'+ @Year AND  FeesCollection.Fee_Status='OK' ORDER BY className ASC  ";


            SqlCommand cmd = new SqlCommand(query, con);
            // cmd.Parameters.AddWithValue("@Year", string.Format("%{0}", Year));
            cmd.Parameters.AddWithValue("@Year", Year);
            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(DailyFee);

            DataTable dtview = new DataTable();

            dtview.Columns.Add("Sr");
            dtview.Columns.Add("className");
            dtview.Columns.Add("Fee_Year");
            dtview.Columns.Add("Balance");





            //Play Group
            DataRow[] PG = DailyFee.Select("className='Play Group'");
            int TotalPG = 0;

            foreach (DataRow row in PG)
            {
                TotalPG = TotalPG + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow play = dtview.NewRow();
            dtview.Rows.Add(play);

            dtview.Rows[0]["Sr"] = "1";
            dtview.Rows[0]["className"] = "Play Group";
            dtview.Rows[0]["Fee_Year"] = Year;
            dtview.Rows[0]["Balance"] = TotalPG;
            //End Paly Group


            //Nursery


            DataRow[] Nursery = DailyFee.Select("className='Nursery'");
            int TotalNursery = 0;

            foreach (DataRow row in Nursery)
            {
                TotalNursery = TotalNursery + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow nursery = dtview.NewRow();
            dtview.Rows.Add(nursery);

            dtview.Rows[1]["Sr"] = "2";
            dtview.Rows[1]["className"] = "Nursery";
            dtview.Rows[1]["Fee_Year"] = Year;
            dtview.Rows[1]["Balance"] = TotalNursery;



            //End Nursery

            //Prep

            DataRow[] Prep = DailyFee.Select("className='Prep'");
            int TotalPrep = 0;

            foreach (DataRow row in Prep)
            {
                TotalPrep = TotalPrep + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow prep = dtview.NewRow();
            dtview.Rows.Add(prep);

            dtview.Rows[2]["Sr"] = "3";
            dtview.Rows[2]["className"] = "Prep";
            dtview.Rows[2]["Fee_Year"] = Year;
            dtview.Rows[2]["Balance"] = TotalPrep;



            //End Prep


            //Ist 


            DataRow[] Ist = DailyFee.Select("className='Ist'");
            int TotalIst = 0;

            foreach (DataRow row in Ist)
            {
                TotalIst = TotalIst + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow first = dtview.NewRow();
            dtview.Rows.Add(first);

            dtview.Rows[3]["Sr"] = "4";
            dtview.Rows[3]["className"] = "Ist";
            dtview.Rows[3]["Fee_Year"] = Year;
            dtview.Rows[3]["Balance"] = TotalIst;

            //End Ist


            //2nd

            DataRow[] Second = DailyFee.Select("className='2nd'");
            int Total2nd = 0;

            foreach (DataRow row in Second)
            {
                Total2nd = Total2nd + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow second = dtview.NewRow();
            dtview.Rows.Add(second);

            dtview.Rows[4]["Sr"] = "5";
            dtview.Rows[4]["className"] = "2nd";
            dtview.Rows[4]["Fee_Year"] = Year;
            dtview.Rows[4]["Balance"] = Total2nd;

            //End 2nd


            //3rd

            DataRow[] Third = DailyFee.Select("className='3rd'");
            int Total3rd = 0;

            foreach (DataRow row in Third)
            {
                Total3rd = Total3rd + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow third = dtview.NewRow();
            dtview.Rows.Add(third);

            dtview.Rows[5]["Sr"] = "6";
            dtview.Rows[5]["className"] = "3rd";
            dtview.Rows[5]["Fee_Year"] = Year;
            dtview.Rows[5]["Balance"] = Total3rd;




            //End 3rd


            //4th

            DataRow[] Fourth = DailyFee.Select("className='4th'");
            int Total4th = 0;

            foreach (DataRow row in Fourth)
            {
                Total4th = Total4th + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow fourth = dtview.NewRow();
            dtview.Rows.Add(fourth);

            dtview.Rows[6]["Sr"] = "7";
            dtview.Rows[6]["className"] = "4th";
            dtview.Rows[6]["Fee_Year"] = Year;
            dtview.Rows[6]["Balance"] = Total4th;


            //End 4th

            // 5th
            DataRow[] Fifth = DailyFee.Select("className='5th'");
            int Total5th = 0;

            foreach (DataRow row in Fifth)
            {
                Total5th = Total5th + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow fifth = dtview.NewRow();
            dtview.Rows.Add(fifth);

            dtview.Rows[7]["Sr"] = "8";
            dtview.Rows[7]["className"] = "5th";
            dtview.Rows[7]["Fee_Year"] = Year;
            dtview.Rows[7]["Balance"] = Total5th;





            //End 5th

            //6th

            DataRow[] Sixth = DailyFee.Select("className='6th'");
            int Total6th = 0;

            foreach (DataRow row in Sixth)
            {
                Total6th = Total6th + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow sixth = dtview.NewRow();
            dtview.Rows.Add(sixth);

            dtview.Rows[8]["Sr"] = "9";
            dtview.Rows[8]["className"] = "6th";
            dtview.Rows[8]["Fee_Year"] = Year;
            dtview.Rows[8]["Balance"] = Total6th;

            //End 6th

            //7th
            DataRow[] Seven = DailyFee.Select("className='7th'");
            int Total7th = 0;

            foreach (DataRow row in Seven)
            {
                Total7th = Total7th + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow seven = dtview.NewRow();
            dtview.Rows.Add(seven);

            dtview.Rows[9]["Sr"] = "10";
            dtview.Rows[9]["className"] = "7th";
            dtview.Rows[9]["Fee_Year"] = Year;
            dtview.Rows[9]["Balance"] = Total7th;




            //End 7th






            //8th
            DataRow[] Eight = DailyFee.Select("className='8th'");
            int Total8th = 0;

            foreach (DataRow row in Eight)
            {
                Total8th = Total8th + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow eight = dtview.NewRow();
            dtview.Rows.Add(eight);

            dtview.Rows[10]["Sr"] = "11";
            dtview.Rows[10]["className"] = "8th";
            dtview.Rows[10]["Fee_Year"] = Year;
            dtview.Rows[10]["Balance"] = Total8th;



            //End 8th

            //9th
            DataRow[] Nine = DailyFee.Select("className='9th'");
            int Total9th = 0;

            foreach (DataRow row in Nine)
            {
                Total9th = Total9th + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow nine = dtview.NewRow();
            dtview.Rows.Add(nine);

            dtview.Rows[11]["Sr"] = "12";
            dtview.Rows[11]["className"] = "9th";
            dtview.Rows[11]["Fee_Year"] = Year;
            dtview.Rows[11]["Balance"] = Total9th;




            //End 9th



            //10th

            DataRow[] Ten = DailyFee.Select("className='10th'");
            int Total10th = 0;

            foreach (DataRow row in Ten)
            {
                Total10th = Total10th + Convert.ToInt32(row["Balance"].ToString());
            }
            DataRow ten = dtview.NewRow();
            dtview.Rows.Add(ten);

            dtview.Rows[12]["Sr"] = "13";
            dtview.Rows[12]["className"] = "10th";
            dtview.Rows[12]["Fee_Year"] = Year;
            dtview.Rows[12]["Balance"] = Total10th;


            //End 10th
            

            con.Close();
            return dtview;
        }



        public DataTable GetAllYear()
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            DataTable AllYear = new DataTable();

            String query = "select  DISTINCT DATEPART( yyyy,CONVERT(DateTime,Paid_Date, 105)) as dateyear  from FeesCollection  where  Paid_Date IS NOT NULL ORDER BY dateyear DESC ";



           

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();


            SqlDataAdapter dap = new SqlDataAdapter(cmd);

            dap.Fill(AllYear);




            con.Close();



            return AllYear;







        }



    }
}
