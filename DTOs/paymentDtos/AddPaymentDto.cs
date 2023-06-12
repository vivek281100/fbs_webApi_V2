using System.ComponentModel.DataAnnotations;

namespace fbs_webApi_v2.DTOs.paymentDtos
{
    public class AddPaymentDto
    {
       
        public string Payment_Mode { get; set; }

        
        public decimal Total_Price { get; set; }

        public bool PaymentStatus { get; set; }

        public int bookingid { get; set; }
    }
}
