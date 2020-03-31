using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows;

namespace Elliela2._0
{
    class manageLocalSave
    {

        private SQLiteConnection sqlite_conn = CreateConnection();
        private SQLiteCommand sqlite_cmd;
        private List<record> sqlMovieRecords = new List<record>();
        private List<record> sqlSeriesRecords = new List<record>();
        private List<record> sqlEpisodeRecords = new List<record>();


        internal List<record> SqlMovieRecords { get => sqlMovieRecords; set => sqlMovieRecords = value; }
        internal List<record> SqlSeriesRecords { get => sqlSeriesRecords; set => sqlSeriesRecords = value; }
        internal List<record> SqlEpisodeRecords { get => sqlEpisodeRecords; set => sqlEpisodeRecords = value; }

        public manageLocalSave()
        {
            createDB();
            ReadDataLocal();
        }

        public void tableTypeSelect(string title, string year, string rated, string released, string runtime, string genre, string director, string writer, string actors, string plot, string lang, string country, string awards, string poster, string imdbId, string type, string dvdRel, string website, string comment, Uri local)
        {

            if (!exits(type, imdbId))
            {
                if (type.Equals("movie"))
                {
                    addLocal(title, year, rated, released, runtime, genre, director, writer, actors, plot, lang, country, awards, poster, imdbId, type, dvdRel, website, comment, local);
                }
                if (type.Equals("series"))
                {
                    addLocal(title, year, rated, released, runtime, genre, director, writer, actors, plot, lang, country, awards, poster, imdbId, type, dvdRel, website, comment, local);
                }
                if (type.Equals("episode"))
                {
                    addLocal(title, year, rated, released, runtime, genre, director, writer, actors, plot, lang, country, awards, poster, imdbId, type, dvdRel, website, comment, local);
                }
            }
            else
            {
                MessageBox.Show("This media already exits!");
            }

        }
        private bool exits(string type, string imdbID) {
            if (type.Equals("movie"))
            {
                for (int i = 0; i < SqlMovieRecords.Count; i++)
                {
                    if (sqlMovieRecords[i].ImdbId.Trim().Equals(imdbID))
                    {
                        return true;
                    }
                }
            }
            if (type.Equals("series"))
            {
                for (int i = 0; i < SqlSeriesRecords.Count; i++)
                {
                    if (sqlSeriesRecords[i].ImdbId.Trim().Equals(imdbID))
                    {
                        return true;
                    }
                }
            }
            if (type.Equals("episode"))
            {
                for (int i = 0; i < SqlEpisodeRecords.Count; i++)
                {
                    if (sqlEpisodeRecords[i].ImdbId.Trim().Equals(imdbID))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void addLocal(string title, string year, string rated, string released, string runtime, string genre, string director, string writer, string actors, string plot, string lang, string country, string awards, string poster, string imdbId, string type, string dvdRel, string website, string comment, Uri local)
        {
            if (local!=null)
            {
                if (type.Equals("movie"))
                {
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = "INSERT INTO movies(title,year,rated,released,runtime,genre,director,writer,actors,plot,language,country,awards,poster,imdbID,type,DVD,path,comment)VALUES('" +
                        "" + title.Replace('\'', '`') + "','" + year + "','" + rated + "','" + released + "','" + runtime + "','" + genre + "','" + director.Replace('\'', ' ') + "','" + writer.Replace('\'', ' ') + "','" + actors + "','" + plot.Replace('\'', ' ') + "','" + lang + "','" + country + "','" + awards + "','" + poster + "','" + imdbId + "','" + type + "','" + dvdRel + "','" + local + "','" + comment + "');";

                    sqlite_cmd.ExecuteNonQuery();
                }
                else if (type.Equals("series"))
                {
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = "INSERT INTO series(title,year,rated,released,runtime,genre,director,writer,actors,plot,language,country,awards,poster,imdbID,type,DVD,path,comment)VALUES('" +
                        "" + title.Replace('\'', '`') + "','" + year + "','" + rated + "','" + released + "','" + runtime + "','" + genre + "','" + director.Replace('\'', ' ') + "','" + writer.Replace('\'', ' ') + "','" + actors + "','" + plot.Replace('\'', ' ') + "','" + lang + "','" + country + "','" + awards + "','" + poster + "','" + imdbId + "','" + type + "','" + dvdRel + "','" + local + "','" + comment + "');";

                    sqlite_cmd.ExecuteNonQuery();
                }
                else
                {
                    sqlite_cmd = sqlite_conn.CreateCommand();
                    sqlite_cmd.CommandText = "INSERT INTO episodes(title,year,rated,released,runtime,genre,director,writer,actors,plot,language,country,awards,poster,imdbID,type,DVD,path,comment)VALUES('" +
                        "" + title.Replace('\'', '`') + "','" + year + "','" + rated + "','" + released + "','" + runtime + "','" + genre + "','" + director.Replace('\'', ' ') + "','" + writer.Replace('\'', ' ') + "','" + actors + "','" + plot.Replace('\'', ' ') + "','" + lang + "','" + country + "','" + awards + "','" + poster + "','" + imdbId + "','" + type + "','" + dvdRel + "','" + local + "','" + comment + "');";

                    sqlite_cmd.ExecuteNonQuery();
                }

            }
        }


        private void createDB()
        {
            string createFilmsSQL = "CREATE TABLE IF NOT EXISTS movies(" +
                "  title  VARCHAR(255)  ," +
                "  year  VARCHAR (8)  , " +
                " rated  VARCHAR(16)   ," +
                "  released  VARCHAR(64)   , " +
                " runtime  VARCHAR(127)   ," +
                "  genre  VARCHAR(127)   ," +
                "  director  VARCHAR(127)   ," +
                "  writer  VARCHAR(127)   , " +
                " actors  VARCHAR(255)   , " +
                " plot  TEXT   ," +
                "  language  VARCHAR(32)   , " +
                " country  VARCHAR(32)   ," +
                "  awards  VARCHAR(127)   ," +
                "  poster  VARCHAR(1024)   ," +
                "  imdbID  VARCHAR(64)   , " +
                " type  VARCHAR(16)   , " +
                " DVD  VARCHAR(64)  ," +
                " path    VARCHAR(1024), " +
                " comment    VARCHAR(512))";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = createFilmsSQL;
            sqlite_cmd.ExecuteNonQuery();

            string createSeriesSQL = "CREATE TABLE IF NOT EXISTS series(" +
                "  title  VARCHAR(255)  ," +
                "  year  VARCHAR (8) , " +
                " rated  VARCHAR(16)   ," +
                "  released  VARCHAR(64)   , " +
                " runtime  VARCHAR(127)   ," +
                "  genre  VARCHAR(127)   ," +
                "  director  VARCHAR(127)   ," +
                "  writer  VARCHAR(127)   , " +
                " actors  VARCHAR(255)   , " +
                " plot  TEXT   ," +
                "  language  VARCHAR(32)   , " +
                " country  VARCHAR(32)   ," +
                "  awards  TEXT   ," +
                "  poster  VARCHAR(1024)   ," +
                "  imdbID  VARCHAR(64)   , " +
                " type  VARCHAR(16)   , " +
                " DVD  VARCHAR(64)  ," +
                " path    VARCHAR(1024), " +
                " comment    VARCHAR(512))";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = createSeriesSQL;
            sqlite_cmd.ExecuteNonQuery();

            string createEpisodeSQL = "CREATE TABLE IF NOT EXISTS episodes(" +
                "  title  VARCHAR(255)  ," +
                "  year  VARCHAR(9) , " +
                " rated  VARCHAR(16)   ," +
                "  released  VARCHAR(64)   , " +
                " runtime  VARCHAR(127)   ," +
                "  genre  VARCHAR(127)   ," +
                "  director  VARCHAR(127)   ," +
                "  writer  VARCHAR(127)   , " +
                " actors  VARCHAR(255)   , " +
                " plot  TEXT   ," +
                "  language  VARCHAR(32)   , " +
                " country  VARCHAR(32)   ," +
                "  awards  TEXT   ," +
                "  poster  VARCHAR(1024)   ," +
                "  imdbID  VARCHAR(64)   , " +
                " type  VARCHAR(16)   , " +
                " DVD  VARCHAR(64)  ," +
                " path    VARCHAR(1024), " +
                " comment    VARCHAR(512))";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = createEpisodeSQL;
            sqlite_cmd.ExecuteNonQuery();
        }


        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=LocalEllialeDatabase.db; Version = 3; New = True; Compress = True; ");

            try
            {
                sqlite_conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while trying create database");
            }
            return sqlite_conn;
        }


        public void ReadDataLocal()
        {

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT ROWID,* FROM movies";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            sqlMovieRecords.Clear();
            sqlSeriesRecords.Clear();
            sqlEpisodeRecords.Clear();


            while (sqlite_datareader.Read())
            {
                sqlMovieRecords.Add(new record(sqlite_datareader.GetInt32(0), sqlite_datareader.GetString(1), sqlite_datareader.GetString(2), sqlite_datareader.GetString(3), sqlite_datareader.GetString(4), sqlite_datareader.GetString(5), sqlite_datareader.GetString(6), sqlite_datareader.GetString(7), sqlite_datareader.GetString(8), sqlite_datareader.GetString(9), sqlite_datareader.GetString(10), sqlite_datareader.GetString(11), sqlite_datareader.GetString(12), sqlite_datareader.GetString(13), sqlite_datareader.GetString(14), sqlite_datareader.GetString(15), sqlite_datareader.GetString(16), sqlite_datareader.GetString(17), sqlite_datareader.GetString(18), sqlite_datareader.GetString(19)));
            }

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT ROWID,* FROM series";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                sqlSeriesRecords.Add(new record(sqlite_datareader.GetInt32(0), sqlite_datareader.GetString(1), sqlite_datareader.GetString(2), sqlite_datareader.GetString(3), sqlite_datareader.GetString(4), sqlite_datareader.GetString(5), sqlite_datareader.GetString(6), sqlite_datareader.GetString(7), sqlite_datareader.GetString(8), sqlite_datareader.GetString(9), sqlite_datareader.GetString(10), sqlite_datareader.GetString(11), sqlite_datareader.GetString(12), sqlite_datareader.GetString(13), sqlite_datareader.GetString(14), sqlite_datareader.GetString(15), sqlite_datareader.GetString(16), sqlite_datareader.GetString(17), sqlite_datareader.GetString(18), sqlite_datareader.GetString(19)));

            }

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT ROWID,* FROM episodes";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                sqlEpisodeRecords.Add(new record(sqlite_datareader.GetInt32(0), sqlite_datareader.GetString(1), sqlite_datareader.GetString(2), sqlite_datareader.GetString(3), sqlite_datareader.GetString(4), sqlite_datareader.GetString(5), sqlite_datareader.GetString(6), sqlite_datareader.GetString(7), sqlite_datareader.GetString(8), sqlite_datareader.GetString(9), sqlite_datareader.GetString(10), sqlite_datareader.GetString(11), sqlite_datareader.GetString(12), sqlite_datareader.GetString(13), sqlite_datareader.GetString(14), sqlite_datareader.GetString(15), sqlite_datareader.GetString(16), sqlite_datareader.GetString(17), sqlite_datareader.GetString(18), sqlite_datareader.GetString(19)));
            }

        }

