using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Web.Script.Serialization;

namespace Elliela2._0
{
    class omdbapi
    {
       // private string apiKey= "386eaee4";
        private string baseUri = $"http://www.omdbapi.com/?apikey=386eaee4";
        private string result = string.Empty;
        private List<string> imdbId=new List<string>();
        private List<string> poster = new List<string>();
        private List<string> title = new List<string>();
        private string name;
        private string type;
        public omdbapi(string name,string type) {
            this.name = name.TrimEnd();
            this.type = type;
            getBase();
        }
        

        public void getBase() {

            var askBuild = new StringBuilder(baseUri);

            askBuild.Append($"&s={name}");
            askBuild.Append($"&type={type}");

            var request = WebRequest.Create(askBuild.ToString());
            request.Timeout = 1000;
            request.Method = "GET";
            request.ContentType = "application/json";



            try
            {
                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException e)
            {
                MessageBox.Show("Check your internet connection!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error while trying connect the internet'");
            }
            searchBase();
        }

        public void searchBase() {
            
           
            try
            {
                ImdbSearch imdbIDSearch = JsonConvert.DeserializeObject<ImdbSearch>(result);
                for (int i = 0; i < imdbIDSearch.Search.Count; i++)
                {
                    imdbId.Add(imdbIDSearch.Search[i].imdbID);
                    poster.Add(imdbIDSearch.Search[i].Poster);
                    title.Add(imdbIDSearch.Search[i].Title);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("0 found");
            }
           
        }

       
        public List<string> getID() {
            return imdbId;
        }

        public List<string> getPoster()
        {
            return poster;
        }

        public List<string> getTitle()
        {
            return title;
        }



    }
}
