namespace occurrensBackend.Entities.DatabaseEntities
{
    public class Disease
    {
        public Guid Id { get; set; }
        public Guid CreatedByDoctor { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Medicines { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);


        public Guid? PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
