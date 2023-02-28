using SupplierEvaluation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EvaluationSupplier
{
    internal class Service
    {
        ConnectDB conSDCM = new ConnectDB("DBSCM");
        ConnectDB conDBDCI = new ConnectDB("DBDCI");
        public List<MVender> getListVendor()
        {
            List<MVender> list = new List<MVender>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [dbSCM].[dbo].[AL_Vendor] ORDER BY VenderName ASC";
            //cmd.CommandText = "SELECT * FROM [dbSCM].[dbo].[AL_Vendor] WHERE Vender = '020013'";
            DataTable dt = conSDCM.Query(cmd);
            foreach(DataRow dr in dt.Rows)
            {
                MVender item = new MVender();
                item.Vender = dr["Vender"].ToString();
                item.VenderName = dr["VenderName"].ToString();
                list.Add(item);
            }
            return list;
        }

        public string getSupplierAddr(string supplierCode)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = " SELECT  [vd_addr],[vd_ap_cc] FROM [dbSCM].[dbo].[vd_mstr] where vd_ap_cc = @SUPPLIER_CODE ";
            cmd.Parameters.Add(new SqlParameter("@SUPPLIER_CODE", supplierCode));
            DataTable dt = conSDCM.Query(cmd);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["vd_addr"] != null ? dt.Rows[0]["vd_addr"].ToString() : supplierCode;
            }
            else
            {
                return supplierCode;
            }
        }
        public DataTable getData(string _vdCode,string year, string month)
        {
            int dataYear = 0;
            int dataMonth = 0;
            int EndOfMonth = 0;
            try
            {
                dataYear = int.Parse(year);
            }
            catch { }

            try
            {
                dataMonth = int.Parse(month);
            }
            catch { }

            try
            {
                EndOfMonth = DateTime.DaysInMonth(dataYear, dataMonth);
            }
            catch { }
            DateTime DateST = new DateTime(dataYear, dataMonth, 1);
            DateTime DateED = new DateTime(dataYear, dataMonth, EndOfMonth);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT datamonth,datayear,SupplierNO as vd_addr,v.vd_sort, v.vd_ap_cc " +
        " ,(SELECT COUNT(1) AS counts FROM [PU_EvaluateSupplier] WHERE [Type] = 'A1' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS count_A1 " +
        " ,(SELECT SUM(point) AS sumA1 FROM [PU_EvaluateSupplier] WHERE [Type] = 'A1' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS sumA1" +
        " ,(SELECT COUNT(1) AS counts FROM [PU_EvaluateSupplier] WHERE [Type] = 'A2' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS count_A2 " +
        " ,(SELECT SUM(point) AS sumA2 FROM [PU_EvaluateSupplier] WHERE [Type] = 'A2' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS sumA2" +
        " ,(SELECT COUNT(1) AS counts FROM [PU_EvaluateSupplier] WHERE [Type] = 'A3' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS count_A3 " +
        " ,(SELECT SUM(point) AS sumA3 FROM [PU_EvaluateSupplier] WHERE [Type] = 'A3' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS sumA3" +
        " ,[delivery_point] AS minus_A " +
        " ,(SELECT COUNT(1) AS counts FROM [PU_EvaluateSupplier] WHERE [Type] = 'B1' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS count_B1 " +
        " ,(SELECT SUM(point) AS sumB1 FROM [PU_EvaluateSupplier] WHERE [Type] = 'B1' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS sumB1" +
        " ,(SELECT COUNT(1) AS counts FROM [PU_EvaluateSupplier] WHERE [Type] = 'B2' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS count_B2 " +
        " ,(SELECT SUM(point) AS sumB2 FROM [PU_EvaluateSupplier] WHERE [Type] = 'B2' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS sumB2" +
        " ,(SELECT COUNT(1) AS counts FROM [PU_EvaluateSupplier] WHERE [Type] = 'B3' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS count_B3 " +
        " ,(SELECT SUM(point) AS sumB3 FROM [PU_EvaluateSupplier] WHERE [Type] = 'B3' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS sumB3" +
        " ,[document_point] AS minus_B " +
        " ,(SELECT COUNT(1) AS counts FROM [PU_EvaluateSupplier] WHERE [Type] = 'C1' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS count_C1 " +
        " ,(SELECT SUM(point) AS sumC1 FROM [PU_EvaluateSupplier] WHERE [Type] = 'C1' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS sumC1" +
        " ,(SELECT COUNT(1) AS counts FROM [PU_EvaluateSupplier] WHERE [Type] = 'C2' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS count_C2 " +
        " ,(SELECT SUM(point) AS sumC2 FROM [PU_EvaluateSupplier] WHERE [Type] = 'C2' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS sumC2" +
        " ,[correct_point] AS minus_C " +
        " ,(SELECT COUNT(1) AS counts FROM [PU_EvaluateSupplier] WHERE [Type] = 'D1' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS count_D1 " +
        " ,(SELECT SUM(point) AS sumD1 FROM [PU_EvaluateSupplier] WHERE [Type] = 'D1' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS sumD1" +
        " ,(SELECT COUNT(1) AS counts FROM [PU_EvaluateSupplier] WHERE [Type] = 'D2' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS count_D2 " +
        " ,(SELECT SUM(point) AS sumD2 FROM [PU_EvaluateSupplier] WHERE [Type] = 'D2' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS sumD2" +
        " ,(SELECT COUNT(1) AS counts FROM [PU_EvaluateSupplier] WHERE [Type] = 'D3' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS count_D3 " +
        " ,(SELECT SUM(point) AS sumD3 FROM [PU_EvaluateSupplier] WHERE [Type] = 'D3' AND vd_addr = r.SupplierNO AND [Status] = 'ACTIVE' AND rnd_date BETWEEN '" + DateST.ToString("yyyy-MM-dd") + "' AND '" + DateED.ToString("yyyy-MM-dd") + "') AS sumD3" +
        " ,[safety_point] AS minus_D " +
        " ,[result_point] AS result_score " +
        " ,[result_grade] " +
        " FROM [PU_EvaluateSupplierResult] AS r " +
        " LEFT JOIN vd_mstr AS v ON v.vd_addr = r.SupplierNO  " +
        " WHERE datayear = '" + dataYear.ToString() + "' AND datamonth = '" + dataMonth.ToString() + "' AND v.vd_addr = '" + _vdCode + "' ";
            DataTable dt = conSDCM.Query(cmd);
            DataTable dtEvaluate = new DataTable();
            dtEvaluate.Columns.Add("no", typeof(int));
            dtEvaluate.Columns.Add("dataMonth", typeof(int));
            dtEvaluate.Columns.Add("dataYear", typeof(int));
            dtEvaluate.Columns.Add("buyer", typeof(string));
            dtEvaluate.Columns.Add("vd_addr", typeof(string));
            dtEvaluate.Columns.Add("vd_sort", typeof(string));

            List<string> grardName = new List<string>() { "A","B","C","D" };
            foreach(string col in grardName)
            {
                for(int i = 1; i <= 3; i++)
                {
                    dtEvaluate.Columns.Add("count_" + col + i, typeof(int));
                    dtEvaluate.Columns.Add("sum" + col  + i , typeof(string));
                }
                dtEvaluate.Columns.Add("minus_" + col + "", typeof(int));
                dtEvaluate.Columns.Add("point_" + col + "", typeof(int));
            }

            //dtEvaluate.Columns.Add("count_A1", typeof(int));
            //dtEvaluate.Columns.Add("count_A2", typeof(int));
            //dtEvaluate.Columns.Add("count_A3", typeof(int));
            //dtEvaluate.Columns.Add("sumA1", typeof(string));
            //dtEvaluate.Columns.Add("sumA2", typeof(string));
            //dtEvaluate.Columns.Add("sumA3", typeof(string));
            //dtEvaluate.Columns.Add("minus_A", typeof(int));
            //dtEvaluate.Columns.Add("point_A", typeof(int));
            //dtEvaluate.Columns.Add("count_B1", typeof(int));
            //dtEvaluate.Columns.Add("count_B2", typeof(int));
            //dtEvaluate.Columns.Add("count_B3", typeof(int));
            //dtEvaluate.Columns.Add("sumB1", typeof(string));
            //dtEvaluate.Columns.Add("sumB2", typeof(string));
            //dtEvaluate.Columns.Add("sumB3", typeof(string));
            //dtEvaluate.Columns.Add("minus_B", typeof(int));
            //dtEvaluate.Columns.Add("point_B", typeof(int));
            //dtEvaluate.Columns.Add("count_C1", typeof(int));
            //dtEvaluate.Columns.Add("count_C2", typeof(int));
            //dtEvaluate.Columns.Add("sumC1", typeof(string));
            //dtEvaluate.Columns.Add("sumC2", typeof(string));
            //dtEvaluate.Columns.Add("minus_C", typeof(int));
            //dtEvaluate.Columns.Add("point_C", typeof(int));
            //dtEvaluate.Columns.Add("count_D1", typeof(int));
            //dtEvaluate.Columns.Add("count_D2", typeof(int));
            //dtEvaluate.Columns.Add("count_D3", typeof(int));
            //dtEvaluate.Columns.Add("sumD1", typeof(string));
            //dtEvaluate.Columns.Add("sumD2", typeof(string));
            //dtEvaluate.Columns.Add("sumD3", typeof(string));
            //dtEvaluate.Columns.Add("minus_D", typeof(int));
            //dtEvaluate.Columns.Add("point_D", typeof(int));
            dtEvaluate.Columns.Add("result_Score", typeof(int));
            dtEvaluate.Columns.Add("result_Grade", typeof(string));

            for(int i = 1; i <= 12; i++)
            {
                dtEvaluate.Columns.Add("GadeMonth" + i, typeof(string));
                dtEvaluate.Columns.Add("ScoreMonth" + i, typeof(string));
            }

            if (dt.Rows.Count > 0)
            {
                int no = 1;
                foreach (DataRow drEval in dt.Rows)
                {
                    DataRow drEva = dtEvaluate.NewRow();
                    drEva["no"] = no.ToString();
                    drEva["dataMonth"] = Convert.ToInt16(drEval["datamonth"].ToString());
                    drEva["dataYear"] = Convert.ToInt16(drEval["datayear"].ToString());
                    drEva["buyer"] = "";
                    drEva["vd_addr"] = drEval["vd_addr"].ToString();
                    drEva["vd_sort"] =  drEval["vd_sort"].ToString();
                    drEva["count_A1"] = drEval["count_A1"].ToString() == "" ? 0 : Convert.ToInt16(Convert.ToDecimal(drEval["count_A1"].ToString()));
                    drEva["count_A2"] = drEval["count_A2"].ToString() == "" ? 0 : Convert.ToInt16(Convert.ToDecimal(drEval["count_A2"].ToString()));
                    drEva["count_A3"] = drEval["count_A3"].ToString() == "" ? 0 : Convert.ToInt16(Convert.ToDecimal(drEval["count_A3"].ToString()));
                    drEva["minus_A"] = drEval["minus_A"].ToString() == "" ? 0 : Convert.ToInt16(Convert.ToDecimal(drEval["minus_A"].ToString()));
                    drEva["point_A"] = 0;
                    drEva["count_B1"] = drEval["count_B1"].ToString() == "" ? 0 : Convert.ToInt16(Convert.ToDecimal(drEval["count_B1"].ToString()));
                    drEva["count_B2"] = drEval["count_B2"].ToString() == "" ? 0 : Convert.ToInt16(Convert.ToDecimal(drEval["count_B2"].ToString()));
                    drEva["count_B3"] = drEval["count_B3"].ToString() == "" ? 0 : Convert.ToInt16(Convert.ToDecimal(drEval["count_B3"].ToString()));
                    drEva["minus_B"] = drEval["minus_B"].ToString() == "" ? 0 : Convert.ToInt16(Convert.ToDecimal(drEval["minus_B"].ToString()));
                    drEva["point_B"] = 0;
                    drEva["count_C1"] = drEval["count_C1"].ToString() == "" ? 0 : Convert.ToInt16(Convert.ToDecimal(drEval["count_C1"].ToString()));
                    drEva["count_C2"] = drEval["count_C2"].ToString() == "" ? 0 : Convert.ToInt16(Convert.ToDecimal(drEval["count_C2"].ToString()));
                    drEva["minus_C"] = drEval["minus_C"].ToString() == "" ? 0 : Convert.ToInt16(Convert.ToDecimal(drEval["minus_C"].ToString()));
                    drEva["point_C"] = 0;
                    drEva["count_D1"] = drEval["count_D1"].ToString() == "" ? 0 : Convert.ToInt32(Convert.ToDecimal(drEval["count_D1"].ToString()));
                    drEva["count_D2"] = drEval["count_D2"].ToString() == "" ? 0 : Convert.ToInt32(Convert.ToDecimal(drEval["count_D2"].ToString()));
                    drEva["count_D3"] = drEval["count_D3"].ToString() == "" ? 0 : Convert.ToInt32(Convert.ToDecimal(drEval["count_D3"].ToString()));
                    drEva["minus_D"] = drEval["minus_D"].ToString() == "" ? 0 : Convert.ToInt32(Convert.ToDecimal(drEval["minus_D"].ToString()));
                    drEva["point_D"] = 0;
                    drEva["result_Score"] = drEval["result_Score"].ToString() == "" ? 0 : Convert.ToInt32(Convert.ToDecimal(drEval["result_score"].ToString()));
                    drEva["result_Grade"] = drEval["result_grade"].ToString();
                    drEva["sumA1"] = drEval["sumA1"].ToString() == "" ? "-" : Math.Round(Convert.ToDecimal(drEval["sumA1"].ToString()), 0).ToString();
                    drEva["sumA2"] = drEval["sumA2"].ToString() == "" ? "-" : Math.Round(Convert.ToDecimal(drEval["sumA2"].ToString()), 0).ToString();
                    drEva["sumA3"] = drEval["sumA3"].ToString() == "" ? "-" : Math.Round(Convert.ToDecimal(drEval["sumA3"].ToString()), 0).ToString();
                    drEva["sumB1"] = drEval["sumB1"].ToString() == "" ? "-" : Math.Round(Convert.ToDecimal(drEval["sumB1"].ToString()), 0).ToString();
                    drEva["sumB2"] = drEval["sumB2"].ToString() == "" ? "-" : Math.Round(Convert.ToDecimal(drEval["sumB2"].ToString()), 0).ToString();
                    drEva["sumB3"] = drEval["sumB3"].ToString() == "" ? "-" : Math.Round(Convert.ToDecimal(drEval["sumB3"].ToString()), 0).ToString();
                    drEva["sumC1"] = drEval["sumC1"].ToString() == "" ? "-" : Math.Round(Convert.ToDecimal(drEval["sumC1"].ToString()), 0).ToString();
                    drEva["sumC2"] = drEval["sumC2"].ToString() == "" ? "-" : Math.Round(Convert.ToDecimal(drEval["sumC2"].ToString()), 0).ToString();
                    drEva["sumD1"] = drEval["sumD1"].ToString() == "" ? "-" : Math.Round(Convert.ToDecimal(drEval["sumD1"].ToString()), 0).ToString();
                    drEva["sumD2"] = drEval["sumD2"].ToString() == "" ? "-" : Math.Round(Convert.ToDecimal(drEval["sumD2"].ToString()), 0).ToString();
                    drEva["sumD3"] = drEval["sumD3"].ToString() == "" ? "-" : Math.Round(Convert.ToDecimal(drEval["sumD3"].ToString()), 0).ToString();
                    dtEvaluate.Rows.Add(drEva);
                    no++;
                }
            }
            return dtEvaluate;
        }

        internal Dictionary<string, MVender> getListDetailVender(List<string> ListVender, string _YEAR, string _MONTH)
        {
            Dictionary<string, MVender> list = new Dictionary<string, MVender>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [dbSCM].[dbo].[AL_Vendor] WHERE Vender IN ('" + String.Join("','",ListVender) + "')";
            DataTable dt = conSDCM.Query(cmd);
            foreach(DataRow dr in dt.Rows)
            {

                list.Add(dr["Vender"].ToString(), new MVender()
                {
                    Vender = dr["Vender"].ToString(),
                    VenderName = dr["VenderName"].ToString(),
                    EmailPo = dr["EmailPO"].ToString(),
                    PersonIncharge = dr["PersonIncharge"].ToString(),
                    Path = (@"C:\temp\evaluation_supplier_" + dr["Vender"].ToString() + "_" + _YEAR + _MONTH.PadLeft(2, '0') + ".pdf"),
                    Data = getData(dr["Vender"].ToString(),_YEAR,_MONTH)
                });
            }
            return list;
        }

        internal MSupplier getDetailSupplier(string supplier)
        {
            string vd_addr = getSupplierAddr(supplier);
            if (vd_addr != supplier)
            {
                supplier = vd_addr;
            }
            MSupplier item = new MSupplier();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT id, EInvoice, rnd_invno_sup, rnd_date, rnd_time, Comment, Remark, point, Type, Status, UpdateBy, UpdateDate, vd_addr, vd_sort, UpdateName FROM vi_PUEvaluateSupplier WHERE (Status = 'ACTIVE') AND (vd_addr = @SUPPLIER) ORDER BY rnd_date, rnd_time";
            cmd.Parameters.Add(new SqlParameter("@SUPPLIER", supplier));
            DataTable dt = conSDCM.Query(cmd);
            if (dt.Rows.Count > 0)
            {
                item.SupplierCode = supplier;
                item.SupplierName = dt.Rows[0]["vd_sort"].ToString();
                item.SupplierAddr = dt.Rows[0]["vd_addr"].ToString();
            }
            return item;
        }

        internal bool saveEva(string _VDCODE,DateTime _DATE,string _CHOICE,int _POINT,string _COMMENT,string _EINVOICE,string _UID)
        {
            //if (_VDCODE.Length > 6)
            //{
            //    _VDCODE = _VDCODE.Substring(0, 6);
            //}
            _EINVOICE = "";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=192.168.226.86;Initial Catalog=dbSCM; Persist Security Info=True; User ID=sa;Password=decjapan;";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO [dbo].[PU_EvaluateSupplier]([vd_addr],[EInvoice],[rnd_date],[Comment],[point],[Type],[InputType],[Status],[CreateBy],[CreateDate],[UpdateBy],[UpdateDate]) VALUES(@VDCODE,@EINVOICE,@ACTIVE_DATE,@COMMENT,@POINT,@TYPE,'MANUAL','ACTIVE',@CREATE_BY,GETDATE(),@CREATE_BY,GETDATE())";
            //cmd.CommandText = "INSERT INTO [dbo].[PU_EvaluateSupplier]([vd_addr],[EInvoice],[rnd_date],[Comment],[point],[Type],[InputType],[Status],[CreateBy],[CreateDate],[UpdateBy],[UpdateDate]) VALUES('" + _VDCODE + "','" + _VDCODE + "','" + _VDCODE + "','" + _VDCODE + "','" + _VDCODE + "','" + _VDCODE + "','MANUAL','ACTIVE','" + _VDCODE + "','" + _VDCODE + "','" + _VDCODE + "','" + _VDCODE + "')"
            cmd.Parameters.Add(new SqlParameter("@VDCODE", _VDCODE));
            cmd.Parameters.Add(new SqlParameter("@EINVOICE", _EINVOICE));
            cmd.Parameters.Add(new SqlParameter("@ACTIVE_DATE", _DATE.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SqlParameter("@COMMENT", _COMMENT));
            cmd.Parameters.Add(new SqlParameter("@POINT", _POINT));
            cmd.Parameters.Add(new SqlParameter("@TYPE", _CHOICE));
            cmd.Parameters.Add(new SqlParameter("@CREATE_BY", _UID));
            cmd.Connection = conn;
            int success = cmd.ExecuteNonQuery();
            conn.Close();
            if (success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal List<MEvaluate> getEva(string vdCode, string year, int month)
        {
            List<MEvaluate> list = new List<MEvaluate>();
            SqlCommand cmd = new SqlCommand();
            string sdate = (year + "-" + month.ToString("D2") + "-01");
            string fdate = (year + "-" + month.ToString("D2") + "-" + DateTime.DaysInMonth(Convert.ToInt32(year), month));
            cmd.CommandText = @"SELECT *  FROM [dbSCM].[dbo].[PU_EvaluateSupplier] WHERE (rnd_date BETWEEN @SDATE AND @FDATE) AND vd_addr = @VDCODE ORDER BY id desc";
            cmd.Parameters.Add(new SqlParameter("@VDCODE", vdCode));
            cmd.Parameters.Add(new SqlParameter("@SDATE", sdate));
            cmd.Parameters.Add(new SqlParameter("@FDATE", fdate));
            DataTable dt = conSDCM.Query(cmd);
            foreach(DataRow dr in dt.Rows)
            {
                MEvaluate item = new MEvaluate();
                item.Date = DateTime.Parse(dr["rnd_date"].ToString());
                item.Type = dr["Type"].ToString();
                item.Point = Convert.ToDecimal(dr["point"]);
                item.Comment = dr["Comment"].ToString();
                item.CreateBy = dr["CreateBy"].ToString();
                item.Id = Convert.ToInt32(dr["id"]);
                list.Add(item);
            }
            return list;
        }

        internal bool removeEva(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=192.168.226.86;Initial Catalog=dbSCM; Persist Security Info=True; User ID=sa;Password=decjapan;";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"DELETE FROM  [dbo].[PU_EvaluateSupplier] WHERE id = @ID";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.Connection = conn;
            int success = cmd.ExecuteNonQuery();
            conn.Close();
            if (success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal MUser getUser(string uID)
        {
            MUser list = new MUser();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT * FROM [dbDCI].[dbo].[Employee] WHERE CODE = @UID";
            cmd.Parameters.Add(new SqlParameter("@UID", uID));
            DataTable dt = conDBDCI.Query(cmd);
            foreach(DataRow dr in dt.Rows)
            {
                list.TName = dr["TNAME"].ToString();
                list.TSurn = dr["TSURN"].ToString();
            }
            list.Size = dt.Rows.Count;
            return list;
        }
        internal bool calEvaluate(string vDCODE, string year , string month,string UID)
        {
            SqlCommand cmd = new SqlCommand();
            Dictionary<string, Decimal> rScoreLimit = new Dictionary<string, Decimal>();
            rScoreLimit.Add("A",50);
            rScoreLimit.Add("B", 20);
            rScoreLimit.Add("C", 20);
            rScoreLimit.Add("D", 10);
            Dictionary<string, Decimal> rScore = new Dictionary<string, Decimal>();
            decimal resultPoint = 0;
            string resultGrade = "A";
            string sdate = (year + "-" + month + "-01");
            string fdate = (year + "-" + month + "-" + DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(month)));
            cmd.CommandText = @"SELECT SUBSTRING(Type,1,1) as Type,SUM(ISNULL (point,0)) as point FROM [dbSCM].[dbo].[PU_EvaluateSupplier] WHERE rnd_date  BETWEEN @SDATE AND @FDATE AND vd_addr = @VDCODE GROUP BY SUBSTRING(Type,1,1)";
            cmd.Parameters.Add(new SqlParameter("@VDCODE", vDCODE));
            cmd.Parameters.Add(new SqlParameter("@SDATE", sdate));
            cmd.Parameters.Add(new SqlParameter("@FDATE", fdate));
            DataTable dtCal = conSDCM.Query(cmd);
            foreach (DataRow drCal in dtCal.Rows)
            {
                decimal point = Convert.ToDecimal(drCal["point"]) > rScoreLimit[drCal["Type"].ToString()] ? rScoreLimit[drCal["Type"].ToString()] : Convert.ToDecimal(drCal["point"]);
                rScore[drCal["Type"].ToString()] = point;
                resultPoint += point;
            }

            if ((100- resultPoint) >= 90)
            {
                resultGrade = "A";
            }
            else if ((100 - resultPoint) >= 70 && (100 - resultPoint) <= 89)
            {
                resultGrade = "B";
            }
            else if((100 - resultPoint) <= 69)
            {
                resultGrade = "C";
            }

            SqlCommand cmdResult = new SqlCommand();
            cmdResult.CommandText = @"SELECT * FROM [dbSCM].[dbo].[PU_EvaluateSupplierResult] WHERE SupplierNO = @VDC AND datayear = @YEAR AND datamonth =  @MONTH ";
            cmdResult.Parameters.Add(new SqlParameter("@VDC", vDCODE));
            cmdResult.Parameters.Add(new SqlParameter("@YEAR", year));
            cmdResult.Parameters.Add(new SqlParameter("@MONTH", Convert.ToInt32(month)));
            DataTable dt = conSDCM.Query(cmdResult);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=192.168.226.86;Initial Catalog=dbSCM; Persist Security Info=True; User ID=sa;Password=decjapan;";
            conn.Open();
            SqlCommand cmdActive = new SqlCommand();
            if (dt.Rows.Count > 0)
            {
               
                cmdActive.CommandText = @"UPDATE [dbo].[PU_EvaluateSupplierResult] SET [delivery_point] = @A_POINT ,[document_point] = @B_POINT ,[correct_point] = @C_POINT ,[safety_point] = @D_POINT ,[result_point] = @RESULT_POINT ,[result_grade] = @RESULT_GRADE ,[UpdateBy] = @UID ,[UpdateDate] = GETDATE() WHERE  id = @ID";
                cmdActive.Parameters.Add(new SqlParameter("@A_POINT", rScoreLimit.ContainsKey("A") && rScore.ContainsKey("A") ? rScore["A"] : 0));
                cmdActive.Parameters.Add(new SqlParameter("@B_POINT", rScoreLimit.ContainsKey("B") && rScore.ContainsKey("B") ? rScore["B"] : 0));
                cmdActive.Parameters.Add(new SqlParameter("@C_POINT", rScoreLimit.ContainsKey("C") && rScore.ContainsKey("C") ? rScore["C"] : 0));
                cmdActive.Parameters.Add(new SqlParameter("@D_POINT", rScoreLimit.ContainsKey("D") && rScore.ContainsKey("D") ? rScore["D"] : 0));
                cmdActive.Parameters.Add(new SqlParameter("@RESULT_POINT", (100- resultPoint)));
                cmdActive.Parameters.Add(new SqlParameter("@RESULT_GRADE", resultGrade));
                cmdActive.Parameters.Add(new SqlParameter("@UID", UID));
                cmdActive.Parameters.Add(new SqlParameter("@ID", dt.Rows[0]["id"].ToString()));
                cmdActive.Connection = conn;
                int update = cmdActive.ExecuteNonQuery();
                conn.Close();
                if (update > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                cmdActive.CommandText = @"INSERT INTO[dbo].[PU_EvaluateSupplierResult] ([datayear] ,[datamonth] ,[SupplierNO] ,[delivery_point] ,[document_point] ,[correct_point] ,[safety_point] ,[result_point] ,[result_grade] ,[UpdateBy] ,[UpdateDate]) VALUES(@YEAR,@MONTH,@VDCODE,@A_POINT,@B_POINT,@C_POINT,@D_POINT,@RESULT_POINT,@RESULT_GRADE,@UID,GETDATE())";
                cmdActive.Parameters.Add(new SqlParameter("@YEAR", year));
                cmdActive.Parameters.Add(new SqlParameter("@MONTH", Convert.ToInt32(month)));
                cmdActive.Parameters.Add(new SqlParameter("@VDCODE", vDCODE));
                cmdActive.Parameters.Add(new SqlParameter("@A_POINT", rScoreLimit.ContainsKey("A") && rScore.ContainsKey("A") ? rScore["A"] : 0));
                cmdActive.Parameters.Add(new SqlParameter("@B_POINT", rScoreLimit.ContainsKey("B") && rScore.ContainsKey("B") ? rScore["B"] : 0));
                cmdActive.Parameters.Add(new SqlParameter("@C_POINT", rScoreLimit.ContainsKey("C") && rScore.ContainsKey("C") ? rScore["C"] : 0));
                cmdActive.Parameters.Add(new SqlParameter("@D_POINT", rScoreLimit.ContainsKey("D") && rScore.ContainsKey("D") ? rScore["D"] : 0));
                cmdActive.Parameters.Add(new SqlParameter("@RESULT_POINT", (100 - resultPoint)));
                cmdActive.Parameters.Add(new SqlParameter("@RESULT_GRADE", resultGrade));
                cmdActive.Parameters.Add(new SqlParameter("@UID", UID));
                cmdActive.Connection = conn;
                int update = cmdActive.ExecuteNonQuery();
                conn.Close();
                if (update > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal List<PU_EvaluateSupplierResult> getEvaResult(string vdCode,string year,int month)
        {
            var ctx = new dbSCMEntities2();
            return ctx.PU_EvaluateSupplierResult.Where(x => x.SupplierNO == vdCode && x.datayear == year && x.datamonth == month.ToString()).ToList();
        }

        internal Employee getUsers(string uID)
        {
            return new dbHRMEntities().Employees.First(x => x.CODE == uID);
        }

        internal object testLeftJoin()
        {
            var dbSCM = new dbSCMEntities2();
            var result = dbSCM.AL_Vendor.Join(dbSCM.vd_mstr, A => A.Vender, B => B.vd_ap_cc, (A, B) => new {
                venderOld = B.vd_addr,
                vdSort = B.vd_sort
            }).ToList();
            return result;
        }

        //interface 
    }
}
