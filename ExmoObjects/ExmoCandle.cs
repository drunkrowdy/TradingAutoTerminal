using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TradingAutoTerminal.DataSource;

namespace TradingAutoTerminal.ExmoObjects
{
    class ExmoCandle : Candle
    {
        public long TimeUTC { get; set; }
        public override DateTime DTime { get { return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(TimeUTC)); } }
    }
}
