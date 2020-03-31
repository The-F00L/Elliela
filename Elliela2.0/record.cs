using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elliela2._0
{
    class record
    {
        private int rowID;
        private string title;
        private string year;
        private string rated;
        private string released;
        private string runtime;
        private string genre;
        private string director;
        private string writer;
        private string actors;
        private string plot;
        private string lang;
        private string country;
        private string awards;
        private string poster;
        private string imdbId;
        private string type;
        private string dvdRel;
        private string website;
        private string comment;
        private Uri local;

        public record(int rowID, string title, string year, string rated, string released, string runtime, string genre, string director, string writer, string actors, string plot, string lang, string country, string awards, string poster, string imdbId,string type, string dvdRel, string local, string comment )
        {
            this.RowID = rowID;
            this.Title = title;
            this.Year = year;
            this.Rated = rated;
            this.Released = released;
            this.Runtime = runtime;
            this.Genre = genre;
            this.Director = director;
            this.Writer = writer;
            this.Actors = actors;
            this.Plot = plot;
            this.Lang = lang;
            this.Country = country;
            this.Awards = awards;
            this.Poster = poster;
            this.ImdbId = imdbId;
            this.Type = type;
            this.DvdRel = dvdRel;
            this.Website = website;
            this.Comment = comment;
            this.Local = new Uri(local);
        }




        public string Title { get => title; set => title = value; }
        public string Year { get => year; set => year = value; }
        public string Rated { get => rated; set => rated = value; }
        public string Released { get => released; set => released = value; }
        public string Runtime { get => runtime; set => runtime = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Director { get => director; set => director = value; }
        public string Writer { get => writer; set => writer = value; }
        public string Actors { get => actors; set => actors = value; }
        public string Plot { get => plot; set => plot = value; }
        public string Lang { get => lang; set => lang = value; }
        public string Country { get => country; set => country = value; }
        public string Awards { get => awards; set => awards = value; }
        public string Poster { get => poster; set => poster = value; }
        public string ImdbId { get => imdbId; set => imdbId = value; }
        public string Type { get => type; set => type = value; }
        public string DvdRel { get => dvdRel; set => dvdRel = value; }
        public string Website { get => website; set => website = value; }
        public string Comment { get => comment; set => comment = value; }
        public Uri Local { get => local; set => local = value; }
        public int RowID { get => rowID; set => rowID = value; }
    }
}
