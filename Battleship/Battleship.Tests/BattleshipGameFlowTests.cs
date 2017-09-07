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

        [TestCase ("a3", true)]
        [TestCase("a,3", true)]
        [TestCase("", false)]
        [TestCase("x4", false)]
        [TestCase("13", false)]
        [TestCase("xx", false)]
        [TestCase("j10", true)]
        [TestCase("111", false)]
        [TestCase("1111", false)]
        [TestCase("aaa", false)]
        [TestCase("a a", false)]
        [TestCase("a,a", false)]
        [TestCase("a11", false)]


        public void ValidateInput(string input, bool expected)
        {
            string Input = input;
            Coordinate c1;

            bool toReturn = ConsoleInput.TryParseCoordinate(input, out c1);

            Assert.AreEqual(expected, toReturn);
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
