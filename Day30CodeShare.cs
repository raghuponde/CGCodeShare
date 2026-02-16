
Introduction to Unit Testing in C#:
Unit testing is the process of testing individual units or components of an application in isolation to ensure that they function as expected. In C#, unit tests are typically written using frameworks like NUnit, MSTest, or XUnit. Here, I'll provide a basic understanding of unit testing using NUnit as an example.

Key Concepts:
Test Framework: NUnit, MSTest, or XUnit provide the infrastructure for writing and running tests.
Assertions: Assertions are used to verify that the expected output matches the actual output of a unit.
Test Suites: A collection of related test cases.
Test Runner: A tool or part of the framework that executes the tests and provides feedback on whether they passed or failed.

open one class library project and write the below code 
 
namespace ArthematicOpsandAnother
{
    public class Calculate 
    {
     
        public int Addition(int num1,int num2)
        {
            return num1 + num2;
        }
        public int substract(int num1,int num2)
        {
            int result;
            if(num1>num2)
            {
                result = num1 - num2;
            }
            else
            {
                result = num2 - num1;
            }
            return result;
        }
        public int Multiplication(int num1, int num2)
        {
            return num1 * num2;
        }

        public int Divide(int num1, int num2)
        {
            int result = 0;
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
            return result;


        }

        public int GetPassWordStrength(string password)
        {
            if(string.IsNullOrEmpty(password))
            {
                return 0;
            }
            int result = 0;
            if(password.Length > 8)
            {
                result = result + 1;
            }
            if(password.Any(char.IsUpper))
            {
                result = result + 1;
            }

            if (password.Any(char.IsLower))
            {
                result = result + 1;
            }
 
            string specialchars = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specarrray = specialchars.ToCharArray();
            foreach (char c in specarrray)
            {
                if (password.Contains(c))
                {
                    result = result + 1;
                }

            }

            if (password.Any(char.IsDigit))
            {
                result = result + 1;
            }

            return result;
        }


    }
}

Now add one test project 
i am adding NUNIt test project to test the abve code whih i had written i need to add dll refercne of above into the test project

using ArthematicOpsandAnother;





namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        Calculate cal = null;
        [SetUp]
        public void Setup()
        {
            cal = new Calculate();
        }

        [Test]

        [TestCase(15,20,35)]
        [TestCase(20, 20,40)]

        public void Addition(int x,int y,int expected)
        {
            //arrange 
            int actual;
         //   int expected;
            //act 
            actual = cal.Addition(x,y);
            //assert
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
       // [TestCase(20, 15)]
        [TestCase(20, 20)]

        public void Substraction(int x, int y)
        {
            //arrange 
            int actual;
            int expected = 0;
            //act 
            actual = cal.substract(x, y);
            //assert
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }

      //  [TestCase(20, 15)]
        [TestCase(20, 20)]

        public void multiply(int x, int y)
        {
            //arrange 
            int actual;
            int expected = 400;
            //act 
            actual = cal.Multiplication(x, y);
            //assert
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }

       // [TestCase(20, 15)]
        [TestCase(20, 20)]

        public void Division(int x, int y)
        {
            //arrange 
            int actual;
            int expected = 0;
            //act 
            actual = cal.Divide(x, y);
            //assert
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
       
        [Test]//negative test cases 
        [TestCase(12,3)]//here it will fail as it passes for negative tasks
        [TestCase(12,0)]// this will pass 
       public void DivideWithException(int a,int b)
        {
            Assert.Throws<DivideByZeroException>(() => cal.Divide(a, b));
        }

        [Test]
         [Ignore("will test it later ")]
        public void Divide()
        {
            int actual = cal.Divide(12, 4);
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }

        //  [TestCase("", 0)] // Empty password
        //  [TestCase("12345", 1)] // Digits only
        //   [TestCase("password123", 2)] // Lowercase + digits
        //  [TestCase("Password123", 3)] // Uppercase + lowercase + digits
          [TestCase("Rajesh@jjj",4)] // Special char + uppercase + lowercase + digits
       // [Test]
        public void GetPasswordStrength_ShouldReturnExpectedStrength(string password,
            int expectedStrength)
        {
            int result = cal.GetPassWordStrength(password);
            Assert.AreEqual(expectedStrength, result);
        }

        [TearDown]
        public void TearDown()
        {
            cal = null;
        }

    }
}
now add xunit 

