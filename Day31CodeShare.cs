
Test-Driven Development (TDD) is a software development practice where tests are written before the actual code is implemented. The process follows three basic steps:

Write a test: Write a test for the functionality you want to implement.
Run the test: Run the test, which should fail because the functionality hasn't been implemented yet.
Write the code: Write the minimum amount of code to make the test pass.
Refactor: Improve the code structure without changing its behavior, and ensure the tests still pass.
Here’s a simple TDD demo using C# with NUnit as the testing framework.

Scenario: Implement a BankAccount class that supports deposits, withdrawals, and balance checking.

Step 1: Write the Failing Test First (RED)
Create the failing test before writing the BankAccount class. The test will fail because the class and methods don’t exist yet.
