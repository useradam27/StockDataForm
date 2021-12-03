using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project3
{
    public partial class CandleStickGraph : Form
    {
        private List<aCandleStick> candleStickData;
        public CandleStickGraph(List<aCandleStick> data)
        {
            candleStickData = data;
            InitializeComponent();
            loadGraph();
        }

        private void loadGraph()
        {
            for (int i = 0; i < candleStickData.Count; i++)
            {
                chart1.Series[0].Points.AddXY(candleStickData[i].getDate(), candleStickData[i].getHigh(), candleStickData[i].getLow(), candleStickData[i].getOpen(), candleStickData[i].getClose());
            }

            double height = chart1.Series[0].Points[1].YValues[0] - chart1.Series[0].Points[1].YValues[1];
            drawRectangle(height);
        }

        public void drawRectangle(double height)
        {
            //get current Y-axis range for the chart (used for scaling annotations properly)
            double chartRange = chart1.ChartAreas[0].AxisY.Maximum - chart1.ChartAreas[0].AxisY.Minimum;
            Console.WriteLine(chartRange);

            //create annotation
            RectangleAnnotation annotation = new RectangleAnnotation(); //declare annotation to be added
            annotation.SmartLabelStyle.Enabled = false; //allow annotation overlapping
            annotation.BackColor = Color.FromArgb(128); //see-through annotations 
            annotation.Width = 76.0 / candleStickData.Count;   //variable width
            annotation.Height = (height / chartRange) * 88.0; //variable height
            annotation.AnchorOffsetY = -(height / chartRange) * 88.0;   //anchors to middle of the candlestick

            //add annotation to chart
            annotation.SetAnchor(chart1.Series[0].Points[1]);
            chart1.Annotations.Add(annotation);

            return;
        }

        private void identifyNeutral(aCandleStick data)
        {
            //if(data.getOpen() >= )
        }

        private void identifyDragonfly()
        {

        }

        private void identifyLongLegged()
        {

        }

        private void identifyGravestone()
        {

        }

        private void identifyBullishMorubozus()
        {

        }

        private void identifyBearishMorubozus()
        {

        }
    }
}
