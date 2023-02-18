namespace Bidding.API.RabbitMQ
{
    public class ProducerMessageFormatPayment
    {
        public Guid Guid { get; set; }

        public int auctionedPrice { get; set; }

    }
}
