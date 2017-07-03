using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Add_EmptyString_ReturnZero()
        {
            var result = Calculator.Add("");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_One_ReturnOne()
        {
            var result = Calculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Add_OneAndTwo_ReturnThree()
        {
            var result = Calculator.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_UnknownAmountOfNumbers_ReturnSum1()
        {
            var result = Calculator.Add("1,2,3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_UnknownAmountOfNumbers_ReturnSum2()
        {
            var result = Calculator.Add("1,6,1,1");

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Add_NewlineSeperatorAndAComma_ReturnSum()
        {
            var result = Calculator.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Add_OneCommaNewLine_ShouldBeInvalid()
        {
            var result = Calculator.Add("1,\n");
        }

        [TestMethod]
        public void Add_TwoNumbersWithCustomDelimiter_ShouldReturnSum3()
        {
            var result = Calculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_WithNegativeValues_ShouldBeInvalid()
        {
            var result = Calculator.Add("1,-3,5");
        }

        [TestMethod]
        public void Add_WithNegativeValues_ShouldReturnAppropriateMessage()
        {
            try
            {
                var result = Calculator.Add("1,-3,5");
            }catch(ArgumentOutOfRangeException exception)
            {
                string ExpectedMessage = "negatives not allowed -3";
                Assert.AreEqual(ExpectedMessage, exception.Message);
                return;
            }

            Assert.Fail("Add_WithNegativeValues_ShouldReturnAppropriateMessage - did not throw an arguement out of range exception");
            
        }

        [TestMethod]
        public void Add_WithMultipleNegativeValues_ShouldReturnAppropriateMessage()
        {
            try
            {
                var result = Calculator.Add("1,-3,-5");
            }
            catch (ArgumentOutOfRangeException exception)
            {
                string ExpectedMessage = "negatives not allowed -3,-5";
                Assert.AreEqual(ExpectedMessage, exception.Message);
                return;
            }

            Assert.Fail("Add_WithNegativeValues_ShouldReturnAppropriateMessage - did not throw an arguement out of range exception");

        }

        [TestMethod]
        public void Add_NumberBiggerThanOneThousandShouldBeIgnored_ShouldSumToTwo()
        {
            var result = Calculator.Add("2,1001");
            Assert.AreEqual(2, result);
        }
    }
}
