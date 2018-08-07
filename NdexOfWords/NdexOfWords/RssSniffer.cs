using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace NdexOfWords
{
    class RssSniffer : Form
    {        //[STAThread]
        //static void Main(string[] args) { Application.Run(new RssSniffer()); }


        public List<RssNews> news = new List<RssNews>();

        public RssSniffer()
        {
            XmlReader reader = XmlReader.Create("https://www.aktualne.cz/rss/");
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items) news.Add(new RssNews(item.Title.Text, item.Summary.Text, item.Links.First().Uri.ToString(), item.PublishDate.ToString()));
            RichTextBox newsTextBox = new RichTextBox { Dock = DockStyle.Fill };
            Controls.Add(newsTextBox);
            newsTextBox.Text = "News Count: " + news.Count.ToString();
            foreach (RssNews rn in news) newsTextBox.Text += "\r\n" + rn.ToString();
        }
    }
    internal class RssNews
    {
        public string Subject { get; private set; }
        public string Link { get; private set; }
        public string Summary { get; private set; }
        public string Date { get; private set; }

        public RssNews(string subject, string summary, string link, string date)
        {
            Subject = subject;
            Summary = summary;
            Link = link;
            Date = date;
        }

        public override string ToString()
        {
            string output = "\r\n# " + Subject;
            output += "\r\n=>" + Summary;
            output += "\r\n" + Link;
            output += "\r\n@ " + Date;
            return output;
        }
    }
}
