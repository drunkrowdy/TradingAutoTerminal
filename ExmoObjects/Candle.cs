using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAutoTerminal.ExmoObjects
{
    class Candle
    {
        public long TimeUTC { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Volume { get; set; }
        public DateTime Time { get { return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(TimeUTC)); } }
    }
}
