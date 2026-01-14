using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyMeter.Shared.Models;

public class Flat : BaseEntity
{
    public string Name { get; set; }
    public List<Metrics>? Metrics { get; set; }
    public Guid? FlatTariffId { get; set; }
    public Tariff? FlatTariff { get; set; }
    public Guid OwnerId { get; set; }
    public Guid? RenterId {get; set; }
    public User Owner { get; set; }
     public User? Renter { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? Number { get; set; }
    public string? ZipCode { get; set; }
}