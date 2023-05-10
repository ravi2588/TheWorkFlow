namespace TheWorkFlow.Models
{
    public class FileActivityLogHistory
    {
        public string Id{ get; set; } = Guid.NewGuid().ToString();
        public string FilelogId { get; set; }
        public string? ActivityId { get; set; }
        public string? StatusId { get; set; }
        public string? Comment { get; set; }
        public DateTime? Eta { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
