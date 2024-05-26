﻿using PetConnect.Backend.Core.Abstractions;

namespace PetConnect.Backend.Core;

public class Booking
{
    public long Id { get; set; }

    public Service Service { get; set; }
    public long ServiceId { get; set; }

    public PetOwnerProfile Customer { get; set; }
    public long CustomerId { get; set; }

    public DateTime StartedDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }
    public Status Status { get; set; }
    public string ServiceAdrress { get; set; } = string.Empty;
    public string AdditionalRequirments { get; set; } = string.Empty;
    public string CustomerComment { get; set; } = string.Empty;
}