//SlotService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Database.Model;

namespace Business.Services
{
    public class SlotService
    {
        // Initialize SkillExchangeContext for database operations
        CarParkingContext skillExchangeContext = new CarParkingContext();

        // Method to retrieve Slot details by ID
        public Result GetSlotById(int SlotId)
        {
            try
            {
                // Retrieve the Slot by ID from the database
                var Slot = skillExchangeContext.Slot.FirstOrDefault(c => c.SlotId == SlotId);
                // Check if Slot exists
                if (Slot == null)
                {
                    // Return failure result if Slot not found
                    return new Result(false, "Slot not found");
                }
                // Return success result with Slot details
                return new Result(true, "Success", Slot);
            }
            catch (Exception ex)
            {
                // Return failure result in case of exception
                return new Result(false, ex.Message);
            }
        }
        // Method to list all Slots
        public Result List()
        { //logics
            try
            {
                // Retrieve all Slots from the database
                var Slots = skillExchangeContext.Slot.ToList();
                // Return success result with Slot list
                return new Result(true, "Success", Slots);
            }
            catch (Exception ex)
            {
                // Return failure result in case of exception
                return new Result(false, ex.Message);
            }
        }
        public Result UpdateSlot(Slot updatedSlot)
        {
            try
            {
                // Retrieve the Slot by ID from the database
                var Slot = skillExchangeContext.Slot.FirstOrDefault(c => c.SlotId == updatedSlot.SlotId);
                // Check if Slot exists
                if (Slot == null)
                {
                    // Return failure result if Slot not found
                    return new Result(false, "Slot not found");
                }
                // Update Slot properties with new values
                Slot.Title = updatedSlot.Title;
                Slot.Description = updatedSlot.Description;
                Slot.Category = updatedSlot.Category;
                Slot.SubCategory = updatedSlot.SubCategory;
                Slot.UpdatedDate = DateTime.Now;
                Slot.UpdatedBy = updatedSlot.UpdatedBy;

                // Save changes to the database
                skillExchangeContext.SaveChanges();

                // Return success result after update
                return new Result(true, "Slot updated successfully");
            }
            catch (Exception ex)
            {
                // Return failure result in case of exception
                return new Result(false, ex.Message);
            }
        }

        // Method to delete a Slot by ID
        public Result DeleteSlot(int SlotId)
        {
            try
            {
                // Retrieve the Slot by ID from the database
                var Slot = skillExchangeContext.Slot.FirstOrDefault(c => c.SlotId == SlotId);

                // Check if Slot exists
                if (Slot == null)
                {
                    // Return failure result if Slot not found
                    return new Result(false, "Slot not found");
                }

                // Remove the Slot from the database
                skillExchangeContext.Slot.Remove(Slot);

                // Save changes to the database
                skillExchangeContext.SaveChanges();

                // Return success result after deletion
                return new Result(true, "Slot deleted successfully");
            }
            catch (Exception ex)
            {
                // Return failure result in case of exception
                return new Result(false, ex.Message);
            }
        }
    }
}
