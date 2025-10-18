using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMCS.Models
{
    public enum ClaimStatus { Pending, Approved, Rejected }

    public class Claim
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SubmissionDate { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [Range(0, 1000)]
        public decimal HoursWorked { get; set; }

        [Required]
        [Range(0, 5000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal HourlyRate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [StringLength(1000)]
        public string AdditionalNotes { get; set; }

        public ClaimStatus Status { get; set; }

        public string DocumentPath { get; set; }
    }
}