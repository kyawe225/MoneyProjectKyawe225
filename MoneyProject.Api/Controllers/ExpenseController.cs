using Microsoft.AspNetCore.Mvc;
using MoneyProject.Api.Model;
using MoneyProject.Persistance.Context;
using MoneyProject.Persistance.Tables;
using Microsoft.EntityFrameworkCore;

namespace MoneyProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/")]
    public class ExpenseController : ControllerBase
    {
        private ILogger<ExpenseController> _logger;
        private MContext _context { set; get; }
        public ExpenseController(MContext context,ILogger<ExpenseController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Index()
        {
            IEnumerable<ExpenseListViewModel> expenseList = _context.expenses.Include(p=> p.ExpenseType).Where(p => p.IsDeleted == false).Select(p=> new ExpenseListViewModel
            {
                Name=p.ExpenseName,
                Ammount=p.Ammount,
                ExpenseTypeName=p.ExpenseType.Name
            }).ToList();
            return Ok(new { status="OK" , data=expenseList });
        }
        [HttpPost]
        public IActionResult Create(ExpenseCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                ExpenseTable expense = new ExpenseTable()
                {
                    ExpenseName = model.Name,
                    ExpenseTypeId = Guid.Parse(model.ExpenseTypeId),
                    ExpenseDate = DateTime.UtcNow,
                    Ammount = model.Ammount
                };
                _context.expenses.Add(expense);
                _context.SaveChanges();
                _logger.LogInformation("Created Successfully.");
                return Ok(new { status = "OK" , message="Create a new expense !!!" });
            }
            _logger.LogTrace("Created Failed");
            return Ok(new { status = "NG" , message="Fail Successfully !!!" });
        }
    }
}
