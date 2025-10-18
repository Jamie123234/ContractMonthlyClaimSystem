using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CMCS.Data;
using CMCS.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CMCS.Controllers
{
    [Authorize(Roles = "ProgramCoordinator")]
    public class CoordinatorAppController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoordinatorAppController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var claims = await _context.Claims
                                       .Include(c => c.User)
                                       .OrderByDescending(c => c.SubmissionDate)
                                       .ToListAsync();
            return View(claims);
        }

        // New action to show claim details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claim = await _context.Claims
                                      .Include(c => c.User) // Include user details
                                      .FirstOrDefaultAsync(m => m.Id == id);

            if (claim == null)
            {
                return NotFound();
            }

            return View(claim);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int claimId, ClaimStatus newStatus)
        {
            var claim = await _context.Claims.FindAsync(claimId);
            if (claim != null)
            {
                claim.Status = newStatus;
                _context.Update(claim);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}