// EditSlot.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Business.Services;
using Database.Model;
using System;
using Database.Context;
using System.Linq;

namespace Web.Pages
{
    public class EditSlotModel : PageModel
    {
        [BindProperty]
        public Slot Slot { get; set; }

        public IActionResult OnGet(int id)
        {
            var result = new SlotService().GetSlotById(id);

            if (result.Success && result.Data is Slot Slot)
            {
                Slot = Slot;
                return Page();
            }

            return RedirectToPage("/Slot");
        }

        public IActionResult OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var context = new CarParkingContext())
                    {
                        var existingSlot = context.Slot.FirstOrDefault(c => c.SlotId == Slot.SlotId);

                        if (existingSlot == null)
                        {
                            ModelState.AddModelError(string.Empty, "Slot not found.");
                            return Page();
                        }

                        existingSlot.Title = Slot.Title;
                        existingSlot.Description = Slot.Description;
                        existingSlot.Category = Slot.Category;
                        existingSlot.SubCategory = Slot.SubCategory;
                        existingSlot.IsBooked = Slot.IsBooked;
                        existingSlot.UpdatedDate = DateTime.Now;

                        context.SaveChanges();
                    }

                    return RedirectToPage("/Slot");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            return Page();
        }
    }
}
