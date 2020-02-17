using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;


namespace Future
{
    public partial class Admin_Home1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("NotAuthenticated.aspx");
            }
            else if (!User.IsInRole("Accountant") && !User.IsInRole("Admin"))
            {
                Response.Redirect("Authorized.aspx");
            }
            else if (!IsPostBack)
            {
                //No of Students in a Class

                SqlConnection conn = new SqlConnection("Data Source=.;Database=School;integrated Security=true;");
                string que = "select Distinct Class.className,Class.classId,COUNT( AddStudent.Class)as Total_Students from Class INNER Join AddStudent on Class.classId=AddStudent.Class Group by Class.className,Class.classId order by Class.classId ASC";
                SqlCommand com = new SqlCommand(que, conn);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable ds = new DataTable();
                da.Fill(ds);

                //2.Set the style/Settings for X and Y axis
                Chart1.Font.Size = FontUnit.Medium;
                Chart1.Series["No of Students in a Class"].XValueType = ChartValueType.Int32;
                Chart1.Series["No of Students in a Class"].YValueType = ChartValueType.Int32;
                Chart1.ChartAreas[0].AxisY.Title = "No. Of Students";
                Chart1.ChartAreas[0].AxisX.Title = "Classes";


                //3.Define the chart type
                Chart1.Series["No of Students in a Class"].ChartType = SeriesChartType.Column;
                //4.Add the actual values from the dataset to X & Y co-ordinates
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    Chart1.Series["No of Students in a Class"].Points.AddXY(ds.Rows[i]["className"], ds.Rows[i]["Total_Students"]);
                }

                //Random random = new Random();
                //foreach (var item in Chart1.Series[0].Points)
                //{
                //    Color c = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                //    item.Color = c;
                //}

                //No of Students in a Class




                //New Admission Capacity


                String que1 = "select Distinct Class.className,Class.classId,50-COUNT( AddStudent.Class) as Total_Students from Class INNER Join AddStudent on Class.classId=AddStudent.Class Group by Class.className,Class.classId order by Class.classId ASC";
                SqlCommand com1 = new SqlCommand(que1, conn);
                SqlDataAdapter da1 = new SqlDataAdapter(com1);
                DataTable ds1 = new DataTable();
                da1.Fill(ds1);

                //2.Set the style/Settings for X and Y axis
                Chart2.Font.Size = FontUnit.Medium;
                Chart2.Series["New Admission Capacity"].XValueType = ChartValueType.Int32;
                Chart2.Series["New Admission Capacity"].YValueType = ChartValueType.Int32;
                Chart2.ChartAreas[0].AxisY.Title = "New Admission Capacity";
                Chart2.ChartAreas[0].AxisX.Title = "Classes";


                //3.Define the chart type
                Chart2.Series["New Admission Capacity"].ChartType = SeriesChartType.Column;
                //4.Add the actual values from the dataset to X & Y co-ordinates
                //for (int i = 0; i < ds1.Rows.Count; i++)
                //{
                //    Chart2.Series["New Admission Capacity"].Points.AddXY(ds1.Rows[i]["className"], ds1.Rows[i]["Total_Students"]);
                //}

                Chart2.DataSource = ds1;

                Chart2.Series["New Admission Capacity"].XValueMember="className";
                Chart2.Series["New Admission Capacity"].YValueMembers = "Total_Students";

                //New Admission Capacity

                //Monthly Defaulters

                DateTime now = DateTime.Now;
                int mn=now.Month;
                String mnth=CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mn);


                String que2 = " select Class.classId ,Class.className,COUNT( FeesCollection.studentId) as Total_Students from Class Left JOIN FeesCollection  ON Class.classId=FeesCollection.classId where FeesCollection.Fee_Month='" + mnth + "'  AND  NULLIF( FeesCollection.Fee_Status, '') IS NULL  Group By Class.className,FeesCollection.Fee_Month,FeesCollection.Fee_Status,Class.classId order by Class.classId ASC";
                SqlCommand com2 = new SqlCommand(que2, conn);
                SqlDataAdapter da2 = new SqlDataAdapter(com2);
                DataTable ds2 = new DataTable();
                da2.Fill(ds2);

                //2.Set the style/Settings for X and Y axis
                Chart3.Font.Size = FontUnit.Medium;
                Chart3.Series["Monthly Defaulters"].XValueType = ChartValueType.Int32;
                Chart3.Series["Monthly Defaulters"].YValueType = ChartValueType.Int32;
                Chart3.ChartAreas[0].AxisY.Title = "Defaulters";
                Chart3.ChartAreas[0].AxisX.Title = "Classes";


                //3.Define the chart type
                Chart3.Series["Monthly Defaulters"].ChartType = SeriesChartType.Column;
               

                Chart3.DataSource = ds2;

                Chart3.Series["Monthly Defaulters"].XValueMember = "className";
                Chart3.Series["Monthly Defaulters"].YValueMembers = "Total_Students";

                //Monthly Defaulters


                // Yearly Defaulters

                String year = DateTime.Now.ToString("yyyy");

              String que3 = " select Class.classId , Class.className,COUNT( FeesCollection.studentId) as Total_Students from Class Left JOIN FeesCollection  ON Class.classId=FeesCollection.classId where   NULLIF( FeesCollection.Fee_Status, '') IS NULL And FeesCollection.Paid_Date Like '%'+ @Year Group By Class.className,FeesCollection.Fee_Month,FeesCollection.Fee_Status,Class.classId,Paid_Date order by Class.classId ASC";
                
                SqlCommand com3 = new SqlCommand(que3, conn);
                com3.Parameters.AddWithValue("@Year", year);
                SqlDataAdapter da3 = new SqlDataAdapter(com3);
                DataTable ds3 = new DataTable();
                da3.Fill(ds3);

                //2.Set the style/Settings for X and Y axis
                Chart4.Font.Size = FontUnit.Medium;
                Chart4.Series["Yearly Defaulters"].XValueType = ChartValueType.Int32;
                Chart4.Series["Yearly Defaulters"].YValueType = ChartValueType.Int32;
                Chart4.ChartAreas[0].AxisY.Title = "Defaulters";
                Chart4.ChartAreas[0].AxisX.Title = "Classes";


                //3.Define the chart type
                Chart4.Series["Yearly Defaulters"].ChartType = SeriesChartType.Column;


                Chart4.DataSource = ds3;

                Chart4.Series["Yearly Defaulters"].XValueMember = "className";
                Chart4.Series["Yearly Defaulters"].YValueMembers = "Total_Students";
               
                // Yearly Defaulters


                //Passed Students
                String que4 = " select Class.classId , Class.className, COUNT( ExamMarks.studentId) as Total_Students from Class Left JOIN ExamMarks  ON Class.classId=ExamMarks.classId where    PromotedStatus='Promoted' Group By Class.className,Class.classId order by Class.classId ASC";

                SqlCommand com4 = new SqlCommand(que4, conn);
                SqlDataAdapter da4 = new SqlDataAdapter(com4);
                DataTable ds4 = new DataTable();
                da4.Fill(ds4);

                //2.Set the style/Settings for X and Y axis
                Chart5.Font.Size = FontUnit.Medium;
                Chart5.Series["Passed Students"].XValueType = ChartValueType.Int32;
                Chart5.Series["Passed Students"].YValueType = ChartValueType.Int32;
                Chart5.ChartAreas[0].AxisY.Title = "Promoted Students";
                Chart5.ChartAreas[0].AxisX.Title = "Classes";


                //3.Define the chart type
                Chart5.Series["Passed Students"].ChartType = SeriesChartType.Column;


                Chart5.DataSource = ds4;

                Chart5.Series["Passed Students"].XValueMember = "className";
                Chart5.Series["Passed Students"].YValueMembers = "Total_Students";

                //Passed Students

                //Failed Students
                String que5 = " select Class.classId , Class.className, COUNT( ExamMarks.studentId) as Total_Students from Class Left JOIN ExamMarks  ON Class.classId=ExamMarks.classId where    PromotedStatus='Failed' Group By Class.className,Class.classId order by Class.classId ASC";

                SqlCommand com5 = new SqlCommand(que5, conn);
                SqlDataAdapter da5 = new SqlDataAdapter(com5);
                DataTable ds5 = new DataTable();
                da5.Fill(ds5);

                //2.Set the style/Settings for X and Y axis
                Chart6.Font.Size = FontUnit.Medium;
                Chart6.Series["Failed Students"].XValueType = ChartValueType.Int32;
                Chart6.Series["Failed Students"].YValueType = ChartValueType.Int32;
                Chart6.ChartAreas[0].AxisY.Title = "Failed Students";
                Chart6.ChartAreas[0].AxisX.Title = "Classes";


                //3.Define the chart type
                Chart6.Series["Failed Students"].ChartType = SeriesChartType.Column;


                Chart6.DataSource = ds5;

                Chart6.Series["Failed Students"].XValueMember = "className";
                Chart6.Series["Failed Students"].YValueMembers = "Total_Students";

                //Failed Students


                //Count All Fee Defaulters
                String CountAllDefaulters = "  select COUNT( FeesCollection.studentId) as Total_Defaulters from  FeesCollection  where FeesCollection.Fee_Month='" + mnth + "'  AND  NULLIF( FeesCollection.Fee_Status, '') IS NULL ";

                

                SqlCommand comCountdefaulters = new SqlCommand(CountAllDefaulters, conn);
                SqlDataAdapter daCountdefaulters = new SqlDataAdapter(comCountdefaulters);
                DataTable dtCountdefaulters = new DataTable();
                daCountdefaulters.Fill(dtCountdefaulters);

                String TDefaulters = dtCountdefaulters.Rows[0]["Total_Defaulters"].ToString();



                //Count All Fee Defaulters


                //Count All Failed Students

                String CountFstudents = " select COUNT( ExamMarks.studentId) as Total_FStudents from  ExamMarks  where    PromotedStatus='Failed' ";
                SqlCommand comCountFstudents = new SqlCommand(CountFstudents, conn);
                SqlDataAdapter daCountFstudents = new SqlDataAdapter(comCountFstudents);
                DataTable dtCountFstudents = new DataTable();
                daCountFstudents.Fill(dtCountFstudents);

                String TFstudents = dtCountFstudents.Rows[0]["Total_FStudents"].ToString();



               
               
                //Count All Failed Students



                //Count System users
                String constring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                String CountUsers = "select Count(Email) as Total_Users from AspNetUsers";

                SqlConnection conUsers = new SqlConnection(constring);
                SqlDataAdapter dapUsers = new SqlDataAdapter(CountUsers, conUsers);
                SqlCommandBuilder comUsers = new SqlCommandBuilder(dapUsers);
                DataTable dtUsers = new DataTable();
                dapUsers.Fill(dtUsers);

                String TUsers = dtUsers.Rows[0]["Total_Users"].ToString();




                //Count System users

                //Count System Roles


                String CountRoles = "select Count(Name) as Total_Roles from AspNetRoles";

                SqlConnection conRoles = new SqlConnection(constring);
                SqlDataAdapter dapRoles = new SqlDataAdapter(CountRoles, conUsers);
                SqlCommandBuilder comRoles = new SqlCommandBuilder(dapRoles);
                DataTable dtRoles = new DataTable();
                dapRoles.Fill(dtRoles);

                String TRoles = dtRoles.Rows[0]["Total_Roles"].ToString();



                 //Count System Roles


                //Count ToTal Students

                String CountTstudents = "  select COUNT( AddStudent.New_Stu_Id) as Total_Students from  AddStudent ";
                SqlCommand comCountTstudents = new SqlCommand(CountTstudents, conn);
                SqlDataAdapter daCountTstudents = new SqlDataAdapter(comCountTstudents);
                DataTable dtCountTstudents = new DataTable();
                daCountTstudents.Fill(dtCountTstudents);

                String Tstudents = dtCountTstudents.Rows[0]["Total_Students"].ToString();


                //Count ToTal Students



                //Count ToTal Staff


                String CountTStaff = "  select COUNT( AddStaff.Id) as Total_Staff from  AddStaff ";
                SqlCommand comCountTStaff = new SqlCommand(CountTStaff, conn);
                SqlDataAdapter daCountTStaff = new SqlDataAdapter(comCountTStaff);
                DataTable dtCountTStaff = new DataTable();
                daCountTStaff.Fill(dtCountTStaff);

                String TStaff = dtCountTStaff.Rows[0]["Total_Staff"].ToString();

                //Count ToTal Staff


                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:FeeDefaulters('" + TDefaulters + "');FailStudents('" + TFstudents + "');SystemUsers('" + TUsers + "');SystemRoles('" + TRoles + "');TotalStudents('" + Tstudents + "'); TotalStaff('" + TStaff + "'); ", true);
      

            }
        }
    }
}