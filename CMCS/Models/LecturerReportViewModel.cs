using System.Collections.Generic;

namespace CMCS.Models
{
    public class LecturerReportViewModel
    {
        public int TotalClaimsSubmitted { get; set; }
        public int ApprovedClaims { get; set; }
        public double ApprovalRate { get; set; }
        public decimal TotalAmountClaimed { get; set; }
        public decimal TotalAmountApproved { get; set; }
        public decimal AverageClaimAmount { get; set; }
        public List<string> ChartLabels { get; set; }
        public List<decimal> ChartData { get; set; }
    }
}