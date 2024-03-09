namespace occurrensBackend.Entities.DatabaseEntities
{
    public class Specialization
    {
        public Guid Id { get; set; } 
        public string Specjalization { get; set; }

        public Doctor Doctor { get; set; }
        public Guid? DoctorId { get; set; } 
    }
}
