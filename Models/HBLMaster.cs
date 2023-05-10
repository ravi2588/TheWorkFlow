using System.ComponentModel.DataAnnotations.Schema;

namespace TheWorkFlow.Models
{
    public class HBLMaster
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string HBLNumber { get; set; }
        public string Booking { get; set; }
        public string FileId { get; set; }

        [ForeignKey("FileId")]
        public FileMaster FileMaster { get; set; }
        public List<HBLActivityLog> HBLActivityLog { get; set; }

    }
}
