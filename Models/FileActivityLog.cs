using System.ComponentModel.DataAnnotations.Schema;

namespace TheWorkFlow.Models
{
    public class FileActivityLog
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FileId { get; set; }
        public string ActivityId { get; set; }
        public string StatusId { get; set; }
        public string? Comment { get; set; }
        public DateTime? Eta { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        [ForeignKey("FileId")]
        public FileMaster FileMaster { get; set; }

        [ForeignKey("ActivityId")]
        public ActivityMaster ActivityMaster { get; set; }

        [ForeignKey("StatusId")]
        public StatusMaster StatusMaster { get; set; }

    }
}
