using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasEchecs_Affaires
{
    public class Position
    {
        private double _x, _y, _z;
        public Position(double x=0.0, double y=0.0, double z=0.0)
        {
            _x = x;
            _y = y;
            _z = z;
        }
        public Double X { get { return _x; } set { _x = value;  } }
        public Double Y { get { return _y; } set { _y = value;  } }
        public Double Z { get { return _z; } set { _z = value; } }

        public double calculerDistance(Position p)
        {
            return Math.Sqrt(Math.Pow(_x - p.X, 2) + Math.Pow(_y - p.Y, 2) + Math.Pow(_z - p.Z, 2));
        }
        public override int GetHashCode()
        {
            return (int)(_x * 100000 + _y * 1000 + _z);
        }
        public override bool Equals(object obj)
        {
            Position autre = obj as Position;
            if (autre == null)
                return false;
            return _x == autre.X && _y == autre.Y && _z == autre.Z;
        }
    }
}
