using System.Runtime.Serialization;

namespace Licitation.API.Models.Licitation
{
    /**
    Represents a response model for licitation.
    */
    [DataContract(Name = "Licitation", Namespace = "")]
    public class LicitationResponseModel
    {
        /// <summary>
        /// The identifier of the licitation.
        /// </summary>
        [DataMember]
        public Guid Guid { get; set; }
        /// <summary>
        /// The Stage of the licitation.
        /// </summary>
        [DataMember]
        public int Stage { get; set; }
        /// <summary>
        /// The Date of the licitation.
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }
        /// <summary>
        /// The Year of the licitation.
        /// </summary>
        [DataMember]
        public int Year { get; set; }
        /// <summary>
        /// The Constarint of the licitation.
        /// </summary>
        [DataMember]
        public int Constarint { get; set; }
        /// <summary>
        /// The BidIncrement of the licitation.
        /// </summary>
        [DataMember]
        public int BidIncrement { get; set; }
        /// <summary>
        /// The ApplicationDeadline of the licitation.
        /// </summary>
        [DataMember]
        public DateTime ApplicationDeadline { get; set; }
        /// <summary>
        /// The collection of lands.
        /// </summary>
        [DataMember]
        public IEnumerable<LicitationLandLicitationResponseModel> LicitationLands { get; set; }
        /// <summary>
        /// The collection of public biddings.
        /// </summary>
        [DataMember]
        public IEnumerable<LicitationPublicBiddingLicitationResponseModel> LicitationPublicBiddings { get; set; }

        /// <summary>
        /// The representing empty constructor.
        /// </summary>
        public LicitationResponseModel()
        {

        }
    }
}
