using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasEchecs_Affaires;
using System.Collections.Generic;

namespace CasEchecs_Tests
{
    [TestClass]
    public class TourTests
    {
        [TestMethod]
        public void TourNoire_DeplacementsTests()
        {
            Tour tourNoire = new Tour(CouleurPiece.Noir, new Position(2, 3));
            List<Position> mauvais = new List<Position>();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    mauvais.Add(new Position(i, j));
            List<Position> bons = new List<Position>();
            bons.Add(new Position(0, 3));
            bons.Add(new Position(1, 3));
            bons.Add(new Position(3, 3));
            bons.Add(new Position(4, 3));
            bons.Add(new Position(5, 3));
            bons.Add(new Position(6, 3));
            bons.Add(new Position(7, 3));
            bons.Add(new Position(2, 0));
            bons.Add(new Position(2, 1));
            bons.Add(new Position(2, 2));
            bons.Add(new Position(2, 4));
            bons.Add(new Position(2, 5));
            bons.Add(new Position(2, 6));
            bons.Add(new Position(2, 7));
            mauvais.Remove(new Position(2, 3));
            foreach(Position p in bons)
                mauvais.Remove(p);
            foreach(Position p in mauvais)
            {
                tourNoire.deplacer(p);
                Assert.IsFalse(p.Equals(tourNoire.Position));
            }
            foreach(Position p in bons)
            {
                tourNoire.deplacer(p);
                Assert.AreEqual(p, tourNoire.Position);
                tourNoire = new Tour(CouleurPiece.Noir, new Position(2, 3));
            }
        }
    }
}
