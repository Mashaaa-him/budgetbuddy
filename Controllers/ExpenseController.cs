using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Data;

namespace Test.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }
    

    [HttpGet]
    public IActionResult Index()
        {
            var expenses = _context.Expenses.OrderBy(e => e.Id).ToList();
            return View(expenses);
        }

    [HttpGet]
    public IActionResult Create()
        {
            return View();
        }
    [HttpPost]
    public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expense);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(expense);
        }
}}