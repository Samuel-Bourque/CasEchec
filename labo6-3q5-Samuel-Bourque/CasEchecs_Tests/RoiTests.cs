using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasEchecs_Affaires;
using System.Collections.Generic;

namespace CasEchecs_Tests
{
    [TestClass]
    public class RoiTests
    {
        [TestMethod]
        public void RoiNoir_DeplacementsTests()
        {
            Roi roiNoir = new Roi(CouleurPiece.Noir, new Position(3, 6));
            List<Position> mauvais = new List<Position>();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    mauvais.Add(new Position(i, j));
            List<Position> bons = new List<Position>();
            bons.Add(new Position(2, 5));
            bons.Add(new Position(2, 6));
            bons.Add(new Position(2, 7));
            bons.Add(new Position(3, 5));
            bons.Add(new Position(3, 7));
            bons.Add(new Position(4, 5));
            bons.Add(new Position(4, 6));
            bons.Add(new Position(4, 7));
            mauvais.Remove(new Position(3, 6));
            foreach(Position p in bons)
                mauvais.Remove(p);
            foreach(Position p in mauvais)
            {
                roiNoir.deplacer(p);
                Assert.IsFalse(p.Equals(roiNoir.Position));
            }
            foreach(Position p in bons)
            {
                roiNoir.deplacer(p);
                Assert.AreEqual(p, roiNoir.Position);
                roiNoir = new Roi(CouleurPiece.Noir, new Position(3, 6));
            }
        }
    }
}
