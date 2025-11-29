using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PR.Data;
using PR.Models.DTOs;
using PR.Models.Entities;
using PR.Models.Enums;

[ApiController]
[Route("api/goals")]
public class GoalController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public GoalController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 1. Create Goal
    [Authorize(Roles = "Exco,Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateGoal(GoalCreateDto dto)
    {
        var goal = new Goal
        {
            Title = dto.Title,
            Description = dto.Description,
            Category = dto.Category,
            Weight = dto.Weight,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Status = GoalStatus.Draft,
            KPIs = dto.KPIs.Select(k => new KPI
            {
                Name = k.Name,
                MeasurementUnit = k.MeasurementUnit,
                TargetValue = k.TargetValue
            }).ToList()
        };

        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        return Ok(goal.Id);
    }

    // 2. Update Goal (only if Draft)
    [Authorize(Roles = "Exco,Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGoal(int id, GoalUpdateDto dto)
    {
        var goal = await _context.Goals.Include(g => g.KPIs)
                                       .FirstOrDefaultAsync(g => g.Id == id);

        if (goal == null) return NotFound();
        if (goal.Status != GoalStatus.Draft)
            return BadRequest("Goal cannot be edited after submission.");

        goal.Title = dto.Title;
        goal.Description = dto.Description;
        goal.Category = dto.Category;
        goal.Weight = dto.Weight;
        goal.StartDate = dto.StartDate;
        goal.EndDate = dto.EndDate;

        // Update KPIs
        goal.KPIs.Clear();
        goal.KPIs = dto.KPIs.Select(k => new KPI
        {
            Name = k.Name,
            MeasurementUnit = k.MeasurementUnit,
            TargetValue = k.TargetValue
        }).ToList();

        await _context.SaveChangesAsync();

        return Ok("Updated");
    }

    // 3. Submit Goal for Approval
    [Authorize(Roles = "Exco,Admin")]
    [HttpPost("submit")]
    public async Task<IActionResult> SubmitGoal(SubmitForApprovalDto dto)
    {
        var goal = await _context.Goals.FindAsync(dto.GoalId);
        if (goal == null) return NotFound();

        if (goal.Status != GoalStatus.Draft)
            return BadRequest("Only draft goals can be submitted.");

        goal.Status = GoalStatus.SubmittedForApproval;
        await _context.SaveChangesAsync();

        return Ok("Submitted for approval");
    }
}
