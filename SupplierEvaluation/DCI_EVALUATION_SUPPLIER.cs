using CrystalDecisions.Shared;
using EvaluationSupplier;
using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using CheckBox = System.Windows.Forms.CheckBox;

namespace SupplierEvaluation
{
    public partial class DCI_EVALUATION_SUPPLIER : MetroSetForm
    {
        ConnectDB conDBSCM = new ConnectDB("DBSCM");
        Service service = new Service();
        List<MVender> listVendor = new List<MVender>();
        rptSupplier rpt = new rptSupplier();
        List<string> _SelectedSupplier = new List<string>();
        Dictionary<string, MVender> _DetailVender = new Dictionary<string, MVender>();
        string MonthNameYear = "";
        string _YEAR = "";
        string _MONTH = "";
        string _SUPPLIER_CODE = "";
        string _PATH = "";
        string _VERSION = "1.00";
        string _UID = "";
        public DCI_EVALUATION_SUPPLIER(string UID, string _SYSTEM_CODE)
        {
            InitializeComponent();
            this.Text += " (" + _SYSTEM_CODE + ") (" + _VERSION + ")";
            this.lbUserDetail.Text = UID;
            this._UID = UID;    
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation= true;
        }

        private void DCI_EVALUATION_SUPPLIER_Load(object sender, EventArgs e)
        {
            setFilter();
            setChk();
            Employee emp = service.getUsers(_UID);

            // TEST LEFT JOIN 
            service.testLeftJoin();
            // END LEFT JOIN

            if (emp.TNAME != "undefined")
            {
                this.lbUserDetail.Text = emp.TNAME + " " + emp.TSURN + " (" + emp.CODE + ")";
            }
            listVendor = service.getListVendor();
            foreach (MVender vd in listVendor)
            {
                gvSupplier.Rows.Add(false, vd.VenderName, vd.Vender);
            }
        }

        private void setChk()
        {
            CheckBox cb = new CheckBox();
            cb.Size = new Size(15, 15);
            var cell = gvSupplier.Columns[0].HeaderCell.Size;
            cb.Location = new Point((cell.Width - cb.Size.Width) / 2, (cell.Height - cb.Size.Height) / 2);
            cb.MouseClick += new MouseEventHandler(cb_MouseClick);
            gvSupplier.Controls.Add(cb);
        }

        private void cb_MouseClick(object sender, MouseEventArgs e)
        {
            var chkHeader = (CheckBox)sender;   
            bool checkedAll = chkHeader.Checked;
            foreach(DataGridViewRow row in gvSupplier.Rows)
            {
                //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                row.Selected = false;
                if (checkedAll)
                {
                    row.Cells["SupplierTool"].Value = true;
                }
                else
                {
                    row.Cells["SupplierTool"].Value = false;
                    //row.DefaultCellStyle.ForeColor = System.control;
                }
            }
            gvSupplier.Refresh();
        }

