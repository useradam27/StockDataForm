using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3
{
    /// <summary>
    /// Main form for program
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// holds all text from csv file that holds tickers info
        /// </summary>
        private string[] csvText = Properties.Resources.SP500.Split('\n');

        /// <summary>
        /// holds all information to graph candlesticks
        /// </summary>
        private List<aCandleStick> allCandleSticks;

        public Form1()
        {
            
            InitializeComponent();
            
            foreach (string s in csvText)
            {
                string[] values = s.Split(',');
                ticker_box.Items.Add(values[0]);
            }

            intervalBox.SelectedIndex = 1;
           
        }

        /// <summary>
        /// creates link to get stock infromation from
        /// </summary>
        /// <returns>string value for entire link</returns>
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

            link += "&interval=";
            if (intervalBox.Text == "1 day")
                link += "1d";
            else if (intervalBox.Text == "1 week")
                link += "1wk";
            else if (intervalBox.Text == "1 month")
                link += "1mo";
            link += "&events=history&includeAdjustedClose=true";

            return link;



        }

        /// <summary>
        /// Creates link, and gets data from link.  Launches Graph form with data to plot.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        { 
            //gets data from link
            string URL = createLink();
            WebRequest request = WebRequest.Create(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            string[] lines = responseFromServer.Split('\n');

            allCandleSticks = new List<aCandleStick>();

            //puts data into aCandleStick List
            int count = 0;
            foreach (string s in lines)
            {
                if (count != 0)
                {
                    string[] text = s.Split(',');
                    aCandleStick temp = new aCandleStick(text[0], Convert.ToDouble(text[1]), Convert.ToDouble(text[2]), Convert.ToDouble(text[3]), Convert.ToDouble(text[4]));
                    allCandleSticks.Add(temp);
                }
                count++;

            }
            

            reader.Close();
            dataStream.Close();

            //generates graph
            Form graphForm = new CandleStickGraph(allCandleSticks);
            graphForm.Show();

            
        }
    }
}
