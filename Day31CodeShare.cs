
Test-Driven Development (TDD) is a software development practice where tests are written before the actual code is implemented. The process follows three basic steps:

Write a test: Write a test for the functionality you want to implement.
Run the test: Run the test, which should fail because the functionality hasn't been implemented yet.
Write the code: Write the minimum amount of code to make the test pass.
Refactor: Improve the code structure without changing its behavior, and ensure the tests still pass.
Here’s a simple TDD demo using C# with NUnit as the testing framework.

Scenario: Implement a BankAccount class that supports deposits, withdrawals, and balance checking.

Step 1: Write the Failing Test First (RED)
Create the failing test before writing the BankAccount class. The test will fail because the class and methods don’t exist yet.


  namespace TDDDemo
{
    [TestFixture]
    public class BankAccountTests 
    {
        [Test]
        public void Deposit_shouldIncrease()
        {
            var account = new BankAccount();
            account.Deposit(100);
            Assert.AreEqual(100, account.Balance);
        }

        [Test]
        public void Withdraw_shouldDecrease()
        {
            var account = new BankAccount();
            account.Deposit(100);
            account.Withdraw(50);
            Assert.AreEqual(50, account.Balance);
        }
        [Test]
        public void Withdraw_shoulldThrowException_insufficent()
        {
            var account = new BankAccount();
           
            account.Withdraw(50);
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(100));
        }

    }
}



using Moq;
namespace MockTesting
{

    public class checkEmployee
    {
        public virtual Boolean checkemp()
        {
            throw new NotImplementedException();
        }

        public virtual int substract(int a, int b)
        {
            throw new NotImplementedException();
        }
    }

    public class processEmployee
    {
        public bool insertEmployee(checkEmployee emp)
        {
            emp.checkemp();
           
            return true;
        }
        public int insertEmployee2(checkEmployee emp)
        {
            
             emp.substract(4, 3);
            return 1;
        }
    }

    [TestClass]
    public class MockTesting
    {
        [TestMethod]
        public void testmethod1()
        {
            Mock<checkEmployee> chk = new Mock<checkEmployee>();
            chk.Setup(x => x.checkemp()).Returns(true);
            chk.Setup(x => x.substract(5,3)).Returns(1);
            processEmployee objprocess = new processEmployee();
            Assert.AreEqual(objprocess.insertEmployee(chk.Object), true);
            Assert.AreEqual(objprocess.insertEmployee2(chk.Object), 1);

        }
    }
}
suppose i want to write a test case without Mock class 

    [TestMethod]
  public void testmethod2()
  {
      checkEmployee chk1 = new checkEmployee();
      int k = chk1.substract(4, 1);
      int expected = 3;
      Assert.AreEqual(k, expected);

  }

this test case will fail for all value becasue he has not written the code or logic only i am testing somethig for which logic is not implemented 
so in those cases forefully i will make the method pass using mockeing 

Final code 
-----------

using Moq;
namespace MockTesting
{

    public class checkEmployee
    {
        public virtual Boolean checkemp()
        {
            throw new NotImplementedException();
        }

        public virtual int substract(int a, int b)
        {
            throw new NotImplementedException();
        }
    }

    public class processEmployee
    {
        public bool insertEmployee(checkEmployee emp)
        {
            emp.checkemp();
           
            return true;
        }
        public int insertEmployee2(checkEmployee emp)
        {
            
            emp.substract(4, 3);
            return 3;
        }
    }

    [TestClass]
    public class MockTesting
    {
        [TestMethod]
        public void testmethod1()
        {
            Mock<checkEmployee> chk = new Mock<checkEmployee>();
            chk.Setup(x => x.checkemp()).Returns(false);
            chk.Setup(x => x.substract(5,3)).Returns(8);
            processEmployee objprocess = new processEmployee();
            Assert.AreEqual(objprocess.insertEmployee(chk.Object), true);
            Assert.AreEqual(objprocess.insertEmployee2(chk.Object), 3);
            // without mock i want to make my test case pass

           


        }

        [TestMethod]
        public void testmethod2()
        {
            checkEmployee chk1 = new checkEmployee();
            int k = chk1.substract(4, 1);
            int expected = 3;
            Assert.AreEqual(k, expected);

        }
    }
}

Here are examples of creating complex test methods that handle multiple scenarios (positive, negative, and edge cases) for NUnit, MSTest, and XUnit using C#. We will test a Calculator class that performs basic arithmetic. Each test method will cover different scenarios: positive, negative, and edge cases.

1. NUnit Example: Complex Test Cases

Step 1: Create the Calculator Class

public class Calculator
{
    public int Divide(int numerator, int denominator)
    {
        if (denominator == 0) 
        {
            throw new DivideByZeroException("Denominator cannot be zero.");
        }
        return numerator / denominator;
    }
}


Step 2: Create Test Class with Different Scenarios

using NUnit.Framework;
using System;

namespace NUnitTestDemo
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        // Positive test case: normal division
        [Test]
        public void Divide_ShouldReturnCorrectResult_WhenInputsAreValid()
        {
            var result = _calculator.Divide(10, 2);
            Assert.AreEqual(5, result);
        }

        // Negative test case: dividing by zero
        [Test]
        public void Divide_ShouldThrowDivideByZeroException_WhenDenominatorIsZero()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }

        // Edge case: division resulting in a fraction (rounding down)
        [Test]
        public void Divide_ShouldRoundDown_WhenResultIsFraction()
        {
            var result = _calculator.Divide(5, 2);
            Assert.AreEqual(2, result); // Integer division, rounds down
        }

        // Edge case: very large numbers
        [Test]
        public void Divide_ShouldHandleLargeNumbers()
        {
            var result = _calculator.Divide(int.MaxValue, 1);
            Assert.AreEqual(int.MaxValue, result);
        }
    }
}

In the above code if i want to make divide by zero to fail i will put 10,2 which we know now i want the  public void Divide_ShouldRoundDown_WhenResultIsFraction() this test case to fail so logic will change like this 
namespace TestProject4
{
    public class Calculator
    {
        public int Divide(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero.");
            }
            return (int)((double)numerator / denominator + 0.5);  // Rounds to nearest (5/2→3 FAILS!)
        }
    }


    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        // Positive test case: normal division
        [Test]
        public void Divide_ShouldReturnCorrectResult_WhenInputsAreValid()
        {
            var result = _calculator.Divide(10, 2);
            Assert.AreEqual(5, result);
        }

        // Negative test case: dividing by zero
        [Test]
        public void Divide_ShouldThrowDivideByZeroException_WhenDenominatorIsZero()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10,0));
        }

        // Edge case: division resulting in a fraction (rounding down)
        [Test]
        public void Divide_ShouldRoundDown_WhenResultIsFraction()
        {
            var result = _calculator.Divide(5, 2);
            Assert.AreEqual(2, result); // Integer division, rounds down
        }

        // Edge case: very large numbers
        [Test]
        public void Divide_ShouldHandleLargeNumbers()
        {
            var result = _calculator.Divide(int.MaxValue, 1);
            Assert.AreEqual(int.MaxValue, result);
        }
    }
}

