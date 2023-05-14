using System;
using fbs_webApi_v2.DataModels;

namespace fbs_webApi_v2.services.IRepositories
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetPaymentsAsync();

        Task<Payment> GetPaymentByIdAsync(int id);

        Task<List<Payment>> GetPaymentsByPayment_ModeAsync(string mode);

        Task<bool> AddPaymentAsync(Payment payment);

        Task<bool> UpdatePaymentStatusAsync(int id, bool status);

        Task<bool> DeletePaymentAsync(int id);
    }
}
