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
    public class DetailsModel : PageModel
    {
        //Holds the databas context.
        private readonly Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext _context;

        public DetailsModel(Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext context)
        {
            _context = context;
        }

        //Holds transaction model.
        public Transaction Transaction { get; set; }

        //Gets transaction details using a lambda query.
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transaction =  _context.Transaction
                .Include(t => t.Buyer)
                .Include(t => t.House).Include(t=>t.House.Seller).FirstOrDefault(m => m.TransactionId == id);

            if (Transaction == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
