namespace Preparation.API.Entities
{
    public class Document
    {
        public Guid DocumentID { get; set; }
        public Guid AnnouncementID { get; set; }
        public DocumentType DocumentType { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public string ReferenceNumber { get; set; }
        public DateOnly DateSubmitted { get; set; }
        public DateOnly DateCertified { get; set; }
        public string Template { get; set; }
    }
}
