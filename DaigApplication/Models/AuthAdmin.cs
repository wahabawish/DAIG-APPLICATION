using System;
using System.Collections.Generic;

namespace DaigApplication.Models;

public partial class AuthAdmin
{
    public int Id { get; set; }

    public string? Usernameis { get; set; }

    public string? Passwordis { get; set; }

    public string? Emailis { get; set; }
}
