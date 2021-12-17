using BT_Tuan09.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BT_Tuan09.Models
{
    public class TaiKhoan
    {
        private int _IDTaiKhoan;
        private string _UserName;
        private string _PassWord;
        private string _HoTen;
        private int _PhanHe;
        private int _TrangThai;

        public int IDTaiKhoan { get => _IDTaiKhoan; set => _IDTaiKhoan = value; }
        public string UserName { get => _UserName; set => _UserName = value; }
        public string PassWord { get => _PassWord; set => _PassWord = value; }
        public string HoTen { get => _HoTen; set => _HoTen = value; }
        public int PhanHe { get => _PhanHe; set => _PhanHe = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }

        public TaiKhoan ThemTaiKhoan(string us, string pss, string hoten, int phanhe)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.UserName = us;
            tk.PassWord = pss;
            tk.HoTen = hoten;
            tk.PhanHe = phanhe;
            tk.TrangThai = 1;
            return tk;
        }

        public TaiKhoan SuaTK(TaiKhoan tk, string hoten)
        {
            tk.HoTen = hoten;
            return tk;
        }

        public TaiKhoan DoiMK(TaiKhoan tk, string mk)
        {
            tk.PassWord = mk;
            return tk;
        }

        public bool KhoaTK(TaiKhoan tk)
        {
            if(tk.UserName == "")
            {
                return false;
            }
            else
            {
                tk.TrangThai = 0;
                return true;
            }    
        }

        public TaiKhoan TimTK(string us)
        {
            String sQuery = "SELECT Top 1 [IDTaiKhoan], [UserName], [PassWord], [HoTen], [PhanHe], [TrangThai] FROM [BT_Tuan09].[dbo].[TaiKhoan] WHERE [UserName] = @un and [TrangThai] = 1";
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@un", us);
            DataTable dt = DataProvider.getDataTable(sQuery, paras);
            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    TaiKhoan tk = new TaiKhoan();
                    tk.IDTaiKhoan = int.Parse(dt.Rows[0]["IDTaiKhoan"].ToString());
                    tk.UserName = dt.Rows[0]["UserName"].ToString(); 
                    tk.PassWord = dt.Rows[0]["PassWord"].ToString();
                    tk.HoTen = dt.Rows[0]["HoTen"].ToString(); 
                    tk.PhanHe = int.Parse(dt.Rows[0]["PhanHe"].ToString()); 
                    tk.TrangThai = int.Parse(dt.Rows[0]["TrangThai"].ToString()); 
                    return tk;
                }
            }
            return null;
        }
    }
}