        public List<string> allTitle() {
            List<string> temp=new List<string>();
            temp.Clear();
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                temp.Add(sqlMovieRecords[i].Title);
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                temp.Add(SqlSeriesRecords[i].Title);
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                temp.Add(SqlEpisodeRecords[i].Title);
            }
            return temp.Distinct().ToList();

        }
        public List<string> allYear()
        {
            List<string> temp = new List<string>();
            temp.Clear();
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                temp.Add(sqlMovieRecords[i].Year);
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                temp.Add(SqlSeriesRecords[i].Year);
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                temp.Add(SqlEpisodeRecords[i].Year);
            }
            return temp.Distinct().ToList();

        }
        public List<string> allRated()
        {
            List<string> temp = new List<string>();
            temp.Clear();
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                temp.Add(sqlMovieRecords[i].Rated);
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                temp.Add(SqlSeriesRecords[i].Rated);
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                temp.Add(SqlEpisodeRecords[i].Rated);
            }
            return temp.Distinct().ToList();

        }
        public List<string> allReleased()
        {
            List<string> temp = new List<string>();
            temp.Clear();
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                temp.Add(sqlMovieRecords[i].Released);
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                temp.Add(SqlSeriesRecords[i].Released);
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                temp.Add(SqlEpisodeRecords[i].Released);
            }
            return temp.Distinct().ToList();

        }
        public List<string> allRuntime()
        {
            List<string> temp = new List<string>();
            temp.Clear();
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                temp.Add(sqlMovieRecords[i].Runtime);
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                temp.Add(SqlSeriesRecords[i].Runtime);
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                temp.Add(SqlEpisodeRecords[i].Runtime);
            }
            return temp.Distinct().ToList(); 

        }
        public List<string> allGenre()
        {
            List<string> temp = new List<string>();
            string[] tempT;
            temp.Clear();
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                tempT = SqlMovieRecords[i].Genre.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                tempT = SqlSeriesRecords[i].Genre.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                tempT = sqlEpisodeRecords[i].Genre.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            return temp.Distinct().ToList();

        }
        public List<string> allDirector()
        {
            List<string> temp = new List<string>();
            string[] tempT;
            temp.Clear();
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                tempT = SqlMovieRecords[i].Director.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
                
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                tempT = SqlSeriesRecords[i].Director.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                tempT = SqlEpisodeRecords[i].Director.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            return temp.Distinct().ToList();

        }
        public List<string> allWriter()
        {
            List<string> temp = new List<string>();
            temp.Clear();
            string[] tempT;
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                tempT = SqlMovieRecords[i].Writer.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                tempT = SqlSeriesRecords[i].Writer.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                tempT = SqlEpisodeRecords[i].Writer.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            return temp.Distinct().ToList();

        }
        public List<string> allActors()
        {
            List<string> temp = new List<string>();
            temp.Clear();
            string[] tempT;
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                tempT = SqlMovieRecords[i].Actors.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                tempT = SqlSeriesRecords[i].Actors.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                tempT = SqlEpisodeRecords[i].Actors.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            return temp.Distinct().ToList(); 
        }
        public List<string> allLang()
        {
            List<string> temp = new List<string>();
            temp.Clear();
            string[] tempT;
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                tempT = SqlMovieRecords[i].Lang.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                tempT = SqlSeriesRecords[i].Lang.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                tempT = SqlEpisodeRecords[i].Lang.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            return temp.Distinct().ToList();

        }
        public List<string> allCountry()
        {
            List<string> temp = new List<string>();
            temp.Clear();
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                temp.Add(sqlMovieRecords[i].Country);
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                temp.Add(SqlSeriesRecords[i].Country);
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                temp.Add(SqlEpisodeRecords[i].Country);
            }
            return temp.Distinct().ToList();

        }
        public List<string> allAwards()
        {
            List<string> temp = new List<string>();
            temp.Clear();
            string[] tempT;
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                tempT = SqlMovieRecords[i].Awards.Split('&');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                tempT = SqlSeriesRecords[i].Awards.Split('&');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                tempT = SqlEpisodeRecords[i].Awards.Split('&');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            return temp.Distinct().ToList();

        }
       
        public List<string> allType()
        {
            List<string> temp = new List<string>();
            temp.Clear();
            string[] tempT;
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                tempT = SqlMovieRecords[i].Type.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                tempT = SqlSeriesRecords[i].Type.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                tempT = SqlEpisodeRecords[i].Type.Split(',');
                for (int y = 0; y < tempT.Length; y++)
                {
                    temp.Add(tempT[y]);
                }
            }
            return temp.Distinct().ToList();

        }
        public List<string> alldvdRel()
        {
            List<string> temp = new List<string>();
            temp.Clear();
            for (int i = 0; i < SqlMovieRecords.Count; i++)
            {
                temp.Add(sqlMovieRecords[i].DvdRel);
            }
            for (int i = 0; i < SqlSeriesRecords.Count; i++)
            {
                temp.Add(SqlSeriesRecords[i].DvdRel);
            }
            for (int i = 0; i < SqlEpisodeRecords.Count; i++)
            {
                temp.Add(SqlEpisodeRecords[i].DvdRel);
            }
            return temp.Distinct().ToList(); ;

        }
       
        public List<string> allTitle(string type) {
            ReadDataLocal();
            List<string> titleList = new List<string>();
            if (type.Equals("movie"))
            {
                for (int i = 0; i < sqlMovieRecords.Count; i++)
                {
                    titleList.Add(sqlMovieRecords[i].Title);
                }
                return titleList;
            }
            if (type.Equals("series"))
            {
                for (int i = 0; i < sqlSeriesRecords.Count; i++)
                {
                    titleList.Add(sqlSeriesRecords[i].Title);
                }
                return titleList;
            }
            if (type.Equals("episode"))
            {
                for (int i = 0; i < sqlEpisodeRecords.Count; i++)
                {
                    titleList.Add(sqlEpisodeRecords[i].Title);
                }
                return titleList;
            }
            return null;
        }

        public List<string> allimdbid(string type)
        {
            List<string> imdbIDList = new List<string>();
            if (type.Equals("movie"))
            {
                for (int i = 0; i < sqlMovieRecords.Count; i++)
                {
                    imdbIDList.Add(sqlMovieRecords[i].ImdbId);
                }
                return imdbIDList;
            }
            if (type.Equals("series"))
            {
                for (int i = 0; i < sqlSeriesRecords.Count; i++)
                {
                    imdbIDList.Add(sqlSeriesRecords[i].ImdbId);
                }
                return imdbIDList;
            }
            if (type.Equals("episode"))
            {
                for (int i = 0; i < sqlEpisodeRecords.Count; i++)
                {
                    imdbIDList.Add(sqlEpisodeRecords[i].ImdbId);
                }
                return imdbIDList;
            }
            return null;
        }

        public void commentUpdate(string type, int rowid, string comment)
        {
            if (type.Equals("movie"))
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "UPDATE movies " +
                    "SET comment = '" + comment + "' " +
                    "WHERE ROWID = " + rowid;
                sqlite_cmd.ExecuteNonQuery();
            }
            else if (type.Equals("series"))
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "UPDATE series " +
                    "SET comment = '" + comment + "' " +
                    "WHERE ROWID = " + rowid;
                sqlite_cmd.ExecuteNonQuery();
            }
            else
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "UPDATE episodes " +
                    "SET comment = '" + comment + "' " +
                    "WHERE ROWID = " + rowid;
                sqlite_cmd.ExecuteNonQuery();
            }
            
            
        }
       

        public void pathUpdate(string type,int rowid,Uri path) {

            if (type.Equals("movie"))
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "UPDATE movies " +
                    "SET path = '" + path + "' " +
                    "WHERE ROWID = " + rowid;
                sqlite_cmd.ExecuteNonQuery();
            }
            else if (type.Equals("series"))
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "UPDATE series " +
                    "SET path = '" + path + "' " +
                    "WHERE ROWID = " + rowid;
                sqlite_cmd.ExecuteNonQuery();
            }
            else
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "UPDATE episodes " +
                    "SET path = '" + path + "' " +
                    "WHERE ROWID = " + rowid;
                sqlite_cmd.ExecuteNonQuery();
            }

        }

        public void deleteFromLocal(string type,int rowid) {
            if (type.Equals("movie"))
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM movies WHERE ROWID="+rowid;
                sqlite_cmd.ExecuteNonQuery();
            }
            else if (type.Equals("series"))
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM series WHERE ROWID=" + rowid;
                sqlite_cmd.ExecuteNonQuery();
            }
            else
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "DELETE FROM episodes WHERE ROWID=" + rowid;
                sqlite_cmd.ExecuteNonQuery();
            }

        }

        public List<record> localSearch(List<string> titles, List<string> years, List<string> rateds, List<string> releaseds, List<string> runtimes, List<string> genres, List<string> directors, List<string> writers, List<string> actorss, List<string> languages, List<string> countrys, List<string> types,List<string> awards) {
            List<record> temp = new List<record>();

            for (int y = 0; y < titles.Count; y++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Title.Equals(titles[y]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Title.Equals(titles[y]))
                    {
                         temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Title.Equals(titles[y]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
                    
                
            }

            for (int i = 0; i < years.Count; i++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Year.Equals(years[i]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Year.Equals(years[i]))
                    {
                        temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Year.Equals(years[i]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
            }

            for (int j = 0; j < rateds.Count; j++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Rated.Equals(rateds[j]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Rated.Equals(rateds[j]))
                    {
                        temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Rated.Equals(rateds[j]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
            }

            for (int l = 0; l < releaseds.Count; l++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Released.Equals(releaseds[l]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Released.Equals(releaseds[l]))
                    {
                        temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Released.Equals(releaseds[l]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
            }

            for (int q = 0; q < runtimes.Count; q++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Runtime.Equals(runtimes[q]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Runtime.Equals(runtimes[q]))
                    {
                        temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Runtime.Equals(runtimes[q]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
            }

            for (int p = 0; p < genres.Count; p++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Genre.Contains(genres[p]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Genre.Contains(genres[p]))
                    {
                        temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Genre.Contains(genres[p]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
            }

            for (int d = 0; d < directors.Count; d++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Director.Contains(directors[d]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Director.Contains(directors[d]))
                    {
                        temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Director.Contains(directors[d]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
            }

            for (int w = 0; w < writers.Count; w++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Writer.Contains(writers[w]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Writer.Contains(writers[w]))
                    {
                        temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Writer.Contains(writers[w]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
            }

            for (int a = 0; a < actorss.Count; a++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Actors.Contains(actorss[a]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Actors.Contains(actorss[a]))
                    {
                        temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Actors.Contains(actorss[a]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
            }

            for (int la = 0; la < languages.Count; la++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Lang.Contains(languages[la]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Lang.Contains(languages[la]))
                    {
                        temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Lang.Contains(languages[la]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
            }

            for (int c = 0; c < countrys.Count; c++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Country.Contains(countrys[c]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Country.Contains(countrys[c]))
                    {
                        temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Country.Contains(countrys[c]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
            }

            for (int t = 0; t < types.Count; t++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Type.Equals(types[t]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Type.Contains(types[t]))
                    {
                        temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Type.Contains(types[t]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
            }

            for (int aw = 0; aw < awards.Count; aw++)
            {
                for (int m = 0; m < sqlMovieRecords.Count; m++)
                {
                    if (sqlMovieRecords[m].Awards.Equals(awards[aw]))
                    {
                        temp.Add(sqlMovieRecords[m]);
                    }
                }
                for (int s = 0; s < sqlSeriesRecords.Count; s++)
                {
                    if (sqlSeriesRecords[s].Awards.Contains(awards[aw]))
                    {
                        temp.Add(sqlSeriesRecords[s]);
                    }
                }
                for (int e = 0; e < sqlEpisodeRecords.Count; e++)
                {
                    if (sqlSeriesRecords[e].Awards.Contains(awards[aw]))
                    {
                        temp.Add(sqlEpisodeRecords[e]);
                    }
                }
            }

            return temp;
        }


    }
    }
