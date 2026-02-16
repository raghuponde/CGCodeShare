
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
       
        [Test]
       public void DivideWithException()
        {
            Assert.Throws<DivideByZeroException>(() => cal.Divide(12, 0));
        }

        [Test]
         [Ignore("will test it later ")]
        public void Divide()
        {
            int actual = cal.Divide(12, 4);
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("", 0)] // Empty password
        [TestCase("12345", 1)] // Digits only
        [TestCase("password123", 2)] // Lowercase + digits
        [TestCase("Password123", 3)] // Uppercase + lowercase + digits
        [TestCase("Password@123", 4)] // Special char + uppercase + lowercase + digits
        public void GetPasswordStrength_ShouldReturnExpectedStrength(string password, int expectedStrength)
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
