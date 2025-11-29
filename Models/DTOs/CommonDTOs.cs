  
namespace PR.Models.DTOs;

using Microsoft.AspNetCore.Mvc;
using   PR.Models.Enums;



// AUTH DTOs
public class LoginDTO
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}



//USER DTOs
public class RegisterUserDTO
{
    public string EmployeeId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public UserRole Role { get; set; }
    public string? Department { get; set; }
    public string? JobTitle { get; set; }

    public DateTime HireDate { get; set; } = DateTime.UtcNow;
}


// KPI DTOs

public class KpiDto
{
    public required string Name { get; set; }  // e.g. "Increase revenue by 10%"
    public string? MeasurementUnit { get; set; } // optional
    public decimal? TargetValue { get; set; }    // optional
}
// Exco Create Goal DTOs
public class GoalCreateDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public GoalCategory Category { get; set; }
    public decimal Weight { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public required List<KpiDto> KPIs { get; set; }
}

// Exco Approve/Reject Goal DTO
public class GoalApprovalDto
{
    public int GoalId { get; set; }
    public ApprovalAction Action { get; set; }
    public string? Comment { get; set; }
}

// GoalUpdateDto

public class GoalUpdateDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public GoalCategory Category { get; set; }
    public decimal Weight { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public required List<KpiDto> KPIs { get; set; }
}

public class GoalResponseDto
{
    public int Id { get; set; }

    public required string Title { get; set; }
    public required string Description { get; set; }
    public GoalCategory Category { get; set; }
    public decimal Weight { get; set; }

    public GoalStatus Status { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public required List<KpiDto> KPIs { get; set; }

    public string? ApprovalComment { get; set; }
    public int? ApprovedBy { get; set; }
    public DateTime? ApprovedOn { get; set; }
}

//Exco submit goals DTO

public class SubmitForApprovalDto
{
    public int GoalId { get; set; }
}

// Exco Approval Action DTO
public class ApprovalActionDto
{
    public int GoalId { get; set; }
    public ApprovalAction Action { get; set; }
    public string? Comment { get; set; }
}
