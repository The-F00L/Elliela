using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elliela2._0
{
    class record
    {
        private int recordID;
        private Uri path;
        private string imdbID;

        public record(string recordID, string path, string imdbID)
        {
            this.RecordID = int.Parse(recordID);
            this.Path = new Uri(path);
            this.ImdbID = imdbID;
        }

        public int RecordID { get => recordID; set => recordID = value; }
        public Uri Path { get => path; set => path = value; }
        public string ImdbID { get => imdbID; set => imdbID = value; }

    }
}
