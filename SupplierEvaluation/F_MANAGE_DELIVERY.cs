using CrystalDecisions.Shared;
using EvaluationSupplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SupplierEvaluation
{
    public partial class F_MANAGE_DELIVERY : Form
    {
        private string _VER = "1.0"; // 1.0 First Imp
        Service service = new Service();
        List<MEvaluate> listEva = new List<MEvaluate>();
        List<MVender> listVender = new List<MVender>();
        private MUser mUser = new MUser();
        public string _YEAR = "";
        public string _MONTH = "";
        public int _MONTH_INDEX = 0;
        public string _VD_NAME = "";
        public string _VD_CODE = "";
        public int _VD_INDEX = 0;
        private string _UID = "";
        private string _SYSID = "";
        public F_MANAGE_DELIVERY(string UID,string SYSID)
        {
            InitializeComponent();
            _UID = UID;
            _SYSID = SYSID;
        }

        public F_MANAGE_DELIVERY()
        {
            InitializeComponent();
        }

        private void btnAddEvaluation_Click(object sender, EventArgs e)
        {
            F_ADD_EVALUATE fAddEva = new F_ADD_EVALUATE(_UID,this);
            fAddEva.ShowDialog();
        }

        public void refreshGvEvaluete(int indexVdCode)
        {
            cbVender.SelectedIndex = indexVdCode;
            _VD_CODE = listVender[indexVdCode-1].Vender;
            initGvEvaluate();
        }

        private void F_MANAGE_DELIVERY_Load(object sender, EventArgs e)
        {
            this.Text += " (" + _SYSID + ") (" + _VER + ")";
            initUser();
            listVender = service.getListVendor();
            setFilter();
            _YEAR = cbYear.Text;
            _MONTH = cbMonth.Text;
            //listEva = service.getEva();
        }

        private void initUser()
        {
            mUser = service.getUser(_UID);
            if (mUser.Size > 0)
            {
                lbUser.Text =mUser.TName + " " + mUser.TSurn + " (" + _UID + ")";
            }
            else
            {
                lbUser.Text =_UID;
            }
        }

        private void setFilter()
        {
            for(int i = 0; i <= 5; i++)
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
            cbVender.Items.Add("  -- Please Select --  ");
            foreach(MVender vd in listVender)
            {
                cbVender.Items.Add("(" + vd.Vender + ") " + vd.VenderName); 
            }
            cbVender.SelectedIndex = 0;
        }

        private void btnEvaluation_Click(object sender, EventArgs e)
        {
            if (cbVender.SelectedIndex != 0)
            {
                _VD_CODE = listVender[cbVender.SelectedIndex - 1].Vender;
                initGvEvaluate();
            }
            else
            {
                lbAlert.Text = "กรุณาเลือกรายการ Supplier ...";
            }
        }

        private void initGvEvaluate()
        {
            _YEAR = cbYear.Text;
            gvEvaluate.Rows.Clear();
            listEva = service.getEva(_VD_CODE, _YEAR, cbMonth.SelectedIndex + 1);
            if (listEva.Count > 0)
            {
                lbAlert.Text = "";
                foreach (MEvaluate item in listEva)
                {
                    gvEvaluate.Rows.Add(item.Date.ToString("dd/MM/yyyy"), item.Type, item.Point, item.Comment, item.CreateBy != "" ? item.CreateBy : "-", "ลบ");
                }
            }
            else
            {
                lbAlert.Text = "ไม่พบข้อมูลที่คุณค้นหา ...";
            }
        }

        private void gvEvaluate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                DialogResult dialog = MessageBox.Show("คุณต้องการลบข้อมูลนี้ ใช่หรือไม่ ? ", "ลบข้อมูล", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    bool removeEva = service.removeEva(listEva[e.RowIndex].Id);
                    if (removeEva == true)
                    {
                        service.calEvaluate(_VD_CODE, DateTime.Parse(listEva[e.RowIndex].Date.ToString()).Year.ToString("D2"), DateTime.Parse(listEva[e.RowIndex].Date.ToString()).Month.ToString("D2"), _UID);
                        gvEvaluate.Rows.Remove(gvEvaluate.Rows[e.RowIndex]);
                        listEva.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void cbVender_SelectedIndexChanged(object sender, EventArgs e)
        {
            _VD_INDEX = cbVender.SelectedIndex;
        }

        private void btnViewEvaluate_Click(object sender, EventArgs e)
        {
            if (_VD_INDEX >0 )
            {
                _VD_NAME = cbVender.SelectedItem.ToString();
                _VD_CODE = listVender[cbVender.SelectedIndex - 1].Vender;
                _MONTH_INDEX = cbMonth.SelectedIndex;
                _YEAR = cbYear.SelectedItem.ToString();
                F_VIEW_EVALUATE frmViewEvaluate = new F_VIEW_EVALUATE(this);
                frmViewEvaluate.ShowDialog();
            }
            else
            {
                MessageBox.Show("กรุณาเลือก Supplier !!!");
            }
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            _MONTH = cbMonth.SelectedItem.ToString();
            _MONTH_INDEX = cbMonth.SelectedIndex + 1;
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            _YEAR = cbYear.Text;
        }

        private void cbVender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
