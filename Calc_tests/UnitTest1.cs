using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorNS;

namespace Calc_tests
{
    [TestClass]
    public class CalcTests
    {
        static StringCalculator calc;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            calc = new StringCalculator();
        }

        [TestMethod]
        [DataRow("1+1",2)]
        [DataRow("1.1+1.1", 2.2)]
        [DataRow("1+0", 1)]
        [DataRow("2-1", 1)]
        [DataRow("2.1-1", 1.1)]
        [DataRow("2-0", 2)]
        [DataRow("3*3", 9)]
        [DataRow("3*0", 0)]
        [DataRow("4/2", 2)]
        [DataRow("4.4/2", 2.2)]
        [DataRow("0/2", 0)]
        [DataRow("1+2*8/4-6/3*7+5-9", -13)]
        public void SimpleOp(string input, double expRes)
        {
            double res = calc.Calc(calc.StringFormat(input));
            Assert.AreEqual(res, expRes);
        }
        [TestMethod]
        [DataRow("-2", -2)]
        [DataRow("-1.1", -1.1)]
        [DataRow("-0", 0)]
        [DataRow("2+-1", 1)]
        [DataRow("-2+1", -1)]
        [DataRow("3*-3", -9)]
        [DataRow("-3/-3", 1)]
        public void UnaryMinus(string input, double expRes)
        {
            double res = calc.Calc(calc.StringFormat(input));
            Assert.AreEqual(res, expRes);
        }
        [TestMethod]
        [DataRow("2*(1+2)", 6)]
        [DataRow("2*(6/(1+1))", 6)]
        [DataRow("-(1+1)*2", -4)]
        [DataRow("2-(-(2))", 4)]
        public void Bracket(string input, double expRes)
        {
            double res = calc.Calc(calc.StringFormat(input));
            Assert.AreEqual(res, expRes);
        }
        [TestMethod]
        [DataRow("")]
        [DataRow("*2")]
        [DataRow("2*")]
        [DataRow("(1+1")]
        [DataRow("1+1)")]
        [DataRow("1++1)")]
        [DataRow("1--1)")]
        [DataRow("1/0")]
        [DataRow("1/f")]
        [ExpectedException(typeof(CalcException))]
        public void ExeptionTest(string input)
        {
            double res = calc.Calc(calc.StringFormat(input));
        }
    }
}
