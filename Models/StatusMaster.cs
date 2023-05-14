namespace TheWorkFlow.Models
{
    public class StatusMaster
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? StatusName { get; set; }
        public string? StatusType { get; set; }
        public Boolean? IsDelete { get; set; } = false;
    }
}
