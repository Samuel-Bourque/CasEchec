using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasEchecs_Affaires
{
    public class Fou : Piece
    {
       public Fou(CouleurPiece c, Position p) : base(c,p) { }

        public override void deplacer(Position p)
        {
            if(p.X != _position.X)
            {
                double pente = (_position.Y - p.Y) / (_position.X - p.X);
                if(Math.Abs(pente) == 1.0)
                    _position = p;
            }
        }
    }
}
