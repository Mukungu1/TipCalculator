using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace TipCalculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public double MealCost { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPostCalculateTips()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            double[] tipPercentages = { 0.15, 0.20, 0.25 };

            var tipAmounts = new List<double>();
            foreach (var tipPercentage in tipPercentages)
            {
                var tipAmount = MealCost * tipPercentage;
                tipAmounts.Add(tipAmount);
            }

            return new JsonResult(new { TipPercentages = tipPercentages, TipAmounts = tipAmounts });
        }
    }
}
