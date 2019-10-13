using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Buy_And_Sell_House_Core_Webapp.Business;
using Buy_And_Sell_House_Core_Webapp.Models;

namespace Buy_And_Sell_House_Core_Webapp.Pages.Shared.Transactions
{
    public class CreateModel : PageModel
    {
        //Holds the databas context.
        private readonly Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext _context;

        public CreateModel(Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext context)
        {
            _context = context;
        }

        //Gets the create form.
        public IActionResult OnGet()
        {
        ViewData["BuyerId"] = new SelectList(_context.Buyer, "Id", "BuyerName");
        ViewData["HouseId"] = new SelectList(_context.House, "Id", "HouseAddress");
            return Page();
        }

        //Holds the transaction model.
        [BindProperty]
        public Transaction Transaction { get; set; }

        //Adds a transaction to database.
        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Transaction.Add(Transaction);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}