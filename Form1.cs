using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3
{
    public partial class Form1 : Form
    {
        private string[] csvText = Properties.Resources.SP500.Split('\n');

        public Form1()
        {
            //WebClient wc = new WebClient();
            
            InitializeComponent();
            /*
            string testURL = "https://query1.finance.yahoo.com/v7/finance/download/TSLA?period1=1606071921&period2=1637607921&interval=1wk&events=history&includeAdjustedClose=true";
            WebRequest request = WebRequest.Create(testURL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            string[] lines = responseFromServer.Split(',');
            richTextBox1.Text = responseFromServer;
            */

            foreach (string s in csvText)
            {
                string[] values = s.Split(',');
                Console.WriteLine(values[0]);
                ticker_box.Items.Add(values[0]);
            }

            DateTime t = dateTimePicker1.Value;
            long unixTime = ((DateTimeOffset)t).ToUnixTimeSeconds();
            Console.WriteLine(unixTime);
        }

        public string createLink()
        {
            string link = "https://query1.finance.yahoo.com/v7/finance/download/";
            link += ticker_box.Text;
            link += "?period1=";

            DateTime t1 = dateTimePicker1.Value;
            long unixTime1 = ((DateTimeOffset)t1).ToUnixTimeSeconds();

            link += unixTime1;
            link += "&period2=";

            DateTime t2 = dateTimePicker2.Value;
            long unixTime2 = ((DateTimeOffset)t2).ToUnixTimeSeconds();

            link += unixTime2;

            link += "&interval=1wk&events=history&includeAdjustedClose=true";

            return link;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string testURL = "https://query1.finance.yahoo.com/v7/finance/download/TSLA?period1=1606435200&period2=1637971200&interval=1wk&events=history&includeAdjustedClose=true";
            string testURL = createLink();
            WebRequest request = WebRequest.Create(testURL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            string[] lines = responseFromServer.Split(',');
            richTextBox1.Text = responseFromServer;

            reader.Close();
            dataStream.Close();
        }
    }
}
