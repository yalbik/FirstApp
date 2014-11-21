using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirstApp.Domain.Models;

namespace FirstApp.Data.Contexts
{
    public interface IAccountContext : IDbContext
    {
        IDbSet<Account> Accounts { get; set; }
    }

    public class AccountContext : DbContext, IAccountContext
    {
        public AccountContext() : base(ConfigurationManager.ConnectionStrings["scooter"].ConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Account> Accounts { get; set; }
    }
}
