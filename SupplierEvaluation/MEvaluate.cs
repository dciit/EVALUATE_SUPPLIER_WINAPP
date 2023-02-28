using System;

namespace SupplierEvaluation
{
    internal class MEvaluate
    {
        private DateTime date = new DateTime();
        private string type = "";
        private decimal point = 0;
        private string comment = "";
        private string createBy = "";
        private int id = 0;
        public string Type { get => type; set => type = value; }
        public decimal Point { get => point; set => point = value; }
        public string Comment { get => comment; set => comment = value; }
        public string CreateBy { get => createBy; set => createBy = value; }
        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}