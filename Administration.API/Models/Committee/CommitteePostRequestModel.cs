using System.Runtime.Serialization;

namespace Administration.API.Models.Committee;

/// <summary>
/// Represents a post request model for the document retrieval operation.
/// </summary>
[DataContract(Name = "Committee", Namespace = "")]
public class CommitteePostRequestModel
{
    /// <summary>
    /// Gets or sets the date when the committee was assembled.
    /// </summary>
    [DataMember]
    public DateTime DateAssembled { get; set; }

    /// <summary>
    /// Initializes a new instance of the CommitteePostRequestModel class.
    /// </summary>
    public CommitteePostRequestModel() { }
}
