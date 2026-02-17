
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
