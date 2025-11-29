using PR.Models.Enums;

namespace PR.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string? Department { get; set; }
        public string? JobTitle { get; set; }
        public bool IsActive { get; set; } = true;
        public UserRole Role { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }

}
