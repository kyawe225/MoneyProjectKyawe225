using Microsoft.EntityFrameworkCore;
using MoneyProject.Persistance.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MoneyProject.Persistance.Context
{
    public class MContext:DbContext
    {
        public MContext(DbContextOptions<MContext> options):base(options)
        {
        }
        public DbSet<JobTable> jobs { set; get; }
        public DbSet<ExpenseTypeTable> expenseTypes { set; get; }
        public DbSet<ExpenseTable> expenses { set; get; }
    }
}
