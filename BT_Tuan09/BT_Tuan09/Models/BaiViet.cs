using BT_Tuan09.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BT_Tuan09.Models
{
    public class BaiViet
    {
        private int _IDBaiViet;
        private string _TenBaiViet;
        private string _NoiDung;
        private DateTime _ThoiGian;
        private int _IDTaiKhoan;
        private int _IDChuDe;
        private int _TrangThai;

        public int IDBaiViet { get => _IDBaiViet; set => _IDBaiViet = value; }
        public string TenBaiViet { get => _TenBaiViet; set => _TenBaiViet = value; }
        public string NoiDung { get => _NoiDung; set => _NoiDung = value; }
        public DateTime ThoiGian { get => _ThoiGian; set => _ThoiGian = value; }
        public int IDTaiKhoan { get => _IDTaiKhoan; set => _IDTaiKhoan = value; }
        public int IDChuDe { get => _IDChuDe; set => _IDChuDe = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }
        

        public BaiViet ThemBaiViet(string ten, string noidung, int id_cd, int id_tk)
        {
            BaiViet bv = new BaiViet();
            bv.TenBaiViet = ten;
            bv.NoiDung = noidung;
            bv.ThoiGian = DateTime.Now;
            bv.IDChuDe = id_cd;
            bv.IDTaiKhoan = id_tk;
            bv.TrangThai = 1;
            return bv;
        }

        public bool XoaBV(BaiViet bv)
        {
            if (bv.TenBaiViet == "")
            {
                return false;
            }
            else
            {
                bv.TrangThai = 0;
                return true;
            }
        }

        public BaiViet SuaBaiViet(BaiViet bv, string ten, string noidung)
        {
            bv.TenBaiViet = ten;
            bv.NoiDung = noidung;
            return bv;
        }

        public BaiViet TimBV(string ten_bv)
        {
            String sQuery = "SELECT Top 1 [IDBaiViet], [TenBaiViet], [NoiDung], [IDTaiKhoan], [IDChuDe], [TrangThai] FROM [BT_Tuan09].[dbo].[BaiViet] WHERE [TenBaiViet] = @un and [TrangThai] = 1";
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@un", ten_bv);
            DataTable dt = DataProvider.getDataTable(sQuery, paras);
            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    BaiViet bv = new BaiViet();
                    bv.IDBaiViet = int.Parse(dt.Rows[0]["IDBaiViet"].ToString());
                    bv.TenBaiViet = dt.Rows[0]["TenBaiViet"].ToString();
                    bv.NoiDung = dt.Rows[0]["NoiDung"].ToString();
                    bv.IDChuDe = int.Parse(dt.Rows[0]["IDChuDe"].ToString());
                    bv.IDTaiKhoan = int.Parse(dt.Rows[0]["IDTaiKhoan"].ToString());
                    bv.TrangThai = int.Parse(dt.Rows[0]["TrangThai"].ToString());
                    return bv;
                }
            }
            return null;
        }
    }
}
