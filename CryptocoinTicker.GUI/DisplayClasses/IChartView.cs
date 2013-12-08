﻿using System;
using System.Collections.Generic;

namespace CryptocoinTicker.GUI.DisplayClasses
{
    public interface IChartView
    {
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