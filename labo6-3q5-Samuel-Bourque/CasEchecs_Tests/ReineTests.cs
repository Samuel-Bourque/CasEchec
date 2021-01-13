using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasEchecs_Affaires;
using System.Collections.Generic;
namespace CasEchecs_Tests
{
    [TestClass]
    public class ReineTests
    {
        [TestMethod]
        public void ReineNoire_DeplacementsTests()
        {
            Reine reineNoire = new Reine(CouleurPiece.Noir, new Position(3, 6));
            List<Position> mauvais = new List<Position>();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    mauvais.Add(new Position(i, j));
            List<Position> bons = new List<Position>();
            bons.Add(new Position(0, 3));
            bons.Add(new Position(0, 6));
            bons.Add(new Position(1, 4));
            bons.Add(new Position(1, 6));
            bons.Add(new Position(2, 5));
            bons.Add(new Position(2, 6));
            bons.Add(new Position(2, 7));
            bons.Add(new Position(3, 0));
            bons.Add(new Position(3, 1));
            bons.Add(new Position(3, 2));
            bons.Add(new Position(3, 3));
            bons.Add(new Position(3, 4));
            bons.Add(new Position(3, 5));
            bons.Add(new Position(3, 7));
            bons.Add(new Position(4, 5));
            bons.Add(new Position(4, 6));
            bons.Add(new Position(4, 7));
            bons.Add(new Position(5, 4));
            bons.Add(new Position(5, 6));
            bons.Add(new Position(6, 3));
            bons.Add(new Position(6, 6));
            bons.Add(new Position(7, 2));
            bons.Add(new Position(7, 6));
            mauvais.Remove(new Position(3, 6));
            foreach(Position p in bons)
                mauvais.Remove(p);
            foreach(Position p in mauvais)
            {
                reineNoire.deplacer(p);
                Assert.IsFalse(p.Equals(reineNoire.Position));
            }
            foreach(Position p in bons)
            {
                reineNoire.deplacer(p);
                Assert.AreEqual(p, reineNoire.Position);
                reineNoire = new Reine(CouleurPiece.Noir, new Position(3, 6));
            }

        }
    }
}
