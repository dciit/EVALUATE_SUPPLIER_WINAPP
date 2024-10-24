using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupplierEvaluation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
       
        static void Main(string[] args)
        {
            //args = new string[] { "41256", "BX3" };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new F_MANAGE_DELIVERY(args[0], args[1]));
            //Application.Run(new F_MANAGE_DELIVERY(args[0], args[1]));

            //if ()
            //{
            //    Application.Run(new DCI_EVALUATION_SUPPLIER());
            //}
            //else if ()
            //{
            //    Application.Run(new DCI_EVALUATION_SUPPLIER());
            //}

        }
    }
}
