using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    /// <summary>
    /// Class to represent and keep track of data for candlestick
    /// </summary>
    public class aCandleStick
    {
        /// <summary>
        /// date for given date
        /// </summary>
        private string date;

        /// <summary>
        /// open price for stock
        /// </summary>
        private double open;

        /// <summary>
        /// high price for stock
        /// </summary>
        private double high;

        /// <summary>
        /// low price for stock
        /// </summary>
        private double low;

        /// <summary>
        /// close price for stock
        /// </summary>
        private double close;


        /// <summary>
        /// Constructor for candlestick object
        /// </summary>
        /// <param name="d">date value</param>
        /// <param name="o">open value for stock</param>
        /// <param name="h">high value for stock</param>
        /// <param name="l">low value for stock</param>
        /// <param name="c">close value for stock</param>
        public aCandleStick(string d, double o, double h, double l, double c)
        {
            date = d;
            open = o;
            high = h;
            low = l;
            close = c;
        }

        /// <summary>
        /// returns date value
        /// </summary>
        /// <returns>double value for date</returns>
        public string getDate()
        {
            return date;
        }

        /// <summary>
        /// returns high value
        /// </summary>
        /// <returns>double value for high</returns>
        public double getHigh()
        {
            return high;
        }

        /// <summary>
        /// returns low value
        /// </summary>
        /// <returns>double value for low</returns>
        public double getLow()
        {
            return low;
        }

        /// <summary>
        /// returns open value
        /// </summary>
        /// <returns>double value for open</returns>
        public double getOpen()
        {
            return open;
        }

        /// <summary>
        /// returns close value
        /// </summary>
        /// <returns>double value for close</returns>
        public double getClose()
        {
            return close;
        }
        
        /// <summary>
        /// prints candlestick data, used for testing
        /// </summary>
        /// <returns>string of all values in candlestick</returns>
        public string printCandleData()
        {
            return date + "   " + open + "   " + high + "   " + low + "   " + close + "\n";
        }
    }
}
