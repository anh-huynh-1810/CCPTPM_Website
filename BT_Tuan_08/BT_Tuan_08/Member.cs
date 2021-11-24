using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BT_Tuan_08
{
    public class Member
    {
        private string _UserName;
        private string _Pass;
        private string _TrangThai;

        public string UserName { get => _UserName; set => _UserName = value; }
        public string Pass { get => _Pass; set => _Pass = value; }
        public string TrangThai { get => _TrangThai; set => _TrangThai = value; }

        public Member(string us, string pas, string role, string status)
        {
            _UserName = us;
            _Pass = pas;
            _TrangThai = status;
        }
    }
}
