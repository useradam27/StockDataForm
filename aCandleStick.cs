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
    class aCandleStick
    {
        /// <summary>
        /// date for given date
        /// </summary>
        private string date;

        /// <summary>
        /// high price for stock
        /// </summary>
        private float high;

        /// <summary>
        /// low price for stock
        /// </summary>
        private float low;

        /// <summary>
        /// open price for stock
        /// </summary>
        private float open;

        /// <summary>
        /// close price for stock
        /// </summary>
        private float close;


        /// <summary>
        /// Constructor for candlestick object
        /// </summary>
        /// <param name="d">date value</param>
        /// <param name="h">high value for stock</param>
        /// <param name="l">low value for stock</param>
        /// <param name="o">open value for stock</param>
        /// <param name="c">close value for stock</param>
        public aCandleStick(string d, float h, float l, float o, float c)
        {
            date = d;
            high = h;
            low = l;
            open = o;
            close = c;
        }

        /// <summary>
        /// returns date value
        /// </summary>
        /// <returns>sting value for date</returns>
        public string getDate()
        {
            return date;
        }

        /// <summary>
        /// returns high value
        /// </summary>
        /// <returns>float value for high</returns>
        public float getHigh()
        {
            return high;
        }

        /// <summary>
        /// returns low value
        /// </summary>
        /// <returns>float value for low</returns>
        public float getLow()
        {
            return low;
        }

        /// <summary>
        /// returns open value
        /// </summary>
        /// <returns>float value for open</returns>
        public float getOpen()
        {
            return open;
        }

        /// <summary>
        /// returns close value
        /// </summary>
        /// <returns>float value for close</returns>
        public float getClose()
        {
            return close;
        }
    }
}
