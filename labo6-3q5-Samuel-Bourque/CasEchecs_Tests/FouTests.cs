using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasEchecs_Affaires;
using System.Collections.Generic;

namespace CasEchecs_Tests
{
    [TestClass]
    public class FouTests
    {
        [TestMethod]
        public void Fou_DeplacementsTests()
        {
            Fou fouNoir = new Fou(CouleurPiece.Noir, new Position(3, 6));
            List<Position> mauvais = new List<Position>();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    mauvais.Add(new Position(i, j));
            List<Position> bons = new List<Position>();
            bons.Add(new Position(0, 3));
            bons.Add(new Position(1, 4));
            bons.Add(new Position(2, 5));
            bons.Add(new Position(2, 7));
            bons.Add(new Position(4, 7));
            bons.Add(new Position(4, 5));
            bons.Add(new Position(5, 4));
            bons.Add(new Position(6, 3));
            bons.Add(new Position(7, 2));
            mauvais.Remove(new Position(3, 6));
            foreach(Position p in bons)
                mauvais.Remove(p);
            foreach(Position p in mauvais)
            {
                fouNoir.deplacer(p);
                Assert.IsFalse(p.Equals(fouNoir.Position));
            }
            foreach(Position p in bons)
            {
                fouNoir.deplacer(p);
                Assert.AreEqual(p, fouNoir.Position);
                fouNoir = new Fou(CouleurPiece.Noir, new Position(3, 6));
            }
        }
    }
}
