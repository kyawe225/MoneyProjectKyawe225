using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyProject.Persistance.Tables
{
    public class ExpenseTable:BaseTable
    {
        [StringLength(255)]
        public string ExpenseName { set; get; }
        public Guid ExpenseTypeId { set; get; }
        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseTypeTable? ExpenseType { set; get; }
        public DateTime ExpenseDate { set; get; } = DateTime.UtcNow;
        public long Ammount { set; get; } = 0;
        
    }
}
