namespace PR.Models.Entities
{
    public class KPI
    {
        public int Id { get; set; }
        public string Name { get; set; }  // e.g. "Increase revenue by 10%"
        public string? MeasurementUnit { get; set; } // optional
        public decimal? TargetValue { get; set; }    // optional
        //public int GoalId { get; set; }
        //public Goal Goal { get; set; }
    }

}
