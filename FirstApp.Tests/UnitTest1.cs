using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FirstApp.Domain.Models;
using FirstApp.Data.Contexts;
using FirstApp.Data.Repos;

namespace FirstApp.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Context()
        {
            var accounts = new AccountContext().Accounts.ToList();
            
            Assert.IsTrue(accounts.Count > 0);
        }

        [TestMethod]
        public void Repo()
        {
            var accounts = new AccountRepository(new AccountContext()).GetAll().ToList();

            Assert.IsTrue(accounts.Count > 0);
        }
    }
}
