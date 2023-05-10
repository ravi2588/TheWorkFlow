using System.ComponentModel.DataAnnotations.Schema;

namespace TheWorkFlow.Models
{
    public class HBLActivityLog
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? HblId { get; set; }
        public string? ActivityId { get; set; }
        public string? StatusId { get; set; }
        public string? Comment { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        [ForeignKey("HblId")]
        public HBLMaster HBLMaster { get; set; }

        [ForeignKey("ActivityId")]
        public ActivityMaster ActivityMaster { get; set; }

        [ForeignKey("StatusId")]
        public StatusMaster StatusMaster { get; set; }
    }
}
