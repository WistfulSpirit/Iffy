using System.Drawing;
using System.Collections.Generic;
using Sbt.Test.Refactoring.Units;
using Sbt.Test.Refactoring.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sbt.Test.Refactoring.Tests
{
    [TestClass]
    public class TractorTest
    {
        [TestMethod]
        public void MoveTest()
        {
            Map map = new Map(5, 5);
            Tractor tractor = new Tractor(map, new Point(4, 4), Orientation.North);
            tractor.Move();
            Assert.AreEqual(new Point(4,5), tractor.Position);
            tractor.Turn(TurnDirection.CounterClockwise);
            tractor.Move();
            Assert.AreEqual(new Point(3, 5), tractor.Position);
        }
        [TestMethod]
        public void TurnTest()
        {
            Map map = new Map(5, 5);
            Tractor tractor = new Tractor(map, new Point(4, 4), Orientation.West);
            Wind wind = new Wind(map, Orientation.West);

            tractor.Turn();
            Assert.AreEqual(Orientation.North, tractor.Orientation);
            tractor.Turn(TurnDirection.CounterClockwise);
            Assert.AreEqual(Orientation.West, tractor.Orientation);

            wind.Turn();
            Assert.AreEqual(Orientation.North, wind.Orientation);
            wind.Turn(TurnDirection.CounterClockwise);
            Assert.AreEqual(Orientation.West, wind.Orientation);

        }
        [TestMethod]
        public void TurnAndMoveTest()
        {
            Map map = new Map(5, 5);
            Tractor tractor = new Tractor(map, new Point(3, 3), Orientation.North);

            tractor.Move();
            Assert.AreEqual(Orientation.North, tractor.Orientation);
            Assert.AreEqual(new Point(3, 4), tractor.Position);
            tractor.Turn();
            Assert.AreEqual(Orientation.East, tractor.Orientation);

            tractor.Move();
            Assert.AreEqual(new Point(4, 4), tractor.Position);
            
            tractor.Move();
            Assert.AreEqual(new Point(5, 4), tractor.Position);
            try{
                tractor.Move();
                Assert.Fail("Tractor was expected to fall off the plateau");
            }
            catch (TractorInDitchException ex){ }
        }  
        [TestMethod]
        public void SelectionTurn()
        {
            Map map = new Map(5, 5);
            Tractor tractor = new Tractor(map, new Point(3, 3), Orientation.North);
            Wind wind = new Wind(map, Orientation.North);
            Stone stone = new Stone(map, new Point(4, 4));
            List<IUnit> units = new List<IUnit>() { tractor, wind, stone };

            foreach (IUnit unit in units)
            {
                (unit as ITurnable)?.Turn(TurnDirection.CounterClockwise);
            }
            Assert.AreEqual(Orientation.West, tractor.Orientation);
            Assert.AreEqual(Orientation.West, wind.Orientation);

            foreach (IUnit unit in units) {
                (unit as ITurnable)?.Turn();
            }
            Assert.AreEqual(Orientation.North, tractor.Orientation);
            Assert.AreEqual(Orientation.North, wind.Orientation);
        }
        [TestMethod]
        public void TestAddUnit()
        {
            Map map = new Map(5, 5);
            Tractor tractor = new Tractor(map, new Point(3, 3), Orientation.North);
            Wind wind = new Wind(map, Orientation.North);
            Stone stone = new Stone(map, new Point(4, 4));
            Stone stone2 = new Stone(map, new Point(3, 3));
            List<IUnit> units = new List<IUnit>() { tractor, wind, stone };
            map.Add(tractor);
            map.Add(wind);
            map.Add(stone);
            try {
                map.Add(stone2);
                Assert.Fail("Unit additon was expected to fall");
            }
            catch (PlaceIsNotEmptyException ex) { }
        }
    }
}
