namespace occurrensBackend.Entities.DatabaseEntities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public int Building_number { get; set; }
        public int? Apartament_number { get; set; } = null;
        public string Postal_code { get; set; }
        public string City { get; set; }



        public Guid? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        


        public List<Is_opened> is_opened { get; set; }
    }
}
