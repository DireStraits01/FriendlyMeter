using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyMeter.Shared.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
}
