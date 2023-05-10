namespace TheWorkFlow.Models
{
    public class CountryMaster
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

    }
}
