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
    /// <summary>
    /// Form for displaying candlestick graph
    /// </summary>
    public partial class CandleStickGraph : Form
    {
        /// <summary>
        /// contains all candlesticks
        /// </summary>
        private List<aCandleStick> candleStickData;
        public CandleStickGraph(List<aCandleStick> data)
        {
            candleStickData = data;
            InitializeComponent();
            loadGraph();

            patternBox.SelectedIndex = 0;
        }

        /// <summary>
        /// plots graph with all candlestick data
        /// </summary>
        private void loadGraph()
        {
            for (int i = 0; i < candleStickData.Count; i++)
            {
                chart1.Series[0].Points.AddXY(candleStickData[i].getDate(), candleStickData[i].getHigh(), candleStickData[i].getLow(), candleStickData[i].getOpen(), candleStickData[i].getClose());
            }

        }

        /// <summary>
        /// draws annotations onto the graph
        /// </summary>
        /// <param name="data">data from aCandleStick object</param>
        /// <param name="pos">index of candlestick</param>
        public void drawAnnotaiton(aCandleStick data, int pos)
        {

            double candleHeight = chart1.Series[0].Points[pos].YValues[0] - chart1.Series[0].Points[pos].YValues[1];
            double chart1Height = chart1.ChartAreas[0].AxisY.Maximum - chart1.ChartAreas[0].AxisY.Minimum;

            //creates annotation
            RectangleAnnotation rect = new RectangleAnnotation();
            rect.SmartLabelStyle.Enabled = false;

            rect.Width = 80.0 / candleStickData.Count; 
            rect.Height = (candleHeight / chart1Height) * 100;
            rect.AnchorOffsetY = -(candleHeight / chart1Height) * 100;

            //allows rectangle to be transparant
            rect.BackColor = Color.FromArgb(128);

            rect.SetAnchor(chart1.Series[0].Points[pos]);
            chart1.Annotations.Add(rect);
        }
        /// <summary>
        /// Identifies if a neutral doji on the graph
        /// </summary>
        /// <param name="data">data from aCandleStick object</param>
        /// <param name="pos">index of candlestick</param>
        private void identifyNeutral(aCandleStick data, int pos)
        {
            //open and close at nearly the same price
            //high to close, nearly same distance as open to low

            double upperWick;
            double lowerWick;

            if (data.getOpen() > data.getClose())
            {
                upperWick = data.getHigh() - data.getOpen();
                lowerWick = data.getClose() - data.getLow();
            }
            else
            {
                upperWick = data.getHigh() - data.getClose();
                lowerWick = data.getOpen() - data.getLow();
            }

            //length of entire candle
            double candleLength = Math.Abs((data.getHigh() - data.getLow()));
            //length of body of candle
            double bodyLength = Math.Abs((candleLength) - (upperWick + lowerWick));


            if (((bodyLength / candleLength) < .20) && (upperWick / lowerWick >= .8) && (upperWick / lowerWick <= 1.2))
            {
                drawAnnotaiton(data, pos);
            }
        }

        /// <summary>
        /// Identifies dragonfly doji on the graph
        /// </summary>
        /// <param name="data">data from aCandleStick object</param>
        /// <param name="pos">index of candlestick</param>
        private void identifyDragonfly(aCandleStick data, int pos)
        {
            //close and open at nearly same price
            //both open and close near high

            double upperWick;
            double lowerWick;

            if(data.getOpen() > data.getClose())
            {
                upperWick = data.getHigh() - data.getOpen();
                lowerWick = data.getClose() - data.getLow();
            }
            else
            {
                upperWick = data.getHigh() - data.getClose();
                lowerWick = data.getOpen() - data.getLow();
            }

            //length of entire candle
            double candleLength = Math.Abs((data.getHigh() - data.getLow()));
            //length of body of candle
            double bodyLength =  Math.Abs((candleLength) - (upperWick + lowerWick));

            if (((bodyLength/candleLength) < .25) && (lowerWick/upperWick > 5))
            {
                drawAnnotaiton(data, pos);
            }
        }

        /// <summary>
        /// Identifies long legged doji on the graph
        /// </summary>
        /// <param name="data">data from aCandleStick object</param>
        /// <param name="pos">index of candlestick</param>
        private void identifyLongLegged(aCandleStick data, int pos)
        {
            //close and open at nearly the same price
            //wicks need to be very long

            double upperWick;
            double lowerWick;

            if (data.getOpen() > data.getClose())
            {
                upperWick = data.getHigh() - data.getOpen();
                lowerWick = data.getClose() - data.getLow();
            }
            else
            {
                upperWick = data.getHigh() - data.getClose();
                lowerWick = data.getOpen() - data.getLow();
            }

            //length of entire candle
            double candleLength = Math.Abs((data.getHigh() - data.getLow()));
            //length of body of candle
            double bodyLength = Math.Abs((candleLength) - (upperWick + lowerWick));

            if (((bodyLength / candleLength) < .15)  && (upperWick / lowerWick >= .8) && (upperWick / lowerWick <= 1.2))
            {
                drawAnnotaiton(data, pos);
            }
        }

        /// <summary>
        /// Identifies Gravestone doji on the graph
        /// </summary>
        /// <param name="data">data from aCandleStick object</param>
        /// <param name="pos">index of candlestick</param>
        private void identifyGravestone(aCandleStick data, int pos)
        {
            //open and close nearly same price
            //both open and close near low

            double upperWick;
            double lowerWick;

            if (data.getOpen() > data.getClose())
            {
                upperWick = data.getHigh() - data.getOpen();
                lowerWick = data.getClose() - data.getLow();
            }
            else
            {
                upperWick = data.getHigh() - data.getClose();
                lowerWick = data.getOpen() - data.getLow();
            }

            //length of entire candle
            double candleLength = Math.Abs((data.getHigh() - data.getLow()));
            //length of body of candle
            double bodyLength = Math.Abs((candleLength) - (upperWick + lowerWick));


            if (((bodyLength / candleLength) < .25) && (upperWick / lowerWick > 5))
            {
                drawAnnotaiton(data, pos);
            }
        }

        /// <summary>
        /// Identifies Bullish Morubozus on the graph
        /// </summary>
        /// <param name="data">data from aCandleStick object</param>
        /// <param name="pos">index of candlestick</param>
        private void identifyBullishMorubozus(aCandleStick data, int pos)
        {
            //open = low, close = high

            //length of entire candle
            double openRatio = data.getOpen() / data.getLow();
            //length of body of candle
            double closeRatio = data.getClose() / data.getHigh();


            if ((openRatio > .97 && openRatio < 1.01) && (closeRatio > .97 && closeRatio < 1.01))
            {
                drawAnnotaiton(data, pos);
            }
        }

        /// <summary>
        /// Identifies bearish morubozus on the graph
        /// </summary>
        /// <param name="data">data from aCandleStick object</param>
        /// <param name="pos">index of candlestick</param>
        private void identifyBearishMorubozus(aCandleStick data, int pos)
        {
            //open = high, close = low

            //length of entire candle
            double openRatio = data.getOpen() / data.getHigh();
            //length of body of candle
            double closeRatio = data.getClose() / data.getLow();


            if ((openRatio > .97 && openRatio < 1.01) && (closeRatio > .97 && closeRatio < 1.01))
            {
                drawAnnotaiton(data, pos);
            }
        }

        /// <summary>
        /// Graphs annotations onto the graph depending on user's choice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patterns_button_Click(object sender, EventArgs e)
        {
            //clears previus annotations
            chart1.Annotations.Clear();

            switch (patternBox.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < candleStickData.Count; i++)
                    {
                        identifyNeutral(candleStickData[i], i);
                    }
                    break;
                case 1:
                    for (int i = 0; i < candleStickData.Count; i++)
                    {
                        identifyLongLegged(candleStickData[i], i);
                    }
                    break;
                case 2:
                    for (int i = 0; i < candleStickData.Count; i++)
                    {
                        identifyGravestone(candleStickData[i], i);
                    }
                    break;
                case 3:
                    for (int i = 0; i < candleStickData.Count; i++)
                    {
                        identifyDragonfly(candleStickData[i], i);
                    }
                    break;
                case 4:
                    for (int i = 0; i < candleStickData.Count; i++)
                    {
                        identifyBullishMorubozus(candleStickData[i], i);
                    }
                    break;
                case 5:
                    for (int i = 0; i < candleStickData.Count; i++)
                    {
                        identifyBearishMorubozus(candleStickData[i], i);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
