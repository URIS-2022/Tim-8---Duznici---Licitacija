namespace Lease.API.Entities;

/// <summary>
/// Represents a lease agreement with its properties and associated entities.
/// </summary>
public partial class DueDate
{
    /// <summary>
    /// Gets or sets the unique identifier of the lease agreement.
    /// </summary>
    public Guid Guid { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the due date.
    /// </summary>
    public Guid DueDateGuid { get; set; }

    /// <summary>
    /// Gets or sets the lease agreements associated with the due date.
    /// </summary>
    public virtual List<LeaseAgreement>? LeaseAgreements { get; set; }

    /// <summary>
    /// Gets or sets the date of the due date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Creates a new instance of the <see cref="DueDate"/> class.
    /// </summary>
    public DueDate() { }

    /// <summary>
    /// Creates a new instance of the <see cref="DueDate"/> class with the specified parameters.
    /// </summary>
    /// <param name="guid"> The unique identifier of the due date.</param>
    /// <param name="dueDateGuid"> The unique identifier of the due date.</param>
    public DueDate(Guid guid, Guid dueDateGuid) /*List<LeaseAgreement> leaseAgreements,*/
    {
        Guid = guid;
        Date = DateTime.Now.AddYears(2);
        DueDateGuid = dueDateGuid;
    }
}

