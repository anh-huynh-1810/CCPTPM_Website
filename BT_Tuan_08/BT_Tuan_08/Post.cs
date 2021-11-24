using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BT_Tuan_08
{
    public class Post
    {
        private int _ID;
        private string _PostTitle;
        private string _PostBrief;
        private string _PostContent;
        private int _PostCat;

        public int ID { get => _ID; set => _ID = value; }
        public string PostTitle { get => _PostTitle; set => _PostTitle = value; }
        public string PostBrief { get => _PostBrief; set => _PostBrief = value; }
        public string PostContent { get => _PostContent; set => _PostContent = value; }
        public int PostCat { get => _PostCat; set => _PostCat = value; }

        public Post(int id, string title, string brief, string content, int cat)
        {
            _ID = id;
            _PostTitle = title;
            _PostBrief = brief;
            _PostContent = content;
            _PostCat = cat;
        }

    }
}
