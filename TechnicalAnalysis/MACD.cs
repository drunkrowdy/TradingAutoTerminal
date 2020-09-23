using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAnalysis
{
    class SubtotalsMACD : Subtotals
    {
        public double EMA_fast;
        public double EMA_slow;
        public double EMA_sig;
        public double A_fast;
        public double A_slow;
        public double A_sig;

        public SubtotalsMACD(int fast_ma, int slow_ma, int signal)
        {
            A_fast = 2.0 / (fast_ma + 1);
            A_slow = 2.0 / (slow_ma + 1);
            A_sig = 2.0 / (signal + 1);
        }
        public SubtotalsMACD(SubtotalsMACD subMACD)
        {
            EMA_fast = subMACD.EMA_fast;
            EMA_slow = subMACD.EMA_slow;
            EMA_sig = subMACD.EMA_sig;
            A_fast = subMACD.A_fast;
            A_slow = subMACD.A_slow;
            A_sig = subMACD.A_sig;
            Price = subMACD.Price;
            PreviousPrice = subMACD.PreviousPrice;
        }
    }
    class MACDValue
    {
        public double FastMACD { get; set; }
        public double Signal { get; set; }
        public double Histogram { get; set; }
    }


    class MACD : Indicator
    {
        int FastMA_Period;
        int SlowMA_Period; 
        int Signal_Period;
        SubtotalsMACD Subtotals;
        public new List<MACDValue> Values { get; set; }

        /// <summary>
        /// Возвращает список значений, соответствующих индикатору MACD за указанный период
        /// </summary>
        /// <param name="rates">Список цен</param>
        /// <param name="fast_ma">Период "быстрой" скользящей</param>
        /// <param name="slow_ma">Период "медленной" скользящей</param>
        /// <param name="signal">Период сигнала</param>
        /// <param name="name">Индивидуальное имя индикатора</param>
        /// <returns></returns>
        public MACD(List<double> rates, int fast_ma = 12, int slow_ma = 26, int signal = 9, string name = "MACD")
            : base("MACD", name)
        {
            try
            {
                //Проверка входных параметров
                if (rates == null)
                    throw new Exception("Нет входных данных");
                if (fast_ma < 2 || slow_ma < 2 || signal < 2)
                    throw new Exception("Параметры скользящих должны быть не меньше 2");
                Rates = rates;
                FastMA_Period = fast_ma;
                SlowMA_Period = slow_ma;
                Signal_Period = signal;
                Subtotals = new SubtotalsMACD(fast_ma,slow_ma,signal);
                Values = new List<MACDValue>(rates.Count);
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

            //Нулевой элемент выходных данных равен нулю
            Values.Add(new MACDValue() { FastMACD = 0, Signal = 0 });
            //настройка промежуточных итогов для следующего элемента
            Subtotals.Price = Rates[1];
            Subtotals.PreviousPrice = Rates[0];
            Subtotals.EMA_fast = Rates[0];
            Subtotals.EMA_slow = Rates[0];
            Subtotals.EMA_sig = 0;

            //var ema_fast = Rates[0];
            //var ema_slow = Rates[0];
            //var sig = ema_slow - ema_fast;
            //var ew_fast = 2 / (Fast_ma + 1);
            //var ew_slow = 2 / (Slow_ma + 1);
            //var ew_signal = 2 / (Signal + 1);
            //var macd = new List<(double macd_, double sig)>();//double[rates.Count][2];

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
                    throw new Exception($"Список значений {Name} больше значений исходного ряда.");
                if (dc > 0)
                {
                    for (int i = Cr - dc; i < Cr; i++)
                    {
                        Subtotals.UpdatePrice(Rates[i]);
                        var (val, subtotals) = GetPoint(Subtotals);
                        Values.Add(val);
                        Subtotals = subtotals;
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

        public (MACDValue macd, SubtotalsMACD subMACD) GetPoint(SubtotalsMACD sub_MACD)
        {
            var s = new SubtotalsMACD(sub_MACD);
            var p = s.Price;
            s.EMA_fast = (p - s.EMA_fast) * s.A_fast + s.EMA_fast;
            s.EMA_slow = (p - s.EMA_slow) * s.A_slow + s.EMA_slow;
            var m = new MACDValue();
            m.FastMACD = s.EMA_fast - s.EMA_slow;
            m.Signal = (m.FastMACD - s.EMA_sig) * s.A_sig + s.EMA_sig;
            m.Histogram = m.FastMACD - m.Signal;
            s.EMA_sig = m.Signal;

            //var p = Rates[i];
            //ema_fast = (p - ema_fast) * ew_fast + ema_fast;
            //ema_slow = (p - ema_slow) * ew_slow + ema_slow;
            //var macd_ = ema_fast - ema_slow;
            //sig = (macd_ - sig) * ew_signal + sig;
            //macd.Add((macd_, sig));
            return (m, s);
        }
    }
}
