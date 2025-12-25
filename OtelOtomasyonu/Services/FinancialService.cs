using System;
using System.Collections.Generic;
using System.Linq;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;
using System.Data.Entity;

namespace OtelOtomasyonu.Services
{
    public class FinancialService
    {
        private HotelContext _context;

        public FinancialService()
        {
            _context = new HotelContext();
        }

        // --- Income (From Reservations) ---
        public decimal GetTotalIncome(DateTime start, DateTime end)
        {
            // Rezervasyonlardan gelir hesapla (Confirmed ve Completed rezervasyonlar)
            // Rezervasyonun başlangıç tarihi aralıkta ise, tam fiyatını gelir olarak say
            var reservations = _context.Reservations
                .Where(r => (r.Status == ReservationStatus.Confirmed || 
                            r.Status == ReservationStatus.Completed) &&
                           r.StartDate >= start && 
                           r.StartDate < end) // Başlangıç tarihi aralıkta
                .ToList();
            
            // Toplam gelir = tüm rezervasyonların TotalPrice'ı
            decimal totalIncome = reservations.Sum(r => r.TotalPrice);
            
            return Math.Round(totalIncome, 2);
        }

        // --- Expenses (Recorded Expenses + Pro-rated Salaries) ---
        public decimal GetTotalExpenses(DateTime start, DateTime end)
        {
            // 1. Recorded Expenses
            decimal recordedExpenses = 0;
            var expQuery = _context.Expenses
                .Where(e => e.Date >= start && e.Date <= end);
            
            if (expQuery.Any())
                recordedExpenses = expQuery.Sum(e => e.Amount);

            // 2. Pro-rated Staff Salaries
            // Logic: Total Monthly Salary / 30 * Days in Range
            decimal totalMonthlySalary = 0;
            if (_context.Users.Any())
            {
                // Ensure we only count Staff or Admins (exclude Customers if they are in Users table)
                totalMonthlySalary = _context.Users
                    .Where(u => u.Role != UserRole.Customer)
                    .Sum(u => (decimal?)u.Salary) ?? 0;
            }

            TimeSpan span = end - start;
            // Add 1 day because start-end is inclusive conceptually for "Today" (00:00 to 23:59 usually) header handles it, 
            // but if passed dates are pure dates:
            double distinctDays = Math.Max(1, span.TotalDays); 

            // Daily Salary Cost
            decimal dailySalaryCost = totalMonthlySalary / 30m;
            decimal durationSalaryCost = dailySalaryCost * (decimal)distinctDays;
            
            // Rounding to avoid crazy decimals
            durationSalaryCost = Math.Round(durationSalaryCost, 2);

            // Personel maaşları gider olarak ekle
            return recordedExpenses + durationSalaryCost;
        }

        public Dictionary<string, decimal> GetExpenseBreakdown(DateTime start, DateTime end)
        {
            var breakdown = new Dictionary<string, decimal>();

            // 1. Grouped Recorded Expenses
            var expenses = _context.Expenses
                .Where(e => e.Date >= start && e.Date <= end)
                .GroupBy(e => e.Category)
                .Select(g => new { Category = g.Key, Total = g.Sum(x => x.Amount) })
                .ToList();

            foreach (var item in expenses)
            {
                breakdown.Add(item.Category.ToString(), item.Total);
            }

            // 2. Salary (Add as "Personel Maaş")
            decimal totalMonthlySalary = _context.Users
                 .Where(u => u.Role != UserRole.Customer)
                 .Sum(u => (decimal?)u.Salary) ?? 0;
            
            double days = Math.Max(1, (end - start).TotalDays);
            decimal salaryCost = Math.Round((totalMonthlySalary / 30m) * (decimal)days, 2);

            if (breakdown.ContainsKey("Staff"))
            {
                breakdown["Staff"] += salaryCost;
            }
            else
            {
                breakdown.Add("Personel Maaş", salaryCost);
            }

            return breakdown;
        }

        // --- Helpers for Dashboard ---
        public FinancialStats GetDashboardStats()
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);
            
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek + 1); // Monday
            DateTime endOfWeek = startOfWeek.AddDays(7);
            
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1);

            return new FinancialStats
            {
                DailyIncome = GetTotalIncome(today, tomorrow),
                WeeklyIncome = GetTotalIncome(startOfWeek, endOfWeek),
                MonthlyIncome = GetTotalIncome(startOfMonth, endOfMonth),
                
                DailyExpense = GetTotalExpenses(today, tomorrow),
                WeeklyExpense = GetTotalExpenses(startOfWeek, endOfWeek),
                MonthlyExpense = GetTotalExpenses(startOfMonth, endOfMonth)
            };
        }
        public List<DailyFinancialStat> GetDailyTrends(int days)
        {
            var result = new List<DailyFinancialStat>();
            DateTime startDate = DateTime.Today.AddDays(-(days - 1));

            for (int i = 0; i < days; i++)
            {
                DateTime currentDay = startDate.AddDays(i);
                DateTime nextDay = currentDay.AddDays(1);

                result.Add(new DailyFinancialStat
                {
                    Date = currentDay,
                    Income = GetTotalIncome(currentDay, nextDay),
                    Expense = GetTotalExpenses(currentDay, nextDay)
                });
            }
            return result;
        }
    }

    public class FinancialStats
    {
        public decimal DailyIncome { get; set; }
        public decimal WeeklyIncome { get; set; }
        public decimal MonthlyIncome { get; set; }

        public decimal DailyExpense { get; set; }
        public decimal WeeklyExpense { get; set; }
        public decimal MonthlyExpense { get; set; }
    }

    public class DailyFinancialStat
    {
        public DateTime Date { get; set; }
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
    }
}
