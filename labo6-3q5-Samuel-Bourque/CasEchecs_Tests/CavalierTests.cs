using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasEchecs_Affaires;
using System.Collections.Generic;

namespace CasEchecs_Tests
{
    [TestClass]
    public class CavalierTests
    {
        [TestMethod]
        public void Cavalier_DeplacementsTests()
        {
            Cavalier cavalierNoir = new Cavalier(CouleurPiece.Noir, new Position(2, 3));
            List<Position> mauvais = new List<Position>();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    mauvais.Add(new Position(i, j));
            List<Position> bons = new List<Position>();
            bons.Add(new Position(0, 2));
            bons.Add(new Position(0, 4));
            bons.Add(new Position(1, 1));
            bons.Add(new Position(1, 5));
            bons.Add(new Position(3, 1));
            bons.Add(new Position(3, 5));
            bons.Add(new Position(4, 2));
            bons.Add(new Position(4, 4));
            mauvais.Remove(new Position(2, 3));
            foreach(Position p in bons)
                mauvais.Remove(p);
            foreach(Position p in mauvais)
            {
                cavalierNoir.deplacer(p);
                Assert.IsFalse(p.Equals(cavalierNoir.Position));
            }
            foreach (Position p in bons)
            {
                cavalierNoir.deplacer(p);
                Assert.AreEqual(cavalierNoir.Position, p);
                cavalierNoir = new Cavalier(CouleurPiece.Noir, new Position(2, 3));
            }

        }
    }
}
