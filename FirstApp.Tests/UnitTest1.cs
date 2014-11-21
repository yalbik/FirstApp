using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FirstApp.Domain.Models;
using FirstApp.Data.Contexts;
using FirstApp.Data.Repos;

using Dapper;

namespace FirstApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanWriteToDB()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["scooter"].ConnectionString);
            Account account = RandomAccount();

            string insertQuery = String.Format(
                "INSERT Account (AccountName, AccountNotes) VALUES ('{0}', '{1}')", account.AccountName, account.AccountNotes);
            string selectQuery = String.Format(
                "SELECT * FROM Account WHERE AccountName = '{0}' AND AccountNotes = '{1}'", account.AccountName, account.AccountNotes);
            string deleteQuery = String.Format(
                "DELETE Account WHERE AccountName = '{0}' AND AccountNotes = '{1}'", account.AccountName, account.AccountNotes);

            con.Query(insertQuery);
            Assert.IsTrue(con.Query<Account>(selectQuery).Count() == 1);
            con.Query(deleteQuery);
            Assert.IsTrue(con.Query<Account>(selectQuery).Count() == 0);
        }
        
        [TestMethod]
        public void ContextAndBasicRepo()
        {
            var context = new AccountContext();
            var repo = new AccountRepository(context);
            
            Assert.IsTrue(context.Accounts.ToList().Count() > 0);
            Assert.IsTrue(repo.GetAll().ToList().Count() > 0);
        }

        [TestMethod]
        public void RepoCrud()
        {
            var repo = new AccountRepository(new AccountContext());

            Account account = RandomAccount();
            Account updateAccount = RandomAccount();

            // add account
            repo.Insert(account);
            repo.Save();

            // check for account
            Assert.IsTrue(repo.GetAll().Where(x =>
                x.AccountName == account.AccountName &&
                x.AccountNotes == account.AccountNotes).Count() == 1);

            // update account
            account.AccountName = updateAccount.AccountName;
            account.AccountNotes = updateAccount.AccountNotes;
            repo.Update(account);
            repo.Save();

            // check for account
            Assert.IsTrue(repo.GetAll().Where(x =>
                x.AccountName == account.AccountName &&
                x.AccountNotes == account.AccountNotes).Count() == 1);

            // delete account
            repo.Delete(account);
            repo.Save();
            
            // check for account
            Assert.IsTrue(repo.GetAll().Where(x =>
                x.AccountName == account.AccountName &&
                x.AccountNotes == account.AccountNotes).Count() == 0);
        }

        private Account RandomAccount()
        {
            return new Account()
            {
                AccountName = Guid.NewGuid().ToString().Substring(0, 10),
                AccountNotes = Guid.NewGuid().ToString().Substring(0, 10)
            };
        }
    }
}
