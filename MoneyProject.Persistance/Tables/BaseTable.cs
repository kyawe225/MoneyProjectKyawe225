
namespace MoneyProject.Persistance.Tables
{
    public class BaseTable
    {
        public Guid Id { set; get; } = Guid.NewGuid();
        public DateTime CreatedAt { set; get; } = DateTime.UtcNow;
        public DateTime UpdateAt { set; get; } = DateTime.UtcNow;
        public bool IsDeleted { set; get; } = false;
        public bool IsHidden { set; get; } = true;
    }
}
