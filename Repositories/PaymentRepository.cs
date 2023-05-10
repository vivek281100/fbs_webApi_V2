using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.IRepositories;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;

namespace fbs_webApi_v2.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public Task<Payment> AddPaymentAsync(Payment payment)
        {
            throw new NotImplementedException();
        }

        public Task DeletePaymentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetPaymentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetPaymentsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetPaymentsByPayment_ModeAsync(string mode)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> UpdatePaymentAsync(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
