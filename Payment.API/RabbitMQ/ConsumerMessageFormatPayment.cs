namespace Payment.API.RabbitMQ
{
    internal class ConsumerMessageFormatPayment
    {
        public Guid Guid { get; set; }

        public int auctionedPrice { get; set; }
    }
}