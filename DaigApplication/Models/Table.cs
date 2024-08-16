using System;
using System.Collections.Generic;

namespace DaigApplication.Models;

public partial class Table
{
    public int Id { get; set; }

    public string? DaigType { get; set; }

    public string? DaigStatus { get; set; }

    public string? DaigAvailability { get; set; }
}