Xunit usage :
-------------
from terminal you want to install MSUNit framework means type below commands
Install-Package xunit
Install-Package xunit.runner.visualstudio

using Xunit;
using ArthematicOpsAndOther;
using System;

namespace ArthematicOpsAndOtherTests
{
    public class CalculateTests
    {
        private readonly Calculate _calculator;

        public CalculateTests()
        {
            _calculator = new Calculate();
        }

        [Fact]
        public void Addition_ShouldReturnCorrectSum()
        {
            int result = _calculator.Addition(5, 3);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Subtract_ShouldReturnCorrectResult_WhenNum1IsGreater()
        {
            int result = _calculator.Subtract(10, 3);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Subtract_ShouldReturnCorrectResult_WhenNum2IsGreater()
        {
            int result = _calculator.Subtract(3, 10);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Multiplication_ShouldReturnCorrectProduct()
        {
            int result = _calculator.Multiplication(5, 4);
            Assert.Equal(20, result);
        }

        [Fact]
        public void Divide_ShouldReturnCorrectQuotient()
        {
            int result = _calculator.Divide(10, 2);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Divide_ShouldThrowDivideByZeroException_WhenDividingByZero()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }

        [Theory]
        [InlineData("", 0)] // Empty password
        [InlineData("12345", 1)] // Digits only
        [InlineData("password123", 2)] // Lowercase + digits
        [InlineData("Password123", 3)] // Uppercase + lowercase + digits
        [InlineData("Password@123", 4)] // Special char + uppercase + lowercase + digits
        public void GetPasswordStrength_ShouldReturnExpectedStrength(string password, int expectedStrength)
        {
            int result = _calculator.GetPasswordStrength(password);
            Assert.Equal(expectedStrength, result);
        }
    }
}

now add mstest framework 

---------------------------
MSUnit
---------

from terminal you want to install MSUNit framework means type below commands

Install-Package MSTest.TestFramework
Install-Package MSTest.TestAdapter

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArthematicOpsAndOther;
using System;

namespace ArthematicOpsAndOtherTests
{
    [TestClass]
    public class CalculateTests
    {
        private Calculate _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new Calculate();
        }

        [TestMethod]
        public void Addition_ShouldReturnCorrectSum()
        {
            int result = _calculator.Addition(5, 3);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Subtract_ShouldReturnCorrectResult_WhenNum1IsGreater()
        {
            int result = _calculator.Subtract(10, 3);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Subtract_ShouldReturnCorrectResult_WhenNum2IsGreater()
        {
            int result = _calculator.Subtract(3, 10);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Multiplication_ShouldReturnCorrectProduct()
        {
            int result = _calculator.Multiplication(5, 4);
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Divide_ShouldReturnCorrectQuotient()
        {
            int result = _calculator.Divide(10, 2);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ShouldThrowDivideByZeroException_WhenDividingByZero()
        {
            _calculator.Divide(10, 0);
        }
 
        [DataTestMethod]
        [DataRow("", 0)] // Empty password
        [DataRow("12345", 1)] // Digits only
        [DataRow("password123", 2)] // Lowercase + digits
        [DataRow("Password123", 3)] // Uppercase + lowercase + digits
        [DataRow("Password@123", 4)] // Special char + uppercase + lowercase + digits
        public void GetPasswordStrength_ShouldReturnExpectedStrength(string password, int expectedStrength)
        {
            int result = _calculator.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, result);
        }
    }
}