        private void setCulture()
        {
            var culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        private void setFilter()
        {
            for (int i = 0; i <= 5; i++)
            {
                cbYear.Items.Add(DateTime.Now.Year - i);
            }
            cbYear.SelectedIndex = 0;
            string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            foreach (string month in months)
            {
                cbMonth.Items.Add(month);
            }
            cbMonth.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void sendMail(string _MAIL,string _PATH)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("mail.dci.daikin.co.jp");
            SmtpServer.Port = 25;
            SmtpServer.UseDefaultCredentials = false;
            mail.From = new MailAddress("dcialpha-noreply@dci.daikin.co.jp");
            mail.To.Add("peerapong.k@dci.daikin.co.jp");
            //mail.To.Add("peerapong.k@dci.daikin.co.jp,aukit.k@dci.daikin.co.jp");
            mail.Subject = "SUBJECT";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            mail.Body = "BODY";
            Attachment attachment;
            attachment = new Attachment(_PATH);
            mail.Attachments.Add(attachment);
            try
            {
                SmtpServer.Send(mail);
                mail.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                cbMonth.Enabled = false;
                cbYear.Enabled = false;
                gvSupplier.Enabled = false;
                btnSend.Enabled = false;
                _MONTH = (cbMonth.SelectedIndex + 1).ToString();
                _YEAR = cbYear.Text;
                MonthNameYear = cbMonth.Text + "-" + _YEAR;
                _SelectedSupplier = new List<string>();
                foreach(DataGridViewRow rowSupplier in gvSupplier.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)rowSupplier.Cells[0];
                    if ((bool)chk.Value == true)
                    {
                    _SelectedSupplier.Add(rowSupplier.Cells["SupplierCode"].Value.ToString());
                    }
                }
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                backgroundWorker1.CancelAsync();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _DetailVender = service.getListDetailVender(_SelectedSupplier, _YEAR, _MONTH);
            if (_DetailVender.Count > 0)
            {
                int[] monthfocal = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3 };
                int year = Convert.ToInt16(_YEAR);
                int[] yearfocal = { year, year, year, year, year, year, year, year, year, year, year, year };

                for (int i = 0; i < yearfocal.Length; i++)
                {
                    if (Convert.ToInt16(_MONTH) >= 1 && Convert.ToInt16(_MONTH) <= 3)
                    {
                        if (i >= 0 && i <= 8)
                        {
                            yearfocal[i] = yearfocal[i] - 1;
                        }
                    }
                    else if (Convert.ToInt16(_MONTH) >= 4 && Convert.ToInt16(_MONTH) <= 12)
                    {
                        if (i >= 9 && i <= 11)
                        {
                            yearfocal[i] = yearfocal[i] + 1;
                        }
                    }
                }
                string[] pointEachMonth = new string[13];
                string[] gradeEachMonth = new string[13];
                int step = 100 / _DetailVender.Count;
                int process = 0;
                foreach (KeyValuePair<string, MVender> item in _DetailVender)
                {
                    
                    MVender vdDetail = item.Value;
                    DataTable dtData = vdDetail.Data;
                    _PATH = vdDetail.Path;
                    _SUPPLIER_CODE = item.Key;
                    SqlCommand sql = new SqlCommand();
                    for (int i = 0; i < 12; i++)
                    {
                        sql.CommandText = "SELECT [result_point],[result_grade] FROM [PU_EvaluateSupplierResult]" +
                                " WHERE datayear = '" + yearfocal[i] + "' AND datamonth = '" + monthfocal[i] + "' " +
                                " AND [SupplierNO] = '" + _SUPPLIER_CODE + "'";
                        DataTable dtable = new DataTable();
                        dtable = conDBSCM.Query(sql);
                        if (dtable.Rows.Count > 0)
                        {
                            pointEachMonth[i] = dtable.Rows[0]["result_point"].ToString() == "" ? "-" : Math.Round(Convert.ToDecimal(dtable.Rows[0]["result_point"].ToString()), 0).ToString();
                            gradeEachMonth[i] = dtable.Rows[0]["result_grade"].ToString();
                            int monthselect = 0;
                            int yearselect = 0;
                            try
                            {
                                monthselect = Convert.ToInt16(_MONTH);
                            }
                            catch { }

                            try
                            {
                                yearselect = Convert.ToInt16(_YEAR);
                            }
                            catch { }

                            if (monthfocal[i] > monthselect && yearfocal[i] == yearselect)
                            {
                                pointEachMonth[i] = "-";
                                gradeEachMonth[i] = "-";
                            }
                        }
                        else
                        {
                            pointEachMonth[i] = "-";
                            gradeEachMonth[i] = "-";
                        }
                    }
                    if (dtData.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("VendorName", vdDetail.VenderName);
                        rpt.SetParameterValue("MonthYearName", MonthNameYear);
                        rpt.SetParameterValue("VendorAdd", _SUPPLIER_CODE);
                        rpt.SetParameterValue("InCharge", vdDetail.PersonIncharge);
                        rpt.SetParameterValue("NameForm", "");
                        rpt.SetParameterValue("TotalA", dtData.Rows[0]["minus_A"].ToString() == "0" ? "-" : dtData.Rows[0]["minus_A"].ToString());
                        rpt.SetParameterValue("TotalB", dtData.Rows[0]["minus_B"].ToString() == "0" ? "-" : dtData.Rows[0]["minus_B"].ToString());
                        rpt.SetParameterValue("TotalC", dtData.Rows[0]["minus_C"].ToString() == "0" ? "-" : dtData.Rows[0]["minus_C"].ToString());
                        rpt.SetParameterValue("TotalD", dtData.Rows[0]["minus_D"].ToString() == "0" ? "-" : dtData.Rows[0]["minus_D"].ToString());
                        rpt.SetParameterValue("TotalPoint", dtData.Rows[0]["result_score"].ToString());
                        rpt.SetParameterValue("QtyA1", dtData.Rows[0]["count_A1"].ToString() == "0" ? "-" : dtData.Rows[0]["count_A1"].ToString());
                        rpt.SetParameterValue("QtyA2", dtData.Rows[0]["count_A2"].ToString() == "0" ? "-" : dtData.Rows[0]["count_A2"].ToString());
                        rpt.SetParameterValue("QtyA3", dtData.Rows[0]["count_A3"].ToString() == "0" ? "-" : dtData.Rows[0]["count_A3"].ToString());
                        rpt.SetParameterValue("ScoreA1", dtData.Rows[0]["sumA1"].ToString());
                        rpt.SetParameterValue("ScoreA2", dtData.Rows[0]["sumA2"].ToString());
                        rpt.SetParameterValue("ScoreA3", dtData.Rows[0]["sumA3"].ToString());
                        rpt.SetParameterValue("ResultGrade", dtData.Rows[0]["result_grade"].ToString());
                        rpt.SetParameterValue("QtyB1", dtData.Rows[0]["count_B1"].ToString() == "0" ? "-" : dtData.Rows[0]["count_B1"].ToString());
                        rpt.SetParameterValue("QtyB2", dtData.Rows[0]["count_B2"].ToString() == "0" ? "-" : dtData.Rows[0]["count_B2"].ToString());
                        rpt.SetParameterValue("QtyB3", dtData.Rows[0]["count_B3"].ToString() == "0" ? "-" : dtData.Rows[0]["count_B3"].ToString());
                        rpt.SetParameterValue("ScoreB1", dtData.Rows[0]["sumB1"].ToString());
                        rpt.SetParameterValue("ScoreB2", dtData.Rows[0]["sumB2"].ToString());
                        rpt.SetParameterValue("ScoreB3", dtData.Rows[0]["sumB3"].ToString());
                        rpt.SetParameterValue("QtyC1", dtData.Rows[0]["count_C1"].ToString() == "0" ? "-" : dtData.Rows[0]["count_C1"].ToString());
                        rpt.SetParameterValue("QtyC2", dtData.Rows[0]["count_C2"].ToString() == "0" ? "-" : dtData.Rows[0]["count_C2"].ToString());
                        rpt.SetParameterValue("ScoreC1", dtData.Rows[0]["sumC1"].ToString());
                        rpt.SetParameterValue("ScoreC2", dtData.Rows[0]["sumC2"].ToString());
                        rpt.SetParameterValue("QtyD1", dtData.Rows[0]["count_D1"].ToString() == "0" ? "-" : dtData.Rows[0]["count_D1"].ToString());
                        rpt.SetParameterValue("QtyD2", dtData.Rows[0]["count_D2"].ToString() == "0" ? "-" : dtData.Rows[0]["count_D2"].ToString());
                        rpt.SetParameterValue("QtyD3", dtData.Rows[0]["count_D3"].ToString() == "0" ? "-" : dtData.Rows[0]["count_D3"].ToString());
                        rpt.SetParameterValue("ScoreD1", dtData.Rows[0]["sumD1"].ToString());
                        rpt.SetParameterValue("ScoreD2", dtData.Rows[0]["sumD2"].ToString());
                        rpt.SetParameterValue("ScoreD3", dtData.Rows[0]["sumD3"].ToString());
                        rpt.SetParameterValue("GradeMonth1", gradeEachMonth[0]);
                        rpt.SetParameterValue("GradeMonth2", gradeEachMonth[1]);
                        rpt.SetParameterValue("GradeMonth3", gradeEachMonth[2]);
                        rpt.SetParameterValue("GradeMonth4", gradeEachMonth[3]);
                        rpt.SetParameterValue("GradeMonth5", gradeEachMonth[4]);
                        rpt.SetParameterValue("GradeMonth6", gradeEachMonth[5]);
                        rpt.SetParameterValue("GradeMonth7", gradeEachMonth[6]);
                        rpt.SetParameterValue("GradeMonth8", gradeEachMonth[7]);
                        rpt.SetParameterValue("GradeMonth9", gradeEachMonth[8]);
                        rpt.SetParameterValue("GradeMonth10", gradeEachMonth[9]);
                        rpt.SetParameterValue("GradeMonth11", gradeEachMonth[10]);
                        rpt.SetParameterValue("GradeMonth12", gradeEachMonth[11]);
                        rpt.SetParameterValue("PointMonth1", pointEachMonth[0]);
                        rpt.SetParameterValue("PointMonth2", pointEachMonth[1]);
                        rpt.SetParameterValue("PointMonth3", pointEachMonth[2]);
                        rpt.SetParameterValue("PointMonth4", pointEachMonth[3]);
                        rpt.SetParameterValue("PointMonth5", pointEachMonth[4]);
                        rpt.SetParameterValue("PointMonth6", pointEachMonth[5]);
                        rpt.SetParameterValue("PointMonth7", pointEachMonth[6]);
                        rpt.SetParameterValue("PointMonth8", pointEachMonth[7]);
                        rpt.SetParameterValue("PointMonth9", pointEachMonth[8]);
                        rpt.SetParameterValue("PointMonth10", pointEachMonth[9]);
                        rpt.SetParameterValue("PointMonth11", pointEachMonth[10]);
                        rpt.SetParameterValue("PointMonth12", pointEachMonth[11]);
                        if (File.Exists(_PATH))
                            File.Delete(_PATH);
                        rpt.ExportToDisk(ExportFormatType.PortableDocFormat, _PATH);
                        if (File.Exists(_PATH))
                        {
                            sendMail(vdDetail.EmailPo, _PATH);
                            backgroundWorker1.ReportProgress(process);
                            process += step;
                        }
                    }
                    else
                    {
                        MSupplier supplierDetail = service.getDetailSupplier(_SUPPLIER_CODE);
                        rptEvaluateOneSupplier repEmpty = new rptEvaluateOneSupplier();
                        repEmpty.SetParameterValue("VendorName", supplierDetail.SupplierName);
                        repEmpty.SetParameterValue("MonthYearName", MonthNameYear);
                        repEmpty.SetParameterValue("VendorCode", _SUPPLIER_CODE);
                        repEmpty.SetParameterValue("InCharge", "");
                        repEmpty.SetParameterValue("NameForm", "");
                        if (File.Exists(_PATH))
                            File.Delete(_PATH);
                        repEmpty.ExportToDisk(ExportFormatType.PortableDocFormat, _PATH);
                        if (File.Exists(_PATH))
                        {
                            sendMail(vdDetail.EmailPo, _PATH);
                            backgroundWorker1.ReportProgress(process);
                            process += step;
                        }
                    }
                }
                backgroundWorker1.ReportProgress(100);
            }
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cbMonth.Enabled = true;
            cbYear.Enabled = true;
            gvSupplier.Enabled = true;
            btnSend.Enabled = true;
            MessageBox.Show("Send Email Supplier Delivery Evaluate Success");
        }

        private void gvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                bool chk = (bool)gvSupplier.Rows[e.RowIndex].Cells[0].Value;
                if (chk)
                {
                    gvSupplier.Rows[e.RowIndex].Cells[0].Value = false;
                   
                }
                else
                {
                    gvSupplier.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.label1.Text = (e.ProgressPercentage.ToString() + "%");
            progressBar1.Value = e.ProgressPercentage;
        }

        private void cbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled= true;
        }
    }
}
