//UserSlot.cshtml
using System.Collections.Generic;
using Business.Services;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class UserSlotsModel : PageModel
    {
        public List<Slot> Slots { get; set; } = new List<Slot>();

        public void OnGet()
        {
            // Load Slots from the service
            var result = new SlotService().List();
            if (result.Success)
            {
                Slots = (List<Slot>)result.Data;
            }
        }
    }
}
