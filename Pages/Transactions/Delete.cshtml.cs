using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Buy_And_Sell_House_Core_Webapp.Business;
using Buy_And_Sell_House_Core_Webapp.Models;

namespace Buy_And_Sell_House_Core_Webapp.Pages.Shared.Transactions
{
    public class DeleteModel : PageModel
    {
        //Holds the databas context.
        private readonly Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext _context;

        public DeleteModel(Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext context)
        {
            _context = context;
        }

        //Holds transaction model.
        [BindProperty]
        public Transaction Transaction { get; set; }

        //Gets the tranaction information uses a lamda query.
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
            return Page();
        }

        //Deletes a transaction uses a linq query to check existence.
        public  IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transaction = (from transaction in _context.Transaction where transaction.TransactionId ==id select transaction).FirstOrDefault();

            if (Transaction != null)
            {
                _context.Transaction.Remove(Transaction);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
