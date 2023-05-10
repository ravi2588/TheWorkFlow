namespace TheWorkFlow.Models
{
    public class FileMaster
    {
        public string Id { get; set; } =Guid.NewGuid().ToString();
        public string FileNumber { get; set; }
        public string Country { get; set; }
        public DateTime Eta { get; set; }
        public DateTime PriviousEta { get; set; }
        public string EtachangedBy { get; set; }
        public DateTime DrafCutOff { get; set; }
        public int HblCount { get; set; }
        public List<FileActivityLog> FileActivityLog { get; set; }
        public List<HBLMaster> HBLMasters { get; set; }


    }
}
