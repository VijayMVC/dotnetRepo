using BattleShip.BLL.Requests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.UI;

namespace Battleship.Tests
{
    [TestFixture]
    class BattleshipGameFlowTests
    {
        [Test]
        public void ConvertInputToCoordinate()
        {
            string input = "a3";
            Coordinate c1;

            bool toReturn = ConsoleInput.TryParseCoordinate(input, out c1);

            Assert.AreEqual(true, toReturn);
        }

        [TestCase("a3", 1,3)]
        [TestCase("a,3", 1,3)]
        [TestCase("j10", 10, 10)]
        [TestCase("j,10", 10, 10)]
        [TestCase("c5", 3, 5)]
        [TestCase("c,5", 3, 5)]

        public void ValidateGoodInput(string Input,int x, int y)
        {
            Coordinate c1 = new Coordinate(x,y);
            Coordinate c2;

            bool toReturn = ConsoleInput.TryParseCoordinate(Input, out c2);

            Assert.AreEqual(c1, c2);
        }

        [TestCase("")]
        [TestCase("00")]
        [TestCase("a,11")]
        [TestCase("a11")]
        [TestCase("aj")]
        [TestCase("0,10")]
        [TestCase("2,12")]
        [TestCase("1,10")]

        public void RejectBadInput(string Input)
        {
            Coordinate c2;

            bool toReturn = ConsoleInput.TryParseCoordinate(Input, out c2);
            //A false return indicate input coordinates are invalid

            Assert.AreEqual(toReturn, false);
        }

        [TestCase("u", true)]
        [TestCase("d", true)]
        [TestCase("l", true)]
        [TestCase("r", true)]
        [TestCase("U", true)]
        [TestCase("D", true)]
        [TestCase("L", true)]
        [TestCase("R", true)]
        [TestCase("", false)]
        [TestCase("dd", false)]
        [TestCase("aaa", false)]
        [TestCase("?", false)]

        public void ValidateDirection(string input, bool expected)
        {
            string Input = input;
            bool toReturn = ConsoleInput.isValidDirection(input, out Input);

            Assert.AreEqual(expected, toReturn);
        }
    
    }
}
