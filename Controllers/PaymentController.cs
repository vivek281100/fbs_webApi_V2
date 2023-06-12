using fbs_webApi_v2.DTOs.paymentDtos;
using fbs_webApi_v2.services.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fbs_webApi_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentRepository _paymentRepository;
        
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        [Route("getPayments")]
        public async Task<IActionResult> getPayments()
        {
            try
            {
                var responce = await _paymentRepository.GetPaymentsAsync();
                return Ok(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getpaymentbybookingId")]
        public async Task<IActionResult> getpaymentbybookingid(int id)
        {
            try
            {
                var responce = await _paymentRepository.GetPaymentByBookingIdAsync(id);
                return Ok(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddPayment")]
        public async Task<IActionResult> addPayment(AddPaymentDto addPayment)
        {
            try
            {
                var responce = await _paymentRepository.AddPaymentAsync(addPayment);
                return Ok(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdatePayment")]
        public async Task<IActionResult> updatePayment(updatePaymentDto updatepayment)
        {
            try
            {
                var responce = await _paymentRepository.UpdatePaymentStatusAsync(updatepayment.Id, updatepayment.PaymentStatus);
                return Ok(responce);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> deletePayment(int id)
        {
            try
            {
                var responce = await _paymentRepository.DeletePaymentAsync(id);
                return Ok(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
