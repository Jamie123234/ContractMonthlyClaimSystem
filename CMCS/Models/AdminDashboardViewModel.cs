using System.Collections.Generic;

namespace CMCS.Models
{
    public class LecturerStats
    {
        public string LecturerName { get; set; }
        public decimal TotalClaimValue { get; set; }
        public int ClaimsSubmitted { get; set; }
        public double ApprovalRate { get; set; }
    }

    public class AdminDashboardViewModel
    {
        public int PendingClaims { get; set; }
        public int ApprovedClaims { get; set; }
        public int RejectedClaims { get; set; }
        public List<LecturerStats> TopLecturers { get; set; }
        public List<string> ChartLabels { get; set; }
        public List<int> ChartData { get; set; }
    }
}