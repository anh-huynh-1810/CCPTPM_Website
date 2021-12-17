using BT_Tuan09.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BT_Tuan09.Models
{
    public class ChuDe
    {
        private int _IDChuDe;
        private string _TenChuDe;
        private string _MoTa;
        private int _TrangThai;

        public int IDChuDe { get => _IDChuDe; set => _IDChuDe = value; }
        public string TenChuDe { get => _TenChuDe; set => _TenChuDe = value; }
        public string MoTa { get => _MoTa; set => _MoTa = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }

        public ChuDe ThemChuDe(string tencd, string mota)
        {
            ChuDe cd = new ChuDe();
            cd.TenChuDe = tencd;
            cd.MoTa = mota;
            cd.TrangThai = 1;
            return cd;
        }

        public bool XoaCD(ChuDe CD)
        {
            if (CD.TenChuDe == "")
            {
                return false;
            }
            else
            {
                CD.TrangThai = 0;
                return true;
            }
        }

        public ChuDe SuaChuDe(ChuDe CD, string tencd, string mota)
        {
            CD.TenChuDe = tencd;
            CD.MoTa = mota;
            return CD;
        }

        public ChuDe TimCD(string ten_CD)
        {
            String sQuery = "SELECT Top 1 [IDChuDe], [TenChuDe], [MoTa], [TrangThai] FROM [BT_Tuan09].[dbo].[ChuDe] WHERE [TenChuDe] = @un and [TrangThai] = 1";
            SqlParameter[] paras = new SqlParameter[1];
            paras[0] = new SqlParameter("@un", ten_CD);
            DataTable dt = DataProvider.getDataTable(sQuery, paras);
            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    ChuDe CD = new ChuDe();
                    CD.IDChuDe = int.Parse(dt.Rows[0]["IDChuDe"].ToString());
                    CD.TenChuDe = dt.Rows[0]["TenChuDe"].ToString();
                    CD.MoTa = dt.Rows[0]["MoTa"].ToString();
                    CD.TrangThai = int.Parse(dt.Rows[0]["TrangThai"].ToString());
                    return CD;
                }
            }
            return null;
        }
    }
}
