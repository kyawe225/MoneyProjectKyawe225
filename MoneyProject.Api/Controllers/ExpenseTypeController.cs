using Microsoft.AspNetCore.Mvc;
using MoneyProject.Api.Model;
using MoneyProject.Persistance.Context;
using MoneyProject.Persistance.Tables;

namespace MoneyProject.Api.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class ExpenseTypeController : ControllerBase
    {
        private MContext _context { set; get; }
        public ExpenseTypeController(MContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<ExpenseTypeListViewModel> modelList=_context.expenseTypes.Select(p => new ExpenseTypeListViewModel
            {
                Id=p.Id.ToString(),
                Name=p.Name
            }).ToList();
            return Ok( new { status="OK" , data=modelList});
        }
        [HttpPost]
        public IActionResult Create(ExpenseTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                ExpenseTypeTable expenseType = new ExpenseTypeTable()
                {
                    Name = model.Name,
                    Description = model.Description
                };
                _context.expenseTypes.Add(expenseType);
                _context.SaveChanges();
                return Ok(new { status="OK" , message="Expense Type Created Successfully" });
            }
            return Ok(new { status="NG"  , message="Expense Type Error!!"});
        }
        [HttpPost]
        public IActionResult GetTotalExpenseViewType(string viewtype)
        {
            if (viewtype == "default")
            {
                _context.jobs.ToList();
            }            
            return Ok(new { status = "OK", message = "Something Wrong" });
            
        }
    }
}
