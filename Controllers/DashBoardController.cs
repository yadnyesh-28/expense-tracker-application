using ExpenseTrackerLearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Syncfusion.EJ2.Linq;
using System.Globalization;
using System.Transactions;

namespace ExpenseTrackerLearning.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashBoardController(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<ActionResult> Index()
        {
            //last 7days
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Models.Transaction> SelectedTransactions = await _context.Transactions
                .Include(x => x.Category)
                .Where(y => y.Date >= StartDate && y.Date <= EndDate)
                .ToListAsync();

            //total Income
            int TotalIncome = SelectedTransactions
                .Where(i => i.Category.Type == "Income")
                .Sum(j => j.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("C0");
            //total Income
            int TotalExpense = SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .Sum(j => j.Amount);
            ViewBag.TotalExpense = TotalExpense.ToString("C0");

            //Balance amount
            int Balance = TotalIncome - TotalExpense;
            CultureInfo culture=CultureInfo.CreateSpecificCulture("en-IN");  //make it in indian rupee
            culture.NumberFormat.CurrencyNegativePattern = 1;
            ViewBag.Balance = String.Format(culture, "{0:C0}",Balance); 
            //c means currency format 0 means no deciaml places

            //Doughnut Chart - Expense by Category
            ViewBag.DoughnutChartData = SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .GroupBy(j => j.Category.CategoryId)
                .Select(k => new
                {
                    CategoryTitleWithIcon=k.First().Category.Icon+ " "+k.First().Category.Title,amount=k.Sum(j => j.Amount),
                    FormattedAmount=k.Sum(j=> j.Amount).ToString("C0"),
                })
                .OrderByDescending(l=>l.amount)
                .ToList();

            //spline chart -Income vs Expense
            //Income
            List<SplineChartData> IncomeSummary=SelectedTransactions
                .Where(i=>i.Category.Type == "Income")
                .GroupBy(j=>j.Date)
                .Select(k=> new SplineChartData()
                {
                    day=k.First().Date.ToString("dd-MMM"),
                    income=k.Sum(l=>l.Amount)
                }).ToList();

            //Expense
            List<SplineChartData> ExpenseSummary = SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .GroupBy(j => j.Date)
                .Select(k => new SplineChartData()
                {
                    day = k.First().Date.ToString("dd-MMM"),
                    expense = k.Sum(l => l.Amount)
                }).ToList();

            //Combine Income & Expense it will show current 7 days
            string[] Last7Days=Enumerable.Range(0, 7)
                .Select(i=>StartDate.AddDays(i).ToString("dd-MMM"))
                .ToArray();

            ViewBag.SplineChartData = from day in Last7Days
                                      join income in IncomeSummary on day equals income.day into dayIncomeJoined
                                      from income in dayIncomeJoined.DefaultIfEmpty()
                                      join expense in ExpenseSummary on day equals expense.day into expenseJoined
                                      from expense in expenseJoined.DefaultIfEmpty()
                                      select new
                                      {
                                          day = day,
                                          income = income == null ? 0 : income.income,
                                          expense = expense == null ? 0 : expense.expense,

                                      };

            //Recent Transactions
            ViewBag.RecentTransactions = await _context.Transactions
                .Include(i => i.Category)
                .OrderByDescending(j => j.Date)
                .Take(5)
                .ToListAsync();


            return View();
        }
    }

    public class SplineChartData
    {
        public string day;
        public int income;
        public int expense;
    }
}
