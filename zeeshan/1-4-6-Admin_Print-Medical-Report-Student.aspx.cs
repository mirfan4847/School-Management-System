using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using SchoolManagementSystem.Entities;

namespace Future
{
    public partial class _1_4_6_Admin_Print_Medical_Report_Student : System.Web.UI.Page
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
            
        }

        public void ClearField()
        {
            txtAdminId.Text = "";
            txtName.Text = "";
            txtFather.Text = "";
            txtEmergencyName1.Text = "";
            txtEmergencyName2.Text = "";
            txtHomeTel1.Text = "";
            txtHomeTel2.Text = "";
            txtMobile1.Text = "";
            txtMobile2.Text = "";
            chkChickenPox.Checked = false;
            chkDiabetes.Checked = false;
            chkEczema.Checked = false;
            chkMumps.Checked = false;
            chkAsthma.Checked = false;
            chkRheumatic.Checked = false;
            chkEpilepsy.Checked = false;
            chkBlood.Checked = false;
            chkSpeech.Checked = false;
            chkNoProb.Checked = false;
            txtChronicDetails.Text = "";
            txtChronicDetails.Visible = false;
            txtTB.Text = "";
            txtEpilepsy.Text = "";
            txtDiabetes.Text = "";
            txtOthers.Text = "";
            txtDate.Text = "";
            chkYes.Checked = false;
            chkNo.Checked = false;



        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string SearchID;
            ClearField();

            SearchID = txtSearchAdmission.Text;

            Admission_bll bll = new Admission_bll();

            DataTable SMedicalEdit = new DataTable();


            SMedicalEdit = bll.SMedicalEditShow_bll(SearchID);

            if (SMedicalEdit.Rows.Count == 1)
            {

                txtAdminId.Text = SMedicalEdit.Rows[0]["AdmissionId"].ToString();
                txtName.Text = SMedicalEdit.Rows[0]["Name"].ToString();
                txtFather.Text = SMedicalEdit.Rows[0]["Father"].ToString();

                txtEmergencyName1.Text = SMedicalEdit.Rows[0]["Name1"].ToString();
                txtEmergencyName2.Text = SMedicalEdit.Rows[0]["Name2"].ToString();
                txtHomeTel1.Text = SMedicalEdit.Rows[0]["Hometel1"].ToString();
                txtHomeTel2.Text = SMedicalEdit.Rows[0]["Hometel2"].ToString();
                txtMobile1.Text = SMedicalEdit.Rows[0]["Mobile1"].ToString();
                txtMobile2.Text = SMedicalEdit.Rows[0]["Mobile2"].ToString();

                if ("True" == SMedicalEdit.Rows[0]["ChickenPox"].ToString())
                {
                    chkChickenPox.Checked = true;
                }
                else
                {
                    chkChickenPox.Checked = false;
                }

                if ("True" == SMedicalEdit.Rows[0]["Diabetes"].ToString())
                {
                    chkDiabetes.Checked = true;
                }
                else
                {
                    chkDiabetes.Checked = false;
                }





                if ("True" == SMedicalEdit.Rows[0]["Eczema"].ToString())
                {
                    chkEczema.Checked = true;
                }
                else
                {
                    chkEczema.Checked = false;
                }

                if ("True" == SMedicalEdit.Rows[0]["Mumps"].ToString())
                {
                    chkMumps.Checked = true;
                }
                else
                {
                    chkMumps.Checked = false;
                }
                chkAsthma.Checked = false;
                if ("True" == SMedicalEdit.Rows[0]["Asthma"].ToString())
                {
                    chkAsthma.Checked = true;
                }
                else
                {
                    chkAsthma.Checked = false;
                }
                if ("True" == SMedicalEdit.Rows[0]["Rheumatic"].ToString())
                {
                    chkRheumatic.Checked = true;
                }
                else
                {
                    chkRheumatic.Checked = false;
                }
                if ("True" == SMedicalEdit.Rows[0]["Epilepsy"].ToString())
                {
                    chkEpilepsy.Checked = true;
                }
                else
                {
                    chkEpilepsy.Checked = false;
                }
                if ("True" == SMedicalEdit.Rows[0]["Blood"].ToString())
                {
                    chkBlood.Checked = true;
                }
                else
                {
                    chkBlood.Checked = false;
                }
                if ("True" == SMedicalEdit.Rows[0]["Speech"].ToString())
                {
                    chkSpeech.Checked = true;
                }
                else
                {
                    chkSpeech.Checked = false;
                }
                if ("True" == SMedicalEdit.Rows[0]["NoProblem"].ToString())
                {
                    chkNoProb.Checked = true;
                }
                else
                {
                    chkNoProb.Checked = false;
                }

                String chronic = SMedicalEdit.Rows[0]["StudentChronicleDetails"].ToString();

                if (chronic != "")
                {
                    chkYes.Checked = true;
                    txtChronicDetails.Visible = true;
                    txtChronicDetails.Text = chronic;
                    chkNo.Checked = false;
                }
                else
                {
                    chkNo.Checked = true;
                    chkYes.Checked = false;
                    txtChronicDetails.Text = "";
                    txtChronicDetails.Visible = false;
                }


                txtTB.Text = SMedicalEdit.Rows[0]["FamilyTB"].ToString();
                txtEpilepsy.Text = SMedicalEdit.Rows[0]["FamilyEpilespsy"].ToString();
                txtDiabetes.Text = SMedicalEdit.Rows[0]["FamilyDiabetes"].ToString();
                txtOthers.Text = SMedicalEdit.Rows[0]["FamilyOthers"].ToString();
                // txtDate.Text = SMedicalEdit.Rows[0]["Date"].ToString();



            }

            else
            {
                ClearField();
                lblStudentIdNotFound.Text = "Student Record Not Found";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                //upModal.Update();

            }

        }


        protected void chkNoProb_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoProb.Checked)
            {
                chkChickenPox.Checked = false;
                chkDiabetes.Checked = false;
                chkEczema.Checked = false;
                chkMumps.Checked = false;
                chkAsthma.Checked = false;
                chkRheumatic.Checked = false;
                chkEpilepsy.Checked = false;
                chkBlood.Checked = false;
                chkSpeech.Checked = false;


            }
        }

        protected void chkChickenPox_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChickenPox.Checked)
            {
                if (chkNoProb.Checked == true)
                {
                    chkNoProb.Checked = false;

                }


            }
        }

        protected void chkDiabetes_CheckedChanged(object sender, EventArgs e)
        {

            if (chkDiabetes.Checked)
            {
                if (chkNoProb.Checked == true)
                {
                    chkNoProb.Checked = false;

                }


            }
        }

        protected void chkEczema_CheckedChanged(object sender, EventArgs e)
        {

            if (chkEczema.Checked)
            {
                if (chkNoProb.Checked == true)
                {
                    chkNoProb.Checked = false;

                }


            }
        }

        protected void chkMumps_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMumps.Checked)
            {
                if (chkNoProb.Checked == true)
                {
                    chkNoProb.Checked = false;

                }


            }
        }

        protected void chkAsthma_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAsthma.Checked)
            {
                if (chkNoProb.Checked == true)
                {
                    chkNoProb.Checked = false;

                }


            }
        }

        protected void chkRheumatic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRheumatic.Checked)
            {
                if (chkNoProb.Checked == true)
                {
                    chkNoProb.Checked = false;

                }


            }
        }

        protected void chkEpilepsy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEpilepsy.Checked)
            {
                if (chkNoProb.Checked == true)
                {
                    chkNoProb.Checked = false;

                }


            }
        }

        protected void chkBlood_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBlood.Checked)
            {
                if (chkNoProb.Checked == true)
                {
                    chkNoProb.Checked = false;

                }


            }
        }

        protected void chkSpeech_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpeech.Checked)
            {
                if (chkNoProb.Checked == true)
                {
                    chkNoProb.Checked = false;

                }



            }
        }

        protected void chkYes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYes.Checked)
            {
                txtChronicDetails.Visible = true;
                chkNo.Checked = false;
            }
            else
            {
                txtChronicDetails.Visible = false;
                chkNo.Checked = false;

            }
        }

        protected void chkNo_CheckedChanged(object sender, EventArgs e)
        {
            txtChronicDetails.Visible = false;
            chkYes.Checked = false;


        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Father");
            dt.Columns.Add("AdminId");
            dt.Columns.Add("Name1");
            dt.Columns.Add("Hometel1");
            dt.Columns.Add("Mobile1");
            dt.Columns.Add("Name2");
            dt.Columns.Add("HomeTel2");
            dt.Columns.Add("Mobile2");
            dt.Columns.Add("StudentChronicleDetails");
            dt.Columns.Add("FamilyTB");
            dt.Columns.Add("FamilyEpilespsy");
            dt.Columns.Add("FamilyDiabetes");
            dt.Columns.Add("FamilyOthers");
            dt.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            dt.Columns.Add("ChickenPox");
            dt.Columns.Add("Diabetes");
            dt.Columns.Add("Eczema");
            dt.Columns.Add("Mumps");
            dt.Columns.Add("Asthma");
            dt.Columns.Add("Rheumatic");
            dt.Columns.Add("Epilepsy");
            dt.Columns.Add("Blood");
            dt.Columns.Add("Speech");
            dt.Columns.Add("NoProblem");

            String ChickenPox;
            String Diabetes;
            String Eczema;
            String Mumps;
            String Asthma;
            String Rheumatic;
            String Epilepsy;
            String Blood;
            String Speech;
            String NoProblem;

            if (chkChickenPox.Checked)
            {
                ChickenPox = "True";

            }
            else
            {
                ChickenPox = "False";
            }

            if (chkDiabetes.Checked)
            {
                Diabetes = "True";

            }
            else
            {
                Diabetes = "False";
            }

            if (chkEczema.Checked)
            {
                Eczema = "True";

            }
            else
            {
                Eczema = "False";
            }
            if (chkMumps.Checked)
            {
                Mumps = "True";

            }
            else
            {
                Mumps = "False";
            }
            if (chkAsthma.Checked)
            {
                Asthma = "True";

            }
            else
            {
                Asthma = "False";
            }
            if (chkRheumatic.Checked)
            {
                Rheumatic = "True";

            }
            else
            {
                Rheumatic = "False";
            }

            if (chkEpilepsy.Checked)
            {
                Epilepsy = "True";

            }
            else
            {
                Epilepsy = "False";
            }
            if (chkBlood.Checked)
            {
                Blood = "True";

            }
            else
            {
                Blood = "False";
            }
            if (chkSpeech.Checked)
            {
                Speech = "True";

            }
            else
            {
                Speech = "False";
            }


            if (chkNoProb.Checked)
            {
                NoProblem = "True";

            }
            else
            {
                NoProblem = "False";
            }


            // dt.Columns.Add(new DataColumn("zeeshan", typeof(Boolean)));
            dt.Rows.Add(txtName.Text, txtFather.Text, txtAdminId.Text, txtEmergencyName1.Text, txtHomeTel1.Text, txtMobile1.Text, txtEmergencyName2.Text, txtHomeTel2.Text, txtMobile2.Text, txtChronicDetails.Text, txtTB.Text, txtEpilepsy.Text, txtDiabetes.Text, txtOthers.Text, txtDate.Text, ChickenPox, Diabetes, Eczema, Mumps, Asthma, Rheumatic, Epilepsy, Blood, Speech, NoProblem);

            Session["Medical-Report"] = dt;

            Response.Redirect("~/Report-Student-Medical.aspx");

        }
    }
}