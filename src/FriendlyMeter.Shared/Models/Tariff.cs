using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyMeter.Shared.Models;

public class Tariff : BaseEntity
{
    public string Name { get; set; }
    public Guid OwnerId { get; set; }
    public User? Owner { get; set; }

    public int ElectricityPhasesCount { get; set; }
    public decimal ElectricityPricePhase1 { get; set; }
    public decimal? ElectricityPricePhase2 { get; set; }
    public decimal? ElectricityPricePhase3 { get; set; }

    public decimal ColdWaterPrice { get; set; }
    public decimal HotWaterPrice { get; set; }
    public decimal SeweragePrice { get; set; }
}
