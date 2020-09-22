using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAnalysis
{
    /// <summary>
    /// Класс для хранения промежуточных итогов расчета ConnosRSI
    /// </summary>
    class SubtotalsCRSI : Subtotals
    {
        /// <summary>
        /// Хранение промежуточных итогов при вычислении компонента RSI(Close, {n = 3})
        /// </summary>
        public SubtotalsRSI RsiClose;
        /// <summary>
        /// Хранение промежуточных итогов при вычислении компонента RSI(Streak, {n = 2}):
        ///     предыдущее значение streak 
        /// </summary>
        public double Streak;
        /// <summary>
        /// Хранение промежуточных итогов при вычислении компонента RSI(Streak, {n = 2}):
        ///     промежуточные итоги RSI(Streak) 
        /// </summary>
        public SubtotalsRSI RsiStreak;
        /// <summary>
        ///Хранение промежуточных итогов DailyReturn при вычислении компонента Rate of Change({n = 100}): 
        ///Кольцевой буфер для хранения значений длиной PercentRankPeriod 
        /// </summary>
        public List<double> DailyReturn;//   !!!!!!!!!!!!! public после отладки убрать
        //Позиция для добавления нового элемента
        int PosDailyReturn;
        public int ROC_Period;

        public SubtotalsCRSI(int rsiClosePeriod, int rsiStreakPeriod, int ROC_period)
        {
            Price = 0;
            PreviousPrice = 0;
            RsiClose = new SubtotalsRSI(rsiClosePeriod);
            Streak = 0;
            RsiStreak = new SubtotalsRSI(rsiStreakPeriod);
            //Инициализация кольцевого буфера
            DailyReturn = new List<double>(ROC_period);
            for (int i = 0; i < ROC_period; i++) DailyReturn.Add(0);
            PosDailyReturn = 0;
            ROC_Period = ROC_period;
        }
        public SubtotalsCRSI(SubtotalsCRSI subCRSI)
        {

            Price = subCRSI.Price;
            PreviousPrice = subCRSI.PreviousPrice;
            RsiClose = subCRSI.RsiClose;
            Streak = subCRSI.Streak;
            RsiStreak = subCRSI.RsiStreak;
            DailyReturn = subCRSI.DailyReturn;
            PosDailyReturn = subCRSI.PosDailyReturn;
            ROC_Period = subCRSI.ROC_Period;
        }
        public void PutDailyReturnValue(double val)
        {
            DailyReturn[PosDailyReturn++] = val;
            if (!(PosDailyReturn < ROC_Period))
                PosDailyReturn = 0;
        }
        public int GetROC(double currDailyReturn)
        {
            var di = currDailyReturn;
            var roc = DailyReturn.Where(x => x < di).Count();
            return roc;
        }
    }

    class ConnorsRSI : Indicator
    {
        SubtotalsCRSI Subtotals;
        int RSI_ClosePeriod;
        int RSI_StreakPeriod;

        //Для отладки
        List<double> rsiPriceVal = new List<double>();
        List<double> rsiStreakVal = new List<double>();
        List<double> rocVal = new List<double>();


        public ConnorsRSI(List<double> rates, int RSI_Close = 3, int RSI_Streak = 2, int ROC_period = 100, string name = "ConnorsRSI")
                : base ("ConnorsRSI", name)
        {
            try
            {
                //Проверка входных параметров
                if (rates == null) 
                    throw new Exception("Нет входных данных");
                if (rates.Count < ROC_period + 2)
                    throw new Exception("Количество исходных значений должно быть на два больше, чем период процентного рейтинга");
                Rates = rates;
                RSI_ClosePeriod = RSI_Close;
                RSI_StreakPeriod = RSI_Streak;
                Values = new List<double>(Rates.Count); //м.б. надо будет сделать больше раза в два для будущих значений
                Subtotals = new SubtotalsCRSI(RSI_Close, RSI_Streak, ROC_period);
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
            var count = Rates.Count;
            var ROC_Period = Subtotals.ROC_Period;
            //Начало расчета
            //настраиваем первые {ROC_Period + 1} значений, т.е 0..ROC_Period
            var rsiClose = new RSI(Rates.GetRange(0, ROC_Period + 1), RSI_ClosePeriod);
            Subtotals.RsiClose = rsiClose.Subtotals;
            var streak = new List<double>(count) { 0 };
            Subtotals.Streak = streak[0];
            Values.Add(0);
            //rocVal.Add(0);  ///  !!!!!!!!!!!!!   Для отладки
            for (int i = 1; i < ROC_Period + 1; i++)
            {
                Subtotals.Price = Rates[i];
                Subtotals.PreviousPrice = Rates[i - 1];
                //Настройка Streak
                var diffPrices = Subtotals.Price - Subtotals.PreviousPrice;
                Subtotals.Streak = getStreak(diffPrices, Subtotals.Streak);
                streak.Add(Subtotals.Streak);
                Subtotals.PutDailyReturnValue(diffPrices / Subtotals.PreviousPrice);
                Values.Add(0);
                //rocVal.Add(0);  ///  !!!!!!!!!!!!!   Для отладки
            }
            var rsiStreak = new RSI(streak, RSI_StreakPeriod);
            Subtotals.RsiStreak = rsiStreak.Subtotals;

            //отладка
            //rsiPriceVal = new List<double>(rsiClose.Values);
            //rsiStreakVal = new List<double>(rsiStreak.Values);

            Subtotals.UpdatePreviousPrice();
            AddPoints();

            //для отладки
            //var str3 = ListToString(rsiPriceVal);
            //var str2 = ListToString(rsiStreakVal);
            //var roc = ListToString(rocVal);

            return res;
        }

        double getStreak(double difference, double subStreak)
        {
            //AK3: =ЕСЛИ(И(AK2>=0;$B3>$B2);AK2+1;
            //           ЕСЛИ(И(AK2>=0;$B3<$B2);-1;
            //                ЕСЛИ(И(AK2<=0;$B3<$B2);AK2-1;
            //                     ЕСЛИ(И(AK2<=0;$B3>$B2);1;0))))

            var d = difference;
            var s = subStreak;
            var si = s;
            if (s >= 0 && d > 0) si += 1;
            else
                if (s >= 0 && d < 0) si = -1;
            else
                if (s <= 0 && d < 0) si -= 1;
            else
                if (s <= 0 && d > 0) si = 1;
            else
                si = 0;
            return si;
        }

        public bool CreateIndicator1()
        {
            Error = "Ok";
            bool res = true;
            var count = Rates.Count;
            var ROC_Period = Subtotals.ROC_Period;
            //начало расчета
            var rsi3 = new RSI(Rates, RSI_ClosePeriod);
            //var str3 = ListToString(rsi3.Values); //для отладки

            var streak = new List<double>(count) { 0 };
            var dailyReturn = new List<double>(count) { 0 };
            var relative = new List<double>(count) { 0 };
            for (int i = 1; i < count; i++)
            {
                //AK3: =ЕСЛИ(И(AK2>=0;$B3>$B2);AK2+1;
                //           ЕСЛИ(И(AK2>=0;$B3<$B2);-1;
                //                ЕСЛИ(И(AK2<=0;$B3<$B2);AK2-1;
                //                     ЕСЛИ(И(AK2<=0;$B3>$B2);1;0))))
                var s = streak[i - 1];
                var si = s;
                var b1 = Rates[i - 1];
                var b2 = Rates[i];
                if (s >= 0 && b2 > b1) si += 1;
                else
                    if (s >= 0 && b2 < b1) si = -1;
                else
                    if (s <= 0 && b2 < b1) si -= 1;
                else
                    if (s <= 0 && b2 > b1) si = 1;
                else
                    si = 0;
                streak.Add(si);
                dailyReturn.Add((b2 - b1) / b1);
                if (i < ROC_Period + 1)  //если i>=ROC_Period+1, т.е считать его начинаем с PR+1
                    relative.Add(0);
                else
                {
                    var di = dailyReturn[i];
                    var ri = dailyReturn.GetRange(i - ROC_Period, ROC_Period).Where(x => x < di).Count();
                    relative.Add(ri);
                }
            }
            //var strs = ListToString(streak);
            var rsi2 = new RSI(streak, RSI_StreakPeriod);
            //var str2 = ListToString(rsi2.Values);
            //var strd = ListToString(dailyReturn);
            //var str_rel = ListToString(relative);

            var crsi = new List<double>(count);
            for (int i = 0; i < ROC_Period + 1; i++)
                crsi.Add(0);
            for (int i = ROC_Period + 1; i < count; i++)
                crsi.Add((rsi3.Values[i] + rsi2.Values[i] + relative[i]) / 3);
            //var str_crsi = ListToString(crsi);
            Values = crsi;

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
                    throw new Exception("Список значений ConnorsRSI больше значений исходного ряда.");
                if (dc > 0)
                {
                    for (int i = Cr - dc; i < Cr; i++)
                    {
                        Subtotals.UpdatePrice(Rates[i]);
                        //var d = Subtotals.GetDifferencePrices(); // Оптимизировать, убрать!!!!
                        double сrsi;
                        (сrsi, Subtotals) = GetPoint(Subtotals);
                        Values.Add(сrsi);
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

        (double crsi, SubtotalsCRSI subCRSI) GetPoint(SubtotalsCRSI sub_CRSI)
        {
            var subCrsi = new SubtotalsCRSI(sub_CRSI);
            var priceDifference = subCrsi.GetDifferencePrices();
            double rsiClosePoint;
            (rsiClosePoint, subCrsi.RsiClose) = RSI.GetPoint(priceDifference, subCrsi.RsiClose);
            var curr_streak = getStreak(priceDifference, subCrsi.Streak);
            var streakDifference = curr_streak - subCrsi.Streak;
            subCrsi.Streak = curr_streak;
            double rsiStreakPoint;
            (rsiStreakPoint, subCrsi.RsiStreak) = RSI.GetPoint(streakDifference, subCrsi.RsiStreak);
            var DailyReturn = priceDifference / Subtotals.PreviousPrice;
            var roc = Subtotals.GetROC(DailyReturn);
            var crsi = (rsiClosePoint + rsiStreakPoint + roc) / 3;
            subCrsi.PutDailyReturnValue(DailyReturn);
            subCrsi.UpdatePreviousPrice();

            //для отладки
            rsiPriceVal.Add(rsiClosePoint);
            rsiStreakVal.Add(rsiStreakPoint);
            rocVal.Add(roc);

            return (crsi, subCrsi);
        }
    }
}
