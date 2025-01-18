//PaymentService.cs
using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class PaymentService
    {
        private readonly DbContext _context;

        public PaymentService(DbContext context)
        {
            _context = context;
        }

        public async Task<bool> ProcessPaymentAsync(string userInfoId, string SlotId, string cardNumber, string expiryDate, string cvv)
        {
            // Validate payment details (e.g., card details and expiry date)
            if (string.IsNullOrWhiteSpace(cardNumber) || string.IsNullOrWhiteSpace(expiryDate) || string.IsNullOrWhiteSpace(cvv))
                return false;

            // Convert SlotId to int
            if (!int.TryParse(SlotId, out int SlotIdInt))
                return false; // Invalid SlotId format

            // Check if the Slot exists
            var Slot = await _context.Set<Slot>().FindAsync(SlotIdInt);
            if (Slot == null)
                return false;

            // Create payment record
            var payment = new Payment
            {
                UserInfoId = userInfoId,
                SlotId = SlotIdInt, // Use the converted int value
                PaymentStatus = "Success", // Assuming a successful payment
                CardNumber = cardNumber,
                ExpiryDate = DateTime.Parse(expiryDate), // Convert expiryDate to DateTime
                CVV = cvv
            };

            await _context.Set<Payment>().AddAsync(payment);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<List<Payment>> GetPaymentsForUserAsync(string userInfoId)
        {
            return await _context.Set<Payment>()
                .Where(p => p.UserInfoId == userInfoId)
                .ToListAsync();
        }
    }
}
