using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualCashCard.Services;

namespace VirtualCashCard.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Can_Add_Credit_To_Account()
        {
            //Arrange
            var bankAccount = BankAccount.Instance;

            //Act
            bankAccount.AddTransaction(500,"C");
            decimal accountBalance = bankAccount.GetCurrentBalance();

            //Assert
            Assert.AreEqual(500, accountBalance);
        }

        [TestMethod]
        public void Can_Add_Debit_Account_After_A_Credit()
        {
            //Arrange
            var bankAccount = BankAccount.Instance;
            bankAccount.ResetAccount();

            //Act
            bankAccount.AddTransaction(500, "C");
            bankAccount.AddTransaction(500, "C");
            bankAccount.AddTransaction(250, "D");
            decimal accountBalance = bankAccount.GetCurrentBalance();

            //Assert
            Assert.AreEqual(750, accountBalance);
        }

       
    }
}
