using NUnit.Framework;
using JamesQMurphy.Math;
using System;

namespace JamesQMurphy.Math.UnitTests
{
    public class UnitParserTests
    {
        [Test]
        public void Empty()
        {
            var up = new UnitParser();
            Assert.AreEqual(String.Empty, up.ToString());
        }

        [Test]
        public void SingleUnitWithExponent1()
        {
            var up = new UnitParser();
            up.Append("B", 1);
            Assert.AreEqual("B", up.ToString());
        }

        [Test]
        public void SingleUnitWithExponent2()
        {
            var up = new UnitParser();
            up.Append("B", 2);
            Assert.AreEqual("B^2", up.ToString());
        }

        [Test]
        public void TwoPositiveExponents()
        {
            var up = new UnitParser();
            up.Append("A", 3);
            up.Append("B", 2);
            Assert.AreEqual("A^3*B^2", up.ToString());
        }
        [Test]
        public void TwoNegativeExponents()
        {
            var up = new UnitParser();
            up.Append("A", -1);
            up.Append("B", -2);
            Assert.AreEqual("A^-1*B^-2", up.ToString());
        }
        [Test]
        public void OnePositiveOneNegativeExponents1()
        {
            var up = new UnitParser();
            up.Append("A", 1);
            up.Append("B", -1);
            Assert.AreEqual("A/B", up.ToString());
        }
        [Test]
        public void OnePositiveOneNegativeExponents2()
        {
            var up = new UnitParser();
            up.Append("A", -1);
            up.Append("B", 1);
            Assert.AreEqual("B/A", up.ToString());
        }
        public void OnePositiveOneNegativeExponents3()
        {
            var up = new UnitParser();
            up.Append("A", -2);
            up.Append("B", 1);
            Assert.AreEqual("B/A^-2", up.ToString());
        }
        [Test]
        public void OnePositiveOneNegativeExponents4()
        {
            var up = new UnitParser();
            up.Append("A", 3);
            up.Append("B", -3);
            Assert.AreEqual("A^3/B^3", up.ToString());
        }

        [Test]
        public void Complex1()
        {
            var up = new UnitParser();
            up.Append("A", 3);
            up.Append("B", -3);
            up.Append("C", 1);
            Assert.AreEqual("A^3*C/B^3", up.ToString());
        }

        [Test]
        public void Complex2()
        {
            var up = new UnitParser();
            up.Append("A", 3);
            up.Append("B", -3);
            up.Append("C", -1);
            Assert.AreEqual("A^3/(B^3*C)", up.ToString());
        }

        [Test]
        public void Complex3()
        {
            var up = new UnitParser();
            up.Append("A", 3);
            up.Append("B", -3);
            up.Append("C", 2);
            up.Append("D", -2);
            Assert.AreEqual("A^3*C^2/(B^3*D^2)", up.ToString());
        }

        [Test]
        public void ParseSingleUnit()
        {
            var up = new UnitParser();
            up.Append("A");
            Assert.AreEqual("A", up.ToString());
        }

        [Test]
        public void ParseTwoPositiveExponents1()
        {
            var up = new UnitParser();
            up.Append("A*B");
            Assert.AreEqual("A*B", up.ToString());
        }

        [Test]
        public void ParseTwoPositiveExponents2()
        {
            var up = new UnitParser();
            up.Append("A");
            up.Append("B");
            Assert.AreEqual("A*B", up.ToString());
        }

        [Test]
        public void ParseTwoPositiveExponents3()
        {
            var up = new UnitParser();
            up.Append("A^2*B");
            Assert.AreEqual("A^2*B", up.ToString());
        }

        [Test]
        public void ParseTwoPositiveExponents4()
        {
            var up = new UnitParser();
            up.Append("A");
            up.Append("B^2");
            Assert.AreEqual("A*B^2", up.ToString());
        }

        [Test]
        public void ParseTwoNegativeExponents1()
        {
            var up = new UnitParser();
            up.Append("A^-2*B^-3");
            Assert.AreEqual("A^-2*B^-3", up.ToString());
        }

        [Test]
        public void ParseTwoNegativeExponents2()
        {
            var up = new UnitParser();
            up.Append("A^-2");
            up.Append("B^-3");
            Assert.AreEqual("A^-2*B^-3", up.ToString());
        }

        [Test]
        public void ParseMix1()
        {
            var up = new UnitParser();
            up.Append("A");
            up.Append("B^-1");
            Assert.AreEqual("A/B", up.ToString());
        }

        [Test]
        public void ParseMix2()
        {
            var up = new UnitParser();
            up.Append("A^-1");
            up.Append("B^1");
            Assert.AreEqual("B/A", up.ToString());
        }

        [Test]
        public void ParseMix3()
        {
            var up = new UnitParser();
            up.Append("A");
            up.Append("B^1");
            up.Append("C^1");
            Assert.AreEqual("A*B*C", up.ToString());
        }

