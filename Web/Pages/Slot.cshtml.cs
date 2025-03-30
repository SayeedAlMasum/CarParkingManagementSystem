// Slot.cshtml.cs
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    [Authorize(Roles = "Admin")]
    public class SlotModel : PageModel
    {
        private readonly SlotService _slotService;

        public SlotModel()
        {
            _slotService = new SlotService();
        }

        public List<Slot> Slots { get; set; } = new List<Slot>();

        [BindProperty]
        public Slot Slot { get; set; } = new Slot();

        public void OnGet()
        {
            var result = _slotService.List();
            if (result.Success)
            {
                Slots = (List<Slot>)result.Data;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Log validation errors
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return Page();
            }

            // Log the course data before saving
            Console.WriteLine($"Title: {Slot.Title}, Description: {Slot.Description}, Category: {Slot.Category}, SubCategory: {Slot.SubCategory}, IsPremium: {Slot.IsBooked}");

            // Set the CreatedBy field to the current user's name
            Slot.CreatedBy = User.Identity?.Name ?? "System";

            var result = _slotService.AddSlot(Slot);
            if (result.Success)
            {
                return RedirectToPage("/Slot");
            }

            // Log the error message
            Console.WriteLine(result.Message);

            ModelState.AddModelError("", result.Message);
            OnGet();
            return Page();
        }
        public IActionResult OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                // Set the UpdatedBy field to the current user's name
                Slot.UpdatedBy = User.Identity?.Name ?? "System";

                var result = _slotService.UpdateSlot(Slot);
                if (result.Success)
                {
                    return RedirectToPage("/Slot");
                }
                ModelState.AddModelError("", result.Message);
            }
            OnGet();
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            var result = _slotService.DeleteSlot(id);
            if (result.Success)
            {
                return RedirectToPage("/Slot");
            }
            ModelState.AddModelError("", result.Message);
            OnGet();
            return Page();
        }

    }
}