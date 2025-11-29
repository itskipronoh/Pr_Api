namespace PR.Models.Entities

{
    using Microsoft.AspNetCore.Http.HttpResults;
    using PR.Models.Enums;
    public class Goal
    {
     public int Id { get; set; }
     public string Title { get; set; } = string.Empty;

     public string Description { get; set; } = string.Empty;
     public GoalCategory Category { get; set; }  // enum
     public decimal Weight { get; set; }         // percentage weight e.g. 20.5
     public DateTime StartDate { get; set; }
     public DateTime EndDate { get; set; }
     public GoalStatus Status { get; set; } = GoalStatus.Draft;
     public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
     public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public List<KPI> KPIs { get; set; } = new();

        // Approval Fields
     public string? ApprovalComment { get; set; }
     public int? ApprovedBy { get; set; }         // Executive Committee UserId
     public DateTime? ApprovedOn { get; set; }
        //public GoalStatus Status { get; set; }
        //public GoalCategory Category { get; set; }
     //public GoalType Type { get; set; }
        //public GoalLevel Level { get; set; }
        //public FeedbackStatus FeedbackStatus { get; set; }


    }
}
