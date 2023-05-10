using System;
using fbs_webApi_v2.DataModels;

namespace fbs_webApi_v2.IRepositories
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetPaymentsAsync(int id);

        Task<Payment> GetPaymentByIdAsync(int id);

        Task<List<Payment>> GetPaymentsByPayment_ModeAsync(string mode);

        Task<Payment> AddPaymentAsync(Payment payment);

        Task<Payment> UpdatePaymentAsync(Payment payment);

        Task DeletePaymentAsync(int id);
    }
}
