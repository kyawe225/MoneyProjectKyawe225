using Microsoft.AspNetCore.Mvc;
using MoneyProject.Api.Model;
using MoneyProject.Persistance.Context;
using MoneyProject.Persistance.Tables;

namespace MoneyProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/")]
    public class JobController : ControllerBase
    {
        private MContext _context { set; get; }
        public JobController(MContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<JobListViewModel> jobs = _context.jobs.Where(p=> p.IsDeleted==false).OrderByDescending(p => p.UpdateAt).Select(q=>new JobListViewModel
            {
                Name=q.Name,
                CompanyName=q.CompanyName,
                Active=q.Active,
                EndTime=q.EndTime,
                JoinedDate=q.JoinedDate,
                StartTime=q.StartTime,
                WorkingHours = q.WorkingHours,
            }).ToList(); 
            return Ok(new { status="OK",data=jobs });
        }
        [HttpPost]
        public IActionResult Create(JobViewModel model)
        {
            if (ModelState.IsValid)
            {
                JobTable job = new JobTable
                {
                    CompanyName=model.CompanyName,
                    EndTime=model.EndTime,
                    StartTime=model.StartTime,
                    Active=model.Active,
                    Description=model.Description,
                    JoinedDate=model.JoinedDate,
                    salary=model.Salary,
                    ResignedDate=null,
                    Location=model.Location,
                    Name=model.Name,
                    WorkingHours=model.WorkingHours,
                    UserId=Guid.NewGuid()
                };
                _context.jobs.Add(job);
                _context.SaveChanges();
                return Ok(new { status="OK" , message="Successfully Added" });
            }
            return Ok( new {  status="NG" , message="Job Create Failed"});
        }
    }
}
