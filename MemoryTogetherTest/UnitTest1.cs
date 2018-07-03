using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MemoryTogetherTest
{
    public class AccountingBook
    {
        internal int Money;
        public string Description { get; set; }
        public string RecordStatus { get; internal set; }

        internal bool Record(double money, string descript)
        {
            throw new NotImplementedException();
        }
    }

    public class AccountingBookOperator
    {
        public bool Record(int money, string accountingBookDescription)
        {
            throw new NotImplementedException();
        }
    }

    [TestClass]
    public class AccountingBookTest
    {
        [TestMethod]
        public void Record_Is_Success()
        {
            var accountingBook = new AccountingBook();
            var accountingBookOperator = new AccountingBookOperator();
            var actual = accountingBookOperator.Record(accountingBook.Money, accountingBook.Description);
            Assert.AreEqual(true, actual);
        }
    }
}