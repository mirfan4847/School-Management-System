using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using SchoolManagementSystem.Entities;
using System.Data;

namespace Future
{
    public partial class _1_4_5_Admin_Edit_Medical_Report_Student : System.Web.UI.Page
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
        public String SearchID { get; set; }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
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

                String chronic=SMedicalEdit.Rows[0]["StudentChronicleDetails"].ToString();

                if (chronic!="")
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
                txtDate.Text = SMedicalEdit.Rows[0]["Date"].ToString();
                


            }

            else
            {
                ClearField();
                lblStudentIdNotFound.Text = "Student Record Not Found";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                //upModal.Update();
               
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Medical med = new Medical();


            if (chkNoProb.Checked == false)
            {

                med.Name1 = txtEmergencyName1.Text;
                med.Hometel1 = txtHomeTel1.Text;
                med.Mobile1 = txtMobile1.Text;
                med.Name2 = txtEmergencyName2.Text;
                med.HomeTel2 = txtHomeTel2.Text;
                if (chkChickenPox.Checked)
                {
                    med.ChickenPox = "True";

                }
                else
                {
                    med.ChickenPox = "False";
                }

                if (chkDiabetes.Checked)
                {
                    med.Diabetes = "True";

                }
                else
                {
                    med.Diabetes = "False";
                }

                if (chkEczema.Checked)
                {
                    med.Eczema = "True";

                }
                else
                {
                    med.Eczema = "False";
                }
                if (chkMumps.Checked)
                {
                    med.Mumps = "True";

                }
                else
                {
                    med.Mumps = "False";
                }
                if (chkAsthma.Checked)
                {
                    med.Asthma = "True";

                }
                else
                {
                    med.Asthma = "False";
                }
                if (chkRheumatic.Checked)
                {
                    med.Rheumatic = "True";

                }
                else
                {
                    med.Rheumatic = "False";
                }

                if (chkEpilepsy.Checked)
                {
                    med.Epilepsy = "True";

                }
                else
                {
                    med.Epilepsy = "False";
                }
                if (chkBlood.Checked)
                {
                    med.Blood = "True";

                }
                else
                {
                    med.Blood = "False";
                }
                if (chkSpeech.Checked)
                {
                    med.Speech = "True";

                }
                else
                {
                    med.Speech = "False";
                }

                med.NoProblem = "False";

                med.StudentChronicleDetails = txtChronicDetails.Text;
                med.FamilyTB = txtTB.Text;
                med.FamilyEpilespsy = txtEpilepsy.Text;
                med.FamilyDiabetes = txtTB.Text;
                med.FamilyOthers = txtOthers.Text;
                med.Date = Convert.ToDateTime(txtDate.Text);

                med.AdmisionId = txtAdminId.Text;

            }

            else if (chkNoProb.Checked == true)
            {
                med.Name1 = txtEmergencyName1.Text;
                med.Hometel1 = txtHomeTel1.Text;
                med.Mobile1 = txtMobile1.Text;
                med.Name2 = txtEmergencyName2.Text;
                med.HomeTel2 = txtHomeTel2.Text;
                med.NoProblem = "True";
                med.ChickenPox = "False";
                med.Diabetes = "False";
                med.Eczema = "False";
                med.Mumps = "False";
                med.Asthma = "False";
                med.Rheumatic = "False";
                med.Epilepsy = "False";
                med.Blood = "False";
                med.Speech = "False";
                med.StudentChronicleDetails = txtChronicDetails.Text;
                med.FamilyTB = txtTB.Text;
                med.FamilyEpilespsy = txtEpilepsy.Text;
                med.FamilyDiabetes = txtTB.Text;
                med.FamilyOthers = txtOthers.Text;
                med.Date = Convert.ToDateTime(txtDate.Text);


                med.AdmisionId = txtAdminId.Text;




            }
            Admission_bll bll = new Admission_bll();
            bll.EditMedicalReport_bll(med);

            ClearField();



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
    }
}