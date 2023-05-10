namespace TheWorkFlow.Models
{
    public class HBLActivityLogHistory
    {
        public Guid Id { get; set; } = new Guid();
        public string HbllogId { get; set; }
        public string ActivityId { get; set; }
        public string StatusId { get; set; }
        public string? Comment { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
