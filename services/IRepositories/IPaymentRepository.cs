using System;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.DTOs.paymentDtos;

namespace fbs_webApi_v2.services.IRepositories
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetPaymentsAsync();

        Task<serviceResponce<GetPaymentDto>> GetPaymentByBookingIdAsync(int id);

        Task<List<Payment>> GetPaymentsByPayment_ModeAsync(string mode);

        Task<serviceResponce<GetPaymentDto>> AddPaymentAsync(AddPaymentDto payment);

        Task<bool> UpdatePaymentStatusAsync(int id, bool status);

        Task<bool> DeletePaymentAsync(int id);
    }
}
