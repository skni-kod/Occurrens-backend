namespace occurrensBackend.Entities.DatabaseEntities
{
    public class Is_opened
    {
        public Guid Id { get; set; }
        public string Monday { get; set; } = "Zamknięte";
        public string Tuesday { get; set; } = "Zamknięte";
        public string Wednesday { get; set; } = "Zamknięte";
        public string Thursday { get; set; } = "Zamknięte";
        public string Fridady { get; set; } = "Zamknięte";
        public string Saturday { get; set; } = "Zamknięte";
        public string Sunday { get; set; } = "Zamknięte";

 
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
