using System;

namespace SupplierEvaluation
{
    internal class MUser
    {
        private string pren = "";
        private string name = "";
        private string surn = "";
        private string sex = "";
        private string tName = "";
        private string tSurn = "";
        private string tPren = "";
        private string code = "";
        private int size = 0;
        private DateTime birth = new DateTime();
        public string Pren { get => pren; set => pren = value; }
        public string Name { get => name; set => name = value; }
        public string Surn { get => surn; set => surn = value; }
        public string Sex { get => sex; set => sex = value; }
        public string TName { get => tName; set => tName = value; }
        public string TSurn { get => tSurn; set => tSurn = value; }
        public string TPren { get => tPren; set => tPren = value; }
        public string Code { get => code; set => code = value; }
        public DateTime Birth { get => birth; set => birth = value; }
        public int Size { get => size; set => size = value; }
    }
}