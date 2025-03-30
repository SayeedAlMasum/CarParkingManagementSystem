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
        // Initialize CarParkingContext for database operations
        CarParkingContext carParkingContext = new CarParkingContext();

        // Method to retrieve Slot details by ID
        public Result GetSlotById(int slotId)
        {
            try
            {
                // Retrieve the Slot by ID from the database
                var slot = carParkingContext.Slot.FirstOrDefault(c => c.SlotId == slotId);
                // Check if Slot exists
                if (slot == null)
                {
                    // Return failure result if Slot not found
                    return new Result(false, "Slot not found");
                }
                // Return success result with Slot details
                return new Result(true, "Success", slot);
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
                var slots = carParkingContext.Slot.ToList();
                // Return success result with Slot list
                return new Result(true, "Success", slots);
            }
            catch (Exception ex)
            {
                // Return failure result in case of exception
                return new Result(false, ex.Message);
            }
        }
        public Result AddSlot(Slot slot)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrEmpty(slot.Title))
                    return new Result(false, "Title is required.");
                if (string.IsNullOrEmpty(slot.Description))
                    return new Result(false, "Description is required.");
                if (string.IsNullOrEmpty(slot.Category))
                    return new Result(false, "Category is required.");
                if (string.IsNullOrEmpty(slot.SubCategory))
                    return new Result(false, "SubCategory is required.");
                // Set the slotId (if not auto-generated)
                if (slot.SlotId == 0)
                {
                    slot.SlotId = carParkingContext.Slot.Max(c => c.SlotId) + 1; // Manually set CourseId
                }
                // Set the CreatedDate of the course to the current date and time
                slot.CreatedDate = DateTime.Now;

                // Add the course to the database context
                carParkingContext.Slot.Add(slot);

                // Save changes to the database
                carParkingContext.SaveChanges();

                // Return a success result with a message
                return new Result(true, "slot added successfully");
            }
            catch (Exception ex)
            {
                // If an exception occurs, return a failure result with the error message
                return new Result(false, ex.Message);
            }
        }
        public Result UpdateSlot(Slot updatedSlot)
        {
            try
            {
                // Retrieve the Slot by ID from the database
                var slot = carParkingContext.Slot.FirstOrDefault(c => c.SlotId == updatedSlot.SlotId);
                // Check if Slot exists
                if (slot == null)
                {
                    // Return failure result if Slot not found
                    return new Result(false, "Slot not found");
                }
                // Update Slot properties with new values
                slot.Title = updatedSlot.Title;
                slot.Description = updatedSlot.Description;
                slot.Category = updatedSlot.Category;
                slot.SubCategory = updatedSlot.SubCategory;
                slot.UpdatedDate = DateTime.Now;
                slot.UpdatedBy = updatedSlot.UpdatedBy;

                // Save changes to the database
                carParkingContext.SaveChanges();

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
        public Result DeleteSlot(int slotId)
        {
            try
            {
                // Retrieve the Slot by ID from the database
                var slot = carParkingContext.Slot.FirstOrDefault(c => c.SlotId == slotId);

                // Check if Slot exists
                if (slot == null)
                {
                    // Return failure result if Slot not found
                    return new Result(false, "Slot not found");
                }

                // Remove the Slot from the database
                carParkingContext.Slot.Remove(slot);

                // Save changes to the database
                carParkingContext.SaveChanges();

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