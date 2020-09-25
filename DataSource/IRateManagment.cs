using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAutoTerminal.DataSource
{
    /// <summary>
    /// Интерфейс для управления ставками (ордерами) на покупку и продажу валюты
    /// </summary>
    interface IRateManagment
    {
        string CurrencyPair { get; set; }
        long Buy(double quantity, double price);
        long Sell(double quantity, double price);
        long BuyMarket(double quantity);
        long SellMarket(double quantity);
    }
}
