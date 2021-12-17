using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BT_Tuan09.Models
{
    public class BinhLuan
    {
        private int _IDBinhLuan;
        private string _NoiDung;
        private DateTime _ThoiGian;
        private int _IDTaiKhoan;
        private int _IDBaiViet;
        private int _TrangThai;

        public int IDBinhLuan { get => _IDBinhLuan; set => _IDBinhLuan = value; }
        public string NoiDung { get => _NoiDung; set => _NoiDung = value; }
        public DateTime ThoiGian { get => _ThoiGian; set => _ThoiGian = value; }
        public int IDTaiKhoan { get => _IDTaiKhoan; set => _IDTaiKhoan = value; }
        public int IDBaiViet { get => _IDBaiViet; set => _IDBaiViet = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }

        public BinhLuan ThemBinhLuan(string noidung, int id_tk, int id_bv)
        {
            BinhLuan cd = new BinhLuan();
            cd.NoiDung = noidung;
            cd.ThoiGian = DateTime.Now;
            cd.IDTaiKhoan = id_tk;
            cd.IDBaiViet = id_bv;
            cd.TrangThai = 1;
            return cd;
        }

        public bool XoaCD(BinhLuan CD)
        {
            if (CD.NoiDung == "")
            {
                return false;
            }
            else
            {
                CD.TrangThai = 0;
                return true;
            }
        }
    }
}
