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

namespace Buy_And_Sell_House_Core_Webapp.Pages.Shared.Buyers
{
    public class EditModel : PageModel
    {
        //Holds the databas context.
        private readonly Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext _context;

        public EditModel(Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext context)
        {
            _context = context;
        }

        //Holds the buyer model.
        [BindProperty]
        public Buyer Buyer { get; set; }

        //Gets the buyer information using a lamda query.
        public  IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Buyer =  _context.Buyer.FirstOrDefault(m => m.Id == id);

            if (Buyer == null)
            {
                return NotFound();
            }
            return Page();
        }

        //updates the buyer.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Buyer).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerExists(Buyer.Id))
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

        private bool BuyerExists(string id)
        {
            return _context.Buyer.Any(e => e.Id == id);
        }
    }
}
