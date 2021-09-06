using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newssite.Pages
{
    public class News
    {
        private int Id { get; set; }
        public string Header { get; set; }
        public string NewsText { get; set; }
        public DateTime Posted { get; set; }
        public string Poster { get; set; }

        public News (string header, string newsText, DateTime posted, string poster)
        {
            Header = header;
            NewsText = newsText;
            Posted = posted;
            Poster = poster;
        }

        public News (string header, string newsText, string posted, string poster)
        {
            Header = header;
            NewsText = newsText;
            Posted = DateTime.Parse(posted);
            Poster = poster;
        }

        public News (int id, string header, string newsText, DateTime posted, string poster)
        {
            Id = id;
            Header = header;
            NewsText = newsText;
            Posted = posted;
            Poster = poster;
        }

        public News (int id, string header, string newsText, string posted, string poster)
        {
            Id = id;
            Header = header;
            NewsText = newsText;
            Posted = DateTime.Parse(posted);
            Poster = poster;
        }

    }
}
