﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
    public class BigMap : Map
    {
        private readonly Dictionary<Point, List<IMappable>> _fields;

        public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 1000 || sizeY > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Width or height exceeds 1000.");
            }

            _fields = new Dictionary<Point, List<IMappable>>();
        }

        public override void Add(IMappable mappable, Point position)
        {
            if (!Exist(position))
            {
                return;
            }

            if (!_fields.ContainsKey(position))
            {
                _fields[position] = new List<IMappable>();
            }

            _fields[position].Add(mappable);
        }

        public override void Remove(IMappable mappable, Point position)
        {
            if (!Exist(position)) return;

            if (!_fields.ContainsKey(position)) return;

            List<IMappable> creatures = _fields[position];

            if (creatures.Contains(mappable))
            {
                creatures.Remove(mappable);
            }
            else
            {
                Console.WriteLine("Obiekt nie istnieje w danym punkcie.");
            }
        }

        public override List<IMappable>? At(int x, int y) => At(new Point(x, y));

        public override List<IMappable>? At(Point point)
        {
            return _fields.TryGetValue(point, out var mappables) ? mappables : null;
        }

        public override void Move(IMappable mappable, Point from, Point to)
        {
            if (!Exist(from) || !Exist(to))
            {
                return;
            }

            Remove(mappable, from);
            Add(mappable, to);
        }

        public override Point Next(Point p, Direction d)
        {
            return d switch
            {
                Direction.Up => new Point(p.X, p.Y + 1),
                Direction.Down => new Point(p.X, p.Y - 1),
                Direction.Left => new Point(p.X - 1, p.Y),
                Direction.Right => new Point(p.X + 1, p.Y),
                _ => throw new ArgumentOutOfRangeException(nameof(d), "Invalid diagonal direction.")
            };
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            return d switch
            {
                Direction.Up => new Point(p.X, p.Y + 1),
                Direction.Down => new Point(p.X, p.Y - 1),
                Direction.Left => new Point(p.X - 1, p.Y),
                Direction.Right => new Point(p.X + 1, p.Y),
                _ => throw new ArgumentOutOfRangeException(nameof(d), "Invalid diagonal direction.")
            };
        }
    }
}

