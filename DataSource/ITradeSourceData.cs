using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAutoTerminal.DataSource
{
    /// <summary>
    /// Интерфейс для управления данными в виде свечей
    /// </summary>
    interface ITradeSourceData
    {
        /// <summary>
        /// Список свечей
        /// </summary>
        List<Candle> Candles { get; }
        /// <summary>
        /// Список цен открытия
        /// </summary>
        List<double> OpeningPrices { get; }
        /// <summary>
        /// Список цен закрытия
        /// </summary>
        List<double> ClosingPrices { get; }
        /// <summary>
        /// Список самых высоких цен 
        /// </summary>
        List<double> HighestRates { get; }
        /// <summary>
        /// Список самых низких цен
        /// </summary>
        List<double> LowestRates { get; }
        /// <summary>
        /// Значение таймфрейма в секундах
        /// </summary>
        int Timeframe { get; }
        /// <summary>
        /// Получить новую свечу
        /// </summary>
        /// <returns></returns>
        bool GetNewCandle();
    }
}
