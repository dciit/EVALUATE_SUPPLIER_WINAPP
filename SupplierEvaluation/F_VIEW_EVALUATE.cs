using EvaluationSupplier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupplierEvaluation
{
    public partial class F_VIEW_EVALUATE : Form
    {
        private F_MANAGE_DELIVERY frmDelivery;
        private Service service = new Service();
        public F_VIEW_EVALUATE(F_MANAGE_DELIVERY f_MANAGE_DELIVERY)
        {
            InitializeComponent();
            this.frmDelivery = f_MANAGE_DELIVERY;
        }

        private void F_VIEW_EVALUATE_Load(object sender, EventArgs e)
        {
            lbVenderName.Text = frmDelivery._VD_NAME;
            lbMonthYear.Text = frmDelivery._MONTH + ", " + frmDelivery._YEAR;
            //MEvaluate data = service.getEvaResult(f_MANAGE_DELIVERY._VD_CODE);
            List<PU_EvaluateSupplierResult> data = service.getEvaResult(frmDelivery._VD_CODE, frmDelivery._YEAR, frmDelivery._MONTH_INDEX+1);
            if (data.Count > 0)
            {
                lbGrade.Text = data[0].result_grade;
                ScoreA.Text = data[0].delivery_point.ToString();
                ScoreB.Text = data[0].document_point.ToString();
                ScoreC.Text = data[0].correct_point.ToString();
                ScoreD.Text = data[0].safety_point.ToString();
            }
        }

    }
}
