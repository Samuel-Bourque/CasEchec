using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasEchecs_Affaires
{
    public abstract class Piece
    {
        protected CouleurPiece _couleur;
        protected Position _position;

        public Piece(CouleurPiece c, Position p)
        {
            _couleur = c;
            _position = p;
        }

        public CouleurPiece Couleur { get { return _couleur; } }
        public Position Position { get { return _position; } }

        public abstract void deplacer(Position p);
    }
}
