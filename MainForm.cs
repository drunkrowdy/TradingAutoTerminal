using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static TradingAutoTerminal.Helpers.Helper;
using TradingAutoTerminal.ExmoObjects;
using TechnicalAnalysis;
using System.Windows.Forms.DataVisualization.Charting;

namespace TradingAutoTerminal
{
    public partial class MainForm : Form
    {
        List<Candle> Candles;
        List<double> Prices;
        
        MACD Macd;
        List<double> macd;
        List<double> signal;

        ConnorsRSI Crsi;

        // Для графиков
        readonly string areaNameCandles = "arCandles";
        string areaNameIndicators = "arIndicators";
        string seriesCandlesName = "serCandles";
        string seriesMacdName = "serMACD";
        string seriesMacdSigName = "serMACD_sig";
        string seriesCRSI = "serCRSI";
        int pCount = 50; //количество отбражаемых точек
        int Xmin = 100;
        int Xmax = 200;
        double Ymin = 0;
        double Ymax = 12000;
        

        public MainForm()
        {
            InitializeComponent();
            Candles = new List<Candle>();
            Prices = new List<double>();
            macd = new List<double>();
            signal = new List<double>();

        }

        private void btnLoadCandles_Click(object sender, EventArgs e)
        {
            string file = "Data/ExampleData-BTC_USD.txt";
            string text = ReadStringFromFile(file);
            if (text != null)
            {
                text = text.Replace("\r", "");
                List<string> str = text.Split('\n').ToList();
                str.RemoveAt(0);
                str.RemoveAt(0);
                foreach (string v in str)
                {
                    var s = v.Split('/');
                    var c = new Candle();
                    try
                    {
                        c.Open = Convert.ToDouble(s[1]);
                        c.High = Convert.ToDouble(s[2]);
                        c.Low = Convert.ToDouble(s[3]);
                        c.Close = Convert.ToDouble(s[4]);
                        Candles.Add(c);
                        Prices.Add(c.Close);
                    }
                    catch { }
                    lblLoad.Text = "Ok";
                }
                CalculateGraphBoundaries();
            }
            else
            {
                lblLoad.Text = "!Ошибка загрузки";
            }
        }

        private void btnMACD_Click(object sender, EventArgs e)
        {
            Macd = new MACD(Prices,12,26,9,"MACD(12,26,9)");
            foreach (var val in Macd.Values)
            {
                macd.Add(val.FastMACD);
                signal.Add(val.Signal);
            }
            lblMacd.Text = Macd.Name;
        }

        private void btnCRSI_Click(object sender, EventArgs e)
        {
            Crsi = new ConnorsRSI(Prices, 3, 2, 100, "CRSI(3,2,100)");
            lblCrsi.Text = Crsi.Name;
        }

        private void btnAddCandles_Click(object sender, EventArgs e)
        {
            if (txtbxCount.Text != "")
            {
                pCount = int.Parse(comboBox1.Text);
                CalculateGraphBoundaries();
            }
            //сначала все очищаем
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            //создаем область
            var areaCandles = chart1.ChartAreas.Add(areaNameCandles);
            //вертикальная черта при щелчке мышью на графике
            areaCandles.CursorX.IsUserEnabled = true;
            areaCandles.CursorY.AxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            areaCandles.AxisX.Minimum = Xmin;
            areaCandles.AxisX.Maximum = Xmax;
            areaCandles.AxisY2.Minimum = Ymin;
            //areaCandles.AxisY.Crossing = Ymin;

            
            //chart1.ChartAreas.FindByName(areaCandlesName).CursorX.IsUserEnabled = true;
            //chart1.ChartAreas.FindByName(areaCandlesName).CursorY.AxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            //создаем для области колекцию значений для свечей
            var seriesCandles = chart1.Series.Add(seriesCandlesName);
            seriesCandles.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            seriesCandles.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            seriesCandles.Color = System.Drawing.Color.Green;
            seriesCandles.BackSecondaryColor = System.Drawing.Color.Red;
            //тень
            seriesCandles.ShadowOffset = 2;
            //подгружаем данные в коллекцию
            for (int i = Xmin; i < Xmax + 1; i++) 
            {
                var candle = Candles[i];
                seriesCandles.Points.AddXY(i, candle.Low, candle.High, candle.Open, candle.Close);
            }


            //помещаем коллекцию на область
            seriesCandles.ChartArea = areaNameCandles;



        }

        private void сhart1_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Вычисляет границы графика свечей с учетом текущего количества точек
        /// начиная от последнего известного значения (т.е. справа)
        /// </summary>
        void CalculateGraphBoundaries()
        {
            var pcnt = Candles.Count;
            if (pCount > pcnt) pCount = pcnt;
            Xmax = pcnt-1;
            Xmin = Xmax - pCount + 1;
            Ymin = Candles.GetRange(Xmin, pCount).Select(x => x.Low).ToArray().Min() - 50;
            Ymax = Candles.GetRange(Xmin, pCount).Select(x => x.High).ToArray().Max() + 50;
        }

        private void btnAddMACD_Click(object sender, EventArgs e)
        {
            var areaIndicators = chart1.ChartAreas.FindByName(areaNameIndicators);
            if (areaIndicators == null)
                areaIndicators = chart1.ChartAreas.Add(areaNameIndicators);
            //вертикальная черта при щелчке мышью на графике
            areaIndicators.CursorX.IsUserEnabled = true;
            areaIndicators.AxisX.Minimum = Xmin;
            areaIndicators.AxisX.Maximum = Xmax;

            var seriesMacd = chart1.Series.FindByName(seriesMacdName);
            if (seriesMacd == null)
                seriesMacd = chart1.Series.Add(seriesMacdName);
            seriesMacd.ChartType = SeriesChartType.Spline;
            seriesMacd.YAxisType = AxisType.Secondary;
            seriesMacd.Color = Color.Blue;
            seriesMacd.Points.DataBindY(macd);
            seriesMacd.ChartArea = areaNameIndicators;

            var seriesMacdSig = chart1.Series.FindByName(seriesMacdSigName);
            if (seriesMacdSig == null)
                seriesMacdSig = chart1.Series.Add(seriesMacdSigName);
            seriesMacdSig.ChartType = SeriesChartType.Spline;
            seriesMacdSig.YAxisType = AxisType.Secondary;
            seriesMacdSig.Color = Color.DarkGreen;
            seriesMacdSig.Points.DataBindY(signal);
            seriesMacdSig.ChartArea = areaNameIndicators;
        }

        private void btnAddCRSI_Click(object sender, EventArgs e)
        {
            var seriesCrsi = chart1.Series.FindByName(seriesCRSI);
            if (seriesCrsi == null)
                seriesCrsi = chart1.Series.Add(seriesCRSI);
            seriesCrsi.ChartType = SeriesChartType.Line;
            seriesCrsi.YAxisType = AxisType.Primary;
            seriesCrsi.Color = Color.Orange;
            seriesCrsi.Points.DataBindY(Crsi.Values);
            seriesCrsi.ChartArea = areaNameIndicators;
        }
    }
}
