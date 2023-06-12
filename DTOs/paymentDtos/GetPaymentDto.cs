namespace fbs_webApi_v2.DTOs.paymentDtos
{
    public class GetPaymentDto
    {
        public int Id { get; set; }


        public DateTime Payment_DateTime { get; set; } = DateTime.Now;


        public string Payment_Mode { get; set; }


        public decimal Total_Price { get; set; }

        public bool PaymentStatus { get; set; }

        public int bookingid { get; set; }
    }
}
