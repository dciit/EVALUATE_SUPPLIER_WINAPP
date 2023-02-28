using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSupplier
{
    internal class MVender
    {
        private string vender = "";
        private string venderName = "";
        private string emailPo = "";
        private string personIncharge = "";
        private string venderCard = "";
        private string path = "";
        private DataTable data = new DataTable();
        public string Vender { get => vender; set => vender = value; }
        public string VenderName { get => venderName; set => venderName = value; }
        public string EmailPo { get => emailPo; set => emailPo = value; }
        public string PersonIncharge { get => personIncharge; set => personIncharge = value; }
        public string VenderCard { get => venderCard; set => venderCard = value; }
        public string Path { get => path; set => path = value; }
        public DataTable Data { get => data; set => data = value; }
    }
}
