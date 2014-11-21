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
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ContextAndBasicRepo()
        {
            var context = new AccountContext();
            var repo = new AccountRepository(context);
            
            Assert.IsTrue(context.Accounts.ToList().Count() > 0);
            Assert.IsTrue(repo.GetAll().ToList().Count() > 0);
        }
    }
}
