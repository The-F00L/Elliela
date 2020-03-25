using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public manageLocalSave()
        {
            createDB();
            ReadDataMovie();
            createDB();
            ReadDataSeries();
            createDB();
            ReadDataEpisode();
        }

        public void tableTypeSelect(string type, Uri local, string imdbId)
        {

            if (!exits(type,imdbId))
            {
                if (type.Equals("movie"))
                {
                    addLocalMovie(local,imdbId);
                }
                if (type.Equals("series"))
                {
                    addLocalSeries(local, imdbId);
                }
                if (type.Equals("episode"))
                {
                    addLocalEpisode(local, imdbId);
                }
            }
            else
            {
                MessageBox.Show("This media already exits!");
                MessageBox.Show(sqlMovieRecords[0].ToString());
            }
            
        }
        private bool exits(string type,string imdbID) {
            if (type.Equals("movie"))
            {
                for (int i = 0; i < sqlMovieRecords.Count; i++)
                {
                    MessageBox.Show("for");
                    if (sqlMovieRecords[i].ImdbID.Equals(imdbID))
                    {
                        MessageBox.Show("IF");
                        return true;
                    }
                }
            }
            if (type.Equals("series"))
            {
                for (int i = 0; i < sqlSeriesRecords.Count; i++)
                {
                    if (sqlSeriesRecords[i].ImdbID.Equals(imdbID))
                    {
                        return true;
                    }
                }
            }
            if (type.Equals("episode"))
            {
                for (int i = 0; i < sqlEpisodeRecords.Count; i++)
                {
                    if (sqlEpisodeRecords[i].ImdbID.Equals(imdbID))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void addLocalMovie(Uri localDest, string imdbID)
        {
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO movies(movieID, path, imdbID) VALUES( null,'" + localDest + "','" + imdbID + "');";
            sqlite_cmd.ExecuteNonQuery();
        }

        private void addLocalSeries(Uri localDest, string imdbID)
        {
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO series(seriesID, path, imdbID) VALUES('null','" + localDest + "','" + imdbID + "');";
            sqlite_cmd.ExecuteNonQuery();
        }
        private void addLocalEpisode(Uri localDest, string imdbID)
        {
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO episodes(episodeID, path, imdbID) VALUES('null','" + localDest + "','" + imdbID + "');";
            sqlite_cmd.ExecuteNonQuery();
        }

        private void createDB()
        {
            string createFilmsSQL = "CREATE TABLE IF NOT EXISTS movies(movieID INTEGER PRIMARY KEY,path VARCHAR(255),imdbID VARCHAR(10))";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = createFilmsSQL;
            sqlite_cmd.ExecuteNonQuery();

            string createSeriesSQL = "CREATE TABLE IF NOT EXISTS series(seriesID INTEGER PRIMARY KEY,path VARCHAR(255),imdbID VARCHAR(10))";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = createSeriesSQL;
            sqlite_cmd.ExecuteNonQuery();

            string createEpisodeSQL = "CREATE TABLE IF NOT EXISTS episodes(episodeID INTEGER PRIMARY KEY,path VARCHAR(255),imdbID VARCHAR(10))";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = createEpisodeSQL;
            sqlite_cmd.ExecuteNonQuery();
        }

        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=database1.db; Version = 3; New = True; Compress = True; ");
            
            try
                {
                sqlite_conn.Open();
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex);
                }
            return sqlite_conn;
        }

        
        public void ReadDataMovie()
        {
            SQLiteDataReader sqlite_datareader;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM movies";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                string[] line = sqlite_datareader.GetString(0).Split(' ');
                sqlMovieRecords.Add(new record(line[0], line[1], line[2]));
            }
            sqlite_conn.Close();
        }

        public void ReadDataSeries()
        {
            SQLiteDataReader sqlite_datareader;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM series";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                string[] line = sqlite_datareader.GetString(0).Split(' ');
                sqlSeriesRecords.Add(new record(line[0], line[1], line[2]));
            }
            sqlite_conn.Close();
        }

        public void ReadDataEpisode()
        {
            SQLiteDataReader sqlite_datareader;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM episodes";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                string[] line = sqlite_datareader.GetString(0).Split(' ');
                sqlEpisodeRecords.Add(new record(line[0], line[1], line[2]));
            }
            sqlite_conn.Close();
        }


    }

}

