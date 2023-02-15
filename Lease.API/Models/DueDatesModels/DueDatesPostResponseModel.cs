﻿using Lease.API.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lease.API.Models;

[DataContract(Name = "Lease", Namespace = "")]
public class DueDatePostResponseModel
{
    [DataMember]
    public Guid Guid { get; set; }

    [DataMember]
    public DateTime Date { get; set; }



    public DueDatePostResponseModel(Guid guid,DateTime date)
    {
        Guid= guid;
        Date = date;
    }
}