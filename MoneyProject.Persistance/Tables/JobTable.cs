using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyProject.Persistance.Tables
{
    public class JobTable : BaseTable
    {
        [StringLength(255)]
        public string Name { set; get; }
        [StringLength(500)]
        public string Description { set; get; }
        public bool Active { set; get; } = false;
        public DateTime JoinedDate { set; get; }
        [StringLength(255)]
        public string CompanyName { set; get; }
        [StringLength(700)]
        // Don't be lazy to copy and paste the company Location.
        public string? Location { set; get; } = null;
        public long salary { set; get; }
        public DateTime? ResignedDate { set; get; } = null;
        public Guid? UserId { set; get; } = null;
        public int WorkingHours { set; get; }
        [StringLength(50)]
        public string StartTime { set; get; }
        [StringLength(50)]
        public string EndTime { set; get; }
        //public string Position { set; get; }
    }
}
