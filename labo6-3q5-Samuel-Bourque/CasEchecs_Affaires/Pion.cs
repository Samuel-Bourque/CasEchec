using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasEchecs_Affaires
{
    public class Pion : Piece
    {
        public Pion(CouleurPiece c, Position p) : base(c,p) { }

        public override void deplacer(Position p)
        {
            if(_position.X == p.X &&
               ((_couleur == CouleurPiece.Blanc && p.Y == _position.Y + 1) ||
                (_couleur == CouleurPiece.Noir && p.Y == _position.Y - 1)))
                _position = p;
        }
    }
}
