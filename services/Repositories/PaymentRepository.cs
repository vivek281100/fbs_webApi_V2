using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;
using fbs_webApi_v2.services.IRepositories;
using fbs_webApi_v2.DTOs.paymentDtos;
using AutoMapper;

namespace fbs_webApi_v2.services.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly fbscontext _context;
        private readonly IMapper _mapper;
        public PaymentRepository(fbscontext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<serviceResponce<GetPaymentDto>> AddPaymentAsync(AddPaymentDto payment)
        {
            var responce = new serviceResponce<GetPaymentDto>();
            try
            {
                var checkpayment = await _context.payments.Where(p => p.bookingid == payment.bookingid).FirstOrDefaultAsync();
                if (checkpayment == null)
                {
                    var addpayment = _mapper.Map<Payment>(payment);
                    await _context.payments.AddAsync(addpayment);
                    await _context.SaveChangesAsync();

                    responce.Success = true;
                    responce.Data = _mapper.Map<GetPaymentDto>(addpayment);
                    responce.Message = "Payment Done";
                    return responce;

                }
                else
                {
                    responce.Success = false;
                    responce.Data = null;
                    responce.Message = "Payment Failed";
                    return responce;
                }
            }
            catch (Exception ex)
            {
                responce.Success = false;
                responce.Message = ex.Message;
                return responce;
            }
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var checkpayment = await _context.payments.FindAsync(id);
            if (checkpayment == null)
            {
                return false;
            }
            return true;
        }

        public async Task<serviceResponce<GetPaymentDto>> GetPaymentByBookingIdAsync(int id)
        {
            var responce = new serviceResponce<GetPaymentDto>();
            try
            {
                var payment = await _context.payments.Where(p => p.bookingid == id).FirstOrDefaultAsync();
                if (payment != null)
                {
                    responce.Data = _mapper.Map<GetPaymentDto>(payment);
                    responce.Success = true;
                    responce.Message = "retreved";
                    return responce;
                }
                else
                {
                    responce.Success = false;
                    responce.Message = " Payment pending for this booking";
                    return responce;
                }
            }
            catch (Exception ex)
            {
                responce.Success = false;
                responce.Data = null;   
                responce.Message = ex.Message;
                return responce;
            }
        }

        public async Task<List<Payment>> GetPaymentsAsync()
        {
            return await _context.payments.ToListAsync();
        }

        public async Task<List<Payment>> GetPaymentsByPayment_ModeAsync(string mode)
        {
            var payment = await _context.payments.Where(p => p.Payment_Mode == mode).ToListAsync();
            return payment;
        }

        public async Task<bool> UpdatePaymentStatusAsync(int id, bool status)
        {
            var payment = await _context.payments.FindAsync(id);
            if (payment != null)
            {
                //payment.Payment_Mode = updatepayment.Payment_Mode;
                //payment.Total_Price = updatepayment.Total_Price;
                payment.PaymentStatus = status;

                await _context.SaveChangesAsync();
                return true;

            }
            return false;

        }
    }
}
