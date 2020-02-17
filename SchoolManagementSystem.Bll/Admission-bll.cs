using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Entities;
using SchoolManagementSystem.DAL;
using System.Data;

namespace SchoolManagementSystem.Bll
{
    public class Admission_bll
    {

        public DataTable FeesOnload(string className)
        {
            DataTable Fees = new DataTable();
            Admission_dal dal = new Admission_dal();
            Fees = dal.FeesOnLoad(className);

            return Fees;



        }
        public DataTable ClassOnload()
        {
            DataTable Class = new DataTable();
            Admission_dal dal = new Admission_dal();
            Class = dal.ClassOnload();



            return Class;
        }
        public DataTable SectionOnload()
        {
            DataTable Section = new DataTable();
            Admission_dal dal = new Admission_dal();

            Section = dal.SectionOnload();


            return Section;
        }
        public void AddStudent_bll(Student addstu)
        {
            Admission_dal dal = new Admission_dal();
            dal.AddStudent_dal(addstu);


        }


        public DataTable EditStudent_bll(String SearchID)
        {

            DataTable edit = new DataTable();

            Admission_dal dal = new Admission_dal();


            edit = dal.EditStudent_dal(SearchID);

            return edit;


        }

        public void UpdateStudent_bll(Student update, string student)
        {

            Admission_dal dal = new Admission_dal();
            dal.UpdateStudent_dal(update, student);



        }


        public DataTable InstituteRule_bll(String SearchID)
        {
            Admission_dal dal = new Admission_dal();
            DataTable rules = new DataTable();

            rules = dal.InstituteRules_dal(SearchID);

            return rules;



        }


        public DataTable SMedical_bll(String SearchID)
        {
            Admission_dal dal = new Admission_dal();
            DataTable SMedical = new DataTable();

            SMedical = dal.SMedical_dal(SearchID);

            return SMedical;




        }

        public DataTable Duplicate_Medical_bll(String AdmissionId)
        {
            DataTable dt = new DataTable();

            Admission_dal dal = new Admission_dal();
            dt = dal.Duplicate_Medical_dal(AdmissionId);



            return dt;

        }


        public void AddMedicalReport_bll(Medical med)
        {

            Admission_dal dal = new Admission_dal();

            dal.AddMedicalReport_dal(med);


        }



        public DataTable SMedicalEditShow_bll(String SearchID)
        {
            Admission_dal dal = new Admission_dal();
            DataTable SMedicalEdit = new DataTable();

            SMedicalEdit = dal.SMedicalEditShow_dal(SearchID);

            return SMedicalEdit;

        }
        public void EditMedicalReport_bll(Medical med)
        {

            Admission_dal dal = new Admission_dal();

            dal.EditMedicalReport_dal(med);


        }

        public DataTable SchoolLeaving(String Id)
        {
            DataTable dt = new DataTable();
            Admission_dal dal = new Admission_dal();
            dt = dal.SchoolLeaving(Id);
            return dt;



        }
        public DataTable SchoolCharacter(string Id)
        {
            DataTable dt = new DataTable();
            Admission_dal dal = new Admission_dal();
            dt = dal.SchoolCharacter(Id);
            return dt;

        }


        public DataTable ClassTimeTable(String Class, String Section)
        {

            DataTable TimeTable = new DataTable();

            Admission_dal dal = new Admission_dal();

            TimeTable = dal.ClassTimeTable(Class, Section);


            return TimeTable;


        }

        public DataTable TeacherTimeTable(String Teacher)
        {

            DataTable TimeTable = new DataTable();

            Admission_dal dal = new Admission_dal();

            TimeTable = dal.TeacherTimeTable(Teacher);


            return TimeTable;


        }




    }
}
