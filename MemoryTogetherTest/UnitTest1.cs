using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemoryTogetherTest
{
    public class AccountingBook
    {
        internal int Money;
        public string Description { get; set; }
    }

    public class AccountingBookOperator
    {
        public bool Record(int money, string description)
        {
            return true;
        }
    }

    [TestClass]
    public class AccountingBookTest
    {
        [TestMethod]
        public void Record_Is_Success()
        {
            var accountingBook = new AccountingBook() { Money = 10, Description = "this is test" };
            var accountingBookOperator = new AccountingBookOperator();
            var actual = accountingBookOperator.Record(accountingBook.Money, accountingBook.Description);
            Assert.IsTrue(actual);
        }
    }
}