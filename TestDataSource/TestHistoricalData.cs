using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAutoTerminal.DataSource;

//потом удалить
using static TradingAutoTerminal.Helpers.Helper;

namespace TradingAutoTerminal.TestDataSource
{
    class TestHistoricalData : ITradeSourceData, IRateManagment
    {

        
        List<Candle> candles = new List<Candle>();
        int timeframe = 0;
        public bool IsValid => validateData();

        //реализация свойств интерфейса ITradeSourceData
        public string CurrencyPair { get; set; }
        public List<Candle> Candles { get { return candles; } }
        public List<double> OpeningPrices { get { return getPrices("Open"); } }
        public List<double> ClosingPrices => getPrices("Close");
        public List<double> HighestRates => getPrices("High");
        public List<double> LowestRates => getPrices("Low");
        public int Timeframe => timeframe;
        
        public TestHistoricalData(int timeframe, string filename)
        {
            this.timeframe = timeframe;
            //считать данные из файла 
            string text = ReadStringFromFile(filename);
            if (text != null)
            {
                text = text.Replace("\r", "");
                List<string> str = text.Split('\n').ToList();
                str.RemoveAt(0);
                str.RemoveAt(0);
                int i = 0;
                foreach (string v in str)
                {
                    var s = v.Split('/');
                    //var c = new TestCandle();
                    try
                    {
                        var c = new TestCandle()
                        {
                            Open = Convert.ToDouble(s[1]),
                            High = Convert.ToDouble(s[2]),
                            Low = Convert.ToDouble(s[3]),
                            Close = Convert.ToDouble(s[4]),
                            TimeUTC = i * timeframe * 60
                        };
                        Candles.Add(c);
                        i++;
                    }
                    catch { }
                }
            }
        }

        bool validateData()
        {
            bool res = true;
            if (candles.Count < 100) res = false;
            return res;
        }




        //реализация методов интерфейса ITradeSourceData
        public bool GetNewCandle()
        {
            throw new NotImplementedException();
        }

        //реализация методов интерфейса IRateManagment
        
        public long Buy(double quantity, double price)
        {
            throw new NotImplementedException();
        }

        public long BuyMarket(double quantity)
        {
            throw new NotImplementedException();
        }

        public long Sell(double quantity, double price)
        {
            throw new NotImplementedException();
        }

        public long SellMarket(double quantity)
        {
            throw new NotImplementedException();
        }






        List<double> getPrices(string propertyName)
        {
            var prices = new List<double>();
            var property = typeof(Candle).GetProperty(propertyName);
            foreach (var c in candles) prices.Add((double)property.GetValue(c));
            return prices;
        }



    }
}
