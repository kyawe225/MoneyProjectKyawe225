namespace MoneyProject.Api.Model
{
    public class JobViewModel
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public DateTime JoinedDate { set; get; }
        public long Salary { set; get; }
        public bool Active { set; get; }
        public string CompanyName { set; get; }
        public string? Location { set; get; } = null;
        public string StartTime { set; get; }
        public string EndTime { set; get; }
        public int WorkingHours { set; get; }
    }
    public class JobListViewModel
    {
        public string Name { set; get; }
        public DateTime JoinedDate { set; get; }
        public bool Active { set; get; }
        public string CompanyName { set; get; }
        public string StartTime { set; get; }
        public string EndTime { set; get; }
        public int WorkingHours { set; get; }
    }
}
