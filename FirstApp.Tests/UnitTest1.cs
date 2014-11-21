using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FirstApp.Domain.Models;
using FirstApp.Data.Contexts;

namespace FirstApp.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var accounts = new AccountContext().Accounts.ToList();
            
            Assert.IsTrue(accounts.Count > 0);
        }
    }
}
