﻿namespace Administration.API.Models;

public class MemberPatchRequestModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public MemberPatchRequestModel() { }
}
