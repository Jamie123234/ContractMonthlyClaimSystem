using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CMCS.Models
{
    public class ClaimInputModel
    {
        [Required]
        [Display(Name = "Hours Worked")]
        [Range(0.1, 1000)]
        public decimal HoursWorked { get; set; }

        [Required]
        [Display(Name = "Hourly Rate")]
        [Range(1, 5000)]
        public decimal HourlyRate { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

        [StringLength(1000)]
        [Display(Name = "Additional Notes (Optional)")]
        public string AdditionalNotes { get; set; }

        public IFormFile Document { get; set; }
    }
}