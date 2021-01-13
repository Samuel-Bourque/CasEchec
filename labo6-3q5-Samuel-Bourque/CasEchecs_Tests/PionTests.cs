using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasEchecs_Affaires;
using System.Collections.Generic;

namespace CasEchecs_Tests
{
    [TestClass]
    public class PionTests
    {
        [TestMethod]
        public void Pion_DeplacementsNoirTest()
        {
            Pion pionNoir = new Pion(CouleurPiece.Noir, new Position(3, 6));
            List<Position> mauvais = new List<Position>();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    mauvais.Add(new Position(i, j));
            List<Position> bons = new List<Position>();
            bons.Add(new Position(3, 5));
            mauvais.Remove(new Position(3,6));
            foreach(Position p in bons)
                mauvais.Remove(p);
            foreach (Position p in mauvais)
            { 
                pionNoir.deplacer(p);
                Assert.IsFalse(p.Equals(pionNoir.Position));
            }
            foreach(Position p in bons)
            {
                pionNoir.deplacer(p);
                Assert.IsTrue(p.Equals(pionNoir.Position));
            }
        }
        [TestMethod]
        public void Pion_DeplacementsBlancTest()
        {
            Pion pionBlanc = new Pion(CouleurPiece.Blanc, new Position(6, 1));
            List<Position> mauvais = new List<Position>();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    mauvais.Add(new Position(i, j));
            List<Position> bons = new List<Position>();
            bons.Add(new Position(6, 2));
            mauvais.Remove(new Position(6, 1));
            foreach (Position p in bons)
                mauvais.Remove(p);
            foreach (Position p in mauvais)
            {
                pionBlanc.deplacer(p);
                Assert.IsFalse(p.Equals(pionBlanc.Position));
            }
            foreach (Position p in bons)
            {
                pionBlanc.deplacer(p);
                Assert.IsTrue(p.Equals(pionBlanc.Position));
            }
        }
    }
}
