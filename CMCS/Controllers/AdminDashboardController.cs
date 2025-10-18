using CMCS.Data;
using CMCS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CMCS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminDashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            var claims = await _context.Claims.Include(c => c.User).ToListAsync();
            var lecturers = await _userManager.GetUsersInRoleAsync("Lecturer");

            var lecturerStats = new List<LecturerStats>();

            foreach (var lecturer in lecturers)
            {
                var lecturerClaims = claims.Where(c => c.UserId == lecturer.Id).ToList();
                if (lecturerClaims.Any())
                {
                    var totalClaims = lecturerClaims.Count;
                    var approvedClaims = lecturerClaims.Count(c => c.Status == ClaimStatus.Approved);

                    lecturerStats.Add(new LecturerStats
                    {
                        LecturerName = $"{lecturer.FirstName} {lecturer.LastName}",
                        TotalClaimValue = lecturerClaims.Sum(c => c.Amount),
                        ClaimsSubmitted = totalClaims,
                        ApprovalRate = totalClaims > 0 ? (double)approvedClaims / totalClaims * 100 : 0
                    });
                }
            }

            var monthlyClaims = claims
            .GroupBy(c => new { c.SubmissionDate.Year, c.SubmissionDate.Month })
            .Select(g => new
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                Count = g.Count()
            })
            .OrderBy(x => x.Year).ThenBy(x => x.Month)
            .ToList();

            var viewModel = new AdminDashboardViewModel
            {
                PendingClaims = claims.Count(c => c.Status == ClaimStatus.Pending),
                ApprovedClaims = claims.Count(c => c.Status == ClaimStatus.Approved),
                RejectedClaims = claims.Count(c => c.Status == ClaimStatus.Rejected),
                TopLecturers = lecturerStats.OrderByDescending(l => l.TotalClaimValue).Take(5).ToList(),
                ChartLabels = monthlyClaims.Select(mc => new DateTime(mc.Year, mc.Month, 1).ToString("MMM yyyy", CultureInfo.InvariantCulture)).ToList(),
                ChartData = monthlyClaims.Select(mc => mc.Count).ToList()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> ManageUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                userViewModels.Add(new UserViewModel
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Roles = await _userManager.GetRolesAsync(user)
                });
            }
            return View(userViewModels);
        }

        public async Task<IActionResult> EditUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var model = new EditUserRolesViewModel
            {
                UserId = user.Id,
                UserName = $"{user.FirstName} {user.LastName}",
                Roles = new List<RoleSelection>()
            };

            foreach (var role in _roleManager.Roles.ToList())
            {
                model.Roles.Add(new RoleSelection
                {
                    RoleName = role.Name,
                    IsSelected = await _userManager.IsInRoleAsync(user, role.Name)
                });
            }

            return View(model);
        }

        // POST: Updates the roles for a user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserRoles(EditUserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var selectedRoles = model.Roles.Where(r => r.IsSelected).Select(r => r.RoleName);

            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));
            if (!result.Succeeded)
            {
                // Handle error
                return View(model);
            }

            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));
            if (!result.Succeeded)
            {
                // Handle error
                return View(model);
            }

            return RedirectToAction(nameof(ManageUsers));
        }

        // GET: Displays all roles
        public async Task<IActionResult> ManageRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
    }
}