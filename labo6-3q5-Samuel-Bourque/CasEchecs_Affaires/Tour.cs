using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasEchecs_Affaires
{
    public class Tour : Piece
    {
       public Tour(CouleurPiece c, Position p) : base(c,p) { }

        public override void deplacer(Position p)
        {
            if(_position.X == p.X || _position.Y == p.Y)
                _position = p;
        }
    }
}
