using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Entities
{
    public class Student
    {


        // for datesheet screen

        public string classForDateSheet { get; set; }
        public int termOfClass { get; set; }

        public string xmlRecord { get; set; }

        //

        // for View Results Screen
        public string currentClass { get; set; }
        public string currentSection { get; set; }

        // for View Results Screen

        // for subjects scrren
        public string subject { get; set; }
        // for subjects scrren



        //Form1

        public string Image { get; set; }
        public String Name { get; set; }
        public String Father { get; set; }
        public DateTime DOB { get; set; }
        public String Place { get; set; }
        public String BForm { get; set; }
        public String Blood { get; set; }
        public String Gender { get; set; }
        public String FCnic { get; set; }
        public String FOccupation { get; set; }
        public String FIncome { get; set; }
        public String Religion { get; set; }
        public String GName { get; set; }
        public String GCnic { get; set; }
        public String GEducation { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }
        public String HomeTel { get; set; }
        public String Hostel { get; set; }
        public String Care { get; set; }
        public String Address { get; set; }

        //Form2
        public String PInstitutionName { get; set; }
        public String PAdmissionId { get; set; }
        public String PInstitutionAddress { get; set; }
        public String PInstitutionClass { get; set; }
        public String PInstitutionCertificate { get; set; }
        public String Curricular { get; set; }
        public String SiblingName1 { get; set; }
        public String SiblingStatus1 { get; set; }
        public String SiblingId1 { get; set; }
        public String SiblingName2 { get; set; }
        public String SiblingStatus2 { get; set; }
        public String SiblingId2 { get; set; }
        public String SiblingName3 { get; set; }
        public String SiblingStatus3 { get; set; }
        public String SiblingId3 { get; set; }


        //Form3
        public String Class { get; set; }
        public String Section { get; set; }
        public String ClassGroup { get; set; }
        public String Medium { get; set; }
        public String AdmissionId { get; set; }
        public String Session { get; set; }
        public int FeeStatus { get; set; }
        public String FamilyNo { get; set; }
        public DateTime AdmissionDate { get; set; }
        public String Remarks { get; set; }
        public String Approval { get; set; }


    }
}
