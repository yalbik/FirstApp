using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirstApp.Data.Contexts;
using FirstApp.Domain.Models;

namespace FirstApp.Data.Repos
{
    public interface IAccountRepository : IBaseRepository<Account> { }

    public class AccountRepository : DbContextRepository<Account>, IAccountRepository
    {
        private readonly IAccountContext context;

        public AccountRepository (IAccountContext context) : base(context)
        {
            this.context = context;
        }
    }
}
