using System.ComponentModel.DataAnnotations;


namespace MoneyProject.Persistance.Tables
{
    public class ExpenseTypeTable:BaseTable
    {
        [StringLength(255)]
        public string Name { set; get; }
        [StringLength(500)]
        public string Description { set; get; }
    }
}
