using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elliela2._0
{
    public class ImdbSearch
    {
        public List<search> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }

        public ImdbSearch(List<search> searches, string totalresult, string response)
        {
            Search = searches;
            totalResults = totalresult;
            Response = response;
            Response = response;
        }
    }

    public class search
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string imdbID { get; set; }
            public string Type { get; set; }
            public string Poster { get; set; }

            public search(string title,string year,string imdbid,string type,string poster)
            {
                Title = title;
                Year = year;
                imdbID = imdbid;
                Type = type;
                Poster = poster;
            }
        }

       
    
}
