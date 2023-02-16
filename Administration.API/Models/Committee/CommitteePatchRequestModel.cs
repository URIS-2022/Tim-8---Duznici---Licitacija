using System.Runtime.Serialization;

namespace Administration.API.Models.Committee;

/// <summary>
/// Represents a patch request model for the document retrieval operation.
/// </summary>
[DataContract(Name = "Committee", Namespace = "")]
public class CommitteePatchRequestModel
{
    /// <summary>
    /// Gets or sets the date when the committee was assembled.
    /// </summary>
    public DateTime DateAssembled { get; set; }

    /// <summary>
    /// Initializes a new instance of the CommitteePatchRequestModel class.
    /// </summary>
    public CommitteePatchRequestModel() { }
}
