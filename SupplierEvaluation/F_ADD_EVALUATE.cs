using EvaluationSupplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SupplierEvaluation
{
    public partial class F_ADD_EVALUATE : Form
    {
        private Dictionary<string, MChoiceEva> ChoiceEvaluation = new Dictionary<string, MChoiceEva>();
        private int _POINT = 0;
        private string _CHOICE = "";
        private string _COMMENT = "";
        private bool _SAVE = false;
        private string _VDCODE = "";
        private string _EINVOICE = "";
        private string _UID = "";
        private DateTime _DATE = new DateTime();
        Service service = new Service();
        List<MVender> rVd = new List<MVender>();
        private readonly F_MANAGE_DELIVERY fManageDelivery;
        MUser mUser = new MUser();
        public F_ADD_EVALUATE(string uid, F_MANAGE_DELIVERY f_MANAGE_DELIVERY)
        {
            InitializeComponent();
            _UID = uid;
            fManageDelivery = f_MANAGE_DELIVERY;
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            _DATE = inpDate.Value;
            if (_SAVE)
            {
                DialogResult dialog = MessageBox.Show("คุณต้องการบันทึกข้อมูลประเมินผลการจัดส่ง ใช่หรือไม่ ?", "ประเมินผลการจัดส่ง", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        bool saveData = service.saveEva(_VDCODE, _DATE, _CHOICE, _POINT, _COMMENT, _EINVOICE, _UID);
                        if (saveData)
                        {
                            MessageBox.Show("ประเมินผลการจัดส่ง สำเร็จ !");
                            fManageDelivery.refreshGvEvaluete(cbSupplier.SelectedIndex);
                            service.calEvaluate(_VDCODE, DateTime.Parse(inpDate.Text).Year.ToString("D2"), DateTime.Parse(inpDate.Text).Month.ToString("D2"), _UID);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("ประเมินผลการจัดส่ง ไม่สำเร็จ ! ");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ประเมินผลการจัดส่ง ไม่สำเร็จ ! " + ex.Message);
                    }
                }
            }
        }

        private void setCbVender()
        {
            rVd = service.getListVendor();
            cbSupplier.DisplayMember = "Value";
            cbSupplier.ValueMember = "Key";
            cbSupplier.Items.Add(new KeyValuePair<string, string>("", "--- Please Select ---"));
            foreach (MVender item in rVd)
            {
                cbSupplier.Items.Add(new KeyValuePair<string, string>(item.Vender," (" + item.Vender + ") " + item.VenderName));
            }
            cbSupplier.SelectedIndex = 0;
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CHOICE = ((KeyValuePair<string, string>)cbType.SelectedItem).Key;
            if (ChoiceEvaluation.ContainsKey(_CHOICE))
            {
                _POINT = ChoiceEvaluation[_CHOICE].Point;
                lbPoint.Text = _POINT + " POINT";
            }
            else
            {
                _POINT = 0;
                lbPoint.Text = "-";
            }
            setEnableBtnSaveData();
        }

        private void setEnableBtnSaveData()
        {
            if (_VDCODE != "" && _CHOICE != "" && _POINT != 0 && _COMMENT.Trim() != "")
            {
                btnSaveData.BackColor = SystemColors.HotTrack;
                btnSaveData.ForeColor = Color.Snow;
                btnSaveData.Enabled = true;
                _SAVE = true;
            }
            else
            {
                btnSaveData.BackColor = SystemColors.ControlLight;
                btnSaveData.ForeColor = SystemColors.ControlDarkDark;
                btnSaveData.Enabled = false;
                _SAVE = false;
            }
        }
        private void inpComment_KeyUp(object sender, KeyEventArgs e)
        {
            _COMMENT = inpComment.Text.Trim();
            setEnableBtnSaveData();
        }

        internal void passContent(List<MVender> listVendor)
        {
            this.rVd = listVendor;
        }

        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            _VDCODE = ((KeyValuePair<string, string>)cbSupplier.SelectedItem).Key;
            setEnableBtnSaveData();
        }
        private void F_ADD_EVALUATE_Load(object sender, EventArgs e)
        {
            initUser();
            setCbVender();
            ChoiceEvaluation.Add("A1", new MChoiceEva("A1 : Delay impact to shotage (-10)", 10));
            ChoiceEvaluation.Add("A2", new MChoiceEva("A2 : Delay delivery date (-5)", 5));
            ChoiceEvaluation.Add("A3", new MChoiceEva("A3 : Delivery on time (+,-2hr)", 5));
            ChoiceEvaluation.Add("B1", new MChoiceEva("B1 : Tag Barcode mistake&No attach E-Invoice (-5)", 5));
            ChoiceEvaluation.Add("B2", new MChoiceEva("B2 : Referance Mistake Po no.,Q'ty,Unit price (-5)", 5));
            ChoiceEvaluation.Add("B3", new MChoiceEva("B3 : No Attach Data Inspection (-5)", 5));
            ChoiceEvaluation.Add("C1", new MChoiceEva("C1 : Mix Drawing in box (-10)", 10));
            ChoiceEvaluation.Add("C2", new MChoiceEva("C2 : Shortage of quatity per box (-10)", 10));
            ChoiceEvaluation.Add("D1", new MChoiceEva("D1 : Accident (-10)", 10));
            ChoiceEvaluation.Add("D2", new MChoiceEva("D2 : Property Damage & Near Miss (-5)", 5));
            ChoiceEvaluation.Add("D3", new MChoiceEva("D3 : Letter information (-3)", 3));
            cbType.DisplayMember = "Value";
            cbType.ValueMember = "Key";
            cbType.Items.Add(new KeyValuePair<string, string>("", "--- Please Select ---"));
            foreach (KeyValuePair<string, MChoiceEva> choice in ChoiceEvaluation)
            {
                cbType.Items.Add(new KeyValuePair<string, string>(choice.Key, choice.Value.Name));
            }
            cbType.SelectedIndex = 0;
            cbSupplier.SelectedIndex = fManageDelivery._VD_INDEX;
        }

        private void initUser()
        {
            mUser = service.getUser(_UID);
            if (mUser.Size > 0)
            {
                lbCreateBy.Text = mUser.TName + " " + mUser.TSurn + " (" + _UID + ")";
            }
            else
            {
                lbCreateBy.Text = _UID;
            }
        }

        private void cbSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled= true;
        }
    }

    internal class MChoiceEva
    {
        private string name = "";
        private int point = 0;

        public MChoiceEva(string name, int point)
        {
            this.name = name;
            this.point = point;
        }

        public string Name { get => name; set => name = value; }
        public int Point { get => point; set => point = value; }
    }
}
