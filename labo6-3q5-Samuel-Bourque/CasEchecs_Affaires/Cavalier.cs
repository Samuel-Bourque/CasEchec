using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasEchecs_Affaires
{
    public class Cavalier : Piece
    {
        public Cavalier(CouleurPiece c, Position p) : base(c, p) { }

        public override void deplacer(Position p)
        {
            if (_position.Y != p.Y)
            {
                double pente = (double)(_position.X - p.X) / (_position.Y - p.Y);
                if ((Math.Abs(pente) == 0.5 || Math.Abs(pente) == 2.0) &&
                    _position.calculerDistance(p) <= 2.25)
                    _position = p;
            }
        }
    }
}
