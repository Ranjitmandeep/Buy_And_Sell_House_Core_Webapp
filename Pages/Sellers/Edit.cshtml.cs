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

namespace Buy_And_Sell_House_Core_Webapp.Pages.Shared.Sellers
{
    public class EditModel : PageModel
    {
        //Holds the databas context.
        private readonly Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext _context;

        public EditModel(Buy_And_Sell_House_Core_Webapp.Models.Buy_And_Sell_House_Core_WebappContext context)
        {
            _context = context;
        }

        //Holds seller model
        [BindProperty]
        public Seller Seller { get; set; }

        //Gets seller infomation using lambda query.
        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seller =  _context.Seller
                .Include(s => s.House).FirstOrDefault(m => m.Id == id);

            if (Seller == null)
            {
                return NotFound();
            }
            if (Seller.House != null)
            {
                ViewData["HouseId"] = new SelectList(_context.House, "Id", "HouseAddress", Seller.House.Id);
            } else {

                ViewData["HouseId"] = new SelectList(_context.House, "Id", "HouseAddress");
            }
            return Page();
        }

        //Updates the seller.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Seller).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(Seller.Id))
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

        private bool SellerExists(string id)
        {
            return _context.Seller.Any(e => e.Id == id);
        }
    }
}
