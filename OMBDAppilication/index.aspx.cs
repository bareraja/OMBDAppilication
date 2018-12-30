using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Net;
using System.IO;
using System.Xml;

namespace OMBDAppilication
{
    public partial class index : System.Web.UI.Page
    {

        protected void ButtonFInd_Click(object sender, EventArgs e)
        {
            //Metoden bruges så du kan downloade data fra nettet. 
            WebClient client = new WebClient();


            string result = "";

            {
                // substitue " " with "+"
                string myselection = TextBoxInput.Text.Replace(' ', '+');

                if (RadioButtonJSON.Checked) {

                    result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&apikey=" + TokenClass.token);
                }
                else {
                    result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&r=xml&apikey=" + TokenClass.token);
                }
            }

            if (RadioButtonJSON.Checked) {
                File.WriteAllText(Server.MapPath("~/MyFiles/Latestresult.json"), result);

                // A simple example. Treat JSON as a string
                string[] separatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
                string[] mysplit = result.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);

                if (mysplit[1] != "False") {
                    LabelMessages.Text = "Movie found";

                    for (int i = 0; i < mysplit.Length; i++) {
                        if (mysplit[i] == "Poster") {
                            ImagePoster.ImageUrl = mysplit[++i];
                            break;
                        }
                    }

                    LabelResult.Text = "Ratings : ";
                    for(int i =0; i <mysplit.Length; i++) 
                        
                    {
                        if(mysplit[i] == "Ratings") 
                        {

                            while(mysplit[++i] == "Source") 
                            {
                                if (mysplit[i - 1] != "Ratings") LabelResult.Text += "; ";
                                LabelResult.Text += mysplit[i + 3] + "from" + mysplit[i + 1];
                                i = i + 3;
                            }
                            break;

                        }
                       
                    }


                }
                else {
                    LabelMessages.Text = "Movie not found";
                    ImagePoster.ImageUrl = "~/MyFiles/hqdefault.jpg";
                    LabelResult.Text = "Result";
                }
                 
            }

            else 
            {
                File.WriteAllText(Server.MapPath("~/MyFiles/Latestresult.xml"), result);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);

                if(doc.SelectSingleNode("/root/@response").InnerText == "True") 
                {
                    XmlNodeList mynotelist = doc.SelectNodes("/root/movie");
                    foreach (XmlNode node in mynotelist) 
                    {
                        string id = node.SelectSingleNode("@poster").InnerText;
                        ImagePoster.ImageUrl = id;
                    }
                    LabelResult.Text = "Rating" + mynotelist[0].SelectSingleNode("@imdbRating").InnerText;
                    LabelResult.Text += " from " + mynotelist[0].SelectSingleNode("@imdbVotes").InnerText + "voters";
                }
                else 
                {
                    LabelMessages.Text = "Movie not found";
                    ImagePoster.ImageUrl = "~/MyFiles/hqdefault.jpg";
                    LabelResult.Text = "Result";
                }

            }

        }
    }
}