using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.DAL;
using SchoolManagementSystem.Entities;
using System.Data;

namespace SchoolManagementSystem.Bll
{
    public class Fees_bll
    {
        public DataTable ShowSetFess()
        {

            DataTable Show = new DataTable();

            Fees_dal dal = new Fees_dal();
            Show = dal.ShowSetFess();


            return Show;





        }
        public DataTable FeeCollection(string Class, string Section, int mnth)
        {
            DataTable Collection = new DataTable();

            Fees_dal dal = new Fees_dal();
            Collection = dal.FeeCollection(Class, Section, mnth);


            return Collection;


        }



        public void AddFeesCollection_bll(DataTable dt)
        {
            Fees_dal dal = new Fees_dal();
            dal.AddFeesCollection_dll(dt);





        }




        public DataTable FeeDefaulters(string Class, string Section, int mnth)
        {
            DataTable Defaulters = new DataTable();

            Fees_dal dal = new Fees_dal();
            Defaulters = dal.FeeDefaulters(Class, Section, mnth);


            return Defaulters;


        }

        public DataTable AllFeeDefaulters(int mnth)
        {
            DataTable Defaulters = new DataTable();

            Fees_dal dal = new Fees_dal();
            Defaulters = dal.AllFeeDefaulters(mnth);


            return Defaulters;


        }



        public void SendEmailToOne(String AddmissionId, int month)
        {
            Fees_dal dal = new Fees_dal();

            dal.SendEmailToOne(AddmissionId, month);

        }

        public void SendEmailToAll(DataTable dt, int month)
        {
            Fees_dal dal = new Fees_dal();

            dal.SendEmailToAll(dt, month);

        }

        public DataTable DailyFeeDetails(String Date)
        {
            Fees_dal dal = new Fees_dal();
            DataTable dt = new DataTable();
            dt = dal.DailyFeeDetails(Date);


            return dt;
        }


        public DataTable MonthlyFeeDetails(int month)
        {
            Fees_dal dal = new Fees_dal();
            DataTable dt = new DataTable();
            dt = dal.MonthlyFeeDetails(month);


            return dt;
        }


        public DataTable YearlyFeeDetailsOnLoad(String Year)
        {
            Fees_dal dal = new Fees_dal();
            DataTable dt = new DataTable();
            dt = dal.YearlyFeeDetailsOnLoad(Year);


            return dt;
        }

        public DataTable GetAllYear()
        {
            Fees_dal dal = new Fees_dal();
            DataTable dt = new DataTable();
            dt = dal.GetAllYear();

            return dt;




        }


    }
}
