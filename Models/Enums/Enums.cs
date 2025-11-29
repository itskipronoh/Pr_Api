namespace PR.Models.Enums
{

    public enum UserRole
    {
        Admin,
        HR,
        Manager,
        Employee,
        Exco
    }

    
    public enum GoalStatus
    {
        Draft = 1,
        SubmittedForApproval = 2,
        Approved = 3,
        Rejected = 4,
        Locked = 5
    }

      public enum ApprovalAction
      {
       Approve = 1,
       Reject = 2
      }


    public enum GoalType
    {
        Functional,
        Organizational,
        Skills
    }

    public enum GoalLevel
    {
        Individual,
        Team,
        Department,
        Enterprise
    }

    public enum GoalCategory
    {
        Financial = 1,
        Growth = 2,
        Operational = 3,
        Customer = 4,
        Innovation = 5
    }


    public enum FeedbackStatus
    {
        Draft,
        Pending,
        Reviewed,
        Finalized
    }

}
