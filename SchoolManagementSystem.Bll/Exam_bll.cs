using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Entities;
using SchoolManagementSystem.DAL;
namespace SchoolManagementSystem.Bll
{
  public  class Exam_bll
    {

        public DataTable getSection()
        {
            DataTable Section = new DataTable();
            Exam_dll dll = new Exam_dll();
            Section = dll.getSection();
            return Section;
        }
        public DataTable getClasses()
        {
            DataTable Classes = new DataTable();
            Exam_dll dll = new Exam_dll();
            Classes = dll.getClasses();
            return Classes;
        }
      public DataTable EnterMarks(String Class,String Section,int term)
      {
          DataTable dt = new DataTable();

          Exam_dll dll = new Exam_dll();
          dt = dll.EnterMarks(Class, Section, term);
          return dt;




      }


      public void UpdateEnterMarks(DataTable dt)
      {
          Exam_dll dll = new Exam_dll();
          dll.UpdateEnterMarks(dt);






      }
      public void insertGrades(DataTable dt)
      {
          Exam_dll dll = new Exam_dll();
          dll.insertGrades(dt);
      }

      public DataTable setSubject(Student st)
      {
          DataTable dt = new DataTable();
          Exam_dll dll = new Exam_dll();
          dt = dll.setSubjects(st);
          return dt;
      }

      public DataTable setDateSheet(Student st)
      {
          DataTable dt = new DataTable();
          Exam_dll dll = new Exam_dll();
          dt = dll.setDateSheet(st);
          return dt;
      }

      public DataTable selectDateSheet(Student st)
      {
          DataTable dt = new DataTable();
          Exam_dll dll = new Exam_dll();
          dt = dll.selectDateSheet(st);
          return dt;
      }
      public void insertDateSheet(Student st)
      {
          Exam_dll dll = new Exam_dll();
          dll.insertDateSheetDll(st);
      }

      public DataTable getFailedStudents(Student st)
      {
          DataTable result = new DataTable();
          Exam_dll dll = new Exam_dll();
          result = dll.getFailedStudents(st);
          return result;
      }

      public DataTable getPromotedStudents(Student st)
      {
          DataTable result = new DataTable();
          Exam_dll dll = new Exam_dll();
          result = dll.getPromotedStudents(st);
          return result;

      }

      public DataTable ViewMarks(String Class, String Section, int term)
      {
          DataTable dt = new DataTable();

          Exam_dll dll = new Exam_dll();
          dt = dll.ViewMarks(Class, Section, term);
          return dt;




      }

      public void SendEmailToOne(String AddmissionId,String cls,String section, int term)
      {

          Exam_dll dal = new Exam_dll();

          dal.SendEmailToOne(AddmissionId, cls, section, term);

      }

      public void SendEmailToAll(DataTable dt,string cls,string section, int term)
      {
          Exam_dll dal = new Exam_dll();
          

          dal.SendEmailToAll(dt,cls,section,term);

      }

      public void SendEmailToOneFail(String AddmissionId, String cls, String section, int term)
      {

          Exam_dll dal = new Exam_dll();

          dal.SendEmailToOneFail(AddmissionId, cls, section, term);

      }

      public void SendEmailToAllFail(DataTable dt, string cls, string section, int term)
      {
          Exam_dll dal = new Exam_dll();


          dal.SendEmailToAllFail(dt, cls, section, term);

      }

      public DataTable getPositionHolders(string Class,int term)

      {

          DataTable result = new DataTable();
          Exam_dll dll = new Exam_dll();
          result = dll.getPositionHolders(Class, term);
          return result;
      }

    }
}
