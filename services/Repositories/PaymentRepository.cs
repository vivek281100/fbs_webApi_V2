using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;
using fbs_webApi_v2.services.IRepositories;

namespace fbs_webApi_v2.services.Repositories
{
    public class PaymentRepository
    {
        //private readonly fbscontext _context;
        //public PaymentRepository(fbscontext context)
        //{
        //    _context = context;
        //}
        //public async Task<bool> AddPaymentAsync(Payment payment)
        //{
        //    var checkpayment = await _context.payments.FindAsync(payment.Payment_Id);
        //    if (checkpayment == null)
        //    {
        //        await _context.payments.AddAsync(payment);
        //        await _context.SaveChangesAsync();
        //        return true;

        //    }
        //    return false;
        //}

        //public async Task<bool> DeletePaymentAsync(int id)
        //{
        //    var checkpayment = await _context.payments.FindAsync(id);
        //    if (checkpayment == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public async Task<Payment> GetPaymentByIdAsync(int id)
        //{
        //    var payment = await _context.payments.FindAsync(id);
        //    return payment;
        //}

        //public async Task<List<Payment>> GetPaymentsAsync()
        //{
        //    return await _context.payments.ToListAsync();
        //}

        //public async Task<List<Payment>> GetPaymentsByPayment_ModeAsync(string mode)
        //{
        //    var payment = await _context.payments.Where(p => p.Payment_Mode == mode).ToListAsync();
        //    return payment;
        //}

        //public async Task<bool> UpdatePaymentStatusAsync(int id, bool status)
        //{
        //    var payment = await _context.payments.FindAsync(id);
        //    if (payment != null)
        //    {
        //        //payment.Payment_Mode = updatepayment.Payment_Mode;
        //        //payment.Total_Price = updatepayment.Total_Price;
        //        payment.PaymentStatus = status;

        //        await _context.SaveChangesAsync();
        //        return true;

        //    }
        //    return false;

        //}
    }
}
