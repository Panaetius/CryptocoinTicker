using System;
using System.Collections.Generic;

using CryptocoinTicker.Contract;

namespace CryptocoinTicker.GUI.DisplayClasses
{
    public interface IChartView
    {
        string ChartName { get; }

        bool IsLogarithmic { get; set; }

        int PeriodSize { get; set; }

        int PeriodsToDisplay { get; set; }

        void AddCandle(Candle candle);

        void AddLine(string name, IEnumerable<Point> line);

        void RemoveLine(string name);

        void Redraw();

        void Clear();
    }
}