        [Test]
        public void ParseMix4()
        {
            var up = new UnitParser();
            up.Append("A");
            up.Append("B^-1");
            up.Append("C^-1");
            Assert.AreEqual("A/(B*C)", up.ToString());
        }

        [Test]
        public void ParseMix5()
        {
            var up = new UnitParser();
            up.Append("A");
            up.Append("B^-1*C^-1");
            Assert.AreEqual("A/(B*C)", up.ToString());
        }

        [Test]
        public void ParseMix6()
        {
            var up = new UnitParser();
            up.Append("A/B");
            up.Append("C^-1");
            Assert.AreEqual("A/(B*C)", up.ToString());
        }

        [Test]
        public void ParseMix7()
        {
            var up = new UnitParser();
            up.Append("A^2*C");
            up.Append("B^-1");
            Assert.AreEqual("A^2*C/B", up.ToString());
        }

        [Test]
        public void ParseMix8()
        {
            var up = new UnitParser();
            up.Append("A/B");
            up.Append("C^3");
            Assert.AreEqual("A*C^3/B", up.ToString());
        }

        [Test]
        public void Combination1()
        {
            var up = new UnitParser();
            up.Append("A/B");
            up.Append("C", 3);
            Assert.AreEqual("A*C^3/B", up.ToString());

        }

        [Test]
        public void Combination2()
        {
            var up = new UnitParser();
            up.Append("A/B");
            up.Append("C", -3);
            Assert.AreEqual("A/(B*C^3)", up.ToString());
        }

        [Test]
        public void Combination3()
        {
            var up = new UnitParser();
            up.Append("A/B");
            up.Append("C", -3);
            up.Append("D^2");
            Assert.AreEqual("A*D^2/(B*C^3)", up.ToString());
        }

        [Test]
        public void Combination4()
        {
            var up = new UnitParser();
            up.Append("A/B");
            up.AppendFlipped("C/D");
            Assert.AreEqual("A*D/(B*C)", up.ToString());
        }

        [Test]
        public void AddSameSymbol1()
        {
            var up = new UnitParser();
            up.Append("A", 2);
            up.Append("A", 1);
            Assert.AreEqual("A^3", up.ToString());
        }

        [Test]
        public void AddSameSymbol2()
        {
            var up = new UnitParser();
            up.Append("A", 2);
            up.Append("A", -2);
            Assert.AreEqual(String.Empty, up.ToString());
        }
        [Test]
        public void AddSameSymbol3()
        {
            var up = new UnitParser();
            up.Append("A/B");
            up.Append("A*B");
            Assert.AreEqual("A^2", up.ToString());
        }
        [Test]
        public void AddSameSymbol4()
        {
            var up = new UnitParser();
            up.Append("A*B/B");
            up.Append("A*B/A");
            Assert.AreEqual("A*B", up.ToString());
        }
        [Test]
        public void AddSameSymbol5()
        {
            var up = new UnitParser();
            up.Append("A*B/B^2");
            up.Append("A*B/A^3");
            Assert.AreEqual("A^-1", up.ToString());
        }
        [Test]
        public void AddSameSymbol6()
        {
            var up = new UnitParser();
            up.Append("A", -3);
            up.Append("B*A^2");
            Assert.AreEqual("B/A", up.ToString());
        }

        [Test]
        public void AppendFlipped1()
        {
            var up = new UnitParser();
            up.AppendFlipped("A");
            Assert.AreEqual("A^-1", up.ToString());
        }
        [Test]
        public void AppendFlipped2()
        {
            var up = new UnitParser();
            up.AppendFlipped("A/B");
            Assert.AreEqual("B/A", up.ToString());
        }

        [Test]
        public void AppendFlipped3()
        {
            var up = new UnitParser();
            up.AppendFlipped("A*B/C");
            Assert.AreEqual("C/(A*B)", up.ToString());
        }
        [Test]
        public void AppendFlipped4()
        {
            var up = new UnitParser();
            up.AppendFlipped("A*B");
            Assert.AreEqual("A^-1*B^-1", up.ToString());
        }
        [Test]
        public void AppendFlipped5()
        {
            var up = new UnitParser();
            up.AppendFlipped("A/(B^2*C^3)");
            Assert.AreEqual("B^2*C^3/A", up.ToString());
        }

        [Test]
        public void ParenthesesOkay()
        {
            var up = new UnitParser();
            up.Append("(A)");
            up.Append("(((B)))");
            Assert.AreEqual("A*B", up.ToString());
        }

        [Test]
        public void EnforceSymbolOnly()
        {
            var up = new UnitParser();
            Assert.Throws<ArgumentException>(() => up.Append("A*B", 1));
            Assert.Throws<ArgumentException>(() => up.Append("A^1", 1));
            Assert.Throws<ArgumentException>(() => up.Append("A/B", 1));
        }

        [Test]
        public void EnforceFormat()
        {
            var up = new UnitParser();
            Assert.Throws<FormatException>(() => up.Append("(A"));
            Assert.Throws<FormatException>(() => up.Append("A)"));
            Assert.Throws<FormatException>(() => up.Append("(A))"));
        }
    }
}
