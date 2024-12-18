﻿using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override bool Exist(Point p) => true;

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = base.Next(p, d);
        return new Point((nextPoint.X + SizeX) % SizeX, (nextPoint.Y + SizeY) % SizeY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextDiagonalPoint = base.NextDiagonal(p, d);
        return new Point((nextDiagonalPoint.X + SizeX) % SizeX, (nextDiagonalPoint.Y + SizeY) % SizeY);
    }
}
