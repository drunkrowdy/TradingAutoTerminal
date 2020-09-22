using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAnalysis
{
    class SubtotalsRSI
    {
        /// <summary>
        /// Прмежуточное среднее значение повышений
        /// </summary>
        public double GainsAve;
        /// <summary>
        /// Прмежуточное среднее значение понижений
        /// </summary>
        public double LossesAve;
        /// <summary>
        /// Интервал, период расчета RSI
        /// </summary>
        public int Period;

        public SubtotalsRSI(int period)
        {
            GainsAve = 0;
            LossesAve = 0;
            Period = period;
        }

        public SubtotalsRSI (SubtotalsRSI subRSI)
        {
            GainsAve = subRSI.GainsAve;
            LossesAve = subRSI.LossesAve;
            Period = subRSI.Period;
        }
    }

    class RSI : Indicator
    {
        //Хранит последнее среднее значение повышений и понижений
        public SubtotalsRSI Subtotals;

        public RSI(List<double> rates, int period = 14, string name = "RSI")
            : base("RSI", name)
        {
            try
            {
                //Проверка входных параметров
                if (rates == null)
                    throw new Exception("Нет входных данных");
                if (period < 2)
                    throw new Exception("Период RSI не может быть меньше 2");
                Rates = rates;
                Subtotals = new SubtotalsRSI(period);
                CreateIndicator();
            }
            catch (Exception e)
            {
                ErrorOfInit(e.Message);
            }
            EndOfInit();
        }
        public override bool CreateIndicator()
        {
            Error = "Ok";
            bool res = true;
            int count = Rates.Count();
            Values  = new List<double>(count);
            //пропуск первых {Period} значений
            for (int i = 0; i < Subtotals.Period; i++)
                Values.Add(0);
            //вычисление первого значения
            double summGains = 0;
            double summLosses = 0;

            for (int i = 1; i < Subtotals.Period + 1; i++)
            {
                var d = Rates[i] - Rates[i - 1];
                if (d > 0)
                    summGains += d;
                else
                    summLosses += (-d);
            }
            Subtotals.GainsAve = summGains / Subtotals.Period;
            Subtotals.LossesAve = summLosses / Subtotals.Period;
            double rsi = 0;
            try
            {
                var rs = Subtotals.GainsAve / Subtotals.LossesAve;
                rsi = 100 - 100 / (1 + rs);
            }
            catch
            {
                rsi = 100;
            }
            Values.Add(rsi);
            //вычисляем остальные точки
            AddPoints();
            return res;
        }

        public override bool AddPoints()
        {
            // проверим, есть ли что вообще добавлять
            Error = "Ok";
            bool res = true;
            try
            {
                var Cr = Rates.Count;
                var Cv = Values.Count;
                var dc = Cr - Cv;
                if (dc < 0)
                    throw new Exception("Список значений RSI больше значений исходного ряда.");
                if (dc > 0)
                {
                    for (int i = Cr - dc; i < Cr; i++)
                    {
                        var d = Rates[i] - Rates[i - 1];
                        double rsi;
                        (rsi, Subtotals) = GetPoint(d, Subtotals);
                        Values.Add(rsi);
                    }
                }
            }
            catch (Exception e)
            {
                res = false;
                Error = e.Message;
            }
            return res;
        }
        /// <summary>
        /// Вычисляет одиночное значение RSI и средние значения повышений и понижений на основе разницы цен и предыдущих средних значений повышений и падений 
        /// </summary>
        /// <param name="priceDifference">Разница цен</param>
        /// <param name="period">Интервал, период расчета RSI</param>
        /// <param name="sub_RSI">Предыдущие средние значения повышений и понижений</param>
        /// <returns></returns>
        public static (double rsi, SubtotalsRSI subRsi) GetPoint(double priceDifference, SubtotalsRSI sub_RSI)
        {
            var subRsi = new SubtotalsRSI(sub_RSI);
            var period = subRsi.Period;
            if (priceDifference > 0)
            {
                subRsi.GainsAve = (priceDifference + subRsi.GainsAve * (period - 1)) / period;
                subRsi.LossesAve = (0 + subRsi.LossesAve * (period - 1)) / period;
            }
            else
            {
                subRsi.GainsAve = (0 + subRsi.GainsAve * (period - 1)) / period;
                subRsi.LossesAve = (-priceDifference + subRsi.LossesAve * (period - 1)) / period;
            }
            double rsi = 0;
            try
            {
                var rs = subRsi.GainsAve / subRsi.LossesAve;
                rsi = 100 - 100 / (1 + rs);
            }
            catch
            {
                rsi = 100;
            }
            return (rsi, subRsi);
        }

    }
}
