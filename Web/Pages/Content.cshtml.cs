using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Business.Services;
using Database.Model;
using System;

namespace Web.Pages
{
    public class ContentModel : PageModel
    {
        public Slot Slot { get; set; }
        public bool IsEnrolled { get; set; }

        public void OnGet(int SlotId)
        {
            // Retrieve the Slot from the service based on SlotId
            var result = new SlotService().GetSlotById(SlotId);

            if (result.Success && result.Data is Slot Slot)
            {
                Slot = Slot;
                // Check if the user is enrolled (you can implement user validation based on session or authentication)
                // Assuming you have a service for checking enrollment.
                IsEnrolled = CheckIfUserIsEnrolled(SlotId);
            }
            else
            {
                // Handle the case when the Slot isn't found
                // Redirect to the available Slots page or show an error message
                RedirectToPage("/UserSlots");
            }
        }

        private bool CheckIfUserIsEnrolled(int SlotId)
        {
            // Replace with actual logic to check if the user is enrolled in the Slot
            // For example, query the database for the user enrollment status
            return true; // Assuming the user is always enrolled for now
        }
    }
}
