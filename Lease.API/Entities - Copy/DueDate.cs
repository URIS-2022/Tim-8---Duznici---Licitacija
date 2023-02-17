namespace Lease.API.Entities;

public partial class DueDate //: IValidatableObject
{

    public Guid Guid { get; set; }

    public Guid DueDateGuid;
    

    public virtual List<LeaseAgreement> LeaseAgreements { get; set; }

    public DateTime Date { get; set; }

    public DueDate() { }

     public DueDate(Guid guid, Guid dueDateGuid) /*List<LeaseAgreement> leaseAgreements,*/ 
    {
        Guid = guid;
        Date = DateTime.Now.AddYears(2);
        DueDateGuid = dueDateGuid;
    }
}

