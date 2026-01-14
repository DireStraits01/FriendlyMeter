using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyMeter.Shared.Models;

public class Metrics : BaseEntity
{
    public Guid FlatId { get; set; }
    public DateTime SubmittedDate { get; set; }
    public int ColdWaterValue { get; set; }
    public int HotWaterValue { get; set; }
    public int? ElectricityPhase1 { get; set; }
    public int? ElectricityPhase2 { get; set; }
    public int? ElectricityPhase3 { get; set; }

    public int TotalWaterConsumption()
    {
        return ColdWaterValue + HotWaterValue;
    }

    
    public decimal ColdWaterPriceAtSubmission { get; set; }
    public decimal HotWaterPriceAtSubmission { get; set; }
    public decimal SeweragePriceAtSubmission { get; set; }
    public decimal ElectricityPriceAtSubmissionPhase1 { get; set; }
    public decimal? ElectricityPriceAtSubmissionPhase2 { get; set; }
    public decimal? ElectricityPriceAtSubmissionPhase3 { get; set; }
}
