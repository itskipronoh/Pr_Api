using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PR.Data;
using PR.Models.DTOs;
using PR.Models.Enums;

[ApiController]
[Route("api/approvals")]
public class ApprovalController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ApprovalController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 1. Get Pending Approval
    [Authorize(Roles = "Exco,Admin")]
    [HttpGet("pending")]
    public async Task<IActionResult> GetPending()
    {
        var pending = await _context.Goals
            .Where(g => g.Status == GoalStatus.SubmittedForApproval)
            .ToListAsync();

        return Ok(pending);
    }

    // 2. Approve / Reject
    [Authorize(Roles = "Exco,Admin")]
    [HttpPost]
    public async Task<IActionResult> ApproveOrReject(ApprovalActionDto dto)
    {
        var goal = await _context.Goals.FindAsync(dto.GoalId);
        if (goal == null) return NotFound();

        if (goal.Status != GoalStatus.SubmittedForApproval)
            return BadRequest("Goal is not pending approval.");

        if (dto.Action == ApprovalAction.Approve)
        {
            goal.Status = GoalStatus.Approved;
            goal.ApprovalComment = dto.Comment;
            goal.ApprovedBy = 1; // TODO: replace with logged-in user
            goal.ApprovedOn = DateTime.Now;
        }
        else
        {
            goal.Status = GoalStatus.Rejected;
            goal.ApprovalComment = dto.Comment;
        }

        await _context.SaveChangesAsync();
        return Ok("Action completed.");
    }
}
