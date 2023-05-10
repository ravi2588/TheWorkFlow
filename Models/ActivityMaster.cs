namespace TheWorkFlow.Models
{
    public class ActivityMaster
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string NameofActivity { get; set; }
        public string ActivityType { get; set; }
        public string Source { get; set; }

    }
}
