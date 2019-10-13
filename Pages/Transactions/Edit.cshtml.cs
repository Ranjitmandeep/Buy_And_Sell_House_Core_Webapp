using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buy_And_Sell_House_Core_Webapp.Business;
using Buy_And_Sell_House_Core_Webapp.Models;

namespace Buy_And_Sell_House_Core_Webapp.Pages.Shared.Transactions
{
    public class EditModel : PageModel
    {
        //Holds the databas context.
        private readonly Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext _context;

        public EditModel(Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext context)
        {
            _context = context;
        }

        //Holds transaction model
        [BindProperty]
        public Transaction Transaction { get; set; }

        //Get transaction details using lamda query.
        public  IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transaction =  _context.Transaction
                .Include(t => t.Buyer)
                .Include(t => t.House).FirstOrDefault(m => m.TransactionId == id);

            if (Transaction == null)
            {
                return NotFound();
            }
           ViewData["BuyerId"] = new SelectList(_context.Buyer, "Id", "BuyerName", Transaction.Buyer.BuyerName );
           ViewData["HouseId"] = new SelectList(_context.House, "Id", "HouseAddress", Transaction.House.HouseAddress);
            return Page();
        }

        //Updates transaction.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Transaction).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(Transaction.TransactionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Check the existance using a lamda query.
        private bool TransactionExists(string id)
        {
            return _context.Transaction.Any(e => e.TransactionId == id);
        }
    }
}
