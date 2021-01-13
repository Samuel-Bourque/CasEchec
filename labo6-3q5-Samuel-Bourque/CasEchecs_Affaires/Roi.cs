using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasEchecs_Affaires
{
    public class Roi : Reine
    {
        public Roi(CouleurPiece c, Position p) : base(c, p) { }

        public override void deplacer(Position p)
        {
            if (_position.calculerDistance(p) <= 1.42)
                base.deplacer(p);
        }
    }
}
