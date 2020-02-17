using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Entities;
using System.Data.SqlClient;
using System.Data;


namespace SchoolManagementSystem.DAL
{
    public class Admission_dal
    {
        public DataTable FeesOnLoad(string className)
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            DataTable Fees = new DataTable();

            String query = "select Fees from SetFees INNER JOIN Class ON SetFees.id=Class.ClassFee where className='" + className + "'";




            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();


            SqlDataAdapter dap = new SqlDataAdapter(cmd);

            dap.Fill(Fees);
            con.Close();



            return Fees;



        }
        public DataTable ClassOnload()
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            DataTable Class = new DataTable();

            String query = "select classId,className from Class";


            //  String query = "select classId,className,Fees from Class INNER JOIN SetFees ON Class.ClassFee=SetFees.id";




            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();


            SqlDataAdapter dap = new SqlDataAdapter(cmd);

            dap.Fill(Class);
            con.Close();



            return Class;

        }
        public DataTable SectionOnload()
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            DataTable Section = new DataTable();

            String query = "select sectionId,sectionName from Section";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();



            SqlDataAdapter dap = new SqlDataAdapter(cmd);

            dap.Fill(Section);

            return Section;



        }

        public String SearchID { get; set; }
        SqlConnection con = new SqlConnection(Connections.AddStudentConnection());


        public void AddStudent_dal(Student addstu)
        {

            con.Open(); 

            String query = "insert into AddStudent(Name,Father,DOB,Place,BForm,Blood,Gender,FCnic,FOccupation,FIncome,Religion,GName,GCnic,GEducation,Email,Mobile,HomeTel,Hostel,Care,Address,PInstitutionName,PAdmissionId,PInstitutionAddress,PInstitutionClass,PInstitutionCertificate,Curricular,SiblingName1,SiblingStatus1,SiblingId1,SiblingName2,SiblingStatus2,SiblingId2,SiblingName3,SiblingStatus3,SiblingId3,Class,Section,Medium,AdmissionId,Session,FeeStatus,FamilyNo,AdmissionDate,Remarks,Approval,Password,Picture)values('" + addstu.Name + "','" + addstu.Father + "','" + addstu.DOB + "','" + addstu.Place + "', '" + addstu.BForm + "','" + addstu.Blood + "','" + addstu.Gender + "','" + addstu.FCnic + "','" + addstu.FOccupation + "','" + addstu.FIncome + "','" + addstu.Religion + "','" + addstu.GName + "','" + addstu.GCnic + "','" + addstu.GEducation + "','" + addstu.Email + "','" + addstu.Mobile + "','" + addstu.HomeTel + "','" + addstu.Hostel + "','" + addstu.Care + "','" + addstu.Address + "','" + addstu.PInstitutionName + "','" + addstu.PAdmissionId + "','" + addstu.PInstitutionAddress + "','" + addstu.PInstitutionClass + "','" + addstu.PInstitutionCertificate + "','" + addstu.Curricular + "','" + addstu.SiblingName1 + "','" + addstu.SiblingStatus1 + "','" + addstu.SiblingId1 + "','" + addstu.SiblingName2 + "','" + addstu.SiblingStatus2 + "','" + addstu.SiblingId2 + "','" + addstu.SiblingName3 + "','" + addstu.SiblingStatus3 + "','" + addstu.SiblingId3 + "','" + addstu.Class + "','" + addstu.Section + "','" + addstu.Medium + "','" + addstu.AdmissionId + "','" + addstu.Session + "','" + addstu.FeeStatus + "','" + addstu.FamilyNo + "','" + addstu.AdmissionDate + "','" + addstu.Remarks + "','" + addstu.Approval + "','" + addstu.AdmissionId + "','" + addstu.Image + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            int rowentered = cmd.ExecuteNonQuery();

            con.Close();





        }


        public DataTable EditStudent_dal(String SearchId)
        {
            SearchID = SearchId;


            String query = "Select * from AddStudent FULL OUTER JOIN Class ON AddStudent.Class=Class.classId FULL OUTER JOIN Section ON AddStudent.Section=Section.sectionId  where AdmissionId='" + SearchID + "'";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable edit = new DataTable();
            da.Fill(edit);

            con.Close();

            return edit;




        }

        public void UpdateStudent_dal(Student addstu, string student)
        {

            // AdmissionId='" + addstu.AdmissionId + "'
            //Picture='" + addstu.Image + "',
            String query = " Update AddStudent Set Name='" + addstu.Name + "',Father='" + addstu.Father + "',DOB='" + addstu.DOB + "',Place='" + addstu.Place + "',BForm='" + addstu.BForm + "',Blood='" + addstu.Blood + "',Gender='" + addstu.Gender + "',FCnic='" + addstu.FCnic + "',FOccupation='" + addstu.FOccupation + "',FIncome='" + addstu.FIncome + "',Religion='" + addstu.Religion + "',GName='" + addstu.GName + "',GCnic= '" + addstu.GCnic + "',GEducation='" + addstu.GEducation + "',Email='" + addstu.Email + "',Mobile='" + addstu.Mobile + "',HomeTel='" + addstu.HomeTel + "',Hostel='" + addstu.Hostel + "',Care='" + addstu.Care + "',Address='" + addstu.Address + "',PInstitutionName='" + addstu.PInstitutionName + "',PAdmissionId='" + addstu.PAdmissionId + "',PInstitutionAddress='" + addstu.PInstitutionAddress + "',PInstitutionClass='" + addstu.PInstitutionClass + "',PInstitutionCertificate='" + addstu.PInstitutionCertificate + "',Curricular='" + addstu.Curricular + "',SiblingName1='" + addstu.SiblingName1 + "',SiblingStatus1='" + addstu.SiblingStatus1 + "',SiblingId1='" + addstu.SiblingId1 + "',SiblingName2='" + addstu.SiblingName2 + "',SiblingStatus2='" + addstu.SiblingStatus2 + "',SiblingId2='" + addstu.SiblingId2 + "',SiblingName3='" + addstu.SiblingName3 + "',SiblingStatus3='" + addstu.SiblingStatus3 + "',SiblingId3='" + addstu.SiblingId3 + "',Class='" + addstu.Class + "',Section='" + addstu.Section + "',Medium='" + addstu.Medium + "',AdmissionId='" + addstu.AdmissionId + "',Session='" + addstu.Session + "',FeeStatus='" + addstu.FeeStatus + "',FamilyNo='" + addstu.FamilyNo + "',AdmissionDate='" + addstu.AdmissionDate + "',Remarks='" + addstu.Remarks + "',Approval='" + addstu.Approval + "',Password='" + addstu.AdmissionId + "' where AdmissionId='" + student + "' ";

            //String query = " Update AddStudent Set Name='" + addstu.Name + "',Father='" + addstu.Father + "' where AdmissionId='" + addstu.AdmissionId + "'";


            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int RowEdit = cmd.ExecuteNonQuery();





        }


        public DataTable InstituteRules_dal(String SearchId)
        {
            SearchID = SearchId;



            String query = "Select AdmissionId,Name,Father,Mobile,className,DOB from AddStudent  INNER JOIN Class  ON AddStudent.Class=Class.classId  where AdmissionId='" + SearchID + "'";



            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable rules = new DataTable();
            da.Fill(rules);

            con.Close();

            return rules;




        }

        public DataTable SMedical_dal(String SearchId)
        {
            //  SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            //  String query1 = "select Studentid from MedicalId where Studentid='"+SearchId+"' ";
            //  con.Open();
            //  SqlCommand cmd1= new SqlCommand(query1,con);

            //int duplicate= cmd1.ExecuteNonQuery();

            //SqlDataAdapter dap1 = new SqlDataAdapter(cmd1);
            //DataTable dt = new DataTable();

            //dap1.Fill(dt);
            //String a=dt.Rows[0]["Studentid"].ToString();

            String query = "Select AdmissionId,Name,Father from AddStudent where AdmissionId='" + SearchId + "'";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable SMedical = new DataTable();
            da.Fill(SMedical);

            con.Close();

            return SMedical;



        }


        public DataTable Duplicate_Medical_dal(string AdmissionId)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            String query1 = "select Studentid from MedicalId where Studentid='" + AdmissionId + "' ";
            con.Open();
            SqlCommand cmd1 = new SqlCommand(query1, con);

            cmd1.ExecuteNonQuery();

            SqlDataAdapter dap = new SqlDataAdapter(cmd1);

            dap.Fill(dt);





            return dt;




        }

        public void AddMedicalReport_dal(Medical med)
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            con.Open();

            String query = "insert into MedicalId(Name1,Hometel1,Mobile1,Name2,HomeTel2,Mobile2,ChickenPox,Diabetes,Eczema,Mumps,Asthma,Rheumatic,Epilepsy,Blood,Speech,NoProblem,StudentChronicleDetails,FamilyTB,FamilyEpilespsy,FamilyDiabetes,FamilyOthers,Date,Studentid)values('" + med.Name1 + "','" + med.Hometel1 + "','" + med.Mobile1 + "','" + med.Name2 + "','" + med.HomeTel2 + "','" + med.Mobile2 + "','" + med.ChickenPox + "','" + med.Diabetes + "','" + med.Eczema + "','" + med.Mumps + "','" + med.Asthma + "','" + med.Rheumatic + "','" + med.Epilepsy + "','" + med.Blood + "','" + med.Speech + "','" + med.NoProblem + "','" + med.StudentChronicleDetails + "','" + med.FamilyTB + "','" + med.FamilyEpilespsy + "','" + med.FamilyDiabetes + "','" + med.FamilyOthers + "','" + med.Date + "','" + med.AdmisionId + "')";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();


        }


        public DataTable SMedicalEditShow_dal(String SearchID)
        {
            //String query = "Select AdmissionId,Name,Father,Name1,Hometel1,Mobile1,Name2,HomeTel2,Mobile2,ChickenPox,Diabetes,Eczema,Mumps,Asthma,Rheumatic,Epilepsy,Blood,Speech,NoProblem,StudentChronicleDetails,FamilyTB,FamilyEpilespsy,FamilyDiabetes,FamilyOthers,Date,Studentid from AddStudent FULL OUTER JOIN MedicalId ON AddStudent.AdmissionId=MedicalId.Studentid where Studentid='" + SearchID + "'";

            String query = "Select * from AddStudent INNER JOIN MedicalId ON AddStudent.AdmissionId=MedicalId.Studentid where Studentid='" + SearchID + "' AND AdmissionId='" + SearchID + "' ";



            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable SMedicalEdit = new DataTable();
            da.Fill(SMedicalEdit);

            con.Close();

            return SMedicalEdit;


        }
        public void EditMedicalReport_dal(Medical med)
        {
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            con.Open();

            String query = " Update MedicalId Set Name1='" + med.Name1 + "', Hometel1='" + med.Hometel1 + "',Mobile1='" + med.Mobile1 + "',Name2='" + med.Name2 + "',HomeTel2='" + med.HomeTel2 + "',Mobile2='" + med.Mobile2 + "',ChickenPox='" + med.ChickenPox + "',Diabetes='" + med.Diabetes + "',Eczema='" + med.Eczema + "',Mumps='" + med.Mumps + "',Asthma='" + med.Asthma + "',Rheumatic='" + med.Rheumatic + "',Epilepsy='" + med.Epilepsy + "',Blood='" + med.Blood + "',Speech='" + med.Speech + "',NoProblem='" + med.NoProblem + "',StudentChronicleDetails='" + med.StudentChronicleDetails + "',FamilyTB='" + med.FamilyTB + "',FamilyEpilespsy='" + med.FamilyEpilespsy + "',FamilyDiabetes='" + med.FamilyDiabetes + "',FamilyOthers='" + med.FamilyOthers + "',Date='" + med.Date + "' where Studentid='" + med.AdmisionId + "' ";




            SqlCommand cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();


        }



        public DataTable SchoolLeaving(String Id)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            String query = "Select * from AddStudent FULL OUTER JOIN Class ON AddStudent.Class=Class.classId FULL OUTER JOIN Section ON AddStudent.Section=Section.sectionId  where AdmissionId='" + Id + "'";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            con.Close();
            return dt;

        }
        public DataTable SchoolCharacter(String Id)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());

            String query = "Select * from AddStudent FULL OUTER JOIN Class ON AddStudent.Class=Class.classId where AdmissionId='" + Id + "'";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            con.Close();


            return dt;
        }


        public DataTable TeacherTimeTable(String Teacher)
        {
            DataTable TimeTable = new DataTable();

            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());


            String query = "Select '0' As ISUPDATE,Id, Days,Lec1,Lec2,Lec3,Lec4,Lec5,Lec6,Lec7,Lec8,Class,Section,Teacher from TeacherTimeTable  where Teacher='" + Teacher + "'";






            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(TimeTable);

            con.Close();
            return TimeTable;

        }
        public DataTable ClassTimeTable(String Class, String Section)
        {
            DataTable TimeTable = new DataTable();

            SqlConnection con = new SqlConnection(Connections.AddStudentConnection());


            String query = "Select '0' As ISUPDATE,Id, Days,Lec1,Lec2,Lec3,Lec4,Lec5,Lec6,Lec7,Lec8,Class,Section,classId,className,teacherId,ClassFee,sectionId,sectionName from ClassTimeTable FULL OUTER JOIN Class ON ClassTimeTable.Class=Class.classId FULL OUTER JOIN Section ON ClassTimeTable.Section=Section.sectionId  where Class='" + Class + "' AND Section='" + Section + "' ";

            

       // String query ="Select * from ClassTimeTable FULL OUTER JOIN Class ON ClassTimeTable.Class=Class.classId FULL OUTER JOIN Section ON ClassTimeTable.Section=Section.sectionId  where Class=1 AND Section=1";



            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(TimeTable);

            con.Close();
            return TimeTable;
        }

    }
}
